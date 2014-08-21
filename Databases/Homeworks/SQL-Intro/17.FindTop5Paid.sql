-- 17. Write a SQL query to find the top 5 best paid employees. --
SELECT TOP(5) * FROM [TelerikAcademy].[dbo].[Employees]
	ORDER BY Salary DESC