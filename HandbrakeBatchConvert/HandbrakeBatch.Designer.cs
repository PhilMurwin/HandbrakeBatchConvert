namespace HandbrakeBatchConvert
{
    partial class HandbrakeBatch
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
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.grpDestination = new System.Windows.Forms.GroupBox();
            this.grpOptional = new System.Windows.Forms.GroupBox();
            this.grpPreset = new System.Windows.Forms.GroupBox();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnSourceBrowse = new System.Windows.Forms.Button();
            this.btnDestinationBrowse = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblExtension = new System.Windows.Forms.Label();
            this.cboFileExtension = new System.Windows.Forms.ComboBox();
            this.cboDeleteSource = new System.Windows.Forms.ComboBox();
            this.lblDeleteSource = new System.Windows.Forms.Label();
            this.cboMetaData = new System.Windows.Forms.ComboBox();
            this.lblMetadata = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cboPreset = new System.Windows.Forms.ComboBox();
            this.lblPreset = new System.Windows.Forms.Label();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnSaveQuery = new System.Windows.Forms.Button();
            this.pnlFiller = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grpSource.SuspendLayout();
            this.grpDestination.SuspendLayout();
            this.grpOptional.SuspendLayout();
            this.grpPreset.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.btnSourceBrowse);
            this.grpSource.Controls.Add(this.txtSource);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSource.Location = new System.Drawing.Point(0, 15);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(569, 52);
            this.grpSource.TabIndex = 0;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source - Location of Files to Encode";
            // 
            // grpDestination
            // 
            this.grpDestination.Controls.Add(this.btnDestinationBrowse);
            this.grpDestination.Controls.Add(this.txtDestination);
            this.grpDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDestination.Location = new System.Drawing.Point(0, 67);
            this.grpDestination.Name = "grpDestination";
            this.grpDestination.Size = new System.Drawing.Size(569, 53);
            this.grpDestination.TabIndex = 1;
            this.grpDestination.TabStop = false;
            this.grpDestination.Text = "Destination - Location to save encoded files to";
            // 
            // grpOptional
            // 
            this.grpOptional.Controls.Add(this.cboPriority);
            this.grpOptional.Controls.Add(this.lblPriority);
            this.grpOptional.Controls.Add(this.cboMetaData);
            this.grpOptional.Controls.Add(this.lblMetadata);
            this.grpOptional.Controls.Add(this.cboDeleteSource);
            this.grpOptional.Controls.Add(this.lblDeleteSource);
            this.grpOptional.Controls.Add(this.cboFileExtension);
            this.grpOptional.Controls.Add(this.lblExtension);
            this.grpOptional.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOptional.Location = new System.Drawing.Point(0, 0);
            this.grpOptional.Name = "grpOptional";
            this.grpOptional.Size = new System.Drawing.Size(569, 85);
            this.grpOptional.TabIndex = 2;
            this.grpOptional.TabStop = false;
            this.grpOptional.Text = "Optional Items";
            // 
            // grpPreset
            // 
            this.grpPreset.Controls.Add(this.btnSaveQuery);
            this.grpPreset.Controls.Add(this.txtQuery);
            this.grpPreset.Controls.Add(this.lblQuery);
            this.grpPreset.Controls.Add(this.cboPreset);
            this.grpPreset.Controls.Add(this.lblPreset);
            this.grpPreset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPreset.Location = new System.Drawing.Point(0, 85);
            this.grpPreset.Name = "grpPreset";
            this.grpPreset.Size = new System.Drawing.Size(569, 191);
            this.grpPreset.TabIndex = 3;
            this.grpPreset.TabStop = false;
            this.grpPreset.Text = "Choose Preset";
            // 
            // pnlFile
            // 
            this.pnlFile.Controls.Add(this.grpDestination);
            this.pnlFile.Controls.Add(this.grpSource);
            this.pnlFile.Controls.Add(this.pnlFiller);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFile.Location = new System.Drawing.Point(0, 0);
            this.pnlFile.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(569, 120);
            this.pnlFile.TabIndex = 4;
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.grpPreset);
            this.pnlConfig.Controls.Add(this.grpOptional);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfig.Location = new System.Drawing.Point(0, 120);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(569, 276);
            this.pnlConfig.TabIndex = 5;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnPreview);
            this.pnlControl.Controls.Add(this.btnStart);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 358);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(569, 38);
            this.pnlControl.TabIndex = 6;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(11, 19);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(451, 20);
            this.txtSource.TabIndex = 0;
            // 
            // btnSourceBrowse
            // 
            this.btnSourceBrowse.Location = new System.Drawing.Point(468, 17);
            this.btnSourceBrowse.Name = "btnSourceBrowse";
            this.btnSourceBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSourceBrowse.TabIndex = 1;
            this.btnSourceBrowse.Text = "Browse...";
            this.btnSourceBrowse.UseVisualStyleBackColor = true;
            this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
            // 
            // btnDestinationBrowse
            // 
            this.btnDestinationBrowse.Location = new System.Drawing.Point(468, 19);
            this.btnDestinationBrowse.Name = "btnDestinationBrowse";
            this.btnDestinationBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDestinationBrowse.TabIndex = 3;
            this.btnDestinationBrowse.Text = "Browse...";
            this.btnDestinationBrowse.UseVisualStyleBackColor = true;
            this.btnDestinationBrowse.Click += new System.EventHandler(this.btnDestinationBrowse_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(11, 19);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(451, 20);
            this.txtDestination.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(473, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Encoding Now...";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(392, 8);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview CLI";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(12, 21);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(114, 13);
            this.lblExtension.TabIndex = 0;
            this.lblExtension.Text = "Choose File Extension:";
            // 
            // cboFileExtension
            // 
            this.cboFileExtension.FormattingEnabled = true;
            this.cboFileExtension.Items.AddRange(new object[] {
            "mp4"});
            this.cboFileExtension.Location = new System.Drawing.Point(15, 42);
            this.cboFileExtension.Name = "cboFileExtension";
            this.cboFileExtension.Size = new System.Drawing.Size(111, 21);
            this.cboFileExtension.TabIndex = 1;
            this.cboFileExtension.Text = "mp4";
            // 
            // cboDeleteSource
            // 
            this.cboDeleteSource.FormattingEnabled = true;
            this.cboDeleteSource.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboDeleteSource.Location = new System.Drawing.Point(160, 42);
            this.cboDeleteSource.Name = "cboDeleteSource";
            this.cboDeleteSource.Size = new System.Drawing.Size(111, 21);
            this.cboDeleteSource.TabIndex = 3;
            this.cboDeleteSource.Text = "No";
            // 
            // lblDeleteSource
            // 
            this.lblDeleteSource.AutoSize = true;
            this.lblDeleteSource.Location = new System.Drawing.Point(157, 21);
            this.lblDeleteSource.Name = "lblDeleteSource";
            this.lblDeleteSource.Size = new System.Drawing.Size(105, 13);
            this.lblDeleteSource.TabIndex = 2;
            this.lblDeleteSource.Text = "Delete Source Files?";
            // 
            // cboMetaData
            // 
            this.cboMetaData.FormattingEnabled = true;
            this.cboMetaData.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboMetaData.Location = new System.Drawing.Point(299, 42);
            this.cboMetaData.Name = "cboMetaData";
            this.cboMetaData.Size = new System.Drawing.Size(111, 21);
            this.cboMetaData.TabIndex = 5;
            this.cboMetaData.Text = "No";
            // 
            // lblMetadata
            // 
            this.lblMetadata.AutoSize = true;
            this.lblMetadata.Location = new System.Drawing.Point(296, 21);
            this.lblMetadata.Name = "lblMetadata";
            this.lblMetadata.Size = new System.Drawing.Size(80, 13);
            this.lblMetadata.TabIndex = 4;
            this.lblMetadata.Text = "Add Metadata?";
            // 
            // cboPriority
            // 
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Items.AddRange(new object[] {
            "High",
            "Above Normal",
            "Normal",
            "Below Normal",
            "Low"});
            this.cboPriority.Location = new System.Drawing.Point(432, 42);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(111, 21);
            this.cboPriority.TabIndex = 7;
            this.cboPriority.Text = "Normal";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(429, 21);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(119, 13);
            this.lblPriority.TabIndex = 6;
            this.lblPriority.Text = "Set Handbrake Priority?";
            // 
            // cboPreset
            // 
            this.cboPreset.FormattingEnabled = true;
            this.cboPreset.Items.AddRange(new object[] {
            "Normal",
            "High Profile"});
            this.cboPreset.Location = new System.Drawing.Point(15, 46);
            this.cboPreset.Name = "cboPreset";
            this.cboPreset.Size = new System.Drawing.Size(111, 21);
            this.cboPreset.TabIndex = 3;
            this.cboPreset.Text = "Normal";
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.Location = new System.Drawing.Point(12, 25);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(79, 13);
            this.lblPreset.TabIndex = 2;
            this.lblPreset.Text = "Choose Preset:";
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(12, 79);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(173, 13);
            this.lblQuery.TabIndex = 4;
            this.lblQuery.Text = "OR Edit or paste your Query below:";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(15, 96);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(395, 47);
            this.txtQuery.TabIndex = 5;
            // 
            // btnSaveQuery
            // 
            this.btnSaveQuery.Location = new System.Drawing.Point(419, 120);
            this.btnSaveQuery.Name = "btnSaveQuery";
            this.btnSaveQuery.Size = new System.Drawing.Size(124, 23);
            this.btnSaveQuery.TabIndex = 6;
            this.btnSaveQuery.Text = "Save As Custom Query";
            this.btnSaveQuery.UseVisualStyleBackColor = true;
            this.btnSaveQuery.Click += new System.EventHandler(this.btnSaveQuery_Click);
            // 
            // pnlFiller
            // 
            this.pnlFiller.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiller.Location = new System.Drawing.Point(0, 0);
            this.pnlFiller.Name = "pnlFiller";
            this.pnlFiller.Size = new System.Drawing.Size(569, 15);
            this.pnlFiller.TabIndex = 2;
            // 
            // HandbrakeBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 396);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "HandbrakeBatch";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Handbrake Batch Convert";
            this.Load += new System.EventHandler(this.HandbrakeBatch_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandbrakeBatch_KeyPress);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.grpDestination.ResumeLayout(false);
            this.grpDestination.PerformLayout();
            this.grpOptional.ResumeLayout(false);
            this.grpOptional.PerformLayout();
            this.grpPreset.ResumeLayout(false);
            this.grpPreset.PerformLayout();
            this.pnlFile.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Button btnSourceBrowse;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.GroupBox grpDestination;
        private System.Windows.Forms.Button btnDestinationBrowse;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.GroupBox grpOptional;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cboMetaData;
        private System.Windows.Forms.Label lblMetadata;
        private System.Windows.Forms.ComboBox cboDeleteSource;
        private System.Windows.Forms.Label lblDeleteSource;
        private System.Windows.Forms.ComboBox cboFileExtension;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.GroupBox grpPreset;
        private System.Windows.Forms.Panel pnlFile;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cboPreset;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.Button btnSaveQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.Panel pnlFiller;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

