using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    public class AppoinmentRepository
    {
        IUnitOfWork _unitOfWork;
        public AppoinmentRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new NullReferenceException("NULL");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = uow as AdoNetUnitOfWork;
            if (_unitOfWork == null)
                throw new NotImplementedException("Sorry We Cant Support you now...");
        }

        /*public List<Appoinment> GetAllAppoinments()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT * FROM Appointment WHERE is_deleted=0";
            IDataReader dr = command.ExecuteReader();
            List<Appoinment> appoinments = new List<Appoinment>();
            while (dr.Read())
            {
                Appoinment appoinment = new Appoinment()
                {
                    ID = dr.GetInt32(0),
                    Doctor = dr.GetInt32(1),
                    Patient = dr.GetInt32(2),
                    Unit = dr.GetInt32(3),
                    Polyclinic = dr.GetInt32(4),
                    AppointmentDate = dr.GetDateTime(5),
                    Preemptor = dr.GetBoolean(6),
                    Situation = dr.GetBoolean(7),
                };
                appoinments.Add(appoinment);
            }
            dr.Close();
            return appoinments;
        }
        */
        /* public List<Appoinment> FindAppointment(string patientName)
         {
             IDbCommand command = _unitOfWork.CreateCommand();
             command.CommandText = "SELECT * FROM Appointment A JOIN Patient P ON A.patient_id=P.id WHERE P.identity_no=@identity_no";
             command.Parameters.Add(new SqlParameter("@identity_no", patientName));
             IDataReader dr = command.ExecuteReader();
             List<Appoinment> appoinments = new List<Appoinment>();
             while (dr.Read())
             {
                 Appoinment appoinment = new Appoinment();
                 appoinment.ID = dr.GetInt32(0);
                 appoinment.Doctor = dr.GetInt32(1);
                 appoinment.Patient = dr.GetInt32(2);
                 appoinment.Unit = dr.GetInt32(3);
                 appoinment.Polyclinic = dr.GetInt32(4);
                 appoinment.AppointmentDate = dr.GetDateTime(5);
                 appoinment.Preemptor = dr.GetBoolean(6);
                 appoinment.Situation = dr.GetBoolean(7);
                 appoinments.Add(appoinment);
             }
             dr.Close();
             return appoinments;
         }*/
        public DataTable GetAllAppoinments()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            //cmd.CommandText = "SELECT D.full_name AS 'Doctor Name',P.full_name AS 'Patient Name',U.unit_name AS 'Unit Name',Pl.name AS 'Polyclinic Name',A.appointment_date,A.preemptor,A.situation  FROM Appointment A JOIN Doctor D ON A.doctor_id = D.id JOIN Patient P ON A.patient_id = P.id JOIN Unit U ON A.unit_id = u.id JOIN Polyclinic Pl ON U.polyclinic_id = Pl.id WHERE A.is_deleted = 0";
            cmd.CommandText = "SELECT A.id AS 'Appointment Number',A.doctor_id,P.full_name AS 'Patient Name',A.unit_id,A.polyclinic_id,A.appointment_date AS 'Date',A.preemptor AS 'Pre-Emptor',A.situation AS 'Situation' FROM Appointment A JOIN Patient P ON A.patient_id = P.id WHERE A.is_deleted = 0 AND A.situation = 0";
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public DataTable FindAppointment(string patientName)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            patientName = "%" + patientName + "%";
            cmd.CommandText = "SELECT A.id AS 'Appointment Number',A.doctor_id,P.full_name AS 'Patient Name',A.unit_id,A.polyclinic_id,A.appointment_date AS 'Date',A.preemptor AS 'Pre-Emptor',A.situation AS 'Situation' FROM Appointment A JOIN Patient P ON A.patient_id = P.id WHERE A.is_deleted = 0 AND A.situation = 0 AND P.full_name LIKE @name";
            cmd.Parameters.Add(new SqlParameter("@name", patientName));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public DataTable FindForDoctor(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            //cmd.CommandText = "SELECT D.full_name AS 'Doctor Name',P.full_name AS 'Patient Name',U.unit_name AS 'Unit Name',Pl.name AS 'Polyclinic Name',A.appointment_date,A.preemptor,A.situation  FROM Appointment A JOIN Doctor D ON A.doctor_id = D.id JOIN Patient P ON A.patient_id = P.id JOIN Unit U ON A.unit_id = u.id JOIN Polyclinic Pl ON U.polyclinic_id = Pl.id WHERE A.is_deleted = 0";
            cmd.CommandText = "SELECT A.id AS 'Appointment No',P.full_name AS 'Patient Name',A.appointment_date AS 'Date',A.situation AS 'Situation' FROM Appointment A JOIN Patient P ON A.patient_id = P.id WHERE A.is_deleted = 0 AND doctor_id=@id AND situation=0 AND A.appointment_date >(SELECT CONVERT(VARCHAR(10), getdate(), 23)) AND A.appointment_date < (SELECT DATEADD(day,1,CONVERT(VARCHAR(10), getdate(), 23)))";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public int AddAppointment(Appoinment appoinment)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "INSERT INTO Appointment VALUES(@doctor,@patient,@unit,@polyclinic,@date,@preemptor,0,0)";
            cmd.Parameters.Add(new SqlParameter("@doctor", appoinment.Doctor));
            cmd.Parameters.Add(new SqlParameter("@patient", appoinment.Patient));
            cmd.Parameters.Add(new SqlParameter("@unit", appoinment.Unit));
            cmd.Parameters.Add(new SqlParameter("@polyclinic", appoinment.Polyclinic));
            cmd.Parameters.Add(new SqlParameter("@date", appoinment.AppointmentDate));
            cmd.Parameters.Add(new SqlParameter("@preemptor", appoinment.Preemptor));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int DeleteAppointment(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Appointment SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdateAppointment(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Appointment SET doctor_id=@doctor, unit_id=@unit, polyclinic_id=@poly, appointment_date=@date, preemptor=@pre, situation=@situ WHERE id=@id ";
            string[] columns = new string[] { "@id", "@date", "@pre", "@situ", "@doctor", "@unit", "@poly" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 6)
                {
                    cmd.Parameters.Add(new SqlParameter(columns[index], item.Value));
                }
                index++;
            }
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdateSituation(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Appointment SET situation=@situ WHERE id=@id ";
            string[] columns = new string[] { "@id", "@situ" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index == 0)
                {
                    cmd.Parameters.Add(new SqlParameter(columns[index], item.Value));
                }
                if (index == 3)
                {
                    cmd.Parameters.Add(new SqlParameter(columns[index - 2], item.Value));
                }
                index++;
            }
            int data = cmd.ExecuteNonQuery();
            return data;
        }
    }
}
