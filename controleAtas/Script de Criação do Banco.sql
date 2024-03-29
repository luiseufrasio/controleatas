SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cores]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Cores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[login] [varchar](20) NOT NULL,
	[senha] [varchar](10) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[admin] [bit] NOT NULL CONSTRAINT [DF_Usuarios_admin]  DEFAULT ((0)),
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Atas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Atas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[texto] [ntext] NOT NULL,
	[idReuniao] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idCor] [int] NOT NULL,
	[dataHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Atas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reunioes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reunioes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[assunto] [varchar](100) NOT NULL,
	[dataHora] [datetime] NOT NULL,
	[local] [varchar](50) NULL,
	[idCriador] [int] NOT NULL,
	[excluida] [bit] NOT NULL CONSTRAINT [DF_Reunioes_excluida]  DEFAULT ((0)),
 CONSTRAINT [PK_Reunioes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Participantes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Participantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idReuniao] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Participantes_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atas_Cores]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atas]'))
ALTER TABLE [dbo].[Atas]  WITH CHECK ADD  CONSTRAINT [FK_Atas_Cores] FOREIGN KEY([idCor])
REFERENCES [dbo].[Cores] ([id])
GO
ALTER TABLE [dbo].[Atas] CHECK CONSTRAINT [FK_Atas_Cores]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atas_Reunioes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atas]'))
ALTER TABLE [dbo].[Atas]  WITH CHECK ADD  CONSTRAINT [FK_Atas_Reunioes] FOREIGN KEY([idReuniao])
REFERENCES [dbo].[Reunioes] ([id])
GO
ALTER TABLE [dbo].[Atas] CHECK CONSTRAINT [FK_Atas_Reunioes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atas_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atas]'))
ALTER TABLE [dbo].[Atas]  WITH CHECK ADD  CONSTRAINT [FK_Atas_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Atas] CHECK CONSTRAINT [FK_Atas_Usuarios]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reunioes_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reunioes]'))
ALTER TABLE [dbo].[Reunioes]  WITH CHECK ADD  CONSTRAINT [FK_Reunioes_Usuarios] FOREIGN KEY([idCriador])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Reunioes] CHECK CONSTRAINT [FK_Reunioes_Usuarios]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Participantes_Reunioes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Participantes]'))
ALTER TABLE [dbo].[Participantes]  WITH CHECK ADD  CONSTRAINT [FK_Participantes_Reunioes] FOREIGN KEY([idReuniao])
REFERENCES [dbo].[Reunioes] ([id])
GO
ALTER TABLE [dbo].[Participantes] CHECK CONSTRAINT [FK_Participantes_Reunioes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Participantes_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Participantes]'))
ALTER TABLE [dbo].[Participantes]  WITH CHECK ADD  CONSTRAINT [FK_Participantes_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Participantes] CHECK CONSTRAINT [FK_Participantes_Usuarios]
