using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class LedgerPostingSP : DBConnection
	{
		public LedgerPostingSP()
		{
		}

		public void LedgerPostingAdd(LedgerPostingInfo ledgerpostinginfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@debit", SqlDbType.Decimal);
					sqlParameter.Value = ledgerpostinginfo.Debit;
					sqlParameter = sqlCommand.Parameters.Add("@credit", SqlDbType.Decimal);
					sqlParameter.Value = ledgerpostinginfo.Credit;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = ledgerpostinginfo.Date;
					sqlCommand.ExecuteScalar();
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

		public bool LedgerPostingCheckExistanceOfLedgerId(string strLedgerId)
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
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingCheckExistanceOfLedgerId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar).Value = strLedgerId;
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

		public void LedgerPostingDelete(string LedgerPostingId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@ledgerPostingId", SqlDbType.VarChar).Value = LedgerPostingId;
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

		public void LedgerPostingDeleteByVoucherTypeAndVoucherNo(string vocuherNumber, string voucherType)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingDeleteByVoucherTypeAndVoucherNo", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar).Value = vocuherNumber;
					sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar).Value = voucherType;
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

		public void LedgerPostingEdit(LedgerPostingInfo ledgerpostinginfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@ledgerPostingId", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.LedgerPostingId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@debit", SqlDbType.Decimal);
					sqlParameter.Value = ledgerpostinginfo.Debit;
					sqlParameter = sqlCommand.Parameters.Add("@credit", SqlDbType.Decimal);
					sqlParameter.Value = ledgerpostinginfo.Credit;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = ledgerpostinginfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = ledgerpostinginfo.Date;
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

		public DataTable LedgerPostingGetCurerntBalanceOfLedger(string strLedgerId, DateTime date)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("LedgerPostingGetCurerntBalanceOfLedger", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@LedgerId", SqlDbType.VarChar);
					sqlParameter.Value = strLedgerId;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@postingDate", SqlDbType.DateTime);
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

		public int LedgerPostingGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingMax", DBConnection.sqlcon)
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

		public LedgerPostingInfo LedgerPostingView(string ledgerPostingId)
		{
			LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("LedgerPostingView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@ledgerPostingId", SqlDbType.VarChar).Value = ledgerPostingId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						ledgerPostingInfo.LedgerPostingId = sqlDataReader[0].ToString();
						ledgerPostingInfo.VoucherNumber = sqlDataReader[1].ToString();
						ledgerPostingInfo.LedgerId = sqlDataReader[2].ToString();
						ledgerPostingInfo.VoucherType = sqlDataReader[3].ToString();
						ledgerPostingInfo.Debit = decimal.Parse(sqlDataReader[4].ToString());
						ledgerPostingInfo.Credit = decimal.Parse(sqlDataReader[5].ToString());
						ledgerPostingInfo.Description = sqlDataReader[6].ToString();
						ledgerPostingInfo.Date = DateTime.Parse(sqlDataReader[7].ToString());
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
			return ledgerPostingInfo;
		}

		public DataTable LedgerPostingViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("LedgerPostingViewAll", DBConnection.sqlcon);
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

		public DataTable LedgerPostingViewByVoucherTypeAndVoucherNumber(string strVocuherNo, string strVoucherType)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("LedgerPostingViewByVoucherTypeAndVoucherNumber", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = strVocuherNo;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = strVoucherType;
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