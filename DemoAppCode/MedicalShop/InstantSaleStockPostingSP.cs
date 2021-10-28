using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class InstantSaleStockPostingSP : DBConnection
	{
		public InstantSaleStockPostingSP()
		{
		}

		public void InstantSaleStockPostingAdd(InstantSaleStockPostingInfo instantsalestockpostinginfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("InstantSaleStockPostingAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@instantStockPostingId", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.InstantStockPostingId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@inwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = instantsalestockpostinginfo.InwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@outwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = instantsalestockpostinginfo.OutwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = instantsalestockpostinginfo.Date;
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

		public void InstantSaleStockPostingDelete(string InstantStockPostingId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("InstantSaleStockPostingDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@instantStockPostingId", SqlDbType.VarChar).Value = InstantStockPostingId;
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

		public void InstantSaleStockPostingEdit(InstantSaleStockPostingInfo instantsalestockpostinginfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("InstantSaleStockPostingEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@instantStockPostingId", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.InstantStockPostingId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@inwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = instantsalestockpostinginfo.InwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@outwardQuantity", SqlDbType.Decimal);
					sqlParameter.Value = instantsalestockpostinginfo.OutwardQuantity;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = instantsalestockpostinginfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = instantsalestockpostinginfo.Date;
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

		public int InstantSaleStockPostingGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("InstantSaleStockPostingMax", DBConnection.sqlcon)
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

		public InstantSaleStockPostingInfo InstantSaleStockPostingView(string instantStockPostingId)
		{
			InstantSaleStockPostingInfo instantSaleStockPostingInfo = new InstantSaleStockPostingInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("InstantSaleStockPostingView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@instantStockPostingId", SqlDbType.VarChar).Value = instantStockPostingId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						instantSaleStockPostingInfo.InstantStockPostingId = sqlDataReader[0].ToString();
						instantSaleStockPostingInfo.VoucherNumber = sqlDataReader[1].ToString();
						instantSaleStockPostingInfo.ProductBatchId = sqlDataReader[2].ToString();
						instantSaleStockPostingInfo.InwardQuantity = decimal.Parse(sqlDataReader[3].ToString());
						instantSaleStockPostingInfo.OutwardQuantity = decimal.Parse(sqlDataReader[4].ToString());
						instantSaleStockPostingInfo.VoucherType = sqlDataReader[5].ToString();
						instantSaleStockPostingInfo.Description = sqlDataReader[6].ToString();
						instantSaleStockPostingInfo.Date = DateTime.Parse(sqlDataReader[7].ToString());
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
			return instantSaleStockPostingInfo;
		}

		public DataTable InstantSaleStockPostingViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("InstantSaleStockPostingViewAll", DBConnection.sqlcon);
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