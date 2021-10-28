using System;
using System.Configuration;
using System.Windows.Forms;

namespace MedicalShop
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmPurchaseRateWindow("7314"));
            string mac = CryptoEngine.Decrypt(ConfigurationSettings.AppSettings["Licence"].ToString());
            String firstMacAddress = CryptoEngine.GetMACAddress(mac);
            if (!CryptoEngine.Decrypt(ConfigurationSettings.AppSettings["Licence"].ToString()).Equals(firstMacAddress))
            {
                CryptoEngine.SendLicenceForValidation();
                MessageBox.Show("Licence is required.Please contact admin (+92 334-7633003)");
                Application.Exit();
            }
            else
            {
                Application.Run(new MDIMedicalShop());
            }

        }
	}
}