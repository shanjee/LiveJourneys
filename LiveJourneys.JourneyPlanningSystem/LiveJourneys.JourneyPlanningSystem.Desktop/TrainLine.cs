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
    public partial class frmTrainLine : Form
    {
        private ManageLines manageLines;
        private JourneyPlanningSystemDbContext _context = null;
        private ICollection<Line> trainLines;

        public frmTrainLine(JourneyPlanningSystemDbContext context)
        {
            _context = context;
            IBasicRepository<Line> lineRepository = new BasicEFRepository<Line>(_context);
            manageLines = new ManageLines(lineRepository);
            InitializeComponent();
        }

        private void frmTrainLine_Load(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        private void DataGridBinding()
        {
            trainLines = manageLines.GetAllLines().ToList();
            dgvTrainLines.DataSource = trainLines;

            dgvTrainLines.Columns["StationLines"].Visible = false;
            dgvTrainLines.Columns["StationMappings"].Visible = false;
        }
    }
}
