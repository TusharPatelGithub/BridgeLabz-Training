-- SAMPLE DATA FOR HEALTHCARE CLINIC DATABASE
USE HealthCareClinic;
GO
-- INSERT SPECIALTIES
INSERT INTO specialties (specialty_name, description) VALUES
('Cardiology', 'Heart and cardiovascular system'),
('Dermatology', 'Skin, hair, and nails'),
('Orthopedics', 'Bones, joints, and muscles'),
('Pediatrics', 'Children and adolescents'),
('General Medicine', 'General health and wellness'),
('Neurology', 'Brain and nervous system'),
('ENT', 'Ear, Nose, and Throat'),
('Ophthalmology', 'Eyes and vision');
GO
-- INSERT DOCTORS
INSERT INTO doctors (doctor_name, specialty_id, contact_number, email, consultation_fee) VALUES
('Dr. Rajesh Kumar', 1, '9876543210', 'rajesh.kumar@clinic.com', 800.00),
('Dr. Priya Sharma', 2, '9876543211', 'priya.sharma@clinic.com', 600.00),
('Dr. Amit Patel', 3, '9876543212', 'amit.patel@clinic.com', 900.00),
('Dr. Sunita Reddy', 4, '9876543213', 'sunita.reddy@clinic.com', 700.00),
('Dr. Vikram Singh', 5, '9876543214', 'vikram.singh@clinic.com', 500.00),
('Dr. Anjali Mehta', 6, '9876543215', 'anjali.mehta@clinic.com', 1000.00),
('Dr. Rahul Verma', 7, '9876543216', 'rahul.verma@clinic.com', 650.00),
('Dr. Kavita Joshi', 8, '9876543217', 'kavita.joshi@clinic.com', 750.00);
GO
-- INSERT PATIENTS
INSERT INTO patients (patient_name, date_of_birth, gender, blood_group, contact_number, email, address, emergency_contact) VALUES
('Ramesh Gupta', '1985-03-15', 'M', 'O+', '9123456780', 'ramesh.g@email.com', '123 MG Road, Delhi', '9123456781'),
('Sneha Kapoor', '1990-07-22', 'F', 'A+', '9123456782', 'sneha.k@email.com', '456 Park Street, Mumbai', '9123456783'),
('Anil Desai', '1978-11-10', 'M', 'B+', '9123456784', 'anil.d@email.com', '789 Brigade Road, Bangalore', '9123456785'),
('Pooja Singh', '1995-02-28', 'F', 'AB+', '9123456786', 'pooja.s@email.com', '321 Residency Road, Pune', '9123456787'),
('Suresh Rao', '1982-09-05', 'M', 'O-', '9123456788', 'suresh.r@email.com', '654 Anna Salai, Chennai', '9123456789'),
('Meera Nair', '1988-12-18', 'F', 'A-', '9123456790', 'meera.n@email.com', '987 MG Road, Kochi', '9123456791'),
('Vivek Jain', '1992-06-30', 'M', 'B-', '9123456792', 'vivek.j@email.com', '147 Civil Lines, Jaipur', '9123456793'),
('Kavya Iyer', '1986-04-12', 'F', 'AB-', '9123456794', 'kavya.i@email.com', '258 Jubilee Hills, Hyderabad', '9123456795'),
('Arjun Malhotra', '1975-08-25', 'M', 'O+', '9123456796', 'arjun.m@email.com', '369 Sector 17, Chandigarh', '9123456797'),
('Divya Saxena', '1993-01-07', 'F', 'A+', '9123456798', 'divya.s@email.com', '741 Connaught Place, Delhi', '9123456799');
GO
-- INSERT APPOINTMENTS
-- Past appointments (for completed visits)
INSERT INTO appointments (patient_id, doctor_id, appointment_date, appointment_time, status, reason) VALUES
(1, 1, '2025-02-01', '10:00:00', 'COMPLETED', 'Chest pain and breathing difficulty'),
(2, 2, '2025-02-01', '11:00:00', 'COMPLETED', 'Skin rash and itching'),
(3, 3, '2025-02-02', '09:30:00', 'COMPLETED', 'Knee pain'),
(4, 4, '2025-02-02', '14:00:00', 'COMPLETED', 'Child vaccination'),
(5, 5, '2025-02-03', '10:30:00', 'COMPLETED', 'Regular checkup'),
(6, 6, '2025-02-03', '15:00:00', 'COMPLETED', 'Headache and dizziness'),
(7, 7, '2025-02-04', '11:30:00', 'CANCELLED', 'Ear infection'),
(8, 8, '2025-02-04', '16:00:00', 'COMPLETED', 'Eye checkup');
-- Future appointments
INSERT INTO appointments (patient_id, doctor_id, appointment_date, appointment_time, status, reason) VALUES
(1, 5, '2025-02-07', '10:00:00', 'SCHEDULED', 'Follow-up consultation'),
(9, 1, '2025-02-07', '11:00:00', 'SCHEDULED', 'Heart palpitations'),
(10, 2, '2025-02-08', '09:00:00', 'SCHEDULED', 'Acne treatment'),
(2, 3, '2025-02-08', '14:30:00', 'SCHEDULED', 'Back pain'),
(3, 4, '2025-02-09', '10:00:00', 'SCHEDULED', 'Child fever'),
(4, 6, '2025-02-09', '15:30:00', 'SCHEDULED', 'Migraine'),
(5, 7, '2025-02-10', '11:00:00', 'SCHEDULED', 'Throat pain'),
(6, 8, '2025-02-10', '16:30:00', 'SCHEDULED', 'Vision problems');
GO
-- =============================================
-- INSERT VISITS (for completed appointments)
-- =============================================
SELECT appointment_id, patient_id, doctor_id, status, appointment_date
FROM appointments
ORDER BY appointment_id;
INSERT INTO visits
(appointment_id, patient_id, doctor_id, visit_date, diagnosis, symptoms, notes, follow_up_date)
SELECT
    a.appointment_id,
    a.patient_id,
    a.doctor_id,
    DATEADD(MINUTE, 30,
        CAST(a.appointment_date AS DATETIME) + CAST(a.appointment_time AS DATETIME)
    ),
    'General Diagnosis',
    'Reported symptoms',
    'Visit completed successfully',
    DATEADD(MONTH, 1, a.appointment_date)
