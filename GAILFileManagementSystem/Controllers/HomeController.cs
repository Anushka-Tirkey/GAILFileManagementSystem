using GAILFileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace GAILFileManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileDBContext fileDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        

        //public IActionResult privacy()
        //{
        //    return view();
        //}

        
        public HomeController(FileDBContext fileDB)
        {
            this.fileDB = fileDB;
        }
        public IActionResult Index()
        {
            var fileData = fileDB.File.ToList();
            return View(fileData);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
