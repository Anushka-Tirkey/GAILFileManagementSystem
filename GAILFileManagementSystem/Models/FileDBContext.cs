using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{
    public class FileDBContext : DbContext
    {
        public FileDBContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Files> File { get; set; }

    }
}
