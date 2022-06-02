using api_dependency_injection.Models;
using Microsoft.EntityFrameworkCore;

namespace api_dependency_injection
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
