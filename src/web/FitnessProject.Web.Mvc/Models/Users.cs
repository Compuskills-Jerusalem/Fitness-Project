
using System.ComponentModel.DataAnnotations;
namespace FitnessProject.Web.Mvc.Models
{
    public class Users

    {
        public int id { get; set; }
        [Required]
            public string Name { get; set; }     
            public string Email { get; set; }
    }
}