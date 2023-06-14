using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_PROJECT.Models.DetailsVM
{
    public class NoticationVM
    {

        public int Id_To { get; set; }

        [Required]
        public string ReplyText { get; set; }

        public IEnumerable<Complaints> complaint { get; set; }
    }
}