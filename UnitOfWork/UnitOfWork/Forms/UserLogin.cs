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
    public partial class UserLogin : Form
    {
        public int docID;
        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogIN_Click(object sender, EventArgs e)
        {
            using (var uow = (AdoNetUnitOfWork)UnitOfWorkFactory.Create(UnitOfWorkFactory.ConnectionType.SQL, Connection.connectionString))
            {
                var uRepos = new UserRepository(uow);
                int data = uRepos.FindUser(txtUserName.Text, txtPassword.Text);
                if (data == -1)
                {
                    MessageBox.Show("Username or Password is wrong...");
                }
                else
                {
                    docID = data;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
           
        }
    }
}
