using System;

namespace FILESMGMT.Models
{
    public class Files
    {
        // Properties
        public int FileId { get; set; } // Unique identifier for the file
        public string FileName { get; set; } // Name of the file
        public File_type File_type { get; set; }
        public string? Description { get; set; }
        public long FileSize { get; set; } // Size of the file in bytes
        public DateTime UploadDate { get; set; } // Date and time when the file was uploaded
        public int Contract_No { get; set; } 
        public string Vendor_name { get; set; }
        public string Vendor_address { get; set; }
        public string? FilePath { get; set; } // Add this property
        public string Status { get; set; }

        // Constructor
        public Files()
        {
            // Initialize properties with default values if needed
            FileId = 0;
            FileName = "";
            FileSize = 0;
            UploadDate = DateTime.Now;
            //EmployeeId = 0;
            //ApprovalStatus = "Pending";
        }

    }
    public enum File_type
    {
        Miscellaneous, Approval, Warranty, AMC
    }

}
