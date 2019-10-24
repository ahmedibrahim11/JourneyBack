namespace joureny.Data
{
    using joureny.Data.Entities;
    using System.Data.Entity;

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
            modelBuilder.Entity<User>().HasMany(r => r.UserTrips).WithRequired(c => c.User).HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Trip>().HasMany(r => r.UserTrips).WithRequired(t => t.Trip).HasForeignKey(r => r.TripId);

            modelBuilder.Entity<TripQuestion>().HasKey(r => new { r.QuestionId, r.TripId });
            modelBuilder.Entity<Question>().HasMany(r => r.TripQuestions).WithRequired(q => q.Question).HasForeignKey(r => r.QuestionId);
            modelBuilder.Entity<Trip>().HasMany(r => r.TripQuestions).WithRequired(t => t.Trip).HasForeignKey(r => r.TripId);



            modelBuilder.Entity<UserAnswerQuestion>().HasKey(r => new { r.QuestionId, r.UserId });
            modelBuilder.Entity<Question>().HasMany(r => r.UserAnswerQuestion).WithRequired(q => q.Question).HasForeignKey(r => r.QuestionId);
            modelBuilder.Entity<User>().HasMany(r => r.UserAnswerQuestion).WithRequired(t => t.User).HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Feedback>().HasRequired<User>(u => u.User)
                .WithMany(help => help.Feedbacks)
                .HasForeignKey<long>(u => u.UserId);
            //modelBuilder.Entity<User>().HasMany(m => m.Connections).WithMany().Map(m =>
            //{
            //    m.MapLeftKey("UserId");
            //    m.MapRightKey("ConnectionId");
            //    m.ToTable("Connections");
                
            //});
            
            //modelBuilder.Entity<User>().HasMany(m => m.Connections).WithMany().Map(cs =>
            //cs.MapLeftKey("UserId").MapRightKey("ConnectionId").ToTable("Connections"));


        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Feedback> Helps { get; set; }
        public virtual DbSet<UserTrips> UserTrips { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<TripQuestion> TripQuestions { get; set; }
        public virtual DbSet<UserAnswerQuestion> UserAnswerQuestion { get; set; }
        public virtual DbSet<UserConnection> UserConnections { get; set; }

        //public virtual DbSet<ConnectionShip> ConnectionShips { get; set; }




    }


}

