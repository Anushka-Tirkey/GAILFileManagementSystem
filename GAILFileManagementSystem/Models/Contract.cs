using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GAILFileManagementSystem.Models
{
    public class Contract
    {
        [Key]
        public int SNO { get; set; }

        [Required(ErrorMessage = "Contract Number is required.")]
        public string CONTRACT_NUMBER { get; set; }

        public string CONTRACT_SUBJECT { get; set; }    //? -> It may contain null values

        public string CONTRACT_DESCRIPTION { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public CType CONTRACT_TYPE { get; set; }
        
        public List<Files> Files { get; set; }
        
        public enum CType
        {
            LOCAL, CENTRALISED
        }
    }

    //    // Constructor
    //    public Contract()
    //    {
    //        // Initialize properties with default values if needed
    //        CONTRACT_ID = 0;
    //        CONTRACT_NUMBER = "";
    //        ClientName = "";
    //        START_DATE = DateTime.Now;
    //        END_DATE = DateTime.Now;
    //    }
    //}
}