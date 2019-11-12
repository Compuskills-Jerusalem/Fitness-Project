
using System.ComponentModel.DataAnnotations;
namespace FitnessProject.Web.Mvc.Models
{
    public class Users
    {        [Required]
            public string Name { get; set; }  
               [Required]    
        public string Email { get; set; }
    }
}