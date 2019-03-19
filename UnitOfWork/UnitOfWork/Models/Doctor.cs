using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class Doctor
    {
        public int ID { get; set; }
        public string IdentityNo { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public byte AnnualLeave { get; set; }
        public byte AnnualLeaveReport { get; set; }
        public int NumberOfDailyPatient { get; set; }
        public int ExtraPatient { get; set; }
        public decimal Salary { get; set; }
        public bool isAdult { get; set; }
        public bool doOperation { get; set; }
        public int NumberOfOperation { get; set; }
        public int Unit { get; set; }
        public int Polyclinic { get; set; }
        
    }
}
