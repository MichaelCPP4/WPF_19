USE [master]
GO
/****** Object:  Database [bd18]    Script Date: 02.05.2023 12:06:26 ******/
CREATE DATABASE [bd18]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bd18', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bd18.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'bd18_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bd18_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [bd18] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bd18].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bd18] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bd18] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bd18] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bd18] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bd18] SET ARITHABORT OFF 
GO
ALTER DATABASE [bd18] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bd18] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bd18] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bd18] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bd18] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bd18] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bd18] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bd18] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bd18] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bd18] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bd18] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bd18] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bd18] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bd18] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bd18] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bd18] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bd18] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bd18] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bd18] SET  MULTI_USER 
GO
ALTER DATABASE [bd18] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bd18] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bd18] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bd18] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [bd18] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bd18] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [bd18] SET QUERY_STORE = OFF
GO
USE [bd18]
GO
/****** Object:  Table [dbo].[Accounting]    Script Date: 02.05.2023 12:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounting](
	[ID] [int] NOT NULL,
	[Surname] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[ThirdName] [nvarchar](20) NULL,
	[MondayDetailsNumber] [int] NULL,
	[ToesdayDetailsNumber] [int] NULL,
	[WednesdayDetailsNumber] [int] NULL,
	[ThursdayDetailsNumber] [int] NULL,
	[FridayDetailsNumber] [int] NULL,
	[Workshop] [nvarchar](20) NULL,
	[Product] [nvarchar](20) NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Accounting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 02.05.2023 12:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[UserID] [int] NOT NULL,
	[USerSurname] [nvarchar](15) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[UserPatronymic] [nvarchar](15) NOT NULL,
	[UserLogin] [nvarchar](20) NOT NULL,
	[UserPassword] [nvarchar](30) NOT NULL,
	[UserRole] [nvarchar](5) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02.05.2023 12:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](5) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (1, N'Сидоров', N'Иван', N'Андреевич', 64, 123, 213, 123, 213, N'Конвеерный', N'Микросхема', 4999)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (2, N'Петров', N'Глеб', N'Иванович', 108, 50, 14, 43, 57, N'Конвеерный', N'Электромагнит', 480)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (3, N'Кузнецов', N'Иван', NULL, 135, 88, 156, 217, 40, N'Литейный', N'Каркас', 6392)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (4, N'Потапова', N'Анна', N'Владиславна', 115, 50, 34, 41, 21, N'Конвеерный', N'Руль', 999)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (5, N'Васильев', N'Артём', N'Платонович', 45, 78, 14, 77, 66, N'Сборочный', N'Мороженное', 12)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (6, N'Куликова', N'Вероника', N'Данииловна', 67, 90, 44, 10, 88, N'Сборочный', N'Мороженное', 12)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (7, N'Павловна', N'Вера', N'Ивановна', 45, 33, 124, 67, 87, N'Литейный', N'Алюминий', 345)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (8, N'Федотов', N'Марк', N'Олегович', 12, 66, 58, 16, 99, N'Литейный', N'Сталь', 1500)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (9, N'Клюев', N'Владимир', N'Михайлович', 55, 98, 42, 29, 73, N'Сборочный', N'Диван', 21000)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (10, N'Орлов', N'Денис', N'Владимирович', 71, 45, 88, 36, 53, N'Сборочный', N'Стул', 2200)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (11, N'Козлова', N'Ульяна', N'Марковна', 26, 18, 49, 61, 35, N'Конвееный', N'Диск для колеса', 1300)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (12, N'Морозов', N'Георгий', N'Львович', 46, 38, 81, 42, 51, N'Сборочный', N'Колесо', 2600)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (13, N'Абрамова', N'Мира', N'Ярославна', 55, 26, 71, 44, 51, N'Сборочный', N'Коробка передач', 5000)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (14, N'Власовна', N'Елизавета', N'Ивановна', 67, 13, 58, 41, 73, N'Конвеерный', N'Рама автомобиля', 7200)
INSERT [dbo].[Accounting] ([ID], [Surname], [Name], [ThirdName], [MondayDetailsNumber], [ToesdayDetailsNumber], [WednesdayDetailsNumber], [ThursdayDetailsNumber], [FridayDetailsNumber], [Workshop], [Product], [Price]) VALUES (15, N'Герасимов', N'Алексей', N'Александрович', 53, 28, 63, 38, 49, N'Литейный', N'Подшибники', 23)
GO
INSERT [dbo].[Authorization] ([UserID], [USerSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (1, N'1', N'1', N'1', N'admin', N'admin', N'admin')
INSERT [dbo].[Authorization] ([UserID], [USerSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (2, N'2', N'2', N'2', N'user', N'user', N'user')
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'user')
GO
USE [master]
GO
ALTER DATABASE [bd18] SET  READ_WRITE 
GO
