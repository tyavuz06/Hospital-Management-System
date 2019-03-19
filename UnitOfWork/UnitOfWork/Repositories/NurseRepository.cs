using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitOfWork
{
    public class NurseRepository
    {
        IUnitOfWork _unitOfWork;
        public NurseRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = uow as AdoNetUnitOfWork;
            if (_unitOfWork == null)
                throw new NotSupportedException("Ohh my, change that UnitOfWorkFactory, will you?");
        }

        public int AddNurse(Nurse nurse)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "INSERT INTO  Nurse (unit_id,identity_no,full_name,phone,email,address,birth_date,salary,work_type,chief_nurse,polyclinic_ID)VALUES(@unit_id,@identity_no,@full_name,@phone,@email,@adress,@birth_date,@salary,@work_type,@chief_nurse,@polyclinic_ID)";
            command.Parameters.Add(new SqlParameter("@unit_id", nurse.Unit));
            command.Parameters.Add(new SqlParameter("@identity_no", nurse.IdentityNo));
            command.Parameters.Add(new SqlParameter("@full_name", nurse.FullName));
            command.Parameters.Add(new SqlParameter("@phone", nurse.Phone));
            command.Parameters.Add(new SqlParameter("@email", nurse.Email));
            command.Parameters.Add(new SqlParameter("@adress", nurse.Adress));
            command.Parameters.Add(new SqlParameter("@birth_date", nurse.BirthDate));
            command.Parameters.Add(new SqlParameter("@salary", nurse.Salary));
            command.Parameters.Add(new SqlParameter("@work_type", nurse.WorkType));
            command.Parameters.Add(new SqlParameter("@chief_nurse", nurse.IsCheafNurse));
            command.Parameters.Add(new SqlParameter("@polyclinic_ID", nurse.Polyclinic));

            int data = command.ExecuteNonQuery();
            return data;
        }

        public List<Nurse> GetAllNursesL()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT id AS 'Nurse No',identity_no AS 'Identity Number', full_name AS 'Full Name', phone AS 'Phone', email AS 'E-Mail', address AS 'Address',birth_date AS 'Birth Date', salary AS 'Salary', work_type AS 'Work Type', chief_nurse AS 'Is Chief Nurse', polyclinic_ID AS ' Polyclinic', unit_id AS 'Unit' FROM Nurse WHERE is_deleted=0";

            IDataReader dataReader = command.ExecuteReader();

            List<Nurse> nurses = new List<Nurse>();

            while (dataReader.Read())
            {
                Nurse nurse = new Nurse()
                {
                    ID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    Phone = dataReader.GetString(3),
                    Email = dataReader.GetString(4),
                    Adress = dataReader.GetString(5),
                    BirthDate = dataReader.GetDateTime(6),
                    Salary = dataReader.GetDecimal(7),
                    WorkType = (Enums.NurseWorkType)dataReader.GetByte(8),
                    IsCheafNurse = dataReader.GetBoolean(9),
                    Polyclinic = dataReader.GetInt32(10),
                    Unit = dataReader.GetInt32(11),
                };
                nurses.Add(nurse);
            }
            dataReader.Close();
            return nurses;
        }

        /*public List<Nurse> FindNurse(string content)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            content = "%" + content + "%";
            command.CommandText = "SELECT * FROM Nurse WHERE full_name LIKE @name";
            command.Parameters.Add(new SqlParameter("@name",content));
            IDataReader dataReader = command.ExecuteReader();

            List<Nurse> nurses = new List<Nurse>();
            while (dataReader.Read())
            {
                Nurse nurse = new Nurse()
                {
                    ID = dataReader.GetInt32(0),
                    Unit = dataReader.GetInt32(1),
                    IdentityNo = dataReader.GetString(2),
                    FullName = dataReader.GetString(3),
                    Phone = dataReader.GetString(4),
                    Email = dataReader.GetString(5),
                    Adress = dataReader.GetString(6),
                    BirthDate = dataReader.GetDateTime(7),
                    AnnualLeave = dataReader.GetByte(8),
                    AnnualLeaveReport = dataReader.GetByte(9),
                    Salary = dataReader.GetDecimal(10),
                    WorkType = (Enums.NurseWorkType)dataReader.GetByte(11),
                    IsCheafNurse = dataReader.GetBoolean(12),
                    Polyclinic = dataReader.GetInt32(13)
                };
                nurses.Add(nurse);
            }
            dataReader.Close();
            return nurses;
        }*/
        public DataTable GetAllNurses()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT * FROM Nurse WHERE is_deleted=0";
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public DataTable FindNurse(string content)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT id AS 'Nurse No',identity_no AS 'Identity Number', full_name AS 'Full Name', phone AS 'Phone', email AS 'E-Mail', address AS 'Address',birth_date AS 'Birth Date', salary AS 'Salary', work_type AS 'Work Type', chief_nurse AS 'Is Chief Nurse', polyclinic_ID AS ' Polyclinic', unit_id AS 'Unit' FROM Nurse WHERE is_deleted=0 AND full_name LIKE @name";
            content = "%" + content + "%";
            cmd.Parameters.Add(new SqlParameter("@name", content));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public int DeleteNurse(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Nurse SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }
        public int SetAnnualLeave(Models.AnnualLeave annualLeave)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "INSERT INTO AnnualLeave VALUES(@worker_type,@worker_id,@duration,@leave_type,null)";
            cmd.Parameters.Add(new SqlParameter("@worker_type", annualLeave.WorkerType));
            cmd.Parameters.Add(new SqlParameter("@worker_id", annualLeave.WorkerID));
            cmd.Parameters.Add(new SqlParameter("@duration", annualLeave.Duration));
            cmd.Parameters.Add(new SqlParameter("@leave_type", annualLeave.LeaveType));
            int data = cmd.ExecuteNonQuery();
            return data;
        }
        public int UpdateNurse(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Nurse SET identity_no=@ino, full_name=@name, birth_date=@bdate, phone=@phone, email=@email, address=@address,  salary=@salary, work_type=@wtype, unit_id=@uid, polyclinic_ID=@pid, chief_nurse=@cnurse WHERE id=@id ";
            string[] columns = new string[] { "@id", "@ino", "@name", "@phone", "@email", "@address", "@bdate", "@salary", "@cnurse" ,"@wtype", "@pid", "@uid" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 11)
                {
                    if (index == 9)
                    {
                        cmd.Parameters.Add(new SqlParameter(columns[index], (int)Enum.Parse(typeof(Enums.NurseWorkType), (string)item.Value)));
                    }
                    else
                        cmd.Parameters.Add(new SqlParameter(columns[index], item.Value));
                }
                index++;
            }
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int InsertAnnual(Models.AnnualLeave annualLeave)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "INSERT INTO WorkerLeave (worker_id,worker_type,duration,leave_type)VALUES(@wid,@wtype,@duration,@ltype)";
            cmd.Parameters.Add(new SqlParameter("@wid", annualLeave.WorkerID));
            cmd.Parameters.Add(new SqlParameter("@wtype", annualLeave.WorkerType));
            cmd.Parameters.Add(new SqlParameter("@duration", annualLeave.Duration));
            cmd.Parameters.Add(new SqlParameter("@ltype", annualLeave.LeaveType));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public void CheckLeave()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "sp_CheckHoliday";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@workerType", 2));
            int data = cmd.ExecuteNonQuery();
        }
    }
}
