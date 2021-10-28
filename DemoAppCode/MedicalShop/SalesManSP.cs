using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class SalesManSP : DBConnection
	{
		public SalesManSP()
		{
		}

		public bool CheckExistanceOfSalesInvoice(string strPurchaseInvoice)
		{
			bool flag;
			bool flag1 = false;
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesMasterCheckDuplicateInvoiceNo", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@invoiceNo", SqlDbType.VarChar).Value = strPurchaseInvoice;
					if (sqlCommand.ExecuteScalar() != null)
					{
						flag = true;
						return flag;
					}
					else
					{
						flag = false;
						return flag;
					}
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
			flag = flag1;
			return flag;
		}

		public string SalesManCodeCheck(string salesManId)
		{
			string str = "false";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesManCodeCheck", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar).Value = salesManId;
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

		internal string SalesManNameCheck(string p)
		{
			string str = "false";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesManNameCheck", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesManName", SqlDbType.VarChar).Value = p;
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

		public string SalesManReferenceCheck(string salesManId)
		{
			string str = "false";
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesManReferenceCheck", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar).Value = salesManId;
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

		public SalesManInfo SalesManView(string salesManId)
		{
			SalesManInfo salesManInfo = new SalesManInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SalesManView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar).Value = salesManId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						salesManInfo.SalesManId = sqlDataReader[0].ToString();
						salesManInfo.SalesManName = sqlDataReader[1].ToString();
						salesManInfo.Address = sqlDataReader[2].ToString();
						salesManInfo.PinCode = sqlDataReader[3].ToString();
						salesManInfo.Phone = sqlDataReader[4].ToString();
						salesManInfo.Mobile = sqlDataReader[5].ToString();
						salesManInfo.Email = sqlDataReader[6].ToString();
						salesManInfo.DateOfBirth = DateTime.Parse(sqlDataReader[7].ToString());
						salesManInfo.DateOfJoining = DateTime.Parse(sqlDataReader[8].ToString());
						salesManInfo.DateOfTermination = DateTime.Parse(sqlDataReader[9].ToString());
						salesManInfo.Qualification = sqlDataReader[10].ToString();
						salesManInfo.ActiveOrNot = bool.Parse(sqlDataReader[11].ToString());
						salesManInfo.LedgerId = sqlDataReader[12].ToString();
						salesManInfo.Description = sqlDataReader[13].ToString();
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
			return salesManInfo;
		}

		public DataTable SalesManViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesManViewAll", DBConnection.sqlcon);
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

		internal DataTable SalesManViewAllActive()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesManViewAllActive", DBConnection.sqlcon);
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

		internal DataTable SalesManViewAllExceptNA()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SalesManViewAllExceptNA", DBConnection.sqlcon);
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

        public void SalesManAdd(SalesManInfo salesmaninfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("SalesManAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.SalesManId;
                    sqlParameter = sqlCommand.Parameters.Add("@salesManName", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.SalesManName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@pinCode", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.PinCode;
                    sqlParameter = sqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Phone;
                    sqlParameter = sqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Mobile;
                    sqlParameter = sqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Email;
                    sqlParameter = sqlCommand.Parameters.Add("@dateOfBirth", SqlDbType.DateTime);
                    sqlParameter.Value = salesmaninfo.DateOfBirth;
                    sqlParameter = sqlCommand.Parameters.Add("@dateOfJoining", SqlDbType.DateTime);
                    sqlParameter.Value = salesmaninfo.DateOfJoining;
                    sqlParameter = sqlCommand.Parameters.Add("@dateOfTermination", SqlDbType.DateTime);
                    sqlParameter.Value = salesmaninfo.DateOfTermination;
                    sqlParameter = sqlCommand.Parameters.Add("@qualification", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Qualification;
                    sqlParameter = sqlCommand.Parameters.Add("@activeOrNot", SqlDbType.Bit);
                    sqlParameter.Value = salesmaninfo.ActiveOrNot;
                    sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.LedgerId;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Description;
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
        public void SalesManEdit(SalesManInfo salesmaninfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("SalesManEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.SalesManId;
                    sqlParameter = sqlCommand.Parameters.Add("@salesManName", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.SalesManName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@pinCode", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.PinCode;
                    sqlParameter = sqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Phone;
                    sqlParameter = sqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Mobile;
                    sqlParameter = sqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Email;
                    sqlParameter = sqlCommand.Parameters.Add("@dateOfBirth", SqlDbType.DateTime);
                    sqlParameter.Value = salesmaninfo.DateOfBirth;
                    sqlParameter = sqlCommand.Parameters.Add("@dateOfJoining", SqlDbType.DateTime);
                    sqlParameter.Value = salesmaninfo.DateOfJoining;
                    sqlParameter = sqlCommand.Parameters.Add("@dateOfTermination", SqlDbType.DateTime);
                    sqlParameter.Value = salesmaninfo.DateOfTermination;
                    sqlParameter = sqlCommand.Parameters.Add("@qualification", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Qualification;
                    sqlParameter = sqlCommand.Parameters.Add("@activeOrNot", SqlDbType.Bit);
                    sqlParameter.Value = salesmaninfo.ActiveOrNot;
                    sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.LedgerId;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = salesmaninfo.Description;
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

        public void SalesManDelete(string salesManId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("SalesManDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@salesManId", SqlDbType.VarChar).Value = salesManId;
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