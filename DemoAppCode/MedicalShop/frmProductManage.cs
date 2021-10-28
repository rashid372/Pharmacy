using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MedicalShopBackEnd;

namespace MedicalShop
{
    public partial class frmProductManage : Form
    {

        private MedicalShop.ProductSP ProductSP = new MedicalShop.ProductSP();
        public frmProductManage()
        {
            InitializeComponent();
        }

        private void ddlManufacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlManufacture.SelectedValue != null)
            {
                grdProducts.DataSource = Accessor.ProductViewAllByManufactureId(ddlManufacture.SelectedValue.ToString());
           }
            
        }
        public void FillRegister()
        {
            try
            {
                ddlManufacture.DataSource = Accessor.ManufacturereViewAll();
                ddlManufacture.DisplayMember = "Name";
                ddlManufacture.ValueMember = "ID";
                DataTable dataTable = new DataTable();
                if (this.ddlManufacture.Text == "")
                {
                    dataTable = this.ProductSP.ProductViewAll();
                }

                this.grdProducts.Rows.Clear();
                this.grdProducts.DataSource = dataTable;
                int str = 0;
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    this.grdProducts.Rows.Add();
                //    this.grdProducts.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
                //    this.grdProducts.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
                //    str++;
                //}
                this.grdProducts.ClearSelection();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void frmProductManage_Load(object sender, EventArgs e)
        {
            FillRegister();
        }
    }
}
