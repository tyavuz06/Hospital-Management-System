using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class Nurse
    {
        public int ID { get; set; }
        public string IdentityNo { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public byte AnnualLeave { get; set; }
        public byte AnnualLeaveReport { get; set; }
        public decimal Salary { get; set; }
        public Enums.NurseWorkType WorkType { get; set; }
        public bool IsCheafNurse { get; set; }
        public int Polyclinic{ get; set; }
        public int Unit { get; set; }
    }
}
