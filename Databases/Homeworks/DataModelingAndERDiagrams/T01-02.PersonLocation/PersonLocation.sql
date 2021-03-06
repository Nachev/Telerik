USE [master]
GO
/****** Object:  Database [PersonLocation]    Script Date: 20.8.2014 г. 17:16:34 ******/
CREATE DATABASE [PersonLocation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonLocation', FILENAME = N'D:\Databases\MSSQL11.MSSQLSERVER\MSSQL\DATA\PersonLocation.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonLocation_log', FILENAME = N'D:\Databases\MSSQL11.MSSQLSERVER\MSSQL\DATA\PersonLocation_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonLocation] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonLocation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonLocation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonLocation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonLocation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonLocation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonLocation] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonLocation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonLocation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonLocation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonLocation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonLocation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonLocation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonLocation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonLocation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonLocation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonLocation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonLocation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonLocation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonLocation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonLocation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonLocation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonLocation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonLocation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonLocation] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonLocation] SET  MULTI_USER 
GO
ALTER DATABASE [PersonLocation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonLocation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonLocation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonLocation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonLocation', N'ON'
GO
USE [PersonLocation]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 20.8.2014 г. 17:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](50) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 20.8.2014 г. 17:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Continents] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[Country]    Script Date: 20.8.2014 г. 17:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContintentId] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 20.8.2014 г. 17:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 20.8.2014 г. 17:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [AddressText], [TownId]) VALUES (1, N'Home', 1)
INSERT [dbo].[Address] ([Id], [AddressText], [TownId]) VALUES (2, N'On the street', 5)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'North Amerika')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (4, N'South Amerika')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (5, N'Afrika')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (6, N'Australia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (7, N'Antarktika')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name], [ContintentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([Id], [Name], [ContintentId]) VALUES (2, N'Romania', 1)
INSERT [dbo].[Country] ([Id], [Name], [ContintentId]) VALUES (3, N'Zambia', 5)
INSERT [dbo].[Country] ([Id], [Name], [ContintentId]) VALUES (4, N'Mexico', 3)
INSERT [dbo].[Country] ([Id], [Name], [ContintentId]) VALUES (5, N'Argentina', 4)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [AddressId]) VALUES (1, N'Pesho', N'Peshev', 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [AddressId]) VALUES (2, N'Horhe', N'Campos', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (3, N'Varna', 1)
INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (4, N'Quilmess', 4)
INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (5, N'Buenos Aires', 4)
SET IDENTITY_INSERT [dbo].[Town] OFF
/****** Object:  Index [IX_Person]    Script Date: 20.8.2014 г. 17:16:34 ******/
CREATE NONCLUSTERED INDEX [IX_Person] ON [dbo].[Person]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([TownId])
REFERENCES [dbo].[Town] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continents] FOREIGN KEY([ContintentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continents]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [PersonLocation] SET  READ_WRITE 
GO
