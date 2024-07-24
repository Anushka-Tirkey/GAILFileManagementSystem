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
        public int FILE_ID { get; set; }

        [Column("FILE_NAME", TypeName = "varchar(255)")]
        public string FILE_NAME { get; set; }

        [Column("FILE_TYPE", TypeName = "varchar(20)")]
        public FILE_TYPE FILE_TYPE { get; set; }

        [Column("DESCRIPTION", TypeName = "varchar(100)")]
        public string DESCRIPTION { get; set; }

        [Column("OPEN_DATE", TypeName = "datetime")]
        [Required(ErrorMessage = "Open Date is required.")]
        public DateTime OPEN_DATE { get; set; }

        [Column("CLOSED_DATE", TypeName = "datetime")]
        [Required(ErrorMessage = "Closed Date is required.")]
        public DateTime CLOSED_DATE { get; set; }

        [Required(ErrorMessage = "STATUS is required.")]
        [Column("STATUS", TypeName = "varchar(100)")]
        public string STATUS { get; set; }

        public void SetFileName()
        {
            FILE_NAME = $"{FILE_TYPE.ToString().Substring(0, 3)}/{OPEN_DATE:yyyy-MM-dd}/{VENDOR_NAME}/{CONTRACT_NUMBER}/{FILE_ID}";
        }
        /*Two ways of creating foreign kets:
        1. Navigation Properties
        2. Entity Framework API emthods*/


        // Foreign key for Contract
        //public int Contract_Id { get; set; }
        public int SNO { get; set; }
        public Contract Contract { get; set; }  //Ref nav property; reference to Contract table;
        // MANY-TO-ONE -> multiple Files may belong to same Contract

        //CONTRACT DETAILS:
        [Required(ErrorMessage = "Contract Number is required.")]
        public string CONTRACT_NUMBER { get; set; }

        public string CONTRACT_SUBJECT { get; set; }    //? -> It may contain null values
        public string CONTRACT_DESCRIPTION { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public CType CONTRACT_TYPE { get; set; }
        public enum CType
        {
            Local, Centralised
        }

        // Foreign key for Vendor
        public int VENDOR_ID { get; set; } // Unique identifier for the vendor
        public Vendor Vendor { get; set; }      //Ref nav property; reference to Vendor table; one-to-many
        //MANY-TO-ONE -> multiple Files may belong to same Vendor

        //VENDOR DETAILS

        [Column("VENDOR_NAME", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Vendor name is required")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string VENDOR_NAME { get; set; } // Name of the vendor

        [Column("VENDOR_ADDRESS", TypeName = "varchar(200)")]
        public string VENDOR_ADDRESS { get; set; }

        [Column("CONTACT_PERSON", TypeName = "varchar(100)")]
        public string CONTACT_PERSON { get; set; } // Contact person at the vendor

        [Column("CONTACT_NUMBER", TypeName = "varchar(100)")]
        public string CONTACT_NUMBER { get; set; } // Contact number of the vendor

        [Column("CONTACT_EMAIL", TypeName = "varchar(100)")]
        public string CONTACT_EMAIL { get; set; }

        // Foreign key for Location
        public int LOCATION_ID { get; set; } // Unique identifier for the vendor
        public Location Location { get; set; }      //Ref nav property; reference to Location table; one-to-many
                                                    //MANY-TO-ONE -> multiple Files may reside in the same location

        //LOCATION DETAILS
        public string LOCATION_NAME { get; set; } = string.Empty;
        public int SUBLOCATION_ID { get; set; }
        public string SUBLOCATION_NAME { get; set; } = string.Empty;
        public int GSTN_NO { get; set; }
    }

    public enum FILE_TYPE
    {
        MISCELLANEOUS, APPROVAL, WARRANTY, AMC
    }
}