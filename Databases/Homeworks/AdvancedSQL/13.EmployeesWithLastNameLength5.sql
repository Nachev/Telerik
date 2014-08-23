--Write a SQL query to find the names of all employees whose last name is 
-- exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName AS [Employee]
FROM TelerikAcademy.dbo.Employees e
	WHERE LEN(LastName) = 5