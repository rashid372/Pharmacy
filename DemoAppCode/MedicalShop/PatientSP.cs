using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class PatientSP : DBConnection
	{
		public PatientSP()
		{
		}

		public bool PatientCheckExistanceOfName(string strPatientName)
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
					SqlCommand sqlCommand = new SqlCommand("PatientCheckExistanceOfName", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = strPatientName;
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

		public void PatientEdit(PatientInfo patientinfo)
		{
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PatientEdit", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlCommand.Parameters.Add("@patientId", SqlDbType.VarChar);
					sqlParameter.Value = patientinfo.PatientId;
					sqlParameter = sqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
					sqlParameter.Value = patientinfo.Name;
					sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
					sqlParameter.Value = patientinfo.Address;
					sqlParameter = sqlCommand.Parameters.Add("@mobileNo", SqlDbType.VarChar);
					sqlParameter.Value = patientinfo.MobileNo;
					sqlParameter = sqlCommand.Parameters.Add("@phoneNo", SqlDbType.VarChar);
					sqlParameter.Value = patientinfo.PhoneNo;
					sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
					sqlParameter.Value = patientinfo.Description;
					sqlParameter = sqlCommand.Parameters.Add("@dailyCustomerOrNot", SqlDbType.Bit);
					sqlParameter.Value = patientinfo.DailyCustomerOrNot;
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

		public PatientInfo PatientView(string patientId)
		{
			PatientInfo patientInfo = new PatientInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("PatientView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@patientId", SqlDbType.VarChar).Value = patientId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						patientInfo.PatientId = sqlDataReader[0].ToString();
						patientInfo.Name = sqlDataReader[1].ToString();
						patientInfo.Address = sqlDataReader[2].ToString();
						patientInfo.MobileNo = sqlDataReader[3].ToString();
						patientInfo.PhoneNo = sqlDataReader[4].ToString();
						patientInfo.Description = sqlDataReader[5].ToString();
						patientInfo.DailyCustomerOrNot = bool.Parse(sqlDataReader[6].ToString());
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
			return patientInfo;
		}

		public DataTable PatientViewAll()
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PatientViewAll", DBConnection.sqlcon);
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
        public DataTable PatientViewAllByInvoice()
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
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PatientViewAllbyInvoice", DBConnection.sqlcon);
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

        public DataTable PatientViewAllByStatus(bool status)
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
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PatientViewAllByStatus", DBConnection.sqlcon);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlParameter sqlParameter = new SqlParameter();
					sqlParameter = sqlDataAdapter.SelectCommand.Parameters.Add("@dailyCustomerOrNot", SqlDbType.Bit);
					sqlParameter.Value = status;
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

        public Int64 PatientAdd(PatientInfo patientinfo)
        {
            Int64 id = 0;
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PatientAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@patientId", SqlDbType.VarChar);
                    sqlParameter.Value = patientinfo.PatientId;
                    sqlParameter = sqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                    sqlParameter.Value = patientinfo.Name;
                    sqlParameter = sqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                    sqlParameter.Value = patientinfo.Address;
                    sqlParameter = sqlCommand.Parameters.Add("@mobileNo", SqlDbType.VarChar);
                    sqlParameter.Value = patientinfo.MobileNo;
                    sqlParameter = sqlCommand.Parameters.Add("@phoneNo", SqlDbType.VarChar);
                    sqlParameter.Value = patientinfo.PhoneNo;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = patientinfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@dailyCustomerOrNot", SqlDbType.Bit);
                    sqlParameter.Value = patientinfo.DailyCustomerOrNot;

                  var result=  sqlCommand.ExecuteScalar();
                    id = Int64.Parse(result.ToString());
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
            return id;
        }

      

        public void PatientDelete(string patientId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("PatientDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@patientId", SqlDbType.VarChar).Value = patientId;
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