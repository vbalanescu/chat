using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class MessageC
    {
        public int Id { get; set; }
        public int IdS { get; set; }
        public int IdR { get; set; }
        public string MessageS { get; set; }
        public bool Seen { get; set; }
    }
}