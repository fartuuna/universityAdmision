using Microsoft.AspNetCore.Mvc;
using UniversityAdmisionApplcation.Models;
using UniversityAdmisionApplcation.Database;
using UniversityAdmisionApplcation.SMSService;
namespace UniversityAdmisionApplcation.Controllers
{


    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContex _context;

        public RegistrationController(ApplicationDbContex context)
        {
            _context = context;
        }
        public IActionResult Register()
            
        {
         ViewBag.faculties = _context.faculties.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Register( Registration obj, IFormFile File)
        {
            if (obj.EducationLevel=="2")
            {
                obj.EducationLevel = "Master Degree";
            }else if (obj.EducationLevel=="1")
            {
                obj.EducationLevel = "Bcholar";

            }
            else if (obj.EducationLevel=="2")
            {
               
                obj.EducationLevel = "PHD";
            }

            obj.Role = "Student";
            obj.File = File.FileName;
            _context.Registrations.Add(obj);
           var result = _context.SaveChanges();
            if (result >0)
            {
            var ob = new API();
               var res = ob.SendSMS(obj.MobileNumber, "waa ku mahadsanthy dalabkaaga");
                TempData["ErrorMassege"] = "success";
            }
            else
            {
                TempData["ErrorMassege"] = "Error";
            }

            ViewBag.faculties = _context.faculties.ToList();

            return View();
        }
    }
}
