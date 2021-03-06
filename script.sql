USE [master]
GO
/****** Object:  Database [gill_rental_DB]    Script Date: 5/03/2020 10:35:31 pm ******/
CREATE DATABASE [gill_rental_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gill_rental_DB_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\gill_rental_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gill_rental_DB_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\gill_rental_DB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [gill_rental_DB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gill_rental_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gill_rental_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gill_rental_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gill_rental_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gill_rental_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gill_rental_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [gill_rental_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gill_rental_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gill_rental_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gill_rental_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gill_rental_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gill_rental_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gill_rental_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gill_rental_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gill_rental_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gill_rental_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gill_rental_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gill_rental_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gill_rental_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gill_rental_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gill_rental_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gill_rental_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gill_rental_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gill_rental_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gill_rental_DB] SET  MULTI_USER 
GO
ALTER DATABASE [gill_rental_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gill_rental_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gill_rental_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gill_rental_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gill_rental_DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'gill_rental_DB', N'ON'
GO
ALTER DATABASE [gill_rental_DB] SET QUERY_STORE = OFF
GO
USE [gill_rental_DB]
GO
/****** Object:  Schema [custdata]    Script Date: 5/03/2020 10:35:33 pm ******/
CREATE SCHEMA [custdata]
GO
/****** Object:  Table [dbo].[customer_data]    Script Date: 5/03/2020 10:35:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[mobile] [varchar](50) NULL,
	[address] [varchar](50) NULL,
 CONSTRAINT [PK_customer_data_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rental_data]    Script Date: 5/03/2020 10:35:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rental_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mov_id] [varchar](50) NULL,
	[csm_id] [varchar](50) NULL,
	[issue_date] [varchar](50) NULL,
	[return_date] [varchar](50) NULL,
 CONSTRAINT [PK_rental_data_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[video_data]    Script Date: 5/03/2020 10:35:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[video_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[points] [varchar](50) NULL,
	[year] [varchar](50) NULL,
	[copies] [varchar](50) NULL,
	[genre] [varchar](50) NULL,
 CONSTRAINT [PK_video_data_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer_data] ON 

INSERT [dbo].[customer_data] ([id], [name], [email], [mobile], [address]) VALUES (1, N'asas', N'as', N'123', N'asd')
SET IDENTITY_INSERT [dbo].[customer_data] OFF
SET IDENTITY_INSERT [dbo].[rental_data] ON 

INSERT [dbo].[rental_data] ([id], [mov_id], [csm_id], [issue_date], [return_date]) VALUES (1, N'1', N'1', N'12/18/2019', N'booked')
INSERT [dbo].[rental_data] ([id], [mov_id], [csm_id], [issue_date], [return_date]) VALUES (2, N'1', N'1', N'12/18/2019', N'12/18/2019')
INSERT [dbo].[rental_data] ([id], [mov_id], [csm_id], [issue_date], [return_date]) VALUES (3, N'1', N'1', N'3/03/2020', N'3/03/2020')
INSERT [dbo].[rental_data] ([id], [mov_id], [csm_id], [issue_date], [return_date]) VALUES (4, N'1', N'1', N'5/03/2020', N'5/03/2020')
SET IDENTITY_INSERT [dbo].[rental_data] OFF
SET IDENTITY_INSERT [dbo].[video_data] ON 

INSERT [dbo].[video_data] ([id], [name], [points], [year], [copies], [genre]) VALUES (1, N'good news', N'3.5', N'2019', N'3', N'good')
INSERT [dbo].[video_data] ([id], [name], [points], [year], [copies], [genre]) VALUES (2, N'ook', N'4', N'2018', N'3', N'ok')
SET IDENTITY_INSERT [dbo].[video_data] OFF
USE [master]
GO
ALTER DATABASE [gill_rental_DB] SET  READ_WRITE 
GO
