using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public class Connection
    {
        //public const string connectionString= @"Data Source=DESKTOP-AKNKVN7\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public const string connectionString = @"Data Source=WISSEN\MSSQL2017;Initial Catalog=HospitalDB;Integrated Security=False;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
