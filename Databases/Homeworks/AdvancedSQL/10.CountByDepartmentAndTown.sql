--Write a SQL query to find the count of all employees in each department and for each town.
SELECT COUNT(*) AS [Count], t.Name AS [Town], d.Name AS [Department] 
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Addresses ad
		ON e.AddressID = ad.AddressID
	INNER JOIN TelerikAcademy.dbo.Towns t
		ON ad.TownID = t.TownID
	INNER JOIN TelerikAcademy.dbo.Departments d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, t.Name