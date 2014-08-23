--Write a SQL statement to create a table Users. Users should have 
--username, password, full name and last login time. Choose appropriate 
--data types for the table fields. Define a primary key column with a 
--primary key constraint. Define the primary key column as identity to 
--facilitate inserting records. Define unique constraint to avoid 
--repeating usernames. Define a check constraint to ensure the password 
--is at least 5 characters long.
USE TelerikAcademy
CREATE TABLE Users
(
	[UserID] int NOT NULL IDENTITY,
	[Username] varchar(10) NOT NULL,
	[Password] varchar(50),
	[FullName] varchar(50),
	[LastLogin] datetime,
	CONSTRAINT PK_UsreID PRIMARY KEY (UserID),
	CONSTRAINT uc_Username UNIQUE (Username),
	CONSTRAINT chk_PasswordLength CHECK (LEN([Password]) > 5)
);