--Using database cursor write a T-SQL script that scans all
--employees and their addresses and prints all pairs of
--employees that live in the same town.
USE [TelerikAcademy]
GO
DECLARE employee_cursor CURSOR READ_ONLY FOR
			SELECT e.EmployeeID, a.TownID FROM [dbo].[Employees] e
				INNER JOIN [dbo].[Addresses] a 
				ON e.AddressID = a.AddressID

CREATE TABLE #EmployeesWithIdAndTownNames(
	[EmployeeID] INT,
	[TownID] INT,
	[EmployeeName] NVARCHAR(50), 
	[TownName] NVARCHAR(50))
GO
INSERT INTO #EmployeesWithIdAndTownNames
	SELECT e.EmployeeID, t.TownID, e.FirstName + ' ' + e.LastName, t.Name
		FROM [dbo].[Employees] e
		INNER JOIN [dbo].[Addresses] a 
			ON e.AddressID = a.AddressID
		INNER JOIN [dbo].[Towns] t
			ON a.TownID = t.TownID

OPEN employee_cursor;
DECLARE @employeeID INT, @townID INT;
DECLARE @ResultTable TABLE(
	[FirstName] nvarchar(50), 
	[SecondName] nvarchar(50), 
	[TownName] nvarchar(50)
);
FETCH NEXT FROM employee_cursor INTO @employeeID, @townID;
WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO @ResultTable([FirstName], [SecondName], [TownName])
			SELECT e.FirstName + ' ' + e.LastName, empT.EmployeeName, empT.TownName
				FROM [dbo].[Employees] e, #EmployeesWithIdAndTownNames empT
				WHERE e.EmployeeID = @employeeID AND @employeeID != empT.EmployeeID AND empT.TownID = @townID
		FETCH NEXT FROM employee_cursor
			INTO @employeeID, @townID;
	END;
CLOSE employee_cursor;
DEALLOCATE employee_cursor;

SELECT * FROM @ResultTable
