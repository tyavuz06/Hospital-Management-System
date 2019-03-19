using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Models
{
    public class AnnualLeave
    {
        public int ID { get; set; }
        public int WorkerID { get; set; }
        public int Duration { get; set; }
        public int LeaveType { get; set; }
        public int WorkerType { get; set; }
        public int DocID { get; set; }
    }
}
