using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FILESMGMT.Models
{
    public class Vendor
    {
        //The [Required] attribute and other validation techniques are not working here
        [Key]
        public int VendorId { get; set; } // Unique identifier for the vendor

        [Column("vendorname", TypeName ="varchar(100)")]
        [Required] public string VendorName { get; set; } // Name of the vendor
        
        [Column("vendoraddress", TypeName = "varchar(200)")]
        [Required] public string VendorAddress { get; set; }

        [Column("contactperson", TypeName = "varchar(100)")]
        [Required] public string ContactPerson { get; set; } // Contact person at the vendor
        
        [Column("contactno", TypeName = "varchar(100)")]
        [Required] public string ContactNumber { get; set; } // Contact number of the vendor


        [Column("contactemail", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Email is must")]
        [EmailAddress]
        public string ContactEmailId { get; set; }
        
        //[Column("ContactEmailId", TypeName = "varchar(100)")] 
        //public string Status { get; set; }
        //public int UploadFiles { get; set; }
        ////Models validation is applied on the properties

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