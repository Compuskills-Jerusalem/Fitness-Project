

using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Web.Mvc
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PlaceName { get; set; }
        }
    }
