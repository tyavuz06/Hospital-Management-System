using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitOfWork
{
    public partial class AddUser : Form
    {
        string operationType;
        Enums.CommonOperationType operationName;
        public AddUser(Enums.CommonOperationType oName)
        {
            InitializeComponent();
            operationName = oName;
            operationType = Enum.GetName(typeof(Enums.CommonOperationType), operationName);
        }
        private void AddUser_Load(object sender, EventArgs e)
        {

            switch (operationName)
            {
                case Enums.CommonOperationType.OUser:
                    this.Height = pnlUser.Height + 300;
                    pnlUser.Visible = true;
                    pnlNurse.Visible = false;
                    pnlAddPatient.Visible = false;
                    pnlPolyclinic.Visible = false;
                    pnlAddDoc.Visible = false;
                    pnlAppointment.Visible = false;
                    pnlUnit.Visible = false;
                    pnlUser.Left = (this.Width - pnlUser.Width) / 2;
                    pnlUser.Top = (this.Height - pnlUser.Height) / 2 - 10;
                    break;
                case Enums.CommonOperationType.ONurse:
                    this.Height = pnlNurse.Height + 100;
                    pnlAppointment.Visible = false;
                    pnlUser.Visible = false;
                    pnlNurse.Visible = true;
                    pnlAddPatient.Visible = false;
                    pnlPolyclinic.Visible = false;
                    pnlAddDoc.Visible = false;
                    pnlUnit.Visible = false;
                    pnlNurse.Left = (this.Width - pnlNurse.Width) / 2;
                    pnlNurse.Top = (this.Height - pnlNurse.Height) / 2-10;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        string[] workTypes = Enum.GetNames(typeof(Enums.NurseWorkType));
                        cmbWorkType.DataSource = workTypes;
                        PolyclinicRepository pRepos = new PolyclinicRepository(uow);
                        UnitRepository uRepos = new UnitRepository(uow);
                        cmbPolyclinic.DisplayMember = "Name";
                        cmbPolyclinic.ValueMember = "ID";
                        cmbPolyclinic.DataSource = pRepos.GetAllPolyclinicsL();
                        cmbPolyclinic.Text = "Choose A Polyclinic.";

                    }
                    break;
                case Enums.CommonOperationType.OPatient:
                    this.Height = pnlAddPatient.Height + 100;
                    pnlAppointment.Visible = false;
                    pnlUser.Visible = false;
                    pnlNurse.Visible = false;
                    pnlAddPatient.Visible = true;
                    pnlPolyclinic.Visible = false;
                    pnlAddDoc.Visible = false;
                    pnlUnit.Visible = false;
                    pnlAddPatient.Left = (this.Width - pnlAddPatient.Width) / 2;
                    pnlAddPatient.Top = (this.Height - pnlAddPatient.Height) / 2 - 10;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        cmbBloodType.DataSource = Enum.GetNames(typeof(Enums.BloodType));
                        cmbSocialSecurity.DataSource = Enum.GetNames(typeof(Enums.SocialSecurity));
                    }
                    break;
                case Enums.CommonOperationType.OUnit:
                    this.Height = pnlUser.Height + 300;
                    pnlAppointment.Visible = false;
                    pnlUser.Visible = false;
                    pnlNurse.Visible = false;
                    pnlAddPatient.Visible = false;
                    pnlPolyclinic.Visible = false;
                    pnlAddDoc.Visible = false;
                    pnlUnit.Visible = true;
                    pnlUnit.Left = (this.Width - pnlUnit.Width) / 2;
                    pnlUnit.Top = (this.Height - pnlUnit.Height) / 2 - 10;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var pRepos = new PolyclinicRepository(uow);
                        cmbPoly.DisplayMember = "Name";
                        cmbPoly.ValueMember = "ID";
                        cmbPoly.DataSource = pRepos.GetAllPolyclinicsL();
                    }
                    break;
                case Enums.CommonOperationType.OAppoinment:
                    this.Height = pnlAppointment.Height + 100;
                    pnlAppointment.Visible = true;
                    pnlUser.Visible = false;
                    pnlNurse.Visible = false;
                    pnlAddPatient.Visible = false;
                    pnlPolyclinic.Visible = false;
                    pnlAddDoc.Visible = false;
                    pnlUnit.Visible = false;
                    pnlAppointment.Left = (this.Width - pnlAppointment.Width) / 2;
                    pnlAppointment.Top = (this.Height - pnlAppointment.Height) / 2 - 10;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var docRepos = new DoctorRepository(uow);
                        var pRepos = new PatientRepository(uow);
                        var polyRepos = new PolyclinicRepository(uow);
                        var uRepos = new UnitRepository(uow);
                        cmbAppDoc.ValueMember = "ID";
                        cmbAppDoc.DisplayMember = "FullName";
                        cmbAppDoc.DataSource = docRepos.GetAllDoctorsForAppointment();
                        cmbAppDoc.Text = "Choose A Doctor..";
                        cmbAppPoly.ValueMember = "ID";
                        cmbAppPoly.DisplayMember = "Name";
                        cmbAppPoly.DataSource = polyRepos.GetAllPolyclinicsL();
                        cmbAppPoly.Text = "Choose a Polyclinic...";
                        cmbAppPatient.ValueMember = "ID";
                        cmbAppPatient.DisplayMember = "FullName";
                        cmbAppPatient.DataSource = pRepos.GetAllPatientsL();
                        cmbAppPatient.Text = "Choose a Patient..";

                    }
                    break;
                case Enums.CommonOperationType.ODoctor:
                    this.Height = pnlAddDoc.Height + 100;
                    pnlAppointment.Visible = false;
                    pnlUser.Visible = false;
                    pnlNurse.Visible = false;
                    pnlAddPatient.Visible = false;
                    pnlPolyclinic.Visible = false;
                    pnlAddDoc.Visible = true;
                    pnlUnit.Visible = false;
                    pnlAddDoc.Left = (this.Width - pnlAddDoc.Width) / 2;
                    pnlAddDoc.Top = (this.Height - pnlAddDoc.Height) / 2 - 10;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        PolyclinicRepository pRepos = new PolyclinicRepository(uow);
                        UnitRepository uRepos = new UnitRepository(uow);
                        cmbDocPoly.DisplayMember = "Name";
                        cmbDocPoly.ValueMember = "ID";
                        cmbDocPoly.DataSource = pRepos.GetAllPolyclinicsL();
                        cmbDocPoly.Text = "Choose A Polyclinic.";
                    }
                    break;
                case Enums.CommonOperationType.OPolyclinic:
                    this.Height = pnlPolyclinic.Height + 100;
                    pnlAppointment.Visible = false;
                    pnlUser.Visible = false;
                    pnlNurse.Visible = false;
                    pnlAddPatient.Visible = false;
                    pnlPolyclinic.Visible = true;
                    pnlAddDoc.Visible = false;
                    pnlUnit.Visible = false;
                    pnlPolyclinic.Left = (this.Width - pnlPolyclinic.Width) / 2;
                    pnlPolyclinic.Top = (this.Height - pnlPolyclinic.Height) / 2 - 10;
                    break;
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    var uRepos = new UserRepository(uow);
                    User user = new User()
                    {
                        userName = txtUserName.Text,
                        Name = txtName.Text
                    };
                    uRepos.CreateUser(user);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
            }
            if (_excep == false && data == 1)
                MessageBox.Show("The operation is successfull...");
        }

        private void btnAddNurse_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                NurseRepository nurseRepository = new NurseRepository(uow);
                try
                {
                    Nurse nurse = new Nurse()
                    {
                        IdentityNo = txtIdentityId.Text,
                        FullName = txtFullName.Text,
                        BirthDate = dateTimePicker1.Value,
                        Email = txtEmail.Text,
                        Adress = txtAdress.Text,
                        IsCheafNurse = chkChiefNurse.Checked,
                        Phone = txtPhone.Text,
                        Polyclinic = (int)cmbPolyclinic.SelectedValue,
                        Salary = Convert.ToDecimal(txtSalary.Text),
                        Unit = (int)cmbUnit.SelectedValue,
                        WorkType = (Enums.NurseWorkType)Enum.Parse(typeof(Enums.NurseWorkType), cmbWorkType.SelectedItem.ToString())
                    };
                    data = nurseRepository.AddNurse(nurse);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
            }
            if (_excep == false && data == 1)
                MessageBox.Show("The operation is successfull...");

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            bool _excep = false;
            int data = 0;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    var pRepos = new PatientRepository(uow);
                    Patient patient = new Patient()
                    {
                        IdentityNo = txtIdentityNo.Text,
                        FullName = txtFullNameP.Text,
                        BirthDate = dateTimePicker2.Value,
                        Phone = txtPhoneP.Text,
                        Adress = txtAdressP.Text,
                        BloodType = (Enums.BloodType)Enum.Parse(typeof(Enums.BloodType), (string)cmbBloodType.SelectedValue),
                        SocialSecurity = (Enums.SocialSecurity)Enum.Parse(typeof(Enums.SocialSecurity), (string)cmbSocialSecurity.SelectedValue)
                    };
                    data = pRepos.AddPatient(patient);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
            }
            if (_excep == false && data == 1)
                MessageBox.Show("The operation is successfull...");
        }

        private void btnPolySave_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                PolyclinicRepository pRepos = new PolyclinicRepository(uow);
                try
                {
                    Polyclinic polyclinic = new Polyclinic()
                    {
                        Name = txtPolyclinicName.Text,
                        Address = txtPolyclinicAddress.Text
                    };
                    data = pRepos.AddPolyclinic(polyclinic);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
                if (_excep == false && data == 1)
                    MessageBox.Show("The operation is successfull...");
            }
        }

        private void btnDocAdd_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var docRepos = new DoctorRepository(uow);
                Doctor doctor = new Doctor()
                {
                    IdentityNo = txtDocIdentityNO.Text,
                    FullName = txtDocFullName.Text,
                    Phone = txtDocPhone.Text,
                    Email = txtDocEmail.Text,
                    Adress = txtDocAddress.Text,
                    Salary = Convert.ToDecimal(txtDocSalary.Text),
                    BirthDate = dateTimePicker2.Value,
                    Unit = (int)cmbDocUnit.SelectedValue,
                    Polyclinic = (int)cmbDocPoly.SelectedValue,
                    isAdult = chkDocAdult.Checked,
                    doOperation = chkDocAdult.Checked
                };
                try
                {
                    data = docRepos.AddDoctor(doctor);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
            }
            if (_excep == false && data == 1)
                MessageBox.Show("The operation is successfull...");
        }

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            bool _excep = false;
            int data = 0;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var appRepos = new Repositories.AppoinmentRepository(uow);
                Models.Appoinment appoinment = new Models.Appoinment()
                {
                    Doctor = (int)cmbAppDoc.SelectedValue,
                    Patient = (int)cmbAppPatient.SelectedValue,
                    Unit = (int)cmbAppUnit.SelectedValue,
                    Polyclinic = (int)cmbAppPoly.SelectedValue,
                    AppointmentDate = dateTimePicker3.Value,
                    Preemptor = chkPre.Checked
                };
                try
                {
                    data = appRepos.AddAppointment(appoinment);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }
            }
            if (_excep == false && data == 1)
                MessageBox.Show("The operation is successfull..");

        }

        private void btnUnitAdd_Click(object sender, EventArgs e)
        {
            int data = 0;
            bool _excep = false;
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    Unit unit = new Unit()
                    {
                        Polyclinic = (int)cmbPoly.SelectedValue,
                        UnitName = txtUnitName.Text
                    };
                    var uRepos = new UnitRepository(uow);
                    data = uRepos.AddUnit(unit);
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _excep = true;
                }

            }
            if (data == 1 && _excep == false)
                MessageBox.Show("The operation is successfull...");
        }

        private void cmbPolyclinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var uRepos = new UnitRepository(uow);
                cmbUnit.ValueMember = "ID";
                cmbUnit.DisplayMember = "UnitName";
                cmbUnit.DataSource = uRepos.GetAllUnitsByPolyclinic((int)cmbPolyclinic.SelectedValue);
                cmbUnit.Text = "Choose a Unit.";
            }
        }

        private void cmbAppPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var uRepos = new UnitRepository(uow);
                cmbAppUnit.ValueMember = "ID";
                cmbAppUnit.DisplayMember = "UnitName";
                cmbAppUnit.DataSource = uRepos.GetAllUnitsByPolyclinic((int)cmbAppPoly.SelectedValue);
                cmbAppUnit.Text = "Choose a Unit.";
            }
        }

        private void cmbDocPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var uRepos = new UnitRepository(uow);
                cmbDocUnit.ValueMember = "ID";
                cmbDocUnit.DisplayMember = "UnitName";
                cmbDocUnit.DataSource = uRepos.GetAllUnitsByPolyclinic((int)cmbDocPoly.SelectedValue);
                cmbDocUnit.Text = "Choose a Unit.";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
