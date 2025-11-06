using System.Diagnostics;
using FinalScore_Data.Models;
using FinalScore_Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalScore_Web.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller {
        public HomeController() {
        }
        
        public IActionResult Index() {
            return View();
        }
        
        public IActionResult Privacy() {
            return View();
        }
                                                                                                            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
