using LiveJourneys.JourneyPlanningSystem.Business;
using LiveJourneys.JourneyPlanningSystem.Data;
using LiveJourneys.JourneyPlanningSystem.Data.Repository;
using LiveJourneys.JourneyPlanningSystem.Models;
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
        private JourneyPlanningSystemDbContext _context = null;
        private ICollection<UserType> userTypes;

        public frmNewuser(JourneyPlanningSystemDbContext context)
        {
            _context = context;
            IBasicRepository<User> userRepository = new BasicEFRepository<User>(_context);
            IBasicRepository<UserType> userTypeRepository = new BasicEFRepository<UserType>(_context);
            manageUsers = new ManageUsers(userRepository);
            manageUserTypes = new ManageUserTypes(userTypeRepository);
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
            cmbUserType.SelectedIndex = 1;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new User()
                {
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    TypeId = (int)cmbUserType.SelectedValue
                };

                var user = await manageUsers.CreateUser(newUser);
                if(user!= null && user.Id > 0)
                {
                    MessageBox.Show("New user created success.", "New user create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New user create", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
