namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefon")]
    public partial class Telefon
    {
        public int telefonID { get; set; }

        [StringLength(50)]
        public string numara { get; set; }

        public int? firmaID { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
