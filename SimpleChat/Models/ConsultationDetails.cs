using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class ConsultationDetails
    {
        public int id { get; set; }
        public int idC { get; set; }
        public DateTime date { get; set; }
        public string details { get; set; }
    }
}