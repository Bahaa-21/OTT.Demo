namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trips
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trips()
        {
            Admin = new HashSet<Admin>();
            PhotoTrips = new HashSet<PhotoTrips>();
            RefuseTrip = new HashSet<RefuseTrip>();
            TripsCustomer = new HashSet<TripsCustomer>();
            Evalution = new HashSet<Evalution>();
            TripsStation = new HashSet<TripsStation>();
        }

        [Key]
        public int ID_Trip { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        [Required]
        [MinLength(10)]
        public string Descripition { get; set; }

        public DateTime T_Announcement_Time { get; set; }

        [Required]
        [StringLength(50)]
        public string Distance { get; set; }


        public int Number_of_passengers { get; set; }

        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        [Range(100, 1000000)]
        public decimal Price { get; set; }

        public int ID_Class { get; set; }

        public int ID_Organizer { get; set; }

        [Required]
        [StringLength(50)]
        public string Start_Location { get; set; }

        public int ID_Region { get; set; }

        public string Trip_Durtion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admin { get; set; }

        public virtual ClassificationTrips ClassificationTrips { get; set; }

        public virtual Organizing Organizing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoTrips> PhotoTrips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefuseTrip> RefuseTrip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripsCustomer> TripsCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evalution> Evalution { get; set; }

        public virtual TripsDetails TripsDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripsStation> TripsStation { get; set; }
    }
}
