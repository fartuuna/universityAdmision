using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmisionApplcation.Models
{
    public class Registration
    {
     
      public int Id { get; set; }
        public int FaucultyId { get; set; }
        public string   Role { get; set; }
        public string FirstName { get; set; }
      public string LastName { get; set; }

        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        
        public string Address { get; set; }
      
        public string File { get; set; }
   
        public string Gender { get; set; } 
       
        public int Status { get; set; }
        public string EducationLevel { get; set; }
    }
}