FROM appointments a
WHERE a.status = 'COMPLETED';
-- =============================================
-- INSERT PRESCRIPTIONS
-- =============================================
SELECT visit_id, appointment_id, patient_id, doctor_id, diagnosis
FROM visits
ORDER BY visit_id;
INSERT INTO prescriptions
(visit_id, medicine_name, dosage, frequency, duration_days, instructions)
SELECT v.visit_id, 'Aspirin', '75mg', 'Once daily', 30, 'Take after breakfast'
FROM visits v
WHERE v.diagnosis = 'Angina Pectoris';
INSERT INTO prescriptions
SELECT v.visit_id, 'Atorvastatin', '10mg', 'Once daily at night', 30, 'Take after dinner'
FROM visits v
WHERE v.diagnosis = 'Angina Pectoris';
INSERT INTO prescriptions
SELECT v.visit_id, 'Nitroglycerin', '0.5mg', 'As needed', 30, 'Sublingual for chest pain'
FROM visits v
WHERE v.diagnosis = 'Angina Pectoris';
INSERT INTO prescriptions
SELECT v.visit_id, 'Hydrocortisone Cream', '1%', 'Apply twice daily', 7, 'Apply on affected area'
FROM visits v
WHERE v.diagnosis = 'Contact Dermatitis';

