// Assuming Models are in this namespace
using GAILFileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAILFileManagementSystem.Controllers
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
        public enum FILE_TYPE
        {
            MISCELLANEOUS = 0,
            APPROVAL = 1,
            WARRANTY = 2,
            AMC = 3
        }

        public IActionResult EnterFiles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterFiles(Files f)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(f);
            //}

            // Checking for vendors
            var existingVendor = dbContext.Vendors
                .FirstOrDefault(v => v.VENDOR_NAME == f.VENDOR_NAME && v.VENDOR_ADDRESS == f.VENDOR_ADDRESS);

            if (existingVendor != null)
            {
                // Map the existing vendor details to the Files model
                f.VENDOR_ID = existingVendor.VENDOR_ID;
                f.VENDOR_NAME = existingVendor.VENDOR_NAME;
                f.VENDOR_ADDRESS = existingVendor.VENDOR_ADDRESS;
                f.CONTACT_PERSON = existingVendor.CONTACT_PERSON;
                f.CONTACT_NUMBER = existingVendor.CONTACT_NUMBER;
                f.CONTACT_EMAIL = existingVendor.CONTACT_EMAIL;
            }
            else
            {
                // Log or handle the case where the vendor is not found
                ModelState.AddModelError(string.Empty, "Vendor not found");
                return View(f);
            }

            // Checking for contracts
            var existingContract = dbContext.Contracts
                .FirstOrDefault(c => c.CONTRACT_NUMBER == f.CONTRACT_NUMBER);

            if (existingContract != null)
            {
                // Map the existing contract details to the Files model
                f.CONTACT_NUMBER = existingContract.CONTRACT_NUMBER;
                f.CONTRACT_SUBJECT = existingContract.CONTRACT_SUBJECT;
                f.CONTRACT_DESCRIPTION = existingContract.CONTRACT_DESCRIPTION;
                f.START_DATE = existingContract.START_DATE;
                f.END_DATE = existingContract.END_DATE;
                //f.CONTRACT_TYPE = existingContract.CONTRACT_TYPE;
            }
            else
            {
                // Log or handle the case where the contract is not found
                ModelState.AddModelError(string.Empty, "Contract not found");
                return View(f);
            }

            // Checking for location
            var existingLocation = dbContext.Locations.FirstOrDefault(v => v.LOCATION_NAME == f.LOCATION_NAME && v.SUBLOCATION_NAME == f.SUBLOCATION_NAME);

            if (existingLocation != null)
            {
                f.LOCATION_ID = existingLocation.LOCATION_ID;
                f.LOCATION_NAME = existingLocation.LOCATION_NAME;
                f.SUBLOCATION_ID = existingLocation.SUBLOCATION_ID;
                f.SUBLOCATION_NAME = existingLocation.SUBLOCATION_NAME;
                f.GSTN_NO = existingLocation.GSTN_NO;
            }
            else
            {
                // Log or handle the case where the location is not found
                ModelState.AddModelError(string.Empty, "Location not found");
                return View(f);
            }

            // Add the Files object to the database
            dbContext.Files.Add(f);

            // Save the changes to the database
            await dbContext.SaveChangesAsync();

            return RedirectToAction("EnterFiles", "User");
        }

        /*public ConsolidatedReportViewModel EnterFilesIntoConsolidatedFileReport(Files f)
        {
            var consolidatedReport = new ConsolidatedReportViewModel
            {
                FILE_ID = f.FILE_ID,
                FILE_NAME = f.FILE_NAME,
                FILE_TYPE = f.FILE_TYPE.ToString(),
                DESCRIPTION = f.DESCRIPTION,
                OPEN_DATE = f.OPEN_DATE,
                CLOSED_DATE = f.CLOSED_DATE,
                FILE_STATUS = f.STATUS,
                // Add other properties as needed

                // Vendor Details
                VENDOR_ID = f.VENDOR_ID,
                VENDOR_NAME = f.VENDOR_NAME,
                VENDOR_ADDRESS = f.VENDOR_ADDRESS,
                CONTACT_PERSON = f.Vendor.CONTACT_PERSON,
                CONTACT_NUMBER = f.CONTACT_PERSON,
                CONTACT_EMAIL = f.CONTACT_EMAIL,

                //public int CONTRACT_ID { get; set; }
                CONTRACT_NUMBER = f.CONTRACT_NUMBER,
                //CONTRACT_SUBJECT { get; set; }
                //CONTRACT_DESCRIPTION { get; set; }
                //CONTRACT_START_DATE 
                //CONTRACT_END_DATE
                //CONTRACT_TYPE

                // Location Details
                LOCATION_ID = f.LOCATION_ID,
                //Location 
                //LOCATION_ID 
                //LOCATION_NAME 
                //SUBLOCATION_ID 
                //SUBLOCATION_NAME 
                //GSTN_NO 
            };
            return consolidatedReport;
        }*/

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

        //public IActionResult Filesss()
        //{
        //    var filesdata = dbContext.Files.ToList();
        //    return View(filesdata);
        //}

        //public ActionResult GenerateReport()
        //{
        //    var model = new CombinedModel
        //    {
        //        Vendors = dbContext.Vendors.ToList(),
        //        Contracts = dbContext.Contracts.ToList(),
        //        Files = dbContext.Files.ToList(),
        //    };

        //    return View(model);
        //}

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
                    Text = item.VENDOR_NAME,
                    Value = item.VENDOR_ID.ToString()
                });
                VendorModel.VendorAddressList.Add(new SelectListItem    //Vendr Addresses
                {
                    Text = item.VENDOR_ADDRESS,
                    Value = item.VENDOR_ID.ToString()
                });
                VendorModel.ContactPersonList.Add(new SelectListItem    //Vendr Addresses
                {
                    Text = item.CONTACT_PERSON,
                    Value = item.VENDOR_ID.ToString()
                });
            }
            foreach (var subject in contractData)
            {
                VendorModel.ContractTypeList.Add(new SelectListItem
                {
                    Text = subject.CONTRACT_TYPE.ToString(),
                    Value = subject.SNO.ToString()
                });
                VendorModel.ContractSubjectList.Add(new SelectListItem
                {
                    Text = subject.CONTRACT_SUBJECT,
                    Value = subject.SNO.ToString()
                });
                VendorModel.ContractStartDateList.Add(new SelectListItem
                {
                    Text = subject.START_DATE.ToString("yyyy-MM-dd"), // Convert DateTime to string
                    Value = subject.SNO.ToString()
                });
                VendorModel.ContractEndDateList.Add(new SelectListItem
                {
                    Text = subject.END_DATE.ToString("yyyy-MM-dd"), // Convert DateTime to string
                    Value = subject.SNO.ToString()
                });
            }
            foreach (var fthing in fileData)
            {
                VendorModel.FileTypeList.Add(new SelectListItem
                {
                    Text = fthing.FILE_TYPE.ToString(), // Convert DateTime to string\r\n 
                    Value = fthing.FILE_ID.ToString()
                });
                VendorModel.FileCloseDateList.Add(new SelectListItem
                {
                    Text = fthing.OPEN_DATE.ToString("yyyy-MM-dd"), // Convert DateTime to string\r\n 
                    Value = fthing.FILE_ID.ToString()
                });
                VendorModel.FileCloseDateList.Add(new SelectListItem
                {
                    Text = fthing.CLOSED_DATE.ToString("yyyy-MM-dd"), // Convert DateTime to string\r\n 
                    Value = fthing.FILE_ID.ToString()
                });
            }
            return VendorModel;
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Files f)
        {
            //Inserting data into the database
            if(ModelState.IsValid == true)
            {
                await dbContext.Files.AddAsync(f);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("GenerateConsolidatedReport", "User");
            }
            return View(f);
        }

        //DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || dbContext.Files == null)
            {
                return NotFound();
            }
            var fdata = await dbContext.Files.FirstOrDefaultAsync(x => x.FILE_ID == id); 
            if(fdata != null)
                return NotFound();
            return View(fdata);
        }

        //EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fdata = await dbContext.Files.FirstOrDefaultAsync(x => x.FILE_ID == id);
            if (fdata == null)
            {
                return NotFound();
            }
            return View(fdata);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Files files)
        {
            if (id != files.FILE_ID)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                dbContext.Files.Update(files);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("GenerateConsolidatedReport", "User");
            }
            return View();
        }

        //DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fdata = await dbContext.Files.FirstOrDefaultAsync(x => x.FILE_ID == id);
            if (fdata == null)
            {
                return NotFound();
            }
            return View(fdata);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var fdata = await dbContext.Files.FindAsync(id);
            if(fdata != null)
            {
                dbContext.Files.Remove(fdata);
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction("GenerateConsolidatedReport", "User");
        }

        public IActionResult ApplyFilter()
        {
            var det = BindDDL();
            return View(det);
        }

        [HttpPost]
        public IActionResult ApplyFilter(VendorModel v)
        {
            var vdetails = dbContext.Vendors.FirstOrDefault(x => x.VENDOR_ID == v.Id);
            if (vdetails != null)
            {
                ViewBag.SelectedVendorName = vdetails.VENDOR_NAME;
            }
            var det = BindDDL();
            return View(det);
        }

        public IActionResult GenerateConsolidatedReport()
        {
            var files = dbContext.Files
                .Include(f => f.Vendor)
                .Include(f => f.Contract)
                .Include(f => f.Location)
                .ToList();

            return View(files);
        }

        //public IActionResult GenerateConsolidatedReport()
        //{
        //    var reportData = (from file in dbContext.Files
        //                      join vendor in dbContext.Vendors 
        //                            on new { file.VENDOR_NAME, file.VENDOR_ADDRESS }
        //                            equals new { vendor.VENDOR_NAME, vendor.VENDOR_ADDRESS }
        //                      join contract in dbContext.Contracts on file.CONTRACT_NUMBER equals contract.CONTRACT_NUMBER
        //                      join location in dbContext.Locations
        //                            on new { file.Location.LOCATION_NAME, file.Location.SUBLOCATION_NAME}
        //                            equals new { location.LOCATION_NAME, location.SUBLOCATION_NAME }
        //                      select new ConsolidatedReportViewModel
        //                      {
        //                          FILE_ID = file.FILE_ID,
        //                          FILE_NAME = file.FILE_NAME,
        //                          FILE_TYPE = file.FILE_TYPE.ToString(),
        //                          DESCRIPTION = file.DESCRIPTION,
        //                          OPEN_DATE = file.OPEN_DATE,
        //                          CLOSED_DATE = file.CLOSED_DATE,
        //                          FILE_STATUS = file.STATUS,

        //                          VENDOR_ID = vendor.VENDOR_ID,
        //                          VENDOR_NAME = vendor.VENDOR_NAME,
        //                          VENDOR_ADDRESS = vendor.VENDOR_ADDRESS,
        //                          CONTACT_PERSON = vendor.CONTACT_PERSON,
        //                          CONTACT_NUMBER = vendor.CONTACT_NUMBER,
        //                          CONTACT_EMAIL = vendor.CONTACT_EMAIL,

        //                          CONTRACT_ID = contract.SNO,
        //                          CONTRACT_NUMBER = contract.CONTRACT_NUMBER,
        //                          CONTRACT_SUBJECT = contract.CONTRACT_SUBJECT,
        //                          CONTRACT_DESCRIPTION = contract.CONTRACT_DESCRIPTION,
        //                          CONTRACT_START_DATE = contract.START_DATE,
        //                          CONTRACT_END_DATE = contract.END_DATE,
        //                          CONTRACT_TYPE = contract.CONTRACT_TYPE.ToString(),

        //                          LOCATION_ID = location.LOCATION_ID,
        //                          LOCATION_NAME = location.LOCATION_NAME,
        //                          SUBLOCATION_ID = location.SUBLOCATION_ID,
        //                          SUBLOCATION_NAME = location.SUBLOCATION_NAME,
        //                          GSTN_NO = location.GSTN_NO
        //                      }).ToList();

        //    return View(reportData);
        //}
    }
}