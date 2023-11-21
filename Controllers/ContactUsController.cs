using Microsoft.AspNetCore.Mvc;
using TechCreare.Models;
using TechCreare.Repository;

namespace TechCreare.Controllers
{
    public class ContactUsController : Controller
    {

        public IActionResult Index()
        {
            EmailParam entity = new EmailParam();
            return View(entity);
        }
    }
}
