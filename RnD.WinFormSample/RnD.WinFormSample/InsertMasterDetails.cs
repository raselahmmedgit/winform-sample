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
                if (IsValid())
                {
                    if (!IsItemExitToGrid())
                    {
                        DataGridViewRow dataGridViewRow = (DataGridViewRow)this.dgvProducts.Rows[0].Clone();

                        //dataGridViewRow.Cells["CategoryId"].Value = this.cmbCategory.SelectedValue;
                        //dataGridViewRow.Cells["CategoryName"].Value = this.cmbCategory.Text;
                        //dataGridViewRow.Cells["ProductName"].Value = this.txtProductName.Text;
                        //dataGridViewRow.Cells["ProductPrice"].Value = this.txtProductPrice.Text;
                        //dataGridViewRow.Cells["ProductQty"].Value = this.txtProductQty.Text;

                        dataGridViewRow.Cells[0].Value = this.cmbCategory.SelectedValue;
                        dataGridViewRow.Cells[1].Value = this.cmbCategory.Text;
                        dataGridViewRow.Cells[2].Value = this.txtProductName.Text;
                        dataGridViewRow.Cells[3].Value = this.txtProductPrice.Text;
                        dataGridViewRow.Cells[4].Value = this.txtProductQty.Text;

                        dgvProducts.Rows.Add(dataGridViewRow);
                    }
                    else
                    {
                        MessageBox.Show("Can not add duplicate item");
                    }
                    ResetDetailsForm();
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
                ResetDetailsForm();
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
                if (!(this.dgvProducts.Rows[0].IsNewRow))
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
        
        private bool InsertProduct(Product model)
        {
            bool isInsert = false;

            SqlConnection sqlConnection = null;

            try
            {

                string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                sqlConnection = new SqlConnection(dbConnectionString);

                string sql = "INSERT INTO Product (ProductId, ProductName, ProductPrice, ProductQty, CategoryId) values (@ProductId, @ProductName, @ProductPrice, @ProductQty, @CategoryId)";

                SqlCommand command = new SqlCommand(sql, sqlConnection);

                SqlParameter parmProductId = new SqlParameter("@ProductId", SqlDbType.Int);
                parmProductId.Value = model.ProductId;
                command.Parameters.Add(parmProductId);

                SqlParameter parmProductName = new SqlParameter("@ProductName", SqlDbType.NVarChar, 50);
                parmProductName.Value = model.ProductName;
                command.Parameters.Add(parmProductName);

                SqlParameter parmProductPrice = new SqlParameter("@ProductPrice", SqlDbType.Decimal);
                parmProductPrice.Value = model.ProductPrice;
                command.Parameters.Add(parmProductPrice);

                SqlParameter parmProductQty = new SqlParameter("@ProductQty", SqlDbType.Decimal);
                parmProductQty.Value = model.ProductQty;
                command.Parameters.Add(parmProductQty);

                SqlParameter parmCategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
                parmCategoryId.Value = model.CategoryId;
                command.Parameters.Add(parmCategoryId);

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

        private bool InsertProductsBySP(List<Product> modelList)
        {
            bool isInsert = false;

            SqlConnection sqlConnection = null;

            try
            {
                if (modelList.Any())
                {

                    string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                    sqlConnection = new SqlConnection(dbConnectionString);

                    SqlCommand command = new SqlCommand("sp_InsertProducts", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    // declare a table to store the parameter values 
                    DataTable detailItems = new DataTable();
                    detailItems.Columns.Add("ProductName", typeof(string));
                    detailItems.Columns.Add("ProductQty", typeof(decimal));
                    detailItems.Columns.Add("ProductPrice", typeof(decimal));
                    detailItems.Columns.Add("CategoryId", typeof(int));

                    foreach (var item in modelList)
                    {
                        detailItems.Rows.Add(new object[] { item.ProductName, item.ProductQty, item.ProductPrice, item.CategoryId });
                    }

                    // add the table as a parameter to the stored procedure 
                    SqlParameter paramDetailItems = command.Parameters.AddWithValue("@products", detailItems);
                    paramDetailItems.SqlDbType = SqlDbType.Structured;
                    paramDetailItems.TypeName = "dbo.ProductType";
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

        //sp_InsertCategoryProducts
        private bool InsertCategoryProductsBySP(Category model, List<Product> modelList)
        {
            bool isInsert = false;

            SqlConnection sqlConnection = null;

            try
            {
                if (modelList.Any())
                {

                    string dbConnectionString = ConfigurationManager.ConnectionStrings["appConStr"].ConnectionString;
                    sqlConnection = new SqlConnection(dbConnectionString);

                    SqlCommand command = new SqlCommand("sp_InsertCategoryProducts", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parmCustomerName = new SqlParameter("@categoryName", SqlDbType.VarChar, 50);
                    parmCustomerName.Value = model.CategoryName;
                    command.Parameters.Add(parmCustomerName);

                    // declare a table to store the parameter values 
                    DataTable detailItems = new DataTable();
                    detailItems.Columns.Add("ProductName", typeof(string));
                    detailItems.Columns.Add("ProductQty", typeof(decimal));
                    detailItems.Columns.Add("ProductPrice", typeof(decimal));
                    detailItems.Columns.Add("CategoryId", typeof(int));

                    foreach (var item in modelList)
                    {
                        detailItems.Rows.Add(new object[] { item.ProductName, item.ProductQty, item.ProductPrice, null });
                    }

                    // add the table as a parameter to the stored procedure 
                    SqlParameter paramDetailItems = command.Parameters.AddWithValue("@products", detailItems);
                    paramDetailItems.SqlDbType = SqlDbType.Structured;
                    paramDetailItems.TypeName = "dbo.ProductType";
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

        private bool IsValid()
        {
            bool isValid = false;
            try
            {
                if (this.cmbCategory.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select category");
                }
                else if (this.txtProductName.Text == null || this.txtProductName.Text == "")
                {
                    MessageBox.Show("Product name required");
                }
                else if (this.txtProductPrice.Text == null || this.txtProductPrice.Text == "")
                {
                    MessageBox.Show("Product price required");
                }
                else if (this.txtProductQty.Text == null || this.txtProductQty.Text == "")
                {
                    MessageBox.Show("Product Qty required");
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

                string productName = this.txtProductName.Text;

                bool IsExistTemp = this.dgvProducts.Rows.Cast<DataGridViewRow>()
                            .Count(c => c.Cells[2].EditedFormattedValue.ToString() == productName) == 1;

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

        private void ResetDetailsForm()
        {

            this.txtProductName.Text = "";
            this.txtProductPrice.Text = "";
            this.txtProductQty.Text = "";
        }

        private bool SaveDataViewGridDatas()
        {
            bool isSave = false;

            try
            {
                List<Product> productLst = new List<Product>();

                foreach (DataGridViewRow row in this.dgvProducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int categoryId = Convert.ToInt32(row.Cells[0].Value);
                        string categoryName = row.Cells[1].Value.ToString();
                        string productName = row.Cells[2].Value.ToString();
                        decimal productPrice = Convert.ToDecimal(row.Cells[3].Value);
                        decimal productQty = Convert.ToDecimal(row.Cells[4].Value);

                        Product product = new Product()
                        {
                            ProductName = productName,
                            ProductPrice = productPrice,
                            ProductQty = productQty,
                            CategoryId = categoryId
                        };

                        productLst.Add(product);
                    }

                }

                if (InsertProductsBySP(productLst))
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
