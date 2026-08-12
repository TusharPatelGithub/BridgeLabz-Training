# BridgeLabz-Training

# Day 1 - Database Normalization

**Date:** 31/07/2026

## Objective

The objective of today's session was to gain an introduction to **Database Normalization** and understand its importance in designing efficient relational databases. We learned how normalization helps eliminate data redundancy, improve data consistency, and organize data into well-structured tables.

## What We Learned

- Introduction to Database Normalization
- Importance of Normalization in Database Design
- Data Redundancy and Data Anomalies
- Functional Dependency
- First Normal Form (1NF)
- Second Normal Form (2NF)
- Third Normal Form (3NF)
- Primary Keys and Foreign Keys
- Organizing data into multiple related tables
- Improving database consistency and maintainability

## Practical Implementation

- Studied an unnormalized database schema
- Identified redundant and repeating data
- Converted the schema into First Normal Form (1NF)
- Further refined it into Second Normal Form (2NF)
- Understood the requirements of Third Normal Form (3NF)
- Designed relationships using Primary Keys and Foreign Keys

## Key Concepts Covered

- Database Normalization
- 1NF (First Normal Form)
- 2NF (Second Normal Form)
- 3NF (Third Normal Form)
- Functional Dependency
- Data Redundancy
- Data Integrity
- Primary Key
- Foreign Key
- Database Relationships

## Outcome

Successfully understood the fundamentals of database normalization and learned how to organize relational database tables by reducing redundancy, improving data integrity, and preparing a scalable database design following normalization principles.

# Day 2 - Database Normalization

**Date:** 03/08/2026

## Objective

The objective of today's session was to understand the concept of **Database Normalization** and learn how to organize database tables efficiently by eliminating data redundancy and maintaining data integrity. We normalized the Health Clinic database schema up to **Third Normal Form (3NF)**.

## What We Learned

- Introduction to Database Normalization
- Understanding the purpose and benefits of normalization
- Identifying data redundancy and update anomalies
- First Normal Form (1NF)
- Second Normal Form (2NF)
- Third Normal Form (3NF)
- Functional Dependency
- Primary Keys and Foreign Keys
- Splitting large tables into smaller related tables
- Establishing relationships between normalized tables

## Practical Implementation

- Analyzed the existing Health Clinic database schema
- Normalized the following entities:
  - Patient
  - Doctor
  - Appointment
- Created separate tables to remove redundant data
- Established relationships using Primary Keys and Foreign Keys
- Verified that the final database design satisfied the requirements of **Third Normal Form (3NF)**

## Key Concepts Covered

- Database Normalization
- 1NF (First Normal Form)
- 2NF (Second Normal Form)
- 3NF (Third Normal Form)
- Functional Dependency
- Data Redundancy
- Data Integrity
- Primary Key
- Foreign Key
- Database Relationships

## Outcome

Successfully learned the principles of database normalization and transformed the Health Clinic database into a well-structured **3NF schema**, resulting in reduced redundancy, improved data consistency, and better database maintainability.

# Day 3 - SQL Triggers

**Date:** 05/08/2026

## Objective

The objective of today's session was to understand the concept of **SQL Triggers**, their purpose, and how they can be used to automatically execute predefined actions in response to database events. We also learned how triggers help maintain data integrity, implement auditing, and enforce business rules.

## What We Learned

- Introduction to SQL Triggers
- Understanding when and why triggers are used
- Types of Triggers
  - AFTER Trigger
  - INSTEAD OF Trigger
- Trigger events:
  - INSERT
  - UPDATE
  - DELETE
- Creating and executing triggers
- Using the `inserted` and `deleted` virtual tables
- Implementing audit logging using triggers
- Automatically tracking changes made to database records
- Testing triggers with different SQL operations

## Practical Implementation

- Created triggers for database tables
- Logged INSERT, UPDATE, and DELETE operations
- Recorded audit information such as:
  - Action Performed
  - Action Date
  - Action By (System User)
- Verified that triggers execute automatically whenever the associated database event occurs

## Key Concepts Covered

- SQL Triggers
- AFTER Trigger
- INSTEAD OF Trigger
- INSERT Trigger
- UPDATE Trigger
- DELETE Trigger
- inserted Table
- deleted Table
- Audit Logging
- Data Integrity
- Business Rules

## Outcome

Successfully learned how SQL Triggers work and implemented triggers to automatically monitor and record database changes, improving data integrity, security, and auditing capabilities without requiring additional application code.

# Day 4 - ADO.NET (HealthClinicApp)

**Date:** 06/08/2026

## Objective

The objective of today's session was to understand the fundamentals of **ADO.NET** and learn how to establish a connection between a C# application and SQL Server. We built a console-based application named **HealthClinicApp** to perform database operations using ADO.NET.

