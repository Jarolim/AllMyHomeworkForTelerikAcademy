USE [master]
GO
/****** Object:  Database [World]    Script Date: 9.7.2013 г. 17:59:38 ч. ******/
CREATE DATABASE [World]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'World', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\World.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'World_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\World_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [World] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [World].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [World] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [World] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [World] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [World] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [World] SET ARITHABORT OFF 
GO
ALTER DATABASE [World] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [World] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [World] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [World] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [World] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [World] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [World] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [World] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [World] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [World] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [World] SET  DISABLE_BROKER 
GO
ALTER DATABASE [World] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [World] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [World] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [World] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [World] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [World] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [World] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [World] SET RECOVERY FULL 
GO
ALTER DATABASE [World] SET  MULTI_USER 
GO
ALTER DATABASE [World] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [World] SET DB_CHAINING OFF 
GO
ALTER DATABASE [World] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [World] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'World', N'ON'
GO
USE [World]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 9.7.2013 г. 17:59:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [text] NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 9.7.2013 г. 17:59:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contries]    Script Date: 9.7.2013 г. 17:59:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Contries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 9.7.2013 г. 17:59:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 9.7.2013 г. 17:59:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([id], [address_text], [town_id]) VALUES (1, N'Studentski grad, 59G', 1)
INSERT [dbo].[Addresses] ([id], [address_text], [town_id]) VALUES (2, N'Some address in Plovdiv', 2)
INSERT [dbo].[Addresses] ([id], [address_text], [town_id]) VALUES (3, N'Washington DC', 5)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [name]) VALUES (1, N'Afrika')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (2, N'Antarctica')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (3, N'Asia')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (4, N'Australia')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (5, N'Europe')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (6, N'North America')
INSERT [dbo].[Continents] ([Id], [name]) VALUES (7, N'South America')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Contries] ON 

INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (1, N'Nigeria', 1)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (2, N'Uganda', 1)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (3, N'Zambia', 1)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (4, N'Egypt', 1)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (5, N'Eskimos', 2)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (6, N'China', 3)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (7, N'North Korea', 3)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (8, N'Russia', 3)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (9, N'Australia', 4)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (11, N'Bulgaria', 5)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (12, N'Romania', 5)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (13, N'Germany', 5)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (14, N'USA', 6)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (15, N'Canada', 6)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (16, N'Brazil', 7)
INSERT [dbo].[Contries] ([id], [name], [continent_id]) VALUES (17, N'Chili', 7)
SET IDENTITY_INSERT [dbo].[Contries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Pesho', N'Peshev', 2)
INSERT [dbo].[Persons] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Barak', N'Obama', 3)
INSERT [dbo].[Persons] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Gosho', N'Plovdivskiq', 2)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([id], [name], [country_id]) VALUES (1, N'Sofia', 11)
INSERT [dbo].[Towns] ([id], [name], [country_id]) VALUES (2, N'Plovdiv', 11)
INSERT [dbo].[Towns] ([id], [name], [country_id]) VALUES (3, N'Burgas', 11)
INSERT [dbo].[Towns] ([id], [name], [country_id]) VALUES (4, N'Berlin', 13)
INSERT [dbo].[Towns] ([id], [name], [country_id]) VALUES (5, N'Washington', 14)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([town_id])
REFERENCES [dbo].[Towns] ([id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Contries]  WITH CHECK ADD  CONSTRAINT [FK_Contries_Continents] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Contries] CHECK CONSTRAINT [FK_Contries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([address_id])
REFERENCES [dbo].[Addresses] ([id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Contries] FOREIGN KEY([country_id])
REFERENCES [dbo].[Contries] ([id])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Contries]
GO
USE [master]
GO
ALTER DATABASE [World] SET  READ_WRITE 
GO
