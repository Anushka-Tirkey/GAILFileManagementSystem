using System;

namespace FILESMGMT.Models
{
    public class Rack
    {
        // Properties
        public int RackId { get; set; } // Unique identifier for the rack
        public string RackName { get; set; } // Name of the rack
        public DateTime ClosedDate { get; set; } // Date when the rack was closed
        public string Location { get; set; } // Location of the rack

        // Constructor
        public Rack()
        {
            // Initialize properties with default values if needed
            RackId = 0;
            RackName = "";
            ClosedDate = DateTime.Now;
            Location = "";
        }
    }
}

