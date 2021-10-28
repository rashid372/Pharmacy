using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class ReceiptDetailsSP : DBConnection
	{
		public ReceiptDetailsSP()
		{
		}

		public void ReceiptDetailsAdd(ReceiptDetailsInfo receiptdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@receiptMasterId", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.ReceiptMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
					sqlParameter.Value = receiptdetailsinfo.Amount;
					sqlParameter = sqlCommand.Parameters.Add("@chequeNumber", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.ChequeNumber;
					sqlParameter = sqlCommand.Parameters.Add("@chequeDate", SqlDbType.DateTime);
					sqlParameter.Value = receiptdetailsinfo.ChequeDate;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.Description;
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

		public void ReceiptDetailsDelete(string ReceiptDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@receiptDetailsId", SqlDbType.VarChar).Value = ReceiptDetailsId;
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

		public void ReceiptDetailsDeleteByMasterId(string receiptMasterId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@receiptMasterId", SqlDbType.VarChar).Value = receiptMasterId;
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

		public void ReceiptDetailsEdit(ReceiptDetailsInfo receiptdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@receiptDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.ReceiptDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@receiptMasterId", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.ReceiptMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
					sqlParameter.Value = receiptdetailsinfo.Amount;
					sqlParameter = sqlCommand.Parameters.Add("@chequeNumber", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.ChequeNumber;
					sqlParameter = sqlCommand.Parameters.Add("@chequeDate", SqlDbType.DateTime);
					sqlParameter.Value = receiptdetailsinfo.ChequeDate;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = receiptdetailsinfo.Description;
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

		public int ReceiptDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsMax", DBConnection.sqlcon)
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

		public ReceiptDetailsInfo ReceiptDetailsView(string receiptDetailsId)
		{
			ReceiptDetailsInfo receiptDetailsInfo = new ReceiptDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@receiptDetailsId", SqlDbType.VarChar).Value = receiptDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						receiptDetailsInfo.ReceiptDetailsId = sqlDataReader[0].ToString();
						receiptDetailsInfo.ReceiptMasterId = sqlDataReader[1].ToString();
						receiptDetailsInfo.LedgerId = sqlDataReader[2].ToString();
						receiptDetailsInfo.VoucherNumber = sqlDataReader[3].ToString();
						receiptDetailsInfo.VoucherType = sqlDataReader[4].ToString();
						receiptDetailsInfo.Amount = decimal.Parse(sqlDataReader[5].ToString());
						receiptDetailsInfo.ChequeNumber = sqlDataReader[6].ToString();
						receiptDetailsInfo.ChequeDate = DateTime.Parse(sqlDataReader[7].ToString());
						receiptDetailsInfo.Description = sqlDataReader[8].ToString();
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
			return receiptDetailsInfo;
		}

		public DataTable ReceiptDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ReceiptDetailsViewAll", DBConnection.sqlcon);
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

		public ReceiptDetailsInfo ReceiptDetailsViewByMasterId(string receiptMasterId)
		{
			ReceiptDetailsInfo receiptDetailsInfo = new ReceiptDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ReceiptDetailsViewByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@receiptMasterId", SqlDbType.VarChar).Value = receiptMasterId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						receiptDetailsInfo.ReceiptDetailsId = sqlDataReader[0].ToString();
						receiptDetailsInfo.ReceiptMasterId = sqlDataReader[1].ToString();
						receiptDetailsInfo.LedgerId = sqlDataReader[2].ToString();
						receiptDetailsInfo.VoucherNumber = sqlDataReader[3].ToString();
						receiptDetailsInfo.VoucherType = sqlDataReader[4].ToString();
						receiptDetailsInfo.Amount = decimal.Parse(sqlDataReader[5].ToString());
						receiptDetailsInfo.ChequeNumber = sqlDataReader[6].ToString();
						receiptDetailsInfo.ChequeDate = DateTime.Parse(sqlDataReader[7].ToString());
						receiptDetailsInfo.Description = sqlDataReader[8].ToString();
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
			return receiptDetailsInfo;
		}
	}
}