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
    public partial class frmStationLineMapping : Form
    {
        private ManageStationLines manageStationLines;
        private ICollection<object> stationLinesMapping;
        private ICollection<Station> stations;
        private ICollection<Line> lines;
        private Station selectedStation;
        private Line selectedTrainLine;

        public frmStationLineMapping()
        {
            manageStationLines = new ManageStationLines(new UnitOfWork());
            InitializeComponent();
        }

        private void frmTrainLine_Load(object sender, EventArgs e)
        {
            DataGridBinding();
            ComboBoxDataSourceBinding();
            Clear();
        }

        private void DataGridBinding()
        {
            stationLinesMapping = manageStationLines.GetAllStationLinesNameOnly().ToList();
            dgvTrainStations.DataSource = stationLinesMapping;
        }

        private void ComboBoxDataSourceBinding()
        {
            lines = manageStationLines.GetAllTrainLines();
            stations = manageStationLines.GetAllStations();

            cmbTrainLine.DataSource = lines;
            cmbTrainLine.ValueMember = "Id";
            cmbTrainLine.DisplayMember = "Name";

            cmbStation.DataSource = stations;
            cmbStation.ValueMember = "Id";
            cmbStation.DisplayMember = "Name";
        }

        private void Clear()
        {
            cmbTrainLine.SelectedIndex = -1;
            cmbStation.SelectedIndex = -1;
            txtStationOrder.Clear();
        }

        private bool ValidateInput()
        {
            var isValid = true;
            if(cmbTrainLine.SelectedIndex < 0 || cmbStation.SelectedIndex < 0)
            {
                MessageBox.Show("Staion Name or Train Line should not be selected.", "Station line mapping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = false;
            }

            int.TryParse(txtStationOrder.Text, out int stationOrder);

            if (stationOrder <= 0)
            {
                MessageBox.Show("Station Order shoud be greater than 0", "Station line mapping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    int.TryParse(txtStationOrder.Text, out int stationOrder);
                    StationLine stationLine = new StationLine() { LineId = (int)cmbTrainLine.SelectedValue,  StationId = (int)cmbStation.SelectedValue, OrderNumber = stationOrder };
                    var result = manageStationLines.CreateStationLine(stationLine);

                    if (result > 0)
                    {
                        MessageBox.Show($"Station Line mapping {StationLineMappingText()} added success.", "Add station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        Clear();
                        return;
                    }

                    MessageBox.Show($"Station Line mapping {StationLineMappingText()} could not added.", "Add station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Add station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Add station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Add station line error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var stationLine = manageStationLines.GetStationLineByIds((int)cmbTrainLine.SelectedValue, (int)cmbStation.SelectedValue);

                    if(stationLine == null)
                    {
                        MessageBox.Show($"station line mapping {StationLineMappingText()} not exesits.", "Delete station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult dialogResult = MessageBox.Show($"Are you sure to delete station line {StationLineMappingText()} ?", "Delete station line", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    
                    var result = manageStationLines.Delete(stationLine);

                    if (result > 0)
                    {
                        MessageBox.Show($"Station Line {StationLineMappingText()} deleted success.", "Delete station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not deleted station line {StationLineMappingText()}.", "Delete station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Delete station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Delete station line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Delete station line error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTrainLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTrainLine = (sender as ComboBox).SelectedItem as Line;
        }

        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStation = (sender as ComboBox).SelectedItem as Station;
        }

        private string StationLineMappingText()
        {
            if(selectedStation?.Name == null || selectedTrainLine?.Name == null)
            {
                return String.Empty;
            }

            return $"\"{selectedStation.Name}\" ==> \"{selectedTrainLine.Name}\"";
        }
    }
}
