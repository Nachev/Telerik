-- 21. Write a SQL query to find all employees, along with their manager and   --
-- their address. Join the 3 tables: Employees e, Employees m and Addresses a. --
SELECT em.EmployeeID, em.FirstName + ' ' + em.LastName AS [Employee Name], m.EmployeeID, m.FirstName + ' ' + m.LastName AS [Manager Name], ad.AddressText