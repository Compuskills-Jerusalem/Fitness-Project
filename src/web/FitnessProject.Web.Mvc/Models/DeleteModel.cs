using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.Web.Mvc.Models
{
    public class DeleteModel
    {
        public int UserNoGoZonesID { get; set; }
        public int UserId { get; set; }
        public int NoGoZoneId { get; set; }
        public string Address { get; set; }
        public string name { get; set; }
    }
}