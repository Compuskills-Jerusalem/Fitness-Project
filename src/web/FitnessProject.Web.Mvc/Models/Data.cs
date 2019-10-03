
   

    namespace FitnessProject.Web.Mvc
{

        public class MapsApiResponse
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
