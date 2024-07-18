using GAILFileManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {

        }
        public DbSet<Files> Files { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<GAILFileManagementSystem.Models.ConsolidatedReportViewModel> ConsolidatedReportViewModel { get; set; }
    }
}
