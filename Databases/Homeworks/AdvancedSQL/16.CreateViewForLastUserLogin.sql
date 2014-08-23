--Write a SQL statement to create a view that displays the users from the Users 
-- table that have been in the system today. Test if the view works correctly.
CREATE VIEW UsersLoggedToday AS
	SELECT [Username]
	FROM TelerikAcademy.dbo.Users
	WHERE CAST([LastLogin] AS DATE) = CAST(getdate() AS DATE)