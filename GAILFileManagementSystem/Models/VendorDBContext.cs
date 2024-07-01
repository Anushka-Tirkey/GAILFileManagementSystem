using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{
    public class VendorDBContext: DbContext  //DbContext  class -> Used to interact with our data and the database
    {
        public VendorDBContext(DbContextOptions options): base(options) //child class-> VendorDBConext, parent class-> DbContext
        {
            //options parameter-> carries important info such as cinnection string, dataabse provider, etc
            //this 'options' parameter is passed in the base class' constructor too
            //base keyword -> used ton call the constructor of the parent class
        }
        public DbSet<Vendor> Vendors { get; set; } 
    }
} 