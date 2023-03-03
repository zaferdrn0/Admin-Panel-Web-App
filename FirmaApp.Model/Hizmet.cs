namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hizmet")]
    public partial class Hizmet
    {
        public int hizmetID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }

        public int? firmaID { get; set; }

        [StringLength(50)]
        public string resim { get; set; }

        public bool? aktifMi { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
