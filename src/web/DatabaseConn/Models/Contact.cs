using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Domain
{
   public class Contact
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
    }
}
