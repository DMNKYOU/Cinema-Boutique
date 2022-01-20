using CinemaBoutique.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaBoutique.DAL.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cinema> Cinemas { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<FilmStrip> FilmStrips { get; set; } = default!;

        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.FilmStrips)
                .WithMany(s => s.Cinemas)
                .UsingEntity<CinemaFilmStrip>(j => j
                        .HasOne(pt => pt.FilmStrip)
                        .WithMany(t => t.CinemaFilmStrips)
                        .HasForeignKey(pt => pt.FilmStripId),
                    j => j
                        .HasOne(pt => pt.Cinema)
                        .WithMany(p => p.CinemaFilmStrips)
                        .HasForeignKey(pt => pt.CinemaId),
                    j =>
                    {
                        j.Property(pt => pt.Title);
                        j.Property(pt => pt.SessionPrice);
                        j.Property(pt => pt.ShowDate);
                        j.Property(pt => pt.Id);
                        j.HasKey(t => new { t.CinemaId, t.FilmStripId, t.Id });
                        j.ToTable("CinemaFilmStrip");
                    });

            modelBuilder.Seed();
        }
    }
}
