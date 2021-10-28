using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class VendorSP : DBConnection
	{
		public VendorSP()
		{
		}

		internal DataTable TelephoneDirectoryViewByName(string Name)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("TelephoneDirectoryViewByName", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@Name", SqlDbType.VarChar);
					sqlParameter.Value = Name;
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

		public VendorInfo VendorView(string vendorId)
		{
			VendorInfo vendorInfo = new VendorInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("VendorView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar).Value = vendorId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						vendorInfo.VendorId = sqlDataReader[0].ToString();
						vendorInfo.VendorName = sqlDataReader[1].ToString();
						vendorInfo.Address = sqlDataReader[2].ToString();
						vendorInfo.Country = sqlDataReader[3].ToString();
						vendorInfo.State = sqlDataReader[4].ToString();
						vendorInfo.PinCode = sqlDataReader[5].ToString();
						vendorInfo.PhoneNumber = sqlDataReader[6].ToString();
						vendorInfo.MobileNumber = sqlDataReader[7].ToString();
						vendorInfo.EmailId = sqlDataReader[8].ToString();
						vendorInfo.LedgerId = sqlDataReader[9].ToString();
						vendorInfo.Description = sqlDataReader[10].ToString();
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
			return vendorInfo;
		}

		public DataTable VendorViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("VendorViewAll", DBConnection.sqlcon);
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

		internal DataTable VendorViewAllExceptNA()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("VendorViewAllExceptNA", DBConnection.sqlcon);
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

        public string vendorAdd(VendorInfo venderinfo)
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
                    SqlCommand sqlCommand = new SqlCommand("vendorAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.VendorId;
                    sqlParameter = sqlCommand.Parameters.Add("@vendorName", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.VendorName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.Address;

                    sqlParameter = sqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.Country;
                    sqlParameter = sqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.State;
                    sqlParameter = sqlCommand.Parameters.Add("@pinCode", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.PinCode;
                    sqlParameter = sqlCommand.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.PhoneNumber;

                    sqlParameter = sqlCommand.Parameters.Add("@emailId", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.EmailId;
                    sqlParameter = sqlCommand.Parameters.Add("@mobileNumber", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.MobileNumber;
                    sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.LedgerId;


                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.Description;
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

        public void VendorEdit(VendorInfo venderinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("VendorEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.VendorId;
                    sqlParameter = sqlCommand.Parameters.Add("@vendorName", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.VendorName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.Address;

                    sqlParameter = sqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.Country;
                    sqlParameter = sqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.State;
                    sqlParameter = sqlCommand.Parameters.Add("@pinCode", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.PinCode;
                    sqlParameter = sqlCommand.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.PhoneNumber;

                    sqlParameter = sqlCommand.Parameters.Add("@emailId", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.EmailId;
                    sqlParameter = sqlCommand.Parameters.Add("@mobileNumber", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.MobileNumber;
                    sqlParameter = sqlCommand.Parameters.Add("@ledgerId", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.LedgerId;


                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = venderinfo.Description;

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

        public void VendorDelete(string vendorId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("VendorDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@vendorId", SqlDbType.VarChar).Value = vendorId;
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