using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PROJECT.Models
{
    public class EditTravelsVM
    {
        public DateTime DateEnd { get; set; }
        public string Descripition { get; set; }
        public string Distance { get; set; }
        public int Number_of_passengers { get; set; }
        public string Start_Location { get; set; }
        public string Station_Start { get; set; }
        public string DescripitionStation { get; set; }
    }
}