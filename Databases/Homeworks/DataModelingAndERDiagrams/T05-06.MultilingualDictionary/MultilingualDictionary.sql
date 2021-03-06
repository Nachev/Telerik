USE [master]
GO
/****** Object:  Database [MultilingualDictionary]    Script Date: 21.8.2014 г. 11:05:50 ******/
CREATE DATABASE [MultilingualDictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MultilingualDictionary', FILENAME = N'D:\Databases\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilingualDictionary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MultilingualDictionary_log', FILENAME = N'D:\Databases\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilingualDictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MultilingualDictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilingualDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilingualDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilingualDictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilingualDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [MultilingualDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilingualDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilingualDictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilingualDictionary', N'ON'
GO
USE [MultilingualDictionary]
GO
/****** Object:  Table [dbo].[Hypernym]    Script Date: 21.8.2014 г. 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernym](
	[HypernymId] [int] NOT NULL,
	[HyponymId] [int] NOT NULL,
 CONSTRAINT [PK_Hypernym] PRIMARY KEY CLUSTERED 
(
	[HypernymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 21.8.2014 г. 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartOfSpeech]    Script Date: 21.8.2014 г. 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartOfSpeech](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartOfSpeech] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonym]    Script Date: 21.8.2014 г. 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonym](
	[WordId] [int] NOT NULL,
	[SynonymWordId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word]    Script Date: 21.8.2014 г. 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word](
	[WordId] [int] IDENTITY(1,1) NOT NULL,
	[WordData] [nvarchar](50) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Explanation] [nvarchar](50) NOT NULL,
	[PartOfSpeechId] [int] NOT NULL,
	[AntonymId] [int] NOT NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordMeaning]    Script Date: 21.8.2014 г. 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordMeaning](
	[MeaningWordId] [int] NOT NULL,
	[WordId] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Hypernym]  WITH CHECK ADD  CONSTRAINT [FK_Hypernym_Word] FOREIGN KEY([HypernymId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Hypernym] CHECK CONSTRAINT [FK_Hypernym_Word]
GO
ALTER TABLE [dbo].[Hypernym]  WITH CHECK ADD  CONSTRAINT [FK_Hypernym_Word1] FOREIGN KEY([HyponymId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Hypernym] CHECK CONSTRAINT [FK_Hypernym_Word1]
GO
ALTER TABLE [dbo].[Synonym]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Synonym] CHECK CONSTRAINT [FK_Synonym_Language]
GO
ALTER TABLE [dbo].[Synonym]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Synonym] CHECK CONSTRAINT [FK_Synonym_Word]
GO
ALTER TABLE [dbo].[Synonym]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_Word1] FOREIGN KEY([SynonymWordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Synonym] CHECK CONSTRAINT [FK_Synonym_Word1]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Language]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_PartOfSpeech] FOREIGN KEY([PartOfSpeechId])
REFERENCES [dbo].[PartOfSpeech] ([Id])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_PartOfSpeech]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Word] FOREIGN KEY([AntonymId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Word]
GO
ALTER TABLE [dbo].[WordMeaning]  WITH CHECK ADD  CONSTRAINT [FK_WordMeaning_Word] FOREIGN KEY([MeaningWordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[WordMeaning] CHECK CONSTRAINT [FK_WordMeaning_Word]
GO
ALTER TABLE [dbo].[WordMeaning]  WITH CHECK ADD  CONSTRAINT [FK_WordMeaning_Word1] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[WordMeaning] CHECK CONSTRAINT [FK_WordMeaning_Word1]
GO
USE [master]
GO
ALTER DATABASE [MultilingualDictionary] SET  READ_WRITE 
GO
