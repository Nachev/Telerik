--Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'