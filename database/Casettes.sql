USE [Videos]
GO

/****** Object:  Table [dbo].[Casettes]    Script Date: 9/24/2020 20:15:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Casettes](
	[id_casette] [int] IDENTITY(1,1) NOT NULL,
	[clave] [text] NOT NULL,
	[estado] [int] NOT NULL,
	[formato] [int] NOT NULL,
 CONSTRAINT [PK_Casettes] PRIMARY KEY NONCLUSTERED 
(
	[id_casette] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Casettes]  WITH CHECK ADD  CONSTRAINT [FK_Casettes_Formato] FOREIGN KEY([formato])
REFERENCES [dbo].[Formato] ([id_formato])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Casettes] CHECK CONSTRAINT [FK_Casettes_Formato]
GO


