using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PROJECT.Models
{
    public class MultibleData
    {
        //Table ClassificationTrips
        public int ID_Class { get; set; }
        public IEnumerable<ClassificationTrips> Type { get; set; }
        // Table TripDetails
        public string Name_Region { get; set; }
        // Table Break 
        public int ID_Break { get; set; }
        public IEnumerable<Breaks> breaks { get; set; }
        //Table Trips //8 fields
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Descripition { get; set; }
        public decimal Price { get; set; }
        public string Start_Location { get; set; }
        public int Number_of_passengers { get; set; }
        public string Distance { get; set; }
        public DateTime T_Announcement_Time { get; set; }
        // Table TripsStation 
        public string NameBreak { get; set; }
        public string Station_Start { get; set; }
        public string PhotoStation { get; set; }
        public string DescripitionStation { get; set; }
        public int NumberStation { get; set; }
        //Table photo Trip
        public string Photo_Trips { get; set; }
    }
}