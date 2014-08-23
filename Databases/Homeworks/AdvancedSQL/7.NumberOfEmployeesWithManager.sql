-- Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) FROM TelerikAcademy.dbo.Employees e
	WHERE ManagerID IS NOT NULL