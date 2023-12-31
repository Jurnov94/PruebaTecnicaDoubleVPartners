/****** Object:  Database [PruebaTecnicaDoubleVPartners]    Script Date: 13/11/2023 12:42:29 p. m. ******/
CREATE DATABASE [PruebaTecnicaDoubleVPartners]
GO
USE [PruebaTecnicaDoubleVPartners]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 13/11/2023 12:42:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[TipoIdentificacion] [varchar](30) NOT NULL,
	[NumeroIdentificacion] [int] NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/11/2023 12:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [uniqueidentifier] NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Persona] ([Id], [Nombres], [Apellidos], [TipoIdentificacion], [NumeroIdentificacion], [Email], [FechaCreacion]) VALUES (N'5a6c298e-be91-488e-8a02-b121b5ec43b9', N'Carolina', N'Granados', N'Tarjata de Identidad', 741258, N'caro@yopmail.com', CAST(N'2023-11-13T12:28:43.773' AS DateTime))
GO
INSERT [dbo].[Usuario] ([Id], [NombreUsuario], [Password], [FechaCreacion]) VALUES (N'f5e9c3ac-8d16-40c3-a5c0-07162742cfe7', N'Julian', N'123456', CAST(N'2023-11-12T21:55:09.633' AS DateTime))
INSERT [dbo].[Usuario] ([Id], [NombreUsuario], [Password], [FechaCreacion]) VALUES (N'9edcdf3d-770f-4400-a4c6-07a79b828fae', N'Velasco', N'123456', CAST(N'2023-11-13T08:46:51.827' AS DateTime))
GO
USE [master]
GO
ALTER DATABASE [PruebaTecnicaDoubleVPartners] SET  READ_WRITE 
GO
