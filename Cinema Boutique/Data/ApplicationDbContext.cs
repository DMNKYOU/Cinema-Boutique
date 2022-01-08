using CinemaBoutique.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_Boutique.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cinema> Tickets { get; set; }// = default!;

        public ApplicationDbContext() : base()
        {
            //Database.EnsureDeleted();   
            //Database.EnsureCreated();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Actor>()
            //    .HasOne(b => b.Departure)
            //    .WithMany(a => a.Voyages)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }
    }
}
