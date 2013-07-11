using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using RnD.WinFormSample.Models;

namespace RnD.WinFormSample
{
    public partial class InsertGenerateId : Form
    {
        public InsertGenerateId()
        {
            InitializeComponent();

            GetBatchs();
            GetSubjects();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    if (!IsItemExitToGrid())
                    {
                        DataGridViewRow dataGridViewRow = (DataGridViewRow)this.dgvStudents.Rows[0].Clone();

                        //dataGridViewRow.Cells["BatchId"].Value = this.cmbBatch.SelectedValue;
                        //dataGridViewRow.Cells["BatchName"].Value = this.cmbBatch.Text;
                        //dataGridViewRow.Cells["SubjectId"].Value = this.cmbSubject.SelectedValue;
                        //dataGridViewRow.Cells["SubjectName"].Value = this.cmbSubject.Text;
                        //dataGridViewRow.Cells["StudentId"].Value = this.txtStudentId.Text;
                        //dataGridViewRow.Cells["StudentName"].Value = this.txtStudentName.Text;
                        //dataGridViewRow.Cells["StudentAddress"].Value = this.txtStudentAddress.Text;
                        //dataGridViewRow.Cells["StudentMobile"].Value = this.txtStudentMobile.Text;
                        //dataGridViewRow.Cells["StudentEmail"].Value = this.txtStudentEmail.Text;

                        dataGridViewRow.Cells[0].Value = this.cmbBatch.SelectedValue;
                        dataGridViewRow.Cells[1].Value = this.cmbBatch.Text;
                        dataGridViewRow.Cells[2].Value = this.cmbSubject.SelectedValue;
                        dataGridViewRow.Cells[3].Value = this.cmbSubject.Text;
                        dataGridViewRow.Cells[4].Value = this.txtStudentId.Text;
                        dataGridViewRow.Cells[5].Value = this.txtStudentName.Text;
                        dataGridViewRow.Cells[6].Value = this.txtStudentAddress.Text;
                        dataGridViewRow.Cells[7].Value = this.txtStudentMobile.Text;
                        dataGridViewRow.Cells[8].Value = this.txtStudentEmail.Text;

                        dgvStudents.Rows.Add(dataGridViewRow);
                    }
                    else
                    {
                        MessageBox.Show("Can not add duplicate item");
                    }
                    ResetForm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnGenerateId_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtStudentId.Text = GenerateId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (!(this.dgvStudents.Rows[0].IsNewRow))
                {
                    if (SaveDataViewGridDatas())
                    {
                        MessageBox.Show("Data saved successfully");
                        //ResetGrid();
                    }
                    else
                    {
                        MessageBox.Show("Data can not saved successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Could not found item");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #region My Methods

        private void GetBatchs()
        {
            SqlConnection sqlConnection = null;

            try
            {

                string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                sqlConnection = new SqlConnection(dbConnectionString);

                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Batch", sqlConnection);

                ////DataSet
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //DataSet dataSet = new DataSet();
                //dataAdapter.Fill(dataSet);

                //DataTable
                DataTable dataTable = new DataTable();
                SqlDataReader dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);

                List<Batch> batchLst = new List<Batch>();
                batchLst.Add(new Batch() { BatchId = 0, BatchName = "--Select--" });

                int count = dataTable.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    batchLst.Add(new Batch() { BatchId = (int)row[0], BatchName = (string)row[1] });
                }

                this.cmbBatch.DataSource = batchLst;
                this.cmbBatch.DisplayMember = "BatchName";
                this.cmbBatch.ValueMember = "BatchId";
                this.cmbBatch.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        private void GetSubjects()
        {
            SqlConnection sqlConnection = null;

            try
            {

                string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                sqlConnection = new SqlConnection(dbConnectionString);

                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Subject", sqlConnection);

                ////DataSet
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //DataSet dataSet = new DataSet();
                //dataAdapter.Fill(dataSet);

                //DataTable
                DataTable dataTable = new DataTable();
                SqlDataReader dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);

                List<Subject> subjectLst = new List<Subject>();
                subjectLst.Add(new Subject() { SubjectId = 0, SubjectName = "--Select--" });

                int count = dataTable.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    subjectLst.Add(new Subject() { SubjectId = (int)row[0], SubjectName = (string)row[1] });
                }

                this.cmbSubject.DataSource = subjectLst;
                this.cmbSubject.DisplayMember = "SubjectName";
                this.cmbSubject.ValueMember = "SubjectId";
                this.cmbSubject.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        private bool InsertStudent(Student model)
        {
            bool isInsert = false;

            SqlConnection sqlConnection = null;

            try
            {

                string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                sqlConnection = new SqlConnection(dbConnectionString);

                string sql = "INSERT INTO Student (StudentId, StudentName, StudentAddress, StudentMobile, StudentEmail, BatchId, SubjectId) values (@StudentId, @StudentName, @StudentAddress, @StudentMobile, @StudentEmail, @BatchId, @SubjectId)";

                SqlCommand command = new SqlCommand(sql, sqlConnection);

                SqlParameter parmStudentId = new SqlParameter("@StudentId", SqlDbType.Int);
                parmStudentId.Value = model.SubjectId;
                command.Parameters.Add(parmStudentId);

                SqlParameter parmStudentName = new SqlParameter("@StudentName", SqlDbType.NVarChar, 50);
                parmStudentName.Value = model.StudentName;
                command.Parameters.Add(parmStudentName);

                SqlParameter parmStudentAddress = new SqlParameter("@StudentAddress", SqlDbType.NVarChar, 50);
                parmStudentAddress.Value = model.StudentAddress;
                command.Parameters.Add(parmStudentAddress);

                SqlParameter parmStudentMobile = new SqlParameter("@StudentMobile", SqlDbType.NVarChar, 50);
                parmStudentMobile.Value = model.StudentMobile;
                command.Parameters.Add(parmStudentMobile);

                SqlParameter parmStudentEmail = new SqlParameter("@StudentEmail", SqlDbType.NVarChar, 50);
                parmStudentEmail.Value = model.StudentEmail;
                command.Parameters.Add(parmStudentEmail);

                SqlParameter parmBatchId = new SqlParameter("@BatchId", SqlDbType.Int);
                parmBatchId.Value = model.BatchId;
                command.Parameters.Add(parmBatchId);

                SqlParameter parmSubjectId = new SqlParameter("@SubjectId", SqlDbType.Int);
                parmSubjectId.Value = model.SubjectId;
                command.Parameters.Add(parmSubjectId);

                sqlConnection.Open();
                command.ExecuteNonQuery();

                isInsert = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }

            return isInsert;
        }

        private bool InsertStudents(List<Student> modelList)
        {
            bool isInsert = false;

            SqlConnection sqlConnection = null;

            try
            {
                if (modelList.Any())
                {

                    string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                    sqlConnection = new SqlConnection(dbConnectionString);

                    SqlCommand command = new SqlCommand("sp_InsertStudents", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    // declare a table to store the parameter values 
                    DataTable detailItems = new DataTable();
                    detailItems.Columns.Add("StudentId", typeof(int));
                    detailItems.Columns.Add("StudentName", typeof(string));
                    detailItems.Columns.Add("StudentAddress", typeof(string));
                    detailItems.Columns.Add("StudentMobile", typeof(string));
                    detailItems.Columns.Add("StudentEmail", typeof(string));
                    detailItems.Columns.Add("BatchId", typeof(int));
                    detailItems.Columns.Add("SubjectId", typeof(int));

                    foreach (var item in modelList)
                    {
                        detailItems.Rows.Add(new object[] { item.StudentId, item.StudentName, item.StudentAddress, item.StudentMobile, item.StudentEmail, item.BatchId, item.SubjectId });
                    }

                    // add the table as a parameter to the stored procedure 
                    SqlParameter paramDetailItems = command.Parameters.AddWithValue("@students", detailItems);
                    paramDetailItems.SqlDbType = SqlDbType.Structured;
                    paramDetailItems.TypeName = "dbo.StudentType";
                    //command.Parameters.Add(paramDetailItems);

                    SqlParameter parmResult = new SqlParameter("@result", SqlDbType.NVarChar, 100);
                    parmResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(parmResult);

                    SqlParameter parmMessage = new SqlParameter("@message", SqlDbType.NVarChar, 100);
                    parmMessage.Direction = ParameterDirection.Output;
                    command.Parameters.Add(parmMessage);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();


                    string result = command.Parameters["@result"].Value.ToString();

                    if (!String.IsNullOrEmpty(result) && result == "Fail")
                    {
                        return isInsert;

                    }
                    else
                    {
                        return isInsert = true;
                    }

                }
                else
                {
                    MessageBox.Show("Could not found item");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();

            }

            return isInsert;
        }

        private string GenerateId()
        {
            string r = string.Empty;

            if (this.cmbBatch.SelectedIndex > 0)
            {
                if (this.cmbSubject.SelectedIndex > 0)
                {
                    int lastStudentRow = GetStudentLastRow() + 1;
                    int batchId = Convert.ToInt32(this.cmbBatch.SelectedValue);
                    int subjectId = Convert.ToInt32(this.cmbSubject.SelectedValue);

                    string batchCode = batchId.ToString().PadLeft(3, '0');
                    string subjectCode = subjectId.ToString().PadLeft(3, '0');
                    string studentCode = lastStudentRow.ToString().PadLeft(5, '0');

                    r = String.Format("{0}{1}{2}", batchCode, subjectCode, studentCode);

                }
                else
                {
                    MessageBox.Show("Please select subject");
                }
            }
            else
            {
                MessageBox.Show("Please select batch");
            }

            return r;
        }

        private int GetStudentLastRow()
        {
            int r = 0;
            SqlConnection sqlConnection = null;

            try
            {

                string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                sqlConnection = new SqlConnection(dbConnectionString);

                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student", sqlConnection);
                command.CommandType = CommandType.Text;
                r = Convert.ToInt32(command.ExecuteScalar());

                return r;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return r;
        }

        private bool IsValid()
        {
            bool isValid = false;
            try
            {
                if (this.cmbBatch.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select batch");
                }
                else if (this.cmbSubject.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select subject");
                }
                else if (this.txtStudentId.Text == null || this.txtStudentId.Text == "")
                {
                    MessageBox.Show("Student id required");
                }
                else if (this.txtStudentName.Text == null || this.txtStudentName.Text == "")
                {
                    MessageBox.Show("Student name required");
                }
                else if (this.txtStudentAddress.Text == null || this.txtStudentAddress.Text == "")
                {
                    MessageBox.Show("Student address required");
                }
                else if (this.txtStudentMobile.Text == null || this.txtStudentMobile.Text == "")
                {
                    MessageBox.Show("Student mobile required");
                }
                else if (this.txtStudentEmail.Text == null || this.txtStudentEmail.Text == "")
                {
                    MessageBox.Show("Student email required");
                }
                else
                {
                    return isValid = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return isValid;
        }

        private bool IsItemExitToGrid()
        {
            bool isExit = false;
            try
            {

                string studentId = this.txtStudentId.Text;

                bool IsExistTemp = this.dgvStudents.Rows.Cast<DataGridViewRow>()
                            .Count(c => c.Cells[4].EditedFormattedValue.ToString() == studentId) == 1;

                if (IsExistTemp)
                {
                    isExit = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return isExit;
        }

        private void ResetForm()
        {
            this.cmbBatch.SelectedIndex = 0;
            this.cmbSubject.SelectedIndex = 0;
            this.txtStudentId.Text = "";
            this.txtStudentName.Text = "";
            this.txtStudentAddress.Text = "";
            this.txtStudentMobile.Text = "";
            this.txtStudentEmail.Text = "";
        }

        private bool SaveDataViewGridDatas()
        {
            bool isSave = false;

            try
            {
                List<Student> studentLst = new List<Student>();

                foreach (DataGridViewRow row in this.dgvStudents.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int batchId = Convert.ToInt32(row.Cells[0].Value);
                        string batchName = row.Cells[1].Value.ToString();
                        int subjectId = Convert.ToInt32(row.Cells[2].Value);
                        string subjectName = row.Cells[3].Value.ToString();
                        int studentId = Convert.ToInt32(row.Cells[4].Value);
                        string studentName = row.Cells[5].Value.ToString();
                        string studentAddress = row.Cells[6].Value.ToString();
                        string studentMobile = row.Cells[7].Value.ToString();
                        string studentEmail = row.Cells[8].Value.ToString();

                        Student student = new Student()
                        {
                            StudentId = studentId,
                            StudentName = studentName,
                            StudentAddress = studentAddress,
                            StudentMobile = studentMobile,
                            StudentEmail = studentEmail,
                            BatchId = batchId,
                            SubjectId = subjectId
                        };

                        studentLst.Add(student);
                    }

                }

                if (InsertStudents(studentLst))
                    isSave = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return isSave;
        }

        #endregion
    }
}
