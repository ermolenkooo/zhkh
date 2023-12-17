namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SERVICE")]
    public partial class SERVICE
    {
        public int id { get; set; }

        public int id_address { get; set; }

        public int id_category { get; set; }

        [Required]
        [StringLength(50)]
        public string company { get; set; }

        [Required]
        [StringLength(50)]
        public string month { get; set; }

        public int year { get; set; }

        public bool status { get; set; }

        public double amount { get; set; }

        [Required]
        [StringLength(50)]
        public string account { get; set; }

        public virtual ADDRESS ADDRESS { get; set; }

        public virtual SERVICE_CATEGORY SERVICE_CATEGORY { get; set; }
    }
}
