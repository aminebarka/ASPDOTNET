using GestiondeLocation.Models;
using Microsoft.EntityFrameworkCore;

namespace GestiondeLocation.EF_core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}

