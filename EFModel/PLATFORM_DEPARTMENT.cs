//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PLATFORM_DEPARTMENT
    {
        public int ID { get; set; }
        public string DepartName { get; set; }
        public string DepartCode { get; set; }
        public string ParentCode { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}