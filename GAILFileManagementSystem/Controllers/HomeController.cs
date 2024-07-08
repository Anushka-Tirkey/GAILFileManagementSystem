using GAILFileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
