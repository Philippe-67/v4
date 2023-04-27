using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using v4.Models;

namespace v4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voiture>? Voitures { get; set; }
        public DbSet<Reparation>? Reparations { get; set; }
        public DbSet<v4.Models.Interventions>? Interventions { get; set; }
        
    }
}