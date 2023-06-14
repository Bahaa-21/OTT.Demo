namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int ID_Admin { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string Password { get; set; }

        public int? IdTrip { get; set; }

        [Required]
        public string Mobile { get; set; }

        public virtual Trips Trips { get; set; }
    }
}
