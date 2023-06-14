namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            Complaints = new HashSet<Complaints>();
            Evalution = new HashSet<Evalution>();
            Notification = new HashSet<Notification>();
            TripsCustomer = new HashSet<TripsCustomer>();
        }

        [Key]
        public int ID_Customer { get; set; }

        [Required]
        [StringLength(50)]
        public string UserNameC { get; set; }

        [Required]
        public string EmailCustomer { get; set; }

        [Required]
        public string PasswordCustomer { get; set; }

        [Required]
        public string MobilePhoneC { get; set; }

        public string RepasswordC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaints> Complaints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evalution> Evalution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notification { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripsCustomer> TripsCustomer { get; set; }
    }
}
