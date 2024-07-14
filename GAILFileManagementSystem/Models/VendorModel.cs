using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAILFileManagementSystem.Models
{
    public class VendorModel
    {
        [Key]
        public int Id { get; set; }
        public List<SelectListItem> VendorNameList { get; set; } = new List<SelectListItem>();  //This is a VendorNameList property of type List<SelectListItem>. It is initialized as a new List<SelectListItem>. This property will hold a list of vendor names that can be used to populate a dropdown list in a view.
        public List<SelectListItem> VendorAddressList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ContactPersonList{ get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ContractTypeList{ get; set; } = new List<SelectListItem>(); 
        public List<SelectListItem> ContractSubjectList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ContractStartDateList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ContractEndDateList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> FileTypeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> FileOpenDateList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> FileCloseDateList { get; set; } = new List<SelectListItem>();

        public string SelectedVendorName { get; set; }
        public string SelectedVendorAddress { get; set; }
        public string SelectedContactPerson{ get; set; }
        public string SelectedContractType{ get; set; }
        public string SelectedContractSubject { get; set; }
        public string SelectedContractStartDate { get; set; }
        public string SelectedContractEndDate { get; set; }
        public string SelectedFileType{ get; set; }
        public string SelectedFileOpenDate { get; set; }
        public string SelectedFileCloseDate { get;set; }

    }
}