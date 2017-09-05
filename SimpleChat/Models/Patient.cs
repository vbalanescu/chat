using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime dateB { get; set; }
        public string cnp { get; set; }
        public string address { get; set; }
    }
}