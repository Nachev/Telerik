-- Write a SQL query to find the full name, salary and department of the employees
-- that take the minimal salary in their department. Use a nested SELECT statement.
SELECT FirstName + ISNULL(' ' + MiddleName, '') + ' ' + LastName AS [Full Name], Salary, d.Name
	FROM TelerikAcademy.dbo.Employees e
		INNER JOIN TelerikAcademy.dbo.Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE Salary = (
			SELECT MIN(Salary) FROM TelerikAcademy.dbo.Employees em
				WHERE em.DepartmentID = d.DepartmentID
		)
		ORDER BY d.Name