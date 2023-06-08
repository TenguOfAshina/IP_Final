using IP_Final.Models;
using IP_Final.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IP_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _ctx;
        public HomeController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View("TestIndex");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\User\Desktop\folder\subway-train-interior.zip");
            string fileName = "Subway_Train_Interior.zip";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

