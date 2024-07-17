using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FILESMGMT.Models
{
    public class Vendor
    {
        [Key]   //Specifies that VendorId is a primary key
        public int VendorId { get; set; } // Unique identifier for the vendor

        [Column("vendorname", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Vendor name is required")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string VendorName { get; set; } // Name of the vendor

        [Column("vendoraddress", TypeName = "varchar(200)")]
        public string VendorAddress { get; set; }

        [Column("contactperson", TypeName = "varchar(100)")]
        [MinLength(5, ErrorMessage = "Vendor name should contain at least 5 characters")]
        public string ContactPerson { get; set; } // Contact person at the vendor

        [Column("contactno", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Contact Number is required")]
        //[Range(1000000000, 9999999999, ErrorMessage = "Enter valid contact number")]
        [MaxLength(10)]
        //[RegularExpression(@"^((\\+91)|(0092))-{0,1}\\d{3}-{0,1}\\d{7}$|^\\d{11}$|^\\d{4}-\\d{7}$")]
        public string ContactNumber { get; set; } // Contact number of the vendor

        [Column("contactemail", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Contact Email is required")] // Provide a meaningful error message here
        [EmailAddress]  // not much preferred because Eg: adil123@gmail will be accepted as valid email
        public string ContactEmailId { get; set; }

        public List<Files> Files { get; set; }

        //[Column("ContactEmailId", TypeName = "varchar(100)")] 
        //public string Status { get; set; }
        //public int UploadFiles { get; set; }
        //// Models validation is applied on the properties

        // Constructor
        //public Vendor()
        //{
        //    // Initialize properties with default values if needed
        //    VendorId = 0;
        //    VendorName = "";
        //    VendorAddress = "";
        //    ContactPerson = "";
        //    ContactNumber = "";
        //    ContactEmailId = "";
        //}
    }
}
