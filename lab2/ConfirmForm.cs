using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace lab2
{
    public partial class ConfirmForm : Form
    {
        string filePath;
        public ConfirmForm()
        {
            InitializeComponent();
        }
        public ConfirmForm(string path)
        {
            InitializeComponent();
            filePath = path;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            Process.Start("explorer",filePath);
        }
    }
}
