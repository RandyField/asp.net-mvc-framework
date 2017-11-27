using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class jsonResult
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public LoginStatus state { get; set; }
    }
}
