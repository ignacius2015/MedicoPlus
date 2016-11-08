namespace MedicoPlus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hosp.online")]
    public partial class online
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public virtual users users { get; set; }
    }
}
