using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class JournalDetailsSP : DBConnection
	{
		public JournalDetailsSP()
		{
		}

		public void JournalDetailsAdd(JournalDetailsInfo journaldetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("JournalDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@journalMasterId", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.JournalMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@debit", SqlDbType.Decimal);
					sqlParameter.Value = journaldetailsinfo.Debit;
					sqlParameter = sqlCommand.Parameters.Add("@credit", SqlDbType.Decimal);
					sqlParameter.Value = journaldetailsinfo.Credit;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.Description;
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

		public void JournalDetailsDelete(string JournalDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("JournalDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@journalDetailsId", SqlDbType.VarChar).Value = JournalDetailsId;
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

		public void journalDetailsDeleteByMasterId(string JournalMaserId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("JournalDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@journalMasterId", SqlDbType.VarChar).Value = JournalMaserId;
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

		public void JournalDetailsEdit(JournalDetailsInfo journaldetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("JournalDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@journalDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.JournalDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@journalMasterId", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.JournalMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@debit", SqlDbType.Decimal);
					sqlParameter.Value = journaldetailsinfo.Debit;
					sqlParameter = sqlCommand.Parameters.Add("@credit", SqlDbType.Decimal);
					sqlParameter.Value = journaldetailsinfo.Credit;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = journaldetailsinfo.Description;
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

		public int JournalDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("JournalDetailsMax", DBConnection.sqlcon)
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

		public JournalDetailsInfo JournalDetailsView(string journalDetailsId)
		{
			JournalDetailsInfo journalDetailsInfo = new JournalDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("JournalDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@journalDetailsId", SqlDbType.VarChar).Value = journalDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						journalDetailsInfo.JournalDetailsId = sqlDataReader[0].ToString();
						journalDetailsInfo.JournalMasterId = sqlDataReader[1].ToString();
						journalDetailsInfo.LedgerId = sqlDataReader[2].ToString();
						journalDetailsInfo.Debit = decimal.Parse(sqlDataReader[3].ToString());
						journalDetailsInfo.Credit = decimal.Parse(sqlDataReader[4].ToString());
						journalDetailsInfo.Description = sqlDataReader[5].ToString();
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
			return journalDetailsInfo;
		}

		public DataTable JournalDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("JournalDetailsViewAll", DBConnection.sqlcon);
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

		public DataTable JournalDetailsViewAllByMasterId(string strMasterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("JournalDetailsViewAllByMasterId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@journalMasterId", SqlDbType.VarChar);
					sqlParameter.Value = strMasterId;
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