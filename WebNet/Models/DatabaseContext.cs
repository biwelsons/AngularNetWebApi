using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebNet.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}