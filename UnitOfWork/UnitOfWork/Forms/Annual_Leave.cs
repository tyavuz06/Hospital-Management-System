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
    public partial class Annual_Leave : Form
    {
        Enums.CommonOperationType type;
        public Annual_Leave(Enums.CommonOperationType otype)
        {
            InitializeComponent();
            type = otype;
        }

        private void Annual_Leave_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            switch (type)
            {
                case Enums.CommonOperationType.ODoctor:
                    pnlNurse.Visible = false;
                    pnlDoctor.Visible = true;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var docRepos = new DoctorRepository(uow);
                        cmbDoc.ValueMember = "ID";
                        cmbDoc.DisplayMember = "FullName";
                        cmbDoc.DataSource = docRepos.GetAllDoctorsL();
                        cmbDoc.Text = "Choose A Doctor...";
                    }
                    break;
                case Enums.CommonOperationType.ONurse:
                    pnlDoctor.Visible = false;
                    pnlNurse.Visible = true;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var nurseRepos = new NurseRepository(uow);
                        cmbNurse.ValueMember = "ID";
                        cmbNurse.DisplayMember = "FullName";
                        cmbNurse.DataSource = nurseRepos.GetAllNursesL();
                        cmbNurse.Text = "Choose A Nurse...";
                    }
                    break;
            }
        }

        private void btnNLeave_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    Models.AnnualLeave annualLeave = new Models.AnnualLeave()
                    {
                        WorkerID = (int)cmbNurse.SelectedValue,
                        WorkerType = (int)type,
                        Duration = Convert.ToInt32(txtLeaveDurationN.Text),
                        LeaveType = chkHasReport.Checked ? 2 : 1
                    };
                    var nRepos = new NurseRepository(uow);
                    data = nRepos.InsertAnnual(annualLeave);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
                if (data == 2 && _excep == false)
                {
                    MessageBox.Show("The operation is successfull");
                }
            }
        }

        private void btnDocLeave_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    Models.AnnualLeave annualLeave = new Models.AnnualLeave()
                    {
                        WorkerID = (int)cmbDoc.SelectedValue,
                        WorkerType = (int)type,
                        Duration = Convert.ToInt32(txtLeaveDuration.Text),
                        LeaveType = chkDHasReport.Checked ? 2 : 1,
                        DocID=(int)cmbExtraDoctor.SelectedValue
                    };
                    var dRepos = new DoctorRepository(uow);
                    data = dRepos.InsertAnnual(annualLeave);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
                if (data == 3 && _excep == false)
                {
                    MessageBox.Show("The operation is successfull");
                }
            }
        }

        private void cmbExtraDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var docRepos = new DoctorRepository(uow);
                cmbExtraDoctor.DisplayMember = "FullName";
                cmbExtraDoctor.ValueMember = "ID";
                cmbExtraDoctor.DataSource = docRepos.GetTempDoctor((int)cmbDoc.SelectedValue);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
