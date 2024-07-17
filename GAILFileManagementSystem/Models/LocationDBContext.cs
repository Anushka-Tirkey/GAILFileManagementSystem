using GAILFileManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{
    public class LocationDBContext : DbContext
    {
        public LocationDBContext(DbContextOptions<LocationDBContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }

    }
}
