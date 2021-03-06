USE [master]
GO
/****** Object:  Database [LiveJourneysDb]    Script Date: 3/10/2018 11:09:21 AM ******/
CREATE DATABASE [LiveJourneysDb]


IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LiveJourneysDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LiveJourneysDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LiveJourneysDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LiveJourneysDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LiveJourneysDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LiveJourneysDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LiveJourneysDb] SET  MULTI_USER 
GO
ALTER DATABASE [LiveJourneysDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LiveJourneysDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LiveJourneysDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LiveJourneysDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LiveJourneysDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LiveJourneysDb', N'ON'
GO
ALTER DATABASE [LiveJourneysDb] SET QUERY_STORE = OFF
GO
USE [LiveJourneysDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [LiveJourneysDb]
GO
/****** Object:  Table [dbo].[Line]    Script Date: 3/10/2018 11:09:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Line](
	[LineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Line] PRIMARY KEY CLUSTERED 
(
	[LineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Station]    Script Date: 3/10/2018 11:09:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Station](
	[StationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED 
(
	[StationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StationLine]    Script Date: 3/10/2018 11:09:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StationLine](
	[LineId] [int] NOT NULL,
	[StationId] [int] NOT NULL,
	[OrderNumber] [int] NOT NULL,
 CONSTRAINT [PK_StationLine] PRIMARY KEY CLUSTERED 
(
	[LineId] ASC,
	[StationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StationMapping]    Script Date: 3/10/2018 11:09:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StationMapping](
	[FromStaionId] [int] NOT NULL,
	[ToStationId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[Distance] [float] NOT NULL,
	[IsDeleay] [bit] NULL,
 CONSTRAINT [PK_StationMapping] PRIMARY KEY CLUSTERED 
(
	[FromStaionId] ASC,
	[ToStationId] ASC,
	[LineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/10/2018 11:09:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 3/10/2018 11:09:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StationMapping] ADD  CONSTRAINT [DF_StationMapping_isDeleay]  DEFAULT ((0)) FOR [isDeleay]
GO
ALTER TABLE [dbo].[StationLine]  WITH CHECK ADD  CONSTRAINT [FK_StationLine_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
GO
ALTER TABLE [dbo].[StationLine] CHECK CONSTRAINT [FK_StationLine_Line]
GO
ALTER TABLE [dbo].[StationLine]  WITH CHECK ADD  CONSTRAINT [FK_StationLine_Station] FOREIGN KEY([StationId])
REFERENCES [dbo].[Station] ([StationId])
GO
ALTER TABLE [dbo].[StationLine] CHECK CONSTRAINT [FK_StationLine_Station]
GO
ALTER TABLE [dbo].[StationMapping]  WITH CHECK ADD  CONSTRAINT [FK_StationMapping_FromStation] FOREIGN KEY([FromStaionId])
REFERENCES [dbo].[Station] ([StationId])
GO
ALTER TABLE [dbo].[StationMapping] CHECK CONSTRAINT [FK_StationMapping_FromStation]
GO
ALTER TABLE [dbo].[StationMapping]  WITH CHECK ADD  CONSTRAINT [FK_StationMapping_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
GO
ALTER TABLE [dbo].[StationMapping] CHECK CONSTRAINT [FK_StationMapping_Line]
GO
ALTER TABLE [dbo].[StationMapping]  WITH CHECK ADD  CONSTRAINT [FK_StationMapping_ToStation] FOREIGN KEY([ToStationId])
REFERENCES [dbo].[Station] ([StationId])
GO
ALTER TABLE [dbo].[StationMapping] CHECK CONSTRAINT [FK_StationMapping_ToStation]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[UserType] ([UserTypeId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
USE [master]
GO
ALTER DATABASE [LiveJourneysDb] SET  READ_WRITE 
GO
