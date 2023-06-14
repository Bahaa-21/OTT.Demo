namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("TripsStation")]
    public partial class TripsStation
    {
        [Key]
        public int ID_Station { get; set; }

        [Required]
        [StringLength(50)]
        public string NameBreak { get; set; }

        [Required]
        [StringLength(50)]
        public string Station_Start { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string PhotoStation { get; set; }

        [Required]
        public string DescripitionStation { get; set; }

        public int ID_Break { get; set; }

        public int ID_Trip { get; set; }

        public int? NumberStation { get; set; }

        public virtual Breaks Breaks { get; set; }

        public virtual Trips Trips { get; set; }
    }
}
