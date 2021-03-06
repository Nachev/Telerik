USE [master]
GO
/****** Object:  Database [TypicalUniversity]    Script Date: 20.8.2014 г. 18:19:14 ******/
CREATE DATABASE [TypicalUniversity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TypicalUniversity', FILENAME = N'D:\Databases\MSSQL11.MSSQLSERVER\MSSQL\DATA\TypicalUniversity.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TypicalUniversity_log', FILENAME = N'D:\Databases\MSSQL11.MSSQLSERVER\MSSQL\DATA\TypicalUniversity_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TypicalUniversity] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TypicalUniversity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TypicalUniversity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TypicalUniversity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TypicalUniversity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TypicalUniversity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TypicalUniversity] SET ARITHABORT OFF 
GO
ALTER DATABASE [TypicalUniversity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TypicalUniversity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TypicalUniversity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TypicalUniversity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TypicalUniversity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TypicalUniversity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TypicalUniversity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TypicalUniversity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TypicalUniversity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TypicalUniversity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TypicalUniversity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TypicalUniversity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TypicalUniversity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TypicalUniversity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TypicalUniversity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TypicalUniversity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TypicalUniversity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TypicalUniversity] SET RECOVERY FULL 
GO
ALTER DATABASE [TypicalUniversity] SET  MULTI_USER 
GO
ALTER DATABASE [TypicalUniversity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TypicalUniversity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TypicalUniversity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TypicalUniversity] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TypicalUniversity', N'ON'
GO
USE [TypicalUniversity]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorTitle]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorTitle](
	[ProfessorId] [int] NOT NULL,
	[TitleId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Title]    Script Date: 20.8.2014 г. 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Name], [ProfessorId]) VALUES (1, N'Descrete Mathematics', 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Name], [FacultyId]) VALUES (1, N'Computer Science', 2)
INSERT [dbo].[Department] ([Id], [Name], [FacultyId]) VALUES (2, N'Informational Security', 2)
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([Id], [Name]) VALUES (1, N'Physics')
INSERT [dbo].[Faculty] ([Id], [Name]) VALUES (2, N'Informational Technologies')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
SET IDENTITY_INSERT [dbo].[Professor] ON 

INSERT [dbo].[Professor] ([Id], [Name], [DepartmentId]) VALUES (1, N'Georgi Dimitrov', 2)
SET IDENTITY_INSERT [dbo].[Professor] OFF
INSERT [dbo].[ProfessorTitle] ([ProfessorId], [TitleId]) VALUES (1, 1)
INSERT [dbo].[ProfessorTitle] ([ProfessorId], [TitleId]) VALUES (1, 2)
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name]) VALUES (1, N'Pesho')
INSERT [dbo].[Student] ([Id], [Name]) VALUES (2, N'Gosho')
INSERT [dbo].[Student] ([Id], [Name]) VALUES (3, N'Mariika')
SET IDENTITY_INSERT [dbo].[Student] OFF
INSERT [dbo].[StudentCourse] ([CourseId], [StudentId]) VALUES (1, 1)
INSERT [dbo].[StudentCourse] ([CourseId], [StudentId]) VALUES (1, 2)
INSERT [dbo].[StudentCourse] ([CourseId], [StudentId]) VALUES (1, 2)
SET IDENTITY_INSERT [dbo].[Title] ON 

INSERT [dbo].[Title] ([Id], [Name]) VALUES (1, N'Ph.D.')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (2, N'Academician')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (3, N'Senior assistant')
SET IDENTITY_INSERT [dbo].[Title] OFF
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Professor]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Faculty]
GO
ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_Department]
GO
ALTER TABLE [dbo].[ProfessorTitle]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorTitle_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[ProfessorTitle] CHECK CONSTRAINT [FK_ProfessorTitle_Professor]
GO
ALTER TABLE [dbo].[ProfessorTitle]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorTitle_Title] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Title] ([Id])
GO
ALTER TABLE [dbo].[ProfessorTitle] CHECK CONSTRAINT [FK_ProfessorTitle_Title]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
USE [master]
GO
ALTER DATABASE [TypicalUniversity] SET  READ_WRITE 
GO
