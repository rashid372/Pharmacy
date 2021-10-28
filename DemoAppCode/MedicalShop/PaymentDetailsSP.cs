using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PaymentDetailsSP : DBConnection
	{
		public PaymentDetailsSP()
		{
		}

		public void PaymentDetailsAdd(PaymentDetailsInfo paymentdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@paymentMasterId", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.PaymentMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
					sqlParameter.Value = paymentdetailsinfo.Amount;
					sqlParameter = sqlCommand.Parameters.Add("@chequeNumber", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.ChequeNumber;
					sqlParameter = sqlCommand.Parameters.Add("@chequeDate", SqlDbType.DateTime);
					sqlParameter.Value = paymentdetailsinfo.ChequeDate;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.Description;
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

		public void PaymentDetailsDelete(string PaymentDetailsId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsDelete", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@paymentDetailsId", SqlDbType.VarChar).Value = PaymentDetailsId;
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

		public void PaymentDetailsDeleteByMasterId(string PaymentMaserId)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsDeleteByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@paymentMasterId", SqlDbType.VarChar).Value = PaymentMaserId;
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

		public void PaymentDetailsEdit(PaymentDetailsInfo paymentdetailsinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@paymentDetailsId", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.PaymentDetailsId;
					sqlParameter = sqlCommand.Parameters.Add("@paymentMasterId", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.PaymentMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.LedgerId;
					sqlParameter = sqlCommand.Parameters.Add("@voucherNumber", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.VoucherNumber;
					sqlParameter = sqlCommand.Parameters.Add("@voucherType", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.VoucherType;
					sqlParameter = sqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
					sqlParameter.Value = paymentdetailsinfo.Amount;
					sqlParameter = sqlCommand.Parameters.Add("@chequeNumber", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.ChequeNumber;
					sqlParameter = sqlCommand.Parameters.Add("@chequeDate", SqlDbType.DateTime);
					sqlParameter.Value = paymentdetailsinfo.ChequeDate;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = paymentdetailsinfo.Description;
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

		public int PaymentDetailsGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsMax", DBConnection.sqlcon)
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

		public PaymentDetailsInfo PaymentDetailsView(string paymentDetailsId)
		{
			PaymentDetailsInfo paymentDetailsInfo = new PaymentDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@paymentDetailsId", SqlDbType.VarChar).Value = paymentDetailsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						paymentDetailsInfo.PaymentDetailsId = sqlDataReader[0].ToString();
						paymentDetailsInfo.PaymentMasterId = sqlDataReader[1].ToString();
						paymentDetailsInfo.LedgerId = sqlDataReader[2].ToString();
						paymentDetailsInfo.VoucherNumber = sqlDataReader[3].ToString();
						paymentDetailsInfo.VoucherType = sqlDataReader[4].ToString();
						paymentDetailsInfo.Amount = decimal.Parse(sqlDataReader[5].ToString());
						paymentDetailsInfo.ChequeNumber = sqlDataReader[6].ToString();
						paymentDetailsInfo.ChequeDate = DateTime.Parse(sqlDataReader[7].ToString());
						paymentDetailsInfo.Description = sqlDataReader[8].ToString();
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
			return paymentDetailsInfo;
		}

		public DataTable PaymentDetailsViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PaymentDetailsViewAll", DBConnection.sqlcon);
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

		public PaymentDetailsInfo PaymentDetailsViewByMasterId(string paymentMasterId)
		{
			PaymentDetailsInfo paymentDetailsInfo = new PaymentDetailsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PaymentDetailsViewByMasterId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@paymentMasterId", SqlDbType.VarChar).Value = paymentMasterId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						paymentDetailsInfo.PaymentDetailsId = sqlDataReader[0].ToString();
						paymentDetailsInfo.PaymentMasterId = sqlDataReader[1].ToString();
						paymentDetailsInfo.LedgerId = sqlDataReader[2].ToString();
						paymentDetailsInfo.VoucherNumber = sqlDataReader[3].ToString();
						paymentDetailsInfo.VoucherType = sqlDataReader[4].ToString();
						paymentDetailsInfo.Amount = decimal.Parse(sqlDataReader[5].ToString());
						paymentDetailsInfo.ChequeNumber = sqlDataReader[6].ToString();
						paymentDetailsInfo.ChequeDate = DateTime.Parse(sqlDataReader[7].ToString());
						paymentDetailsInfo.Description = sqlDataReader[8].ToString();
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
			return paymentDetailsInfo;
		}
	}
}