--Create a database with two tables: 
--Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance). 
--Insert few records for testing. Write a stored 
--procedure that selects the full names of all persons.

CREATE DATABASE [TSqlHomework]
GO

USE [TSqlHomework]
GO

CREATE TABLE [Persons]
(
	[PersonsID] INT IDENTITY NOT NULL,
	[FirstName] NVARCHAR(50), 
	[LastName] NVARCHAR(50),
	[SSN] UNIQUEIDENTIFIER DEFAULT NEWID(),
	CONSTRAINT PK_PersonsId PRIMARY KEY([PersonsID])
)
GO

CREATE TABLE [Accounts]
(
	[AccountID] INT IDENTITY NOT NULL,
	[PersonsID] INT NOT NULL,
	[Balance] MONEY,
	CONSTRAINT PK_AccountsId PRIMARY KEY([AccountID]),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY([PersonsID]) REFERENCES [Persons]([PersonsID])
)
GO

GRANT SELECT ON Persons TO Public
GO 

INSERT INTO [Persons]([FirstName], [LastName], [SSN])
  VALUES
	('Pesho', 'Petrov', NEWID()),
	('Gosho', 'Georgievv', NEWID()),
	('Petrana', 'Petrova', NEWID()),
	('Mariika', 'Marinova', NEWID()),
	('Stamat', 'Zhelyazkov', NEWID())
GO

INSERT INTO [Accounts]([PersonsID], [Balance])
  VALUES
    (1, 20000.00),
	(2, 2000.00),
	(3, 234.33),
	(4, 1000000000.00),
	(5, 5432.00)
GO

USE [TSqlHomework]
GO

IF OBJECT_ID ( 'dbo.uspGetPersonFullName', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].uspGetPersonFullName;
GO
CREATE PROCEDURE [dbo].uspGetPersonFullName
AS
  BEGIN
    SELECT [FirstName] + ' ' + [LastName] AS [FullName] FROM [Persons]
  END;
GO

EXEC [dbo].uspGetPersonFullName