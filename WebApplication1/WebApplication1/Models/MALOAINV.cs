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
    
    public partial class MALOAINV
    {
        public MALOAINV()
        {
            this.NHANVIENs = new HashSet<NHANVIEN>();
        }
    
        public short MALOAINV1 { get; set; }
        public string TENLOAINV { get; set; }
    
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }
    }
}
