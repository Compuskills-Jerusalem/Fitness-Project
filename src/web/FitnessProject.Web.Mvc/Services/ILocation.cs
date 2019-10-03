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
    }
}
