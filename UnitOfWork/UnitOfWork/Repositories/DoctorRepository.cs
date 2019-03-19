using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitOfWorkDLL2;
namespace UnitOfWork
{
    public class DoctorRepository
    {
        IUnitOfWork _unitOfWork;
        public DoctorRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("NULL");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = uow as AdoNetUnitOfWork;
            if (_unitOfWork == null)
                throw new NotImplementedException("Sorry we cant suppot at the moment..");
        }
        public List<Doctor> GetAllDoctorsForAppointment()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT * FROM Doctor WHERE is_deleted=0 AND onHoliday=0";

            IDataReader dataReader = command.ExecuteReader();

            List<Doctor> doctors = new List<Doctor>();

            while (dataReader.Read())
            {
                Doctor doctor = new Doctor()
                {
                    ID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    BirthDate = dataReader.GetDateTime(3),
                    Phone = dataReader.GetString(4),
                    Email = dataReader.GetString(5),
                    Adress = dataReader.GetString(6),
                    AnnualLeave = dataReader.GetByte(7),
                    AnnualLeaveReport = dataReader.GetByte(8),
                    NumberOfDailyPatient = dataReader.GetInt32(9),
                    ExtraPatient = dataReader.GetInt32(10),
                    Salary = dataReader.GetDecimal(11),
                    isAdult = dataReader.GetBoolean(12),
                    doOperation = dataReader.GetBoolean(13),
                    NumberOfOperation = dataReader.GetInt32(14),
                    Unit = dataReader.GetInt32(15),
                    Polyclinic = dataReader.GetInt32(16)
                };
                doctors.Add(doctor);
            }
            dataReader.Close();
            return doctors;
        }

        public List<Doctor> GetTempDoctor(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT * FROM Doctor WHERE id NOT IN (@id)";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            IDataReader dataReader = cmd.ExecuteReader();

            List<Doctor> doctors = new List<Doctor>();

            while (dataReader.Read())
            {
                Doctor doctor = new Doctor()
                {
                    ID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    BirthDate = dataReader.GetDateTime(3),
                    Phone = dataReader.GetString(4),
                    Email = dataReader.GetString(5),
                    Adress = dataReader.GetString(6),
                    AnnualLeave = dataReader.GetByte(7),
                    AnnualLeaveReport = dataReader.GetByte(8),
                    NumberOfDailyPatient = dataReader.GetInt32(9),
                    ExtraPatient = dataReader.GetInt32(10),
                    Salary = dataReader.GetDecimal(11),
                    isAdult = dataReader.GetBoolean(12),
                    doOperation = dataReader.GetBoolean(13),
                    NumberOfOperation = dataReader.GetInt32(14),
                    Unit = dataReader.GetInt32(15),
                    Polyclinic = dataReader.GetInt32(16)
                };
                doctors.Add(doctor);
            }
            dataReader.Close();
            return doctors;
        }

        public List<Doctor> GetAllDoctorsL()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT * FROM Doctor WHERE is_deleted=0";

            IDataReader dataReader = command.ExecuteReader();

            List<Doctor> doctors = new List<Doctor>();

            while (dataReader.Read())
            {
                Doctor doctor = new Doctor()
                {
                    ID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    BirthDate = dataReader.GetDateTime(3),
                    Phone = dataReader.GetString(4),
                    Email = dataReader.GetString(5),
                    Adress = dataReader.GetString(6),
                    AnnualLeave = dataReader.GetByte(7),
                    AnnualLeaveReport = dataReader.GetByte(8),
                    NumberOfDailyPatient = dataReader.GetInt32(9),
                    ExtraPatient = dataReader.GetInt32(10),
                    Salary = dataReader.GetDecimal(11),
                    isAdult = dataReader.GetBoolean(12),
                    doOperation = dataReader.GetBoolean(13),
                    NumberOfOperation = dataReader.GetInt32(14),
                    Unit = dataReader.GetInt32(15),
                    Polyclinic = dataReader.GetInt32(16)
                };
                doctors.Add(doctor);
            }
            dataReader.Close();
            return doctors;
        }
        public Doctor GetDoctorL(int id)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT * FROM Doctor WHERE is_deleted=0 AND id=@id";
            command.Parameters.Add(new SqlParameter("@id", id));

            IDataReader dataReader = command.ExecuteReader();
            Doctor doctor = null;
            while (dataReader.Read())
            {
                doctor = new Doctor()
                {
                    ID = dataReader.GetInt32(0),
                    FullName = dataReader.GetString(2),
                };
            }
            dataReader.Close();
            return doctor;
        }
        /*public List<Doctor> FindDoctor(string DoctorName)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            DoctorName = "%" + DoctorName + "%";
            command.CommandText = "SELECT * FROM Doctor WHERE is_deleted=0 AND [full_name] LIKE @name";
            command.Parameters.Add(new SqlParameter("@name", DoctorName));
            IDataReader dataReader = command.ExecuteReader();

            List<Doctor> doctors = new List<Doctor>();

            while (dataReader.Read())
            {
                Doctor doctor = new Doctor()
                {
                    ID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    BirthDate = dataReader.GetDateTime(3),
                    Phone = dataReader.GetString(4),
                    Email = dataReader.GetString(5),
                    Adress = dataReader.GetString(6),
                    AnnualLeave = dataReader.GetByte(7),
                    AnnualLeaveReport = dataReader.GetByte(8),
                    NumberOfDailyPatient = dataReader.GetInt32(9),
                    ExtraPatient = dataReader.GetInt32(10),
                    Salary = dataReader.GetDecimal(11),
                    isAdult = dataReader.GetBoolean(12),
                    doOperation = dataReader.GetBoolean(13),
                    NumberOfOperation = dataReader.GetInt32(14),
                    Unit = dataReader.GetInt32(15),
                    Polyclinic = dataReader.GetInt32(16)
                };
                doctors.Add(doctor);
            }
            dataReader.Close();
            return doctors;
        }
        */
        public DataTable FindDoctor(string DoctorName)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            DoctorName = "%" + DoctorName + "%";
            cmd.CommandText = "SELECT id AS 'Doctor Number',identity_no AS 'Identity Number',full_name AS 'Doctor Name', birthdate AS 'Birth Date', phone AS 'Phone Number',email AS 'E-Mail', address AS 'Address', salary AS 'Salary', adult AS 'Is Adult', operation AS 'Do Operation', unit_id,polyclinic_id FROM Doctor WHERE is_deleted=0 AND full_name LIKE @name";
            cmd.Parameters.Add(new SqlParameter("@name", DoctorName));
            SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public DataTable GetAllDoctors()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT id AS 'Doctor Number',identity_no AS 'Identity Number',full_name AS 'Doctor Name', birthdate AS 'Birth Date', phone AS 'Phone Number',email AS 'E-Mail', address AS 'Address', salary AS 'Salary', adult AS 'Is Adult', operation AS 'Do Operation', polyclinic_id AS 'Polyclinics',unit_id FROM Doctor WHERE is_deleted=0";
            SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public int AddDoctor(Doctor doc)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "INSERT INTO Doctor (identity_no,full_name,birthdate,phone,email,address,salary,adult,operation,unit_id,polyclinic_id) VALUES (@identityNo,@fullName,@birthDate,@phone,@email,@address,@salary,@adult,@operation,@unit,@polyclinic)";
            cmd.Parameters.Add(new SqlParameter("@identityNo", doc.IdentityNo));
            cmd.Parameters.Add(new SqlParameter("@fullName", doc.FullName));
            cmd.Parameters.Add(new SqlParameter("@birthDate", doc.BirthDate));
            cmd.Parameters.Add(new SqlParameter("@phone", doc.Phone));
            cmd.Parameters.Add(new SqlParameter("@email", doc.Email));
            cmd.Parameters.Add(new SqlParameter("@address", doc.Adress));
            cmd.Parameters.Add(new SqlParameter("@salary", doc.Salary));
            cmd.Parameters.Add(new SqlParameter("@adult", doc.isAdult));
            cmd.Parameters.Add(new SqlParameter("@operation", doc.doOperation));
            cmd.Parameters.Add(new SqlParameter("@unit", doc.Unit));
            cmd.Parameters.Add(new SqlParameter("@polyclinic", doc.Polyclinic));
            int data = cmd.ExecuteNonQuery();

            /*IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "INSERT INTO Users (username,password,name,surname) VALUES (@username,@password,@name,@surname)";
            command.Parameters.Add(new SqlParameter("@username", doc.Email));
            command.Parameters.Add(new SqlParameter("@password", doc.IdentityNo));
            string[] arr = doc.FullName.Split(' ');
            command.Parameters.Add(new SqlParameter("@name", arr[0]));
            command.Parameters.Add(new SqlParameter("@surname", arr[1]));
            data = command.ExecuteNonQuery();*/
            return data;
        }
        public int DeleteDoctor(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Doctor SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdateDoctor(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Doctor SET identity_no=@ino, full_name=@name, birthdate=@bdate, phone=@phone, email=@email, address=@address,  salary=@salary, adult=@adult,operation=@operation, unit_id=@uid, polyclinic_id=@pid WHERE id=@id ";
            string[] columns = new string[] { "@id", "@ino", "@name", "@bdate", "@phone", "@email", "@address", "@salary", "@adult", "@operation",  "@pid", "@uid" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 11)
                {
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
            cmd.CommandText = "INSERT INTO WorkerLeave (worker_id,worker_type,duration,leave_type,temp_doc)VALUES(@wid,@wtype,@duration,@ltype,@tdoc)";
            cmd.Parameters.Add(new SqlParameter("@wid", annualLeave.WorkerID));
            cmd.Parameters.Add(new SqlParameter("@wtype", annualLeave.WorkerType));
            cmd.Parameters.Add(new SqlParameter("@duration", annualLeave.Duration));
            cmd.Parameters.Add(new SqlParameter("@ltype", annualLeave.LeaveType));
            cmd.Parameters.Add(new SqlParameter("@tdoc", annualLeave.DocID));
            int data = cmd.ExecuteNonQuery();

            return data;
        }
        public void CheckLeave()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "sp_CheckHoliday";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@workerType", 1));
            int data = cmd.ExecuteNonQuery();
        }
    }
}
