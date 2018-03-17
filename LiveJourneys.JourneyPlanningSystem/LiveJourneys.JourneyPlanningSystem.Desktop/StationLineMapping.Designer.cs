namespace LiveJourneys.JourneyPlanningSystem.Desktop
{
    partial class frmStationLineMapping
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
            this.dgvTrainStations = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStationOrder = new System.Windows.Forms.TextBox();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.cmbTrainLine = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.frmClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainStations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTrainStations
            // 
            this.dgvTrainStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrainStations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainStations.Location = new System.Drawing.Point(12, 187);
            this.dgvTrainStations.Name = "dgvTrainStations";
            this.dgvTrainStations.ReadOnly = true;
            this.dgvTrainStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainStations.Size = new System.Drawing.Size(296, 190);
            this.dgvTrainStations.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtStationOrder);
            this.groupBox1.Controls.Add(this.cmbStation);
            this.groupBox1.Controls.Add(this.cmbTrainLine);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.frmClear);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Station Line Mapping Details";
            // 
            // txtStationOrder
            // 
            this.txtStationOrder.Location = new System.Drawing.Point(83, 83);
            this.txtStationOrder.Name = "txtStationOrder";
            this.txtStationOrder.Size = new System.Drawing.Size(202, 20);
            this.txtStationOrder.TabIndex = 5;
            // 
            // cmbStation
            // 
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(83, 53);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(202, 21);
            this.cmbStation.TabIndex = 3;
            this.cmbStation.SelectedIndexChanged += new System.EventHandler(this.cmbStation_SelectedIndexChanged);
            // 
            // cmbTrainLine
            // 
            this.cmbTrainLine.FormattingEnabled = true;
            this.cmbTrainLine.Location = new System.Drawing.Point(83, 24);
            this.cmbTrainLine.Name = "cmbTrainLine";
            this.cmbTrainLine.Size = new System.Drawing.Size(202, 21);
            this.cmbTrainLine.TabIndex = 1;
            this.cmbTrainLine.SelectedIndexChanged += new System.EventHandler(this.cmbTrainLine_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(129, 117);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmClear
            // 
            this.frmClear.Location = new System.Drawing.Point(210, 117);
            this.frmClear.Name = "frmClear";
            this.frmClear.Size = new System.Drawing.Size(75, 23);
            this.frmClear.TabIndex = 8;
            this.frmClear.Text = "Clear";
            this.frmClear.UseVisualStyleBackColor = true;
            this.frmClear.Click += new System.EventHandler(this.frmClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(48, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Train Line : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Station Order : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Station Name : ";
            // 
            // frmStationLineMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 389);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTrainStations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmStationLineMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Station Line Mapping";
            this.Load += new System.EventHandler(this.frmTrainLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainStations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrainStations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.ComboBox cmbTrainLine;
        private System.Windows.Forms.Button frmClear;
        private System.Windows.Forms.TextBox txtStationOrder;
        private System.Windows.Forms.Label label3;
    }
}