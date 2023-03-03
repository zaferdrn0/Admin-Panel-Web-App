namespace FirmaApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        public int mesajID { get; set; }

        public int? firmaID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string eposta { get; set; }

        [StringLength(50)]
        public string konu { get; set; }

        public string icerik { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? tarih { get; set; }

        [StringLength(50)]
        public string ipAdresi { get; set; }

        public bool? okunduMu { get; set; }

        public virtual Firma Firma { get; set; }
    }
}
