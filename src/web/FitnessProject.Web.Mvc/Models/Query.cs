﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.Web.Mvc.Models
{
    public class Query
    {
        public IQueryable UserQuery(string name)
        {
            using (var fitt = new FittAppContext())
            {

                //  e model item passed into the dictionary is of type 'System.Data.Entity.Infrastructure.DbQuery`1[<>f__AnonymousType3`3[System.String,System.Double,System.Double]]', but this dictionary requires a model item of type 'System.Collections.Generic.IEnumerable`1[FitnessProjectServerSide.Models.NoGoZone]'.
                var model = from person in fitt.UserNoGoZones
                            where person.users.Name == name
                            select new
                            {
                                person.NoGoZones.Address,
                                person.NoGoZones.Laditude,
                                person.NoGoZones.Longitude,
                            };
                return model;
            }
        }
    }
}