namespace RnD.WinFormSample
{
    partial class InsertGenerateId
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.btnGenerateId = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.txtStudentAddress = new System.Windows.Forms.TextBox();
            this.txtStudentMobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStudentEmail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.BatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch:";
            // 
            // cmbBatch
            // 
            this.cmbBatch.DisplayMember = "BatchName";
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(83, 10);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(150, 24);
            this.cmbBatch.TabIndex = 1;
            this.cmbBatch.ValueMember = "BatchId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(340, 13);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(150, 24);
            this.cmbSubject.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID:";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Enabled = false;
            this.txtStudentId.Location = new System.Drawing.Point(83, 48);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(150, 22);
            this.txtStudentId.TabIndex = 5;
            // 
            // btnGenerateId
            // 
            this.btnGenerateId.Location = new System.Drawing.Point(257, 48);
            this.btnGenerateId.Name = "btnGenerateId";
            this.btnGenerateId.Size = new System.Drawing.Size(140, 24);
            this.btnGenerateId.TabIndex = 6;
            this.btnGenerateId.Text = "Generate Id";
            this.btnGenerateId.UseVisualStyleBackColor = true;
            this.btnGenerateId.Click += new System.EventHandler(this.btnGenerateId_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Name:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(83, 82);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(150, 22);
            this.txtStudentName.TabIndex = 8;
            // 
            // txtStudentAddress
            // 
            this.txtStudentAddress.Location = new System.Drawing.Point(340, 82);
            this.txtStudentAddress.Name = "txtStudentAddress";
            this.txtStudentAddress.Size = new System.Drawing.Size(150, 22);
            this.txtStudentAddress.TabIndex = 9;
            // 
            // txtStudentMobile
            // 
            this.txtStudentMobile.Location = new System.Drawing.Point(83, 116);
            this.txtStudentMobile.Name = "txtStudentMobile";
            this.txtStudentMobile.Size = new System.Drawing.Size(150, 22);
            this.txtStudentMobile.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mobile:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Email:";
            // 
            // txtStudentEmail
            // 
            this.txtStudentEmail.Location = new System.Drawing.Point(340, 116);
            this.txtStudentEmail.Name = "txtStudentEmail";
            this.txtStudentEmail.Size = new System.Drawing.Size(150, 22);
            this.txtStudentEmail.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(322, 148);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 24);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(415, 148);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 24);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchId,
            this.BatchName,
            this.SubjectId,
            this.SubjectName,
            this.StudentId,
            this.StudentName,
            this.StudentAddress,
            this.StudentMobile,
            this.StudentEmail});
            this.dgvStudents.Location = new System.Drawing.Point(12, 192);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(478, 162);
            this.dgvStudents.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Location = new System.Drawing.Point(415, 369);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 24);
            this.btnCencel.TabIndex = 19;
            this.btnCencel.Text = "Cencel";
            this.btnCencel.UseVisualStyleBackColor = true;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // BatchId
            // 
            this.BatchId.HeaderText = "BatchId";
            this.BatchId.Name = "BatchId";
            this.BatchId.Visible = false;
            // 
            // BatchName
            // 
            this.BatchName.HeaderText = "Batch";
            this.BatchName.Name = "BatchName";
            // 
            // SubjectId
            // 
            this.SubjectId.HeaderText = "SubjectId";
            this.SubjectId.Name = "SubjectId";
            this.SubjectId.Visible = false;
            // 
            // SubjectName
            // 
            this.SubjectName.HeaderText = "Subject";
            this.SubjectName.Name = "SubjectName";
            // 
            // StudentId
            // 
            this.StudentId.HeaderText = "ID";
            this.StudentId.Name = "StudentId";
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Name";
            this.StudentName.Name = "StudentName";
            // 
            // StudentAddress
            // 
            this.StudentAddress.HeaderText = "Address";
            this.StudentAddress.Name = "StudentAddress";
            // 
            // StudentMobile
            // 
            this.StudentMobile.HeaderText = "Mobile";
            this.StudentMobile.Name = "StudentMobile";
            // 
            // StudentEmail
            // 
            this.StudentEmail.HeaderText = "Email";
            this.StudentEmail.Name = "StudentEmail";
            // 
            // InsertGenerateId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 404);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtStudentEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStudentMobile);
            this.Controls.Add(this.txtStudentAddress);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerateId);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBatch);
            this.Controls.Add(this.label1);
            this.Name = "InsertGenerateId";
            this.Text = "InsertGenerateId";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Button btnGenerateId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtStudentAddress;
        private System.Windows.Forms.TextBox txtStudentMobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStudentEmail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentEmail;
    }
}