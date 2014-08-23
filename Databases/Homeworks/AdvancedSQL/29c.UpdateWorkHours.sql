UPDATE TelerikAcademy.dbo.WorkHours
	SET [EmployeeID] = 24,
		[Comments] = 'Changed employee id due to entry error.'
	WHERE [EmployeeID] = 23