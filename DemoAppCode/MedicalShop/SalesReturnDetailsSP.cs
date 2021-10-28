using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class SalesReturnDetailsSP : DBConnection
	{
		public SalesReturnDetailsSP()
		{
		}

		public void SalesReturnDetailsAdd(SalesReturnDetailsInfo salesreturndetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesReturnDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@salesReturnMasterId", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.SalesReturnMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@salesDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.SalesDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@returnedQty", SqlDbType.Decimal);
					sqlParameter.Value = salesreturndetailsinfo.ReturnedQty;
					sqlParameter = sqlCommand.Parameters.Add("@returnedFreeQty", SqlDbType.Decimal);
					sqlParameter.Value = salesreturndetailsinfo.ReturnedFreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.Description;
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

		public void SalesReturnDetailsDelete(string SalesReturnDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesReturnDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesReturnDetailsId", SqlDbType.VarChar).Value = SalesReturnDetailsId;
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

		public void SalesReturnDetailsDeleteByMasterId(string SalesReturnMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesReturnDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesReturnMasterId", SqlDbType.VarChar).Value = SalesReturnMasterId;
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

		public void SalesReturnDetailsEdit(SalesReturnDetailsInfo salesreturndetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesReturnDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@salesReturnDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.SalesReturnDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@salesReturnMasterId", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.SalesReturnMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@salesDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.SalesDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@returnedQty", SqlDbType.Decimal);
					sqlParameter.Value = salesreturndetailsinfo.ReturnedQty;
					sqlParameter = sqlCommand.Parameters.Add("@returnedFreeQty", SqlDbType.Decimal);
					sqlParameter.Value = salesreturndetailsinfo.ReturnedFreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = salesreturndetailsinfo.Description;
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

		public int SalesReturnDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("SalesReturnDetailsMax", DBConnection.sqlcon)
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

		public SalesReturnDetailsInfo SalesReturnDetailsView(string salesReturnDetailsId)
		{
			SalesReturnDetailsInfo salesReturnDetailsInfo = new SalesReturnDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesReturnDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesReturnDetailsId", SqlDbType.VarChar).Value = salesReturnDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						salesReturnDetailsInfo.SalesReturnDetailsId = sqlDataReader[0].ToString();
						salesReturnDetailsInfo.SalesReturnMasterId = sqlDataReader[1].ToString();
						salesReturnDetailsInfo.SalesDetailsId = sqlDataReader[2].ToString();
						salesReturnDetailsInfo.ReturnedQty = decimal.Parse(sqlDataReader[3].ToString());
						salesReturnDetailsInfo.ReturnedFreeQty = decimal.Parse(sqlDataReader[4].ToString());
						salesReturnDetailsInfo.Description = sqlDataReader[5].ToString();
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
			return salesReturnDetailsInfo;
		}

		public DataTable SalesReturnDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReturnDetailsViewAll", DBConnection.sqlcon);
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

		public DataTable SalesReturnDetailsViewAllByMasterId(string masterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesReturnDetailsViewAllByMasterId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@salesReturnMasterId", SqlDbType.VarChar).Value = masterId;
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