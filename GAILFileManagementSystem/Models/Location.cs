using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAILFileManagementSystem.Models
{
    public class Location
    {
        [Key]
        public int LId { get; set; }
        public int LocationId { get; set; }

        public string LocationName { get; set; } = string.Empty;
        public int SubLocationID { get; set; }
        public string SubLocationName { get; set;} = string.Empty;
        public List<Files> Files { get; set; }
        public int GSTN_No { get; set; }
    }
}