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
    internal class PuchaseOrderDetailsSP : DBConnection
    {
        public PuchaseOrderDetailsSP()
        {
        }
        public DataTable PurchaseOrderDetailsViewAllByVendorId(string vendorId)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseOrderDetailsViewAllByVendorId", DBConnection.sqlcon);
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
        public DataTable VendorProductViewAllByProductName(string vendorId, string productName)
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
        public void PurchaseOrderDetailsAdd(PurchaseOrderDetailsInfo purchaseOrderDetailsInfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseOrderDetailAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@purchaseOrderMasterId", SqlDbType.BigInt);
                    sqlParameter.Value = purchaseOrderDetailsInfo.PurchaseOrderMasterId;
                    sqlParameter = sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar);
                    sqlParameter.Value = purchaseOrderDetailsInfo.ProductId;
                    sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
                    sqlParameter.Value = purchaseOrderDetailsInfo.Rate;
                    sqlParameter = sqlCommand.Parameters.Add("@discount", SqlDbType.Float);
                    sqlParameter.Value = purchaseOrderDetailsInfo.Discount;
                    sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
                    sqlParameter.Value = purchaseOrderDetailsInfo.Qty;
                    sqlParameter = sqlCommand.Parameters.Add("@freeQty", SqlDbType.Decimal);
                    sqlParameter.Value = purchaseOrderDetailsInfo.FreeQty;

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
        public void PurchaseOrderDetailsEdit(PurchaseOrderDetailsInfo purchaseOrderDetailsInfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseOrderDetailEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@purchaseOrderDetailsId", SqlDbType.BigInt);
                    sqlParameter.Value = purchaseOrderDetailsInfo.PurchaseOrderDetailsId;
                    sqlParameter = sqlCommand.Parameters.Add("@purchaseOrderMasterId", SqlDbType.BigInt);
                    sqlParameter.Value = purchaseOrderDetailsInfo.PurchaseOrderMasterId;
                    sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
                    sqlParameter.Value = purchaseOrderDetailsInfo.Rate;
                    sqlParameter = sqlCommand.Parameters.Add("@discount", SqlDbType.Float);
                    sqlParameter.Value = purchaseOrderDetailsInfo.Discount;
                    sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
                    sqlParameter.Value = purchaseOrderDetailsInfo.Qty;
                    sqlParameter = sqlCommand.Parameters.Add("@freeQty", SqlDbType.Decimal);
                    sqlParameter.Value = purchaseOrderDetailsInfo.FreeQty;

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

        public void PurchaseOrderDetailsDelete(long purchaseOrderDetailsId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseOrderDetailDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@purchaseOrderDetailsId", SqlDbType.BigInt).Value = purchaseOrderDetailsId;
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
