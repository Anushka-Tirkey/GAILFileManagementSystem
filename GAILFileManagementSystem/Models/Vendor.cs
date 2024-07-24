using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAILFileManagementSystem.Models
{
    public class Vendor
    {
        [Key]   //Specifies that VENDOR_ID is a primary key
        public int VENDOR_ID { get; set; } // Unique identifier for the vendor

        [Column("VENDOR_NAME", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Vendor name is required")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string VENDOR_NAME { get; set; } // Name of the vendor

        [Column("VENDOR_ADDRESS", TypeName = "varchar(200)")]
        public string VENDOR_ADDRESS { get; set; }

        [Column("CONTACT_PERSON", TypeName = "varchar(100)")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string CONTACT_PERSON { get; set; } // Contact person at the vendor

        [Column("CONTACT_NUMBER", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Contact Number is required")]
        //[Range(1000000000, 9999999999, ErrorMessage = "Enter valid contact number")]
        [MaxLength(10)]
        //[RegularExpression(@"^((\\+91)|(0092))-{0,1}\\d{3}-{0,1}\\d{7}$|^\\d{11}$|^\\d{4}-\\d{7}$")]
        public string CONTACT_NUMBER { get; set; } // Contact number of the vendor

        [Column("CONTACT_EMAIL", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Contact Email is required")] // Provide a meaningful error message here
        [EmailAddress]  // not much preferred because Eg: adil123@gmail will be accepted as valid email
        public string CONTACT_EMAIL { get; set; }

        public List<Files> Files { get; set; }

        //[Column("CONTACT_EMAIL", TypeName = "varchar(100)")] 
        //public string STATUS { get; set; }
        //public int UploadFiles { get; set; }
        //// Models validation is applied on the properties

        // Constructor
        //public Vendor()
        //{
        //    // Initialize properties with default values if needed
        //    VENDOR_ID = 0;
        //    VENDOR_NAME = "";
        //    VENDOR_ADDRESS = "";
        //    CONTACT_PERSON = "";
        //    CONTACT_NUMBER = "";
        //    CONTACT_EMAIL = "";
        //}
    }
}
