USE [bukepdb_test]
GO
/****** Object:  Table [dir].[Attribute]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[Attribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [nvarchar](512) NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[DataProvider]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[DataProvider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_DataProvider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[DataSource]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[DataSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [nvarchar](512) NOT NULL,
	[DataProviderId] [int] NOT NULL,
 CONSTRAINT [PK_DataSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[DataSourceAttribute]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[DataSourceAttribute](
	[DataProviderId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
 CONSTRAINT [PK_DataSourceAttribute] PRIMARY KEY CLUSTERED 
(
	[DataProviderId] ASC,
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[DataSourceAttributeValue]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[DataSourceAttributeValue](
	[DataProviderId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[Value] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_DataSourceAttributeValue] PRIMARY KEY CLUSTERED 
(
	[DataProviderId] ASC,
	[AttributeId] ASC,
	[DataSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[Directory]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[Directory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](512) NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[AccessObjectId] [int] NOT NULL,
 CONSTRAINT [PK_Directory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[Field]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[Field](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[DataTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[FieldAttribute]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[FieldAttribute](
	[DataProviderId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
 CONSTRAINT [PK_FieldAttribute] PRIMARY KEY CLUSTERED 
(
	[DataProviderId] ASC,
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dir].[FieldAttributeValue]    Script Date: 27.07.2021 9:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dir].[FieldAttributeValue](
	[DataProviderId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[FieldId] [int] NOT NULL,
	[Value] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_FieldAttributeValue] PRIMARY KEY CLUSTERED 
(
	[DataProviderId] ASC,
	[AttributeId] ASC,
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dir].[DataSource]  WITH CHECK ADD  CONSTRAINT [FK_DataSource_DataProvider] FOREIGN KEY([DataProviderId])
REFERENCES [dir].[DataProvider] ([Id])
GO
ALTER TABLE [dir].[DataSource] CHECK CONSTRAINT [FK_DataSource_DataProvider]
GO
ALTER TABLE [dir].[DataSourceAttribute]  WITH CHECK ADD  CONSTRAINT [FK_DataSourceAttribute_Attribute] FOREIGN KEY([AttributeId])
REFERENCES [dir].[Attribute] ([Id])
GO
ALTER TABLE [dir].[DataSourceAttribute] CHECK CONSTRAINT [FK_DataSourceAttribute_Attribute]
GO
ALTER TABLE [dir].[DataSourceAttribute]  WITH CHECK ADD  CONSTRAINT [FK_DataSourceAttribute_DataProvider] FOREIGN KEY([DataProviderId])
REFERENCES [dir].[DataProvider] ([Id])
GO
ALTER TABLE [dir].[DataSourceAttribute] CHECK CONSTRAINT [FK_DataSourceAttribute_DataProvider]
GO
ALTER TABLE [dir].[DataSourceAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_DataSourceAttributeValue_DataSource] FOREIGN KEY([DataSourceId])
REFERENCES [dir].[DataSource] ([Id])
GO
ALTER TABLE [dir].[DataSourceAttributeValue] CHECK CONSTRAINT [FK_DataSourceAttributeValue_DataSource]
GO
ALTER TABLE [dir].[DataSourceAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_DataSourceAttributeValue_DataSourceAttribute] FOREIGN KEY([DataProviderId], [AttributeId])
REFERENCES [dir].[DataSourceAttribute] ([DataProviderId], [AttributeId])
GO
ALTER TABLE [dir].[DataSourceAttributeValue] CHECK CONSTRAINT [FK_DataSourceAttributeValue_DataSourceAttribute]
GO
ALTER TABLE [dir].[Directory]  WITH CHECK ADD  CONSTRAINT [FK_Directory_DataSource] FOREIGN KEY([DataSourceId])
REFERENCES [dir].[DataSource] ([Id])
GO
ALTER TABLE [dir].[Directory] CHECK CONSTRAINT [FK_Directory_DataSource]
GO
ALTER TABLE [dir].[Directory]  WITH CHECK ADD  CONSTRAINT [FK_Directory_Objects] FOREIGN KEY([AccessObjectId])
REFERENCES [acs].[Objects] ([idObject])
GO
ALTER TABLE [dir].[Directory] CHECK CONSTRAINT [FK_Directory_Objects]
GO
ALTER TABLE [dir].[Field]  WITH CHECK ADD  CONSTRAINT [FK_Field_DataSource] FOREIGN KEY([DataSourceId])
REFERENCES [dir].[DataSource] ([Id])
GO
ALTER TABLE [dir].[Field] CHECK CONSTRAINT [FK_Field_DataSource]
GO
ALTER TABLE [dir].[FieldAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FieldAttribute_Attribute] FOREIGN KEY([AttributeId])
REFERENCES [dir].[Attribute] ([Id])
GO
ALTER TABLE [dir].[FieldAttribute] CHECK CONSTRAINT [FK_FieldAttribute_Attribute]
GO
ALTER TABLE [dir].[FieldAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FieldAttribute_DataProvider] FOREIGN KEY([DataProviderId])
REFERENCES [dir].[DataProvider] ([Id])
GO
ALTER TABLE [dir].[FieldAttribute] CHECK CONSTRAINT [FK_FieldAttribute_DataProvider]
GO
ALTER TABLE [dir].[FieldAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FieldAttributeValue_Field] FOREIGN KEY([FieldId])
REFERENCES [dir].[Field] ([Id])
GO
ALTER TABLE [dir].[FieldAttributeValue] CHECK CONSTRAINT [FK_FieldAttributeValue_Field]
GO
ALTER TABLE [dir].[FieldAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FieldAttributeValue_FieldAttribute] FOREIGN KEY([DataProviderId], [AttributeId])
REFERENCES [dir].[FieldAttribute] ([DataProviderId], [AttributeId])
GO
ALTER TABLE [dir].[FieldAttributeValue] CHECK CONSTRAINT [FK_FieldAttributeValue_FieldAttribute]
GO
