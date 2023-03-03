using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FirmaApp.Model
{
    public partial class FirmaContext : DbContext
    {
        public FirmaContext()
            : base("name=FirmaContext")
        {
        }

        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Eposta> Eposta { get; set; }
        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<Hizmet> Hizmet { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Mesaj> Mesaj { get; set; }
        public virtual DbSet<Referans> Referans { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
