--Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE TelerikAcademy.dbo.Users
	SET Username = 'Mariika', FullName = 'Maria Petrova'
	WHERE Username = 'Gosho';

UPDATE TelerikAcademy.dbo.Groups
	SET Name = 'Shooters'
	WHERE Name = 'Drivers';