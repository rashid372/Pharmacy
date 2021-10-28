using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalShop
{
    public partial class AdvanceReport : Form
    {
        public AdvanceReport()
        {
            InitializeComponent();
        }

        private void AdvanceReport_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
