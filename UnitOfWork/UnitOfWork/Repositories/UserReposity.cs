using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitOfWork
{
    public class UserRepository
    {
        private IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = (uow as AdoNetUnitOfWork);
            if (_unitOfWork == null)
                throw new NotSupportedException("Ohh my, change that UnitOfWorkFactory, will you?");
        }

        public int CreateUser(User u)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "INSERT INTO Users (username,full_name) VALUES (@username,@name)";
            command.Parameters.Add(new SqlParameter("@username", u.userName));
            command.Parameters.Add(new SqlParameter("@name", u.Name));
            int resultData = command.ExecuteNonQuery();
            return resultData;
        }
        /*public List<User> GetAllUsers()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT * FROM Users WHERE is_deleted=0";

            IDataReader dataReader = command.ExecuteReader();

            List<User> users = new List<User>();

            while(dataReader.Read())
            {
                User user = new User()
                {
                    ID=dataReader.GetInt32(0),
                    userName=dataReader.GetString(1),
                    Password=dataReader.GetString(2),
                    Name=dataReader.GetString(3),
                    Surname=dataReader.GetString(4),
                    WrongCount=dataReader.GetInt32(5),
                    isActive=dataReader.GetBoolean(6)
                };
                users.Add(user);
            }
            dataReader.Close();
            return users;
        }*/

        /*public List<User> FindUser(string content)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            content = "%" + content + "%";
            command.CommandText = "SELECT * FROM Users WHERE username LIKE @name'";
            command.Parameters.Add(new SqlParameter("@name", content));
            IDataReader dataReader = command.ExecuteReader();

            List<User> users = new List<User>();
            while (dataReader.Read())
            {
                User user = new User()
                {
                    ID = dataReader.GetInt32(0),
                    userName = dataReader.GetString(1),
                    Password = dataReader.GetString(2),
                    Name = dataReader.GetString(3),
                    Surname = dataReader.GetString(4),
                    WrongCount = dataReader.GetInt32(5),
                    isActive = dataReader.GetBoolean(6)
                };
                users.Add(user);
            }
            dataReader.Close();
            return users;
        }*/

        public DataTable GetAllUsers()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE is_deleted=0";
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public int FindUser(string userName, string password)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT username FROM Users WHERE is_deleted=0 AND isActive=1 AND username=@name AND password=@password";
            cmd.Parameters.Add(new SqlParameter("@name", userName));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            string username = (string)cmd.ExecuteScalar();
            if (username != null)
            {
                IDbCommand cmd2 = _unitOfWork.CreateCommand();
                cmd2.CommandText = "SELECT id FROM Doctor WHERE email=@username";
                cmd2.Parameters.Add(new SqlParameter("@username", username));
                object data = cmd2.ExecuteScalar();
                if (data == null)
                {
                    return 0;
                }
                else
                    return (int)data;
            }
            else
                return -1;
        }
        public DataTable FindUserName(string content)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE is_deleted=0 AND full_name LIKE @name";
            content = "%" + content + "%";
            cmd.Parameters.Add(new SqlParameter("@name", content));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public int DeleteUser(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Users SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdateUser(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Users SET username=@username,password=@password,full_name=@name WHERE id=@id ";
            string[] columns = new string[] { "@id", "@username", "@password", "@name" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 3)
                {
                    cmd.Parameters.Add(new SqlParameter(columns[index], item.Value));
                }
                index++;
            }
            int data = cmd.ExecuteNonQuery();
            return data;
        }
    }
}
