--Start a database transaction, delete all employees from the 'Sales' 
--department along with all dependent records from the pother tables.
-- At the end rollback the transaction.
BEGIN TRAN tran_DeleteSales
  USE [TelerikAcademy];
  -- Change in constraint is needed to remove the dependencies
  ALTER TABLE [dbo].[Departments]
    DROP CONSTRAINT [FK_Departments_Employees]
  GO
  ALTER TABLE [dbo].[Departments]
	ADD CONSTRAINT [FK_Departments_Employees] 
	  FOREIGN KEY(ManagerID) 
	  REFERENCES [dbo].[Employees]([EmployeeID])
	  ON DELETE CASCADE
  GO
  DECLARE @EmployeesToDelete AS TABLE(empID INT)
  INSERT INTO @EmployeesToDelete
    SELECT [EmployeeID] FROM [dbo].[Employees] 
	  WHERE [DepartmentID] = 3
  
  DELETE FROM [dbo].[WorkHours]
    WHERE [EmployeeID] IN (
	  SELECT * FROM @EmployeesToDelete
	)

  DELETE FROM [dbo].[Employees]
	WHERE [DepartmentID] = 3

  DELETE FROM [dbo].[Departments]
    WHERE [ManagerID] IN (
	  SELECT * FROM @EmployeesToDelete
	)
ROLLBACK TRAN tran_DeleteSales