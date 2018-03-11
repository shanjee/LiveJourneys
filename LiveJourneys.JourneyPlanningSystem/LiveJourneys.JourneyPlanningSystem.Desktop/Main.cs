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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void tsbNewuser_Click(object sender, EventArgs e)
        {
            new frmNewuser().ShowDialog();
        }

        private void tsbTrainLine_Click(object sender, EventArgs e)
        {
            new frmTrainLine().ShowDialog();
        }

        private void tsbTrainStation_Click(object sender, EventArgs e)
        {
            new frmTrainStation().ShowDialog();
        }

        private void tsbStationLineMapping_Click(object sender, EventArgs e)
        {
            new frmStationLineMapping().ShowDialog();
        }
    }
}
