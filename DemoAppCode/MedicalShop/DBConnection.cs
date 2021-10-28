using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using System.Configuration;

namespace MedicalShop
{
	public class DBConnection
	{
		protected static SqlConnection sqlcon;
        private string conString;
		static DBConnection()
		{
			DBConnection.sqlcon = new SqlConnection();
		}

		public DBConnection()
		{
			if (DBConnection.sqlcon.State == ConnectionState.Open)
			{
				DBConnection.sqlcon.Close();
			}
			if (CompanyInfo._companyId != null)
			{


                conString = ConfigurationSettings.AppSettings["Pharmacy"].ToString();
                DBConnection.sqlcon = new SqlConnection(conString);
				DBConnection.sqlcon.Open();
			}
		}

        public object ConfigurationManager { get; private set; }
    }
}