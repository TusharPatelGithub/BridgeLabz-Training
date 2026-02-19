CREATE DATABASE AddressBookSystem;
GO
USE AddressBookSystem;
GO
CREATE TABLE AddressBooks (
    AddressBookId INT IDENTITY(1,1) PRIMARY KEY,
    AddressBookName VARCHAR(100) NOT NULL UNIQUE);
CREATE TABLE Contacts (
    ContactId INT IDENTITY(1,1) PRIMARY KEY,
    AddressBookId INT NOT NULL,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Address VARCHAR(200),
    City VARCHAR(50),
    State VARCHAR(50),
    Zip VARCHAR(10),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    FOREIGN KEY (AddressBookId) REFERENCES AddressBooks(AddressBookId)
);
