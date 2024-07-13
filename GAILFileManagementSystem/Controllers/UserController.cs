using FILESMGMT.Models; //Files Model is defined in this namespace
using GAILFileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILESMGMT.Controllers
{
    public class UserController : Controller
    {
        
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        public enum File_type
        {
            Miscellaneous=0, 
            Approval=1, 
            Warranty=2, 
            AMC=3
        }


        public IActionResult EnterFiles()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterFiles(Files f)
        {
            //return "File Type: " + f.File_type + "File Description: "+ f.Description + "File Open Date: "+ f.OpenDate + "File Close Date: "+ f.CloseDate + " Status: "+ f.Status+ " Contract Number : "+ f.Contract_No +" Vendor_NAme: "+ f.Vendor_name + " Vendor Address "+ f.Vendor_address ;
            if (ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confo then it will return.
            {
                await fileDB.Files.AddAsync(f);
                await fileDB.SaveChangesAsync();
                return RedirectToAction("EnterFiles","User");
            }
            
            return View(f);
            
        }
        public IActionResult EnterLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterLocation(Location l)
        {
            //return "File Type: " + f.File_type + "File Description: "+ f.Description + "File Open Date: "+ f.OpenDate + "File Close Date: "+ f.CloseDate + " Status: "+ f.Status+ " Contract Number : "+ f.Contract_No +" Vendor_NAme: "+ f.Vendor_name + " Vendor Address "+ f.Vendor_address ;
            if (ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confo then it will return.
            {
                await locationDB.Locations.AddAsync(l);
                await locationDB.SaveChangesAsync();
                return RedirectToAction("EnterLocation","User");
            }
            return View(l);

        }

        public enum  CType
        {
            Local =0, 
            Centralised = 1
        }
        public IActionResult ContractDetails()
        {
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContractDetails(Contract c)   //Model binder; will be executed before the action method
        {
            //model binder also validates the input using Model Validator
            if (ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confothen it will return.
            {
                await contractDB.Contracts.AddAsync(c);
                await contractDB.SaveChangesAsync();
                return RedirectToAction("ContractDetails", "User");
            }
            return View(c);
        }
        public IActionResult VendorDetails()    //GET
        {
            var stdData = vendorDB.Vendors.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VendorDetails(Vendor v) //an object 'v' of the Vendor model class Contract
        {   //POST
            if (ModelState.IsValid)    //indicates whether the model binding and validation succeeded.
            {
                await vendorDB.Vendors.AddAsync(v);
                await vendorDB.SaveChangesAsync();
                return RedirectToAction("VendorDetails", "User");
                
            }
            return View(v);

        }

        //Vid #40; displaying data from the database
        private readonly VendorDBContext vendorDB;
        private readonly ContractDBContext contractDB;
        private readonly LocationDBContext locationDB;
        private readonly FileDBContext fileDB;

        //private readonly FileDBContext FileDB;
        //CONSTRUCTOR
        public UserController(VendorDBContext vendorDB, ContractDBContext contractDB, LocationDBContext locationDB, FileDBContext fileDB)
        {
            this.vendorDB = vendorDB;
            this.contractDB = contractDB;
            this.locationDB = locationDB;
            this.fileDB = fileDB;
        }
        public IActionResult Filesss()
        {
            var filesdata = fileDB.Files.ToList();
            return View(filesdata);
        }

        //public UserController(FileDBContext fileDB)
        //{
        //    this.fileDB = fileDB;
        //}
        public ActionResult GenerateReport()
        {
            var model = new CombinedModel
            {
                Vendors = vendorDB.Vendors.ToList(), // Assuming you have a database context 'db'
                Contracts = contractDB.Contracts.ToList(),
                Files = fileDB.Files.ToList(),
            };

            return View(model);
        }


        //public IActionResult GenerateReport()
        //{
        //    var vendorData = vendorDB.Vendors.ToList();
        //    var contractData = contractDB.Contracts.ToList();  
        //    return View(vendorData);
        //}

        //public IActionResult GenerateReport2()
        //{
        //    var vendorData = vendorDB.Vendors.ToList();
        //    var contractData = contractDB.Contracts.ToList();
        //    return View(contractData);
        //}


        /*public ActionResult ApplyFilters()
        {
            var model = new CombinedModel
            {
                Vendors = vendorDB.Vendors.ToList(), // Assuming you have a database context 'db'
                Contracts = contractDB.Contracts.ToList(),
                //Files= FileDB.File.ToList(),
            };

            return View(model);
        }*/

        //public async Task<IActionResult> Details (int id)
        //{
        //    if(id == 0 || id==null || vendorDB.Vendors == null)
        //    {
        //        return NotFound();
        //    }
        //    var comdata = await vendorDB.Vendors.FirstOrDefaultAsync(x => x.VendorId == id);
        //    if(comdata == null)
        //        return NotFound();
        //    return View(comdata);
        //}

        /*public IActionResult ApplyFilter()
        {
            VendorModel VendorModel = new VendorModel();
            VendorModel.VendorList = new List<SelectListItem>();
            var data = vendorDB.Vendors.ToList();   //Vendors: from this code in VendorDBContext: public DbSet<Vendor> Vendors { get; set; }
            VendorModel.VendorList.Add(new SelectListItem /*first value*/
        /*{
            Text = "Select Vendor Name",
            Value = ""
        });

        VendorModel.VendorAddressList.Add(new SelectListItem
        {
            Text = "Select Vendor Address",
            Value = ""
        });

        foreach (var item in data)  /*The rest of the values*/
        /*{
            VendorModel.VendorList.Add(new SelectListItem
            {
                Text = item.VendorName,
                Value = item.VendorId.ToString()
            });
        }
        return View(VendorModel);
    }*/

        public IActionResult ApplyFilter()
        {
            VendorModel VendorModel = new VendorModel();

            var data = vendorDB.Vendors.ToList(); // Vendors: from this code in VendorDBContext: public DbSet<Vendor> Vendors { get; set; }
            var contractData = contractDB.Contracts.ToList();
            //var fileData = fileDB.Files.ToList();

            //THE FIRST/DEFAULT TEXT TO BE DISPLAYED IN DROPDOWNS
            VendorModel.VendorNameList.Add(new SelectListItem
            {
                Text = "Select Vendor Name",
                Value = ""
            });
            VendorModel.VendorAddressList.Add(new SelectListItem
            {
                Text = "Select Vendor Address",
                Value = ""
            });
            VendorModel.ContractSubjectList.Add(new SelectListItem
            {
                Text = "Select Contract Subject",
                Value = ""
            });
            VendorModel.ContractStartDateList.Add(new SelectListItem
            {
                Text = "Select Contact Start Date",
                Value = ""
            });
            VendorModel.ContractEndDateList.Add(new SelectListItem
            {
                Text = "Select Contact End Date",
                Value = ""
            });
            //VendorModel.FileTypeList.Add(new SelectListItem
            //{
            //    Text = "Select Contract End Date",
            //    Value = ""
            //});

            //VendorModel.FileOpenDateList.Add(new SelectListItem
            //{
            //    Text = "Select File Open Date",
            //    Value = ""
            //});
            //VendorModel.FileCloseDateList.Add(new SelectListItem
            //{
            //    Text = "Select File Close Date",
            //    Value = ""
            //});



            //POPULATE THE DROPDOWN LISTS"
            //Populate For Vendors
            foreach (var item in data)  
            {
                VendorModel.VendorNameList.Add(new SelectListItem   //Vendor Names
                {
                    Text = item.VendorName,
                    Value = item.VendorId.ToString()
                });
                VendorModel.VendorAddressList.Add(new SelectListItem    //Vendr Addresses
                {
                    Text = item.VendorAddress,
                    Value = item.VendorId.ToString()
                });
            }
            foreach (var subject in contractData)
            {
                VendorModel.ContractSubjectList.Add(new SelectListItem
                {
                    Text = subject.ContractSubject,
                    Value = subject.sno.ToString()
                });
                VendorModel.ContractStartDateList.Add(new SelectListItem
                {
                    Text = subject.StartDate.ToString("yyyy-MM-dd"), // Convert DateTime to string
                    Value = subject.sno.ToString()
                });
                VendorModel.ContractEndDateList.Add(new SelectListItem
                {
                    Text = subject.EndDate.ToString("yyyy-MM-dd"), // Convert DateTime to string
                    Value = subject.sno.ToString()
                });
            }



            return View(VendorModel);
        }

        public IActionResult Details(string vendorName, string vendorAddress, string contractNo, DateTime fopendate, DateTime fclosedate)
        {
            var model = new CombinedModel
            {
                Vendors = vendorDB.Vendors.Where(x => x.VendorName == vendorName && x.VendorAddress == vendorAddress).ToList(),
                Contracts = contractDB.Contracts.Where(x => x.ContractNumber == contractNo).ToList(),
                Files = fileDB.Files.Where(x => x.Open_Date == fopendate && x.Closed_Date == fclosedate).ToList(),
            };

            return View(model);
        }
    }
}