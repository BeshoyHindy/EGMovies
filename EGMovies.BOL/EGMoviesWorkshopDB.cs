namespace EGMovies.BOL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EGMoviesWorkshopDB : DbContext
    {
        public EGMoviesWorkshopDB()
            : base("name=EGMoviesWorkshopDB")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<CinemaGroup> CinemaGroups { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Movies)
                .WithMany(e => e.Actors)
                .Map(m => m.ToTable("MoviesActors").MapLeftKey("ActorId").MapRightKey("MovieId"));
        }
    }
}
