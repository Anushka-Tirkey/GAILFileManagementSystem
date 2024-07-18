using System;
using System.ComponentModel.DataAnnotations;

namespace GAILFileManagementSystem.Models
{
    public class ConsolidatedReportViewModel
    {
        [Key] public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string FileStatus { get; set; }

        // Vendor Details
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmailId { get; set; }

        // Contract Details
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public string ContractSubject { get; set; }
        public string ContractDescription { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractType { get; set; }

        // Location Details
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int SubLocationId { get; set; }
        public string SubLocationName { get; set; }
        public int GSTN_No { get; set; }
    }
}
