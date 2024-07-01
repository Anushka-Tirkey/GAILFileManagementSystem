using System;
using System.ComponentModel.DataAnnotations;

namespace GAILFileManagementSystem.Models
{
    public class Contract
    {
        [Required(ErrorMessage = "Contract Number is required.")]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "Contract Subject is required.")]
        public string ContractSubject { get; set; }

        // Other properties without [Required] attributes
        public string ContractDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CType ContractType { get; set; }

        public enum CType
        {
            Local, Centralised
        }
    }

    //public class Contract
    //{
    //    // Properties
    //    public int ContractId { get; set; } // Unique identifier for the contract

    //    [Required]
    //    public string ContractNumber { get; set; } // Contract number

    //    [Required]
    //    public string ContractSubject { get; set; }
    //    public string ContractDescription { get; set; }
    //    [Required] public string ClientName { get; set; } // Name of the client associated with the contract
    //    public DateTime StartDate { get; set; } // Start date of the contract
    //    public DateTime EndDate { get; set; } // End date of the contract
    //    public CType ContractType { get; set; }

    //    public enum CType
    //    {
    //        Local, Centralised
    //    }

    //    // Constructor
    //    public Contract()
    //    {
    //        // Initialize properties with default values if needed
    //        ContractId = 0;
    //        ContractNumber = "";
    //        ClientName = "";
    //        StartDate = DateTime.Now;
    //        EndDate = DateTime.Now;
    //    }
    //}
}