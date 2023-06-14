using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PROJECT.Models.DetailsVM
{
    public class DetailsTripsVM
    {
       
        // Table TripDetails
        public int ID_Trip { get; set; }
        public DateTime DateEnd { get; set; }
        public string Descripition { get; set; }
        public string Start_Location { get; set; }
        public string Distance { get; set; }
        // Table TripsStation 
        //public int ID_Station { get; set; }
        public string NameBreak { get; set; }
        public string Station_Start { get; set; }
        public string DescripitionStation { get; set; }
    }
}
