USE [TSqlHomework]
GO

CREATE TABLE [dbo].[Logs](
	[LogID] int IDENTITY(1,1) NOT NULL,
	[AccountID] int NOT NULL,
	[OldSum] money NULL,
	[NewSum] money NULL,
	CONSTRAINT [PK_LogId] PRIMARY KEY([LogID]),
	CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountID])
      REFERENCES [dbo].[Accounts] ([AccountID])
)
GO

IF OBJECT_ID ('dbo.trg_LogUpdate','TR') IS NOT NULL
  DROP TRIGGER [dbo].[trg_LogUpdate];
GO
CREATE TRIGGER [dbo].[trg_LogUpdate] ON [dbo].[Accounts]
  AFTER UPDATE
AS
  BEGIN
    INSERT INTO [dbo].[Logs]
	    ([AccountID], [OldSum], [NewSum])
	  SELECT 
	    d.AccountID, d.Balance, i.Balance
	  FROM 
	    deleted d INNER JOIN inserted i
	  ON d.AccountID = i.AccountID
  END;
GO
