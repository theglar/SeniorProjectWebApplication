using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProjectWebApplication.Data
{
    public class Measurement
    {
        public int ID { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Session Number")]
        public int SessionNumber { get; set; }

        [Display(Name = "Time Stamp")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Pressure (PSI)")]
        public float Pressure { get; set; }
    }
}
