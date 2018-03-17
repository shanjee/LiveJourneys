using LiveJourneys.JourneyPlanningSystem.Business;
using LiveJourneys.JourneyPlanningSystem.Data;
using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveJourneys.JourneyPlanningSystem.Desktop
{
    public partial class frmNewuser : Form
    {
        private ManageUsers manageUsers;
        private ManageUserTypes manageUserTypes;

        public frmNewuser()
        {
            manageUsers = new ManageUsers(new UnitOfWork());
            manageUserTypes = new ManageUserTypes(new UnitOfWork());
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbUserType.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new User()
                {
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    TypeId = (int)cmbUserType.SelectedValue
                };

                var result  = manageUsers.CreateUser(newUser);
                if(result > 0)
                {
                    MessageBox.Show("New user created success.", "New user create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "New user create", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "New user create", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNewuser_Load(object sender, EventArgs e)
        {
            var userTypes = manageUserTypes.GetAllTypes().ToList();
            cmbUserType.DataSource = userTypes;
            cmbUserType.DisplayMember = "Type";
            cmbUserType.ValueMember = "Id";
        }
    }
}
