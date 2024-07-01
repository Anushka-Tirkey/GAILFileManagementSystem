using System;

namespace FILESMGMT.Models
{
    public class Files
    {
        // Properties
        public int FileId { get; set; } // Unique identifier for the file
        public string FileName { get; set; } // Name of the file
        public string FileType { get; set; } // Type of the file (e.g., image/jpeg, application/pdf)
        public long FileSize { get; set; } // Size of the file in bytes
        public DateTime UploadDate { get; set; } // Date and time when the file was uploaded
        public int EmployeeId { get; set; } // Employee ID of the user who uploaded the file
        public string ApprovalStatus { get; set; } // Approval status of the file (e.g., pending, approved, rejected)
        public string? FilePath { get; set; } // Add this property
        

        // Constructor
        public Files()
        {
            // Initialize properties with default values if needed
            FileId = 0;
            FileName = "";
            FileType = "";
            FileSize = 0;
            UploadDate = DateTime.Now;
            EmployeeId = 0;
            ApprovalStatus = "Pending";
        }
    }
}
