using Microsoft.AspNetCore.Mvc;

namespace ComplaintManagementSystem.Controllers
{
    /// <summary>
    /// Home controller for user role selection
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Landing page - User role selection
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Set user role and redirect accordingly
        /// </summary>
        [HttpPost]
        public IActionResult SelectRole(string role)
        {
            if (role == "student")
            {
                HttpContext.Session.SetString("UserRole", "Student");
                return RedirectToAction("Index", "Complaints");
            }
            else if (role == "admin")
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Logout - Clear session
        /// </summary>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}