/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2017/12/14 16:09:54                          */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('PLATFORM_DEPARTMENT')
            and   type = 'U')
   drop table PLATFORM_DEPARTMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_BUG_FEEDBACK')
            and   type = 'U')
   drop table SYS_BUG_FEEDBACK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_BUTTON')
            and   type = 'U')
   drop table SYS_BUTTON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_LOGIN')
            and   type = 'U')
   drop table SYS_LOGIN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_LOGIN_LOG')
            and   type = 'U')
   drop table SYS_LOGIN_LOG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_MENU')
            and   type = 'U')
   drop table SYS_MENU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_MENU_BUTTON')
            and   type = 'U')
   drop table SYS_MENU_BUTTON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_OPERATE_LOG')
            and   type = 'U')
   drop table SYS_OPERATE_LOG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_ROLE')
            and   type = 'U')
   drop table SYS_ROLE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_ROLE_MENU_BUTTON')
            and   type = 'U')
   drop table SYS_ROLE_MENU_BUTTON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_ROLE_USER')
            and   type = 'U')
   drop table SYS_ROLE_USER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SYS_USER')
            and   type = 'U')
   drop table SYS_USER
go

/*==============================================================*/
/* Table: PLATFORM_DEPARTMENT                                   */
/*==============================================================*/
create table PLATFORM_DEPARTMENT (
   ID                   int                  identity,
   DepartName           varchar(32)          null,
   DepartCode           varchar(16)          null,
   ParentCode           varchar(16)          null,
   Sort                 int                  null,
   CreateUserID         int                  null,
   CreateDate           datetime             null,
   constraint PK_PLATFORM_DEPARTMENT primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_BUG_FEEDBACK                                      */
/*==============================================================*/
create table SYS_BUG_FEEDBACK (
   ID                   int                  identity,
   UserName             varchar(32)          null,
   UserIp               varchar(50)          null,
   BugInfo              varchar(max)         null,
   BugReply             varchar(max)         null,
   FeedBackDate         datetime             null,
   SolveMan             varchar(32)          null,
   SolveDate            datetime             null,
   IsShow               char(1)              null,
   State                char(1)              null,
   constraint PK_SYS_BUG_FEEDBACK primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_BUTTON                                            */
/*==============================================================*/
create table SYS_BUTTON (
   ID                   int                  identity,
   Name                 varchar(16)          null,
   Code                 varchar(8)           null,
   IconScript           text                 null,
   Sort                 int                  null,
   CreateUserID         int                  null,
   CreateDate           datetime             null,
   Description          text                 null,
   constraint PK_SYS_BUTTON primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_LOGIN                                             */
/*==============================================================*/
create table SYS_LOGIN (
   ID                   int                  identity,
   UserName             varchar(32)          null,
   UserPassword         varchar(32)          null,
   UpdateUserID         int                  null,
   UpdateDate           datetime             null,
   CreateUserID         int                  null,
   CreateDate           datetime             null,
   constraint PK_SYS_LOGIN primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_LOGIN_LOG                                         */
/*==============================================================*/
create table SYS_LOGIN_LOG (
   ID                   int                  identity,
   UserName             varchar(16)          null,
   UserIp               varchar(50)          null,
   City                 varchar(32)          null,
   Success              char(1)              null,
   LoginDate            datetime             null,
   constraint PK_SYS_LOGIN_LOG primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_MENU                                              */
/*==============================================================*/
create table SYS_MENU (
   ID                   int                  identity,
   MenuName             varchar(16)          null,
   MenuCode             varchar(8)           null,
   ParentCode           varchar(8)           null,
   LinkAddress          varchar(100)         null,
   IconScript           text                 null,
   Sort                 int                  null,
   CreateUserID         int                  null,
   CreateDate           datetime             null,
   constraint PK_SYS_MENU primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_MENU_BUTTON                                       */
/*==============================================================*/
create table SYS_MENU_BUTTON (
   ID                   int                  identity,
   MenuID               int                  null,
   ButtonID             int                  null,
   constraint PK_SYS_MENU_BUTTON primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_OPERATE_LOG                                       */
/*==============================================================*/
create table SYS_OPERATE_LOG (
   ID                   int                  identity,
   UserName             varchar(32)          null,
   UserIp               varchar(50)          null,
   OperateInfo          varchar(16)          null,
   OperateDesc          varchar(32)          null,
   Success              char(1)              null,
   OperateDate          datetime             null,
   constraint PK_SYS_OPERATE_LOG primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_ROLE                                              */
/*==============================================================*/
create table SYS_ROLE (
   RoleID               int                  identity,
   RoleName             varchar(16)          null,
   RoleDesc             text                 null,
   CreateUserID         int                  null,
   CreateDate           datetime             null,
   UpdateUserID         int                  null,
   UpdateDate           datetime             null,
   constraint PK_SYS_ROLE primary key (RoleID)
)
go

/*==============================================================*/
/* Table: SYS_ROLE_MENU_BUTTON                                  */
/*==============================================================*/
create table SYS_ROLE_MENU_BUTTON (
   ID                   int                  identity,
   RoleID               int                  null,
   MenuID               int                  null,
   ButtonID             int                  null,
   constraint PK_SYS_ROLE_MENU_BUTTON primary key (ID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SYS_ROLE_MENU_BUTTON')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SYS_ROLE_MENU_BUTTON', 'column', 'RoleID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '½ÇÉ«id',
   'user', @CurrentUser, 'table', 'SYS_ROLE_MENU_BUTTON', 'column', 'RoleID'
go

/*==============================================================*/
/* Table: SYS_ROLE_USER                                         */
/*==============================================================*/
create table SYS_ROLE_USER (
   ID                   int                  identity,
   UserID               int                  null,
   RoleID               int                  null,
   constraint PK_SYS_ROLE_USER primary key (ID)
)
go

/*==============================================================*/
/* Table: SYS_USER                                              */
/*==============================================================*/
create table SYS_USER (
   UserID               int                  identity,
   LoginID              int                  null,
   DepartCode           varchar(16)          null,
   RealName             varchar(32)          null,
   Sex                  char(1)              null,
   Phone                varchar(16)          null,
   QQ                   varchar(16)          null,
   "E-mail"             varchar(32)          null,
   Wechat               varchar(32)          null,
   CreateUserID         int                  null,
   CreateDate           datetime             null,
   UpdateUserID         int                  null,
   UpdateDate           datetime             null,
   constraint PK_SYS_USER primary key (UserID)
)
go

