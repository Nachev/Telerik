-- Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary) FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'