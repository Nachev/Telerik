--11. Write a SQL query to find the names of all --
--employees whose first name starts with "SA".   --
SELECT FirstName + ISNULL (' ' + MiddleName, '') + ' ' + LastName AS [Full Name] FROM [TelerikAcademy].[dbo].[Employees]
	WHERE FirstName LIKE 'SA%'