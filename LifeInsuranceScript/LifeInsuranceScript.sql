USE [LifeInsuranceDb]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 09-Oct-20 5:19:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NOT NULL,
	[CustomerAddress] [nvarchar](200) NOT NULL,
	[CustomerGender] [nvarchar](10) NOT NULL,
	[CustomerCountry] [nvarchar](100) NOT NULL,
	[DateofBirth] [datetime] NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[CoveragePlan] [nvarchar](100) NOT NULL,
	[NetPrice] [decimal](18, 0) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoveragePlans]    Script Date: 09-Oct-20 5:19:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoveragePlans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoveragePlan] [nvarchar](100) NOT NULL,
	[EligibilityDateFrom] [datetime] NOT NULL,
	[EligibilityDateTo] [datetime] NOT NULL,
	[EligibilityCountry] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Modifieddate] [datetime] NULL,
	[Isdeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CoveragePlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RateChart]    Script Date: 09-Oct-20 5:19:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateChart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoveragePlansId] [int] NOT NULL,
	[CustomerGender] [nvarchar](50) NOT NULL,
	[CustomerAge] [nvarchar](50) NOT NULL,
	[NetPrice] [decimal](18, 0) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[Modifieddate] [datetime] NULL,
	[Isdeleted] [bit] NOT NULL,
 CONSTRAINT [PK_RateChart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CoveragePlans] ON 
GO
INSERT [dbo].[CoveragePlans] ([Id], [CoveragePlan], [EligibilityDateFrom], [EligibilityDateTo], [EligibilityCountry], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (1, N'Gold', CAST(N'2009-01-01T00:00:00.000' AS DateTime), CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'USA', CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[CoveragePlans] ([Id], [CoveragePlan], [EligibilityDateFrom], [EligibilityDateTo], [EligibilityCountry], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (2, N'Platinum', CAST(N'2005-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-01T00:00:00.000' AS DateTime), N'CAN', CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[CoveragePlans] ([Id], [CoveragePlan], [EligibilityDateFrom], [EligibilityDateTo], [EligibilityCountry], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (3, N'Silver', CAST(N'2001-01-01T00:00:00.000' AS DateTime), CAST(N'2026-01-01T00:00:00.000' AS DateTime), N'*', CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[CoveragePlans] OFF
GO
SET IDENTITY_INSERT [dbo].[RateChart] ON 
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (1, 1, N'M', N'<=40', CAST(1000 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (2, 1, N'M', N'>40', CAST(2000 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (3, 1, N'F', N'<=40', CAST(1200 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (4, 1, N'F', N'>40 ', CAST(2500 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (5, 2, N'M', N'<=40  ', CAST(1500 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (6, 2, N'M', N'>40 ', CAST(2600 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (7, 2, N'F', N'<=40  ', CAST(1900 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (8, 2, N'F', N'>40 ', CAST(2800 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (9, 3, N'M', N'<=40  ', CAST(1900 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (10, 3, N'M', N'>40 ', CAST(2900 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (11, 3, N'F', N'<=40  ', CAST(2100 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RateChart] ([Id], [CoveragePlansId], [CustomerGender], [CustomerAge], [NetPrice], [AddedDate], [Modifieddate], [Isdeleted]) VALUES (12, 3, N'F', N'>40 ', CAST(3200 AS Decimal(18, 0)), CAST(N'2020-10-01T00:00:00.000' AS DateTime), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[RateChart] OFF
GO
ALTER TABLE [dbo].[RateChart]  WITH CHECK ADD  CONSTRAINT [FK_RateChart_CoveragePlans] FOREIGN KEY([CoveragePlansId])
REFERENCES [dbo].[CoveragePlans] ([Id])
GO
ALTER TABLE [dbo].[RateChart] CHECK CONSTRAINT [FK_RateChart_CoveragePlans]
GO
