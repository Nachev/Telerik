CREATE TABLE [TelerikAcademy].[dbo].[WorkHoursLogs]
(
	[WorkHoursLogsID] int IDENTITY NOT NULL,
	[EntryID] int,
	[ColumnName] nvarchar(50),
	[OldValue] nvarchar(50),
	[NewValue] nvarchar(50),
	CONSTRAINT PK_WorkHoursLogsId PRIMARY KEY([WorkHoursLogsID])
)