--Write SQL statements to insert in the Users table the names 
--of all employees from the Employees table. Combine the first 
--and last names as a full name. For username use the first letter 
--of the first name + the last name (in lowercase). Use the same 
--for the password, and NULL for last login time.

INSERT INTO TelerikAcademy.dbo.Users(Username, [Password], FullName, LastLogin, GroupID)
SELECT LOWER(LEFT(e.FirstName, 3) + '.' + e.LastName) AS Username, -- Constraint does not allow duplicate names
	LOWER(LEFT(e.FirstName, 1) + e.LastName + 'pass') AS [Password],  -- Constraint does not allow pass length < 5
	e.FirstName + ISNULL( ' ' + e.MiddleName, '') + ' ' + e.LastName AS [FullName],
	NULL,
	NULL
	FROM TelerikAcademy.dbo.Employees e