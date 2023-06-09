USE [master]
GO
/****** Object:  Database [LenaSoftwareDb]    Script Date: 27.04.2023 01:46:58 ******/
CREATE DATABASE [LenaSoftwareDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LenaSoftwareDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LenaSoftwareDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LenaSoftwareDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LenaSoftwareDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LenaSoftwareDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LenaSoftwareDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LenaSoftwareDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LenaSoftwareDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LenaSoftwareDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LenaSoftwareDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LenaSoftwareDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LenaSoftwareDb] SET  MULTI_USER 
GO
ALTER DATABASE [LenaSoftwareDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LenaSoftwareDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LenaSoftwareDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LenaSoftwareDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LenaSoftwareDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LenaSoftwareDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LenaSoftwareDb', N'ON'
GO
ALTER DATABASE [LenaSoftwareDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [LenaSoftwareDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LenaSoftwareDb]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 27.04.2023 01:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Age] [int] NULL,
	[FormId] [int] NOT NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 27.04.2023 01:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.04.2023 01:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](20) NULL,
	[FullName] [nvarchar](70) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fields]  WITH CHECK ADD  CONSTRAINT [FK_Fields_Forms] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([Id])
GO
ALTER TABLE [dbo].[Fields] CHECK CONSTRAINT [FK_Fields_Forms]
GO
ALTER TABLE [dbo].[Forms]  WITH CHECK ADD  CONSTRAINT [FK_Forms_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Forms] CHECK CONSTRAINT [FK_Forms_Users]
GO
USE [master]
GO
ALTER DATABASE [LenaSoftwareDb] SET  READ_WRITE 
GO
