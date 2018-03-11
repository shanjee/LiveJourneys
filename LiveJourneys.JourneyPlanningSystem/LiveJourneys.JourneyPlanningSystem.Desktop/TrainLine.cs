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
    public partial class frmTrainLine : Form
    {
        private ManageLines manageLines;
        private ICollection<Line> trainLines;
        private Line currentTrainLine;

        public frmTrainLine()
        {
            manageLines = new ManageLines(new UnitOfWork());
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                var lineName = txtLine.Text;
                currentTrainLine = manageLines.GetLineByName(lineName);

                if(currentTrainLine != null)
                {
                    txtLine.Text = currentTrainLine.Name;
                    txtLineId.Text = currentTrainLine.Id.ToString();
                    return;
                }

                MessageBox.Show($"Could not found train line \"{lineName}\".", "Find train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Clear();
        }

        private void Clear()
        {
            txtLineId.Clear();
            txtLine.Clear();
            currentTrainLine = null;
        }

        private bool ValidateInput()
        {
            var isValid = true;
            if(string.IsNullOrWhiteSpace(txtLine.Text))
            {
                MessageBox.Show("Train line should not be null.", "Train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Line line = new Line() { Name = txtLine.Text };
                    var result = manageLines.CreateLine(line);

                    if (result > 0)
                    {
                        MessageBox.Show($"Train line \"{line.Name}\" added success.", "Add train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not added train line \"{line.Name}\".", "Add train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Add train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Add train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Add train line error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (currentTrainLine == null)
                    {
                        MessageBox.Show($"First find the train line.", "Edit train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string previousLineName = currentTrainLine.Name; 
                    currentTrainLine.Name = Name = txtLine.Text;
                    var result = manageLines.Update(currentTrainLine);

                    if (result > 0)
                    {
                        MessageBox.Show($"Train line \"{previousLineName}\" edited success.", "Edit train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not edited train line \"{previousLineName}\".", "Edit train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Edit train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Edit train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Edit train line error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (currentTrainLine == null)
                    {
                        MessageBox.Show($"First find the train line.", "Delete train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string lineName = currentTrainLine.Name;
                    DialogResult dialogResult = MessageBox.Show($"Are you want to delete Train line \"{lineName}\" ?", "Delete train line", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                    var result = manageLines.Delete(currentTrainLine);

                    if (result > 0)
                    {
                        MessageBox.Show($"Train line \"{lineName}\" deleted success.", "Delete train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridBinding();
                        return;
                    }

                    MessageBox.Show($"Could not deleted train line \"{lineName}\".", "Delete train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Delete train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Delete train line", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.", "Delete train line error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clear();
            }
        }
    }
}
