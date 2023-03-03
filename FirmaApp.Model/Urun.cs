namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        public int urunID { get; set; }

        public int? firmaID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        public string ozet { get; set; }

        [StringLength(50)]
        public string detay { get; set; }

        public bool? aktifMI { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
