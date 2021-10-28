using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PurchaseDetailsSP : DBConnection
	{
		public PurchaseDetailsSP()
		{
		}

		public void PurchaseDetailsAdd(PurchaseDetailsInfo purchasedetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.PurchaseMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = purchasedetailsinfo.Rate;
					sqlParameter = sqlCommand.Parameters.Add("@discount", SqlDbType.Float);
					sqlParameter.Value = purchasedetailsinfo.Discount;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = purchasedetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@freeQty", SqlDbType.Decimal);
					sqlParameter.Value = purchasedetailsinfo.FreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@taxPercentage", SqlDbType.Float);
					sqlParameter.Value = purchasedetailsinfo.TaxPercentage;
					sqlParameter = sqlCommand.Parameters.Add("@taxIncludedOrNot", SqlDbType.Bit);
					sqlParameter.Value = purchasedetailsinfo.TaxIncludedOrNot;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.Description;
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

		public bool PurchaseDetailsCheckOnDelete(string strPurchaseDetailsId)
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
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsCheckOnDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseDetailsId", SqlDbType.VarChar).Value = strPurchaseDetailsId;
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

		public void PurchaseDetailsDelete(string PurchaseDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseDetailsId", SqlDbType.VarChar).Value = PurchaseDetailsId;
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

       

        public void PurchaseDetailsDeleteByPurchaseMasterId(string PurchaseMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsDeleteByPurchaseMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar).Value = PurchaseMasterId;
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

		public void PurchaseDetailsEdit(PurchaseDetailsInfo purchasedetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@purchaseDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.PurchaseDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.PurchaseMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
					sqlParameter.Value = purchasedetailsinfo.Rate;
					sqlParameter = sqlCommand.Parameters.Add("@discount", SqlDbType.Float);
					sqlParameter.Value = purchasedetailsinfo.Discount;
					sqlParameter = sqlCommand.Parameters.Add("@qty", SqlDbType.Decimal);
					sqlParameter.Value = purchasedetailsinfo.Qty;
					sqlParameter = sqlCommand.Parameters.Add("@freeQty", SqlDbType.Decimal);
					sqlParameter.Value = purchasedetailsinfo.FreeQty;
					sqlParameter = sqlCommand.Parameters.Add("@taxPercentage", SqlDbType.Float);
					sqlParameter.Value = purchasedetailsinfo.TaxPercentage;
					sqlParameter = sqlCommand.Parameters.Add("@taxIncludedOrNot", SqlDbType.Bit);
					sqlParameter.Value = purchasedetailsinfo.TaxIncludedOrNot;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = purchasedetailsinfo.Description;
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

		public int PurchaseDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsMax", DBConnection.sqlcon)
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

		public DataTable PurchaseDetailsPendingForReturn(string pPurchaseMasterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseDetailsPendingForReturn", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar).Value = pPurchaseMasterId;
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

		public PurchaseDetailsInfo PurchaseDetailsView(string purchaseDetailsId)
		{
			PurchaseDetailsInfo purchaseDetailsInfo = new PurchaseDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PurchaseDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@purchaseDetailsId", SqlDbType.VarChar).Value = purchaseDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						purchaseDetailsInfo.PurchaseDetailsId = sqlDataReader[0].ToString();
						purchaseDetailsInfo.PurchaseMasterId = sqlDataReader[1].ToString();
						purchaseDetailsInfo.ProductBatchId = sqlDataReader[2].ToString();
						purchaseDetailsInfo.Rate = decimal.Parse(sqlDataReader[3].ToString());
						purchaseDetailsInfo.Discount = float.Parse(sqlDataReader[4].ToString());
						purchaseDetailsInfo.Qty = decimal.Parse(sqlDataReader[5].ToString());
						purchaseDetailsInfo.FreeQty = decimal.Parse(sqlDataReader[6].ToString());
						purchaseDetailsInfo.TaxPercentage = float.Parse(sqlDataReader[7].ToString());
						purchaseDetailsInfo.TaxIncludedOrNot = bool.Parse(sqlDataReader[8].ToString());
						purchaseDetailsInfo.Description = sqlDataReader[9].ToString();
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
			return purchaseDetailsInfo;
		}

		public DataTable PurchaseDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseDetailsViewAll", DBConnection.sqlcon);
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


      

        public DataTable PurchaseDetailsViewAllByMasterId(string pPurchaseMasterId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PurchaseDetailsViewAllByMasterId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@purchaseMasterId", SqlDbType.VarChar).Value = pPurchaseMasterId;
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