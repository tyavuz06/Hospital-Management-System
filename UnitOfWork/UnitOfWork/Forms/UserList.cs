using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitOfWorkDLL2;

namespace UnitOfWork
{
    public partial class UserList : Form
    {
        bool isLoad = true;
        public UserList()
        {
            InitializeComponent();
        }
        Enums.CommonOperationType type;
        public UserList(Enums.CommonOperationType operationType)
        {
            InitializeComponent();
            type = operationType;
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 11);
        }
        void FillDataGridView()
        {
            dataGridView1.DataSource = null;
            switch (type)
            {
                case Enums.CommonOperationType.OUnit:

                    label1.Text = "Unit Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var uRepos = new UnitRepository(uow);
                        dataGridView1.DataSource = uRepos.GetAllUnits();

                        var pRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.HeaderText = "Polyclinic Name";
                        column.Name = "PolyclinicName";
                        column.DisplayMember = "Name";
                        column.ValueMember = "ID";
                        column.DataSource = pRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(column);
                        dataGridView1.Columns["PolyclinicName"].DisplayIndex = 1;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["PolyclinicName"].Value = row.Cells[1].Value;
                        }
                        dataGridView1.Columns.RemoveAt(1);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Unit";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Unit";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OPatient:
                    this.WindowState = FormWindowState.Maximized;
                    label1.Text = "Patient Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var pRepos = new PatientRepository(uow);
                        dataGridView1.DataSource = pRepos.GetAllPatientsL();

                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.HeaderText = "BloodTypes";
                        column.Name = "BloodTypes";
                        column.DataSource = Enum.GetNames(typeof(Enums.BloodType));
                        dataGridView1.Columns.Add(column);
                        dataGridView1.Columns["BloodTypes"].DisplayIndex = 6;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["BloodTypes"].Value = Enum.GetName(typeof(Enums.BloodType), row.Cells[6].Value);
                        }
                        dataGridView1.Columns.RemoveAt(6);

