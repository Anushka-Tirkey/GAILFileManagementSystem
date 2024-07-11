using FILESMGMT.Models;
using System.Collections.Generic;

namespace FILESMGMT.Models
{
    public class CombinedModel
    {
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<FILESMGMT.Models.Contract> Contracts { get; set; }
        public IEnumerable<FILESMGMT.Models.Files> Files{ get; set; }

    }
}
