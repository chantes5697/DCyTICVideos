﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCyTICVideos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VideosEntities : DbContext
    {
        public VideosEntities()
            : base("name=VideosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Casette> Casettes { get; set; }
        public virtual DbSet<Formato> Formatoes { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Filtro> Filtroes { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario1> Usuario1 { get; set; }
    }
}
