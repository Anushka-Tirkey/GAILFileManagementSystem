using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GAILFileManagementSystem.Models
{
    public class VendorModel
    {
        public int Id { get; set; } //value
        
        //we always bind selectlist with dropdown
        public List<SelectListItem> VendorList { get; set; }   //text
        //we will fetch the data from the database and store in VendorList
    }
}
