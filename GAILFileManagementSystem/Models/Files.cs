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
        private string _contractNumber;
        public string CONTRACT_NUMBER
        {
            get => _contractNumber;
            set => _contractNumber = value?.ToUpper();
        }

        private string _contractSubject;
        public string CONTRACT_SUBJECT
        {
            get => _contractSubject;
            set => _contractSubject = value?.ToUpper();
        }

        private string _contractDescription;
        public string CONTRACT_DESCRIPTION
        {
            get => _contractDescription;
            set => _contractDescription = value?.ToUpper();
        }

        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }

        public CType CONTRACT_TYPE { get; set; }
        public enum CType
        {
            LOCAL,
            CENTRALISED
        }

        // Foreign key for Vendor
        public int VENDOR_ID { get; set; } // Unique identifier for the vendor
        public Vendor Vendor { get; set; }      //Ref nav property; reference to Vendor table; one-to-many
        //MANY-TO-ONE -> multiple Files may belong to same Vendor

        //VENDOR DETAILS

        [Column("VENDOR_NAME", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Vendor name is required")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        private string _vendorName;
        public string VENDOR_NAME
        {
            get => _vendorName;
            set => _vendorName = value?.ToUpper() ?? string.Empty;
        }

        [Column("VENDOR_ADDRESS", TypeName = "varchar(200)")]
        private string _vendorAddress;
        public string VENDOR_ADDRESS
        {
            get => _vendorAddress;
            set => _vendorAddress = value?.ToUpper() ?? string.Empty;
        }

        [Column("CONTACT_PERSON", TypeName = "varchar(100)")]
        [MinLength(5, ErrorMessage = "Contact person name should contain at least 5 characters")]
        private string _contactPerson;
        public string CONTACT_PERSON
        {
            get => _contactPerson;
            set => _contactPerson = value?.ToUpper() ?? string.Empty;
        }

        [Column("CONTACT_NUMBER", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Contact Number is required")]
        [MaxLength(10)]
        private string _contactNumber;
        public string CONTACT_NUMBER
        {
            get => _contactNumber;
            set => _contactNumber = value?.ToUpper() ?? string.Empty;
        }

        [Column("CONTACT_EMAIL", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Contact Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string CONTACT_EMAIL { get; set; }

        // Foreign key for Location
        public int L_ID { get; set; } // Unique identifier for the vendor
        public Location Location { get; set; }      //Ref nav property; reference to Location table; one-to-many
                                                    //MANY-TO-ONE -> multiple Files may reside in the same location

        //LOCATION DETAILS
        public int LOCATION_ID { get; set; }

        private string _locationName;
        public string LOCATION_NAME
        {
            get => _locationName;
            set => _locationName = value?.ToUpper() ?? string.Empty;
        }

        public int SUBLOCATION_ID { get; set; }

        private string _sublocationName;
        public string SUBLOCATION_NAME
        {
            get => _sublocationName;
            set => _sublocationName = value?.ToUpper() ?? string.Empty;
        }
        public int GSTN_NO { get; set; }
    }

    public enum FILE_TYPE
    {
        MISCELLANEOUS, APPROVAL, WARRANTY, AMC
    }
}