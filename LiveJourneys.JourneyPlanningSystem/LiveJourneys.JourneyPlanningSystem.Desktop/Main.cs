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
            BindLineDetailsGrid();
        }

        private void tsbNewuser_Click(object sender, EventArgs e)
        {
            new frmNewuser().ShowDialog();
        }

        private void tsbTrainLine_Click(object sender, EventArgs e)
        {
            new frmTrainLine().ShowDialog();
            BindLineDetailsGrid();
        }

        private void tsbTrainStation_Click(object sender, EventArgs e)
        {
            new frmTrainStation().ShowDialog();
            BindLineDetailsGrid();
        }

        private void tsbStationLineMapping_Click(object sender, EventArgs e)
        {
            new frmStationLineMapping().ShowDialog();
            BindLineDetailsGrid();
        }

        private void tsbDistanceConfiguration_Click(object sender, EventArgs e)
        {
            new frmDistanceConfiguration().ShowDialog();
            BindLineDetailsGrid();
        }

        private void BindLineDetailsGrid()
        {
            var lines = new ManageLines(new UnitOfWork()).GetAllLines(); 
            List<LineGrid> lineDetails = new List<LineGrid>();
            bool foundLineStation = false;
            foreach (var line in lines)
            {
                foundLineStation = false;
                foreach (var station in line.StationLines)
                {
                    var nextStationDetail = line.StationMappings.FirstOrDefault(n => n.LineId == line.Id && n.FromStaionId == station.StationId);
                    var nextStation = nextStationDetail != null ? nextStationDetail.ToStation.Name : "";
                    var distance = nextStationDetail != null ? nextStationDetail.Distance : 0;
                    bool isDelay = nextStationDetail != null ? nextStationDetail.IsDeleay.Value : false;

                    var lineGrid = new LineGrid()
                    {
                        Line = line.Name,
                        Station = station.Station.Name,
                        StationOrder = station.OrderNumber.ToString(),
                        NextStation = nextStation,
                        Distance = distance,
                        IsDelay = isDelay
                    };

                    lineDetails.Add(lineGrid);
                    foundLineStation = true;
                }

                if(!foundLineStation)
                {
                    var lineGrid = new LineGrid()
                    {
                        Line = line.Name,
                        Station = "",
                        StationOrder = "",
                        NextStation = "",
                        Distance = 0
                    };

                    lineDetails.Add(lineGrid);
                }
            }

            dgvAllLineDetails.DataSource = lineDetails
                                            .OrderBy(s => s.Line)
                                            .ThenBy(s => s.StationOrder)
                                            .ToList();
        }
    }

    class LineGrid
    {
        public string Line { get; set; }
        public string StationOrder { get; set; }
        public string Station { get; set; }
        public string NextStation { get; set; } = "";
        public double Distance { get; set; } = 0;
        public bool IsDelay { get; set; } = false;
    }

}
