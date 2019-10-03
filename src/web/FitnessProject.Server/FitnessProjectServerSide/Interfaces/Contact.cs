using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
    }
}