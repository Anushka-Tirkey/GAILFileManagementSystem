using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAILFileManagementSystem.Models
{
    public class Contract
    {
        [Key]
        public int SNO { get; set; }

        [Required(ErrorMessage = "Contract Number is required.")]
        private string _contractNumber;
        public string CONTRACT_NUMBER
        {
            get => _contractNumber;
            set => _contractNumber = value?.ToUpper();
        }

        private string _contractSubject;
        public string CONTRACT_SUBJECT
        {
            get => _contractSubject;
            set => _contractSubject = value?.ToUpper();
        }

        private string _contractDescription;
        public string CONTRACT_DESCRIPTION
        {
            get => _contractDescription;
            set => _contractDescription = value?.ToUpper();
        }

        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }

        public CType CONTRACT_TYPE { get; set; }

        public List<Files> Files { get; set; }

        public enum CType
        {
            LOCAL,
            CENTRALISED
        }
    }
}


/*using System;
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
}*/