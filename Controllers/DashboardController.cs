using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Check if user is logged in
            string? userEmail = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Home");
            }

            // Get user details from session
            ViewBag.FullName = HttpContext.Session.GetString("FullName");
            ViewBag.BloodGroup = HttpContext.Session.GetString("BloodGroup");

            // Open Dashboard page
            return View();
        }
    }
}