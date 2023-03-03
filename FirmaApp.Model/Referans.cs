namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Referans
    {
        public int referansID { get; set; }

        public int? firmaID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string resim { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
