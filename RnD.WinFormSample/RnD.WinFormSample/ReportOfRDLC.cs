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
    public partial class ReportOfRDLC : Form
    {
        public ReportOfRDLC()
        {
            InitializeComponent();
        }

        private void ReportOfRDLC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'winform_dbDataSet.Student' table. You can move, or remove it, as needed.
            this.StudentTableAdapter.Fill(this.winform_dbDataSet.Student);

            this.reportViewer1.RefreshReport();
        }
    }
}
