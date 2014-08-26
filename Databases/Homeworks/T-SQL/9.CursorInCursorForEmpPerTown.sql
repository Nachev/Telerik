--* Write a T-SQL script that shows for each town a 
--list of all employees that live in it. Sample output:
  --Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
  --Ottawa -> Jose Saraiva
  --…

USE [TelerikAcademy]
GO

IF OBJECT_ID('tempdb..#EmployeesWithIdAndTownNames') IS NOT NULL
BEGIN
  DROP TABLE #EmployeesWithIdAndTownNames
END
CREATE TABLE #EmployeesWithIdAndTownNames(
	[EmployeeID] INT,
	[TownID] INT,
	[EmployeeName] NVARCHAR(50), 
	[TownName] NVARCHAR(50))
GO
INSERT INTO #EmployeesWithIdAndTownNames
	SELECT e.EmployeeID, t.TownID, e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName, t.Name
		FROM [dbo].[Employees] e
		INNER JOIN [dbo].[Addresses] a 
			ON e.AddressID = a.AddressID
		INNER JOIN [dbo].[Towns] t
			ON a.TownID = t.TownID
		ORDER BY t.TownID
GO

DECLARE town_cursor CURSOR READ_ONLY FOR
	SELECT DISTINCT TownID, Name FROM [dbo].[Towns]
OPEN town_cursor;
DECLARE @outerTownID INT, @townName nvarchar(50);
FETCH NEXT FROM town_cursor INTO @outerTownID, @townName;
WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @resultString NVARCHAR(MAX) = @townName + ' -> ';
		DECLARE employee_cursor CURSOR READ_ONLY FOR
			SELECT EmployeeID, TownID FROM #EmployeesWithIdAndTownNames	
				WHERE TownID = @outerTownID
		OPEN employee_cursor;
		DECLARE @employeeID INT, @innerTownID INT;
		FETCH NEXT FROM employee_cursor INTO @employeeID, @innerTownID;
		WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @innerTownID = @outerTownID
				BEGIN
					SELECT @resultString = CONCAT(@resultString, emp.EmployeeName + ', ')
						FROM #EmployeesWithIdAndTownNames emp
						WHERE @employeeID = emp.EmployeeID AND emp.TownID = @outerTownID
				END;
				FETCH NEXT FROM employee_cursor
					INTO @employeeID, @innerTownID;
			END;
		PRINT @ResultString;
		CLOSE employee_cursor;
		DEALLOCATE employee_cursor;
		FETCH NEXT FROM town_cursor INTO @outerTownID, @townName;
	END;
CLOSE town_cursor;
DEALLOCATE town_cursor;
