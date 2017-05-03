USE [SPM_URD]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Professors_Administrator]') AND parent_object_id = OBJECT_ID(N'[dbo].[Professors]'))
ALTER TABLE [dbo].[Professors] DROP CONSTRAINT [FK_Professors_Administrator]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Professors_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Professors] DROP CONSTRAINT [DF_Professors_Status]
END

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 03/05/2017 9:35:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Professors]') AND type in (N'U'))
DROP TABLE [dbo].[Professors]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 03/05/2017 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Professors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Professors](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[PhoneNumber] [varchar](11) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Professors_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Professors] ADD  CONSTRAINT [DF_Professors_Status]  DEFAULT ((0)) FOR [Status]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Professors_Administrator]') AND parent_object_id = OBJECT_ID(N'[dbo].[Professors]'))
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Administrator] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Administrator] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Professors_Administrator]') AND parent_object_id = OBJECT_ID(N'[dbo].[Professors]'))
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Administrator]
GO
