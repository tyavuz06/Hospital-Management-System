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
    public class UnitRepository
    {
        IUnitOfWork _unitOfWork;
        public UnitRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("null");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = uow as AdoNetUnitOfWork;
            if (_unitOfWork == null)
                throw new NotImplementedException("Sorry we cant support at the moment...");
        }

        public List<Unit> GetAllUnitsL()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT id AS 'Unit NO', polyclinic_id,unit_name AS 'Unit Name',unit_maxDoc AS 'Number of Doctor',unit_maxNurse AS 'Number of Nurse' FROM Unit";
            IDataReader dataReader = command.ExecuteReader();

            List<Unit> units = new List<Unit>();

            while (dataReader.Read())
            {
                Unit unit = new Unit()
                {
                    ID = dataReader.GetInt32(0),
                    Polyclinic = dataReader.GetInt32(1),
                    UnitName = dataReader.GetString(2),
                    UnitMaxDoctor = dataReader.GetByte(3),
                    UnitMaxNurse = dataReader.GetByte(4)
                };
                units.Add(unit);
            }
            dataReader.Close();
            return units;
        }
        public List<Unit> GetAllUnitsByPolyclinic(int id)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT id AS 'Unit NO', unit_name AS 'Unit Name' FROM Unit WHERE polyclinic_id=@id";
            command.Parameters.Add(new SqlParameter("@id", id));
            IDataReader dataReader = command.ExecuteReader();

            List<Unit> units = new List<Unit>();

            while (dataReader.Read())
            {
                Unit unit = new Unit()
                {
                    ID = dataReader.GetInt32(0),
                    UnitName = dataReader.GetString(1)
                };
                units.Add(unit);
            }
            dataReader.Close();
            return units;
        }
        public List<Unit> FindUnitL(string unitName)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            unitName = "%" + unitName + "%";
            command.CommandText = "SELECT * FROM Unit WHERE unit_name LIKE @name";
            command.Parameters.Add(new SqlParameter("@name", unitName));
            IDataReader dataReader = command.ExecuteReader();

            List<Unit> units = new List<Unit>();

            while (dataReader.Read())
            {
                Unit unit = new Unit()
                {
                    ID = dataReader.GetInt32(0),
                    Polyclinic = dataReader.GetInt32(1),
                    UnitName = dataReader.GetString(2),
                    UnitMaxDoctor = dataReader.GetByte(3),
                    UnitMaxNurse = dataReader.GetByte(4)
                };
                units.Add(unit);
            }
            dataReader.Close();
            return units;
        }
        public int AddUnit(Unit unit)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "INSERT INTO Unit(polyclinic_id,unit_name) VALUES(@poly,@name)";
            cmd.Parameters.Add(new SqlParameter("@poly", unit.Polyclinic));
            cmd.Parameters.Add(new SqlParameter("@name", unit.UnitName));
            int data = cmd.ExecuteNonQuery();
            return data;
        }
        public DataTable GetAllUnits()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT id AS 'Unit NO', polyclinic_id,unit_name AS 'Unit Name',unit_maxDoc AS 'Number of Doctor',unit_maxNurse AS 'Number of Nurse' FROM Unit WHERE is_deleted=0";
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public DataTable FindUnit(string unitName)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            unitName = "%" + unitName + "%";
            cmd.CommandText = "SELECT id AS 'Unit NO', polyclinic_id,unit_name AS 'Unit Name',unit_maxDoc AS 'Number of Doctor',unit_maxNurse AS 'Number of Nurse' FROM Unit WHERE unit_name LIKE @name";
            cmd.Parameters.Add(new SqlParameter("@name", unitName));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public int DeleteUnit(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Unit SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdateUnit(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Unit SET polyclinic_id=@pid,unit_name=@uname,unit_maxDoc=@maxD,unit_maxNurse=@maxN WHERE id=@id";
            string[] columns = new string[] { "@id", "@uname", "@maxD", "@maxN", "@pid" };
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 4)
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
