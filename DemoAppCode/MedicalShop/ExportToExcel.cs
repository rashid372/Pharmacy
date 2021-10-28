using System;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class ExportToExcel
	{
		public ExportToExcel()
		{
		}

		public void ExportExcel(DataGridView dgv, string rptName, int inFirstRow, int inFirstCol, string Format)
		{
			MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}
}