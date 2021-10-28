using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class ProductBatchSP : DBConnection
	{
		public ProductBatchSP()
		{
		}

		public string ProductBatchAdd(ProductBatchInfo productbatchinfo)
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
					SqlCommand sqlCommand = new SqlCommand("ProductBatchAdd", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.ProductId;
					sqlParameter = sqlCommand.Parameters.Add("@batchName", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.BatchName;
					sqlParameter = sqlCommand.Parameters.Add("@expiryDate", SqlDbType.DateTime);
					sqlParameter.Value = productbatchinfo.ExpiryDate;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseRate", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.PurchaseRate;
					sqlParameter = sqlCommand.Parameters.Add("@salesRate", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.SalesRate;
					sqlParameter = sqlCommand.Parameters.Add("@MRP", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.MRP;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.Description;
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

		internal void ProductBatchDeleteByProductId(string _ID)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ProductBatchDeleteByProductId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = _ID;
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

		public void ProductBatchEdit(ProductBatchInfo productbatchinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ProductBatchEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.ProductId;
					sqlParameter = sqlCommand.Parameters.Add("@batchName", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.BatchName;
					sqlParameter = sqlCommand.Parameters.Add("@expiryDate", SqlDbType.DateTime);
					sqlParameter.Value = productbatchinfo.ExpiryDate;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseRate", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.PurchaseRate;
					sqlParameter = sqlCommand.Parameters.Add("@salesRate", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.SalesRate;
					sqlParameter = sqlCommand.Parameters.Add("@MRP", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.MRP;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.Description;
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

		public void ProductBatchEditByProductId(ProductBatchInfo productbatchinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ProductBatchEditByProductId", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.ProductBatchId;
					sqlParameter = sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.ProductId;
					sqlParameter = sqlCommand.Parameters.Add("@batchName", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.BatchName;
					sqlParameter = sqlCommand.Parameters.Add("@expiryDate", SqlDbType.DateTime);
					sqlParameter.Value = productbatchinfo.ExpiryDate;
					sqlParameter = sqlCommand.Parameters.Add("@purchaseRate", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.PurchaseRate;
					sqlParameter = sqlCommand.Parameters.Add("@salesRate", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.SalesRate;
					sqlParameter = sqlCommand.Parameters.Add("@MRP", SqlDbType.Decimal);
					sqlParameter.Value = productbatchinfo.MRP;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = productbatchinfo.Description;
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

		public int ProductBatchGetMax()
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
					SqlCommand sqlCommand = new SqlCommand("ProductBatchMax", DBConnection.sqlcon)
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

		public ProductBatchInfo ProductBatchView(string productBatchId)
		{
			ProductBatchInfo productBatchInfo = new ProductBatchInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("ProductBatchView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@productBatchId", SqlDbType.VarChar).Value = productBatchId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						productBatchInfo.ProductBatchId = sqlDataReader[0].ToString();
						productBatchInfo.ProductId = sqlDataReader[1].ToString();
						productBatchInfo.BatchName = sqlDataReader[2].ToString();
						productBatchInfo.ExpiryDate = DateTime.Parse(sqlDataReader[3].ToString());
						productBatchInfo.PurchaseRate = decimal.Parse(sqlDataReader[4].ToString());
						productBatchInfo.SalesRate = decimal.Parse(sqlDataReader[5].ToString());
						productBatchInfo.MRP = decimal.Parse(sqlDataReader[6].ToString());
						productBatchInfo.Description = sqlDataReader[7].ToString();
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
			return productBatchInfo;
		}


        public ProductBatchInfo ProductBatchNameView(string productId)
        {
            ProductBatchInfo productBatchInfo = new ProductBatchInfo();
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("ProductBatchNameView", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = productId;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        productBatchInfo.ProductId = sqlDataReader[0].ToString();
                       
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
            return productBatchInfo;
        }
        public DataTable ProductBatchViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProductBatchViewAll", DBConnection.sqlcon);
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

		public DataTable ProductBatchViewAllByProductId(string productId)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProductBatchViewAllByProductId", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = productId;
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

		public DataTable ProductBatchViewAllNotDuplicate()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProductBatchViewAllNotDuplicate", DBConnection.sqlcon);
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

		public DataTable ProductBatchViewByProductAndBatchName(string productId, string batchName)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ProductBatchViewByProductAndBatchName", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = productId;
					sqlDataAdapter.SelectCommand.Parameters.Add("@batchName", SqlDbType.VarChar).Value = batchName;
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

		public DataTable ShortExpiryBatchGet(DateTime dtDate)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ShortExpiryBatchGet", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = dtDate;
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