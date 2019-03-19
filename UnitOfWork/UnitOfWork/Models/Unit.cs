using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class Unit
    {
        public int ID { get; set; }
        public int Polyclinic { get; set; }
        public string UnitName { get; set; }
        public byte UnitMaxDoctor { get; set; }
        public byte UnitMaxNurse { get; set; }
    }
}
