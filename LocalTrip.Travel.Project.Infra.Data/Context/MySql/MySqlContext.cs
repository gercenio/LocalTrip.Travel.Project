using System;
using System.IO;
using System.Linq;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocalTrip.Travel.Project.Infra.Data.Context.MySql
{
    public class MySqlContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseMySql(config.GetSection("ConnectionStrings:Connection").Value);
        }
        
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("InsertAt") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("InsertAt").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("InsertAt").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdateAt") != null))
            {
                if (entry.State == EntityState.Modified)
                    entry.Property("UpdateAt").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiAccountDto>().ToTable("apiaccount", "TripDb");
            modelBuilder.Entity<DestinationDto>().ToTable("destination", "TripDb");
            modelBuilder.Entity<PeopleDto>().ToTable("people", "TripDb");
            modelBuilder.Entity<PeopleAccountDto>().ToTable("peopleaccount", "TripDb");
            modelBuilder.Entity<CartDto>().ToTable("cart", "TripDb");
            modelBuilder.Entity<CartItemDto>().ToTable("cartitem", "TripDb");
            modelBuilder.Entity<PeopleContactDto>().ToTable("peoplecontact", "TripDb");
            modelBuilder.Entity<DestinationActivitiesDto>().ToTable("destinationactivities", "TripDb");
            
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<ApiAccountDto> ApiAccount { get; set; }
        public DbSet<DestinationDto> Destination { get; set; }
        public DbSet<PeopleDto> People { get; set; }
        public DbSet<PeopleContactDto> PeopleContact { get; set; }
        public DbSet<CartDto> Cart { get; set; }
        public DbSet<CartItemDto> CartItem { get; set; }
        public DbSet<PeopleAccountDto> PeopleAccount { get; set; }
        public DbSet<DestinationActivitiesDto> DestinationActivities { get; set; }

    }
}