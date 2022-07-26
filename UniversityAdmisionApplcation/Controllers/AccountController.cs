using Microsoft.AspNetCore.Mvc;
using UniversityAdmisionApplcation.Database;
using UniversityAdmisionApplcation.Models;

namespace UniversityAdmisionApplcation.Controllers
{
    public class AccountController : Controller
    { 
            private readonly ApplicationDbContex _context;

    public AccountController(ApplicationDbContex context)
    {
        _context = context;
    }
    
        public IActionResult Sign()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Sign(Login lg)

        {
            var result = _context.Registrations.Where(r => r.Username == lg.Username && r.Password == lg.Password).ToList();
            if(result.Count > 0)
            {
                ViewBag.profile = result;
                foreach (var r in result)
                {
                    ViewBag.FirstName = r.FirstName;

                    ViewBag.LastName = r.LastName;
                    if (r.Role == "Student")
                    {
                        ViewBag.Title = "Applicant";
                    }
                    else
                    {
                        ViewBag.Title = r.Role;
                    }
                    }

                
                return RedirectToAction("DashboardPage", "Dashboard");
                
            }
            TempData["ErrorMassege"] = "Error";

            return View();
        }


        public IActionResult Forget()
        {
            return View();
        }
    }
}
