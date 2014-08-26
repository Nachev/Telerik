--Define a function in the database TelerikAcademy
--that returns all Employee's names (first or middle or 
--last name) and all town's names that are comprised 
--of given set of letters. Example 'oistmiahf' will 
--return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

IF OBJECT_ID('dbo.ufn_EmployeesNamesAndTowns', 'TF') IS NOT NULL
  DROP FUNCTION [dbo].[ufn_EmployeesNamesAndTowns]
GO
CREATE FUNCTION [dbo].[ufn_EmployeesNamesAndTowns] (@lettersSet NVARCHAR(50))
  RETURNS @NameSet TABLE([Name] NVARCHAR(100))
AS
BEGIN
	DECLARE uname_cursor CURSOR READ_ONLY FOR
			SELECT [FirstName] AS [UName] FROM [dbo].[Employees]
			UNION
			SELECT [MiddleName] AS [UName] FROM [dbo].[Employees]
				WHERE [MiddleName] IS NOT NULL
			UNION
			SELECT [LastName] AS [UName] FROM [dbo].[Employees]
			UNION
			SELECT [Name] AS [UName] FROM [dbo].[Towns]
	OPEN uname_cursor
	DECLARE @name char(50);
	FETCH NEXT FROM uname_cursor INTO @name;
	WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE @stringLen INT = LEN(@name);
			DECLARE @index INT = 1;
			DECLARE @character NCHAR;
			DECLARE @isLikeSet BIT = 1;
			WHILE @index <= @stringLen
				BEGIN 
					SET @character = SUBSTRING(@name,@index,1);
					SET @index = @index + 1;
					IF @character NOT LIKE ('[' + @lettersSet + ']')
						BEGIN
							SET @isLikeSet = 0;
							BREAK;
						END;
				END;
			IF @isLikeSet = 1
				INSERT INTO @NameSet VALUES (@name);
			FETCH NEXT FROM uname_cursor 
				INTO @name
		END;
	CLOSE uname_cursor
	DEALLOCATE uname_cursor
	RETURN;
END;
GO

SELECT * FROM [dbo].[ufn_EmployeesNamesAndTowns]('oistmiahf')