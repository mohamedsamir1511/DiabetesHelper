using DiabetesHelper.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 namespace DiabetesHelper.DAL
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<GlucoseReading> GlucoseReadings { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Alerts)
                .WithOne(A => A.User);
            modelBuilder.Entity<User>()
                .HasMany(U => U.GlucoseReadings)
                .WithOne(GR => GR.User);
        }
    }


}

