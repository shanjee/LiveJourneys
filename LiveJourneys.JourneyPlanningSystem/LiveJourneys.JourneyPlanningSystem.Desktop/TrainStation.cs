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
    public partial class frmTrainStation : Form
    {
        private ManageStations manageStations;
        private ICollection<Station> trainStations;
        private Station currentStation;

        public frmTrainStation()
        {
            manageStations = new ManageStations(new UnitOfWork());
            InitializeComponent();
        }

        private void frmTrainLine_Load(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        private void DataGridBinding()
        {
            trainStations = manageStations.GetAllStations().ToList();
            dgvTrainStations.DataSource = trainStations;

            dgvTrainStations.Columns["StationLines"].Visible = false;
            dgvTrainStations.Columns["FromStationMappings"].Visible = false;
            dgvTrainStations.Columns["ToStationMappings"].Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                var stationName = txtStationName.Text;
                currentStation = manageStations.GetStationByName(stationName);

                if(currentStation != null)
                {
                    txtStationName.Text = currentStation.Name;
                    txtStationId.Text = currentStation.Id.ToString();
                    return;
                }

                MessageBox.Show($"Could not found train Station \"{stationName}\".", "Find train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Clear();
        }

        private void Clear()
        {
            txtStationId.Clear();
            txtStationName.Clear();
            currentStation = null;
        }

        private bool ValidateInput()
        {
            var isValid = true;
            if(string.IsNullOrWhiteSpace(txtStationName.Text))
            {
                MessageBox.Show("Staion name should not be null.", "Train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Station station = new Station() { Name = txtStationName.Text };
                    var result = manageStations.CreateStation(station);

                    if (result > 0)
                    {
                        MessageBox.Show($"Train station \"{station.Name}\" added success.", "Add train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not added train station \"{station.Name}\".", "Add train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Add train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Add train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Add train station error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    if (currentStation == null)
                    {
                        MessageBox.Show($"First find the train station.", "Edit train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string previousStationName = currentStation.Name; 
                    currentStation.Name = Name = txtStationName.Text;
                    var result = manageStations.Update(currentStation);

                    if (result > 0)
                    {
                        MessageBox.Show($"Train station \"{previousStationName}\" edited success.", "Edit train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not edited train station \"{previousStationName}\".", "Edit train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Edit train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Edit train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Edit train station error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clear();
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
                    if (currentStation == null)
                    {
                        MessageBox.Show($"First find the train station.", "Delete train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string stationName = currentStation.Name;
                    DialogResult dialogResult = MessageBox.Show($"Are you want to delete Train station \"{stationName}\" ?", "Delete train station", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.No)
                    {
                        return;
                    }

                    var result = manageStations.Delete(currentStation);

                    if (result > 0)
                    {
                        MessageBox.Show($"Train station \"{stationName}\" deleted success.", "Delete train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not deleted train station \"{stationName}\".", "Delete train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Delete train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Delete train station", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Delete train station error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clear();
            }
        }
    }
}
