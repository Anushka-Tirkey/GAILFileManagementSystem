using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAILFileManagementSystem.Models
{
    public class Files
    {

        //FILE DETAILS

        [Key]
        public int FileId { get; set; }

        [Column("File_Name", TypeName = "varchar(255)")]
        public string FileName { get; set; }

        [Column("File_Type", TypeName = "varchar(20)")]
        public File_type File_type { get; set; }

        [Column("Description", TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column("Open_Date", TypeName = "datetime")]
        [Required(ErrorMessage = "Open Date is required.")]
        public DateTime Open_Date { get; set; }

        [Column("Closed_Date", TypeName = "datetime")]
        [Required(ErrorMessage = "Closed Date is required.")]
        public DateTime Closed_Date { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Column("Status", TypeName = "varchar(100)")]
        public string Status { get; set; }

        public void SetFileName()
        {
            FileName = $"{File_type.ToString().Substring(0, 3)}/{Open_Date:yyyy-MM-dd}/{VendorName}/{ContractNumber}/{FileId}";
        }
        /*Two ways of creating foreign kets:
        1. Navigation Properties
        2. Entity Framework API emthods*/


        // Foreign key for Contract
        //public int Contract_Id { get; set; }
        public int sno { get; set; }
        public Contract Contract { get; set; }  //Ref nav property; reference to Contract table;
        // MANY-TO-ONE -> multiple Files may belong to same Contract

        //CONTRACT DETAILS:
        [Required(ErrorMessage = "Contract Number is required.")]
        public string ContractNumber { get; set; }

        public string ContractSubject { get; set; }    //? -> It may contain null values
        public string ContractDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CType ContractType { get; set; }
        public enum CType
        {
            Local, Centralised
        }

        // Foreign key for Vendor
        public int VendorId { get; set; } // Unique identifier for the vendor
        public Vendor Vendor { get; set; }      //Ref nav property; reference to Vendor table; one-to-many
        //MANY-TO-ONE -> multiple Files may belong to same Vendor

        //VENDOR DETAILS

        [Column("vendorname", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Vendor name is required")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string VendorName { get; set; } // Name of the vendor

        [Column("vendoraddress", TypeName = "varchar(200)")]
        public string VendorAddress { get; set; }

        [Column("contactperson", TypeName = "varchar(100)")]
        public string ContactPerson { get; set; } // Contact person at the vendor

        [Column("contactno", TypeName = "varchar(100)")]
        public string ContactNumber { get; set; } // Contact number of the vendor

        [Column("contactemail", TypeName = "varchar(100)")]
        public string ContactEmailId { get; set; }

        // Foreign key for Location
        public int LocationId { get; set; } // Unique identifier for the vendor
        public Location Location { get; set; }      //Ref nav property; reference to Location table; one-to-many
                                                    //MANY-TO-ONE -> multiple Files may reside in the same location

        //LOCATION DETAILS
        public string LocationName { get; set; } = string.Empty;
        public int SubLocationID { get; set; }
        public string SubLocationName { get; set; } = string.Empty;
        public int GSTN_No { get; set; }
    }

    public enum File_type
    {
        Miscellaneous, Approval, Warranty, AMC
    }
}