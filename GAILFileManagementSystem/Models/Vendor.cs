using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAILFileManagementSystem.Models
{
    public class Vendor
    {
        [Key] // Specifies that VENDOR_ID is a primary key
        public int VENDOR_ID { get; set; } // Unique identifier for the vendor

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
        [MaxLength(10)]
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

        public List<Files> Files { get; set; }
    }
}
