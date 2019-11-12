﻿using System.Collections.Generic;
using System.Linq;
using DatabaseConn;
namespace FitnessProject.Web.Mvc.Services
{
    public class AddRemoveFromDbModel
    {


        public void AddToJoinTable(string username,string address)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var user = fitt.Users.FirstOrDefault(x => x.Name == username);
                var noGoZone = fitt.NoGoZones.FirstOrDefault(x => x.Address == address);
                fitt.UserNoGoZones.Add(new UserNoGoZone { UserId = user.UserID, NoGoZoneID = noGoZone.NoGoZoneID });
                fitt.SaveChanges();
            }
        }
        public IQueryable FindNoGoId(string username,int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var noGoZone = from nogo in fitt.UserNoGoZones
                               where nogo.UserNoGoZoneID == id
                               select nogo.NoGoZoneID;
              
                return noGoZone;
            }
        }

      
        }
    }
