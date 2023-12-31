USE [Personen]
GO
/****** Object:  Table [dbo].[Personen]    Script Date: 12/12/2022 13:54:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [text] NOT NULL,
	[Email] [text] NULL,
	[Geboortedatum] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Personen] ON 

INSERT [dbo].[Personen] ([Id], [Naam], [Email], [Geboortedatum]) VALUES (1, N'Jan', N'jan@hotmail.com', CAST(N'2001-01-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Personen] ([Id], [Naam], [Email], [Geboortedatum]) VALUES (2, N'Pol', N'pol@gmail.com', CAST(N'2002-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Personen] ([Id], [Naam], [Email], [Geboortedatum]) VALUES (3, N'Piet', N'piet@hotmail.com', CAST(N'2002-02-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Personen] OFF
GO
