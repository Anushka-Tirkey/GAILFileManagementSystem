using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;

namespace FILESMGMT.Models
{
    public class LocationDBContext : DbContext
    {
        public LocationDBContext(DbContextOptions<LocationDBContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }

    }
}
