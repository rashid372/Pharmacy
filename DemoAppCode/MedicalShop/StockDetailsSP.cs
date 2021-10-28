using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class StockDetailsSP : DBConnection
	{
		public StockDetailsSP()
		{
		}

		public void StockDetailsAdd(StockDetailsInfo stockdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@stockMasterId", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.StockMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = stockdetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = stockdetailsinfo.Rate;
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

		public void StockDetailsDelete(string StockDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@stockDetailsId", SqlDbType.VarChar).Value = StockDetailsId;
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

		public void StockDetailsDeleteByMasterId(string StockMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@stockMasterId", SqlDbType.VarChar).Value = StockMasterId;
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

		public void StockDetailsEdit(StockDetailsInfo stockdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@stockDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.StockDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@stockMasterId", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.StockMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = stockdetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = stockdetailsinfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = stockdetailsinfo.Rate;
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

		public int StockDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("StockDetailsMax", DBConnection.sqlcon)
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

		public StockDetailsInfo StockDetailsView(string stockDetailsId)
		{
			StockDetailsInfo stockDetailsInfo = new StockDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@stockDetailsId", SqlDbType.VarChar).Value = stockDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						stockDetailsInfo.StockDetailsId = sqlDataReader[0].ToString();
						stockDetailsInfo.StockMasterId = sqlDataReader[1].ToString();
						stockDetailsInfo.ProductBatchId = sqlDataReader[2].ToString();
						stockDetailsInfo.Qty = decimal.Parse(sqlDataReader[3].ToString());
						stockDetailsInfo.Description = sqlDataReader[4].ToString();
						stockDetailsInfo.Rate = decimal.Parse(sqlDataReader[5].ToString());
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
			return stockDetailsInfo;
		}

		public DataTable StockDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("StockDetailsViewAll", DBConnection.sqlcon);
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
	}
}