-- Write a SQL query to find all managers that have exactly 
-- 5 employees. Display their first name and last name.
SELECT * FROM TelerikAcademy.dbo.Employees m
	WHERE (
		SELECT COUNT(*) FROM TelerikAcademy.dbo.Employees e
			WHERE e.ManagerID = m.EmployeeID
		GROUP BY e.ManagerID
	) = 5