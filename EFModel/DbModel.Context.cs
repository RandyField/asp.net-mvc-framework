﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SYS_CONFIG> SYS_CONFIG { get; set; }
        public DbSet<SYS_DEPARTMENT> SYS_DEPARTMENT { get; set; }
        public DbSet<SYS_MENU> SYS_MENU { get; set; }
        public DbSet<SYS_PERMISSION> SYS_PERMISSION { get; set; }
        public DbSet<SYS_PERMISSION_MENU_RELATION> SYS_PERMISSION_MENU_RELATION { get; set; }
        public DbSet<SYS_ROLE> SYS_ROLE { get; set; }
        public DbSet<SYS_ROLE_PERMISSION_RELATION> SYS_ROLE_PERMISSION_RELATION { get; set; }
        public DbSet<SYS_USER_ROLE_RELATION> SYS_USER_ROLE_RELATION { get; set; }
        public DbSet<SYS_USERINFO> SYS_USERINFO { get; set; }
        public DbSet<Zhp_AwardCreate> Zhp_AwardCreate { get; set; }
        public DbSet<Zhp_AwardsLimited> Zhp_AwardsLimited { get; set; }
        public DbSet<Zhp_GameApi> Zhp_GameApi { get; set; }
        public DbSet<Zhp_GameAwards> Zhp_GameAwards { get; set; }
        public DbSet<Zhp_GameConfig> Zhp_GameConfig { get; set; }
        public DbSet<Zhp_GameRecord> Zhp_GameRecord { get; set; }
        public DbSet<Zhp_OnlineGame> Zhp_OnlineGame { get; set; }
        public DbSet<SYS_PARAM_CONFIG> SYS_PARAM_CONFIG { get; set; }
        public DbSet<SYS_PARAM> SYS_PARAM { get; set; }
        public DbSet<Zhp_GameCount> Zhp_GameCount { get; set; }
        public DbSet<Zhp_WxUserInfo> Zhp_WxUserInfo { get; set; }
    }
}
