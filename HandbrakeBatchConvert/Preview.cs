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

            txtPreview.Text = string.Join("\n", files);
        }
    }
}
