-- Write a SQL query to display the minimal employee salary
-- by department and job title along with the name of some
-- of the employees that take it.

SELECT MIN(Salary) AS [Minimal Salary], 
	e.JobTitle, 
	d.Name AS [Department], 
	MIN(e.FirstName + ' ' + e.LastName) AS [Some Employee]
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Addresses ad
		ON e.AddressID = ad.AddressID
	INNER JOIN TelerikAcademy.dbo.Departments d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle