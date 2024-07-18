// Assuming Models are in this namespace
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
        private readonly myDbContext dbContext;

        public UserController(myDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public enum File_type
        {
            Miscellaneous = 0,
            Approval = 1,
            Warranty = 2,
            AMC = 3
        }

        public IActionResult EnterFiles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterFiles(Files f)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Files.AddAsync(f);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("EnterFiles", "User");
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
            if (ModelState.IsValid)
            {
                await dbContext.Locations.AddAsync(l);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("EnterLocation", "User");
            }
            return View(l);
        }

        public enum CType
        {
            Local = 0,
            Centralised = 1
        }

        public IActionResult ContractDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContractDetails(Contract c)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Contracts.AddAsync(c);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("ContractDetails", "User");
            }
            return View(c);
        }

        public IActionResult VendorDetails()
        {
            var stdData = dbContext.Vendors.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VendorDetails(Vendor v)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Vendors.AddAsync(v);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("VendorDetails", "User");
            }
            return View(v);
        }

        public IActionResult Filesss()
        {
            var filesdata = dbContext.Files.ToList();
            return View(filesdata);
        }

        public ActionResult GenerateReport()
        {
            var model = new CombinedModel
            {
                Vendors = dbContext.Vendors.ToList(),
                Contracts = dbContext.Contracts.ToList(),
                Files = dbContext.Files.ToList(),
            };

            return View(model);
        }

        private VendorModel BindDDL()
        {
            VendorModel VendorModel = new VendorModel();

            var data = dbContext.Vendors.ToList();
            var contractData = dbContext.Contracts.ToList();
            var fileData = dbContext.Files.ToList();

            VendorModel.VendorNameList.Add(new SelectListItem
            {
                Text = "--Select Vendor Name--",
                Value = ""
            });
            VendorModel.VendorAddressList.Add(new SelectListItem
            {
                Text = "--Select Vendor Address--",
                Value = ""
            });
            VendorModel.ContactPersonList.Add(new SelectListItem
            {
                Text = "--Select Contact Person--",
                Value = ""
            });
            VendorModel.ContractTypeList.Add(new SelectListItem
            {
                Text = "--Select Contract Type--",
                Value = ""
            });
            VendorModel.ContractSubjectList.Add(new SelectListItem
            {
                Text = "--Select Contract Subject--",
                Value = ""
            });
            VendorModel.ContractStartDateList.Add(new SelectListItem
            {
                Text = "--Select Contact Start Date--",
                Value = ""
            });
            VendorModel.ContractEndDateList.Add(new SelectListItem
            {
                Text = "--Select Contact End Date--",
                Value = ""
            });
            VendorModel.FileTypeList.Add(new SelectListItem
            {
                Text = "--Select File Type--",
                Value = ""
            });
            VendorModel.FileOpenDateList.Add(new SelectListItem
            {
                Text = "Select File Open Date",
                Value = ""
            });
            VendorModel.FileCloseDateList.Add(new SelectListItem
            {
                Text = "Select File Close Date",
                Value = ""
            });

            //POPULATE THE DROPDOWN LISTS...
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
                VendorModel.ContactPersonList.Add(new SelectListItem    //Vendr Addresses
                {
                    Text = item.ContactPerson,
                    Value = item.VendorId.ToString()
                });
            }
            foreach (var subject in contractData)
            {
                VendorModel.ContractTypeList.Add(new SelectListItem
                {
                    Text = subject.ContractType.ToString(),
                    Value = subject.sno.ToString()
                });
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
            foreach (var fthing in fileData)
            {
                VendorModel.FileTypeList.Add(new SelectListItem
                {
                    Text = fthing.File_type.ToString(), // Convert DateTime to string\r\n 
                    Value = fthing.FileId.ToString()
                });
                VendorModel.FileCloseDateList.Add(new SelectListItem
                {
                    Text = fthing.Open_Date.ToString("yyyy-MM-dd"), // Convert DateTime to string\r\n 
                    Value = fthing.FileId.ToString()
                });
                VendorModel.FileCloseDateList.Add(new SelectListItem
                {
                    Text = fthing.Closed_Date.ToString("yyyy-MM-dd"), // Convert DateTime to string\r\n 
                    Value = fthing.FileId.ToString()
                });
            }
            return VendorModel;
        }

        public IActionResult ApplyFilter()
        {
            var det = BindDDL();
            return View(det);
        }

        [HttpPost]
        public IActionResult ApplyFilter(VendorModel v)
        {
            var vdetails = dbContext.Vendors.FirstOrDefault(x => x.VendorId == v.Id);
            if (vdetails != null)
            {
                ViewBag.SelectedVendorName = vdetails.VendorName;
            }
            var det = BindDDL();
            return View(det);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fdata = await dbContext.Files.FirstOrDefaultAsync(x => x.FileId == id);
            if (fdata == null)
            {
                return NotFound();
            }
            return View(fdata);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Files files)
        {
            if (id != files.FileId)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                dbContext.Files.Update(files);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            var fdata = await dbContext.Files.FirstOrDefaultAsync(x => x.FileId == id);
            return View(fdata);
        }

        public IActionResult GenerateConsolidatedReport()
        {
            var reportData = (from file in dbContext.Files
                              join vendor in dbContext.Vendors on file.VendorName equals vendor.VendorName /*file.VendorId equals vendor.VendorId*/
                              join contract in dbContext.Contracts on file.ContractNumber equals contract.ContractNumber
                              join location in dbContext.Locations on file.LocationId equals location.LocationId
                              select new ConsolidatedReportViewModel
                              {
                                  FileId = file.FileId,
                                  FileName = file.FileName,
                                  FileType = file.File_type.ToString(),
                                  Description = file.Description,
                                  OpenDate = file.Open_Date,
                                  ClosedDate = file.Closed_Date,
                                  FileStatus = file.Status,

                                  VendorId = vendor.VendorId,
                                  VendorName = vendor.VendorName,
                                  VendorAddress = vendor.VendorAddress,
                                  ContactPerson = vendor.ContactPerson,
                                  ContactNumber = vendor.ContactNumber,
                                  ContactEmailId = vendor.ContactEmailId,

                                  ContractId = contract.sno,
                                  ContractNumber = contract.ContractNumber,
                                  ContractSubject = contract.ContractSubject,
                                  ContractDescription = contract.ContractDescription,
                                  ContractStartDate = contract.StartDate,
                                  ContractEndDate = contract.EndDate,
                                  ContractType = contract.ContractType.ToString(),

                                  LocationId = location.LocationId,
                                  LocationName = location.LocationName,
                                  SubLocationId = location.SubLocationID,
                                  SubLocationName = location.SubLocationName,
                                  GSTN_No = location.GSTN_No
                              }).ToList();

            return View(reportData);
        }
    }
}


