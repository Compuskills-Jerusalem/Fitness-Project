using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json; //added JSON.NET with Nuget
using Newtonsoft.Json.Linq;

using FitnessProjectServerSide.Models;


namespace FitnessProjectServerSide.Controllers
{
   
    public class LocateController : ApiController
    {
       
        [HttpPost]
      public void Find(LocateLadLon location)
        {
            using (FittApp fitt = new FittApp())
            {
                fitt.NoGoZones.Add(new NoGoZone {Laditude= })
            }
        }
        l


    }
}
