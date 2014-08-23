-- Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO TelerikAcademy.dbo.Groups(Name)
	VALUES ('Students'), ('Teachers'), ('Drinkers'), ('Drivers')

INSERT INTO TelerikAcademy.dbo.Users(Username, [Password], FullName, LastLogin, GroupID)
	VALUES 
		('Pesho', '123456', 'Petar Petrov', getdate(), 3),
		('Gosho', '123456', 'Georgi Georgiev', getdate(), 3)