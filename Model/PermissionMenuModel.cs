using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PermissionMenuModel
    {
        public int menuId { get; set; }
        public string add { get; set; }
        public string delete { get; set; }
        public string edit { get; set; }
        public string query { get; set; }
        public string permissionName { get; set; }
    }
}
