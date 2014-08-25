--Start a database transaction and drop the table EmployeesProjects.
-- Now how you could restore back the lost table data?

-- To restore lost table data there are some options:
	-- First one is Backup restore from previously backed up data
	-- Second one is third parity software such as: ApexSQL Log


ALTER DATABASE [TelerikAcademy] SET RECOVERY FULL
GO

-- DO NOT EXECUTE WITH EXISTING DRIVE H:, IT WILL BE FORMATED
BACKUP DATABASE [TelerikAcademy]
TO DISK = 'H:\SQLServerBackups\TelericAcademy.Bak'
   WITH FORMAT,
      MEDIANAME = 'H_SQLServerBackups',
      NAME = 'Full Backup of TelericAcademy';
GO

BEGIN TRAN tran_DropEmployeesProjects
  DROP TABLE [dbo].[EmployeesProjects]
GO

RESTORE DATABASE [TelerikAcademy]
   FROM DISK = 'H:\SQLServerBackups\TelericAcademy.Bak'
   WITH NORECOVERY;

RESTORE LOG [TelerikAcademy]
   FROM DISK = 'H:\SQLServerBackups\TelericAcademy.Bak'
   WITH NORECOVERY, STOPAT = 'Apr 15, 2020 12:00 AM';

RESTORE LOG [TelerikAcademy]
   FROM DISK = 'H:\SQLServerBackups\TelericAcademy.Bak'
   WITH NORECOVERY, STOPAT = 'Apr 15, 2020 12:00 AM';
RESTORE DATABASE [TelerikAcademy] WITH RECOVERY; 
GO
