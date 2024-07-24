using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAILFileManagementSystem.Models
{
    public class Location
    {
        [Key]
        public int L_ID { get; set; }
        public int LOCATION_ID { get; set; }

        private string _locationName;
        public string LOCATION_NAME
        {
            get => _locationName;
            set => _locationName = value?.ToUpper() ?? string.Empty;
        }

        public int SUBLOCATION_ID { get; set; }

        private string _sublocationName;
        public string SUBLOCATION_NAME
        {
            get => _sublocationName;
            set => _sublocationName = value?.ToUpper() ?? string.Empty;
        }
        public int GSTN_NO { get; set; }
        public List<Files> Files { get; set; }

    }
}
