
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserMenuModel
    {
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
        public string ParentCode { get; set; }
        public string LinkAddress { get; set; }
        public string IconScript { get; set; }
        public Nullable<int> Sort { get; set; }
    }
}
