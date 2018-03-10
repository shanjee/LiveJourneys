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
    public partial class frmMain : Form
    {
        private ManageUsers manageUsers;
        JourneyPlanningSystemDbContext _context = null;

        public frmMain(JourneyPlanningSystemDbContext context)
        {
            _context = context;
            IBasicRepository<User> repository = new BasicEFRepository<User>(_context);
            InitializeComponent();
        }

        private void tsbNewuser_Click(object sender, EventArgs e)
        {
            new frmNewuser(_context).ShowDialog();
        }

        private void tsbTrainLine_Click(object sender, EventArgs e)
        {
            new frmTrainLine(_context).ShowDialog();
        }
    }
}
