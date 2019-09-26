using System;
using System.Collections.Generic;
namespace FitnessProject.Web.Mvc.Models
{
    public class NoGoZone
    {
       
        public int id { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZones { get; set; }
        public string Address { get; set; }
        public double Laditude { get; set; }
        public double Longitude { get; set; }
      

       
    }
}
