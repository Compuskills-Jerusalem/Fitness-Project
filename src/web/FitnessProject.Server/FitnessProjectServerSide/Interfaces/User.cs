using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class User
    {
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
        public ICollection<UserSensor> UserSensors { get; set; }
    }
}