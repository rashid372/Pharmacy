using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PurchaseMasterSP : DBConnection
	{
		public PurchaseMasterSP()
		{
		}

		public bool CheckExistanceOfPurchaseInvoice(string strPurchaseInvoice)
		{
			bool flag;
			bool flag1 = false;
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseMasterCheckDuplicateInvoiceNo", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@invoiceNo", SqlDbType.VarChar).Value = strPurchaseInvoice;
					if (sqlCommand.ExecuteScalar() != null)
					{
						flag = true;
						return flag;
					}
					else
					{
						flag = false;
						return flag;
					}
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
			flag = flag1;
			return flag;
		}

		public void PurchaseMasterAdd(PurchaseMasterInfo purchasemasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseMasterAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = purchasemasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@dueDays", SqlDbType.Int);
					sqlParameter.Value = purchasemasterinfo.DueDays;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseInvoiceNo", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.PurchaseInvoiceNo;
					sqlParameter = sqlCommand.Parameters.Add("@billDiscount", SqlDbType.Decimal);
					sqlParameter.Value = purchasemasterinfo.BillDiscount;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@additionalCost", SqlDbType.Decimal);
					sqlParameter.Value = purchasemasterinfo.AdditionalCost;
					sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.VendorId;
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

		public void PurchaseMasterDelete(string PurchaseMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseMasterDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar).Value = PurchaseMasterId;
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

		public void PurchaseMasterEdit(PurchaseMasterInfo purchasemasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseMasterEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.PurchaseMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = purchasemasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@dueDays", SqlDbType.Int);
					sqlParameter.Value = purchasemasterinfo.DueDays;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseInvoiceNo", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.PurchaseInvoiceNo;
					sqlParameter = sqlCommand.Parameters.Add("@billDiscount", SqlDbType.Decimal);
					sqlParameter.Value = purchasemasterinfo.BillDiscount;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@additionalCost", SqlDbType.Decimal);
					sqlParameter.Value = purchasemasterinfo.AdditionalCost;
					sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
					sqlParameter.Value = purchasemasterinfo.VendorId;
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

		public int PurchaseMasterGetMax()
		{
			int num = 0;
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseMasterMax", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					num = int.Parse(sqlCommand.ExecuteScalar().ToString());
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
			return num;
		}

        public int PurchaseMasterInvoiceMax()
        {
            int num = 0;
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PurchaseMasterInvoiceMax", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    num = int.Parse(sqlCommand.ExecuteScalar().ToString());
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
            return num;
        }

        public PurchaseMasterInfo PurchaseMasterView(string purchaseMasterId)
		{
			PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseMasterView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar).Value = purchaseMasterId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						purchaseMasterInfo.PurchaseMasterId = sqlDataReader[0].ToString();
						purchaseMasterInfo.Date = DateTime.Parse(sqlDataReader[1].ToString());
						purchaseMasterInfo.LedgerId = sqlDataReader[2].ToString();
						purchaseMasterInfo.DueDays = int.Parse(sqlDataReader[3].ToString());
						purchaseMasterInfo.PurchaseInvoiceNo = sqlDataReader[4].ToString();
						purchaseMasterInfo.BillDiscount = decimal.Parse(sqlDataReader[5].ToString());
						purchaseMasterInfo.Description = sqlDataReader[6].ToString();
						purchaseMasterInfo.AdditionalCost = decimal.Parse(sqlDataReader[7].ToString());
						purchaseMasterInfo.VendorId = sqlDataReader[8].ToString();
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
			return purchaseMasterInfo;
		}

		public DataTable PurchaseMasterViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseMasterViewAll", DBConnection.sqlcon);
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

		public DataTable PurchaseMAsterViewAllForRegister(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseMasterViewAllByCondition", DBConnection.sqlcon);
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

		public DataTable PurchaseReportForAll(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
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

		public DataTable PurchaseReportForCashAccount(DateTime fromdate, DateTime todate, string ledgerId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForCashAccount", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar).Value = ledgerId;
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

		public DataTable PurchaseReportForGenericName(DateTime fromdate, DateTime todate, string genericId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForGenericName", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@genericNameId", SqlDbType.VarChar).Value = genericId;
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

		public DataTable PurchaseReportForInvoice(DateTime fromdate, DateTime todate, string invoiceNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForInvoice", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
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

		public DataTable PurchaseReportForProduct(DateTime fromdate, DateTime todate, string ProductId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForProduct", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = ProductId;
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

		public DataTable PurchaseReportForProductGroup(DateTime fromdate, DateTime todate, string productGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForProductGroup", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@productGroupId", SqlDbType.VarChar).Value = productGroupId;
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

		public DataTable PurchaseReportForVendors(DateTime fromdate, DateTime todate, string VendorId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForVendors", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@vendors", SqlDbType.VarChar).Value = VendorId;
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

		public DataTable PurchaseReportForVoucherNo(DateTime fromdate, DateTime todate, string voucherNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReportForVoucherNo", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
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

		public DataSet ZPrintingPurchaseReportForAll(string invoiceNo)
		{
			DataSet dataSet = new DataSet();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ZPrintingPurchaseReportForAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@voucherNo", SqlDbType.VarChar).Value = invoiceNo;
					sqlDataAdapter.Fill(dataSet);
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
			return dataSet;
		}

		internal DataSet ZPrintingPurchaseReportForAll(string strId, DateTime date, string invoice, string cashVendor)
		{
			DataSet dataSet = new DataSet();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ZPrintingPurchaseReportForAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@voucherNo", SqlDbType.VarChar).Value = strId;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = date;
					sqlDataAdapter.SelectCommand.Parameters.Add("@Invoice", SqlDbType.VarChar).Value = invoice;
					sqlDataAdapter.SelectCommand.Parameters.Add("@cashVendor", SqlDbType.VarChar).Value = cashVendor;
					sqlDataAdapter.Fill(dataSet);
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
			return dataSet;
		}
	}
}