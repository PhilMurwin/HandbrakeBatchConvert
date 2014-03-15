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
    public partial class Preview : BaseForm
    {
        public Preview(string[] files)
        {
            InitializeComponent();
            txtPreview.Font = new Font(FontFamily.GenericMonospace, txtPreview.Font.Size);

            if (files != null || files.Length > 0)
            {
                txtPreview.Text = string.Join("\n", files);
            }
            else
            {
                txtPreview.Text = "No files found.";
            }
        }
    }
}
