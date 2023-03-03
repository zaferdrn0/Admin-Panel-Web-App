namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adres
    {
        public int adresID { get; set; }

        public int? firmaID { get; set; }

        [StringLength(50)]
        public string detay { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
