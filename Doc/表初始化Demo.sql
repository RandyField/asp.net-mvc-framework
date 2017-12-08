/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2017/11/30 17:25:37                          */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('FileUploader')
            and   type = 'U')
   drop table FileUploader
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysDepartment')
            and   type = 'U')
   drop table dbo.SysDepartment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysException')
            and   type = 'U')
   drop table dbo.SysException
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysField')
            and   type = 'U')
   drop table dbo.SysField
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysLog')
            and   type = 'U')
   drop table dbo.SysLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysMenu')
            and   type = 'U')
   drop table dbo.SysMenu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysMenuSysOperation')
            and   type = 'U')
   drop table SysMenuSysOperation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysMenuSysRoleSysOperation')
            and   type = 'U')
   drop table SysMenuSysRoleSysOperation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysOperation')
            and   type = 'U')
   drop table SysOperation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysPerson')
            and   type = 'U')
   drop table dbo.SysPerson
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysRole')
            and   type = 'U')
   drop table dbo.SysRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysRoleSysPerson')
            and   type = 'U')
   drop table dbo.SysRoleSysPerson
go

/*==============================================================*/
/* Table: FileUploader                                          */
/*==============================================================*/
create table FileUploader (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   Path                 nvarchar(200)        null,
   FullPath             varchar(500)         null,
   Suffix               nvarchar(200)        null,
   Size                 int                  null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   State                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_FILEUPLOADER primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: SysDepartment                                         */
/*==============================================================*/
create table dbo.SysDepartment (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   Name                 nvarchar(200)        collate Chinese_PRC_CI_AS not null,
   ParentId             nvarchar(36)         collate Chinese_PRC_CI_AS null,
   Address              nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Sort                 int                  null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSDEPARTMENT primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDepartment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDepartment', 'column', 'Name'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysDepartment', 'column', 'Name'
go

/*==============================================================*/
/* Table: SysException                                          */
/*==============================================================*/
create table dbo.SysException (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   LeiXing              nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Message              nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   Result               nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   State                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSEXCEPTION primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Message')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysException', 'column', 'Message'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysException', 'column', 'Message'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysException', 'column', 'CreateTime'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysException', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: SysField                                              */
/*==============================================================*/
create table dbo.SysField (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   MyTexts              nvarchar(200)        collate Chinese_PRC_CI_AS not null,
   ParentId             nvarchar(36)         collate Chinese_PRC_CI_AS null,
   MyTables             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MyColums             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Sort                 int                  null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSFIELD primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MyTexts')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysField', 'column', 'MyTexts'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysField', 'column', 'MyTexts'
go

/*==============================================================*/
/* Table: SysLog                                                */
/*==============================================================*/
create table dbo.SysLog (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   PersonId             nvarchar(36)         collate Chinese_PRC_CI_AS null,
   Message              nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   Result               nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MenuId               nvarchar(36)         collate Chinese_PRC_CI_AS null,
   Ip                   nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   State                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSLOG primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Message')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLog', 'column', 'Message'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysLog', 'column', 'Message'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLog', 'column', 'Ip'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysLog', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLog', 'column', 'State'

end


execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', 'dbo', 'table', 'SysLog', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLog', 'column', 'CreateTime'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysLog', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: SysMenu                                               */
/*==============================================================*/
create table dbo.SysMenu (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   Name                 nvarchar(200)        collate Chinese_PRC_CI_AS not null,
   ParentId             nvarchar(36)         collate Chinese_PRC_CI_AS null,
   Url                  nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Iconic               nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Sort                 int                  null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   State                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   IsLeaf               nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSMENU primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysMenu') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysMenu' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'µ¼º½À¸', 
   'user', 'dbo', 'table', 'SysMenu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Name'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Name'
go

/*==============================================================*/
/* Table: SysMenuSysOperation                                   */
/*==============================================================*/
create table SysMenuSysOperation (
   SysMenuId            nvarchar(36)         not null,
   SysOperationId       nvarchar(36)         not null,
   constraint PK_SYSMENUSYSOPERATION primary key (SysMenuId, SysOperationId)
)
go

/*==============================================================*/
/* Table: SysMenuSysRoleSysOperation                            */
/*==============================================================*/
create table SysMenuSysRoleSysOperation (
   Id                   nvarchar(36)         not null,
   SysMenuId            nvarchar(36)         null,
   SysOperationId       nvarchar(36)         null,
   SysRoleId            nvarchar(36)         null,
   constraint PK_SYSMENUSYSROLESYSOPERATION primary key (Id)
)
go

/*==============================================================*/
/* Table: SysOperation                                          */
/*==============================================================*/
create table SysOperation (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   Name                 nvarchar(200)        collate Chinese_PRC_CI_AS null,
   "Function"           nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Iconic               nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Sort                 int                  null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   State                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSOPERATION primary key nonclustered (Id),
   constraint AK_KEY_1_SYSOPERA unique clustered (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysOperation') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysOperation' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '²Ù×÷', 
   'user', @CurrentUser, 'table', 'SysOperation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysOperation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Iconic')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysOperation', 'column', 'Iconic'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'SysOperation', 'column', 'Iconic'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysOperation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysOperation', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'SysOperation', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysOperation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysOperation', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'SysOperation', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: SysPerson                                             */
/*==============================================================*/
create table dbo.SysPerson (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   Name                 nvarchar(200)        collate Chinese_PRC_CI_AS not null,
   MyName               nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Password             nvarchar(200)        collate Chinese_PRC_CI_AS not null,
   SurePassword         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Sex                  nvarchar(200)        collate Chinese_PRC_CI_AS null,
   SysDepartmentId      nvarchar(36)         collate Chinese_PRC_CI_AS null,
   Position             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MobilePhoneNumber    nvarchar(200)        collate Chinese_PRC_CI_AS null,
   PhoneNumber          nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Province             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   City                 nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Village              nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Address              nvarchar(200)        collate Chinese_PRC_CI_AS null,
   EmailAddress         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Remark               nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   State                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   UpdateTime           datetime             null,
   LogonNum             int                  null,
   LogonTime            datetime             null,
   LogonIP              nvarchar(200)        collate Chinese_PRC_CI_AS null,
   LastLogonTime        datetime             null,
   LastLogonIP          nvarchar(200)        collate Chinese_PRC_CI_AS null,
   UpdatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Version              timestamp            null,
   constraint PK_SYSPERSON primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Name'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MyName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'MyName'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'MyName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sex')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Sex'

end


execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Province')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Province'

end


execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Province'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'City')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'City'

end


execute sp_addextendedproperty 'MS_Description', 
   'ProvinceCascade',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'City'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Village')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Village'

end


execute sp_addextendedproperty 'MS_Description', 
   'CityCascade',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'Village'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysPerson', 'column', 'State'

end


execute sp_addextendedproperty 'MS_Description', 
   'RadioButtonResearch',
   'user', 'dbo', 'table', 'SysPerson', 'column', 'State'
go

/*==============================================================*/
/* Table: SysRole                                               */
/*==============================================================*/
create table dbo.SysRole (
   Id                   nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   Name                 nvarchar(200)        collate Chinese_PRC_CI_AS not null,
   Description          nvarchar(4000)       collate Chinese_PRC_CI_AS null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSROLE primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysRole')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysRole', 'column', 'Name'

end


execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', 'dbo', 'table', 'SysRole', 'column', 'Name'
go

/*==============================================================*/
/* Table: SysRoleSysPerson                                      */
/*==============================================================*/
create table dbo.SysRoleSysPerson (
   SysPersonId          nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   SysRoleId            nvarchar(36)         collate Chinese_PRC_CI_AS not null,
   constraint PK_SYSROLESYSPERSON primary key (SysPersonId, SysRoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

