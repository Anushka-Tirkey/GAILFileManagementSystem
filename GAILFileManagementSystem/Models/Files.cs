using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FILESMGMT.Models
{
    public class Files
    {
        [Key]
        public int FileId { get; set; }

        [Column("File_Name", TypeName = "varchar(255)")]
        public string FileName { get; set; }

        [Column("File_Type", TypeName = "varchar(20)")]
        public File_type File_type { get; set; }

        [Column("Description", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "File description is required.")]
        public string Description { get; set; }

        [Column("Open_Date", TypeName = "datetime")]
        [Required(ErrorMessage = "Open Date is required.")]
        public DateTime Open_Date { get; set; }

        [Column("Closed_Date", TypeName = "datetime")]
        [Required(ErrorMessage = "Closed Date is required.")]
        public DateTime Closed_Date { get; set; }

        /*Two ways pf creating foreign kets:
        1. Navigation Properties
        2. Entity Framework API emthods*/


        // Foreign key for Contract
        //public int Contract_Id { get; set; }
        public int sno { get; set; }
        public Contract Contract { get; set; }  //Ref nav property; reference to Contract table;
        // MANY-TO-ONE -> multiple Files may belong to same Contract

        // Foreign key for Vendor
        public int VendorId { get; set; } // Unique identifier for the vendor
        public Vendor Vendor { get; set; }      //Ref nav property; reference to Vendor table; one-to-many
        //MANY-TO-ONE -> multiple Files may belong to same Vendor


        /*[Column("ContractNumber", TypeName = "int")]
        [Required(ErrorMessage = "Contract number is required.")]*/
        [Required(ErrorMessage = "Contract Number is required.")]
        public string ContractNumber { get; set; }
        //public int ContractNumber { get; set; }

        //[Column("VendorName", TypeName = "varchar(100)")]
        //[StringLength(15, MinimumLength = 3, ErrorMessage = "Vendor name must be between 3 and 15 characters.")]
        //public string VendorName { get; set; }

        /*[Column("vendorname", TypeName = "varchar(100)")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Vendor name must be between 3 and 15 characters.")]
        public string VendorName { get; set; } // Name of the vendor


        //[Column("VendorAddress", TypeName = "varchar(100)")]
        //[Required]
        //public string VendorAddress { get; set; }
        [Column("vendoraddress", TypeName = "varchar(200)")]
        [Required]
        public string VendorAddress { get; set; }*/

        [Column("vendorname", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Vendor name is required")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string VendorName { get; set; } // Name of the vendor

        [Column("vendoraddress", TypeName = "varchar(200)")]
        public string VendorAddress { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Column("Status", TypeName = "varchar(100)")]
        public string Status { get; set; }

        public void SetFileName()
        {
            FileName = $"{File_type.ToString().Substring(0, 3)}/{Open_Date:yyyy-MM-dd}/{VendorName}/{ContractNumber}/{FileId}";
        }
    }

    public enum File_type
    {
        Miscellaneous, Approval, Warranty, AMC
    }
}