using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Mvc.Models
{
    interface ILocation
    {
        void FindLocation(string address,string userName);
        void AddToJoinTable(string address, string username,string placeName);
      
       // void AvoidRepeating(string address, string username);
    }
}
