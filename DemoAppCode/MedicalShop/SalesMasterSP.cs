using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class SalesMasterSP : DBConnection
	{
		public SalesMasterSP()
		{
		}
    

        public bool CheckExistanceOfSalesInvoice(string strPurchaseInvoice)
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
					SqlCommand sqlCommand = new SqlCommand("SalesMasterCheckDuplicateInvoiceNo", DBConnection.sqlcon)
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

		public void SalesMasterAdd(SalesMasterInfo salesmasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesMasterAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@salesInvoiceNo", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.SalesInvoiceNo;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = salesmasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@doctorId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.DoctorId;
					sqlParameter = sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.SalesManId;
					sqlParameter = sqlCommand.Parameters.Add("@patientId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.PatientId;
					sqlParameter = sqlCommand.Parameters.Add("@billDiscount", SqlDbType.Decimal);
					sqlParameter.Value = salesmasterinfo.BillDiscount;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.Description;
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

		public void SalesMasterDelete(string SalesMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesMasterDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar).Value = SalesMasterId;
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

		public void SalesMasterEdit(SalesMasterInfo salesmasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesMasterEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.SalesMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@salesInvoiceNo", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.SalesInvoiceNo;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = salesmasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@doctorId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.DoctorId;
					sqlParameter = sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.SalesManId;
					sqlParameter = sqlCommand.Parameters.Add("@patientId", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.PatientId;
					sqlParameter = sqlCommand.Parameters.Add("@billDiscount", SqlDbType.Decimal);
					sqlParameter.Value = salesmasterinfo.BillDiscount;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = salesmasterinfo.Description;
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

		public DataTable SalesMasterForReturn()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesMasterForReturn", DBConnection.sqlcon);
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


        public string SalesMasterGetInnoiceMax()
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
                    SqlCommand sqlCommand = new SqlCommand("SalesMasterInvoiceMax", DBConnection.sqlcon)
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

        public string SalesMasterGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("SalesMasterMax", DBConnection.sqlcon)
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

		public SalesMasterInfo SalesMasterView(string salesMasterId)
		{
			SalesMasterInfo salesMasterInfo = new SalesMasterInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesMasterView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar).Value = salesMasterId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						salesMasterInfo.SalesMasterId = sqlDataReader[0].ToString();
						salesMasterInfo.SalesInvoiceNo = sqlDataReader[1].ToString();
						salesMasterInfo.Date = DateTime.Parse(sqlDataReader[2].ToString());
						salesMasterInfo.LedgerId = sqlDataReader[3].ToString();
						salesMasterInfo.DoctorId = sqlDataReader[4].ToString();
						salesMasterInfo.SalesManId = sqlDataReader[5].ToString();
						salesMasterInfo.PatientId = sqlDataReader[6].ToString();
						salesMasterInfo.BillDiscount = decimal.Parse(sqlDataReader[7].ToString());
						salesMasterInfo.Description = sqlDataReader[8].ToString();
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
			return salesMasterInfo;
		}

		public DataTable SalesMasterViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesMasterViewAll", DBConnection.sqlcon);
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

		public DataTable SalesMasterViewAllForRegister(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesMasterViewAllForRegister", DBConnection.sqlcon);
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

        public DataTable SalesMasterViewAllForRegisterbyPatient(DateTime fromdate, DateTime todate,string patientId)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesMasterViewAllForRegisterbyPatient", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromdate;
                    sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime).Value = todate;
                    sqlDataAdapter.SelectCommand.Parameters.Add("@patientId", SqlDbType.VarChar).Value = patientId;
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

        public DataTable SalesReportForAll(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForAll", DBConnection.sqlcon);
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

		public DataTable SalesReportForCashAccount(DateTime fromdate, DateTime todate, string ledgerId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForCashAccount", DBConnection.sqlcon);
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

		public DataTable SalesReportForDoctor(DateTime fromdate, DateTime todate, string doctorId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForDoctor", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@doctorId", SqlDbType.VarChar).Value = doctorId;
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

		public DataTable SalesReportForGenericName(DateTime fromdate, DateTime todate, string genericId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForGenericName", DBConnection.sqlcon);
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

		public DataTable SalesReportForInvoice(DateTime fromdate, DateTime todate, string invoiceNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForInvoice", DBConnection.sqlcon);
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

		public DataTable SalesReportForPatient(DateTime fromdate, DateTime todate, string doctorId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForPatient", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@patientId", SqlDbType.VarChar).Value = doctorId;
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

		public DataTable SalesReportForProduct(DateTime fromdate, DateTime todate, string ProductId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForProduct", DBConnection.sqlcon);
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

		public DataTable SalesReportForProductGroup(DateTime fromdate, DateTime todate, string productGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForProductGroup", DBConnection.sqlcon);
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

		public DataTable SalesReportForSalesMan(DateTime fromdate, DateTime todate, string salesManId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForSalesMan", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
					sqlDataAdapter.SelectCommand.Parameters.Add("@SalesMan", SqlDbType.VarChar).Value = salesManId;
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

		public DataTable SalesReportForVoucherNo(DateTime fromdate, DateTime todate, string voucherNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReportForVoucherNo", DBConnection.sqlcon);
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

		public DataSet ZPrintingSaleReportForAll(string invoiceNo, DateTime date)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ZPrintingSaleReportForAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@voucherNo", SqlDbType.VarChar).Value = invoiceNo;
					sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = date;
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