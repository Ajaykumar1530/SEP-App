using Microsoft.AspNetCore.Mvc;

namespace SEP_App.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
