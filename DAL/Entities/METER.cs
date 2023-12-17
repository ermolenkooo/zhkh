namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("METER")]
    public partial class METER
    {
        public int id { get; set; }

        public int id_address { get; set; }

        [Required]
        [StringLength(50)]
        public string number { get; set; }

        public int id_category { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int? reading { get; set; }

        public virtual ADDRESS ADDRESS { get; set; }

        public virtual METER_CATEGORY METER_CATEGORY { get; set; }
    }
}
