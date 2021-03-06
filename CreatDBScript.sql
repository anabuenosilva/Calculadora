USE [CalculadoraSka]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/01/2021 20:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculoHistorico]    Script Date: 26/01/2021 20:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculoHistorico](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DataCriacao] [datetime2](7) NULL,
	[ValorPrimario] [decimal](18, 2) NULL,
	[Operacao] [int] NULL,
	[ValorSecundario] [decimal](18, 2) NULL,
	[Resultado] [decimal](18, 2) NULL,
	[Usuario] [nvarchar](max) NULL,
	[Calculo] [nvarchar](max) NULL,
 CONSTRAINT [PK_CalculoHistorico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
