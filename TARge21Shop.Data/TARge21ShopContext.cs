using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.Domain.Car;

namespace TARge21Shop.Data
{
    public class TARge21ShopContext : DbContext
    {
        public TARge21ShopContext(DbContextOptions<TARge21ShopContext> options) :
            base(options)
        {

        }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<PictureToDatabase> PictureToDatabases {get; set;}
    }
}
