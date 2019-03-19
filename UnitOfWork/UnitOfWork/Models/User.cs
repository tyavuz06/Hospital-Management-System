using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class User
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int WrongCount { get; set; }
        public bool isActive { get; set; }
    }
}
