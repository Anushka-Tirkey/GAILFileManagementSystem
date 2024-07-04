using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;

namespace GAILFileManagementSystem.Models
{
    public class VendorDBContext: DbContext  //DbContext  class -> Used to interact with our data and the database
    {
        //The VendorDBContext class (=child class) inherits from the Dbcontext class (=parent class)
        public VendorDBContext(DbContextOptions options): base(options)
        {
            //options parameter-> carries important info such as cinnection string, dataabse provider, etc
            //this 'options' parameter is passed in the base class' constructor too
            //base keyword -> used to call the constructor of the parent (=DbContext) class
        }
        public DbSet<Vendor> Vendors { get; set; } //Represents the database
        //the name of our database will be 'Students'
    }
} 