namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripsCustomer")]
    public partial class TripsCustomer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Trip { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Customer { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Participation_Date { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Participation_State { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Trips Trips { get; set; }
    }
}
