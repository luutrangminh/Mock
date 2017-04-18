USE [SPM_URD]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Student]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer] DROP CONSTRAINT [FK_StudentAnswer_Student]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer] DROP CONSTRAINT [FK_StudentAnswer_Question]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Answer]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer] DROP CONSTRAINT [FK_StudentAnswer_Answer]
GO
/****** Object:  Table [dbo].[StudentAnswer]    Script Date: 18/04/2017 7:49:06 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentAnswer]') AND type in (N'U'))
DROP TABLE [dbo].[StudentAnswer]
GO
/****** Object:  Table [dbo].[StudentAnswer]    Script Date: 18/04/2017 7:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentAnswer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentAnswer](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Answer]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_Answer] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[Answer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Answer]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_Answer]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_Question]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Student]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentAnswer_Student]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentAnswer]'))
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_Student]
GO
