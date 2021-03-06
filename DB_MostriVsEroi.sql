USE [master]
GO
/****** Object:  Database [Demo8]    Script Date: 03/09/2021 14:54:44 ******/
CREATE DATABASE [Demo8]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Demo8', FILENAME = N'E:\Week8.ProvaFinale-master\MostriVsEroi.DbRepository\Demo8.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Demo8_log', FILENAME = N'E:\Week8.ProvaFinale-master\MostriVsEroi.DbRepository\Demo8_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Demo8] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Demo8].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Demo8] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Demo8] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Demo8] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Demo8] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Demo8] SET ARITHABORT OFF 
GO
ALTER DATABASE [Demo8] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Demo8] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Demo8] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Demo8] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Demo8] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Demo8] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Demo8] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Demo8] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Demo8] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Demo8] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Demo8] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Demo8] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Demo8] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Demo8] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Demo8] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Demo8] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Demo8] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Demo8] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Demo8] SET  MULTI_USER 
GO
ALTER DATABASE [Demo8] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Demo8] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Demo8] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Demo8] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Demo8] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Demo8] SET QUERY_STORE = OFF
GO
USE [Demo8]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Demo8]
GO
/****** Object:  Table [dbo].[Classe]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classe](
	[Name] [nvarchar](30) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo] [int] NULL,
 CONSTRAINT [PK_Classe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[Nome] [nvarchar](30) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[IdClasse] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[Nome] [nvarchar](30) NOT NULL,
	[IdClasse] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdGiocatore] [int] NOT NULL,
	[PuntiAccumulati] [int] NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livello_PuntiVita]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livello_PuntiVita](
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_Livello_PuntiVIta] PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EroiConProprieta]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[EroiConProprieta]
AS
SELECT        dbo.Eroe.IdGiocatore, dbo.Eroe.Nome, dbo.Eroe.Id, dbo.Eroe.PuntiAccumulati, dbo.Classe.Name AS Classe, dbo.Arma.Nome AS ArmaNome, dbo.Arma.PuntiDanno, dbo.Livello_PuntiVita.Livello, 
                         dbo.Livello_PuntiVita.PuntiVita
FROM            dbo.Eroe INNER JOIN
                         dbo.Classe ON dbo.Eroe.IdClasse = dbo.Classe.Id INNER JOIN
                         dbo.Arma ON dbo.Eroe.IdArma = dbo.Arma.Id INNER JOIN
                         dbo.Livello_PuntiVita ON dbo.Eroe.Livello = dbo.Livello_PuntiVita.Livello
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[Nome] [nvarchar](30) NOT NULL,
	[IdClasse] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MostriConProprieta]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MostriConProprieta] as
select Mostro.Nome, Classe.Name as Classe, Arma.nome as ArmaNome, Arma.PuntiDanno as PuntiDanno, Livello_PuntiVita.Livello, Livello_PuntiVita.PuntiVita
from Mostro
inner join Classe on Mostro.IdClasse = Classe.Id
inner join Arma on Mostro.IdArma = Arma.Id
inner join Livello_PuntiVita on Mostro.Livello = Livello_PuntiVita.Livello
GO
/****** Object:  Table [dbo].[Giocatore]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giocatore](
	[Nome] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Giocatore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livello_PuntiAccumulati]    Script Date: 03/09/2021 14:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livello_PuntiAccumulati](
	[Livello] [int] NOT NULL,
	[PuntiAccumulati] [int] NOT NULL,
 CONSTRAINT [PK_Livello_PuntiAccumulati] PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Alabarda', 15, 1, 1)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Ascia', 8, 1, 2)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Mazza', 5, 1, 3)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Spada', 10, 1, 4)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Spadone', 15, 1, 5)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Arco e frecce', 8, 2, 7)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Bacchetta', 5, 2, 9)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Bastone magico', 10, 2, 10)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Onda d''urto', 15, 2, 11)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Pugnali', 5, 2, 12)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Discorso Noioso', 4, 3, 13)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Farneticazione', 7, 3, 14)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Imprecazione', 5, 3, 15)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Magia nera', 3, 3, 16)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Arco', 7, 4, 17)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Clava', 5, 4, 18)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Spada rotta', 3, 4, 19)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Mazza chiodata', 10, 4, 20)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Alabarda del drago', 30, 5, 21)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Divinazione', 15, 5, 22)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Fulmine', 10, 5, 23)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Fulmine celeste', 15, 5, 24)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Tempesta', 8, 5, 25)
INSERT [dbo].[Arma] ([Nome], [PuntiDanno], [IdClasse], [Id]) VALUES (N'Tempesta oscura', 15, 5, 26)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Classe] ON 

INSERT [dbo].[Classe] ([Name], [Id], [IdTipo]) VALUES (N'Guerriero', 1, 1)
INSERT [dbo].[Classe] ([Name], [Id], [IdTipo]) VALUES (N'Mago', 2, 1)
INSERT [dbo].[Classe] ([Name], [Id], [IdTipo]) VALUES (N'Cultista', 3, 2)
INSERT [dbo].[Classe] ([Name], [Id], [IdTipo]) VALUES (N'Orco', 4, 2)
INSERT [dbo].[Classe] ([Name], [Id], [IdTipo]) VALUES (N'SignoreDelMale', 5, 2)
SET IDENTITY_INSERT [dbo].[Classe] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([Nome], [IdClasse], [IdArma], [Livello], [Id], [IdGiocatore], [PuntiAccumulati]) VALUES (N'Il mio primo eroe', 1, 3, 1, 5, 1, 0)
INSERT [dbo].[Eroe] ([Nome], [IdClasse], [IdArma], [Livello], [Id], [IdGiocatore], [PuntiAccumulati]) VALUES (N'IlMioSecondoEroe', 1, 5, 4, 6, 1, 60)
INSERT [dbo].[Eroe] ([Nome], [IdClasse], [IdArma], [Livello], [Id], [IdGiocatore], [PuntiAccumulati]) VALUES (N'Eroe', 2, 11, 1, 1004, 3, 0)
INSERT [dbo].[Eroe] ([Nome], [IdClasse], [IdArma], [Livello], [Id], [IdGiocatore], [PuntiAccumulati]) VALUES (N'mio eroe', 2, 12, 1, 1005, 1, 0)
INSERT [dbo].[Eroe] ([Nome], [IdClasse], [IdArma], [Livello], [Id], [IdGiocatore], [PuntiAccumulati]) VALUES (N'eroe forte', 2, 12, 1, 1008, 4, 0)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Giocatore] ON 

INSERT [dbo].[Giocatore] ([Nome], [Password], [IsAdmin], [Id]) VALUES (N'Arianna', N'1234', 1, 1)
INSERT [dbo].[Giocatore] ([Nome], [Password], [IsAdmin], [Id]) VALUES (N'Ari', N'prova', 0, 3)
INSERT [dbo].[Giocatore] ([Nome], [Password], [IsAdmin], [Id]) VALUES (N'michi95', N'abc123', 0, 4)
SET IDENTITY_INSERT [dbo].[Giocatore] OFF
GO
INSERT [dbo].[Livello_PuntiAccumulati] ([Livello], [PuntiAccumulati]) VALUES (1, 0)
INSERT [dbo].[Livello_PuntiAccumulati] ([Livello], [PuntiAccumulati]) VALUES (2, 30)
INSERT [dbo].[Livello_PuntiAccumulati] ([Livello], [PuntiAccumulati]) VALUES (3, 60)
INSERT [dbo].[Livello_PuntiAccumulati] ([Livello], [PuntiAccumulati]) VALUES (4, 90)
INSERT [dbo].[Livello_PuntiAccumulati] ([Livello], [PuntiAccumulati]) VALUES (5, 120)
GO
INSERT [dbo].[Livello_PuntiVita] ([Livello], [PuntiVita]) VALUES (1, 20)
INSERT [dbo].[Livello_PuntiVita] ([Livello], [PuntiVita]) VALUES (2, 40)
INSERT [dbo].[Livello_PuntiVita] ([Livello], [PuntiVita]) VALUES (3, 60)
INSERT [dbo].[Livello_PuntiVita] ([Livello], [PuntiVita]) VALUES (4, 80)
INSERT [dbo].[Livello_PuntiVita] ([Livello], [PuntiVita]) VALUES (5, 100)
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([Nome], [IdClasse], [IdArma], [Livello], [Id]) VALUES (N'Primo mostro', 3, 14, 1, 1)
INSERT [dbo].[Mostro] ([Nome], [IdClasse], [IdArma], [Livello], [Id]) VALUES (N'MostroBrutto', 5, 26, 2, 2)
INSERT [dbo].[Mostro] ([Nome], [IdClasse], [IdArma], [Livello], [Id]) VALUES (N'Mostro forte', 4, 17, 3, 3)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD  CONSTRAINT [FK_Arma_Classe] FOREIGN KEY([IdClasse])
REFERENCES [dbo].[Classe] ([Id])
GO
ALTER TABLE [dbo].[Arma] CHECK CONSTRAINT [FK_Arma_Classe]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Arma]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Classe] FOREIGN KEY([IdClasse])
REFERENCES [dbo].[Classe] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Classe]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Giocatore] FOREIGN KEY([IdGiocatore])
REFERENCES [dbo].[Giocatore] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Giocatore]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Livello_PuntiAccumulati] FOREIGN KEY([Livello])
REFERENCES [dbo].[Livello_PuntiAccumulati] ([Livello])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Livello_PuntiAccumulati]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Livello_PuntiVIta] FOREIGN KEY([Livello])
REFERENCES [dbo].[Livello_PuntiVita] ([Livello])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Livello_PuntiVIta]
GO
ALTER TABLE [dbo].[Livello_PuntiVita]  WITH CHECK ADD  CONSTRAINT [FK_Livello_PuntiVIta_Livello_PuntiAccumulati] FOREIGN KEY([Livello])
REFERENCES [dbo].[Livello_PuntiAccumulati] ([Livello])
GO
ALTER TABLE [dbo].[Livello_PuntiVita] CHECK CONSTRAINT [FK_Livello_PuntiVIta_Livello_PuntiAccumulati]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([Id])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Arma]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Classe] FOREIGN KEY([IdClasse])
REFERENCES [dbo].[Classe] ([Id])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Classe]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Livello_PuntiVIta] FOREIGN KEY([Livello])
REFERENCES [dbo].[Livello_PuntiVita] ([Livello])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Livello_PuntiVIta]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Classe"
            Begin Extent = 
               Top = 6
               Left = 254
               Bottom = 119
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Arma"
            Begin Extent = 
               Top = 120
               Left = 254
               Bottom = 250
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Livello_PuntiVita"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 234
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Eroe"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiConProprieta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiConProprieta'
GO
USE [master]
GO
ALTER DATABASE [Demo8] SET  READ_WRITE 
GO
