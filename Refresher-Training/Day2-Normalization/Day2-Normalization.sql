DROP TABLE IF EXISTS Patient;
CREATE TABLE Patient
(
    PatientID INT IDENTITY(1,1) PRIMARY KEY,

    Name VARCHAR(100) NOT NULL,

    DateOfBirth DATE NOT NULL,

    Gender VARCHAR(10),

    Phone VARCHAR(15),

    Address VARCHAR(255)
);

CREATE TABLE Specialization
(
    SpecializationID INT IDENTITY(1,1) PRIMARY KEY,

    SpecializationName VARCHAR(100) NOT NULL UNIQUE
);