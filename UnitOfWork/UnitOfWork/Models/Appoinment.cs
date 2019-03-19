using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Models
{
    public class Appoinment
    {
        public int ID { get; set; }
        public int Doctor { get; set; }
        public int Patient { get; set; }
        public int Unit { get; set; }
        public int Polyclinic { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool Preemptor { get; set; }
        public bool Situation { get; set; }
    }
}
