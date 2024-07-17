using GAILFileManagementSystem.Models;
using System.Collections.Generic;

namespace GAILFileManagementSystem.Models
{
    public class CombinedModel
    {
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<GAILFileManagementSystem.Models.Contract> Contracts { get; set; }
        public IEnumerable<GAILFileManagementSystem.Models.Files> Files{ get; set; }

        public IEnumerable<GAILFileManagementSystem.Models.Location> Locations { get; set; }

    }
}
