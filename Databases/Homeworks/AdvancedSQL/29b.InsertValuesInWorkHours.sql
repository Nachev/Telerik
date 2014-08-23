INSERT INTO TelerikAcademy.dbo.WorkHours([EmployeeID], [Date], [Hours], [Task], [Comments])
	VALUES 
		(23, CONVERT(date, GETDATE()), CONVERT(time, GETDATE()), 'Do some work', 'And some comments'),
		(33, CONVERT(date, GETDATE()), CONVERT(time, GETDATE()), 'Do some work', 'And some comments'),
		(13, CONVERT(date, GETDATE()), CONVERT(time, GETDATE()), 'Do some work', 'And some comments'),
		(213, CONVERT(date, GETDATE()), CONVERT(time, GETDATE()), 'Do some work', 'And some comments'),
		(123, CONVERT(date, '2011-03-03'), CONVERT(time, '12:32:45.146'), 'Do some work', 'And some comments')