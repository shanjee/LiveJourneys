namespace LiveJourneys.JourneyPlanningSystem.Desktop
{
    partial class frmDistanceConfiguration
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTrainLine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFromStation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbToStation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckIsDeleay = new System.Windows.Forms.CheckBox();
            this.btnSetDistance = new System.Windows.Forms.Button();
            this.txtDistance = new LiveJourneys.JourneyPlanningSystem.Desktop.CustomControl.DistanceTextbox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Train Line : ";
            // 
            // cmbTrainLine
            // 
            this.cmbTrainLine.FormattingEnabled = true;
            this.cmbTrainLine.Location = new System.Drawing.Point(83, 25);
            this.cmbTrainLine.Name = "cmbTrainLine";
            this.cmbTrainLine.Size = new System.Drawing.Size(178, 21);
            this.cmbTrainLine.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Station : ";
            // 
            // cmbFromStation
            // 
            this.cmbFromStation.FormattingEnabled = true;
            this.cmbFromStation.Location = new System.Drawing.Point(83, 55);
            this.cmbFromStation.Name = "cmbFromStation";
            this.cmbFromStation.Size = new System.Drawing.Size(178, 21);
            this.cmbFromStation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Station : ";
            // 
            // cmbToStation
            // 
            this.cmbToStation.FormattingEnabled = true;
            this.cmbToStation.Location = new System.Drawing.Point(83, 85);
            this.cmbToStation.Name = "cmbToStation";
            this.cmbToStation.Size = new System.Drawing.Size(178, 21);
            this.cmbToStation.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Distance : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDistance);
            this.groupBox1.Controls.Add(this.ckIsDeleay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbToStation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbFromStation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbTrainLine);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Station Distance Confiquration Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "isDeleay : ";
            // 
            // ckIsDeleay
            // 
            this.ckIsDeleay.AutoSize = true;
            this.ckIsDeleay.Location = new System.Drawing.Point(83, 145);
            this.ckIsDeleay.Name = "ckIsDeleay";
            this.ckIsDeleay.Size = new System.Drawing.Size(15, 14);
            this.ckIsDeleay.TabIndex = 9;
            this.ckIsDeleay.UseVisualStyleBackColor = true;
            // 
            // btnSetDistance
            // 
            this.btnSetDistance.Location = new System.Drawing.Point(109, 192);
            this.btnSetDistance.Name = "btnSetDistance";
            this.btnSetDistance.Size = new System.Drawing.Size(91, 23);
            this.btnSetDistance.TabIndex = 1;
            this.btnSetDistance.Text = "Set Distance";
            this.btnSetDistance.UseVisualStyleBackColor = true;
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(83, 115);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(178, 20);
            this.txtDistance.TabIndex = 10;
            // 
            // frmDistanceConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 234);
            this.Controls.Add(this.btnSetDistance);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDistanceConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distance Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTrainLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFromStation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbToStation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckIsDeleay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetDistance;
        private CustomControl.DistanceTextbox txtDistance;
    }
}