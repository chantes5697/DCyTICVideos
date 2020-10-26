USE [Videos]
GO

/****** Object:  Table [dbo].[Filtro]    Script Date: 9/24/2020 20:16:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Filtro](
	[id_filtro] [int] IDENTITY(1,1) NOT NULL,
	[contenido] [text] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[duracion] [time](7) NOT NULL,
	[videos] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Filtro]  WITH CHECK ADD  CONSTRAINT [FK_Filtro_Videos] FOREIGN KEY([videos])
REFERENCES [dbo].[Videos] ([id_video])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Filtro] CHECK CONSTRAINT [FK_Filtro_Videos]
GO


