using System;
using System.ComponentModel.DataAnnotations;

namespace GAILFileManagementSystem.Models
{
    public class ConsolidatedReportViewModel
    {
        //File details
        public Files Files { get; set; }
        [Key] public int FILE_ID { get; set; }
        public string FILE_NAME { get; set; }
        public string FILE_TYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime OPEN_DATE { get; set; }
        public DateTime CLOSED_DATE { get; set; }
        public string FILE_STATUS { get; set; }

        // Vendor Details
        public Vendor Vendor { get; set; }
        public int VENDOR_ID { get; set; }
        public string VENDOR_NAME { get; set; }
        public string VENDOR_ADDRESS { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string CONTACT_NUMBER { get; set; }
        public string CONTACT_EMAIL { get; set; }

        // Contract Details
        public Contract Contract { get; set; }
        public int CONTRACT_ID { get; set; }
        public string CONTRACT_NUMBER { get; set; }
        public string CONTRACT_SUBJECT { get; set; }
        public string CONTRACT_DESCRIPTION { get; set; }
        public DateTime CONTRACT_START_DATE { get; set; }
        public DateTime CONTRACT_END_DATE { get; set; }
        public string CONTRACT_TYPE { get; set; }

        // Location Details
        public Location Location { get; set; } 
        public int LOCATION_ID { get; set; }
        public string LOCATION_NAME { get; set; }
        public int SUBLOCATION_ID { get; set; }
        public string SUBLOCATION_NAME { get; set; }
        public int GSTN_NO { get; set; }
    }
}
