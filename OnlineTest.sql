USE [OnlineTest]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[Id] [int] IDENTITY(1111,1) NOT NULL,
	[FullName] [text] NOT NULL,
	[Username] [char](20) NOT NULL,
	[Password] [char](16) NOT NULL,
	[Email] [text] NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetailTest]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailTest](
	[QuestionId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[NumberOfQuestion] [int] NOT NULL,
 CONSTRAINT [PK_DetailTest] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Group]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1111,1) NOT NULL,
	[GroupCode] [text] NOT NULL,
	[GroupName] [text] NOT NULL,
	[Leader] [text] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Rate] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMember](
	[StudentId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[JoinAt] [datetime] NOT NULL,
	[MemberNumber] [int] NOT NULL,
 CONSTRAINT [PK_GroupMember] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [int] IDENTITY(1111,1) NOT NULL,
	[FullName] [text] NOT NULL,
	[Email] [text] NOT NULL,
	[Username] [char](20) NOT NULL,
	[Password] [char](16) NOT NULL,
	[PhoneNumber] [varchar](11) NOT NULL,
	[Address] [text] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectCode] [text] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[StartAt] [datetime] NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionName] [text] NOT NULL,
	[Answer] [text] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScoreBoard]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScoreBoard](
	[StudentId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[SubmitAt] [datetime] NOT NULL,
 CONSTRAINT [PK_ScoreBoard] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/7/2017 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1111,1) NOT NULL,
	[Username] [char](20) NOT NULL,
	[Password] [char](16) NOT NULL,
	[FullName] [text] NOT NULL,
	[College] [text] NOT NULL,
	[Subject] [text] NOT NULL,
	[Age] [int] NOT NULL,
	[AssignBy] [int] NOT NULL,
	[Birthday] [datetime] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([Id], [FullName], [Username], [Password], [Email]) VALUES (1111, N'Luu Trang Minh', N'admin               ', N'admin           ', N'admin@gmail.com')
SET IDENTITY_INSERT [dbo].[Administrator] OFF
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Professor_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[DetailTest]  WITH CHECK ADD  CONSTRAINT [FK_DetailTest_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[DetailTest] CHECK CONSTRAINT [FK_DetailTest_Project]
GO
ALTER TABLE [dbo].[DetailTest]  WITH CHECK ADD  CONSTRAINT [FK_DetailTest_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[DetailTest] CHECK CONSTRAINT [FK_DetailTest_Question]
GO
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_Group]
GO
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_Student]
GO
ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Administrator] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Administrator] ([Id])
GO
ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_Administrator]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Professor] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Professor]
GO
ALTER TABLE [dbo].[ScoreBoard]  WITH CHECK ADD  CONSTRAINT [FK_ScoreBoard_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ScoreBoard] CHECK CONSTRAINT [FK_ScoreBoard_Project]
GO
ALTER TABLE [dbo].[ScoreBoard]  WITH CHECK ADD  CONSTRAINT [FK_ScoreBoard_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[ScoreBoard] CHECK CONSTRAINT [FK_ScoreBoard_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Student] FOREIGN KEY([AssignBy])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Student]
GO
