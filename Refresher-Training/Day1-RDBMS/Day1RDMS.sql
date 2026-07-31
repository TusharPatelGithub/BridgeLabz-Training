CREATE DATABASE HealthClinicDB;
GO

USE HealthClinicDB;
GO

CREATE TABLE Patient (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Phone NVARCHAR(15),
    Address NVARCHAR(255)
);
GO

CREATE TABLE Doctor (
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100)
);
GO

CREATE TABLE Appointment (
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Scheduled',
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    CONSTRAINT FK_Appointment_Patient FOREIGN KEY (PatientID) 
        REFERENCES Patient(PatientID) ON DELETE CASCADE,
    CONSTRAINT FK_Appointment_Doctor FOREIGN KEY (DoctorID) 
        REFERENCES Doctor(DoctorID) ON DELETE CASCADE
);
GO