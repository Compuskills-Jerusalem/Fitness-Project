
     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace WebApplication1.Controllers
{
    public class Place
    {
        public string Address { get; set; }
    }

        public class Response
        {

            public string Status { get; set; }
            public Results[] Results { get; set; }

        }

        public class Results
        {
            public string Formatted_addres { get; set; }
            public geometry Geometry { get; set; }
            public string[] Types { get; set; }
            public address_component[] Address_components { get; set; }
        }

        public class geometry
        {
            public string Location_type { get; set; }
            public location Location { get; set; }
        }

        public class   location
        {
            public string Lat { get; set; }
            public string Lng { get; set; }
        }

        public class address_component
        {
            public string Long_name { get; set; }
            public string Short_name { get; set; }
            public string[] Types { get; set; }
        }
    }
