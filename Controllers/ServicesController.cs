using Microsoft.AspNetCore.Mvc;

namespace TechCreare.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ILogger<ServicesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult ECommerceSolutions()
        {
            return View();
        }

        public IActionResult WebApplicationDevelopment()
        {
            return View();
        }
    }
}
