--Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM TelerikAcademy.dbo.Users
WHERE Username = 'Mariika'

DELETE FROM TelerikAcademy.dbo.Groups
WHERE Name = 'Shooters'