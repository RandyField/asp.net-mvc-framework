using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Menuaccess
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> MenuLevel { get; set; }
        public string MenuIcon { get; set; }
        public string MenuUrl { get; set; }
        public Nullable<int> ParentMenu { get; set; }
        public Nullable<int> Isdelete { get; set; }
        public string Sort { get; set; }
        public Nullable<int> BelongSys { get; set; }
        public string Remark { get; set; }
        public string UpdateTime { get; set; }
        public string Alias { get; set; }
        public string Access { get; set; }
    }
}