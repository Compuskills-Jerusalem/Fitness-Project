﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class Sensor
    {
        public int SensorID { get; set; }
        
        public string SensorName { get; set; }
        public ICollection<UserSensor> UserSensors { get; set; }
    }
}