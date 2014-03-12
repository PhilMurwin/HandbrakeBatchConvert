using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandbrakeBatchConvert
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.KeyPreview = true;
            this.KeyPress += Form_KeyPress;
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
