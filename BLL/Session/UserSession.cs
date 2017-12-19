using EFModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Session
{
    public class UserSession
    {

        //RBAC梳理
        //基础-整个系统的菜单
        //权限-关联菜单功能模块，包括增删改查，且一个权限包括所有菜单功能模块
        //角色-关联权限，一个角色可以对应多个权限
        //角色-权限-菜单
        //角色是一组权限集合，也是一组用户集合
        //so用户隶属的角色，角色包括的权限集，各个权限包括的菜单功能模块的限制（增删改查）
        //--所以，当一个角色存在用户，角色则不能删除，当权限被某个角色占用，则权限不能删除，

        public SYS_USER AccountInfo { get; set; }

        /// <summary>
        /// 用户角色信息
        /// </summary>
        public List<SYS_ROLE> Rolelist { get; set; }

        /// <summary>
        /// 用户可用菜单信息
        /// </summary>
        public List<UserMenuModel> Menulist { get; set; }

        /// <summary>
        /// 用户所属部门信息
        /// </summary>
        public PLATFORM_DEPARTMENT Department { get; set; }

        /// <summary>
        /// 用户拥有的菜单按钮
        /// </summary>
        public List<SYS_ROLE_MENU_BUTTON> Menubtn { get; set; }

        /// <summary>
        /// 用户登录信息
        /// </summary>
        public SYS_LOGIN logininfo { get; set; }

    }
}
