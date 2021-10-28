using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PrimaryDBSP : DBConnectionForPDB
	{
		public PrimaryDBSP()
		{
		}

		public void CompanyPathAdd(CompanyPathInfo companypathinfo)
		{
			try
			{
				try
				{
					if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
					{
						DBConnectionForPDB.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CompanyPathAdd", DBConnectionForPDB.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar);
					sqlParameter.Value = companypathinfo.CompanyId;
					sqlParameter = sqlCommand.Parameters.Add("@companyName", SqlDbType.VarChar);
					sqlParameter.Value = companypathinfo.CompanyName;
					sqlParameter = sqlCommand.Parameters.Add("@path", SqlDbType.VarChar);
					sqlParameter.Value = companypathinfo.Path;
					sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
					sqlParameter.Value = companypathinfo.DefaultOrNot;
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
				DBConnectionForPDB.sqlcon.Close();
			}
		}

		public bool CompanyPathCheckExistnaceOfId(string strId)
		{
			bool flag = false;
			try
			{
				if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
				{
					DBConnectionForPDB.sqlcon.Open();
				}
				SqlCommand sqlCommand = new SqlCommand("CompanyPathCheckExistnaceOfId", DBConnectionForPDB.sqlcon)
				{
					CommandType = CommandType.StoredProcedure
				};
				SqlParameter sqlParameter = new SqlParameter();
				sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar).Value = strId;
				flag = (sqlCommand.ExecuteScalar() != null ? true : false);
				DBConnectionForPDB.sqlcon.Close();
			}
			catch (Exception exception)
			{
			}
			return flag;
		}

		public string CompanyPathCheckExistnaceOfName(string strComapanyName)
		{
			string str = "";
			try
			{
				try
				{
					if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
					{
						DBConnectionForPDB.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CompanyPathCheckExistnaceOfName", DBConnectionForPDB.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@companyName", SqlDbType.VarChar).Value = strComapanyName;
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
				DBConnectionForPDB.sqlcon.Close();
			}
			return str;
		}

		public void CompanyPathDeleteByCompanyId(string CompanyId)
		{
			try
			{
				try
				{
					if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
					{
						DBConnectionForPDB.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CompanyPathDelete", DBConnectionForPDB.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar).Value = CompanyId;
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
				DBConnectionForPDB.sqlcon.Close();
			}
		}

		public void CompanyPathEdit(CompanyPathInfo companypathinfo)
		{
			try
			{
				try
				{
					if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
					{
						DBConnectionForPDB.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CompanyPathEdit", DBConnectionForPDB.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar);
					sqlParameter.Value = companypathinfo.CompanyId;
					sqlParameter = sqlCommand.Parameters.Add("@companyName", SqlDbType.VarChar);
					sqlParameter.Value = companypathinfo.CompanyName;
					sqlParameter = sqlCommand.Parameters.Add("@path", SqlDbType.VarChar);
					sqlParameter.Value = companypathinfo.Path;
					sqlParameter = sqlCommand.Parameters.Add("@defaultOrNot", SqlDbType.Bit);
					sqlParameter.Value = companypathinfo.DefaultOrNot;
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
				DBConnectionForPDB.sqlcon.Close();
			}
		}

		public CompanyPathInfo CompanyPathView(string companyId)
		{
			CompanyPathInfo companyPathInfo = new CompanyPathInfo();
			try
			{
				try
				{
					if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
					{
						DBConnectionForPDB.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("CompanyPathView", DBConnectionForPDB.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@companyId", SqlDbType.VarChar).Value = companyId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						companyPathInfo.CompanyId = sqlDataReader[0].ToString();
						companyPathInfo.CompanyName = sqlDataReader[1].ToString();
						companyPathInfo.Path = sqlDataReader[2].ToString();
						companyPathInfo.DefaultOrNot = bool.Parse(sqlDataReader[3].ToString());
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
				DBConnectionForPDB.sqlcon.Close();
			}
			return companyPathInfo;
		}

		public DataTable CompanyPathViewAll()
		{
			DataTable dataTable = new DataTable();
			try
			{
				try
				{
					if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
					{
						DBConnectionForPDB.sqlcon.Open();
					}
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CompanyPathViewAll", DBConnectionForPDB.sqlcon);
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
				DBConnectionForPDB.sqlcon.Close();
			}
			return dataTable;
		}

		public string GetCompanyId()
		{
			string str;
			string str1 = "";
			string str2 = "";
			try
			{
				if (DBConnectionForPDB.sqlcon.State == ConnectionState.Closed)
				{
					DBConnectionForPDB.sqlcon.Open();
				}
				SqlCommand sqlCommand = new SqlCommand("CompanyPathCount", DBConnectionForPDB.sqlcon)
				{
					CommandType = CommandType.StoredProcedure
				};
				object obj = sqlCommand.ExecuteScalar();
				str = ((obj == null ? false : !(obj.ToString() == "0")) ? obj.ToString() : "1");
				DBConnectionForPDB.sqlcon.Close();
				bool flag = false;
				//int length = str1.ToString().Length;
				//if (length < 2)
				//{
				//	str2 = string.Concat("COMP", str1.ToString().PadLeft(4, '0'));
				//}
				//else if (length < 3)
				//{
				//	str2 = string.Concat("COMP", str1.ToString().PadLeft(3, '0'));
				//}
				//else if (length < 4)
				//{
				//	str2 = string.Concat("COMP", str1.ToString().PadLeft(2, '0'));
				//}
				flag = this.CompanyPathCheckExistnaceOfId(str);
				//decimal num = decimal.Parse(str1);
				//while (flag)
				//{
				//	num = num++;
				//	flag = false;
				//	length = num.ToString().Length;
				//	if (length < 2)
				//	{
				//		str2 = string.Concat("COMP", num.ToString().PadLeft(4, '0'));
				//	}
				//	else if (length >= 3)
				//	{
				//		str2 = (length >= 4 ? string.Concat("COMP", num.ToString()) : string.Concat("COMP", num.ToString().PadLeft(2, '0')));
				//	}
				//	else
				//	{
				//		str2 = string.Concat("COMP", num.ToString().PadLeft(3, '0'));
				//	}
				//	flag = this.CompanyPathCheckExistnaceOfId(str2);
				//}
				//str = str2;
				return str;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			str = str2;
			return str;
		}
	}
}