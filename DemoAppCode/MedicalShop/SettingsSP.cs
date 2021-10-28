using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class SettingsSP : DBConnection
	{
		public SettingsSP()
		{
		}

		public SettingsInfo SettingsView(string settingsId)
		{
			SettingsInfo settingsInfo = new SettingsInfo();
			try
			{
				try
				{
					if (DBConnection.sqlcon.State == ConnectionState.Closed)
					{
						DBConnection.sqlcon.Open();
					}
					SqlCommand sqlCommand = new SqlCommand("SettingsView", DBConnection.sqlcon)
					{
						CommandType = CommandType.StoredProcedure
					};
					SqlParameter sqlParameter = new SqlParameter();
					sqlCommand.Parameters.Add("@settingsId", SqlDbType.VarChar).Value = settingsId;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						settingsInfo.SettingsId = sqlDataReader[0].ToString();
						settingsInfo.AutomaticProductIdGeneration = bool.Parse(sqlDataReader[1].ToString());
						settingsInfo.NegativeStockAlertStatus = sqlDataReader[2].ToString();
						settingsInfo.ExpiryProductTransactionStatus = sqlDataReader[3].ToString();
						settingsInfo.ExpiryReminderWithin = sqlDataReader[4].ToString();
						settingsInfo.Description = sqlDataReader[5].ToString();
						settingsInfo.ExpiryReminderNeeded = bool.Parse(sqlDataReader[6].ToString());
						settingsInfo.LowStockAlertStatus = bool.Parse(sqlDataReader[7].ToString());
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
			return settingsInfo;
		}

        public void SettingsAdd( SettingsInfo settinginfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("SettingsAdd", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@settingsId", SqlDbType.VarChar);
                    sqlParameter.Value =settinginfo.SettingsId;
                    sqlParameter = sqlCommand.Parameters.Add("@automaticProductIdGeneration", SqlDbType.Bit);
                    sqlParameter.Value =settinginfo.AutomaticProductIdGeneration;
                    sqlParameter = sqlCommand.Parameters.Add("@negativeStockAlertStatus", SqlDbType.VarChar);
                    sqlParameter.Value =settinginfo.NegativeStockAlertStatus;

                    sqlParameter = sqlCommand.Parameters.Add("@expiryProductTransactionStatus", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.ExpiryProductTransactionStatus;
                    sqlParameter = sqlCommand.Parameters.Add("@expiryReminderWithin", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.ExpiryReminderWithin;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@expiryReminderNeeded", SqlDbType.Bit);
                    sqlParameter.Value = settinginfo.ExpiryReminderNeeded;
                    sqlParameter = sqlCommand.Parameters.Add("@lowStockAlertStatus", SqlDbType.Bit);
                    sqlParameter.Value = settinginfo.LowStockAlertStatus;

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

        public void SettingsDelete(string settingsId)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("SettingsDelete", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@settingsId", SqlDbType.VarChar).Value = settingsId;
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

       
        public void SettingsEdit(SettingsInfo settinginfo)
        {
            try
            {
                try
                {
                    if (DBConnection.sqlcon.State == ConnectionState.Closed)
                    {
                        DBConnection.sqlcon.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("SettingsEdit", DBConnection.sqlcon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter = sqlCommand.Parameters.Add("@settingsId", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.SettingsId;
                    sqlParameter = sqlCommand.Parameters.Add("@automaticProductIdGeneration", SqlDbType.Bit);
                    sqlParameter.Value = settinginfo.AutomaticProductIdGeneration;
                    sqlParameter = sqlCommand.Parameters.Add("@negativeStockAlertStatus", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.NegativeStockAlertStatus;

                    sqlParameter = sqlCommand.Parameters.Add("@expiryProductTransactionStatus", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.ExpiryProductTransactionStatus;
                    sqlParameter = sqlCommand.Parameters.Add("@expiryReminderWithin", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.ExpiryReminderWithin;
                    sqlParameter = sqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                    sqlParameter.Value = settinginfo.Description;
                    sqlParameter = sqlCommand.Parameters.Add("@expiryReminderNeeded", SqlDbType.Bit);
                    sqlParameter.Value = settinginfo.ExpiryReminderNeeded;
                    sqlParameter = sqlCommand.Parameters.Add("@lowStockAlertStatus", SqlDbType.Bit);
                    sqlParameter.Value = settinginfo.LowStockAlertStatus;
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