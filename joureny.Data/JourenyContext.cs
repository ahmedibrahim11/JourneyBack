namespace joureny.Data
{
    using joureny.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class JourenyContext : DbContext
    {
        // Your context has been configured to use a 'JourenyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'joureny.Data.JourenyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'JourenyContext' 
        // connection string in the application configuration file.
        public JourenyContext()
            : base("name=JourenyContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrips>().HasKey(r => new { r.UserId, r.TripId });
            modelBuilder.Entity<User>().HasMany(r => r.UserTrips).WithRequired().HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Trip>().HasMany(r => r.UserTrips).WithRequired().HasForeignKey(r => r.TripId);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<UserTrips> UserTrips { get; set; }


    }


}