//using GAILFileManagementSystem.Models; //Files Model is defined in this namespace
//using GAILFileManagementSystem.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GAILFileManagementSystem.Controllers
//{
//    public class UserController : Controller
//    {

//        [Route("")]
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public enum File_type
//        {
//            Miscellaneous=0, 
//            Approval=1, 
//            Warranty=2, 
//            AMC=3
//        }


//        public IActionResult EnterFiles()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> EnterFiles(Files f)
//        {
//            //return "File Type: " + f.File_type + "File Description: "+ f.Description + "File Open Date: "+ f.OpenDate + "File Close Date: "+ f.CloseDate + " Status: "+ f.Status+ " Contract Number : "+ f.ContractNumber +" Vendor_NAme: "+ f.VendorName + " Vendor Address "+ f.VendorAddress ;
//            if (ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confo then it will return.
//            {
//                await fileDB.Files.AddAsync(f);
//                await fileDB.SaveChangesAsync();
//                return RedirectToAction("EnterFiles","User");
//            }

//            return View(f);

//        }
//        public IActionResult EnterLocation()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> EnterLocation(Location l)
//        {
//            //return "File Type: " + f.File_type + "File Description: "+ f.Description + "File Open Date: "+ f.OpenDate + "File Close Date: "+ f.CloseDate + " Status: "+ f.Status+ " Contract Number : "+ f.ContractNumber +" Vendor_NAme: "+ f.VendorName + " Vendor Address "+ f.VendorAddress ;
//            if (ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confo then it will return.
//            {
//                await locationDB.Locations.AddAsync(l);
//                await locationDB.SaveChangesAsync();
//                return RedirectToAction("EnterLocation","User");
//            }
//            return View(l);

//        }

//        public enum  CType
//        {
//            Local =0, 
//            Centralised = 1
//        }
//        public IActionResult ContractDetails()
//        {
//                return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> ContractDetails(Contract c)   //Model binder; will be executed before the action method
//        {
//            //model binder also validates the input using Model Validator
//            if (ModelState.IsValid)    //if the model binding and validation succeeded, i.e. if the fields confothen it will return.
//            {
//                await contractDB.Contracts.AddAsync(c);
//                await contractDB.SaveChangesAsync();
//                return RedirectToAction("ContractDetails", "User");
//            }
//            return View(c);
//        }
//        public IActionResult VendorDetails()    //GET
//        {
//            var stdData = vendorDB.Vendors.ToList();
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> VendorDetails(Vendor v) //an object 'v' of the Vendor model class Contract
//        {   //POST
//            if (ModelState.IsValid)    //indicates whether the model binding and validation succeeded.
//            {
//                await vendorDB.Vendors.AddAsync(v);
//                await vendorDB.SaveChangesAsync();
//                return RedirectToAction("VendorDetails", "User");

