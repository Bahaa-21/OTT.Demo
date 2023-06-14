namespace MVC_PROJECT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Breaks> Breaks { get; set; }
        public virtual DbSet<ClassificationTrips> ClassificationTrips { get; set; }
        public virtual DbSet<Complaints> Complaints { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Organizing> Organizing { get; set; }
        public virtual DbSet<PhotoTrips> PhotoTrips { get; set; }
        public virtual DbSet<RefuseTrip> RefuseTrip { get; set; }
        public virtual DbSet<Trips> Trips { get; set; }
        public virtual DbSet<TripsDetails> TripsDetails { get; set; }
        public virtual DbSet<TripsStation> TripsStation { get; set; }
        public virtual DbSet<Evalution> Evalution { get; set; }
        public virtual DbSet<TripsCustomer> TripsCustomer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breaks>()
                .HasMany(e => e.TripsStation)
                .WithRequired(e => e.Breaks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassificationTrips>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.ClassificationTrips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Complaints)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Evalution)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Notification)
                .WithRequired(e => e.Customers)
                .HasForeignKey(e => e.Id_To)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.TripsCustomer)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organizing>()
                .HasMany(e => e.RefuseTrip)
                .WithRequired(e => e.Organizing)
                .HasForeignKey(e => e.Id_Org)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organizing>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.Organizing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trips>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trips>()
                .HasMany(e => e.Admin)
                .WithOptional(e => e.Trips)
                .HasForeignKey(e => e.IdTrip);

            modelBuilder.Entity<Trips>()
                .HasMany(e => e.PhotoTrips)
                .WithRequired(e => e.Trips)
                .HasForeignKey(e => e.ID_Trips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trips>()
                .HasMany(e => e.RefuseTrip)
                .WithRequired(e => e.Trips)
                .HasForeignKey(e => e.Id_T)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trips>()
                .HasMany(e => e.TripsCustomer)
                .WithRequired(e => e.Trips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trips>()
                .HasMany(e => e.Evalution)
                .WithRequired(e => e.Trips)
                .HasForeignKey(e => e.Id_Trips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trips>()
                .HasMany(e => e.TripsStation)
                .WithRequired(e => e.Trips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TripsDetails>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.TripsDetails)
                .HasForeignKey(e => e.ID_Region)
                .WillCascadeOnDelete(false);
        }
    }
}
