using FILESMGMT.Models; //Files Model is defined in this namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public IActionResult EnterFiles(Files f)
        {
            //return "File Type: " + f.File_type + "File Description: "+ f.Description + "File Open Date: "+ f.OpenDate + "File Close Date: "+ f.CloseDate + " Status: "+ f.Status+ " Contract Number : "+ f.Contract_No +" Vendor_NAme: "+ f.Vendor_name + " Vendor Address "+ f.Vendor_address ;
            if (!ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confo then it will return.
            {
                return View(f);
            }

            return RedirectToAction("Filesss");
        }

        [HttpPost]
        public IActionResult EnterLocation(Location l)
        {
            //return "File Type: " + f.File_type + "File Description: "+ f.Description + "File Open Date: "+ f.OpenDate + "File Close Date: "+ f.CloseDate + " Status: "+ f.Status+ " Contract Number : "+ f.Contract_No +" Vendor_NAme: "+ f.Vendor_name + " Vendor Address "+ f.Vendor_address ;
            if (!ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confo then it will return.
            {
                return View(l);
            }

            return RedirectToAction("Locationss");

        }

        //public IActionResult Demo()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public string Demo(Contract c)   
        //{
        //    return "Contract number = " + c.ContractNumber;
        //}

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
        public IActionResult ContractDetails(Contract c)   //Model binder; will be executed before the action method
        {
            //model binder also validates the input using Model Validator
            if (!ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confothen it will return.
            {
                return View(c);
            }

            return RedirectToAction("Index");   
        }

        //Data, GET request se yaha pe aayega jb hm apna application phli baar run krenge
        public IActionResult VendorDetails()    //GET
        {
            var stdData = vendorDB.Vendors.ToList();
            return View();
        }

        //When the form is submitted, this form., which contains HTTPPost request will be run
        //then its data will be stored in the object 'v' of this VendorDetails function
        [HttpPost]
        public IActionResult VendorDetails(Vendor v) //an object 'v' of the Vendor model class Contract
        {   //POST
            if (!ModelState.IsValid)    //indicates whether the model binding and validation succeeded.
            {
                return View(v);
            }

            // Process the valid model
            return RedirectToAction("Index");
            //return View();
            // Model validation is applied on the properties mentioned above through attributes
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
       

        public ActionResult ApplyFilters()
        {
            var model = new CombinedModel
            {
                Vendors = vendorDB.Vendors.ToList(), // Assuming you have a database context 'db'
                Contracts = contractDB.Contracts.ToList(),
                //Files= FileDB.File.ToList(),
            };

            return View(model);
        }
        
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

        //Vid #40; displaying data from the database
        private readonly VendorDBContext vendorDB;
        private readonly ContractDBContext contractDB;
        private readonly FileDBContext fileDB;
        private readonly LocationDBContext locationDB;

        //private readonly FileDBContext FileDB;

        public UserController(VendorDBContext vendorDB, ContractDBContext contractDB, FileDBContext fileDB, LocationDBContext locationDB)
        {
            this.vendorDB = vendorDB;
            this.contractDB = contractDB;
            this.fileDB = fileDB;
            this.locationDB = locationDB;
        }

        //public UserController(FileDBContext fileDB)
        //{
        //    this.fileDB = fileDB;
        //}
        public IActionResult Filesss()
        {
            var files = fileDB.Files.ToList();
            return View(files);
        }

        public IActionResult Locationss()
        {
            var locations = locationDB.Locations.ToList();
            return View(locations);
        }
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
