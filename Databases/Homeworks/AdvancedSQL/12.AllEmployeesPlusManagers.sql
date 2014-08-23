-- Write a SQL query to find all employees along with their managers.
-- For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName, 'no manager') AS [Manager]
FROM TelerikAcademy.dbo.Employees e
	LEFT JOIN TelerikAcademy.dbo.Employees m
		ON e.ManagerID = m.EmployeeID