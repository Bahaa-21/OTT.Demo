namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Complaints
    {
        [Key]
        public int Id_Complaint { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateComplaint { get; set; }

        [Required]
        public string DescraptionComplaint { get; set; }

        public int ID_Customer { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
