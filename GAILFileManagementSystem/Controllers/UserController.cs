using FILESMGMT.Models;
using GAILFileManagementSystem.Models; //Files Model is defined in this namespace
using Microsoft.AspNetCore.Mvc;

namespace GAILFileManagementSystem.Controllers
{
    public class UserController : Controller
    {
        //VALIDATION NHI HO PA RHA KISI V PAGE M
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnterFiles()
        {
            return View();
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
                /*"Contract number = " + c.ContractNumber +
                "Contract Subject = " + c.ContractSubject +
                "Contract Description = " + c.ContractDescription +
                "Start Date = " + c.StartDate +
                "End Date= " + c.EndDate +
                "Contract Type= " + c.ContractType;*/
        }

        //Data, GET request se yaha pe aayega jb hm apna application phli baar run krenge
        public IActionResult VendorDetails()    //GET
        {
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
        //    var myFiles = new List<Files>
        //    {
        //        new Files() { FileId = 1, FileName = "Contract1", FileType = "AMC" /*, FileSize = ..., UploadDate = ..., EmployeeId = ..., ApprovalStatus = ..., FilePath = ... */ },
        //        new Files() { FileId = 2, FileName = "ContractForLaptop", FileType = "Contract" },
        //        new Files() { FileId = 3, FileName = "Employee Details ", FileType = "Contract" }
        //    };
        //    return View(myFiles);
        //}
    }
}