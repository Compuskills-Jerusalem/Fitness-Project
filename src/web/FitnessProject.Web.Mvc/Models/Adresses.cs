
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Web.Mvc.Models
{
    public class Adresses
    {
        [Required]
        public string Address { get; set; }
       public string PlaceName { get; set; }
    }
}