using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class FinacialYearSP : DBConnection
	{
		public FinacialYearSP()
		{
		}

		public bool CheckTransactionInBetweenTwoDates(DateTime dtFromdate, DateTime dtTodate)
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
					SqlCommand sqlCommand = new SqlCommand("CheckTransactionInBetweenTwoDates", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = dtFromdate;
					sqlParameter = sqlCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = dtTodate;
					flag = bool.Parse(sqlCommand.ExecuteScalar().ToString());
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

		public void FinacialYearAdd(FinacialYearInfo finacialyearinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("FinacialYearAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = finacialyearinfo.FromDate;
					sqlParameter = sqlCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = finacialyearinfo.ToDate;
					sqlParameter = sqlCommand.Parameters.Add("@activeOrNot", SqlDbType.Bit);
					sqlParameter.Value = finacialyearinfo.ActiveOrNot;
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

		public DataTable FinacialYearGetBetweenDate(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("FinacialYearGetBetweenDate", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public FinacialYearInfo FinacialYearView(string finacialYearId)
		{
			FinacialYearInfo finacialYearInfo = new FinacialYearInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("FinacialYearView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@finacialYearId", SqlDbType.VarChar).Value = finacialYearId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						finacialYearInfo.FinacialYearId = sqlDataReader[0].ToString();
						finacialYearInfo.FromDate = DateTime.Parse(sqlDataReader[1].ToString());
						finacialYearInfo.ToDate = DateTime.Parse(sqlDataReader[2].ToString());
						finacialYearInfo.ActiveOrNot = bool.Parse(sqlDataReader[3].ToString());
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
			return finacialYearInfo;
		}

		public DataTable FinacialYearViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("FinacialYearViewAll", DBConnection.sqlcon);
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

		public string FinacialYearViewByDate(DateTime fromDate, DateTime toDate)
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
					SqlCommand sqlCommand = new SqlCommand("FinacialYearViewByDate", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromDate;
					sqlParameter = sqlCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = toDate;
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

		public DataTable FinancialYearViewallActingYear()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("FinancialYearViewallActingYear", DBConnection.sqlcon);
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
        public void FinancialYearDelete(string finacialYearId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("FinancialYearDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@finacialYearId", SqlDbType.VarChar).Value = finacialYearId;
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