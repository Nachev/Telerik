CREATE TABLE [TelerikAcademy].[dbo].[LogOperationType]
(
	[LogOperationTypeID] int IDENTITY NOT NULL,
	[OperationTypeData] nvarchar(10),
	CONSTRAINT PK_LogOperationTypeId PRIMARY KEY([LogOperationTypeID]),
)

INSERT INTO [TelerikAcademy].[dbo].[LogOperationType]
	VALUES ('INSERT'), ('UPDATE'), ('DELETE')

GO

CREATE TABLE [TelerikAcademy].[dbo].[WorkHoursLogs]
(
	[WorkHoursLogsID] int IDENTITY NOT NULL,
	[LogOperationTypeID] int NOT NULL,
	[WorkHoursID] int NOT NULL,
	[EmployeeID] int NOT NULL,
	[LogDate] date,
	[LogHours] time,
	[Task] nvarchar(50),
	[Comments] nvarchar(50),
	[IsDeleted] bit, 
	[OldValueID] int,
	CONSTRAINT PK_WorkHoursLogsId PRIMARY KEY([WorkHoursLogsID]),
	CONSTRAINT FK_WHLogs_WorkHours FOREIGN KEY([WorkHoursID]) REFERENCES [TelerikAcademy].[dbo].[WorkHours]([WorkHoursID]),
	CONSTRAINT FK_WHLogs_WHLogs FOREIGN KEY([OldValueID]) REFERENCES [TelerikAcademy].[dbo].[WorkHoursLogs]([WorkHoursLogsID]),
	CONSTRAINT FK_WHLogs_LogOperationType FOREIGN KEY([LogOperationTypeID]) REFERENCES [TelerikAcademy].[dbo].[LogOperationType]([LogOperationTypeID])
)