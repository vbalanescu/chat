using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        public DateTime date { get; set; }
        public int doctorId { get; set; }

    }
}