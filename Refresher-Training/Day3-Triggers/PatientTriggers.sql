use HealthClinicDB

sp_help patient

CREATE TABLE PatientAudit
(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
PatientID INT,
Name VARCHAR(100),
DateOfBirth DATE,
Gender varchar(10),
Phone VARCHAR(15),
Address VARCHAR(255),

ActionPerformed VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE(),
    ActionBy VARCHAR(100) DEFAULT SYSTEM_USER
);

CREATE TRIGGER Patient_Insert
ON Patient
AFTER INSERT AS BEGIN
INSERT INTO PatientAudit(
PatientID,Name,DateOfBirth,Gender,Phone, Address, ActionPerformed )
SELECT PatientID,Name,DateOfBirth,Gender,Phone, Address,'INSERT' From inserted;
END;
GO

CREATE TRIGGER Patient_Update
ON Patient 
AFTER UPDATE AS BEGIN
INSERT INTO PatientAudit(
PatientID,Name,DateOfBirth,Gender,Phone,Address,ActionPerformed)
select PatientID,Name,DateOfBirth,Gender,Phone,Address,'UPDATE' From inserted;
End;
Go

CREATE TRIGGER Patient_Delete
on Patient
AFTER DELETE AS BEGIN
INSERT INTO PatientAudit(
PatientID,Name, DateOfBirth,Gender,Phone,Address, ActionPerformed)
select PatientID, Name,DateOfBirth, Gender,Phone, Address, 'DELETE' FROM deleted;
end;
go


INSERT INTO Patient(
Name,DateOfBirth,Gender,Phone,Address)
VALUES 
('Aman Sharma',   '1998-05-10', 'Male',   '9876543201', 'Delhi'),
('Priya Gupta',   '2000-08-15', 'Female', '9876543202', 'Lucknow'),
('Rohit Verma',   '1995-11-20', 'Male',   '9876543203', 'Kanpur'),
('Neha Singh',    '1999-02-28', 'Female', '9876543204', 'Noida'),
('Arjun Patel',   '1997-09-14', 'Male',   '9876543205', 'Ahmedabad'),
('Sneha Kapoor',  '2001-03-18', 'Female', '9876543206', 'Jaipur'),
('Vikas Kumar',   '1996-12-01', 'Male',   '9876543207', 'Patna'),
('Pooja Mishra',  '1998-06-25', 'Female', '9876543208', 'Varanasi'),
('Karan Mehta',   '1994-10-05', 'Male',   '9876543209', 'Mumbai'),
('Anjali Desai',  '2002-01-12', 'Female', '9876543210', 'Surat');

UPDATE Patient set Phone='9999999999' where PatientID=5;
DELETE From Patient where PatientID=10;

select * from PatientAudit;