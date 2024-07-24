using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAILFileManagementSystem.Models
{
    public class Location
    {
        [Key]
        public int L_ID { get; set; }
        public int LOCATION_ID { get; set; }

        public string LOCATION_NAME { get; set; } = string.Empty;
        public int SUBLOCATION_ID { get; set; }
        public string SUBLOCATION_NAME { get; set;} = string.Empty;
        public List<Files> Files { get; set; }
        public int GSTN_NO { get; set; }
    }
}