using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GoodsModel
    {
        public string price { get; set; }
        public string title { get; set; }
        public string img { get; set; }
    }

    public class GoodsList
    {
       public List<GoodsModel> goods { get; set; }
    }
}
