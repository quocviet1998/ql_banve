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
    
    public partial class TUYENXE
    {
        public TUYENXE()
        {
            this.CHUYENXEs = new HashSet<CHUYENXE>();
        }
    
        public int MATUYEN { get; set; }
        public string TENTUYEN { get; set; }
        public string DIEMDI { get; set; }
        public string DIEMDEN { get; set; }
        public Nullable<decimal> BANGGIA { get; set; }
    
        public virtual ICollection<CHUYENXE> CHUYENXEs { get; set; }
    }
}