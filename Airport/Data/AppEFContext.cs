using Airport.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Data
{
    public class AppEFContext : DbContext
    {
        public AppEFContext(DbContextOptions<AppEFContext> options) :
             base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // IConfigurationRoot configuration = new ConfigurationBuilder()
           //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           //.AddJsonFile("appsettings.json")
           //.Build();
           // optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<FlightTicket> FlightTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (!Database.GetMigrations().Any())
            builder.Seed();
        }
    }
}
