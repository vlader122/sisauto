using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class SisautoContext : DbContext
    {
        public SisautoContext(DbContextOptions<SisautoContext> options)
            : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Paises> Paises { get; set; }
    }
}
