using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blood_Donation_Management.Models;
using Blood_Donation_Management.TaskDbContext;

namespace Blood_Donation_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Home Page
        public IActionResult Index()
        {
            return View();
        }

        // Register Page
        public IActionResult Register()
        {
            return View();
        }

        // Register User
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if email already exists
            bool emailExists = await _context.Users.AnyAsync(u => u.Email == model.Email);

            if (emailExists)
            {
                ModelState.AddModelError("Email", "Email already exists!");
                return View(model);
            }

            // Save new user
            model.Id = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;

            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Registration Successful! You can now login.";

            return RedirectToAction("Login");
        }

        // Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Login User
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check email and password
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == model.Email &&
                u.Password == model.Password);

            if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View(model);
            }

            // Store user information in session
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("FullName", user.FullName);
            HttpContext.Session.SetString("BloodGroup", user.BloodGroup);

            return RedirectToAction("Index", "Dashboard");
        }

        // Logout User
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}