use HealthClinicDB;

sp_help Appointment;

CREATE TABLE AppointmentAudit(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
AppointmentID INT,
AppointmentDate Date,
AppointmentTime Time,
Status VARCHAR(20),
PatientID INT,
DoctorID INT,

ActionPerformed VARCHAR(20),
ActionDate DATETIME DEFAULT GETDATE(),
ActionBy VARCHAR(100) DEFAULT SYSTEM_USER
);

CREATE TRIGGER Appointment_Insert
ON Appointment
AFTER INSERT AS BEGIN
Insert INTO AppointmentAudit(
AppointmentID, AppointmentDate,AppointmentTime,Status,PatientID, DoctorID,ActionPerformed)
select AppointmentID, AppointmentDate,AppointmentTime,Status,PatientID, DoctorID, 'INSERT' FROM inserted;
END;
GO

DROP TRIGGER IF EXISTS appointment_Update;
GO

CREATE TRIGGER appointment_Update
ON Appointment
AFTER UPDATE
AS
BEGIN
    INSERT INTO AppointmentAudit
    (
        AppointmentID,
        AppointmentDate,
        AppointmentTime,
        Status,
        PatientID,
        DoctorID,
        ActionPerformed
    )
    SELECT
        AppointmentID,
        AppointmentDate,
        AppointmentTime,
        Status,
        PatientID,
        DoctorID,
        'UPDATE'
    FROM inserted;
END;
GO


CREATE TRIGGER appointment_Delete
ON Appointment
AFTER DELETE
AS
BEGIN
    INSERT INTO AppointmentAudit
    (
        AppointmentID,
        AppointmentDate,
        AppointmentTime,
        Status,
        PatientID,
        DoctorID,
        ActionPerformed
    )
    SELECT
        AppointmentID,
        AppointmentDate,
        AppointmentTime,
        Status,
        PatientID,
        DoctorID,
        'DELETE'
    FROM deleted;
END;
GO

INSERT INTO Appointment
(
    AppointmentDate,
    AppointmentTime,
    Status,
    PatientID,
    DoctorID
)
VALUES
('2026-08-05', '09:00', 'Scheduled', 1, 1),
('2026-08-05', '09:30', 'Scheduled', 2, 2),
('2026-08-05', '10:00', 'Completed', 3, 3),
('2026-08-05', '10:30', 'Scheduled', 4, 4),
('2026-08-05', '11:00', 'Cancelled', 5, 5),
('2026-08-06', '09:00', 'Scheduled', 6, 6),
('2026-08-06', '09:30', 'Completed', 7, 7),
('2026-08-06', '10:00', 'Scheduled', 8, 8),
('2026-08-06', '10:30', 'Scheduled', 9, 9),
('2026-08-06', '11:00', 'Completed', 10, 10);

SELECT DoctorID, Name
FROM Doctor
ORDER BY DoctorID;

SELECT PatientID, Name
FROM Patient
ORDER BY PatientID;




SET IDENTITY_INSERT Doctor ON;

INSERT INTO Doctor
(
    DoctorID,
    Name,
    Phone,
    Email,
    SpecializationID
)
VALUES
(
    3,
    'Dr. Amit Verma',
    '9876543212',
    'amit@gmail.com',
    3
);

SET IDENTITY_INSERT Doctor OFF;


SET IDENTITY_INSERT Doctor ON;

INSERT INTO Doctor
(
    DoctorID,
    Name,
    Phone,
    Email,
    SpecializationID
)
VALUES
(
    10,
    'Dr. Anjali Desai',
    '9876543219',
    'anjali@gmail.com',
    5
);

SET IDENTITY_INSERT Doctor OFF;

DELETE FROM Patient
WHERE PatientID = 11;


SET IDENTITY_INSERT Patient ON;

INSERT INTO Patient
(
    PatientID,
    Name,
    DateOfBirth,
    Gender,
    Phone,
    Address
)
VALUES
(
    10,
    'Riya Sharma',
    '2001-07-15',
    'Female',
    '9876543221',
    'Delhi'
);

SET IDENTITY_INSERT Patient OFF;


INSERT INTO Appointment
(
    AppointmentDate,
    AppointmentTime,
    Status,
    PatientID,
    DoctorID
)
VALUES
('2026-08-05','09:00','Scheduled',1,1),
('2026-08-05','09:30','Scheduled',2,2),
('2026-08-05','10:00','Completed',3,3),
('2026-08-05','10:30','Scheduled',4,4),
('2026-08-05','11:00','Cancelled',5,5),
('2026-08-06','09:00','Scheduled',6,6),
('2026-08-06','09:30','Completed',7,7),
('2026-08-06','10:00','Scheduled',8,8),
('2026-08-06','10:30','Scheduled',9,9),
('2026-08-06','11:00','Completed',10,10);

SELECT *
FROM Appointment;

SELECT *
FROM AppointmentAudit
ORDER BY AuditID;