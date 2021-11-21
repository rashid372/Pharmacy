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
    internal class PurchaseOrderSP : DBConnection
    {
        public PurchaseOrderSP()
        {
        }
        public DataTable PurchaseOrderViewAllByVendorId(string vendorId)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseOrderViewAllByVendorId", DBConnection.sqlcon);
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
    }
}
