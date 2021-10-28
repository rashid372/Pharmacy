using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class ManufacturerSP : DBConnection
	{
		public ManufacturerSP()
		{
		}

		public bool CheckExistanceOfManufactureId(string strManufactureName)
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
					SqlCommand sqlCommand = new SqlCommand("manufactureCheckExistanceOfName", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@manufactureName", SqlDbType.VarChar).Value = strManufactureName;
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

		public ManufacturerInfo ManufacturerView(string manufactureId)
		{
			ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ManufacturerView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@manufactureId", SqlDbType.VarChar).Value = manufactureId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						manufacturerInfo.ManufactureId = sqlDataReader[0].ToString();
						manufacturerInfo.ManufactureName = sqlDataReader[1].ToString();
						manufacturerInfo.Address = sqlDataReader[2].ToString();
						manufacturerInfo.Phone = sqlDataReader[3].ToString();
						manufacturerInfo.Email = sqlDataReader[4].ToString();
						manufacturerInfo.Description = sqlDataReader[5].ToString();
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
			return manufacturerInfo;
		}

		public DataTable ManufacturerViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ManufacturerViewAll", DBConnection.sqlcon);
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

		internal DataTable ManufacturerViewAllExceptNA()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ManufacturerViewAllExceptNA", DBConnection.sqlcon);
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

		public ManufacturerInfo manufactureViewByPdoductBatch(string manufactureId)
		{
			ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("manufactureViewByPdoductBatch", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar).Value = manufactureId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						manufacturerInfo.ManufactureId = sqlDataReader[0].ToString();
						manufacturerInfo.ManufactureName = sqlDataReader[1].ToString();
						manufacturerInfo.Address = sqlDataReader[2].ToString();
						manufacturerInfo.Phone = sqlDataReader[3].ToString();
						manufacturerInfo.Email = sqlDataReader[4].ToString();
						manufacturerInfo.Description = sqlDataReader[5].ToString();
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
			return manufacturerInfo;
		}

		internal DataTable ProductViewByManufactureId(string _Search)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProductViewByManufactureId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@manufactureId", SqlDbType.VarChar);
					sqlParameter.Value = _Search;
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

        public void ManufacturerAdd(ManufacturerInfo manufacturerinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("ManufacturerAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@manufactureId", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.ManufactureId;
                    sqlParameter = sqlCommand.Parameters.Add("@manufactureName", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.ManufactureName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Phone;
                    sqlParameter = sqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Email;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Description;
                    
                    sqlCommand.ExecuteScalar();
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

        public void ManufacturerEdit(ManufacturerInfo manufacturerinfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("ManufacturerEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@manufactureId", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.ManufactureId;
                    sqlParameter = sqlCommand.Parameters.Add("@manufactureName", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.ManufactureName;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Phone;
                    sqlParameter = sqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Email;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = manufacturerinfo.Description;
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

        public void ManufacturerDelete(string manufactureId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("ManufacturerDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@manufacturerId", SqlDbType.VarChar).Value= manufactureId;
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