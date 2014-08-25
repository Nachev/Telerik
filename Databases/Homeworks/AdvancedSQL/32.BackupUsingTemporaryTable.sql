--Find how to use temporary tables in SQL Server. Using temporary 
--tables backup all records from EmployeesProjects and restore them 
--back after dropping and re-creating the table.

USE [TelerikAcademy];

CREATE TABLE #TemporaryTable (
        EmployeeId INT,
        ProjectId INT
)
GO
INSERT INTO #TemporaryTable
  SELECT ep.EmployeeId AS EmployeeId,
        ep.ProjectId AS ProjectId
  FROM EmployeesProjects ep
GO
DROP TABLE EmployeesProjects
GO
CREATE TABLE EmployeesProjects
(
  EmployeeId INT,
  ProjectId INT
)
GO
INSERT INTO EmployeesProjects
  SELECT tt.EmployeeId AS EmployeeId,
        tt.ProjectId AS ProjectId
  FROM #TemporaryTable tt