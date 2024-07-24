using System;

namespace GAILFileManagementSystem.Models
{
    public class Rack
    {
        // Properties
        public int RackId { get; set; } // Unique identifier for the rack
        public string RackName { get; set; } // Name of the rack
        public DateTime CLOSED_DATE { get; set; } // Date when the rack was closed
        public string Location { get; set; } // Location of the rack

        // Constructor
        public Rack()
        {
            // Initialize properties with default values if needed
            RackId = 0;
            RackName = "";
            CLOSED_DATE = DateTime.Now;
            Location = "";
        }
    }
}

