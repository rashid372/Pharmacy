using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class SalesDetailsSP : DBConnection
	{
		public SalesDetailsSP()
		{
		}

		public void SalesDetailsAdd(SalesDetailsInfo salesdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.SalesMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.Rate;
					sqlParameter = sqlCommand.Parameters.Add("@MRP", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.MRP;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@freeQty", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.FreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@discount", SqlDbType.Float);
					sqlParameter.Value = salesdetailsinfo.Discount;
					sqlParameter = sqlCommand.Parameters.Add("@directSaleOrNot", SqlDbType.Bit);
					sqlParameter.Value = salesdetailsinfo.DirectSaleOrNot;
					sqlParameter = sqlCommand.Parameters.Add("@taxIncludedOrNot", SqlDbType.Bit);
					sqlParameter.Value = salesdetailsinfo.TaxIncludedOrNot;
					sqlParameter = sqlCommand.Parameters.Add("@taxPercentage", SqlDbType.Float);
					sqlParameter.Value = salesdetailsinfo.TaxPercentage;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.Description;
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

		public bool SalesDetailsCheckOnDelete(string strsalesDetailsId)
		{
			bool flag = true;
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsCheckOnDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesDetailsId", SqlDbType.VarChar).Value = strsalesDetailsId;
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

		public void SalesDetailsDelete(string SalesDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesDetailsId", SqlDbType.VarChar).Value = SalesDetailsId;
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

		public void SalesDetailsDeleteByMasterId(string SalesMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsDeleteByMasterId", DBConnection.sqlcon)
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

		public void SalesDetailsEdit(SalesDetailsInfo salesdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@salesDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.SalesDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.SalesMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.Rate;
					sqlParameter = sqlCommand.Parameters.Add("@MRP", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.MRP;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@freeQty", SqlDbType.Decimal);
					sqlParameter.Value = salesdetailsinfo.FreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@discount", SqlDbType.Float);
					sqlParameter.Value = salesdetailsinfo.Discount;
					sqlParameter = sqlCommand.Parameters.Add("@directSaleOrNot", SqlDbType.Bit);
					sqlParameter.Value = salesdetailsinfo.DirectSaleOrNot;
					sqlParameter = sqlCommand.Parameters.Add("@taxIncludedOrNot", SqlDbType.Bit);
					sqlParameter.Value = salesdetailsinfo.TaxIncludedOrNot;
					sqlParameter = sqlCommand.Parameters.Add("@taxPercentage", SqlDbType.Float);
					sqlParameter.Value = salesdetailsinfo.TaxPercentage;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = salesdetailsinfo.Description;
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

		public int SalesDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsMax", DBConnection.sqlcon)
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

		public DataTable SalesDetailsPendingForReturn(string masterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesDetailsPendingForReturn", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar).Value = masterId;
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

		public SalesDetailsInfo SalesDetailsView(string salesDetailsId)
		{
			SalesDetailsInfo salesDetailsInfo = new SalesDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesDetailsId", SqlDbType.VarChar).Value = salesDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						salesDetailsInfo.SalesDetailsId = sqlDataReader[0].ToString();
						salesDetailsInfo.SalesMasterId = sqlDataReader[1].ToString();
						salesDetailsInfo.ProductBatchId = sqlDataReader[2].ToString();
						salesDetailsInfo.Rate = decimal.Parse(sqlDataReader[3].ToString());
						salesDetailsInfo.MRP = decimal.Parse(sqlDataReader[4].ToString());
						salesDetailsInfo.Qty = decimal.Parse(sqlDataReader[5].ToString());
						salesDetailsInfo.FreeQty = decimal.Parse(sqlDataReader[6].ToString());
						salesDetailsInfo.Discount = float.Parse(sqlDataReader[7].ToString());
						salesDetailsInfo.DirectSaleOrNot = bool.Parse(sqlDataReader[8].ToString());
						salesDetailsInfo.TaxIncludedOrNot = bool.Parse(sqlDataReader[9].ToString());
						salesDetailsInfo.TaxPercentage = float.Parse(sqlDataReader[10].ToString());
						salesDetailsInfo.Description = sqlDataReader[11].ToString();
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
			return salesDetailsInfo;
		}

		public DataTable SalesDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesDetailsViewAll", DBConnection.sqlcon);
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

		public DataTable SalesDetailsViewAllByMasterId(string masterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesDetailsViewAllByMasterId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@salesMasterId", SqlDbType.VarChar).Value = masterId;
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