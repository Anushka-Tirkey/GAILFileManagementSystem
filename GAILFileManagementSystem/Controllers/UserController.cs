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
        /*public async Task<IActionResult> EnterFiles(Files f)
        {
            //if (ModelState.IsValid)
            //{
            //Checking for vendors
            var existingVendor = dbContext.Vendors
                    .FirstOrDefault(v => v.VendorName == f.VendorName && v.VendorAddress == f.VendorAddress);

            if (existingVendor != null)
            {
                // Map the existing vendor details to the Files model
                f.VendorId = existingVendor.VendorId;
                f.Vendor = existingVendor;
                f.ContactPerson = existingVendor.ContactPerson;
                f.ContactNumber = existingVendor.ContactNumber;
                f.ContactEmailId = existingVendor.ContactEmailId;
            }

            //checking for CONTRACTS
            var existingContract = dbContext.Contracts
                    .FirstOrDefault(v => v.ContractNumber == f.ContractNumber);

            if (existingContract != null)
            {
                // Map the existing CONTRACT details to the Files model
                f.ContractSubject= existingContract.ContractSubject;
                f.ContractDescription= existingContract.ContractDescription;    
                f.StartDate = existingContract.StartDate;   
                f.EndDate = existingContract.EndDate;
                //f.ContractType = Enum.Parse<CType>(existingContract.ContractType.ToString());
            }

            //CHECKING FOR LOCATION
            var existingLocation = dbContext.Locations.FirstOrDefault(v => v.LocationId == f.LocationId);
            if (existingLocation != null)
            {
                f.SubLocationID = existingLocation.SubLocationID;
                f.GSTN_No = existingLocation.GSTN_No;
            }

                await dbContext.Files.AddAsync(f);
                await dbContext.SaveChangesAsync();
                //EnterFilesIntoConsolidatedFileReport(f);
                return RedirectToAction("EnterFiles", "User");
                return View(f);
        }*/

        public async Task<IActionResult> EnterFiles(Files f)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return View(f);
            }

            // Checking for vendors
            var existingVendor = dbContext.Vendors
                .FirstOrDefault(v => v.VendorName == f.VendorName && v.VendorAddress == f.VendorAddress);

            if (existingVendor != null)
            {
                // Map the existing vendor details to the Files model
                f.VendorId = existingVendor.VendorId;
                f.Vendor = existingVendor;
                f.ContactPerson = existingVendor.ContactPerson;
                f.ContactNumber = existingVendor.ContactNumber;
                f.ContactEmailId = existingVendor.ContactEmailId;
            }
            else
            {
                // Log or handle the case where the vendor is not found
                ModelState.AddModelError(string.Empty, "Vendor not found");
                return View(f);
            }

            // Checking for contracts
            var existingContract = dbContext.Contracts
                .FirstOrDefault(v => v.ContractNumber == f.ContractNumber);

            if (existingContract != null)
            {
                // Map the existing contract details to the Files model
                f.ContractSubject = existingContract.ContractSubject;
                f.ContractDescription = existingContract.ContractDescription;
                f.StartDate = existingContract.StartDate;
                f.EndDate = existingContract.EndDate;
                //f.ContractType = existingContract.ContractType;
            }
            else
            {
                // Log or handle the case where the contract is not found
                ModelState.AddModelError(string.Empty, "Contract not found");
                return View(f);
            }

            // Checking for location
            var existingLocation = dbContext.Locations.FirstOrDefault(v => v.LocationId == f.LocationId);

            if (existingLocation != null)
            {
                f.SubLocationID = existingLocation.SubLocationID;
                f.GSTN_No = existingLocation.GSTN_No;
            }
            else
            {
                // Log or handle the case where the location is not found
                ModelState.AddModelError(string.Empty, "Location not found");
                return View(f);
            }

            // Add the Files object to the database
            await dbContext.Files.AddAsync(f);
            await dbContext.SaveChangesAsync();

            // Optionally call a method to handle the consolidated report
            // EnterFilesIntoConsolidatedFileReport(f);

            return RedirectToAction("EnterFiles", "User");
        }


        /*public ConsolidatedReportViewModel EnterFilesIntoConsolidatedFileReport(Files f)
        {
            var consolidatedReport = new ConsolidatedReportViewModel
            {
                FileId = f.FileId,
                FileName = f.FileName,
                FileType = f.File_type.ToString(),
                Description = f.Description,
                OpenDate = f.Open_Date,
                ClosedDate = f.Closed_Date,
                FileStatus = f.Status,
                // Add other properties as needed

                // Vendor Details
                VendorId = f.VendorId,
                VendorName = f.VendorName,
                VendorAddress = f.VendorAddress,
                ContactPerson = f.Vendor.ContactPerson,
                ContactNumber = f.ContactPerson,
                ContactEmailId = f.ContactEmailId,

                //public int ContractId { get; set; }
                ContractNumber = f.ContractNumber,
                //ContractSubject { get; set; }
                //ContractDescription { get; set; }
                //ContractStartDate 
                //ContractEndDate
                //ContractType

                // Location Details
                LocationId = f.LocationId,
                //Location 
                //LocationId 
                //LocationName 
                //SubLocationId 
                //SubLocationName 
                //GSTN_No 
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