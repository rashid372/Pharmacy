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
    internal class PuchaseOrderMasterSP : DBConnection
    {
        public PuchaseOrderMasterSP()
        {
        }
        public DataTable PuchaseOrderMasterViewByVendorIdDate(string vendorId,DateTime date)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseOrderMasterViewByVendorIdAndDate", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = vendorId;
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@date", SqlDbType.Date);
                    sqlParameter.Value = date;
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
        public void PuchaseOrderMasterAdd(PuchaseOrderMasterInfo puchaseOrderMasterInfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseOrderMasterAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = puchaseOrderMasterInfo.VendorId;
                    sqlParameter = sqlCommand.Parameters.Add("@receivingDate", SqlDbType.DateTime);
                    sqlParameter.Value = puchaseOrderMasterInfo.ReceivingDate;
                    sqlParameter = sqlCommand.Parameters.Add("@puchaseOrderTitle", SqlDbType.VarChar);
                    sqlParameter.Value = puchaseOrderMasterInfo.PuchaseOrderTitle;
                    sqlParameter = sqlCommand.Parameters.Add("@createdBy", SqlDbType.VarChar);
                    sqlParameter.Value = puchaseOrderMasterInfo.CreatedBy;

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
        public void PuchaseOrderMasterEdit(PuchaseOrderMasterInfo puchaseOrderMasterInfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseOrderMasterEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@purchaseOrderMasterId", SqlDbType.BigInt);
                    sqlParameter.Value = puchaseOrderMasterInfo.PurchaseOrderMasterId;
                    sqlParameter = sqlCommand.Parameters.Add("@receivingDate", SqlDbType.DateTime);
                    sqlParameter.Value = puchaseOrderMasterInfo.ReceivingDate;
                    sqlParameter = sqlCommand.Parameters.Add("@puchaseOrderTitle", SqlDbType.VarChar);
                    sqlParameter.Value = puchaseOrderMasterInfo.PuchaseOrderTitle;
                    sqlParameter = sqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                    sqlParameter.Value = puchaseOrderMasterInfo.Status;

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

        public void PuchaseOrderMasterDelete(long purchaseOrderMasterId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseOrderMasterDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@purchaseOrderMasterId", SqlDbType.BigInt).Value = purchaseOrderMasterId;
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
