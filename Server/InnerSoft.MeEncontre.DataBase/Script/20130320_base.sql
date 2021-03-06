SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[Descricao] [nvarchar](max) NULL,
	[StatusUsuario] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermissaoLocalColaborador]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PermissaoLocalColaborador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Colaborador_Id] [int] NOT NULL,
	[Local_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PermissaoLocalColaborador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Acesso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Acesso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocalKey] [nvarchar](max) NULL,
	[ColaboradorKey] [nvarchar](max) NULL,
	[Data] [datetime] NOT NULL,
	[Movimento] [nvarchar](max) NULL,
	[Cliente_Id] [int] NULL,
	[Colaborador_Id] [int] NOT NULL,
	[Local_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Acesso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Colaborador]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Colaborador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [nvarchar](max) NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Foto] [nvarchar](max) NULL,
	[Key] [nvarchar](max) NULL,
	[UltimoAcesso] [datetime] NULL,
	[Status_Id] [int] NULL,
	[Cliente_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Colaborador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Local]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Key] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[Latitude] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NULL,
	[UltimoiLive] [datetime] NULL,
	[UltimoInicializacao] [datetime] NULL,
	[Status_Id] [int] NULL,
	[Cliente_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Local] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[Nome] [nvarchar](max) NULL,
	[Status_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.PermissaoLocalColaborador_dbo.Colaborador_Colaborador_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermissaoLocalColaborador]'))
ALTER TABLE [dbo].[PermissaoLocalColaborador]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PermissaoLocalColaborador_dbo.Colaborador_Colaborador_Id] FOREIGN KEY([Colaborador_Id])
REFERENCES [dbo].[Colaborador] ([Id])
GO
ALTER TABLE [dbo].[PermissaoLocalColaborador] CHECK CONSTRAINT [FK_dbo.PermissaoLocalColaborador_dbo.Colaborador_Colaborador_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.PermissaoLocalColaborador_dbo.Local_Local_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermissaoLocalColaborador]'))
ALTER TABLE [dbo].[PermissaoLocalColaborador]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PermissaoLocalColaborador_dbo.Local_Local_Id] FOREIGN KEY([Local_Id])
REFERENCES [dbo].[Local] ([Id])
GO
ALTER TABLE [dbo].[PermissaoLocalColaborador] CHECK CONSTRAINT [FK_dbo.PermissaoLocalColaborador_dbo.Local_Local_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Acesso_dbo.Cliente_Cliente_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acesso]'))
ALTER TABLE [dbo].[Acesso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Acesso_dbo.Cliente_Cliente_Id] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Acesso] CHECK CONSTRAINT [FK_dbo.Acesso_dbo.Cliente_Cliente_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Acesso_dbo.Colaborador_Colaborador_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acesso]'))
ALTER TABLE [dbo].[Acesso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Acesso_dbo.Colaborador_Colaborador_Id] FOREIGN KEY([Colaborador_Id])
REFERENCES [dbo].[Colaborador] ([Id])
GO
ALTER TABLE [dbo].[Acesso] CHECK CONSTRAINT [FK_dbo.Acesso_dbo.Colaborador_Colaborador_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Acesso_dbo.Local_Local_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acesso]'))
ALTER TABLE [dbo].[Acesso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Acesso_dbo.Local_Local_Id] FOREIGN KEY([Local_Id])
REFERENCES [dbo].[Local] ([Id])
GO
ALTER TABLE [dbo].[Acesso] CHECK CONSTRAINT [FK_dbo.Acesso_dbo.Local_Local_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Colaborador_dbo.Cliente_Cliente_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Colaborador]'))
ALTER TABLE [dbo].[Colaborador]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Colaborador_dbo.Cliente_Cliente_Id] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Colaborador] CHECK CONSTRAINT [FK_dbo.Colaborador_dbo.Cliente_Cliente_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Colaborador_dbo.Status_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Colaborador]'))
ALTER TABLE [dbo].[Colaborador]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Colaborador_dbo.Status_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Colaborador] CHECK CONSTRAINT [FK_dbo.Colaborador_dbo.Status_Status_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Local_dbo.Cliente_Cliente_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Local]'))
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Local_dbo.Cliente_Cliente_Id] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_dbo.Local_dbo.Cliente_Cliente_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Local_dbo.Status_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Local]'))
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Local_dbo.Status_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_dbo.Local_dbo.Status_Status_Id]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Cliente_dbo.Status_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cliente]'))
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.Status_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.Status_Status_Id]
