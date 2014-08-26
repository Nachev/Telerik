--Create a stored procedure that accepts a number as 
--a parameter and returns all persons who have more 
--money in their accounts than the supplied number.
USE [TSqlHomework]
 
IF OBJECT_ID('dbo.uspGetPersonsWithGraterBalance', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].uspGetPersonsWithGraterBalance
GO
CREATE PROCEDURE dbo.uspGetPersonsWithGraterBalance (@minBalance money)
AS
  BEGIN
	SELECT * FROM [Persons] p INNER JOIN [Accounts] a
	  ON p.PersonsID = a.PersonsID
	  WHERE a.Balance > @minBalance
  END;
GO

EXEC [dbo].uspGetPersonsWithGraterBalance 2000.00