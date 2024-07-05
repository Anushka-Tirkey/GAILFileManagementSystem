using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FILESMGMT.Models
{
    public class Files
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public File_type File_type { get; set; }

        [Required(ErrorMessage = "File description is required.")]
        public string Description { get; set; }

        public long FileSize { get; set; }

        [Required(ErrorMessage = "Open Date is required.")]
        public DateTime Open_Date { get; set; }

        [Required(ErrorMessage = "Closed Date is required.")]
        public DateTime Closed_Date { get; set; }

        [Required(ErrorMessage = "Contract number is required.")]
        public int Contract_No { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Vendor name must be between 3 and 15 characters.")]
        public string Vendor_name { get; set; }

        public string Vendor_address { get; set; }
        public string FilePath { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }

    public enum File_type
    {
        Miscellaneous, Approval, Warranty, AMC
    }
}
