using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class CompanySP : DBConnection
	{
		public CompanySP()
		{
		}

		public CompanyInfo CompanyView(string companyId)
		{
			CompanyInfo companyInfo = new CompanyInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CompanyView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar).Value = companyId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						companyInfo.CompanyId = sqlDataReader[0].ToString();
						companyInfo.CompanyName = sqlDataReader[1].ToString();
						companyInfo.Address = sqlDataReader[2].ToString();
						companyInfo.Country = sqlDataReader[3].ToString();
						companyInfo.State = sqlDataReader[4].ToString();
						companyInfo.City = sqlDataReader[5].ToString();
						companyInfo.Pincode = sqlDataReader[6].ToString();
						companyInfo.Fax = sqlDataReader[7].ToString();
						companyInfo.Email = sqlDataReader[8].ToString();
						companyInfo.Website = sqlDataReader[9].ToString();
						companyInfo.DrugLicense = sqlDataReader[10].ToString();
						companyInfo.TinNumber = sqlDataReader[11].ToString();
						companyInfo.CstNumber = sqlDataReader[12].ToString();
						companyInfo.Currency = sqlDataReader[13].ToString();
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
			return companyInfo;
		}

		public DataTable CompanyViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CompanyViewAll", DBConnection.sqlcon);
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

        public void CompanyAdd(CompanyInfo companyinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("CompanyAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.CompanyId;
                    sqlParameter = sqlCommand.Parameters.Add("@companyName", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.CompanyName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Country;
                    sqlParameter = sqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.State;
                    sqlParameter = sqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.City;
                    sqlParameter = sqlCommand.Parameters.Add("@pincode", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Pincode;

                    sqlParameter = sqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Fax;
                    sqlParameter = sqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Email;
                    sqlParameter = sqlCommand.Parameters.Add("@website", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Website;
                    sqlParameter = sqlCommand.Parameters.Add("@drugLicense", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.DrugLicense;

                    sqlParameter = sqlCommand.Parameters.Add("@tinNumber", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.TinNumber;
                    sqlParameter = sqlCommand.Parameters.Add("@cstNumber", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.CstNumber;
                    sqlParameter = sqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Currency;

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

        public void CompanyEdit(CompanyInfo companyinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("CompanyEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.CompanyId;
                    sqlParameter = sqlCommand.Parameters.Add("@companyName", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.CompanyName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Country;
                    sqlParameter = sqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.State;
                    sqlParameter = sqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.City;
                    sqlParameter = sqlCommand.Parameters.Add("@pincode", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Pincode;

                    sqlParameter = sqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Fax;
                    sqlParameter = sqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Email;
                    sqlParameter = sqlCommand.Parameters.Add("@website", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Website;
                    sqlParameter = sqlCommand.Parameters.Add("@drugLicense", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.DrugLicense;

                    sqlParameter = sqlCommand.Parameters.Add("@tinNumber", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.TinNumber;
                    sqlParameter = sqlCommand.Parameters.Add("@cstNumber", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.CstNumber;
                    sqlParameter = sqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                    sqlParameter.Value = companyinfo.Currency;
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

        public void CompanyDelete(string companyId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("CompanyDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar).Value = companyId;
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