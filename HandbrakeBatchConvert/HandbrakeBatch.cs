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
            txtDestination.Text = sourcePath + "\\Converted";
        }

        private void btnDestinationBrowse_Click(object sender, EventArgs e)
        {
            txtDestination.Text = folderBrowse();
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

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
