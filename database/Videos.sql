USE [Videos]
GO

/****** Object:  Table [dbo].[Videos]    Script Date: 9/24/2020 20:16:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Videos](
	[id_video] [int] IDENTITY(1,1) NOT NULL,
	[casette] [int] NOT NULL,
	[contenido] [text] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[duracion] [time](7) NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[id_video] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Casette] FOREIGN KEY([casette])
REFERENCES [dbo].[Casettes] ([id_casette])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Casette]
GO


