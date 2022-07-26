using Microsoft.AspNetCore.Mvc;
using UniversityAdmisionApplcation.Database;

namespace UniversityAdmisionApplcation.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContex _context;

        public ApplicationController (ApplicationDbContex context)
        {
            _context = context;
        }
           
        public IActionResult Applications()
        {
            
         var result = _context.Registrations.ToList();

            return View();
        }

        public IActionResult Process()
        {
            return View();
        }
    }
}
