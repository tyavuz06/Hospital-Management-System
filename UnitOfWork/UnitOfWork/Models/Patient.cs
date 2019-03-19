using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class Patient
    {
        public int ID { get; set; }
        public string IdentityNo { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public Enums.BloodType BloodType { get; set; }
        public Enums.SocialSecurity SocialSecurity { get; set; }
    }
}