//            }
//            return View(v);

//        }

//        //Vid #40; displaying data from the database
//        private readonly myDbContext vendorDB;
//        private readonly myDbContext contractDB;
//        private readonly myDbContext locationDB;
//        private readonly myDbContext fileDB;
//        private readonly myDbContext vendorModelDB;

//        //private readonly myDbContext FileDB;
//        //CONSTRUCTOR
//        public UserController(myDbContext vendorDB, myDbContext contractDB, myDbContext locationDB, myDbContext fileDB, myDbContext vendorModelDB)
//        {
//            this.vendorDB = vendorDB;
//            this.contractDB = contractDB;
//            this.locationDB = locationDB;
//            this.fileDB = fileDB;
//            this.vendorModelDB = vendorModelDB;
//        }
//        public IActionResult Filesss()
//        {
//            var filesdata = fileDB.Files.ToList();
//            return View(filesdata);
//        }

//        public ActionResult GenerateReport()
//        {
//            var model = new CombinedModel
//            {
//                Vendors = vendorDB.Vendors.ToList(), // Assuming you have a database context 'db'
//                Contracts = contractDB.Contracts.ToList(),
//                Files = fileDB.Files.ToList(),
//            };

//            return View(model);
//        }


//        //public IActionResult GenerateReport()
//        //{
//        //    var vendorData = vendorDB.Vendors.ToList();
//        //    var contractData = contractDB.Contracts.ToList();  
//        //    return View(vendorData);
//        //}

//        //public IActionResult GenerateReport2()
//        //{
//        //    var vendorData = vendorDB.Vendors.ToList();
//        //    var contractData = contractDB.Contracts.ToList();
//        //    return View(contractData);
//        //}


//        /*public ActionResult ApplyFilters()
//        {
//            var model = new CombinedModel
//            {
//                Vendors = vendorDB.Vendors.ToList(), // Assuming you have a database context 'db'
//                Contracts = contractDB.Contracts.ToList(),
//                //Files= FileDB.File.ToList(),
//            };

//            return View(model);
//        }*/

//        //public async Task<IActionResult> Details (int id)
//        //{
//        //    if(id == 0 || id==null || vendorDB.Vendors == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    var comdata = await vendorDB.Vendors.FirstOrDefaultAsync(x => x.VendorId == id);
//        //    if(comdata == null)
//        //        return NotFound();
//        //    return View(comdata);
//        //}



//        private VendorModel BindDDL()
//        {
//            VendorModel VendorModel = new VendorModel();

//            var data = vendorDB.Vendors.ToList(); // Vendors: from this code in myDbContext: public DbSet<Vendor> Vendors { get; set; }
//            var contractData = contractDB.Contracts.ToList();
//            var fileData = fileDB.Files.ToList();

//            //THE FIRST/DEFAULT TEXT TO BE DISPLAYED IN DROPDOWNS
//            VendorModel.VendorNameList.Add(new SelectListItem
//            {
//                Text = "--Select Vendor Name--",
//                Value = ""
//            });
//            VendorModel.VendorAddressList.Add(new SelectListItem
//            {
//                Text = "--Select Vendor Address--",
//                Value = ""
//            });
//            VendorModel.ContactPersonList.Add(new SelectListItem
//            {
//                Text = "--Select Contact Person--",
//                Value = ""
//            });
//            VendorModel.ContractTypeList.Add(new SelectListItem
//            {
//                Text = "--Select Contract Type--",
//                Value = ""
//            });
//            VendorModel.ContractSubjectList.Add(new SelectListItem
//            {
//                Text = "--Select Contract Subject--",
//                Value = ""
//            });
//            VendorModel.ContractStartDateList.Add(new SelectListItem
//            {
//                Text = "--Select Contact Start Date--",
//                Value = ""
//            });
//            VendorModel.ContractEndDateList.Add(new SelectListItem
//            {
//                Text = "--Select Contact End Date--",
//                Value = ""
//            });
//            VendorModel.FileTypeList.Add(new SelectListItem
//            {
//                Text = "--Select File Type--",
//                Value = ""
//            });
//            VendorModel.FileOpenDateList.Add(new SelectListItem
//            {
//                Text = "Select File Open Date",
//                Value = ""
//            });
//            VendorModel.FileCloseDateList.Add(new SelectListItem
//            {
//                Text = "Select File Close Date",
//                Value = ""
//            });

