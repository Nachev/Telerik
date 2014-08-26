--Create a function that accepts as parameters – sum, 
--yearly interest rate and number of months. It should 
--calculate and return the new sum. Write a SELECT to 
--test whether the function works as expected.
USE [TSqlHomework];
GO

IF OBJECT_ID('dbo.ufn_CalculateInterest', 'FN') IS NOT NULL
  DROP FUNCTION [dbo].ufn_CalculateInterest
GO
CREATE FUNCTION [dbo].ufn_CalculateInterest(
    @sum money, 
    @interestRate real, 
    @numberOfMonths int)
  RETURNS money
AS
  BEGIN
	DECLARE @result money;
	SET @result = @sum * ((@interestRate / 12) * @numberOfMonths);
    RETURN @result;
  END;
GO

SELECT [dbo].ufn_CalculateInterest(a.Balance, 6.5, 6) FROM [dbo].[Accounts] a