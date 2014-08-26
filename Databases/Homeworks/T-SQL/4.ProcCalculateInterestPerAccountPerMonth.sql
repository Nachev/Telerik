--Create a stored procedure that uses the function 
--from the previous example to give an interest to a 
--person's account for one month. It should take the 
--AccountId and the interest rate as parameters.

USE [TSqlHomework]
 
IF OBJECT_ID('dbo.uspGetInterestPerMonth', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].uspGetInterestPerMonth
GO
CREATE PROCEDURE [dbo].uspGetInterestPerMonth (@accountId int, @interestRate real)
AS
  BEGIN
    SELECT 
	  p.[FirstName] + ' ' + p.[LastName] AS [FullName], 
	  [dbo].ufn_CalculateInterest(a.Balance, @interestRate, 1) AS [NewBalance]
	FROM [dbo].[Persons] p INNER JOIN [dbo].[Accounts] a
	  ON p.PersonsID = a.PersonsID
	WHERE a.AccountID = @accountId
  END;
GO

EXEC [dbo].uspGetInterestPerMonth 
  @accountId = 3, 
  @interestRate = 3.4