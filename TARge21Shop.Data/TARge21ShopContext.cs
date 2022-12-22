using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Domain.Spaceship;

namespace TARge21Shop.Data
{
    public class TARge21ShopContext : DbContext
    {
        public TARge21ShopContext(DbContextOptions<TARge21ShopContext> options) :
            base(options)
        {

        }

        public DbSet<Spaceship> Spaceships { get; set; }

        public DbSet<FileToDatabase> FileToDatabases { get; set; }
    }
}
