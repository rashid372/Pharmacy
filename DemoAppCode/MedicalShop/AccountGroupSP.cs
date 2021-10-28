using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class AccountGroupSP : DBConnection
	{
		public AccountGroupSP()
		{
		}

		public AccountGroupInfo AccountGroupView(string accountGroupId)
		{
			AccountGroupInfo accountGroupInfo = new AccountGroupInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("AccountGroupView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar).Value = accountGroupId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						accountGroupInfo.AccountGroupId = sqlDataReader[0].ToString();
						accountGroupInfo.AccountGroupName = sqlDataReader[1].ToString();
						accountGroupInfo.GroupUnder = sqlDataReader[2].ToString();
						accountGroupInfo.Description = sqlDataReader[3].ToString();
						accountGroupInfo.DefaultOrNot = bool.Parse(sqlDataReader[4].ToString());
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
			return accountGroupInfo;
		}

		public DataTable AccountGroupViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountGroupViewAll", DBConnection.sqlcon);
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

		public DataTable AccountGroupViewAllByAccountGroupId(string strAccountGroupId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountGroupViewAllByAccountGroupId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
					sqlParameter.Value = strAccountGroupId;
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

		public DataTable AccountGroupViewAllByAccountGroupIdAndStatus(string strAccountGroupId, bool isInbuilt)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountGroupViewAllByAccountGroupIdAndStatus", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
					sqlParameter.Value = strAccountGroupId;
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@defaultOrNot", SqlDbType.VarChar);
					sqlParameter.Value = isInbuilt;
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

		public DataTable AccountGroupViewAllByStatus(bool isBuiltIn)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AccountGroupViewAllByStatus", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
					sqlParameter.Value = isBuiltIn;
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

        public void AccountGroupAdd(AccountGroupInfo acountgroupinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("AccountGroupAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.AccountGroupId;
                    sqlParameter = sqlCommand.Parameters.Add("@accountGroupName", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.AccountGroupName;
                    sqlParameter = sqlCommand.Parameters.Add("@groupUnder", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.GroupUnder;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
                    sqlParameter.Value = acountgroupinfo.DefaultOrNot;

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

        public void AccountGroupEdit(AccountGroupInfo acountgroupinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("AccountGroupEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.AccountGroupId;
                    sqlParameter = sqlCommand.Parameters.Add("@accountGroupName", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.AccountGroupName;
                    sqlParameter = sqlCommand.Parameters.Add("@groupUnder", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.GroupUnder;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = acountgroupinfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
                    sqlParameter.Value = acountgroupinfo.DefaultOrNot;
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

        public void AccountGroupDelete(string AccountGroupId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("AccountGroupDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@accountGroupId", SqlDbType.VarChar).Value = AccountGroupId;
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

        internal string AccountGroupNameCheck(string name)
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
                    SqlCommand sqlCommand = new SqlCommand("accountGroupNameCheck", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@accountGroupName", SqlDbType.VarChar).Value = name;
                    object obj = sqlCommand.ExecuteScalar();
                    str = (obj != null ? obj.ToString() : "");
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

    }
}