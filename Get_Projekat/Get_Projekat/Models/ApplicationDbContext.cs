using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Get_Projekat.Models
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Termin> termini { get; set; }
        public DbSet<Sto> stolovi { get; set; }

        public static string LogedUsername { get; set; }
    }
}
