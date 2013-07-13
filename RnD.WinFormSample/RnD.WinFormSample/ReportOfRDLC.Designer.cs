namespace RnD.WinFormSample
{
    partial class ReportOfRDLC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.winform_dbDataSet = new RnD.WinFormSample.winform_dbDataSet();
            this.StudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StudentTableAdapter = new RnD.WinFormSample.winform_dbDataSetTableAdapters.StudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.winform_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "winform_dbDataSet_Student";
            reportDataSource1.Value = this.StudentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RnD.WinFormSample.RDLC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(757, 630);
            this.reportViewer1.TabIndex = 0;
            // 
            // winform_dbDataSet
            // 
            this.winform_dbDataSet.DataSetName = "winform_dbDataSet";
            this.winform_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentBindingSource
            // 
            this.StudentBindingSource.DataMember = "Student";
            this.StudentBindingSource.DataSource = this.winform_dbDataSet;
            // 
            // StudentTableAdapter
            // 
            this.StudentTableAdapter.ClearBeforeFill = true;
            // 
            // ReportOfRDLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 655);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportOfRDLC";
            this.Text = "RoportOfRDLC";
            this.Load += new System.EventHandler(this.ReportOfRDLC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.winform_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StudentBindingSource;
        private winform_dbDataSet winform_dbDataSet;
        private RnD.WinFormSample.winform_dbDataSetTableAdapters.StudentTableAdapter StudentTableAdapter;
    }
}