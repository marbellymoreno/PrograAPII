using Microsoft.EntityFrameworkCore;

namespace PrograAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Producto> Productos { get; set; }
    }
}