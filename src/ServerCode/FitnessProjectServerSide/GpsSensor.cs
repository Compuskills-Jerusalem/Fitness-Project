﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProjectServerSide
{
    public class GpsSensor : ISensor
    {
        public int SensorID { get; set; }

        public bool ShouldAlertUser()
        {
            return true;
        }
        public GpsSensor(Geolocation PersonsLocation )
        {

        }
    }
}