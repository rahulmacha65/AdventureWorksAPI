--Query to create Database
CREATE DATABASE AdventureWorks

--Query to use AdventureWorks Database
USE AdventureWorks

--Query to create person table.
CREATE TABLE Person(
PersonId int IDENTITY (1,1) PRIMARY KEY,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
EmailAddress nvarchar(50) NOT NULL,
PhoneNumber nvarchar(20) NOT NULL,
Address nvarchar(max)
)
--Query to create demographics table.
CREATE TABLE DemographicDetails(
DemographicId int IDENTITY (1,1) PRIMARY KEY,
Age int,
Gender nvarchar(20),
MaritalStatus nvarchar(10),
Education nvarchar(max),
PersonId int FOREIGN KEY REFERENCES Person(PersonId)
)

--SELECT query to select the tables.
SELECT * FROM dbo.Person
SELECT * FROM dbo.DemographicDetails

--INSERT queries to insert details in both the tables.
INSERT INTO dbo.Person (FirstName,LastName,EmailAddress,PhoneNumber,Address)
VALUES
('Alissa','Clark','a.clark@randatmail.com','455-1783-34','47 W 13th St, New York, NY 10011, USA'),
('Charlie','Cooper','c.cooper@randatmail.com','750-5698-89','20 Cooper Square, New York, NY 10003, USA'),
('Eric','Alexander','e.alexander@randatmail.com','123-9205-66','1 E 2nd St, New York, NY 10003, USA'),
('Jack','Richardson','j.richardson@randatmail.com','172-0923-87','75 3rd Ave, New York, NY 10003, USA'),
('Kevin','Thompson','k.thompson@randatmail.com','540-9438-48','Metrotech Center, Brooklyn, NY 11201, USA')


INSERT INTO dbo.DemographicDetails(Age,Gender,MaritalStatus,Education,PersonId)
VALUES
(22,'Female','Single','Upper secondary',2),
(22,'Male','Single','Bachelors',3),
(22,'Male','Married','Bachelors',4),
(28,'Male','Married','Bachelors',5),
(19,'Male','Married','Primary',6)

-- SP to read data from both tables.
CREATE PROCEDURE spGetPersonDetails
AS
BEGIN 
	SELECT * FROM dbo.Person p JOIN dbo.DemographicDetails d
	ON p.PersonId=d.PersonId
	WHERE d.Education='Bachelors'
END




