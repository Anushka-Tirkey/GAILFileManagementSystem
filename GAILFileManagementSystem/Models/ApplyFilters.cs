using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GAILFileManagementSystem.Models
{
    public class ApplyFilters
    {
        public int Id {  get; set; }
        public List<SelectListItem> VendorList { get; set; }   
    }
}
