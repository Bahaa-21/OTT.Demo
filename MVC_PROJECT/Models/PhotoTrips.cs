namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhotoTrips
    {
        [Key]
        [Column("ID-PhotoTrips")]
        public int ID_PhotoTrips { get; set; }

        [Column("ID-Trips")]
        public int ID_Trips { get; set; }

        [Required]
        public string Photo_Trips { get; set; }

        public virtual Trips Trips { get; set; }
    }
}
