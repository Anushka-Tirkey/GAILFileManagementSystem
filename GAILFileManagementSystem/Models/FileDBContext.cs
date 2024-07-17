using GAILFileManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{
    public class FileDBContext : DbContext
    {
        public FileDBContext(DbContextOptions<FileDBContext> options) : base(options)
        {
                
        }
        public DbSet<Files> Files { get; set; }

    }
}
