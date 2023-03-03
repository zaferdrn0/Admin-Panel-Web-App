namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Eposta")]
    public partial class Eposta
    {
        public int ePostaID { get; set; }

        [StringLength(50)]
        public string posta { get; set; }

        public int? firmaID { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
