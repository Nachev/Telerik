--Define a .NET aggregate function StrConcat that takes
-- as input a sequence of strings and return a single 
-- string that consists of the input strings separated 
-- by ','. For example the following SQL statement 
-- should return a single string:
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
USE [TelerikAcademy];
GO

DECLARE @SamplesPath nvarchar(1024)

-- To be executed properly path should point to the StrConcatProject.dll
SELECT @dllPath = 'D:\Git\Telerik\Databases\Homeworks\T-SQL\StrConcatProject\StrConcatProject.dll'

CREATE ASSEMBLY StringUtilities FROM @dllPath
WITH PERMISSION_SET=SAFE;
GO

CREATE AGGREGATE [dbo].StrConcat (@strToConcat nvarchar(4000))
	RETURNS nvarchar(4000)
	EXTERNAL NAME [StringUtilities]
GO

SELECT [dbo].StrConcat([FirstName]) FROM TelerikAcademy.dbo.Employees