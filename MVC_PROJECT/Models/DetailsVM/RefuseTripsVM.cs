using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PROJECT.Models.DetailsVM
{
    public class RefuseTripsVM
    {
        public int Id_refuse { get; set; }
        public string TextRefuse { get; set; }
        public int ID_Org { get; set; }
        public int Id_t { get; set; }
        public IEnumerable<Trips> trips { get; set; }
    }
}