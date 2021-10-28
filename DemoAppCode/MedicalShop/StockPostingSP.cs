using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class StockPostingSP : DBConnection
	{
		public StockPostingSP()
		{
		}

		public void StockPostingAdd(StockPostingInfo stockpostinginfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockPostingAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@inwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = stockpostinginfo.InwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@outwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = stockpostinginfo.OutwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = stockpostinginfo.Date;
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

		public void StockPostingDelete(string SerialNumber)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockPostingDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@serialNumber", SqlDbType.VarChar).Value = SerialNumber;
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

		public void StockPostingDeleteByVoucherAndType(string VoucherNumber, string VoucherType)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockPostingDeleteByVoucherAndType", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar).Value = VoucherNumber;
					sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar).Value = VoucherType;
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

		public void StockPostingEdit(StockPostingInfo stockpostinginfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockPostingEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@serialNumber", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.SerialNumber;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@inwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = stockpostinginfo.InwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@outwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = stockpostinginfo.OutwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = stockpostinginfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = stockpostinginfo.Date;
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

		public int StockPostingGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("StockPostingMax", DBConnection.sqlcon)
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

		public StockPostingInfo StockPostingView(string serialNumber)
		{
			StockPostingInfo stockPostingInfo = new StockPostingInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("StockPostingView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@serialNumber", SqlDbType.VarChar).Value = serialNumber;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						stockPostingInfo.SerialNumber = sqlDataReader[0].ToString();
						stockPostingInfo.VoucherNumber = sqlDataReader[1].ToString();
						stockPostingInfo.ProductBatchId = sqlDataReader[2].ToString();
						stockPostingInfo.InwardQuantity = decimal.Parse(sqlDataReader[3].ToString());
						stockPostingInfo.OutwardQuantity = decimal.Parse(sqlDataReader[4].ToString());
						stockPostingInfo.VoucherType = sqlDataReader[5].ToString();
						stockPostingInfo.Description = sqlDataReader[6].ToString();
						stockPostingInfo.Date = DateTime.Parse(sqlDataReader[7].ToString());
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
			return stockPostingInfo;
		}

		public DataTable StockPostingViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("StockPostingViewAll", DBConnection.sqlcon);
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