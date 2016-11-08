namespace MedicoPlus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hosp.personal")]
    public partial class personal
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string fullname { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        public int region_id { get; set; }

        public int area_id { get; set; }

        public int city_id { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        public int user_id { get; set; }

        public int hosp_id { get; set; }

        public virtual areas areas { get; set; }

        public virtual cities cities { get; set; }

        public virtual hospitals hospitals { get; set; }

        public virtual users users { get; set; }

        public virtual regions regions { get; set; }
    }
}
