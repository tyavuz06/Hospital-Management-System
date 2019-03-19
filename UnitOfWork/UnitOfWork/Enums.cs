using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class Enums
    {
        public enum CommonOperationType { OUser, ODoctor, ONurse, OUnit, OPatient, OPolyclinic, OAppoinment }
        public enum NurseWorkType { tip1, tip2, tip3 }
        public enum BloodType { ABPositive = 0, ABNegative = 1, APositive = 2, ANegative = 3, BPositive = 4, BNegative = 5, ZeroPositive = 6, ZeroNegative = 7 }
        public enum SocialSecurity { SKK, Bağkur }
        public enum UserType { User, Doctor }
    }
}
