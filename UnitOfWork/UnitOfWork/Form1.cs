using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitOfWork
{
    public partial class Form1 : Form
    {
        int userType;
        bool isLoad = true;
        public Form1()
        {
            InitializeComponent();
            Forms.UserLogin user = new Forms.UserLogin();
            if (user.ShowDialog() == DialogResult.OK)
            {
                userType = user.docID;
            }
            ResizeForm();
            isLoad = false;
        }
        void ResizeForm()
        {
            if (userType == 0)
            {
                panel15.Visible = true;
                panel16.Visible = false;
                this.Width = panel15.Width + 50;
                this.Height = panel15.Height + 50;
                panel15.Left = (this.Width - panel15.Width) / 2;
                panel15.Top = (this.Height - panel15.Height) / 2;
            }
            else
            {
                panel15.Visible = false;
                panel16.Visible = true;
                this.Width = panel16.Width + 50;
                this.Height = panel16.Height + 50;
                panel16.Left = (this.Width - panel16.Width) / 2;
                panel16.Top = (this.Height - panel16.Height) / 2;
            }
        }
        string a = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            
        }

        private void btnNList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.ONurse);
            userList.ShowDialog();
        }

        private void btnNAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.ONurse);
            addUser.ShowDialog();
        }

        private void btnPolyclinicList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.OPolyclinic);
            userList.ShowDialog();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.OUser);
            userList.ShowDialog();
        }

        private void btnPolyclinicAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.OPolyclinic);
            addUser.ShowDialog();
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.OUser);
            addUser.ShowDialog();
        }

        private void btnDList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.ODoctor);
            userList.ShowDialog();
        }

        private void btnDAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.ODoctor);
            addUser.ShowDialog();
        }

        private void btnUnitList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.OUnit);
            userList.ShowDialog();
        }

        private void btnUnitAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.OUnit);
            addUser.ShowDialog();
        }

        private void btnPList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.OPatient);
            userList.ShowDialog();
        }

        private void btnPAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.OPatient);
            addUser.ShowDialog();
        }
        private void btnAppointmentList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList(Enums.CommonOperationType.OAppoinment);
            userList.ShowDialog();
        }

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(Enums.CommonOperationType.OAppoinment);
            addUser.ShowDialog();
        }
        private void Add_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Image.FromFile(a + @"\Resources\Actions-list-add-icon.png");
        }
        private void Add_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Image.FromFile(a + @"\Resources\add-icon (1).png");
        }
        private void List_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Image.FromFile(a + @"\Resources\Numbering-List-icon.png");
        }
        private void List_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Image.FromFile(a + @"\Resources\Bulleted-List-icon.png");
        }

        private void btnDocLeave_Click(object sender, EventArgs e)
        {
            Forms.Annual_Leave annual_Leave = new Forms.Annual_Leave(Enums.CommonOperationType.ODoctor);
            annual_Leave.ShowDialog();
        }

        private void btnNurseLeave_Click(object sender, EventArgs e)
        {
            Forms.Annual_Leave annual_Leave = new Forms.Annual_Leave(Enums.CommonOperationType.ONurse);
            annual_Leave.ShowDialog();
        }
        private void Leave_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).BackgroundImage = Image.FromFile(a + @"\Resources\icons8-leave-100.png");
        }
        private void Leave_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Image.FromFile(a + @"\Resources\icons8-leave-1000.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    var dRepos = new DoctorRepository(uow);
                    dRepos.CheckLeave();
                    uow.SaveChanges();
                    
                }
                catch
                {

                }
            }
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                try
                {
                    var nRepos = new NurseRepository(uow);
                    nRepos.CheckLeave();
                    uow.SaveChanges();

                }
                catch
                {

                }
            }
            
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnDocPatientList_Click(object sender, EventArgs e)
        {
            Forms.DocPatients docPatients = new Forms.DocPatients(userType);
            docPatients.ShowDialog();
        }

        private void btnDocPatientList_Click_1(object sender, EventArgs e)
        {
            Forms.DocPatients docPatients = new Forms.DocPatients(userType);
            docPatients.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(isLoad==false)
            {
                ResizeForm();
            }
        }
    }
}
