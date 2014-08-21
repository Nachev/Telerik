-- 19. Write a SQL query to find all employees and their   --
-- address. Use equijoins (conditions in the WHERE clause) --
SELECT * FROM [TelerikAcademy].[dbo].[Employees] em, [TelerikAcademy].[dbo].[Addresses] ad	WHERE em.AddressID = ad.AddressID