USE [master]
GO
/****** Object:  Database [kafe]    Script Date: 8.05.2020 02:24:42 ******/
CREATE DATABASE [kafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\kafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\kafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [kafe] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [kafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kafe] SET RECOVERY FULL 
GO
ALTER DATABASE [kafe] SET  MULTI_USER 
GO
ALTER DATABASE [kafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kafe] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'kafe', N'ON'
GO
ALTER DATABASE [kafe] SET QUERY_STORE = OFF
GO
USE [kafe]
GO
/****** Object:  Table [dbo].[kullanici]    Script Date: 8.05.2020 02:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici](
	[kullaniciadi] [varchar](20) NOT NULL,
	[sifre] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 8.05.2020 02:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[urunad] [varchar](50) NOT NULL,
	[fiyat] [int] NOT NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musteri]    Script Date: 8.05.2020 02:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteri](
	[ID] [int] NOT NULL,
	[musteriad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_musteri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[siparis]    Script Date: 8.05.2020 02:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[siparis](
	[siparisID] [int] IDENTITY(1,1) NOT NULL,
	[musteriID] [int] NOT NULL,
	[siparistutar] [int] NOT NULL,
	[urunistek] [varchar](50) NOT NULL,
	[adet] [int] NOT NULL,
	[menuID] [int] NOT NULL,
 CONSTRAINT [PK_siparis] PRIMARY KEY CLUSTERED 
(
	[siparisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[kullanici] ([kullaniciadi], [sifre]) VALUES (N'admin', N'123456')
GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (1, N'Cafe Latte', 10)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (2, N'Espresso', 10)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (3, N'Americano', 12)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (4, N'Mochiato', 14)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (5, N'Filtre Kahve', 11)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (7, N'Mocha', 15)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (9, N'Arabica', 13)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (10, N'Liberica', 13)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (11, N'Frappe', 16)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (12, N'Robusta', 15)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (13, N'Flat White', 14)
INSERT [dbo].[menu] ([ID], [urunad], [fiyat]) VALUES (14, N'Waffle', 15)
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
ALTER TABLE [dbo].[siparis]  WITH CHECK ADD  CONSTRAINT [FK_siparis_menu] FOREIGN KEY([menuID])
REFERENCES [dbo].[menu] ([ID])
GO
ALTER TABLE [dbo].[siparis] CHECK CONSTRAINT [FK_siparis_menu]
GO
USE [master]
GO
ALTER DATABASE [kafe] SET  READ_WRITE 
GO
