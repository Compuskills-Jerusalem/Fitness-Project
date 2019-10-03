using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class UserContact
    {
        public int UserContactID { get; set; }
        public virtual User User { get; set; }
        public virtual Contact Contact { get; set; }
        public string ContactValue { get; set; }            
    }
}