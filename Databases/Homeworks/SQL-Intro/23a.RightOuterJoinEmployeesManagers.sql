-- 23a. Write a SQL query to find all the employees and the --
-- manager for each of them along with the employees	   --
-- that do not have manager. Use right outer join.		   --
-- Rewrite the query to use left outer join.			   --SELECT * FROM [TelerikAcademy].[dbo].[Employees] man	RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] em	ON man.EmployeeID = em.ManagerID