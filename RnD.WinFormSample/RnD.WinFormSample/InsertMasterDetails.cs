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
    public partial class InsertMasterDetails : Form
    {
        public InsertMasterDetails()
        {
            InitializeComponent();
            GetCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

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

        #region My Method

        private void GetCategories()
        {
            SqlConnection sqlConnection = null;

            try
            {

                string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                sqlConnection = new SqlConnection(dbConnectionString);

                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Category", sqlConnection);

                ////DataSet
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //DataSet dataSet = new DataSet();
                //dataAdapter.Fill(dataSet);

                //DataTable
                DataTable dataTable = new DataTable();
                SqlDataReader dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);

                List<Category> categoryLst = new List<Category>();
                categoryLst.Add(new Category() { CategoryId = 0, CategoryName = "--Select--" });

                int count = dataTable.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    categoryLst.Add(new Category() { CategoryId = (int)row[0], CategoryName = (string)row[1] });
                }

                this.cmbCategory.DataSource = categoryLst;
                this.cmbCategory.DisplayMember = "CategoryName";
                this.cmbCategory.ValueMember = "CategoryId";
                this.cmbCategory.Refresh();

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

        #endregion
    }
}
