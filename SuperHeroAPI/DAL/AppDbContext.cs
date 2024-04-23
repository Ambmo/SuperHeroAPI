namespace SuperheroAPI.DAL
{
    using Microsoft.EntityFrameworkCore;
    using SuperHeroAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //public DbSet<Superhero> Superheroes { get; set; }
        //TODO can be used later for storing some superHeros or most hitted in Search even!
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignore the Superhero entity
            modelBuilder.Ignore<Superhero>();

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Favorite>()
            //    .HasKey(f => new { f.UserId, f.SuperheroId });

            //modelBuilder.Entity<Favorite>()
            //    .HasOne(f => f.Superhero)
            //    .WithMany()
            //    .HasForeignKey(f => f.SuperheroId);
        }

    }
}
