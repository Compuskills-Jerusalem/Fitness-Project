//using System.Collections.Generic;
//using System.Linq;
//using FitnessProject.Web.Domain;
//namespace FitnessProject.Web.Mvc.Services
//{
//    public class AddRemoveFromDbModel
//    {


//        public void AddToJoinTable(string username,string address)
//        {
//            using (FitnessAppContext fitt = new FitnessAppContext())
//            {
//                var user = fitt.Users.FirstOrDefault(x => x.Name == username);
//                var noGoZone = fitt.NoGoZones.FirstOrDefault(x => x.Address == address);
//                fitt.UserNoGoZones.Add(new UserNoGoZone { UserId = user.UserID, NoGoZoneID = noGoZone.NoGoZoneID });
//                fitt.SaveChanges();
//            }
//        }    
//        }
//    }