                        DataGridViewComboBoxColumn scolumn = new DataGridViewComboBoxColumn();
                        scolumn.HeaderText = "SocialSecurities";
                        scolumn.Name = "SocialSecurities";
                        scolumn.DataSource = Enum.GetNames(typeof(Enums.SocialSecurity));
                        dataGridView1.Columns.Add(scolumn);
                        dataGridView1.Columns["SocialSecurities"].DisplayIndex = 7;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["SocialSecurities"].Value = Enum.GetName(typeof(Enums.SocialSecurity), row.Cells[6].Value);
                        }
                        dataGridView1.Columns.RemoveAt(6);

                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Patient";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Patient";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.ODoctor:
                    this.WindowState = FormWindowState.Maximized;
                    label1.Text = "Doctor Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var dRepos = new DoctorRepository(uow);
                        dataGridView1.DataSource = dRepos.GetAllDoctors();

                        var polRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn polcolumn = new DataGridViewComboBoxColumn();
                        polcolumn.DisplayMember = "Name";
                        polcolumn.ValueMember = "ID";
                        polcolumn.HeaderText = "Polyclinic";
                        polcolumn.Name = "Polyclinic";
                        polcolumn.DataSource = polRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(polcolumn);
                        var uRepos = new UnitRepository(uow);
                        DataGridViewComboBoxColumn ucolumn = new DataGridViewComboBoxColumn();
                        ucolumn.HeaderText = "Units";
                        dataGridView1.Columns.Add(ucolumn);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Polyclinic"].Value = row.Cells[10].Value;
                            DataGridViewCell cell;
                            DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                            cmb.DisplayMember = "UnitName";
                            cmb.ValueMember = "ID";
                            cmb.DataSource = uRepos.GetAllUnitsByPolyclinic((int)row.Cells[10].Value);
                            cmb.Value = row.Cells[11].Value;
                            cell = cmb;
                            row.Cells[13] = cell;
                        }
                        dataGridView1.Columns.RemoveAt(10);
                        dataGridView1.Columns.RemoveAt(10);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Unit";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Unit";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.ONurse:
                    this.WindowState = FormWindowState.Maximized;
                    label1.Text = "Nurse Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var dRepos = new NurseRepository(uow);
                        dataGridView1.DataSource = dRepos.GetAllNursesL();
                        dataGridView1.Columns.RemoveAt(7);
                        dataGridView1.Columns.RemoveAt(7);
                        DataGridViewComboBoxColumn wcolumn = new DataGridViewComboBoxColumn();
                        wcolumn.HeaderText = "WorkTypes";
                        wcolumn.Name = "WorkTypes";
                        wcolumn.DataSource = Enum.GetNames(typeof(Enums.NurseWorkType));
                        dataGridView1.Columns.Add(wcolumn);
                        //dataGridView1.Columns["WorkTypes"].DisplayIndex = 8;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["WorkTypes"].Value = Enum.GetName(typeof(Enums.NurseWorkType), row.Cells[8].Value);
                        }
                        dataGridView1.Columns.RemoveAt(8);



                        var polRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn polcolumn = new DataGridViewComboBoxColumn();
                        polcolumn.DisplayMember = "Name";
                        polcolumn.ValueMember = "ID";
                        polcolumn.HeaderText = "Polyclinics";
                        polcolumn.Name = "Polyclinics";
                        polcolumn.DataSource = polRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(polcolumn);

                        var uRepos = new UnitRepository(uow);
                        DataGridViewComboBoxColumn ucolumn = new DataGridViewComboBoxColumn();
                        ucolumn.HeaderText = "Units";
                        ucolumn.Name = "Units";
                        dataGridView1.Columns.Add(ucolumn);

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Polyclinics"].Value = row.Cells["Polyclinic"].Value;
                            DataGridViewCell cell;
                            DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                            cmb.DisplayMember = "UnitName";
                            cmb.ValueMember = "ID";
                            cmb.DataSource = uRepos.GetAllUnitsByPolyclinic((int)row.Cells["Polyclinic"].Value);
                            cmb.Value = row.Cells["Unit"].Value;
                            cell = cmb;
                            row.Cells["Units"] = cell;
                        }
                        dataGridView1.Columns.RemoveAt(9);
                        dataGridView1.Columns.RemoveAt(9);


                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Unit";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Unit";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OUser:
                    label1.Text = "User Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var uRepos = new UserRepository(uow);
                        dataGridView1.DataSource = uRepos.GetAllUsers();
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete User";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update User";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OAppoinment:
                    this.WindowState = FormWindowState.Maximized;
                    label1.Text = "Appointment Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var aRepos = new Repositories.AppoinmentRepository(uow);
                        dataGridView1.DataSource = aRepos.GetAllAppoinments();

                        var docRepos = new DoctorRepository(uow);
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.DisplayMember = "FullName";
                        column.ValueMember = "ID";
                        column.HeaderText = "Doctor";
                        column.Name = "Doctor";
                        column.DataSource = docRepos.GetAllDoctorsL();
                        dataGridView1.Columns.Add(column);
                        dataGridView1.Columns["Doctor"].DisplayIndex = 1;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Doctor"].Value = row.Cells[1].Value;
                        }
                        dataGridView1.Columns.RemoveAt(1);

                        var uRepos = new UnitRepository(uow);
                        DataGridViewComboBoxColumn ucolumn = new DataGridViewComboBoxColumn();
                        ucolumn.DisplayMember = "UnitName";
                        ucolumn.ValueMember = "ID";
                        ucolumn.HeaderText = "Unit";
                        ucolumn.Name = "Unit";
                        ucolumn.DataSource = uRepos.GetAllUnitsL();
                        dataGridView1.Columns.Add(ucolumn);
                        dataGridView1.Columns["Unit"].DisplayIndex = 2;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Unit"].Value = row.Cells[2].Value;
                        }
                        dataGridView1.Columns.RemoveAt(2);

                        var polRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn polcolumn = new DataGridViewComboBoxColumn();
                        polcolumn.DisplayMember = "Name";
                        polcolumn.ValueMember = "ID";
                        polcolumn.HeaderText = "Polyclinic";
                        polcolumn.Name = "Polyclinic";
                        polcolumn.DataSource = polRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(polcolumn);
                        dataGridView1.Columns["Polyclinic"].DisplayIndex = 3;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Polyclinic"].Value = row.Cells[2].Value;
                        }
                        dataGridView1.Columns.RemoveAt(2);

                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Appointment";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Appointment";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OPolyclinic:
                    label1.Text = "Polyclinic Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        var pRepos = new PolyclinicRepository(uow);
                        dataGridView1.DataSource = pRepos.GetAllPolyclinics();
                        dataGridView1.Columns.RemoveAt(3);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Polyclinic";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Polyclinic";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
            }
            isLoad = false;
        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            switch (type)
            {
                case Enums.CommonOperationType.ONurse:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(9);
                        dataGridView1.Columns.RemoveAt(9);
                        dataGridView1.Columns.RemoveAt(9);
                        dataGridView1.Columns.RemoveAt(9);
                        dataGridView1.Columns.RemoveAt(9);
                        var nRepos = new NurseRepository(uow);
                        dataGridView1.DataSource = nRepos.FindNurse(txtSearch.Text);
                        DataGridViewComboBoxColumn wcolumn = new DataGridViewComboBoxColumn();
                        wcolumn.HeaderText = "WorkTypes";
                        wcolumn.Name = "WorkTypes";
                        wcolumn.DataSource = Enum.GetNames(typeof(Enums.NurseWorkType));
                        dataGridView1.Columns.Add(wcolumn);
                        dataGridView1.Columns["WorkTypes"].DisplayIndex = 8;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["WorkTypes"].Value = Enum.GetName(typeof(Enums.NurseWorkType), row.Cells[8].Value);
                        }
                        dataGridView1.Columns.RemoveAt(8);

                        var polRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn polcolumn = new DataGridViewComboBoxColumn();
                        polcolumn.DisplayMember = "Name";
                        polcolumn.ValueMember = "ID";
                        polcolumn.HeaderText = "Polyclinics";
                        polcolumn.Name = "Polyclinics";
                        polcolumn.DataSource = polRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(polcolumn);
                        dataGridView1.Columns["Polyclinics"].DisplayIndex = 9;
                        var uRepos = new UnitRepository(uow);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Polyclinics"].Value = row.Cells[9].Value;
                            DataGridViewCell cell;
                            DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                            cmb.DisplayMember = "UnitName";
                            cmb.ValueMember = "ID";
                            cmb.DataSource = uRepos.GetAllUnitsByPolyclinic((int)row.Cells[9].Value);
                            cell = cmb;
                            row.Cells[10] = cell;
                        }
                        dataGridView1.Columns["Unit"].DisplayIndex = 10;
                        dataGridView1.Columns.RemoveAt(9);

                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Unit";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Unit";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OUser:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        var uRepos = new UserRepository(uow);
                        dataGridView1.DataSource = uRepos.FindUserName(txtSearch.Text);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete User";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update User";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OAppoinment:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        var appRepos = new Repositories.AppoinmentRepository(uow);
                        dataGridView1.DataSource = appRepos.FindAppointment(txtSearch.Text);
                        var docRepos = new DoctorRepository(uow);
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.DisplayMember = "FullName";
                        column.ValueMember = "ID";
                        column.HeaderText = "Doctor";
                        column.Name = "Doctor";
                        column.DataSource = docRepos.GetAllDoctorsL();
                        dataGridView1.Columns.Add(column);
                        dataGridView1.Columns["Doctor"].DisplayIndex = 1;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Doctor"].Value = row.Cells[1].Value;
                        }
                        dataGridView1.Columns.RemoveAt(1);

                        var uRepos = new UnitRepository(uow);
                        DataGridViewComboBoxColumn ucolumn = new DataGridViewComboBoxColumn();
                        ucolumn.DisplayMember = "UnitName";
                        ucolumn.ValueMember = "ID";
                        ucolumn.HeaderText = "Unit";
                        ucolumn.Name = "Unit";
                        ucolumn.DataSource = uRepos.GetAllUnitsL();
                        dataGridView1.Columns.Add(ucolumn);
                        dataGridView1.Columns["Unit"].DisplayIndex = 2;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Unit"].Value = row.Cells[2].Value;
                        }
                        dataGridView1.Columns.RemoveAt(2);

                        var polRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn polcolumn = new DataGridViewComboBoxColumn();
                        polcolumn.DisplayMember = "Name";
                        polcolumn.ValueMember = "ID";
                        polcolumn.HeaderText = "Polyclinic";
                        polcolumn.Name = "Polyclinic";
                        polcolumn.DataSource = polRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(polcolumn);
                        dataGridView1.Columns["Polyclinic"].DisplayIndex = 3;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Polyclinic"].Value = row.Cells[2].Value;
                        }
                        dataGridView1.Columns.RemoveAt(2);

                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Appointment";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Appointment";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;

                    }
                    break;
                case Enums.CommonOperationType.ODoctor:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(10);
                        dataGridView1.Columns.RemoveAt(10);
                        dataGridView1.Columns.RemoveAt(10);
                        dataGridView1.Columns.RemoveAt(10);
                        var dRepos = new DoctorRepository(uow);
                        dataGridView1.DataSource = dRepos.FindDoctor(txtSearch.Text);

                        var polRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn polcolumn = new DataGridViewComboBoxColumn();
                        polcolumn.DisplayMember = "Name";
                        polcolumn.ValueMember = "ID";
                        polcolumn.HeaderText = "Polyclinic";
                        polcolumn.Name = "Polyclinic";
                        polcolumn.DataSource = polRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(polcolumn);
                        dataGridView1.Columns["Polyclinic"].DisplayIndex = 11;
                        var uRepos = new UnitRepository(uow);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["Polyclinic"].Value = row.Cells[11].Value;
                            DataGridViewCell cell;
                            DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                            cmb.DisplayMember = "UnitName";
                            cmb.ValueMember = "ID";
                            cmb.DataSource = uRepos.GetAllUnitsByPolyclinic((int)row.Cells[11].Value);
                            cell = cmb;
                            row.Cells[10] = cell;
                        }
                        dataGridView1.Columns.RemoveAt(11);

                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Unit";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Unit";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OPatient:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(6);
                        dataGridView1.Columns.RemoveAt(6);
                        dataGridView1.Columns.RemoveAt(6);
                        dataGridView1.Columns.RemoveAt(6);
                        var uRepos = new PatientRepository(uow);
                        dataGridView1.DataSource = uRepos.FindPatient(txtSearch.Text);
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.HeaderText = "BloodTypes";
                        column.Name = "BloodTypes";
                        column.DataSource = Enum.GetNames(typeof(Enums.BloodType));
                        dataGridView1.Columns.Add(column);
                        dataGridView1.Columns["BloodTypes"].DisplayIndex = 6;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["BloodTypes"].Value = Enum.GetName(typeof(Enums.BloodType), row.Cells[6].Value);
                        }
                        dataGridView1.Columns.RemoveAt(6);

                        DataGridViewComboBoxColumn scolumn = new DataGridViewComboBoxColumn();
                        scolumn.HeaderText = "SocialSecurities";
                        scolumn.Name = "SocialSecurities";
                        scolumn.DataSource = Enum.GetNames(typeof(Enums.SocialSecurity));
                        dataGridView1.Columns.Add(scolumn);
                        dataGridView1.Columns["SocialSecurities"].DisplayIndex = 7;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["SocialSecurities"].Value = Enum.GetName(typeof(Enums.SocialSecurity), row.Cells[6].Value);
                        }
                        dataGridView1.Columns.RemoveAt(6);

                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Patient";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Patient";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OUnit:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        dataGridView1.Columns.RemoveAt(4);
                        var uRepos = new UnitRepository(uow);
                        dataGridView1.DataSource = uRepos.FindUnit(txtSearch.Text);
                        var pRepos = new PolyclinicRepository(uow);
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.HeaderText = "Polyclinic Name";
                        column.Name = "PolyclinicName";
                        column.DisplayMember = "Name";
                        column.ValueMember = "ID";
                        column.DataSource = pRepos.GetAllPolyclinicsL();
                        dataGridView1.Columns.Add(column);
                        dataGridView1.Columns["PolyclinicName"].DisplayIndex = 1;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells["PolyclinicName"].Value = row.Cells[1].Value;
                        }
                        dataGridView1.Columns.RemoveAt(1);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Unit";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Unit";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
                case Enums.CommonOperationType.OPolyclinic:
                    using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                    {
                        dataGridView1.Columns.RemoveAt(3);
                        dataGridView1.Columns.RemoveAt(3);
                        var uRepos = new PolyclinicRepository(uow);
                        dataGridView1.DataSource = uRepos.FindPolyclinic(txtSearch.Text);
                        dataGridView1.Columns.RemoveAt(3);
                        DataGridViewButtonColumn bCol = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol);
                        bCol.HeaderText = "Delete Polyclinic";
                        bCol.Text = "Delete";
                        bCol.UseColumnTextForButtonValue = true;
                        DataGridViewButtonColumn bCol2 = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(bCol2);
                        bCol2.HeaderText = "Update Polyclinic";
                        bCol2.Text = "Update";
                        bCol2.UseColumnTextForButtonValue = true;
                    }
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool _excep = false;
            int data = 0;
            switch (type)
            {
                case Enums.CommonOperationType.OUnit:
                    if (e.ColumnIndex == 5)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new UnitRepository(uow);
                            try
                            {
                                data = uRepos.DeleteUnit((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(5);
                            dataGridView1.Columns.RemoveAt(5);
                            FillDataGridView();
                        }
                    }

                    if (e.ColumnIndex == 6)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new UnitRepository(uow);
                            try
                            {
                                data = uRepos.UpdateUnit(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(5);
                            dataGridView1.Columns.RemoveAt(5);
                            FillDataGridView();
                        }
                    }
                    break;
                case Enums.CommonOperationType.OPatient:
                    label1.Text = "Patient Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    if (e.ColumnIndex == 8)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new PatientRepository(uow);
                            try
                            {
                                data = uRepos.DeletePatient((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(6);
                            dataGridView1.Columns.RemoveAt(6);
                            dataGridView1.Columns.RemoveAt(6);
                            dataGridView1.Columns.RemoveAt(6);
                            FillDataGridView();
                        }
                    }
                    if (e.ColumnIndex == 9)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new PatientRepository(uow);
                            try
                            {
                                data = uRepos.UpdatePatient(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(6);
                            dataGridView1.Columns.RemoveAt(6);
                            dataGridView1.Columns.RemoveAt(6);
                            dataGridView1.Columns.RemoveAt(6);
                            FillDataGridView();
                        }
                    }
                    break;
                case Enums.CommonOperationType.ODoctor:
                    label1.Text = "Doctor Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    if (e.ColumnIndex == 12)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new DoctorRepository(uow);
                            try
                            {
                                data = uRepos.DeleteDoctor((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(10);
                            dataGridView1.Columns.RemoveAt(10);
                            dataGridView1.Columns.RemoveAt(10);
                            dataGridView1.Columns.RemoveAt(10);
                            FillDataGridView();
                        }
                    }

                    if (e.ColumnIndex == 13)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new DoctorRepository(uow);
                            try
                            {
                                data = uRepos.UpdateDoctor(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(10);
                            dataGridView1.Columns.RemoveAt(10);
                            dataGridView1.Columns.RemoveAt(10);
                            dataGridView1.Columns.RemoveAt(10);
                            FillDataGridView();
                        }
                    }
                    break;
                case Enums.CommonOperationType.ONurse:
                    label1.Text = "Nurse Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    if (e.ColumnIndex == 12)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new NurseRepository(uow);
                            try
                            {
                                data = uRepos.DeleteNurse((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            FillDataGridView();
                        }
                    }

                    if (e.ColumnIndex == 13)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new NurseRepository(uow);
                            try
                            {
                                data = uRepos.UpdateNurse(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            dataGridView1.Columns.RemoveAt(9);
                            FillDataGridView();
                        }
                    }
                    break;
                case Enums.CommonOperationType.OUser:
                    label1.Text = "User Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    if (e.ColumnIndex == 5)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new UserRepository(uow);
                            try
                            {
                                data = uRepos.DeleteUser((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(5);
                            dataGridView1.Columns.RemoveAt(5);
                            FillDataGridView();
                        }
                    }

                    if (e.ColumnIndex == 6)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new UserRepository(uow);
                            try
                            {
                                data = uRepos.UpdateUser(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(5);
                            dataGridView1.Columns.RemoveAt(5);
                            FillDataGridView();
                        }
                    }
                    break;
                case Enums.CommonOperationType.OAppoinment:
                    label1.Text = "Appointment Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    if (e.ColumnIndex == 8)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new Repositories.AppoinmentRepository(uow);
                            try
                            {
                                data = uRepos.DeleteAppointment((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(4);
                            dataGridView1.Columns.RemoveAt(4);
                            dataGridView1.Columns.RemoveAt(4);
                            dataGridView1.Columns.RemoveAt(4);
                            dataGridView1.Columns.RemoveAt(4);
                            dataGridView1.Columns.RemoveAt(4);
                            FillDataGridView();
                        }
                    }

                    if (e.ColumnIndex == 9)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new Repositories.AppoinmentRepository(uow);
                            try
                            {

                                dataGridView1.Columns.RemoveAt(1);
                                data = uRepos.UpdateAppointment(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            FillDataGridView();
                        }
                    }
                    break;
                case Enums.CommonOperationType.OPolyclinic:
                    label1.Text = "Polyclinic Name:";
                    txtSearch.Left = label1.Width + label1.Left + 20;
                    if (e.ColumnIndex == 3)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new PolyclinicRepository(uow);
                            try
                            {
                                data = uRepos.DeletePolyclinic((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            FillDataGridView();
                        }
                    }

                    if (e.ColumnIndex == 4)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new PolyclinicRepository(uow);
                            try
                            {
                                data = uRepos.UpdatePolyclinic(dataGridView1.Rows[e.RowIndex]);
                                uow.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                _excep = true;
                            }
                        }
                        if (_excep == false && data == 1)
                        {
                            MessageBox.Show("Operation is successfull...");
                            dataGridView1.Columns.RemoveAt(3);
                            dataGridView1.Columns.RemoveAt(3);
                            FillDataGridView();
                        }
                    }
                    break;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (type)
            {
                case Enums.CommonOperationType.ODoctor:
                    if (e.ColumnIndex == 10 && isLoad == false)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            var uRepos = new UnitRepository(uow);
                            DataGridViewCell cell;
                            DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                            cmb.DisplayMember = "UnitName";
                            cmb.ValueMember = "ID";
                            cmb.DataSource = uRepos.GetAllUnitsByPolyclinic((int)dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                            cell = cmb;
                            dataGridView1.Rows[e.RowIndex].Cells[11] = cell;
                        }
                    }
                    break;
                case Enums.CommonOperationType.ONurse:

                    if (e.ColumnIndex == 10 && isLoad == false)
                    {
                        using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                var uRepos = new UnitRepository(uow);
                                DataGridViewCell cell;
                                DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                                cmb.DisplayMember = "UnitName";
                                cmb.ValueMember = "ID";
                                cmb.DataSource = uRepos.GetAllUnitsByPolyclinic((int)dataGridView1.Rows[e.RowIndex].Cells["Polyclinics"].Value);
                                cell = cmb;
                                dataGridView1.Rows[e.RowIndex].Cells["Units"] = cell;
                            }
                        }
                    }
                    break;



            }
        }
    }
}
