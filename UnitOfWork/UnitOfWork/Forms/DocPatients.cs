using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitOfWork.Forms
{
    public partial class DocPatients : Form
    {
        int docID;
        public DocPatients(int userType)
        {
            InitializeComponent();
            docID = userType;
        }

        private void DocPatients_Load(object sender, EventArgs e)
        {
            FiilToGridView();

        }

        private void FiilToGridView()
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var aRepos = new Repositories.AppoinmentRepository(uow);
                dataGridView1.DataSource = aRepos.FindForDoctor(docID);

                DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(bCol);
                bCol.HeaderText = "Confirm";
                bCol.Text = "Confirm";
                bCol.UseColumnTextForButtonValue = true;
            }
            if (dataGridView1.Rows.Count == 0)
                dataGridView1.Visible = false;
            else
                dataGridView1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                bool _excep = false;
                int data = 0;
                using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                {
                    try
                    {
                        var aRepos = new Repositories.AppoinmentRepository(uow);
                        data = aRepos.UpdateSituation(dataGridView1.Rows[e.RowIndex]);
                        uow.SaveChanges();
                        dataGridView1.Columns.RemoveAt(4);
                        FiilToGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        _excep = true;
                    }
                }
                if (_excep == false && data == 1)
                    MessageBox.Show("Operation is successfull");
            }
        }
    }
}
