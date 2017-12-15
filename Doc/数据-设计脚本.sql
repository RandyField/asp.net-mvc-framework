USE [RandyAdminACE]
GO
/****** Object:  Table [dbo].[PLATFORM_DEPARTMENT]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PLATFORM_DEPARTMENT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartName] [varchar](32) NULL,
	[DepartCode] [varchar](16) NULL,
	[ParentCode] [varchar](16) NULL,
	[Sort] [int] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_PLATFORM_DEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_BUG_FEEDBACK]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_BUG_FEEDBACK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](32) NULL,
	[UserIp] [varchar](50) NULL,
	[BugInfo] [varchar](max) NULL,
	[BugReply] [varchar](max) NULL,
	[FeedBackDate] [datetime] NULL,
	[SolveMan] [varchar](32) NULL,
	[SolveDate] [datetime] NULL,
	[IsShow] [char](1) NULL,
	[State] [char](1) NULL,
 CONSTRAINT [PK_SYS_BUG_FEEDBACK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_BUTTON]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_BUTTON](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](16) NULL,
	[Code] [varchar](8) NULL,
	[IconScript] [text] NULL,
	[Sort] [int] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_SYS_BUTTON] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_LOGIN]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_LOGIN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](32) NULL,
	[UserPassword] [varchar](64) NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_SYS_LOGIN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_LOGIN_LOG]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_LOGIN_LOG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](16) NULL,
	[UserIp] [varchar](50) NULL,
	[City] [varchar](32) NULL,
	[Success] [char](1) NULL,
	[LoginDate] [datetime] NULL,
 CONSTRAINT [PK_SYS_LOGIN_LOG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_MENU]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_MENU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](16) NULL,
	[MenuCode] [varchar](8) NULL,
	[ParentCode] [varchar](8) NULL,
	[LinkAddress] [varchar](100) NULL,
	[IconScript] [varchar](100) NULL,
	[Sort] [int] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_SYS_MENU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_MENU_BUTTON]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_MENU_BUTTON](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuCode] [varchar](8) NULL,
	[ButtonCode] [varchar](8) NULL,
 CONSTRAINT [PK_SYS_MENU_BUTTON] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_OPERATE_LOG]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_OPERATE_LOG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](32) NULL,
	[UserIp] [varchar](50) NULL,
	[OperateInfo] [varchar](16) NULL,
	[OperateDesc] [varchar](32) NULL,
	[Success] [char](1) NULL,
	[OperateDate] [datetime] NULL,
 CONSTRAINT [PK_SYS_OPERATE_LOG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_ROLE]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_ROLE](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](16) NULL,
	[RoleDesc] [text] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SYS_ROLE] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_ROLE_MENU_BUTTON]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_ROLE_MENU_BUTTON](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[MenuCode] [varchar](8) NULL,
	[ButtonCode] [varchar](8) NULL,
 CONSTRAINT [PK_SYS_ROLE_MENU_BUTTON] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_ROLE_USER]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ROLE_USER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_SYS_ROLE_USER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_USER]    Script Date: 2017/12/15 17:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_USER](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LoginID] [int] NULL,
	[DepartCode] [varchar](16) NULL,
	[RealName] [varchar](32) NULL,
	[Sex] [char](1) NULL,
	[Phone] [varchar](16) NULL,
	[QQ] [varchar](16) NULL,
	[E-mail] [varchar](32) NULL,
	[Wechat] [varchar](32) NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SYS_USER] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_BUTTON] ON 

GO
INSERT [dbo].[SYS_BUTTON] ([ID], [Name], [Code], [IconScript], [Sort], [CreateUserID], [CreateDate], [Description]) VALUES (1, N'增加', N'01', NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[SYS_BUTTON] ([ID], [Name], [Code], [IconScript], [Sort], [CreateUserID], [CreateDate], [Description]) VALUES (2, N'删除', N'02', NULL, 2, NULL, NULL, NULL)
GO
INSERT [dbo].[SYS_BUTTON] ([ID], [Name], [Code], [IconScript], [Sort], [CreateUserID], [CreateDate], [Description]) VALUES (3, N'修改', N'03', NULL, 3, NULL, NULL, NULL)
GO
INSERT [dbo].[SYS_BUTTON] ([ID], [Name], [Code], [IconScript], [Sort], [CreateUserID], [CreateDate], [Description]) VALUES (4, N'查询', N'04', NULL, 4, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SYS_BUTTON] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_LOGIN] ON 

GO
INSERT [dbo].[SYS_LOGIN] ([ID], [UserName], [UserPassword], [UpdateUserID], [UpdateDate], [CreateUserID], [CreateDate], [State]) VALUES (1, N'admin', N'ISMvKXpXpadDiUoOSoAfww==', 1, NULL, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[SYS_LOGIN] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_MENU] ON 

GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (1, N'系统设置', N'01', N'00', NULL, N'menu-icon fa fa-tachometer', 1, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (2, N'按钮管理', N'0101', N'01', N'/Button/Index', N'menu-icon fa fa-caret-right', 5, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (3, N'菜单管理', N'0102', N'01', N'/Menu/Index', N'menu-icon fa fa-caret-right', 4, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (4, N'用户管理', N'0103', N'01', N'/User/Index', N'menu-icon fa fa-caret-right', 3, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (5, N'角色管理', N'0104', N'01', N'/Role/Index', N'menu-icon fa fa-caret-right', 2, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (6, N'部门管理', N'0105', N'01', N'/Depart/Index', N'menu-icon fa fa-caret-right', 1, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (7, N'其他', N'02', N'00', NULL, N'menu-icon fa fa-file-o', 1, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (8, N'登录日志', N'0201', N'02', N'/Login/Index', N'menu-icon fa fa-caret-right', 1, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (9, N'操作日志', N'0202', N'02', N'/Log/Index', N'menu-icon fa fa-caret-right', 2, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
INSERT [dbo].[SYS_MENU] ([ID], [MenuName], [MenuCode], [ParentCode], [LinkAddress], [IconScript], [Sort], [CreateUserID], [CreateDate]) VALUES (10, N'Bug反馈', N'0203', N'02', N'/Feedback/Index', N'menu-icon fa fa-caret-right', 3, 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SYS_MENU] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_MENU_BUTTON] ON 

GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (1, N'0101', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (2, N'0101', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (3, N'0101', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (4, N'0101', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (5, N'0102', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (6, N'0102', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (7, N'0102', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (8, N'0102', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (9, N'0103', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (10, N'0103', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (11, N'0103', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (12, N'0103', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (13, N'0104', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (14, N'0104', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (15, N'0104', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (16, N'0104', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (17, N'0105', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (18, N'0105', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (19, N'0105', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (20, N'0105', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (21, N'0201', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (22, N'0201', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (23, N'0201', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (24, N'0201', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (25, N'0202', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (26, N'0202', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (27, N'0202', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (28, N'0202', N'04')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (29, N'0203', N'01')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (30, N'0203', N'02')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (31, N'0203', N'03')
GO
INSERT [dbo].[SYS_MENU_BUTTON] ([ID], [MenuCode], [ButtonCode]) VALUES (32, N'0203', N'04')
GO
SET IDENTITY_INSERT [dbo].[SYS_MENU_BUTTON] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_ROLE] ON 

GO
INSERT [dbo].[SYS_ROLE] ([RoleID], [RoleName], [RoleDesc], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate]) VALUES (1, N'超级管理员', N'超级管理员', 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime), 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SYS_ROLE] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ON 

GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (1, 1, N'0101', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (2, 1, N'0101', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (3, 1, N'0101', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (4, 1, N'0101', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (5, 1, N'0102', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (6, 1, N'0102', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (7, 1, N'0102', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (8, 1, N'0102', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (9, 1, N'0103', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (10, 1, N'0103', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (11, 1, N'0103', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (12, 1, N'0103', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (13, 1, N'0104', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (14, 1, N'0104', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (15, 1, N'0104', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (16, 1, N'0104', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (17, 1, N'0105', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (18, 1, N'0105', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (19, 1, N'0105', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (20, 1, N'0105', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (21, 1, N'0201', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (22, 1, N'0201', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (23, 1, N'0201', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (24, 1, N'0201', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (25, 1, N'0202', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (26, 1, N'0202', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (27, 1, N'0202', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (28, 1, N'0202', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (29, 1, N'0203', N'01')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (30, 1, N'0203', N'02')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (31, 1, N'0203', N'03')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (32, 1, N'0203', N'04')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (43, 1, N'01', N'00')
GO
INSERT [dbo].[SYS_ROLE_MENU_BUTTON] ([ID], [RoleID], [MenuCode], [ButtonCode]) VALUES (44, 1, N'02', N'00')
GO
SET IDENTITY_INSERT [dbo].[SYS_ROLE_MENU_BUTTON] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_ROLE_USER] ON 

GO
INSERT [dbo].[SYS_ROLE_USER] ([ID], [UserID], [RoleID]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[SYS_ROLE_USER] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_USER] ON 

GO
INSERT [dbo].[SYS_USER] ([UserID], [LoginID], [DepartCode], [RealName], [Sex], [Phone], [QQ], [E-mail], [Wechat], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate]) VALUES (1, 1, N'00000000', N'张登', N'1', N'13880825220', N'287572291', N'287572291@qq.com', N'Carfield', 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime), 1, CAST(N'2017-12-14 16:11:11.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SYS_USER] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_MENU_BUTTON', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
