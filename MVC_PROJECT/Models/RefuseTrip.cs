namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RefuseTrip")]
    public partial class RefuseTrip
    {
        [Key]
        public int ID_Refuse { get; set; }

        [Required]
        public string reason_refuse { get; set; }

        public int Id_Org { get; set; }

        public int Id_T { get; set; }

        public virtual Organizing Organizing { get; set; }

        public virtual Trips Trips { get; set; }
    }
}
