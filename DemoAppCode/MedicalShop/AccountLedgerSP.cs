using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class AccountLedgerSP : DBConnection
	{
		public AccountLedgerSP()
		{
		}

		public DataTable AccountGroupViewAllUnderBank()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountGroupViewAllUnderBank", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
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

		public DataTable AccountGroupViewAllUnderCash()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountGroupViewAllUnderCash", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
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

		public bool AccountLedgerCheckExistanceOfIdInSalesManAndVendor(string strLedgerId)
		{
			bool flag = false;
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("AccountLedgerCheckExistanceOfIdInSalesManAndVendor", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar).Value = strLedgerId;
					flag = (!(sqlCommand.ExecuteScalar().ToString() == "Y") ? false : true);
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
			return flag;
		}

		public bool AccountLedgerCheckExistanceOfName(string strAccountLedgerName)
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
					SqlCommand sqlCommand = new SqlCommand("AccountLedgerCheckExistanceOfName", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@acccountLedgerName", SqlDbType.VarChar).Value = strAccountLedgerName;
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

		internal string AccountLedgerCheckName(string p)
		{
			string str = "false";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("AccountLedgerCheckName", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@acccountLedgerName", SqlDbType.VarChar).Value = p;
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

		internal void AccountLedgerEditBySalesManName(MedicalShop.AccountLedgerInfo AccountLedgerInfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("AccountLedgerEditBySalesManName", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@acccountLedgerName", SqlDbType.VarChar);
					sqlParameter.Value = AccountLedgerInfo.AcccountLedgerName;
					sqlParameter = sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
					sqlParameter.Value = AccountLedgerInfo.AccountGroupId;
					sqlParameter = sqlCommand.Parameters.Add("@openingBalance", SqlDbType.Decimal);
					sqlParameter.Value = AccountLedgerInfo.OpeningBalance;
					sqlParameter = sqlCommand.Parameters.Add("@debitOrCredit", SqlDbType.Bit);
					sqlParameter.Value = AccountLedgerInfo.DebitOrCredit;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = AccountLedgerInfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
					sqlParameter.Value = AccountLedgerInfo.DefaultOrNot;
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

		public int AccountLedgerGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("AccountLedgerMax", DBConnection.sqlcon)
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

		public AccountLedgerInfo AccountLedgerView(string ledgerId)
		{
			AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("AccountLedgerView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar).Value = ledgerId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						accountLedgerInfo.LedgerId = sqlDataReader[0].ToString();
						accountLedgerInfo.AcccountLedgerName = sqlDataReader[1].ToString();
						accountLedgerInfo.AccountGroupId = sqlDataReader[2].ToString();
						accountLedgerInfo.OpeningBalance = decimal.Parse(sqlDataReader[3].ToString());
						accountLedgerInfo.DebitOrCredit = bool.Parse(sqlDataReader[4].ToString());
						accountLedgerInfo.Description = sqlDataReader[5].ToString();
						accountLedgerInfo.DefaultOrNot = bool.Parse(sqlDataReader[6].ToString());
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
			return accountLedgerInfo;
		}

		public DataTable AccountLedgerViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewAll", DBConnection.sqlcon);
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

		public DataTable AccountLedgerViewAllByAccountGroupId(string strAccountGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewAllByAccountGroupId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
					sqlParameter.Value = strAccountGroupId;
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

		public DataTable AccountLedgerViewAllByAccountGroupIdAndStatus(string strAccountGroupId, bool isInbuilt)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewAllByAccountGroupIdAndStatus", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
					sqlParameter.Value = strAccountGroupId;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@defaultOrNot", SqlDbType.VarChar);
					sqlParameter.Value = isInbuilt;
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

		public DataTable AccountLedgerViewAllByStatus(bool isInbuilt)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewAllByStatus", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
					sqlParameter.Value = isInbuilt;
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

		public DataTable AccountLedgerViewAllExcepBankOrCash(bool cash)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewAllExcepBankOrCash", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@cash", SqlDbType.Bit);
					sqlParameter.Value = cash;
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

		public DataTable AccountLedgerViewUnderBank()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewUnderBank", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
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

		public DataTable AccountLedgerViewUnderCash()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewUnderCash", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
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

		public DataTable AccountLedgerViewUnderSundryDebtorCreditorCash()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountLedgerViewUnderSundryDebtorCreditorCash", DBConnection.sqlcon);
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

		public DataSet BalanceSheet(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("BalanceSheet", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataTable BankBook(DateTime fromdate, DateTime todate, bool isGroup)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("BankBook", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@isGroup", SqlDbType.Bit);
					sqlParameter.Value = isGroup;
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

        public DataTable DailyIncomeExpense(DateTime date)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DailyIncomeExpense", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime);
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

        public DataTable DailyIncomeExpenseView(DateTime date)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DailyIncomeExpenseView", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime);
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

        public DataTable MonthlyIncomeExpenseView(DateTime date)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("MonthlyIncomeExpenseView", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime);
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

        public DataTable stockByManufacturePriceAndLedger(string ledgerid)
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("stockByManufacturePriceAndLedger", DBConnection.sqlcon);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@ledgerid", SqlDbType.VarChar);
                    sqlParameter.Value = ledgerid;
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


        public DataTable stockByManufactureAndPrice()
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("stockByManufactureAndPrice", DBConnection.sqlcon);
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

        public DataTable CashBook(DateTime fromdate, DateTime todate, bool isGroup)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CashBook", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@isGroup", SqlDbType.Bit);
					sqlParameter.Value = isGroup;
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


		public DataTable CheckGroupIdUnderCash(string strGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CheckGroupIdUnderCash", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@groupid", SqlDbType.VarChar);
					sqlParameter.Value = strGroupId;
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

		public DataTable Daybook(DateTime date)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Daybook", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime);
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

		public DataSet DetailedBalanceSheet(DateTime fromdate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DetailedBalanceSheet", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
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

		public DataSet DetailedBalanceSheet(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DetailedBalanceSheet", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataSet DetailedProfitAndLossAnalysis(DateTime fromdate, DateTime todate, bool isContensed)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DetailedProfitAndLossAnalysis", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataTable LedgerOrGroupBalance(DateTime fromdate, DateTime todate, string strLedgerOrGroupId, bool isGroup)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("LedgerOrGroupBalance", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@ledgerOrGroupId", SqlDbType.VarChar);
					sqlParameter.Value = strLedgerOrGroupId;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@isGroupWise", SqlDbType.Bit);
					sqlParameter.Value = isGroup;
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

		public DataSet NetProfitAndLoss(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("NetProfitAndLoss", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataSet ProfitAndLossAnalysis(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProfitAndLossAnalysis", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataSet ProfitAndLossAnalysisUpToaDate(DateTime fromdate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProfitAndLossAnalysisUpToaDate", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
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

		public DataTable TrialBalance(DateTime fromdate, DateTime todate, bool isGroup)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("TrialBalance", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@isGroup", SqlDbType.Bit);
					sqlParameter.Value = isGroup;
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

        public void AccountLedgerAdd(AccountLedgerInfo  acountledgerinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("AccountLedgerAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.LedgerId;
                    sqlParameter = sqlCommand.Parameters.Add("@acccountLedgerName", SqlDbType.VarChar);
                    sqlParameter.Value =acountledgerinfo.AcccountLedgerName;
                    sqlParameter = sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.AccountGroupId;
                    sqlParameter = sqlCommand.Parameters.Add("@openingBalance", SqlDbType.Decimal);
                    sqlParameter.Value = acountledgerinfo.OpeningBalance;
                    sqlParameter = sqlCommand.Parameters.Add("@debitOrCredit", SqlDbType.Bit);
                    sqlParameter.Value =acountledgerinfo.DebitOrCredit;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
                    sqlParameter.Value = acountledgerinfo.DefaultOrNot;

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

        public void AccountLedgerEdit(AccountLedgerInfo  acountledgerinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("AccountLedgerEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.LedgerId;
                    sqlParameter = sqlCommand.Parameters.Add("@acccountLedgerName", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.AcccountLedgerName;
                    sqlParameter = sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.AccountGroupId;
                    sqlParameter = sqlCommand.Parameters.Add("@openingBalance", SqlDbType.Decimal);
                    sqlParameter.Value = acountledgerinfo.OpeningBalance;
                    sqlParameter = sqlCommand.Parameters.Add("@debitOrCredit", SqlDbType.Bit);
                    sqlParameter.Value = acountledgerinfo.DebitOrCredit;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = acountledgerinfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
                    sqlParameter.Value = acountledgerinfo.DefaultOrNot;
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

        public void AccountLedgerDelete(string ledgerId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("AccountLedgerDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar).Value = ledgerId;
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