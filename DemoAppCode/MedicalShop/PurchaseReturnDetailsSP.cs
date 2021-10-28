using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PurchaseReturnDetailsSP : DBConnection
	{
		public PurchaseReturnDetailsSP()
		{
		}

		public void PurchaseReturnDetailsAdd(PurchaseReturnDetailsInfo purchasereturndetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.PurchaseReturnMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.PurchaseDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@returnedQty", SqlDbType.Decimal);
					sqlParameter.Value = purchasereturndetailsinfo.ReturnedQty;
					sqlParameter = sqlCommand.Parameters.Add("@returnedFreeQty", SqlDbType.Decimal);
					sqlParameter.Value = purchasereturndetailsinfo.ReturnedFreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.Description;
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

		public void PurchaseReturnDetailsDelete(string PurchaseReturnDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseReturnDetailsId", SqlDbType.VarChar).Value = PurchaseReturnDetailsId;
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

		public void PurchaseReturnDetailsDeleteByMasterId(string MasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar).Value = MasterId;
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

		public void PurchaseReturnDetailsEdit(PurchaseReturnDetailsInfo purchasereturndetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseReturnDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.PurchaseReturnDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.PurchaseReturnMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.PurchaseDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@returnedQty", SqlDbType.Decimal);
					sqlParameter.Value = purchasereturndetailsinfo.ReturnedQty;
					sqlParameter = sqlCommand.Parameters.Add("@returnedFreeQty", SqlDbType.Decimal);
					sqlParameter.Value = purchasereturndetailsinfo.ReturnedFreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasereturndetailsinfo.Description;
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

		public int PurchaseReturnDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnDetailsMax", DBConnection.sqlcon)
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

		public PurchaseReturnDetailsInfo PurchaseReturnDetailsView(string purchaseReturnDetailsId)
		{
			PurchaseReturnDetailsInfo purchaseReturnDetailsInfo = new PurchaseReturnDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseReturnDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseReturnDetailsId", SqlDbType.VarChar).Value = purchaseReturnDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						purchaseReturnDetailsInfo.PurchaseReturnDetailsId = sqlDataReader[0].ToString();
						purchaseReturnDetailsInfo.PurchaseReturnMasterId = sqlDataReader[1].ToString();
						purchaseReturnDetailsInfo.PurchaseDetailsId = sqlDataReader[2].ToString();
						purchaseReturnDetailsInfo.ReturnedQty = decimal.Parse(sqlDataReader[3].ToString());
						purchaseReturnDetailsInfo.ReturnedFreeQty = decimal.Parse(sqlDataReader[4].ToString());
						purchaseReturnDetailsInfo.Description = sqlDataReader[5].ToString();
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
			return purchaseReturnDetailsInfo;
		}

		public DataTable PurchaseReturnDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnDetailsViewAll", DBConnection.sqlcon);
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

		public DataTable PurchaseReturnDetailsViewAllByMasterId(string masterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseReturnDetailsViewAllByMasterId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@purchaseReturnMasterId", SqlDbType.VarChar).Value = masterId;
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