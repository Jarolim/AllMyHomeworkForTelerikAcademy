USE [master]
GO
/****** Object:  Database [universities]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
CREATE DATABASE [universities]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'universities', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\universities.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'universities_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\universities_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [universities] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [universities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [universities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [universities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [universities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [universities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [universities] SET ARITHABORT OFF 
GO
ALTER DATABASE [universities] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [universities] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [universities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [universities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [universities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [universities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [universities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [universities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [universities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [universities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [universities] SET  DISABLE_BROKER 
GO
ALTER DATABASE [universities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [universities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [universities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [universities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [universities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [universities] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [universities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [universities] SET RECOVERY FULL 
GO
ALTER DATABASE [universities] SET  MULTI_USER 
GO
ALTER DATABASE [universities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [universities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [universities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [universities] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'universities', N'ON'
GO
USE [universities]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoursesList]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesList](
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Courses_List] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[FacultyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorTitles]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorTitles](
	[TitlesId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_Professor_Titles] PRIMARY KEY CLUSTERED 
(
	[TitlesId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CourseId] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 13.7.2013 г. 13:04:47 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[ProfessorTitleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[ProfessorTitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (1, N'C++ Programming', 1, 4)
INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (2, N'Databases', 1, 3)
INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (3, N'Pharalel Programming', 1, 2)
INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (4, N'Material Resistance', 2, 5)
INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (5, N'Signals and Systems', 2, 6)
INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (6, N'DVG', 5, 5)
INSERT [dbo].[Courses] ([CourseId], [Name], [DepartmentId], [ProfessorId]) VALUES (7, N'High Mathematics', 6, 1)
SET IDENTITY_INSERT [dbo].[Courses] OFF
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (1, 6)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (1, 7)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (2, 5)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (2, 9)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (3, 8)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (3, 14)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (3, 15)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (4, 2)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (5, 11)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (5, 13)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (6, 1)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (6, 10)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (7, 4)
INSERT [dbo].[CoursesList] ([CourseId], [StudentId]) VALUES (7, 12)
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (1, N'Computer Science', 1)
INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (2, N'Telecomunications', 2)
INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (3, N'Mobile Comunications', 2)
INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (4, N'Rail Transport', 4)
INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (5, N'Traffic Control', 4)
INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (6, N'Mathematics', 3)
INSERT [dbo].[Departments] ([DepartmentId], [Name], [FacultyId]) VALUES (7, N'Informatics', 3)
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([FacultyId], [Name]) VALUES (1, N'FKSU')
INSERT [dbo].[Faculties] ([FacultyId], [Name]) VALUES (2, N'FKT')
INSERT [dbo].[Faculties] ([FacultyId], [Name]) VALUES (3, N'FMI')
INSERT [dbo].[Faculties] ([FacultyId], [Name]) VALUES (4, N'TT')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Professors] ON 

INSERT [dbo].[Professors] ([ProfessorId], [FirstName], [LastName], [DepartmentId]) VALUES (1, NULL, N'Goceva', 1)
INSERT [dbo].[Professors] ([ProfessorId], [FirstName], [LastName], [DepartmentId]) VALUES (2, N'PLamenka', N'Borovska', 1)
INSERT [dbo].[Professors] ([ProfessorId], [FirstName], [LastName], [DepartmentId]) VALUES (3, NULL, N'Nakov', 1)
INSERT [dbo].[Professors] ([ProfessorId], [FirstName], [LastName], [DepartmentId]) VALUES (4, N'Milena', N'Lazarova', 1)
INSERT [dbo].[Professors] ([ProfessorId], [FirstName], [LastName], [DepartmentId]) VALUES (5, NULL, N'Damqnov', 4)
INSERT [dbo].[Professors] ([ProfessorId], [FirstName], [LastName], [DepartmentId]) VALUES (6, NULL, N'Toforov', 2)
SET IDENTITY_INSERT [dbo].[Professors] OFF
INSERT [dbo].[ProfessorTitles] ([TitlesId], [ProfessorId]) VALUES (1, 2)
INSERT [dbo].[ProfessorTitles] ([TitlesId], [ProfessorId]) VALUES (1, 3)
INSERT [dbo].[ProfessorTitles] ([TitlesId], [ProfessorId]) VALUES (3, 4)
INSERT [dbo].[ProfessorTitles] ([TitlesId], [ProfessorId]) VALUES (4, 5)
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (1, N'Pesho', N'Peshev', 6)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (2, N'Genadi', N'Gerov', 4)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (4, N'Sub', N'Zero', 7)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (5, N'Obi Wan', N'Kenobi', 2)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (6, N'Evlogi', N'Stamatov', 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (7, N'Mariq', N'Ivanova', 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (8, N'Krum', N'Bibishkov', 3)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (9, N'Spiridon', N'Spiridonov', 2)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (10, N'Bay', N'Georgi', 6)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (11, N'Chorban', N'Chorov', 5)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (12, N'Alex', N'Sashov', 7)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (13, N'Mitko', N'Mitkov', 5)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (14, N'Zlatina', N'Masheva', 3)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [CourseId]) VALUES (15, N'Mircho', N'Nemirchev', 3)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Titles] ON 

INSERT [dbo].[Titles] ([ProfessorTitleId], [Title]) VALUES (1, N'Ph. D')
INSERT [dbo].[Titles] ([ProfessorTitleId], [Title]) VALUES (2, N'Ph.')
INSERT [dbo].[Titles] ([ProfessorTitleId], [Title]) VALUES (3, N'Docent Doctor')
INSERT [dbo].[Titles] ([ProfessorTitleId], [Title]) VALUES (4, N'Assistant')
INSERT [dbo].[Titles] ([ProfessorTitleId], [Title]) VALUES (5, N'Doctor')
SET IDENTITY_INSERT [dbo].[Titles] OFF
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Professors]
GO
ALTER TABLE [dbo].[CoursesList]  WITH CHECK ADD  CONSTRAINT [FK_Courses_List_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CoursesList] CHECK CONSTRAINT [FK_Courses_List_Courses]
GO
ALTER TABLE [dbo].[CoursesList]  WITH CHECK ADD  CONSTRAINT [FK_Courses_List_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[CoursesList] CHECK CONSTRAINT [FK_Courses_List_Students]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([FacultyId])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Departments]
GO
ALTER TABLE [dbo].[ProfessorTitles]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Titles_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[ProfessorTitles] CHECK CONSTRAINT [FK_Professor_Titles_Professors]
GO
ALTER TABLE [dbo].[ProfessorTitles]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Titles_Titles] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Titles] ([ProfessorTitleId])
GO
ALTER TABLE [dbo].[ProfessorTitles] CHECK CONSTRAINT [FK_Professor_Titles_Titles]
GO
USE [master]
GO
ALTER DATABASE [universities] SET  READ_WRITE 
GO
