using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FILESMGMT.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; } = string.Empty;
        public int SubLocationID { get; set; }
        public string SubLocationName { get; set;} = string.Empty;
        public int GSTN_No { get; set; }


    }
}
