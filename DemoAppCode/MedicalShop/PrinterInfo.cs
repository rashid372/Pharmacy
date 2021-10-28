using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
 public static class PrinterInfo
    {
         static System.Windows.Forms.PrintDialog prnDialog=new System.Windows.Forms.PrintDialog(); 

        public static string ActivePrinterName
        {
            get
            {
                return prnDialog.PrinterSettings.PrinterName;
            }
        }
    }
}
