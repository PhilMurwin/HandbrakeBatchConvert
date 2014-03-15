using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandbrakeBatchConvert
{
    public partial class HandbrakeBatch : Form
    {
        #region Members
        private bool ProcessingHandbrake = false;
        private Logger logger = LogManager.GetCurrentClassLogger();
        private BackgroundWorker bgWorker;


        private string Destination
        {
            get
            {
                var destination = txtDestination.Text;
                destination = (destination.EndsWith("\\") ? destination : destination + "\\") + "{0}." + cboFileExtension.Text;

                return destination;
            }
        }

        private bool CustomQuery
        {
            get
            {
                return !string.IsNullOrEmpty(txtQuery.Text);
            }
        }

        private string Query
        {
            get
            {
                return CustomQuery ? txtQuery.Text : cboPreset.Text;
            }
        }
        #endregion Members

        #region Constructor
        public HandbrakeBatch()
        {
            InitializeComponent();
        }
        #endregion Constructor

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
            var files = BatchConvert.GetFileList(txtSource.Text);

            var longestStringLength = files.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;

            // Build list of input/output files
            for(int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var fileInfo = new FileInfo(file);
                file = "Source: " + file.PadRight(longestStringLength + 4) + "\tDestination: " + string.Format(" " + Destination, Path.GetFileNameWithoutExtension(fileInfo.Name));
                files[i] = file;
            }

            Preview preview = new Preview(files.ToArray());
            preview.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            logger.Info("Enter Processing Code");

            // Validation
            logger.Info("Make sure the Destination directory exists");
            var destination = txtDestination.Text;

            if (string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("You must select a valid destination directory!");
                return;
            }
            else
            {
                Directory.CreateDirectory(destination);
            }

            // After Validation
            // Save the Query Text if it has changed
            if (!string.IsNullOrEmpty(txtQuery.Text))
            {
                AppConfig.Query = txtQuery.Text;
            }

            var files = BatchConvert.GetFileList(txtSource.Text);
            ConfigureProgressBar(files.Count);

            ProcessingHandbrake = true;
            StartBackgroundWorker(files);
        }

        private void StartBackgroundWorker(List<string> files)
        {
            if (bgWorker == null)
            {
                bgWorker = new BackgroundWorker();
                bgWorker.RunWorkerCompleted += bgWorker_WorkCompleted;
                bgWorker.DoWork += bgWorker_DoWork;
            }

            // Disable text boxes and buttons
            ToggleControlsEnabled(false);
            bgWorker.RunWorkerAsync(new List<object>{ files, Destination, Query, CustomQuery });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var obj = e.Argument as List<object>;
            var files = obj[0] as List<string>;
            var destination = obj[1] as string;
            var query = obj[2] as string;
            var customQuery = (bool)obj[3];
            ProcessVideos(files, destination, query, customQuery);
        }

        private void bgWorker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Disable text boxes and buttons
            ToggleControlsEnabled(true);

            ProcessingHandbrake = false;
            logger.Info("Processing Complete, exit code");
        }

        private void ProcessVideos(List<string> files, string destination, string query, bool customQuery)
        {
            logger.Info("Begin processing");
            logger.Info("Retrieve processing commands.");

            var commands = BatchConvert.GetProcessingCommands(files, destination, query, customQuery);
            int totalCommands = commands.Count;            
            var errorCount = 0;

            for (int i = 0; i < totalCommands; i++)
            {
                var fileCount = i+1;
                var filePath = files[i];

                try
                {
                    logger.Info(string.Format("Proccesing file [{0} of {1}]: {2}.", fileCount, totalCommands, filePath));
                    ProgressBar_Update(string.Format("Processing {0} of {1}", fileCount, totalCommands), false, false);

                    var command = commands[i];
                    var processInfo = new ProcessStartInfo();
                    processInfo.UseShellExecute = false;
                    processInfo.RedirectStandardError = true;
                    processInfo.CreateNoWindow = true;
                    processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processInfo.FileName = ".\\Resources\\HandBrakeCLI.exe";
                    processInfo.Arguments = command;

                    var process = Process.Start(processInfo);
                    var standardError = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    WriteHandbrakeLogToFile(filePath, standardError);

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

                    if (errorCount > 2)
                    {
                        logger.Fatal("Multiple errors have occurred.  Halting processing");
                        break;
                    }
                }
                finally
                {
                    // Only set status text if we're done.
                    var statusText = (fileCount == totalCommands) ? string.Format("{0} of {1} Completed", fileCount, totalCommands) : "";
                    var errorOccurred = (errorCount > 0);

                    ProgressBar_Update(statusText, errorOccurred);
                }
            }
        }

        private void WriteHandbrakeLogToFile(string filePath, string log)
        {
            var fileInfo = new FileInfo(filePath);
            var fileName = Path.GetFileNameWithoutExtension(fileInfo.Name);

            var handbrakeLog = LogManager.GetLogger("_Handbrake." + fileName);
            handbrakeLog.Info(log);
        }

        private void ConfigureProgressBar(int totalCommands)
        {
            progressStatus.ForeColor = Color.Green;
            progressStatus.Minimum = 1;
            progressStatus.Maximum = totalCommands;
            progressStatus.Step = 1;
            progressStatus.Value = 1;

            progressStatus.DisplayStyle = ProgressBarWithLabel.ProgressBarDisplayText.CustomText;
            progressStatus.CustomText = "1 of " + totalCommands.ToString();
        }

        private void ToggleControlsEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(ProgressBarWithLabel.ProgressBarWLabel))
                {
                    continue;
                }

                control.Enabled = enabled;
            }
        }

        private delegate void ProgressBar_Update_Handler(string statusText, bool errorOccurred = false, bool performStep = true);

        public void ProgressBar_Update(string statusText, bool errorOccurred = false, bool performStep = true)
        {
            // If we're in the wrong thread use Invoke and the delegate
            if (progressStatus.InvokeRequired)
            {
                progressStatus.Invoke(new ProgressBar_Update_Handler(ProgressBar_Update), statusText, errorOccurred, performStep);
                return;
            }

            if (!string.IsNullOrEmpty(statusText))
            {
                progressStatus.CustomText = statusText;
            }

            // Update progress bar
            if (errorOccurred)
            {
                progressStatus.ForeColor = Color.Red;
            }

            if (performStep)
            {
                progressStatus.PerformStep();
            }
        }

        private void HandbrakeBatch_Load(object sender, EventArgs e)
        {
            this.Text += " v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            progressStatus.DisplayStyle = ProgressBarWithLabel.ProgressBarDisplayText.CustomText;
            progressStatus.CustomText = "0 of 0";

            // Load any saved settings
            txtSource.Text = AppConfig.Source;
            txtDestination.Text = AppConfig.Destination;
            txtQuery.Text = AppConfig.Query;
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

        private void HandbrakeBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the user presses escape exit the application            
            if (e.KeyChar == (char)Keys.Escape)
            {
                // Relies on FormClosing for the confirm dialog if necessary
                this.Close();
            }            
        }

        bool IsFormClosing = false;
        private void HandbrakeBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsFormClosing)
            {
                IsFormClosing = true;
                CloseMe();
                e.Cancel = true;
                IsFormClosing = false;
            }
        }

        private void CloseMe()
        {
            bool confirmClose = true;

            // If we're currently processing files display a warning first
            if (ProcessingHandbrake)
            {
                var result = MessageBox.Show("Currently processing files, are you sure you want to exit?", "Confirm Exit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                confirmClose = (result == System.Windows.Forms.DialogResult.Yes);
            }

            if (confirmClose)
            {
                this.Close();
            }
        }       
    }
}
