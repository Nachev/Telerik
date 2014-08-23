--Write a SQL statement that deletes all users without passwords (NULL password).

DELETE TelerikAcademy.dbo.Users
WHERE [Password] IS NULL