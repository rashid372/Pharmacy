using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class DBConnectionForPDB
	{
		protected static SqlConnection sqlcon;
        private string conString;

        static DBConnectionForPDB()
		{
			DBConnectionForPDB.sqlcon = new SqlConnection();
		}

		public DBConnectionForPDB()
		{
			if (DBConnectionForPDB.sqlcon.State == ConnectionState.Open)
			{
				DBConnectionForPDB.sqlcon.Close();
			}
			if (CompanyInfo._companyId != null)
			{
                conString = ConfigurationSettings.AppSettings["Pharmacy"].ToString();
                DBConnectionForPDB.sqlcon = new SqlConnection(conString);
                DBConnectionForPDB.sqlcon.Open();
			}
		}
	}
}