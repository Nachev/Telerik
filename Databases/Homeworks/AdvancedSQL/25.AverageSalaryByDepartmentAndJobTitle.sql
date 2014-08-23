--Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(Salary) AS [Average Salary], e.JobTitle, d.Name AS [Department] 
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Addresses ad
		ON e.AddressID = ad.AddressID
	INNER JOIN TelerikAcademy.dbo.Departments d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle