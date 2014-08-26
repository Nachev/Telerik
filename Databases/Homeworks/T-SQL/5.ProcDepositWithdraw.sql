--Add two more stored procedures WithdrawMoney( 
--AccountId, money) and DepositMoney 
--(AccountId, money) that operate in transactions.

USE [TSqlHomework]
 
IF OBJECT_ID('dbo.uspWithdrawMoney', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].uspWithdrawMoney
GO
CREATE PROCEDURE [dbo].uspWithdrawMoney (@accountId int, @ammount money)
AS
  BEGIN
    BEGIN TRAN tran_withdrawMoney;
	  UPDATE [dbo].[Accounts]
	    SET [Balance] = [Balance] - @ammount
		WHERE [AccountID] = @accountId;
	COMMIT TRAN tran_withdrawMoney;
  END;
GO

IF OBJECT_ID('dbo.uspDepositMoney', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].uspDepositMoney
GO
CREATE PROCEDURE [dbo].uspDepositMoney (@accountId int, @ammount money)
AS
  BEGIN
    BEGIN TRAN tran_depositMoney;
	  UPDATE [dbo].[Accounts]
	    SET [Balance] = [Balance] + @ammount
		WHERE [AccountID] = @accountId;
    COMMIT TRAN tran_depositMoney;
  END;
GO

EXEC [dbo].uspDepositMoney 3, 2304.10
GO
EXEC [dbo].uspWithdrawMoney 3, 1300.32
GO