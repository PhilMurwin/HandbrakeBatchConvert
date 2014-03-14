using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandbrakeBatchConvert
{
    public partial class HandbrakeBatch : Form
    {
        bool ProcessingHandbrake = false;
        Logger logger = LogManager.GetCurrentClassLogger();

        public HandbrakeBatch()
        {
            InitializeComponent();
        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            var sourcePath = OpenFolderDialog();
            txtSource.Text = sourcePath;
            AppConfig.Source = sourcePath;

            txtDestination.Text = sourcePath + "\\Converted";
            AppConfig.Destination = sourcePath + "\\Converted";
        }

        private void btnDestinationBrowse_Click(object sender, EventArgs e)
        {
            var destinationpath = OpenFolderDialog();
            txtDestination.Text = destinationpath;
            AppConfig.Destination = destinationpath;
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Don't currently feel like taking the time to implement a way to save these, should probably be a separate XML file or custom app.config section");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var commands = GetProcessingCommands();

            Preview preview = new Preview(commands.ToArray());
            preview.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            logger.Info("Enter Processing Code");

            if (!string.IsNullOrEmpty(txtQuery.Text))
            {
                AppConfig.Query = txtQuery.Text;
            }

            logger.Info("Retrieve processing commands.");
            var commands = GetProcessingCommands();

            ProcessingHandbrake = true;

            logger.Info("Begin processing");
            int totalCommands = commands.Count;
            progressStatus.Step = 100 / totalCommands;
            progressStatus.ForeColor = Color.Green;
            var errorCount = 0;

            for(int i = 0; i < totalCommands; i++)
            {
                try
                {
                    var command = commands[i];
                    var processInfo = new ProcessStartInfo();
                    processInfo.FileName = ".\\Resources\\HandBrakeCLI.exe";
                    processInfo.Arguments = command;

                    var process = Process.Start(processInfo);
                    process.WaitForExit();

                    if (process.ExitCode == 1)
                    {
                        throw new Exception("Handbrake crashed!");
                    }
                }
                catch (Exception err)
                {
                    errorCount++;
                    string errMessage = "Exception: Something broke\n" + err.Message;
                    logger.ErrorException(errMessage, err);
                    progressStatus.ForeColor = Color.Red;

                    if (errorCount > 2)
                    {
                        logger.Fatal("Multiple errors have occurred.  Halting processing");
                        break;
                    }
                }

                progressStatus.PerformStep();
            }

            ProcessingHandbrake = false;

            logger.Info("Processing Complete, exit code");
        }

        private List<string> GetProcessingCommands()
        {
            var custom = !string.IsNullOrEmpty(txtQuery.Text);
            var query = custom ? txtQuery.Text : cboPreset.Text;
            var destination = txtDestination.Text;
            destination = (destination.EndsWith("\\") ? destination : destination + "\\") + "{0}." + cboFileExtension.Text;

            var files = BatchConvert.GetFileList(txtSource.Text);
#if DEBUG
            files = files.Take(1).ToArray();
#endif
            var commands = new List<string>(files.Length);

            foreach (var file in files)
            {
                commands.Add(BatchConvert.BuildCLICommand(file, destination, query, custom));
            }
            return commands;
        }

        private void HandbrakeBatch_Load(object sender, EventArgs e)
        {
            // Load any saved settings
            txtSource.Text = AppConfig.Source;
            txtDestination.Text = AppConfig.Destination;
            txtQuery.Text = AppConfig.Query;
        }

        private void HandbrakeBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the user presses escape exit the application
            // If we're currently processing files display a warning first
            if (e.KeyChar == (char)Keys.Escape)
            {
                bool confirmClose = true;

                if (ProcessingHandbrake)
                {
                    confirmClose = MessageBox.Show("Currently processing files, are you sure you want to exit?", "Confirm Exit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes;
                }

                if (confirmClose)
                {
                    this.Close();
                }
            }
        }

        private string OpenFolderDialog()
        {
            var folderPath = "";

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }

            return folderPath;
        }
    }
}
