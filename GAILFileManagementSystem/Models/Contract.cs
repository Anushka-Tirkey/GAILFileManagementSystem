using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GAILFileManagementSystem.Models
{
    public class Contract
    {
        [Key]
        public int sno { get; set; }

        [Required(ErrorMessage = "Contract Number is required.")]
        public string ContractNumber { get; set; }

        public string ContractSubject { get; set; }    //? -> It may contain null values

        public string ContractDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CType ContractType { get; set; }

        public enum CType
        {
            Local, Centralised
        }
    }

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