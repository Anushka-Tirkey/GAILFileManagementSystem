using System;

namespace FILESMGMT.Models
{
    public class Employee
    {
        // Properties
        public int EmployeeId { get; set; } // Unique identifier for the employee
        public string EmployeeName { get; set; } // Name of the employee
        public string Department { get; set; } // Department of the employee
        public string Position { get; set; } // Position of the employee

        // Constructor
        public Employee()
        {
            // Initialize properties with default values if needed
            EmployeeId = 0;
            EmployeeName = "";
            Department = "";
            Position = "";
        }
    }
}
