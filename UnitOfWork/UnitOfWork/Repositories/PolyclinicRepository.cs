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
    public class PolyclinicRepository
    {
        IUnitOfWork _unitOfWork;
        public PolyclinicRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new NotImplementedException("uow");
            if (uow is AdoNetUnitOfWork)
                _unitOfWork = uow as AdoNetUnitOfWork;
            if (_unitOfWork == null)
                throw new NotSupportedException("Sorry we cant support nowww");

        }
        public List<Polyclinic> GetAllPolyclinicsL()
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            command.CommandText = "SELECT id AS 'Polyclinic No',name AS 'Polyclinic Name',address AS 'Polyclinic Adress' FROM Polyclinic";

            IDataReader dataReader = command.ExecuteReader();

            List<Polyclinic> polyclinics = new List<Polyclinic>();

            while (dataReader.Read())
            {
                Polyclinic polyclinic = new Polyclinic()
                {
                    ID = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Address= dataReader.GetString(2)
                };
                polyclinics.Add(polyclinic);
            }
            dataReader.Close();
            return polyclinics;
        }

        public List<Polyclinic> FindPolyclinicL(string polyclinicName)
        {
            IDbCommand command = _unitOfWork.CreateCommand();
            polyclinicName = "%" + polyclinicName + "%";
            command.CommandText = "SELECT * FROM Polyclinic WHERE name LIKE @name";
            command.Parameters.Add(new SqlParameter("@name", polyclinicName));
            IDataReader dataReader = command.ExecuteReader();

            List<Polyclinic> polyclinics = new List<Polyclinic>();

            while (dataReader.Read())
            {
                Polyclinic polyclinic = new Polyclinic()
                {
                    ID = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                };
                polyclinics.Add(polyclinic);
            }
            dataReader.Close();
            return polyclinics;
        }

        public int AddPolyclinic(Polyclinic polyclinic)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "INSERT INTO Polyclinic(name,address) VALUES (@name,@address)";
            cmd.Parameters.Add(new SqlParameter("@name", polyclinic.Name));
            cmd.Parameters.Add(new SqlParameter("@address", polyclinic.Address));

            int data = cmd.ExecuteNonQuery();
            return data;
        }
        public DataTable GetAllPolyclinics()
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "SELECT * FROM Polyclinic WHERE is_deleted=0";
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public DataTable FindPolyclinic(string polyclinicName)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            polyclinicName = "%" + polyclinicName + "%";
            cmd.CommandText = "SELECT * FROM Polyclinic WHERE is_deleted=0 AND name LIKE @name";
            cmd.Parameters.Add(new SqlParameter("@name", polyclinicName));
            SqlDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public int DeletePolyclinic(int ID)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Polyclinic SET is_deleted=1 WHERE id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", ID));
            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public int UpdatePolyclinic(DataGridViewRow dgr)
        {
            IDbCommand cmd = _unitOfWork.CreateCommand();
            cmd.CommandText = "UPDATE Polyclinic SET name=@name,address=@address WHERE id=@id";
            string[] columns = new string[] { "@id", "@name", "@address"};
            int index = 0;
            foreach (DataGridViewCell item in dgr.Cells)
            {
                if (index <= 2)
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
