//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SYS_DEPARTMENT
    {
        public int ID { get; set; }
        public string DepartName { get; set; }
        public string DepartCode { get; set; }
        public string ChargeMan { get; set; }
        public string ChargeManPhone { get; set; }
        public string ParentDepart { get; set; }
        public Nullable<int> Isdelete { get; set; }
        public string Remark { get; set; }
        public string Alias { get; set; }
        public string UpdateTime { get; set; }
    }
}