//            //POPULATE THE DROPDOWN LISTS"
//            //Populate For Vendors
//            foreach (var item in data)
//            {
//                VendorModel.VendorNameList.Add(new SelectListItem   //Vendor Names
//                {
//                    Text = item.VendorName,
//                    Value = item.VendorId.ToString()
//                });
//                VendorModel.VendorAddressList.Add(new SelectListItem    //Vendr Addresses
//                {
//                    Text = item.VendorAddress,
//                    Value = item.VendorId.ToString()
//                });
//                VendorModel.ContactPersonList.Add(new SelectListItem    //Vendr Addresses
//                {
//                    Text = item.ContactPerson,
//                    Value = item.VendorId.ToString()
//                });
//            }
//            foreach (var subject in contractData)
//            {
//                VendorModel.ContractTypeList.Add(new SelectListItem
//                {
//                    Text = subject.ContractType.ToString(),
//                    Value = subject.sno.ToString()
//                });
//                VendorModel.ContractSubjectList.Add(new SelectListItem
//                {
//                    Text = subject.ContractSubject,
//                    Value = subject.sno.ToString()
//                });
//                VendorModel.ContractStartDateList.Add(new SelectListItem
//                {
//                    Text = subject.StartDate.ToString("yyyy-MM-dd"), // Convert DateTime to string
//                    Value = subject.sno.ToString()
//                });
//                VendorModel.ContractEndDateList.Add(new SelectListItem
//                {
//                    Text = subject.EndDate.ToString("yyyy-MM-dd"), // Convert DateTime to string
//                    Value = subject.sno.ToString()
//                });
//            }
//            foreach (var fthing in fileData)
//            {
//                VendorModel.FileTypeList.Add(new SelectListItem
//                {
//                    Text = fthing.File_type.ToString(), // Convert DateTime to string\r\n 
//                    Value = fthing.FileId.ToString()
//                });
//                VendorModel.FileCloseDateList.Add(new SelectListItem
//                {
//                    Text = fthing.Open_Date.ToString("yyyy-MM-dd"), // Convert DateTime to string\r\n 
//                    Value = fthing.FileId.ToString()
//                });
//                VendorModel.FileCloseDateList.Add(new SelectListItem
//                {
//                    Text = fthing.Closed_Date.ToString("yyyy-MM-dd"), // Convert DateTime to string\r\n 
//                    Value = fthing.FileId.ToString()
//                });
//            }
//            return VendorModel;
//        }

//        public IActionResult ApplyFilter()
//        {
//            var det = BindDDL();
//            return View(det);
//        }

//        [HttpPost]
//        public IActionResult ApplyFilter(VendorModel v)
//        {
//            var vdetails = vendorDB.Vendors.Where(x=> x.VendorId == v.Id).FirstOrDefault();
//            if (vdetails != null)
//            {
//                ViewBag.SelectedVendorName = vdetails.VendorName;
//            }
//            var det = BindDDL();
//            return View(det);
//        }

//        //public IActionResult Details(string vendorName, string vendorAddress, string contractNo, DateTime fopendate, DateTime fclosedate)
//        //{
//        //    var model = new CombinedModel
//        //    {
//        //        Vendors = vendorDB.Vendors.Where(x => x.VendorName == vendorName && x.VendorAddress == vendorAddress).ToList(),
//        //        Contracts = contractDB.Contracts.Where(x => x.ContractNumber == contractNo).ToList(),
//        //        Files = fileDB.Files.Where(x => x.Open_Date == fopendate && x.Closed_Date == fclosedate).ToList(),
//        //    };

//        //    return View(model);
//        //}

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if(id == null)
//            {
//                return NotFound();
//            }
//            var fdata = await fileDB.Files.FirstOrDefaultAsync(x => x.FileId == id);
//            if(fdata == null)
//            {
//                return NotFound();
//            }
//            return View(fdata);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(int? id, Files files)
//        {
//            if (id != files.FileId)
//            {
//                NotFound();
//            }
//            if(ModelState.IsValid)
//            {
//                fileDB.Files.Update(files);
//                await fileDB.SaveChangesAsync();
//                return RedirectToAction("Index", "User");

//            }
//            return View(); 
//        }
//        public async Task<IActionResult> Details(int? id)
//        {
//            //if (id == null)
//            //{
//            //    return NotFound();
//            //}
//            var fdata = await fileDB.Files.FirstOrDefaultAsync(x => x.FileId == id);
//            //if (fdata == null)
//            //{
//            //    return NotFound();
//            //}
//            return View(fdata);
//        }
//    }
//}