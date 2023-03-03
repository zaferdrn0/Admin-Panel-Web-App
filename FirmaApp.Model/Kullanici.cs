namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        public int kullaniciID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(50)]
        public string ePosta { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        public bool? aktifMi { get; set; }

        public int? firmaID { get; set; }

        [StringLength(50)]
        public string resim { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
