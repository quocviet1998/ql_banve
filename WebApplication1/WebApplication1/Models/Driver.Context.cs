﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QL_BanVeXeEntities : DbContext
    {
        public QL_BanVeXeEntities()
            : base("name=QL_BanVeXeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CHUYENXE> CHUYENXEs { get; set; }
        public DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public DbSet<LOAIXE> LOAIXEs { get; set; }
        public DbSet<MALOAINV> MALOAINVs { get; set; }
        public DbSet<NHANVIEN> NHANVIENs { get; set; }
        public DbSet<TUYENXE> TUYENXEs { get; set; }
        public DbSet<VEXE> VEXEs { get; set; }
        public DbSet<XE> XEs { get; set; }
    }
}
