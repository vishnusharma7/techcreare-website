using Microsoft.AspNetCore.Mvc;

namespace TechCreare.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutCompany()
        {
            return View();
        }
        public IActionResult Careers()
        {
            return View();
        }
        public IActionResult ourculture()
        {
            return View();
        }
    }
}
