using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.Web.Mvc.Models
{
    public class LocationMap
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}