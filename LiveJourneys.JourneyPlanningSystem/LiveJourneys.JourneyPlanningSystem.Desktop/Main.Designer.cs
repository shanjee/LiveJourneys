namespace LiveJourneys.JourneyPlanningSystem.Desktop
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewuser = new System.Windows.Forms.ToolStripButton();
            this.tsbTrainLine = new System.Windows.Forms.ToolStripButton();
            this.tsbTrainStation = new System.Windows.Forms.ToolStripButton();
            this.tsbStationLineMapping = new System.Windows.Forms.ToolStripButton();
            this.tsbDistanceConfiguration = new System.Windows.Forms.ToolStripButton();
            this.dgvAllLineDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLineDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewuser,
            this.tsbTrainLine,
            this.tsbTrainStation,
            this.tsbStationLineMapping,
            this.tsbDistanceConfiguration});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(753, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewuser
            // 
            this.tsbNewuser.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewuser.Image")));
            this.tsbNewuser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewuser.Name = "tsbNewuser";
            this.tsbNewuser.Size = new System.Drawing.Size(102, 22);
            this.tsbNewuser.Text = "Add New User";
            this.tsbNewuser.Click += new System.EventHandler(this.tsbNewuser_Click);
            // 
            // tsbTrainLine
            // 
            this.tsbTrainLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbTrainLine.Image")));
            this.tsbTrainLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTrainLine.Name = "tsbTrainLine";
            this.tsbTrainLine.Size = new System.Drawing.Size(78, 22);
            this.tsbTrainLine.Text = "Train Line";
            this.tsbTrainLine.Click += new System.EventHandler(this.tsbTrainLine_Click);
            // 
            // tsbTrainStation
            // 
            this.tsbTrainStation.Image = ((System.Drawing.Image)(resources.GetObject("tsbTrainStation.Image")));
            this.tsbTrainStation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTrainStation.Name = "tsbTrainStation";
            this.tsbTrainStation.Size = new System.Drawing.Size(89, 22);
            this.tsbTrainStation.Text = "Train Staion";
            this.tsbTrainStation.Click += new System.EventHandler(this.tsbTrainStation_Click);
            // 
            // tsbStationLineMapping
            // 
            this.tsbStationLineMapping.Image = ((System.Drawing.Image)(resources.GetObject("tsbStationLineMapping.Image")));
            this.tsbStationLineMapping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStationLineMapping.Name = "tsbStationLineMapping";
            this.tsbStationLineMapping.Size = new System.Drawing.Size(140, 22);
            this.tsbStationLineMapping.Text = "Station Line Mapping";
            this.tsbStationLineMapping.Click += new System.EventHandler(this.tsbStationLineMapping_Click);
            // 
            // tsbDistanceConfiguration
            // 
            this.tsbDistanceConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("tsbDistanceConfiguration.Image")));
            this.tsbDistanceConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDistanceConfiguration.Name = "tsbDistanceConfiguration";
            this.tsbDistanceConfiguration.Size = new System.Drawing.Size(149, 22);
            this.tsbDistanceConfiguration.Text = "Distance Configuration";
            this.tsbDistanceConfiguration.Click += new System.EventHandler(this.tsbDistanceConfiguration_Click);
            // 
            // dgvAllLineDetails
            // 
            this.dgvAllLineDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllLineDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLineDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllLineDetails.Location = new System.Drawing.Point(0, 25);
            this.dgvAllLineDetails.Name = "dgvAllLineDetails";
            this.dgvAllLineDetails.ReadOnly = true;
            this.dgvAllLineDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllLineDetails.Size = new System.Drawing.Size(753, 311);
            this.dgvAllLineDetails.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 336);
            this.Controls.Add(this.dgvAllLineDetails);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Journey Planning System";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLineDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewuser;
        private System.Windows.Forms.ToolStripButton tsbTrainLine;
        private System.Windows.Forms.ToolStripButton tsbTrainStation;
        private System.Windows.Forms.ToolStripButton tsbStationLineMapping;
        private System.Windows.Forms.ToolStripButton tsbDistanceConfiguration;
        private System.Windows.Forms.DataGridView dgvAllLineDetails;
    }
}