//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KHACHHANG
    {
        public KHACHHANG()
        {
            this.VEXEs = new HashSet<VEXE>();
        }
    
        public short MAKH { get; set; }
        public string TENDN { get; set; }
        public string MATKHAU { get; set; }
        public string TENKH { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public string DIACHI { get; set; }
        public Nullable<decimal> CMND { get; set; }
        public Nullable<decimal> DIENTHOAI { get; set; }
        public string EMAIL { get; set; }
    
        public virtual ICollection<VEXE> VEXEs { get; set; }
    }
}