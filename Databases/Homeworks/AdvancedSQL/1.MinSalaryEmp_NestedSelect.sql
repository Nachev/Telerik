-- 1.Write a SQL query to find the names and salaries of the employees that 
-- take the minimal salary in the company. Use a nested SELECT statement.
SELECT * FROM TelerikAcademy.dbo.Employees
	WHERE Salary = (
		SELECT TOP 1 Salary FROM TelerikAcademy.dbo.Employees
			ORDER BY Salary ASC
	)