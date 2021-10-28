using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class GreetingTextSP : DBConnection
	{
		public GreetingTextSP()
		{
		}

		public void GreetingTextAdd(GreetingTextInfo greetingtextinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("GreetingTextAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = greetingtextinfo.FromDate;
					sqlParameter = sqlCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = greetingtextinfo.ToDate;
					sqlParameter = sqlCommand.Parameters.Add("@greetingMessage", SqlDbType.VarChar);
					sqlParameter.Value = greetingtextinfo.GreetingMessage;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = greetingtextinfo.Description;
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

		public void GreetingTextEdit(GreetingTextInfo greetingtextinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("GreetingTextEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@greetingTextId", SqlDbType.VarChar);
					sqlParameter.Value = greetingtextinfo.GreetingTextId;
					sqlParameter = sqlCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = greetingtextinfo.FromDate;
					sqlParameter = sqlCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = greetingtextinfo.ToDate;
					sqlParameter = sqlCommand.Parameters.Add("@greetingMessage", SqlDbType.VarChar);
					sqlParameter.Value = greetingtextinfo.GreetingMessage;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = greetingtextinfo.Description;
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

		public GreetingTextInfo GreetingTextView(string greetingTextId)
		{
			GreetingTextInfo greetingTextInfo = new GreetingTextInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("GreetingTextView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@greetingTextId", SqlDbType.VarChar).Value = greetingTextId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						greetingTextInfo.GreetingTextId = sqlDataReader[0].ToString();
						greetingTextInfo.FromDate = DateTime.Parse(sqlDataReader[1].ToString());
						greetingTextInfo.ToDate = DateTime.Parse(sqlDataReader[2].ToString());
						greetingTextInfo.GreetingMessage = sqlDataReader[3].ToString();
						greetingTextInfo.Description = sqlDataReader[4].ToString();
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
			return greetingTextInfo;
		}

		public DataTable GreetingTextViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GreetingTextViewAll", DBConnection.sqlcon);
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

		internal DataTable GreetingTextViewBetweenDate(DateTime dateTime)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GreetingTextViewByDate", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = dateTime;
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
        public void GreetingTextDelete(string greetingTextId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("GreetingTextDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@greetingTextId", SqlDbType.VarChar).Value = greetingTextId;
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