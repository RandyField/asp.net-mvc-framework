USE [master]
GO
/****** Object:  Database [righttest]    Script Date: 2017/12/1 16:59:51 ******/
CREATE DATABASE [righttest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'righttest', FILENAME = N'E:\sqlserver\MSSQL12.MSSQLSERVER\MSSQL\DATA\righttest.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'righttest_log', FILENAME = N'E:\sqlserver\MSSQL12.MSSQLSERVER\MSSQL\DATA\righttest_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [righttest] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [righttest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [righttest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [righttest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [righttest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [righttest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [righttest] SET ARITHABORT OFF 
GO
ALTER DATABASE [righttest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [righttest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [righttest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [righttest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [righttest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [righttest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [righttest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [righttest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [righttest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [righttest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [righttest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [righttest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [righttest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [righttest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [righttest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [righttest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [righttest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [righttest] SET RECOVERY FULL 
GO
ALTER DATABASE [righttest] SET  MULTI_USER 
GO
ALTER DATABASE [righttest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [righttest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [righttest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [righttest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [righttest] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'righttest', N'ON'
GO
USE [righttest]
GO
/****** Object:  Table [dbo].[tbBug]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbBug](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserIp] [varchar](50) NULL,
	[BugInfo] [varchar](max) NULL,
	[BugReply] [varchar](max) NULL,
	[BugDate] [datetime] NULL,
	[IfShow] [bit] NULL,
	[IfSolve] [bit] NULL,
 CONSTRAINT [PK_tbBug] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbButton]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbButton](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](50) NULL,
	[Icon] [varchar](50) NULL,
	[Sort] [int] NULL,
	[AddDate] [datetime] NULL CONSTRAINT [DF_tbButton_AddDate]  DEFAULT (getdate()),
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_tbButton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbDepartment]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[Sort] [int] NULL,
	[AddDate] [datetime] NULL CONSTRAINT [DF_tbDepartment_AddDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbLoginLog]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbLoginLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserIp] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Success] [bit] NULL,
	[LoginDate] [datetime] NULL CONSTRAINT [DF_tbLoginInfo_LoginDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbLoginInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMenu]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[Code] [varchar](50) NULL,
	[LinkAddress] [varchar](100) NULL,
	[Icon] [varchar](50) NULL,
	[Sort] [int] NULL,
	[AddDate] [datetime] NULL CONSTRAINT [DF_tbMenu_AddDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMenuButton]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbMenuButton](
	[MenuId] [int] NULL,
	[ButtonId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbRole]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
	[AddDate] [datetime] NULL CONSTRAINT [DF_tbRole_AddDate]  DEFAULT (getdate()),
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_tbRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbRoleMenuButton]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRoleMenuButton](
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[ButtonId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[UserPwd] [varchar](50) NULL,
	[IsAble] [bit] NULL,
	[IfChangePwd] [bit] NULL,
	[AddDate] [datetime] NULL CONSTRAINT [DF_tbUser_AddDate]  DEFAULT (getdate()),
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUserDepartment]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUserDepartment](
	[UserId] [int] NULL,
	[DepartmentId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbUserOperateLog]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserOperateLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserIp] [varchar](50) NULL,
	[OperateInfo] [varchar](64) NULL,
	[Description] [varchar](max) NULL,
	[IfSuccess] [bit] NULL,
	[OperateDate] [datetime] NULL CONSTRAINT [DF_tbUserOperateInfo_OperateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbUserOperateInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUserRole]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUserRole](
	[UserId] [int] NULL,
	[RoleId] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbButton] ON 

INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (1, N'浏览', N'browser', N'icon-eye', 1, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (3, N'添加', N'add', N'icon-add', 3, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (4, N'修改', N'edit', N'icon-application_edit', 4, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (5, N'删除', N'delete', N'icon-delete', 5, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (6, N'导出', N'export', N'icon-page_excel', 6, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (7, N'部门设置', N'setdepartment', N'icon-group', 8, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (8, N'角色设置', N'setrole', N'icon-user_key', 7, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (9, N'角色授权', N'authorize', N'icon-key', 9, CAST(N'2013-12-04 11:46:04.113' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (10, N'分配按钮', N'setbutton', N'icon-link', 10, CAST(N'2013-12-11 09:13:22.950' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (11, N'全部展开', N'expandall', N'icon-expand', 11, CAST(N'2013-12-11 10:28:38.470' AS DateTime), NULL)
INSERT [dbo].[tbButton] ([Id], [Name], [Code], [Icon], [Sort], [AddDate], [Description]) VALUES (12, N'全部隐藏', N'collapseall', N'icon-collapse', 12, CAST(N'2013-12-11 10:28:54.640' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbButton] OFF
SET IDENTITY_INSERT [dbo].[tbDepartment] ON 

INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (1, N'人事行政部', 0, 3, CAST(N'2013-10-15 21:55:13.787' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (2, N'研发部', 0, 1, CAST(N'2013-10-15 21:55:18.590' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (3, N'技术支持', 0, 2, CAST(N'2013-10-15 21:55:27.010' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (4, N'人事部', 1, 1, CAST(N'2013-10-15 21:55:27.980' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (5, N'行政部', 1, 2, CAST(N'2013-10-15 21:56:03.830' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (7, N'C#组', 2, 2, CAST(N'2013-10-15 21:56:18.240' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (8, N'Java组', 2, 1, CAST(N'2013-10-15 21:56:22.273' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (9, N'Shell脚本组', 2, 5, CAST(N'2013-10-15 21:56:39.400' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (10, N'C/C++组', 2, 4, CAST(N'2013-10-15 21:56:45.913' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (11, N'宽带光纤', 3, 2, CAST(N'2013-10-15 21:56:57.307' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (12, N'系统运维', 3, 1, CAST(N'2013-10-15 21:57:04.680' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (15, N'人事1部', 4, 1, CAST(N'2013-12-11 11:04:13.917' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (16, N'行政1部', 5, 2, CAST(N'2013-12-16 10:32:02.433' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (17, N'行政2部', 5, 1, CAST(N'2013-12-16 10:32:19.800' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (41, N'销售部', 0, 4, CAST(N'2014-01-08 11:09:32.587' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (43, N'销售组', 41, 1, CAST(N'2014-01-08 11:10:01.910' AS DateTime))
INSERT [dbo].[tbDepartment] ([Id], [DepartmentName], [ParentId], [Sort], [AddDate]) VALUES (46, N'PHP组', 2, 3, CAST(N'2014-01-08 11:11:20.550' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbDepartment] OFF
SET IDENTITY_INSERT [dbo].[tbLoginLog] ON 

INSERT [dbo].[tbLoginLog] ([Id], [UserName], [UserIp], [City], [Success], [LoginDate]) VALUES (1, N'zd', N'::1', N'四川成都,%u56DB%u5DDD%u7701%u6210%u90FD%u5E02', 1, CAST(N'2017-12-01 15:32:08.123' AS DateTime))
INSERT [dbo].[tbLoginLog] ([Id], [UserName], [UserIp], [City], [Success], [LoginDate]) VALUES (2, N'zd', N'::1', N'四川成都,%u56DB%u5DDD%u7701%u6210%u90FD%u5E02', 1, CAST(N'2017-12-01 15:32:58.157' AS DateTime))
INSERT [dbo].[tbLoginLog] ([Id], [UserName], [UserIp], [City], [Success], [LoginDate]) VALUES (3, N'admin', N'::1', N'四川成都,%u56DB%u5DDD%u7701%u6210%u90FD%u5E02', 1, CAST(N'2017-12-01 15:33:25.187' AS DateTime))
INSERT [dbo].[tbLoginLog] ([Id], [UserName], [UserIp], [City], [Success], [LoginDate]) VALUES (4, N'admin', N'::1', N'四川成都,%u56DB%u5DDD%u7701%u6210%u90FD%u5E02', 1, CAST(N'2017-12-01 15:47:22.273' AS DateTime))
INSERT [dbo].[tbLoginLog] ([Id], [UserName], [UserIp], [City], [Success], [LoginDate]) VALUES (5, N'admin', N'::1', N'四川成都,%u56DB%u5DDD%u7701%u6210%u90FD%u5E02', 1, CAST(N'2017-12-01 16:23:16.420' AS DateTime))
INSERT [dbo].[tbLoginLog] ([Id], [UserName], [UserIp], [City], [Success], [LoginDate]) VALUES (6, N'admin', N'::1', N'四川成都,%u56DB%u5DDD%u7701%u6210%u90FD%u5E02', 1, CAST(N'2017-12-01 16:23:30.020' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbLoginLog] OFF
SET IDENTITY_INSERT [dbo].[tbMenu] ON 

INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (1, N'系统设置', 0, NULL, NULL, N'icon-cog', 1, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (2, N'其他', 0, NULL, NULL, N'icon-tux', 2, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (3, N'菜单管理', 1, N'menu', N'html/ui_menu.html', N'icon-layout', 2, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (4, N'用户管理', 1, N'user', N'html/ui_user.html', N'icon-user_suit_black', 3, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (5, N'部门管理', 1, N'department', N'html/ui_department.html', N'icon-group', 5, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (6, N'角色管理', 1, N'role', N'html/ui_role.html', N'icon-key_go', 4, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (7, N'按钮管理', 1, N'button', N'html/ui_button.html', N'icon-button', 1, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (8, N'登录日志', 2, N'loginlog', N'html/ui_loginlog.html', N'icon-drive_user', 1, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (9, N'操作日志', 2, N'operatelog', N'html/ui_operatelog.html', N'icon-table', 2, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
INSERT [dbo].[tbMenu] ([Id], [Name], [ParentId], [Code], [LinkAddress], [Icon], [Sort], [AddDate]) VALUES (10, N'Bug反馈', 2, N'bugs', N'html/ui_bugs.html', N'icon-bug', 3, CAST(N'2013-09-21 14:32:43.253' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbMenu] OFF
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 7)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (7, 5)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (8, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (4, 8)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (8, 6)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (9, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (6, 9)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (3, 10)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 1)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 11)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 3)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 4)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (10, 6)
INSERT [dbo].[tbMenuButton] ([MenuId], [ButtonId]) VALUES (5, 12)
SET IDENTITY_INSERT [dbo].[tbRole] ON 

INSERT [dbo].[tbRole] ([Id], [RoleName], [Description], [AddDate], [ModifyDate]) VALUES (1, N'超级管理员', N'拥有所有增删改查权限', CAST(N'2013-11-11 16:01:24.697' AS DateTime), CAST(N'2013-12-18 10:22:32.067' AS DateTime))
INSERT [dbo].[tbRole] ([Id], [RoleName], [Description], [AddDate], [ModifyDate]) VALUES (52, N'浏览角色', N'仅拥有浏览菜单的权限，无增删改权限', CAST(N'2014-02-19 09:30:14.863' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbRole] OFF
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 7)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 7, 5)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 8, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 4, 8)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 8, 6)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 9, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 6, 9)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 3, 10)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 11)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 3)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 4)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 10, 6)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 1, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 9, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 4, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 7, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 3, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 2, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 10, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 5, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 1, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 2, 0)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 6, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (52, 8, 1)
INSERT [dbo].[tbRoleMenuButton] ([RoleId], [MenuId], [ButtonId]) VALUES (1, 5, 12)
SET IDENTITY_INSERT [dbo].[tbUser] ON 

INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (72, N'admin', N'管理员', N'E10ADC3949BA59ABBE56E057F20F88', 1, 1, CAST(N'2014-01-08 10:32:57.700' AS DateTime), N'管理员账号')
INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (74, N'wangjie', N'汪杰', N'E10ADC3949BA59ABBE56E057F20F88', 1, 1, CAST(N'2014-02-19 09:26:35.643' AS DateTime), N'oppoic.cnblogs.com')
INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (75, N'test', N'测试用户', N'E10ADC3949BA59ABBE56E057F20F88', 1, 1, CAST(N'2014-02-24 09:56:00.977' AS DateTime), N'测试账号')
INSERT [dbo].[tbUser] ([Id], [UserId], [UserName], [UserPwd], [IsAble], [IfChangePwd], [AddDate], [Description]) VALUES (76, N'zd', N'zd', N'E10ADC3949BA59ABBE56E057F20F88', 1, 1, CAST(N'2017-12-01 15:12:16.880' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbUser] OFF
INSERT [dbo].[tbUserDepartment] ([UserId], [DepartmentId]) VALUES (72, 15)
SET IDENTITY_INSERT [dbo].[tbUserOperateLog] ON 

INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (1, N'admin', N'::1', N'查询按钮', N'查询条件：1=1 排序：Sort asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:33:33.280' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (2, N'admin', N'::1', N'查询菜单', N'查询条件：1=1 排序：ParentId asc,Sort asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:33:35.000' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (3, N'admin', N'::1', N'查询用户', N'查询条件：1=1 排序：AddDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:33:36.110' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (4, N'admin', N'::1', N'查询角色', N'查询条件：1=1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:33:36.850' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (5, N'admin', N'::1', N'查询部门', N'查询条件：1=1', 1, CAST(N'2017-12-01 15:33:37.747' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (6, N'admin', N'::1', N'查询登陆日志', N'查询条件：1=1 排序：LoginDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:33:40.017' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (7, N'admin', N'::1', N'查询操作日志', N'查询条件：1=1 排序：OperateDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:33:40.630' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (8, N'admin', N'::1', N'查询操作日志', N'查询条件：1=1 排序：OperateDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:45:01.800' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (9, N'admin', N'::1', N'查询登陆日志', N'查询条件：1=1 排序：LoginDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:45:02.660' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (10, N'admin', N'::1', N'查询按钮', N'查询条件：1=1 排序：Sort asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 15:45:07.110' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (11, N'admin', N'::1', N'查询菜单', N'查询条件：1=1 排序：ParentId asc,Sort asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:46:38.630' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (12, N'admin', N'::1', N'查询用户', N'查询条件：1=1 排序：AddDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:46:44.083' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (13, N'admin', N'::1', N'查询角色', N'查询条件：1=1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:46:46.060' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (14, N'admin', N'::1', N'查询角色用户', N'查询角色Id：1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:46:48.153' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (15, N'admin', N'::1', N'查询按钮', N'查询条件：1=1 排序：Sort asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:46:51.520' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (16, N'admin', N'::1', N'查询登陆日志', N'查询条件：1=1 排序：LoginDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:47:08.093' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (17, N'admin', N'::1', N'查询操作日志', N'查询条件：1=1 排序：OperateDate desc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:47:15.837' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (18, N'admin', N'::1', N'查询部门', N'查询条件：1=1', 1, CAST(N'2017-12-01 16:47:18.413' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (19, N'admin', N'::1', N'查询角色用户', N'查询角色Id：52 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:47:47.857' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (20, N'admin', N'::1', N'查询角色用户', N'查询角色Id：1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:47:49.290' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (21, N'admin', N'::1', N'查询角色用户', N'查询角色Id：52 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:49:58.433' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (22, N'admin', N'::1', N'查询部门用户', N'查询部门Id：8 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:21.853' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (23, N'admin', N'::1', N'查询部门用户', N'查询部门Id：7 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:23.170' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (24, N'admin', N'::1', N'查询部门用户', N'查询部门Id：46 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:23.900' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (25, N'admin', N'::1', N'查询部门用户', N'查询部门Id：10 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:24.527' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (26, N'admin', N'::1', N'查询部门用户', N'查询部门Id：9 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:25.260' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (27, N'admin', N'::1', N'查询部门用户', N'查询部门Id：12 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:26.167' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (28, N'admin', N'::1', N'查询部门用户', N'查询部门Id：11 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:26.767' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (29, N'admin', N'::1', N'查询部门用户', N'查询部门Id：15,4 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:27.590' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (30, N'admin', N'::1', N'查询部门用户', N'查询部门Id：15 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:28.243' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (31, N'admin', N'::1', N'查询部门用户', N'查询部门Id：17 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:29.010' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (32, N'admin', N'::1', N'查询部门用户', N'查询部门Id：16 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:29.703' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (33, N'admin', N'::1', N'查询部门用户', N'查询部门Id：43 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:30.707' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (34, N'admin', N'::1', N'查询角色用户', N'查询角色Id：1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:50:53.050' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (35, N'admin', N'::1', N'角色授权', N'授权成功，菜单/按钮Id：7 1,7 3,7 4,7 5,3 1,3 3,3 4,3 5,3 10,4 1,4 3,4 4,4 5,4 8,4 7,6 1,6 3,6 4,6 5,6 9,5 1,5 3,5 4,5 5,5 11,5 12,8 1,8 6,9 1,10 1,10 3,10 4,10 6', 1, CAST(N'2017-12-01 16:53:05.680' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (36, N'admin', N'::1', N'查询角色用户', N'查询角色Id：52 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:53:07.163' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (37, N'admin', N'::1', N'角色授权', N'授权成功，菜单/按钮Id：7 1,7 3,7 4,3 1,4 1,6 1,5 1,8 1,9 1,10 1', 1, CAST(N'2017-12-01 16:53:13.093' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (38, N'admin', N'::1', N'查询角色用户', N'查询角色Id：1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:53:41.313' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (39, N'admin', N'::1', N'查询角色用户', N'查询角色Id：52 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:53:43.443' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (40, N'admin', N'::1', N'角色授权', N'授权成功，菜单/按钮Id：7 1,3 1,4 1,6 1,5 1,8 1,9 1,10 1', 1, CAST(N'2017-12-01 16:54:09.413' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (41, N'admin', N'::1', N'查询角色用户', N'查询角色Id：1 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:56:44.547' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (42, N'admin', N'::1', N'查询角色用户', N'查询角色Id：52 排序：AddDate asc 页码/每页大小：1 20', 1, CAST(N'2017-12-01 16:56:50.230' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (43, N'admin', N'::1', N'角色授权', N'授权成功，菜单/按钮Id：7 1,7 3,7 4,7 5,3 1,4 1,6 1,5 1,8 1,9 1,10 1', 1, CAST(N'2017-12-01 16:56:56.657' AS DateTime))
INSERT [dbo].[tbUserOperateLog] ([Id], [UserName], [UserIp], [OperateInfo], [Description], [IfSuccess], [OperateDate]) VALUES (44, N'admin', N'::1', N'角色授权', N'授权成功，菜单/按钮Id：7 1,3 1,4 1,6 1,5 1,8 1,9 1,10 1', 1, CAST(N'2017-12-01 16:57:13.930' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbUserOperateLog] OFF
INSERT [dbo].[tbUserRole] ([UserId], [RoleId]) VALUES (74, 52)
INSERT [dbo].[tbUserRole] ([UserId], [RoleId]) VALUES (72, 1)
ALTER TABLE [dbo].[tbBug] ADD  CONSTRAINT [DF_tbBug_BugDate]  DEFAULT (getdate()) FOR [BugDate]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckLogin]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_CheckLogin]  
@ip nvarchar(50),  
@lastErrorLoginTime datetime output  
as          
declare @errorLoginCount int  --错误次数  
select @errorLoginCount = Count(1) from tbLoginLog where Success = 0 and DATEADD(MI,30,LoginDate) > GETDATE() and UserIp = @ip  
if @errorLoginCount >= 5  
begin  
 select top 1 @lastErrorLoginTime = T.LoginDate from (select top 5 LoginDate from tbLoginLog where UserIp = @ip order by LoginDate desc ) T order by LoginDate asc  
end  
else  
begin  
 set @lastErrorLoginTime = null  
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAuthorityByUserId]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetAuthorityByUserId]  
@userId int  --用户主键id  
as    
declare @roleIds varchar(128)  --用户所有的角色集合  
declare @sql varchar(max)    
SELECT @roleIds=REPLACE(    
(select str(ur.RoleId)+',' from tbUser u    
join tbUserRole ur on u.Id = ur.UserId where u.Id = @userId  
for xml path('')),' ','')    
--print substring(@roleids,1,len(@roleids)-1)  --打印出用户所拥有的角色id  
set @sql=    
'select m.Id menuid,m.Name menuname,m.ParentId parentid,m.Icon menuicon,mb.ButtonId buttonid,b.Name buttonname,b.Icon buttonicon,rmb.RoleId roleid,  
case      
when isnull(rmb.ButtonId,0) = 0   
then ''false'' else ''true''    
end checked    
from tbMenu m  
left join tbMenuButton mb on m.Id=mb.MenuId  
left join tbButton b on mb.ButtonId=b.Id    
left join tbRoleMenuButton rmb on (mb.MenuId=rmb.MenuId and mb.ButtonId=rmb.ButtonId and rmb.RoleId in ('    
+    
isnull(substring(@roleIds,1,len(@roleIds)-1),0)    
+'))    
order by m.ParentId,m.Sort,b.Sort'  
--print @sql    
exec (@sql)

GO
/****** Object:  StoredProcedure [dbo].[sp_Pager]    Script Date: 2017/12/1 16:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Pager]
@tableName varchar(64),  --分页表名
@columns varchar(512),  --查询的字段
@order varchar(256),    --排序方式
@pageSize int,  --每页大小
@pageIndex int,  --当前页
@where varchar(1024) = '1=1',  --查询条件
@totalCount int output  --总记录数
as
declare @beginIndex int,@endIndex int,@sqlResult nvarchar(2000),@sqlGetCount nvarchar(2000)
set @beginIndex = (@pageIndex - 1) * @pageSize + 1  --开始
set @endIndex = (@pageIndex) * @pageSize  --结束
set @sqlresult = 'select '+@columns+' from (
select row_number() over(order by '+ @order +')
as Rownum,'+@columns+'
from '+@tableName+' where '+ @where +') as T
where T.Rownum between ' + CONVERT(varchar(max),@beginIndex) + ' and ' + CONVERT(varchar(max),@endIndex)
set @sqlGetCount = 'select @totalCount = count(*) from '+@tablename+' where ' + @where  --总数
--print @sqlresult
exec(@sqlresult)
exec sp_executesql @sqlGetCount,N'@totalCount int output',@totalCount output
--测试调用：
--declare @total int
--exec sp_Pager 'tbLoginInfo','Id,UserName,Success','LoginDate','desc',4,2,'1=1',@total output
--print @total

GO
USE [master]
GO
ALTER DATABASE [righttest] SET  READ_WRITE 
GO
