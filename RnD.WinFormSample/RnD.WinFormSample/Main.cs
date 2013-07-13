using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RnD.WinFormSample
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertGenerateId form = new InsertGenerateId();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertMasterDetails form = new InsertMasterDetails();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportOfCrystall form = new ReportOfCrystall();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReportOfRDLC form = new ReportOfRDLC();
            form.Show();
        }
    }
}
