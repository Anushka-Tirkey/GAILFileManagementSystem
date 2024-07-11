using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;

namespace FILESMGMT.Models
{
    public class ContractDBContext: DbContext
    {
        public ContractDBContext(DbContextOptions<ContractDBContext> options) : base(options)
        {
            //options parameter-> carries important info such as connection string, database provider, etc
            //this 'options' parameter is passed in the base class' constructor too
            //base keyword -> used to call the constructor of the parent (=DbContext) class
        }

        public DbSet<Contract> Contracts { get; set; } //Represents the database
        //the name of our database will be 'Contracts'
    }
}
