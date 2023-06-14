namespace MVC_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organizing")]
    public partial class Organizing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizing()
        {
            RefuseTrip = new HashSet<RefuseTrip>();
            Trips = new HashSet<Trips>();
        }

        [Key]
        public int ID_Organizer { get; set; }

        [Required]
        [StringLength(50)]
        public string UserNameOrg { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailOrg { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(6)]
        public string PasswordOrg { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        //[Compare("PasswordOrg",ErrorMessage ="The password and confirm password do not match")]
        public string RePassword { get; set; }
        //[RegularExpression(@"^([0-9]{10}$", ErrorMessage ="Invalid mobile number")]
        public string MobilePhoneOrg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefuseTrip> RefuseTrip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trips> Trips { get; set; }
    }
}
