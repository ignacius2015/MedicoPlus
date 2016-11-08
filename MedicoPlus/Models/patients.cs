namespace MedicoPlus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hosp.patients")]
    public partial class patients
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string fullname { get; set; }

        public DateTime begintime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public int city_id { get; set; }

        public int area_id { get; set; }

        public int region_id { get; set; }

        [StringLength(12)]
        public string phone { get; set; }

        public int refhosp_id { get; set; }

        public int dep_id { get; set; }

        [Required]
        [StringLength(20)]
        public string cardnumber { get; set; }

        [Required]
        [StringLength(255)]
        public string firstdiagnosis { get; set; }

        [Required]
        [StringLength(255)]
        public string seconddiagnosis { get; set; }

        public DateTime? discharge { get; set; }

        public int? transferhosp_id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string reject { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string employed { get; set; }

        public virtual areas areas { get; set; }

        public virtual cities cities { get; set; }

        public virtual departaments departaments { get; set; }

        public virtual hospitals hospitals { get; set; }

        public virtual hospitals hospitals1 { get; set; }

        public virtual regions regions { get; set; }
    }
}
