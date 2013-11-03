USE [master]
GO
/****** Object:  Database [MultilanguageDictionary]    Script Date: 7/14/2013 9:46:26 AM ******/
CREATE DATABASE [MultilanguageDictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MultilanguageDictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilanguageDictionary.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MultilanguageDictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilanguageDictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MultilanguageDictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilanguageDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilanguageDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MultilanguageDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilanguageDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilanguageDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilanguageDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilanguageDictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilanguageDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [MultilanguageDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilanguageDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilanguageDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilanguageDictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilanguageDictionary', N'ON'
GO
USE [MultilanguageDictionary]
GO
/****** Object:  User [batman]    Script Date: 7/14/2013 9:46:26 AM ******/
CREATE USER [batman] FOR LOGIN [batman] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 7/14/2013 9:46:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[explanationId] [int] NOT NULL,
	[wordId] [int] NOT NULL,
	[language] [nvarchar](20) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[explanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 7/14/2013 9:46:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[synonymId] [int] NOT NULL,
	[wordId] [int] NOT NULL,
 CONSTRAINT [PK_Synonyms_1] PRIMARY KEY CLUSTERED 
(
	[synonymId] ASC,
	[wordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 7/14/2013 9:46:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[wordId] [int] NOT NULL,
	[translationId] [int] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[wordId] ASC,
	[translationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 7/14/2013 9:46:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[wordId] [int] NOT NULL,
	[language] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[wordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([wordId])
REFERENCES [dbo].[Words] ([wordId])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words1] FOREIGN KEY([synonymId])
REFERENCES [dbo].[Words] ([wordId])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words2] FOREIGN KEY([wordId])
REFERENCES [dbo].[Words] ([wordId])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words2]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([wordId])
REFERENCES [dbo].[Words] ([wordId])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words1] FOREIGN KEY([translationId])
REFERENCES [dbo].[Words] ([wordId])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words1]
GO
USE [master]
GO
ALTER DATABASE [MultilanguageDictionary] SET  READ_WRITE 
GO
