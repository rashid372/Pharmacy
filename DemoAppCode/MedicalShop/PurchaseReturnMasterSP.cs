using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PurchaseReturnMasterSP : DBConnection
	{
		public PurchaseReturnMasterSP()
		{
		}

		public DataTable PurchaseMasterForReturn()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseMasterForReturn", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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

		public void PurchaseReturnMasterAdd(PurchaseReturnMasterInfo purchasereturnmasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnMasterAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturnmasterinfo.PurchaseMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = purchasereturnmasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturnmasterinfo.Description;
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

		public void PurchaseReturnMasterEdit(PurchaseReturnMasterInfo purchasereturnmasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnMasterEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturnmasterinfo.PurchaseReturnMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturnmasterinfo.PurchaseMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = purchasereturnmasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturnmasterinfo.Description;
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

		public string PurchaseReturnMasterGetMax()
		{
			string str = "";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnMasterMax", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					str = sqlCommand.ExecuteScalar().ToString();
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
			return str;
		}

		public PurchaseReturnMasterInfo PurchaseReturnMasterView(string purchaseReturnMasterId)
		{
			PurchaseReturnMasterInfo purchaseReturnMasterInfo = new PurchaseReturnMasterInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnMasterView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar).Value = purchaseReturnMasterId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						purchaseReturnMasterInfo.PurchaseReturnMasterId = sqlDataReader[0].ToString();
						purchaseReturnMasterInfo.PurchaseMasterId = sqlDataReader[1].ToString();
						purchaseReturnMasterInfo.Date = DateTime.Parse(sqlDataReader[2].ToString());
						purchaseReturnMasterInfo.Description = sqlDataReader[3].ToString();
					}
					sqlDataReader.Close();
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
			return purchaseReturnMasterInfo;
		}

		public DataTable PurchaseReturnMasterViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnMasterViewAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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

		public DataTable PurchaseReturnMasterViewAllForRegisters(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnMasterViewAllForRegisters", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
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

		public DataTable PurchaseReturnRportForAll(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnRportForAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
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

		public DataTable PurchaseReturnRportForGenericName(DateTime fromdate, DateTime todate, string genericName)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnRportForGenericName", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@genericNameId", SqlDbType.VarChar).Value = genericName;
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

		public DataTable PurchaseReturnRportForInvoice(DateTime fromdate, DateTime todate, string invoiceNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnRportForInvoice", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@invoice", SqlDbType.VarChar).Value = invoiceNo;
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

		public DataTable PurchaseReturnRportForProdcutGroup(DateTime fromdate, DateTime todate, string prodcutGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnRportForProdcutGroup", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@prodcutGroupId", SqlDbType.VarChar).Value = prodcutGroupId;
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

		public DataTable PurchaseReturnRportForProduct(DateTime fromdate, DateTime todate, string ProductId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnRportForProduct", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@ProductId", SqlDbType.VarChar).Value = ProductId;
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

		public DataTable PurchaseReturnRportForVoucherNo(DateTime fromdate, DateTime todate, string voucherNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnRportForVoucherNo", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@voucherNo", SqlDbType.VarChar).Value = voucherNo;
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

        public void PurchaseReturnMasterDelete(string purchaseReturnMasterId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseReturnMasterDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar).Value = purchaseReturnMasterId;
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