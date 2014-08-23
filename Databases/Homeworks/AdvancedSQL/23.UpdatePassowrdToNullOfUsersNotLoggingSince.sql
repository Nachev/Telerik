--Write a SQL statement that changes the password to NULL for 
--all users that have not been in the system since 10.03.2010.

UPDATE TelerikAcademy.dbo.Users
	SET [Password] = NULL
	WHERE CAST(LastLogin AS DATE) < CAST('2010-03-10' AS DATE) 