INSERT INTO prescriptions
SELECT v.visit_id, 'Cetirizine', '10mg', 'Once daily', 5, 'Take at bedtime'
FROM visits v
WHERE v.diagnosis = 'Contact Dermatitis';
INSERT INTO prescriptions
SELECT v.visit_id, 'Diclofenac', '50mg', 'Twice daily', 15, 'Take after meals'
FROM visits v
WHERE v.diagnosis = 'Osteoarthritis';

INSERT INTO prescriptions
SELECT v.visit_id, 'Calcium Supplement', '500mg', 'Once daily', 30, 'Take with food'
FROM visits v
WHERE v.diagnosis = 'Osteoarthritis';
INSERT INTO prescriptions
SELECT v.visit_id, 'MMR Vaccine', '0.5ml', 'Single dose', 1, 'Subcutaneous injection given'
FROM visits v
WHERE v.diagnosis = 'Routine Vaccination';
INSERT INTO prescriptions
SELECT v.visit_id, 'Paracetamol', '500mg', 'As needed (max 3 times daily)', 5, 'Take with water'
FROM visits v
WHERE v.diagnosis = 'Tension Headache';

INSERT INTO prescriptions
SELECT v.visit_id, 'Vitamin B Complex', '1 tablet', 'Once daily', 30, 'Take after breakfast'
FROM visits v
WHERE v.diagnosis = 'Tension Headache';

-- =============================================
-- INSERT BILLS
-- =============================================
INSERT INTO bills
(
    visit_id,
    patient_id,
    consultation_fee,
    additional_charges,
    total_amount,
    payment_status,
    payment_date,
    payment_mode
)
SELECT
    v.visit_id,
    v.patient_id,
    d.consultation_fee,
    CASE 
        WHEN v.diagnosis = 'Angina Pectoris' THEN 200
        WHEN v.diagnosis = 'Osteoarthritis' THEN 500
        WHEN v.diagnosis = 'Routine Vaccination' THEN 300
        WHEN v.diagnosis = 'Tension Headache' THEN 150
        ELSE 0
    END AS additional_charges,
    0 AS total_amount,   -- ? REQUIRED
    CASE 
        WHEN v.diagnosis = 'Tension Headache' THEN 'UNPAID'
        ELSE 'PAID'
    END AS payment_status,
    CASE 
        WHEN v.diagnosis = 'Tension Headache' THEN NULL
        ELSE v.visit_date
    END AS payment_date,
    CASE 
        WHEN v.diagnosis = 'Routine Vaccination' THEN 'INSURANCE'
        ELSE 'CARD'
    END AS payment_mode
FROM visits v
JOIN doctors d ON v.doctor_id = d.doctor_id;
-- =============================================
-- INSERT PAYMENT TRANSACTIONS
-- =============================================
INSERT INTO payment_transactions
(bill_id, amount, payment_mode, transaction_date, transaction_reference)
SELECT
    b.bill_id,
    CASE 
        WHEN b.payment_status = 'PARTIAL' THEN b.total_amount * 0.6
        ELSE b.total_amount
    END AS amount,
    b.payment_mode,
    b.payment_date,
    CONCAT('TXN-', b.bill_id, '-', FORMAT(GETDATE(), 'yyyyMMdd'))
FROM bills b
WHERE b.payment_status IN ('PAID', 'PARTIAL');
PRINT 'Sample data inserted successfully!';
PRINT '';
PRINT 'Database Statistics:';
SELECT 'Specialties' AS TableName, COUNT(*) AS RecordCount FROM specialties
UNION ALL
SELECT 'Doctors', COUNT(*) FROM doctors
UNION ALL
SELECT 'Patients', COUNT(*) FROM patients
UNION ALL
SELECT 'Appointments', COUNT(*) FROM appointments
UNION ALL
SELECT 'Visits', COUNT(*) FROM visits
UNION ALL
SELECT 'Prescriptions', COUNT(*) FROM prescriptions
UNION ALL
SELECT 'Bills', COUNT(*) FROM bills
UNION ALL
SELECT 'Payment Transactions', COUNT(*) FROM payment_transactions;
GO

