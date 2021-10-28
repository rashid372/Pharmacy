using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class DamageStcokMasterSP : DBConnection
	{
		public DamageStcokMasterSP()
		{
		}

		public string DamageStcokMasterAdd(DamageStcokMasterInfo damagestcokmasterinfo)
		{
			string str = "";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("DamageStcokMasterAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = damagestcokmasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = damagestcokmasterinfo.Description;
					str = sqlCommand.ExecuteScalar().ToString();
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
			return str;
		}

		public void DamageStcokMasterEdit(DamageStcokMasterInfo damagestcokmasterinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("DamageStcokMasterEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@damageStockMasterId", SqlDbType.VarChar);
					sqlParameter.Value = damagestcokmasterinfo.DamageStockMasterId;
					sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
					sqlParameter.Value = damagestcokmasterinfo.Date;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = damagestcokmasterinfo.Description;
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

		public string DamageStcokMasterGetMax()
		{
			string str = "";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("DamageStcokMasterMax", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					str = sqlCommand.ExecuteScalar().ToString();
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
			return str;
		}

		public DamageStcokMasterInfo DamageStcokMasterView(string damageStockMasterId)
		{
			DamageStcokMasterInfo damageStcokMasterInfo = new DamageStcokMasterInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("DamageStcokMasterView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@damageStockMasterId", SqlDbType.VarChar).Value = damageStockMasterId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						damageStcokMasterInfo.DamageStockMasterId = sqlDataReader[0].ToString();
						damageStcokMasterInfo.Date = DateTime.Parse(sqlDataReader[1].ToString());
						damageStcokMasterInfo.Description = sqlDataReader[2].ToString();
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
			return damageStcokMasterInfo;
		}

		public DataTable DamageStcokMasterViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStcokMasterViewAll", DBConnection.sqlcon);
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

		internal DataTable DamageStcokMasterViewBetweenDate(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStcokMasterViewBetweenDate", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataTable DamageStockReportForAll(DateTime fromdate, DateTime todate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStockReportForAll", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
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

		public DataTable DamageStockReportForGenericName(DateTime fromdate, DateTime todate, string genericId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStockReportForGenericName", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@genericNameId", SqlDbType.VarChar);
					sqlParameter.Value = genericId;
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

		public DataTable DamageStockReportForProduct(DateTime fromdate, DateTime todate, string productId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStockReportForProduct", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@productId", SqlDbType.VarChar);
					sqlParameter.Value = productId;
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

		public DataTable DamageStockReportForProductGroup(DateTime fromdate, DateTime todate, string productGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStockReportForProductGroup", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@productGroupId", SqlDbType.VarChar);
					sqlParameter.Value = productGroupId;
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

		public DataTable DamageStockReportForVoucher(DateTime fromdate, DateTime todate, string voucherNo)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("DamageStockReportForVoucher", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.DateTime);
					sqlParameter.Value = fromdate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.DateTime);
					sqlParameter.Value = todate;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@voucherNo", SqlDbType.VarChar);
					sqlParameter.Value = voucherNo;
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

        public void DamageStcokMasterDelete(string damageStockMasterId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("DamageStcokMasterDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@damageStockMasterId", SqlDbType.VarChar).Value = damageStockMasterId;
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
    }
}