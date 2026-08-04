use HealthClinicDB;

Create Table DoctorAudit(
AuditID INT Identity(1,1) PRIMARY KEY,
DoctorID INT,
Name VARCHAR(100),
 Phone VARCHAR(15),
 Email VARCHAR(100),
 SpecializationID INT,

  ActionPerformed VARCHAR(20),
  ActionDate DATETIME DEFAULT GETDATE(),
  ActionBy VARCHAR(100) DEFAULT SYSTEM_USER
);

CREATE TRIGGER doc_Insert
ON Doctor
AFTER INSERT
AS
BEGIN
    INSERT INTO DoctorAudit
    (
        DoctorID,
        Name,
        Phone,
        Email,
        SpecializationID,
        ActionPerformed
    )
    SELECT
        DoctorID,
        Name,
        Phone,
        Email,
        SpecializationID,
        'INSERT'
    FROM inserted;
END;

INSERT INTO Doctor
(
    Name,
    Phone,
    Email,
    SpecializationID
)
VALUES
(
    'Dr. Rahul Sharma',
    '9876543210',
    'rahul.sharma@gmail.com',
    1
);

SELECT * FROM Specialization;

INSERT INTO Specialization (SpecializationName)
VALUES
('Cardiology'),
('Neurology'),
('Orthopedics'),
('Dermatology'),
('Pediatrics');

INSERT INTO Doctor
(
    Name,
    Phone,
    Email,
    SpecializationID
)
VALUES
(
    'Dr. Rahul Sharma',
    '9876543210',
    'rahul.sharma@gmail.com',
    1
);

select * from Doctor;

select * from DoctorAudit;

sp_help specialization

CREATE TRIGGER doc_Update
ON Doctor
AFTER UPDATE
AS
BEGIN
    INSERT INTO DoctorAudit
    (
        DoctorID,
        Name,
        Phone,
        Email,
        SpecializationID,
        ActionPerformed
    )
    SELECT
        DoctorID,
        Name,
        Phone,
        Email,
        SpecializationID,
        'UPDATE'
    FROM inserted;
END;
GO

update Doctor set phone='999999999' where DoctorID=1;

select * from DoctorAudit;

select * from Doctor

update Doctor set phone='9999999999' where DoctorID=2;

select * from DoctorAudit

DBCC CHECKIDENT ('Doctor', RESEED, 0);

DELETE FROM Doctor;

select * from Doctor

DBCC CHECKIDENT ('Doctor', RESEED, 0);

INSERT INTO Doctor
(
    Name,
    Phone,
    Email,
    SpecializationID
)
VALUES
('Dr. Rahul Sharma',    '9876543210', 'rahul@gmail.com',      1),
('Dr. Priya Singh',     '9876543211', 'priya@gmail.com',      2),
('Dr. Amit Verma',      '9876543212', 'amit@gmail.com',       3),
('Dr. Neha Gupta',      '9876543213', 'neha@gmail.com',       4),
('Dr. Arjun Patel',     '9876543214', 'arjun@gmail.com',      5),
('Dr. Sneha Kapoor',    '9876543215', 'sneha@gmail.com',      1),
('Dr. Vikram Mehta',    '9876543216', 'vikram@gmail.com',     2),
('Dr. Pooja Sharma',    '9876543217', 'pooja@gmail.com',      3),
('Dr. Karan Malhotra',  '9876543218', 'karan@gmail.com',      4),
('Dr. Anjali Desai',    '9876543219', 'anjali@gmail.com',     5);

select * from DoctorAudit order by AuditID

drop trigger if exists doc_delete

CREATE TRIGGER doc_delete
ON Doctor
After delete 
as begin
INSERT INTO DoctorAudit
    (
        DoctorID,
        Name,
        Phone,
        Email,
        SpecializationID,
        ActionPerformed
    )
    SELECT
        DoctorID,
        Name,
        Phone,
        Email,
        SpecializationID,
        'DELETE'
    FROM deleted;
END;
GO


delete from Doctor where DoctorID = 3

select * from DoctorAudit
