using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MedicalShop
{
    internal class VendorProductsSP : DBConnection
    {
        public VendorProductsSP()
        {
        }
        public DataTable VendorProductViewAllByVendorId(string vendorId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("VendorProductViewAllByVendorId", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorId;
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            finally
            {
                DBConnection.sqlcon.Close();
            }
            return dataTable;
        }
        public DataTable VendorProductViewAllByProductName(string vendorId,string productName)
        {
            DataTable dataTable = new DataTable();
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("VendorProductViewAllByProductName", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorId;
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@productName", SqlDbType.VarChar);
                    sqlParameter.Value = productName;
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            finally
            {
                DBConnection.sqlcon.Close();
            }
            return dataTable;
        }
        public void VendorProductAdd(VendorProductsInfo vendorProductsInfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("VendorProductAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorProductsInfo.ProductId;
                    sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorProductsInfo.VendorId;
                    sqlParameter = sqlCommand.Parameters.Add("@purchaseRate", SqlDbType.Decimal);
                    sqlParameter.Value = vendorProductsInfo.PurchaseRate;
                    sqlParameter = sqlCommand.Parameters.Add("@createdBy", SqlDbType.VarChar);
                    sqlParameter.Value = vendorProductsInfo.CreateBy;

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            finally
            {
                DBConnection.sqlcon.Close();
            }
        }

        public void VendorProductEdit(VendorProductsInfo vendorProductsInfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("VendorProductEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorProductsInfo.ProductId;
                    sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorProductsInfo.VendorId;
                    sqlParameter = sqlCommand.Parameters.Add("@purchaseRate", SqlDbType.Decimal);
                    sqlParameter.Value = vendorProductsInfo.PurchaseRate;
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            finally
            {
                DBConnection.sqlcon.Close();
            }
        }

        public void VendorProductDelete(string vendorId,string productId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("VendorProductDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar).Value = vendorId;
                    sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = productId;
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            finally
            {
                DBConnection.sqlcon.Close();
            }
        }
    }
}
