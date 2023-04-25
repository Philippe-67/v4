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
        public DbSet<v4.Models.Voiture>? Voitures { get; set; }
        public DbSet<v4.Models.Reparation>? Reparations { get; set; }
        
    }
}