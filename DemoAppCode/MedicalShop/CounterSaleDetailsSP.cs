using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class CounterSaleDetailsSP : DBConnection
	{
		public CounterSaleDetailsSP()
		{
		}

		public void CounterSaleDetailsAdd(CounterSaleDetailsInfo countersaledetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CounterSaleDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@counterSaleMasterId", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.CounterSaleMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productbatchId", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.ProductbatchId;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = countersaledetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = countersaledetailsinfo.Rate;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.Description;
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

		public void CounterSaleDetailsDelete(string CounterSaleDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CounterSaleDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@counterSaleDetailsId", SqlDbType.VarChar).Value = CounterSaleDetailsId;
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

		public void CounterSaleDetailsDeleteByMasterId(string CounterSaleMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CounterSaleDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@counterSaleMasterId", SqlDbType.VarChar).Value = CounterSaleMasterId;
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

		public void CounterSaleDetailsEdit(CounterSaleDetailsInfo countersaledetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CounterSaleDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@counterSaleDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.CounterSaleDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@counterSaleMasterId", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.CounterSaleMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productbatchId", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.ProductbatchId;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = countersaledetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = countersaledetailsinfo.Rate;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = countersaledetailsinfo.Description;
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

		public int CounterSaleDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("CounterSaleDetailsMax", DBConnection.sqlcon)
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

		public CounterSaleDetailsInfo CounterSaleDetailsView(string counterSaleDetailsId)
		{
			CounterSaleDetailsInfo counterSaleDetailsInfo = new CounterSaleDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CounterSaleDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@counterSaleDetailsId", SqlDbType.VarChar).Value = counterSaleDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						counterSaleDetailsInfo.CounterSaleDetailsId = sqlDataReader[0].ToString();
						counterSaleDetailsInfo.CounterSaleMasterId = sqlDataReader[1].ToString();
						counterSaleDetailsInfo.ProductbatchId = sqlDataReader[2].ToString();
						counterSaleDetailsInfo.Qty = decimal.Parse(sqlDataReader[3].ToString());
						counterSaleDetailsInfo.Rate = decimal.Parse(sqlDataReader[4].ToString());
						counterSaleDetailsInfo.Description = sqlDataReader[5].ToString();
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
			return counterSaleDetailsInfo;
		}

		public DataTable CounterSaleDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CounterSaleDetailsViewAll", DBConnection.sqlcon);
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

		public DataTable CounterSaleDetailsViewAllByMasterId(string masterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CounterSaleDetailsViewAllByMasterId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@counterSaleMasterId", SqlDbType.VarChar).Value = masterId;
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