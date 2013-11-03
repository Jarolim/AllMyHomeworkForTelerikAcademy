USE [master]
GO
/****** Object:  Database [BookstoreSystem]    Script Date: 7/25/2013 6:10:48 PM ******/
CREATE DATABASE [BookstoreSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookstoreSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookstoreSystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookstoreSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookstoreSystem_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookstoreSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookstoreSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookstoreSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookstoreSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookstoreSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookstoreSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookstoreSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookstoreSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookstoreSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookstoreSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookstoreSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookstoreSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookstoreSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookstoreSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookstoreSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookstoreSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookstoreSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookstoreSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookstoreSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookstoreSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookstoreSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookstoreSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookstoreSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookstoreSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookstoreSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookstoreSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [BookstoreSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BookstoreSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookstoreSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookstoreSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookstoreSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookstoreSystem', N'ON'
GO
USE [BookstoreSystem]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 7/25/2013 6:10:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 7/25/2013 6:10:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[ISBN] [nvarchar](13) NULL,
	[Price] [money] NULL,
	[WebSite] [nvarchar](256) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Books_Authors]    Script Date: 7/25/2013 6:10:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books_Authors](
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_Books_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 7/25/2013 6:10:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfCreation] [datetime] NULL,
	[AuthorId] [int] NULL,
	[BookId] [int] NOT NULL,
	[ReviewText] [ntext] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Authors]    Script Date: 7/25/2013 6:10:48 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Authors] ON [dbo].[Authors]
(
	[AuthorName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Books]    Script Date: 7/25/2013 6:10:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books] ON [dbo].[Books]
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Books_1]    Script Date: 7/25/2013 6:10:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books_1] ON [dbo].[Books]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books_Authors]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Books_Authors] CHECK CONSTRAINT [FK_Books_Authors_Authors]
GO
ALTER TABLE [dbo].[Books_Authors]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Books_Authors] CHECK CONSTRAINT [FK_Books_Authors_Books]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Authors1] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Authors1]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Books]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [CK_Books] CHECK  ((len([ISBN])=(13)))
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [CK_Books]
GO
USE [master]
GO
ALTER DATABASE [BookstoreSystem] SET  READ_WRITE 
GO
