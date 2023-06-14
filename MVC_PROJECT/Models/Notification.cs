namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        public int Id_N { get; set; }

        public int Id_To { get; set; }

        [Required]
        public string ReplyText { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
