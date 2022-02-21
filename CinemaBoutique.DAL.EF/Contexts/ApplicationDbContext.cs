using System;
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
        public DbSet<FilmSession> FilmSession { get; set; } = default!;
        public new DbSet<User> Users { get; set; } = default!;
        public new DbSet<Ticket> Tickets { get; set; } = default!;

        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.FilmStrips)
                .WithMany(s => s.Cinemas)
                .UsingEntity<FilmSession>(j => j
                        .HasOne(pt => pt.FilmStrip)
                        .WithMany(t => t.FilmSessions)
                        .HasForeignKey(pt => pt.FilmStripId),
                    j => j
                        .HasOne(pt => pt.Cinema)
                        .WithMany(p => p.FilmSessions)
                        .HasForeignKey(pt => pt.CinemaId),
                    j =>
                    {
                        j.Property(pt => pt.SessionPrice).HasDefaultValue(10);
                        j.Property(pt => pt.ShowDate).HasDefaultValue(DateTime.Now);
                        j.Property(pt => pt.Id);
                        j.HasKey(t => new { t.Id });
                        j.ToTable("FilmSession");
                    });

            modelBuilder.Seed();
        }
    }
}
