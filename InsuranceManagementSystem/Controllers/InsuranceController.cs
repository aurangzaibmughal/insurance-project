using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementSystem.Controllers
{
    public class InsuranceController : Controller
    {
        public IActionResult Life()
        {
            return View();
        }

        public IActionResult Medical()
        {
            return View();
        }

        public IActionResult Motor()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}
