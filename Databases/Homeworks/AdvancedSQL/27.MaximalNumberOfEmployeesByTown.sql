--Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 tc.Name, tc.EmployessCount FROM (
	SELECT COUNT(*) AS [EmployessCount], t.Name FROM TelerikAcademy.dbo.Employees e
		INNER JOIN TelerikAcademy.dbo.Addresses a
			ON e.AddressID = a.AddressID
		INNER JOIN TelerikAcademy.dbo.Towns t
			ON t.TownID = a.TownID
		GROUP BY t.Name) tc
	ORDER BY tc.EmployessCount DESC
