using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProjectWebApplication.Models
{
    public class Measurement
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public int SessionNumber { get; set; }
        public DateTime Date { get; set; }
        public float Pressure { get; set; }
    }
}
