USE [produktdb]
GO

/****** Object:  Table [dbo].[Author]    Script Date: 11.07.2020 06:02:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Author](
	[AuthorName] [nchar](50) NULL,
	[AuthorVorname] [nchar](50) NULL,
	[Strasse] [nchar](50) NULL,
	[PLZ] [nchar](50) NULL,
	[Stadt] [nchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [produktdb]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 11.07.2020 06:03:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookTitle] [nchar](100) NULL,
	[BookPrice] [float] NULL,
	[AuthorId] [int] NULL,
	[BookVerlag] [nchar](100) NULL,
	[BookISDN] [nchar](100) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO