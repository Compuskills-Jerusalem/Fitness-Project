﻿using System;
using System.Collections.Generic;
namespace FitnessProjectServerSide.Models
{
    public class NoGoZone
    {
       /* public NoGoZone()
        {
            this.Users = new HashSet<User>();
        }*/
        public int id { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZones { get; set; }
        public string Address { get; set; }
        public double Laditude { get; set; }
        public double Longitude { get; set; }
      //  public virtual ICollection<User> Users { get; set; }

       
    }
}
