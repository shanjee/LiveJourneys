using LiveJourneys.JourneyPlanningSystem.Business;
using LiveJourneys.JourneyPlanningSystem.Data;
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
    public partial class frmDistanceConfiguration : Form
    {
        private ManageLines manageLines;
        private ManageStations manageStations;
        private ManageStationMapping manageStationMapping;
        private ICollection<Station> stations;
        private ICollection<Line> lines;

        public frmDistanceConfiguration()
        {
            InitializeComponent();

            IUnitOfWork unitOfWork = new UnitOfWork();
            manageStationMapping = new ManageStationMapping(unitOfWork);
            manageStations = new ManageStations(unitOfWork);
            manageLines = new ManageLines(unitOfWork);
        }

        private void ComboBoxTrainLineDataSourceBinding()
        {
            lines = manageLines.GetAllLines().ToList();

            cmbTrainLine.DataSource = lines;
            cmbTrainLine.ValueMember = "Id";
            cmbTrainLine.DisplayMember = "Name";
        }

        private void ComboBoxStationDataSourceBinding()
        {
            cmbFromStation.DataSource = stations;
            cmbFromStation.ValueMember = "Id";
            cmbFromStation.DisplayMember = "Name";

            cmbToStation.DataSource = stations.Select(s => s).ToList();
            cmbToStation.ValueMember = "Id";
            cmbToStation.DisplayMember = "Name";

            cmbFromStation.SelectedIndex = -1;
            cmbToStation.SelectedIndex = -1;
        }

        private void frmDistanceConfiguration_Load(object sender, EventArgs e)
        {
            ComboBoxTrainLineDataSourceBinding();
            Clear();
        }

        private void cmbTrainLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            var line = (sender as ComboBox).SelectedItem as Line;
            if (line != null)
            {
                stations = manageStations.GetStationsByLineId(line.Id);
            }
            else
            {
                stations = new List<Station>();
            }

            ComboBoxStationDataSourceBinding();
        }

        private void btnSetDistance_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(txtDistance.Text, out int distance);
                var stationMapping = new StationMapping()
                {
                    LineId = cmbTrainLine.SelectedValue != null ? (int)cmbTrainLine.SelectedValue : 0,
                    FromStaionId = cmbFromStation.SelectedValue != null ? (int)cmbFromStation.SelectedValue : 0,
                    ToStationId = cmbToStation.SelectedValue != null ? (int)cmbToStation.SelectedValue : 0,
                    Distance = distance
                };

                var result = manageStationMapping.CreateStationMapping(stationMapping);

                if (result > 0)
                {
                    MessageBox.Show("Distance confiquration added success", "Set distance configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    return;
                }

                MessageBox.Show("Distance confiquration could not added.", "Set distance configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Set distance configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Set distance configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Set distance configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtDistance.Text = "0";
            cmbTrainLine.SelectedIndex = -1;
            cmbFromStation.Text = "";
            cmbToStation.Text = "";
        }
    }
}
