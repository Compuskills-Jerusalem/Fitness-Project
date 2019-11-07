using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseConn;
namespace FitnessProject.Web.Mvc.Services
{
    public class FindUserId
    {
        public IQueryable GetUserId(string name)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
              var m=fitt.Users.Where(x=>x.)
                var model = from client in fitt.Users
                            where client.Name == name
                            select client.UserID;
                return model;
            }
            
           
        }
    }
}