## What We Learned

- Introduction to ADO.NET
- Understanding the ADO.NET architecture
- Connecting a C# application to SQL Server
- Using `SqlConnection` to establish database connectivity
- Executing SQL commands using `SqlCommand`
- Performing CRUD (Create, Read, Update, Delete) operations
- Using `SqlDataReader` to retrieve data
- Understanding `ExecuteNonQuery()`, `ExecuteReader()`, and `ExecuteScalar()`
- Implementing a menu-driven console application
- Managing database connections using `using` statements
- Basic exception handling with `try-catch`

## Project Created

Project Name:

```
HealthClinicApp
```

## Modules Implemented

- Patient Management
- Doctor Management
- Appointment Management

Each module supports CRUD operations and interacts with the SQL Server database using ADO.NET.

## Key Concepts Covered

- ADO.NET
- SQL Server Connectivity
- SqlConnection
- SqlCommand
- SqlDataReader
- ExecuteNonQuery()
- ExecuteReader()
- ExecuteScalar()
- CRUD Operations
- Exception Handling

## Outcome

Successfully developed a menu-driven **HealthClinicApp** using ADO.NET that connects to SQL Server and performs CRUD operations for Patients, Doctors, and Appointments, providing practical experience in database connectivity and data manipulation using C#.

# Day 5 - Basic ASP.NET Core Web API (WeatherApp)

**Date:** 07/08/2026

## Objective

The objective of today's session was to understand the fundamentals of **ASP.NET Core Web API** and learn how to create a basic Web API project using the .NET CLI.

## What We Learned

- Introduction to ASP.NET Core Web API
- Understanding what a Web API is and how it works
- Scaffolding a basic Web API project using the .NET CLI
- Exploring the project folder structure
- Understanding the purpose of important files:
  - Program.cs
  - appsettings.json
  - appsettings.Development.json
  - Controllers Folder
  - Properties Folder
  - .csproj file
- Introduction to Swagger UI for API testing
- Understanding Minimal APIs and API endpoints
- Running the application using the `dotnet run` command
- Testing API endpoints through Swagger and the browser

## Project Created

Project Name:

```
WeatherApp
```

Created using:

```bash
dotnet new webapi -n WeatherApp
```

## Project Structure

```
WeatherApp
│
├── Controllers
├── Properties
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── WeatherApp.csproj
└── WeatherApp.http
```

## Key Concepts Covered

- ASP.NET Core
- Web API
- Scaffolding
- Minimal API
- Controllers
- HTTP Requests
- JSON Response
- Swagger/OpenAPI
- Project Structure

## Outcome

Successfully created and explored a basic ASP.NET Core Web API project, understood its structure, learned how API endpoints are exposed, and tested the application using Swagger.


# Day 6 - ASP.NET Core MVC / Web API (My Greetings App)

## Date: 10/08/2026

Objective

The objective of today's session was to understand the fundamentals of the Model-View-Controller (MVC) pattern, REST APIs, HTTP protocol, controllers, routing, and request/response handling in ASP.NET Core. The session also focused on building a basic My Greetings App using ASP.NET Core MVC/Web API.

What We Learned
Introduction to the Model-View-Controller (MVC) pattern
Understanding the role of:
Model
View
Controller
Understanding the basic flow of an MVC application
Introduction to REST APIs
Understanding C# REST API calls
Understanding HTTP request and response handling
Introduction to the HTTP protocol
Understanding common HTTP methods:
GET
POST
PUT
DELETE
Understanding HTTP status codes
Understanding Controllers in ASP.NET Core
Understanding Routing and API endpoints
Understanding attribute routing
Handling API requests and responses
Returning JSON responses from APIs
Building a basic My Greetings App
Project Created

Project Name:

MyGreetingsApp

Created using:

dotnet new webapi -n MyGreetingsApp
Project Structure
MyGreetingsApp
│
├── Controllers
├── Properties
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── MyGreetingsApp.csproj
└── MyGreetingsApp.http
Key Concepts Covered
ASP.NET Core MVC
Web API
MVC Pattern
Model
View
Controller
REST API
HTTP Protocol
HTTP Methods
HTTP Requests
HTTP Responses
Routing
Attribute Routing
JSON Response
HTTP Status Codes
Practical Task

Created a basic My Greetings App using ASP.NET Core Web API with API endpoints for handling greeting requests.

Example endpoint:

GET /api/greetings

Example response:

{
    "message": "Hello, World!"
}

The application demonstrates how a client sends an HTTP request to a controller and receives an appropriate response.

Outcome

Successfully understood the fundamentals of the MVC pattern, REST APIs, HTTP protocol, controllers, routing, and request/response handling. Also created a basic My Greetings App using ASP.NET Core Web API and learned how to expose and handle API endpoints.


