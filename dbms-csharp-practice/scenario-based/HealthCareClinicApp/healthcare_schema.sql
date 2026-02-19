-- HEALTHCARE CLINIC DATABASE - MS SQL SERVER
-- Complete Database Schema with Tables, Constraints, and Indexes
-- Drop existing database if exists and create new
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'HealthCareClinic')
BEGIN
    ALTER DATABASE HealthCareClinic SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE HealthCareClinic;
END
GO
CREATE DATABASE HealthCareClinic;
GO
USE HealthCareClinic;
GO
-- TABLE 1: SPECIALTIES (Lookup Table)
CREATE TABLE specialties (
    specialty_id INT IDENTITY(1,1) PRIMARY KEY,
    specialty_name NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(500),
    is_active BIT DEFAULT 1,
    created_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT chk_specialty_name CHECK (LEN(specialty_name) > 0)
);
GO
-- TABLE 2: DOCTORS
CREATE TABLE doctors (
    doctor_id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_name NVARCHAR(100) NOT NULL,
    specialty_id INT NOT NULL,
    contact_number NVARCHAR(15) NOT NULL UNIQUE,
    email NVARCHAR(100) UNIQUE,
    consultation_fee DECIMAL(10,2) NOT NULL,
    is_active BIT DEFAULT 1,
    created_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_doctor_specialty FOREIGN KEY (specialty_id) 
        REFERENCES specialties(specialty_id),
    CONSTRAINT chk_doctor_name CHECK (LEN(doctor_name) > 0),
    CONSTRAINT chk_consultation_fee CHECK (consultation_fee >= 0),
    CONSTRAINT chk_contact_number CHECK (contact_number LIKE '[0-9]%')
);
GO
-- TABLE 3: PATIENTS
CREATE TABLE patients (
    patient_id INT IDENTITY(1,1) PRIMARY KEY,
    patient_name NVARCHAR(100) NOT NULL,
    date_of_birth DATE NOT NULL,
    gender CHAR(1) CHECK (gender IN ('M', 'F', 'O')),
    blood_group NVARCHAR(5),
    contact_number NVARCHAR(15) NOT NULL UNIQUE,
    email NVARCHAR(100) UNIQUE,
    address NVARCHAR(500),
    emergency_contact NVARCHAR(15),
    is_active BIT DEFAULT 1,
    created_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT chk_patient_name CHECK (LEN(patient_name) > 0),
    CONSTRAINT chk_dob CHECK (date_of_birth <= GETDATE()),
    CONSTRAINT chk_blood_group CHECK (blood_group IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'))
);
GO
-- Find the exact constraint name first
SELECT name
FROM sys.key_constraints
WHERE parent_object_id = OBJECT_ID('patients');
ALTER TABLE patients
DROP CONSTRAINT UQ__patients__AB6E6164D8958FD0;
-- TABLE 4: APPOINTMENTS
CREATE TABLE appointments (
    appointment_id INT IDENTITY(1,1) PRIMARY KEY,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    appointment_date DATE NOT NULL,
    appointment_time TIME NOT NULL,
    status NVARCHAR(20) DEFAULT 'SCHEDULED',
    reason NVARCHAR(500),
    created_date DATETIME DEFAULT GETDATE(),
    modified_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_appointment_patient FOREIGN KEY (patient_id) 
        REFERENCES patients(patient_id),
    CONSTRAINT fk_appointment_doctor FOREIGN KEY (doctor_id) 
        REFERENCES doctors(doctor_id),
    CONSTRAINT chk_appointment_status CHECK 
        (status IN ('SCHEDULED', 'COMPLETED', 'CANCELLED', 'NO_SHOW')),
    CONSTRAINT chk_appointment_date CHECK (appointment_date >= CAST(GETDATE() AS DATE))
);
GO
-- FIX: Allow Past Dates for Completed Appointments
USE HealthCareClinic;
GO
-- Drop the existing constraint
ALTER TABLE appointments
DROP CONSTRAINT chk_appointment_date;
GO
-- Add a new, more flexible constraint
-- This allows past dates for COMPLETED/CANCELLED appointments
-- But still requires future dates for SCHEDULED appointments
ALTER TABLE appointments
ADD CONSTRAINT chk_appointment_date CHECK (
    -- Allow any date for completed/cancelled appointments
    status IN ('COMPLETED', 'CANCELLED', 'NO_SHOW')
    OR 
    -- Require future/today date only for scheduled appointments
    (status = 'SCHEDULED' AND appointment_date >= CAST(GETDATE() AS DATE))
);
GO
USE HealthCareClinic;
GO
ALTER TABLE appointments
DROP CONSTRAINT chk_appointment_date;
GO
-- TABLE 5: VISITS
CREATE TABLE visits (
    visit_id INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id INT NOT NULL,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    visit_date DATETIME DEFAULT GETDATE(),
    diagnosis NVARCHAR(1000),
    symptoms NVARCHAR(1000),
    notes NVARCHAR(2000),
    follow_up_date DATE,
    CONSTRAINT fk_visit_appointment FOREIGN KEY (appointment_id) 
        REFERENCES appointments(appointment_id),
    CONSTRAINT fk_visit_patient FOREIGN KEY (patient_id) 
        REFERENCES patients(patient_id),
    CONSTRAINT fk_visit_doctor FOREIGN KEY (doctor_id) 
        REFERENCES doctors(doctor_id),
    CONSTRAINT uq_visit_appointment UNIQUE (appointment_id)
);
GO
-- TABLE 6: PRESCRIPTIONS
CREATE TABLE prescriptions (
    prescription_id INT IDENTITY(1,1) PRIMARY KEY,
    visit_id INT NOT NULL,
    medicine_name NVARCHAR(200) NOT NULL,
    dosage NVARCHAR(100) NOT NULL,
    frequency NVARCHAR(100),
    duration_days INT,
    instructions NVARCHAR(500),
    CONSTRAINT fk_prescription_visit FOREIGN KEY (visit_id) 
        REFERENCES visits(visit_id) ON DELETE CASCADE,
    CONSTRAINT chk_duration CHECK (duration_days > 0)
);
GO
-- TABLE 7: BILLS
CREATE TABLE bills (
    bill_id INT IDENTITY(1,1) PRIMARY KEY,
    visit_id INT NOT NULL,
    patient_id INT NOT NULL,
    consultation_fee DECIMAL(10,2) NOT NULL,
    additional_charges DECIMAL(10,2) DEFAULT 0,
    total_amount DECIMAL(10,2) NOT NULL,
    payment_status NVARCHAR(20) DEFAULT 'UNPAID',
    payment_date DATETIME,
    payment_mode NVARCHAR(50),
    bill_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_bill_visit FOREIGN KEY (visit_id) 
        REFERENCES visits(visit_id),
    CONSTRAINT fk_bill_patient FOREIGN KEY (patient_id) 
        REFERENCES patients(patient_id),
    CONSTRAINT chk_payment_status CHECK 
        (payment_status IN ('PAID', 'UNPAID', 'PARTIAL', 'REFUNDED')),
    CONSTRAINT chk_payment_mode CHECK 
        (payment_mode IN ('CASH', 'CARD', 'UPI', 'NET_BANKING', 'INSURANCE') OR payment_mode IS NULL),
    CONSTRAINT chk_total_amount CHECK (total_amount >= 0)
);
GO
-- TABLE 8: PAYMENT_TRANSACTIONS
CREATE TABLE payment_transactions (
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    bill_id INT NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    payment_mode NVARCHAR(50) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE(),
    transaction_reference NVARCHAR(100),
    CONSTRAINT fk_transaction_bill FOREIGN KEY (bill_id) 
        REFERENCES bills(bill_id),
    CONSTRAINT chk_transaction_amount CHECK (amount > 0)
);
GO
-- TABLE 9: APPOINTMENT_AUDIT
CREATE TABLE appointment_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id INT NOT NULL,
    action_type NVARCHAR(50) NOT NULL,
    old_status NVARCHAR(20),
    new_status NVARCHAR(20),
    old_date DATE,
    new_date DATE,
    old_time TIME,
    new_time TIME,
    modified_by NVARCHAR(100),
    modified_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT chk_action_type CHECK 
        (action_type IN ('CREATED', 'UPDATED', 'CANCELLED', 'RESCHEDULED', 'COMPLETED'))
);
GO
-- TABLE 10: AUDIT_LOG (System-wide audit)
CREATE TABLE audit_log (
    log_id INT IDENTITY(1,1) PRIMARY KEY,
    table_name NVARCHAR(100) NOT NULL,
    operation NVARCHAR(20) NOT NULL,
    record_id INT,
    user_name NVARCHAR(100),
    log_date DATETIME DEFAULT GETDATE(),
    old_values NVARCHAR(MAX),
    new_values NVARCHAR(MAX),
    CONSTRAINT chk_operation CHECK 
        (operation IN ('INSERT', 'UPDATE', 'DELETE'))
);
GO
-- CREATE INDEXES FOR PERFORMANCE
-- Patients table indexes
CREATE INDEX idx_patient_contact ON patients(contact_number);
CREATE INDEX idx_patient_name ON patients(patient_name);
CREATE INDEX idx_patient_email ON patients(email);
CREATE UNIQUE INDEX uq_patients_email_not_null
ON patients(email)
WHERE email IS NOT NULL;
GO
-- Doctors table indexes
CREATE INDEX idx_doctor_specialty ON doctors(specialty_id);
CREATE INDEX idx_doctor_contact ON doctors(contact_number);
CREATE INDEX idx_doctor_active ON doctors(is_active);
GO
-- Appointments table indexes
CREATE INDEX idx_appointment_date ON appointments(appointment_date);
CREATE INDEX idx_appointment_patient ON appointments(patient_id);
CREATE INDEX idx_appointment_doctor ON appointments(doctor_id);
CREATE INDEX idx_appointment_status ON appointments(status);
CREATE INDEX idx_appointment_datetime ON appointments(appointment_date, appointment_time);
GO
-- Visits table indexes
CREATE INDEX idx_visit_patient ON visits(patient_id);
CREATE INDEX idx_visit_doctor ON visits(doctor_id);
CREATE INDEX idx_visit_date ON visits(visit_date);
GO
-- Bills table indexes
CREATE INDEX idx_bill_patient ON bills(patient_id);
CREATE INDEX idx_bill_status ON bills(payment_status);
CREATE INDEX idx_bill_date ON bills(bill_date);
GO
-- TRIGGERS
-- Trigger to audit appointment changes
GO
CREATE TRIGGER trg_appointment_audit
ON appointments
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        -- UPDATE operation
        INSERT INTO appointment_audit (appointment_id, action_type, old_status, new_status, 
                                       old_date, new_date, old_time, new_time, modified_by)
        SELECT 
            i.appointment_id,
            CASE 
                WHEN i.status = 'CANCELLED' THEN 'CANCELLED'
                WHEN i.appointment_date != d.appointment_date OR i.appointment_time != d.appointment_time THEN 'RESCHEDULED'
                WHEN i.status = 'COMPLETED' THEN 'COMPLETED'
                ELSE 'UPDATED'
            END,
            d.status,
            i.status,
            d.appointment_date,
            i.appointment_date,
            d.appointment_time,
            i.appointment_time,
            SYSTEM_USER
        FROM inserted i
        INNER JOIN deleted d ON i.appointment_id = d.appointment_id;
    END
    ELSE IF EXISTS (SELECT * FROM inserted)
    BEGIN
        -- INSERT operation
        INSERT INTO appointment_audit (appointment_id, action_type, new_status, 
                                       new_date, new_time, modified_by)
        SELECT 
            appointment_id,
            'CREATED',
            status,
            appointment_date,
            appointment_time,
            SYSTEM_USER
        FROM inserted;
    END
END;
GO

-- Trigger to calculate bill total
GO
CREATE TRIGGER trg_bill_calculate_total
ON bills
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE b
    SET total_amount = b.consultation_fee + b.additional_charges
    FROM bills b
    INNER JOIN inserted i ON b.bill_id = i.bill_id
    WHERE b.total_amount != (b.consultation_fee + b.additional_charges);
END;
GO

-- Trigger for general audit logging
GO
CREATE TRIGGER trg_audit_patients
ON patients
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO audit_log (table_name, operation, record_id, user_name, old_values, new_values)
        SELECT 
            'patients',
            'UPDATE',
            i.patient_id,
            SYSTEM_USER,
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        INNER JOIN deleted d ON i.patient_id = d.patient_id;
    END
    ELSE IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO audit_log (table_name, operation, record_id, user_name, new_values)
        SELECT 
            'patients',
            'INSERT',
            patient_id,
            SYSTEM_USER,
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
    END
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO audit_log (table_name, operation, record_id, user_name, old_values)
        SELECT 
            'patients',
            'DELETE',
            patient_id,
            SYSTEM_USER,
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM deleted d;
    END
END;
GO
PRINT 'Healthcare Clinic Database Schema Created Successfully!';
GO

