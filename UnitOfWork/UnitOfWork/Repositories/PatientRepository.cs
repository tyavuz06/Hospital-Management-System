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
    public class PatientRepository
    {
        IUnitOfWork _unitOfWork;
        public PatientRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("NULL");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = uow as AdoNetUnitOfWork;
            if (_unitOfWork == null)
                throw new NotImplementedException("Sorry we cant support at the moment...");
        }

        public List<Patient> GetAllPatientsL()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT id AS 'Patient Number',identity_no AS 'Identity Number', full_name AS 'Patient Name', birthdate AS 'Birth Date', phone AS 'Phone',address AS 'Address', blood_type AS 'Blood Type',social_security AS 'Social Security' FROM Patient WHERE is_deleted=0";

            IDataReader dataReader = command.ExecuteReader();

            List<Patient> patients = new List<Patient>();

            while (dataReader.Read())
            {
                Patient patient = new Patient()
                {
                    ID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    BirthDate = dataReader.GetDateTime(3),
                    Phone = dataReader.GetString(4),
                    Adress = dataReader.GetString(5),
                    BloodType = (Enums.BloodType)dataReader.GetInt32(6),
                    SocialSecurity = (Enums.SocialSecurity)dataReader.GetInt32(7)
                };
                patients.Add(patient);
            }
            dataReader.Close();
            return patients;
        }

        /*public List<Patient> FindPatient(string PatientName)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            PatientName = "%" + PatientName + "%";
            command.CommandText = "SELECT * FROM Patient WHERE is_deleted=0 AND full_name LIKE @name";
            command.Parameters.Add(new SqlParameter("@name", PatientName));
            IDataReader dataReader = command.ExecuteReader();

            List<Patient> patients = new List<Patient>();

            while (dataReader.Read())
            {
                Patient patient = new Patient()
                {
                    PatientID = dataReader.GetInt32(0),
                    IdentityNo = dataReader.GetString(1),
                    FullName = dataReader.GetString(2),
                    BirthDate = dataReader.GetDateTime(3),
                    Phone = dataReader.GetString(4),
                    Adress = dataReader.GetString(5),
                    BloodType = (Enums.BloodType)dataReader.GetByte(6),
                    SocialSecurity = (Enums.SocialSecurity)dataReader.GetByte(7)
                };
                patients.Add(patient);
            }
            dataReader.Close();
            return patients;
        }*/

        public int AddPatient(Patient patient)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "INSERT INTO Patient VALUES(@identity_no,@full_name,@birth_date,@phone,@adress,@blood_type,@social_security,0)";
            command.Parameters.Add(new SqlParameter("@identity_no", patient.IdentityNo));
            command.Parameters.Add(new SqlParameter("@full_name", patient.FullName));
            command.Parameters.Add(new SqlParameter("@phone", patient.Phone));
            command.Parameters.Add(new SqlParameter("@adress", patient.Adress));
            command.Parameters.Add(new SqlParameter("@birth_date", patient.BirthDate));
            command.Parameters.Add(new SqlParameter("@blood_type", patient.BloodType));
            command.Parameters.Add(new SqlParameter("@social_security", patient.SocialSecurity));

            int data = command.ExecuteNonQuery();
            return data;
        }
        public DataTable GetAllPatients()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT * FROM Patient WHERE is_deleted=0";
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public DataTable FindPatient(string patientName)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            patientName = "%" + patientName + "%";
            cmd.CommandText = "SELECT id AS 'Patient Number',identity_no AS 'Identity Number', full_name AS 'Patient Name', birthdate AS 'Birth Date', phone AS 'Phone',address AS 'Address', blood_type AS 'Blood Type',social_security AS 'Social Security' FROM Patient WHERE is_deleted=0 AND full_name LIKE @name";
            cmd.Parameters.Add(new SqlParameter("@name", patientName));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public int DeletePatient(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Patient SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdatePatient(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Patient SET identity_no=@ino, full_name=@name, birthdate=@bdate, phone=@phone, address=@address, blood_type=@btype, social_security=@sc WHERE id=@id ";
            string[] columns = new string[] { "@id", "@ino", "@name", "@bdate", "@phone", "@address", "@btype", "@sc" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 7)
                {
                    if (index == 6)
                    {
                        cmd.Parameters.Add(new SqlParameter(columns[index], (int)Enum.Parse(typeof(Enums.BloodType), (string)item.Value)));
                    }
                    else if(index==7)
                    {
                        cmd.Parameters.Add(new SqlParameter(columns[index], (int)Enum.Parse(typeof(Enums.SocialSecurity), (string)item.Value)));
                    }
                    else
                        cmd.Parameters.Add(new SqlParameter(columns[index], item.Value));
                }
                index++;
            }
            int data = cmd.ExecuteNonQuery();
            return data;
        }
    }
}
