--Write a SQL query to display the number of managers from each town.
SELECT COUNT(*), t.Name FROM (
	SELECT DISTINCT ManagerID FROM TelerikAcademy.dbo.Employees
		WHERE ManagerID IS NOT NULL
	) man
	INNER JOIN TelerikAcademy.dbo.Employees e
		ON e.EmployeeID = man.ManagerID
	INNER JOIN TelerikAcademy.dbo.Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN TelerikAcademy.dbo.Towns t
		ON t.TownID = a.TownID
	GROUP BY t.Name