# Day 7 - Minimal APIs in ASP.NET Core (Contacts App)

## Date: 11/08/2026

Objective

The objective of today's session was to understand Minimal APIs in ASP.NET Core and learn how to create lightweight HTTP endpoints with minimal configuration and code. The session also focused on starting the backend development of a Contacts App using Minimal APIs.

What We Learned
Introduction to Minimal APIs in ASP.NET Core
Understanding the purpose and advantages of Minimal APIs
Difference between Minimal APIs and Controller-based APIs
Understanding lightweight endpoint definitions
Creating HTTP endpoints using Minimal APIs
Understanding HTTP methods:
GET
POST
PUT
DELETE
Understanding route mapping in Minimal APIs
Handling HTTP requests and responses
Returning JSON responses
Working with endpoint parameters
Understanding basic CRUD operations
Starting the backend development of the Contacts App
Project Created

Project Name:

ContactsApp

Created using:

dotnet new web -n ContactsApp
Basic Minimal API Structure
ContactsApp
│
├── Properties
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── ContactsApp.csproj
└── ContactsApp.http
Example Minimal API
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/api/contacts", () =>
{
    return Results.Ok("List of Contacts");
});

app.Run();
Key Concepts Covered
ASP.NET Core Minimal APIs
Lightweight Endpoint Definitions
Route Mapping
HTTP Methods
GET, POST, PUT and DELETE
Request and Response Handling
JSON Responses
CRUD Operations
API Endpoints
Minimal API Project Structure
Practical Task

Started developing the Contacts App backend using Minimal APIs.

The application will provide endpoints for managing contacts, such as:

GET    /api/contacts
POST   /api/contacts
PUT    /api/contacts/{id}
DELETE /api/contacts/{id}

These endpoints will be used to perform basic CRUD operations on contact information.

Outcome

Successfully understood the fundamentals of Minimal APIs in ASP.NET Core, learned how to define lightweight HTTP endpoints, handle requests and responses, and started developing the Contacts App backend using Minimal APIs.


# Day 8 - H2 Database, Distributed Architecture & API Testing

## Date: 12/08/2026

Objective

The objective of today's session was to understand the H2 Database, its ADO.NET wrapper H2Sharp, the fundamentals of Distributed Architecture, and automated API testing using RestAssured.Net. The concepts were also applied to the ongoing Contacts App backend.

What We Learned
Introduction to H2 Database
Understanding the purpose and features of H2 Database
Understanding H2Sharp as an ADO.NET wrapper for H2
Understanding database connectivity from .NET applications
Introduction to Distributed Architecture
Understanding the motivation and benefits of distributed systems
Understanding scalability, fault isolation, and independent deployment
Introduction to RestAssured.Net for API testing
Understanding automated API testing
Testing HTTP requests and responses
Validating API status codes and responses
Understanding SDLC (Software Development Life Cycle)
Project Continued

Project Name:

ContactsApp

The existing Contacts App backend was continued by applying the concepts introduced during the live class.

H2 Database and H2Sharp

H2 is a lightweight relational database that can be useful for development and testing.

H2Sharp provides an ADO.NET-based way for .NET applications to interact with H2.

Basic flow:

Contacts App
     ↓
ADO.NET / H2Sharp
     ↓
H2 Database
Distributed Architecture

Distributed architecture involves dividing an application into multiple services or components that can communicate over a network.

Example:

Client
  ↓
API Gateway
  ↓
Contacts Service
  ↓
Database

Benefits include:

Scalability
Fault isolation
Independent deployment
Separation of responsibilities
Better resource utilization
API Testing Using RestAssured.Net

RestAssured.Net was introduced for automated testing of REST APIs.

The basic testing flow is:

Given
  ↓
When
  ↓
Then

Example:

Send GET Request
       ↓
Contacts API
       ↓
Verify Status Code
       ↓
Verify Response

API endpoints of the Contacts App can be tested for:

GET
POST
PUT
DELETE
Practical Task

Continued development of the Contacts App backend by applying the concepts introduced in the live class.

The Contacts App endpoints were tested using RestAssured.Net to verify API functionality, HTTP status codes, and responses.

Example endpoints:

GET    /api/contacts
POST   /api/contacts
PUT    /api/contacts/{id}
DELETE /api/contacts/{id}
Key Concepts Covered
H2 Database
H2Sharp
ADO.NET
Database Connectivity
Distributed Architecture
Scalability
Fault Isolation
REST API Testing
RestAssured.Net
HTTP Requests and Responses
Status Code Validation
SDLC
CRUD API Testing
Outcome

Successfully understood the fundamentals of H2 Database, H2Sharp, Distributed Architecture, RestAssured.Net, and SDLC. Continued development of the Contacts App backend and applied the learned concepts by testing its API endpoints using RestAssured.Net.