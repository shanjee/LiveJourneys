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
    public partial class frmLogin : Form
    {
        private ManageUsers manageUsers;
        JourneyPlanningSystemDbContext _context = null;

        public frmLogin(JourneyPlanningSystemDbContext context)
        {
            _context = context;
            InitializeComponent();
            IBasicRepository<User> repository = new BasicEFRepository<User>(_context);
            manageUsers = new ManageUsers(repository);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                var user = manageUsers.VerifyUser(username,password);

                if (user != null && user.TypeId == 1)
                {
                    new frmMain(_context).Show();
                    this.Hide();
                }
                else if(user != null)
                {
                    Clear();
                    MessageBox.Show("Unauthorized access", "Log In error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Clear();
                    MessageBox.Show("Invalid username and password.", "Log In error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex) 
            {
                MessageBox.Show(ex.Message,"Log In error", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Log In error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
