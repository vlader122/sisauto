using DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class SisautoContext : IdentityDbContext
    {
        public SisautoContext(DbContextOptions<SisautoContext> options)
            : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Paises> Paises { get; set; }
    }
}
