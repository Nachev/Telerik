-- Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) FROM TelerikAcademy.dbo.Employees e
	WHERE ManagerID IS NULL