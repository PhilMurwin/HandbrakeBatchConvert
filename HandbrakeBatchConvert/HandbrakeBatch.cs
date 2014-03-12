using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandbrakeBatchConvert
{
    public partial class HandbrakeBatch : Form
    {
        public HandbrakeBatch()
        {
            InitializeComponent();
        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            var sourcePath = folderBrowse();
            txtSource.Text = sourcePath;
            AppConfig.Source = sourcePath;

            txtDestination.Text = sourcePath + "\\Converted";
            AppConfig.Destination = sourcePath + "\\Converted";
        }

        private void btnDestinationBrowse_Click(object sender, EventArgs e)
        {
            var destinationpath = folderBrowse();
            txtDestination.Text = destinationpath;
            AppConfig.Destination = destinationpath;
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var files = BatchConvert.GetFileList(txtSource.Text);
            Preview preview = new Preview(files);

            preview.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private string BuildCLICommand(string filePath)
        {
            //TODO: Set outputpath using textdestination and filepath filename and extension
            var outputPath = txtDestination.Text;
            var query = txtQuery.Text;

            var command = "HandBrakeCLI -i {0} -o {1} {2}";
            command = string.Format(command, filePath, outputPath, query);

            return command;
        }

        private void HandbrakeBatch_Load(object sender, EventArgs e)
        {
            txtSource.Text = AppConfig.Source;
            txtDestination.Text = AppConfig.Destination;
        }

        private void HandbrakeBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private string folderBrowse()
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
