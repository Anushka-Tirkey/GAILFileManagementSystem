using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{    
    public class VendorModelDBContext : DbContext
    {
            public VendorModelDBContext(DbContextOptions<VendorModelDBContext> options) : base(options)
            {

            }
            public DbSet<VendorModel> VendorModels { get; set; }

    }
}
