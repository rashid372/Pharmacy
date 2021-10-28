using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class UserSP : DBConnection
	{
		public UserSP()
		{
		}

		public UserInfo UserView(string userId)
		{
			UserInfo userInfo = new UserInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("UserView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@userId", SqlDbType.VarChar).Value = userId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						userInfo.UserId = sqlDataReader[0].ToString();
						userInfo.Username = sqlDataReader[1].ToString();
						userInfo.Password = sqlDataReader[2].ToString();
						userInfo.ActiveOrNot = bool.Parse(sqlDataReader[3].ToString());
						userInfo.Description = sqlDataReader[4].ToString();
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
			return userInfo;
		}

		public DataTable UserViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("UserViewAll", DBConnection.sqlcon);
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

        public string UserAdd( UserInfo userinfo)
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
                    SqlCommand sqlCommand = new SqlCommand("UserAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                    sqlParameter.Value = userinfo.Username;
                    sqlParameter = sqlCommand.Parameters.Add("@password", SqlDbType.VarChar);
                    sqlParameter.Value =userinfo.Password;
                    sqlParameter = sqlCommand.Parameters.Add("@activeOrNot", SqlDbType.Bit);
                    sqlParameter.Value = userinfo.ActiveOrNot;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = userinfo.Description;
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

        public void UserEdit(UserInfo userinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("UserEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@userId", SqlDbType.VarChar);
                    sqlParameter.Value = userinfo.UserId;
                    sqlParameter = sqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                    sqlParameter.Value = userinfo.Username;
                    sqlParameter = sqlCommand.Parameters.Add("@password", SqlDbType.VarChar);
                    sqlParameter.Value = userinfo.Password;
                    sqlParameter = sqlCommand.Parameters.Add("@activeOrNot", SqlDbType.Bit);
                    sqlParameter.Value = userinfo.ActiveOrNot;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = userinfo.Description;
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

        public void UserDelete(string userId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("UserDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@userId", SqlDbType.VarChar).Value = userId;
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