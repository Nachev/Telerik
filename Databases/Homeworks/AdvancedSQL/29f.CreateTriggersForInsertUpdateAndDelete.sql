USE [TelerikAcademy]
GO

IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'IsDeleted' AND [object_id] = OBJECT_ID(N'WorkHours'))
BEGIN
  ALTER TABLE [dbo].[WorkHours]
    ADD [IsDeleted] bit DEFAULT 0
END
GO

IF OBJECT_ID ('trg_WorkHoursDelete','TR') IS NOT NULL
  DROP TRIGGER trg_WorkHoursDelete;
GO
CREATE TRIGGER trg_WorkHoursDelete ON [dbo].[WorkHours]
  INSTEAD OF DELETE
AS
  UPDATE w 
	SET w.[IsDeleted] = 1
    FROM [dbo].[WorkHours] w JOIN deleted d 
      ON d.WorkHoursID = w.WorkHoursID
  WHERE (w.[IsDeleted] IS NULL) OR (w.[IsDeleted] = 0)  
GO

IF OBJECT_ID('trg_LogUpdate','TR') IS NOT NULL
  DROP TRIGGER trg_LogUpdate
GO
CREATE TRIGGER trg_LogUpdate ON [dbo].[WorkHours]
  AFTER UPDATE
AS
  BEGIN
	DECLARE @oldValueId int
	DECLARE @operationType int = 2
    INSERT INTO [dbo].[WorkHoursLogs]
	    ([LogOperationTypeID], [WorkHoursID], [EmployeeID], [LogDate], [LogHours], [Task], [Comments], [IsDeleted])
	  SELECT 
	    @operationType, d.WorkHoursID, d.EmployeeID, d.Date, d.Hours, d.Task, d.Comments, d.IsDeleted
	  FROM 
	    deleted d
	SET @oldValueId = @@IDENTITY
	INSERT INTO [dbo].[WorkHoursLogs]
	    ([LogOperationTypeID], [WorkHoursID], [EmployeeID], [LogDate], [LogHours], [Task], [Comments], [IsDeleted], [OldValueID])
	  SELECT 
	    @operationType, i.WorkHoursID, i.EmployeeID, i.Date, i.Hours, i.Task, i.Comments, i.IsDeleted, @oldValueId
	  FROM 
	    inserted i
  END;
 GO

IF OBJECT_ID('trg_LogInsert','TR') IS NOT NULL
  DROP TRIGGER trg_LogInsert
GO
CREATE TRIGGER trg_LogInsert ON [dbo].[WorkHours]
  AFTER INSERT
AS
  BEGIN
	DECLARE @operationType int = 1
	INSERT INTO [dbo].[WorkHoursLogs]
	    ([LogOperationTypeID], [WorkHoursID], [EmployeeID], [LogDate], [LogHours], [Task], [Comments], [IsDeleted])
	  SELECT 
	    @operationType, i.WorkHoursID, i.EmployeeID, i.Date, i.Hours, i.Task, i.Comments, i.IsDeleted
	  FROM 
	    inserted i
  END;
GO

IF OBJECT_ID('trg_LogDelete','TR') IS NOT NULL
  DROP TRIGGER trg_LogDelete
GO
CREATE TRIGGER trg_LogDelete ON [dbo].[WorkHours]
  AFTER DELETE
AS
  BEGIN
	DECLARE @oldValueId int
	DECLARE @operationType int = 3
    INSERT INTO [dbo].[WorkHoursLogs]
	    ([LogOperationTypeID], [WorkHoursID], [EmployeeID], [LogDate], [LogHours], [Task], [Comments], [IsDeleted])
	  SELECT 
	    @operationType, d.WorkHoursID, d.EmployeeID, d.Date, d.Hours, d.Task, d.Comments, d.IsDeleted
	  FROM 
	    deleted d
  END;
GO