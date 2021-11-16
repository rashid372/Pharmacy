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
    public partial class frmVendorProducts : Form
    {
		private MedicalShop.ProductInfo ProductInfo = new MedicalShop.ProductInfo();

		private MedicalShop.ProductSP ProductSP = new MedicalShop.ProductSP();

		private MedicalShop.ProductBatchInfo ProductBatchInfo = new MedicalShop.ProductBatchInfo();

		private MedicalShop.ProductBatchSP ProductBatchSP = new MedicalShop.ProductBatchSP();

		private MedicalShop.ProductGroupInfo ProductGroupInfo = new MedicalShop.ProductGroupInfo();

		private MedicalShop.ProductGroupSP ProductGroupSP = new MedicalShop.ProductGroupSP();

		private MedicalShop.ManufacturerInfo ManufacturerInfo = new MedicalShop.ManufacturerInfo();

		private MedicalShop.ManufacturerSP ManufacturerSP = new MedicalShop.ManufacturerSP();

		private MedicalShop.ShelfInfo ShelfInfo = new MedicalShop.ShelfInfo();

		private MedicalShop.ShelfSP ShelfSP = new MedicalShop.ShelfSP();

		private MedicalShop.GenericNameInfo GenericNameInfo = new MedicalShop.GenericNameInfo();

		private MedicalShop.GenericNameSP GenericNameSP = new MedicalShop.GenericNameSP();

		private MedicalShop.UnitInfo UnitInfo = new MedicalShop.UnitInfo();

		private MedicalShop.UnitSP UnitSP = new MedicalShop.UnitSP();
		public frmVendorProducts()
        {
            InitializeComponent();
        }
		public void FillRegister()
		{
			try
			{
				DataTable dataTable = new DataTable();
				if (this.cmbSearchBy.Text == "All")
				{
					dataTable = this.ProductSP.ProductViewAll();
					var data = dataTable.AsEnumerable().Select
					(r => new
					{
						Code = r.Field<string>("id"),
						Name = r.Field<string>("name")
					}).ToList();
					dgdSearch.DataSource = data;
				}
				else if (this.cmbSearchBy.Text == "Product Group")
				{
					if (this.cmbSearch.SelectedValue != null)
						dataTable = this.ProductGroupSP.ProductVewByProductGroupId(this.cmbSearch.SelectedValue.ToString());
					var data = dataTable.AsEnumerable().Select
						(r => new
						{
							Code = r.Field<string>("productId"),
							Name = r.Field<string>("productName")
						}).ToList();
											dgdSearch.DataSource = data;
					this.lblSearch.Text = "Product Group";
				}
				else if (this.cmbSearchBy.Text == "Generic Name")
				{
					if (this.cmbSearch.SelectedValue != null)
						dataTable = this.GenericNameSP.ProductViewByGenericNameId(this.cmbSearch.SelectedValue.ToString());
					var data = dataTable.AsEnumerable().Select
					(r => new
					{
						Code = r.Field<string>("productId"),
						Name = r.Field<string>("productName")
					}).ToList();
										dgdSearch.DataSource = data;
					this.lblSearch.Text = "Generic Name";
				}
				else if (this.cmbSearchBy.Text == "Shelf")
				{
					if (this.cmbSearch.SelectedValue != null)
						dataTable = this.ShelfSP.ProductViewByShelfId(this.cmbSearch.SelectedValue.ToString());
					var data = dataTable.AsEnumerable().Select
					(r => new
					{
						Code = r.Field<string>("productId"),
						Name = r.Field<string>("productName")
					}).ToList();
										dgdSearch.DataSource = data;

					this.lblSearch.Text = "Shelf";
				}
				else if (this.cmbSearchBy.Text == "Medicine For")
				{
					dataTable = this.ProductSP.ProductViewByMedicineFor(this.cmbSearch.Text);
					var data = dataTable.AsEnumerable().Select
						(r => new
						{
							Code = r.Field<string>("id"),
							Name = r.Field<string>("name")
						}).ToList();
											dgdSearch.DataSource = data;
					this.lblSearch.Text = "Medicine For";
				}
				else if (this.cmbSearchBy.Text == "Manufacture")
				{
					if (this.cmbSearch.SelectedValue != null)
					{
						dataTable = this.ManufacturerSP.ProductViewByManufactureId(this.cmbSearch.SelectedValue.ToString());
					var	data = dataTable.AsEnumerable().Select
				(r => new
				{
					Code = r.Field<string>("productId"),
					Name = r.Field<string>("productName")
				}).ToList();
						dgdSearch.DataSource = data;

					}
					this.lblSearch.Text = "Manufacture";
				}
				//this.dgdSearch.Rows.Clear();
			
				//int str = 0;
				//foreach (DataRow row in dataTable.Rows)
				//{
				//	this.dgdSearch.Rows.Add();
				//	this.dgdSearch.Rows[str].Cells[0].Value = false;
				//	this.dgdSearch.Rows[str].Cells[1].Value = row.ItemArray[0].ToString();
				//	this.dgdSearch.Rows[str].Cells[2].Value = row.ItemArray[1].ToString();
				//	str++;
				//}
				this.dgdSearch.ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchBy_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			try
			{
				if (this.cmbSearchBy.Text == "Product Group")
				{
					MedicalShop.ProductGroupSP productGroupSP = new MedicalShop.ProductGroupSP();
					DataTable dataTable = new DataTable();
					dataTable = productGroupSP.ProductGroupViewAll();
					this.cmbSearch.DataSource = dataTable;
					this.cmbSearch.DisplayMember = "Name";
					this.cmbSearch.ValueMember = "ID";
					this.cmbSearch.SelectedValue = "1";
				}
				else if (this.cmbSearchBy.Text == "Generic Name")
				{
					MedicalShop.GenericNameSP genericNameSP = new MedicalShop.GenericNameSP();
					DataTable dataTable1 = new DataTable();
					dataTable1 = genericNameSP.GenericNameViewAll();
					this.cmbSearch.DataSource = dataTable1;
					this.cmbSearch.DisplayMember = "Name";
					this.cmbSearch.ValueMember = "ID";
					this.cmbSearch.SelectedValue = "0";
				}
				else if (this.cmbSearchBy.Text == "Shelf")
				{
					MedicalShop.ShelfSP shelfSP = new MedicalShop.ShelfSP();
					DataTable dataTable2 = new DataTable();
					dataTable2 = shelfSP.ShelfViewAll();
					this.cmbSearch.DataSource = dataTable2;
					this.cmbSearch.DisplayMember = "Shelf Name";
					this.cmbSearch.ValueMember = "Shelf Id";
					this.cmbSearch.SelectedValue = "0";
				}
				else if (this.cmbSearchBy.Text == "Medicine For")
				{
					MedicalShop.ProductSP productSP = new MedicalShop.ProductSP();
					DataTable dataTable3 = new DataTable();
					dataTable3 = productSP.MedicineForViewAll();
					this.cmbSearch.DataSource = dataTable3;
					this.cmbSearch.DisplayMember = "MedicineFor";
				}
				else if (!(this.cmbSearchBy.Text == "Manufacture"))
				{
					this.cmbSearch.SelectedIndex = -1;
				}
				else
				{
					MedicalShop.ManufacturerSP manufacturerSP = new MedicalShop.ManufacturerSP();
					DataTable dataTable4 = new DataTable();
					dataTable4 = manufacturerSP.ManufacturerViewAll();
					this.cmbSearch.DataSource = dataTable4;
					this.cmbSearch.DisplayMember = "Name";
					this.cmbSearch.ValueMember = "ID";
					this.cmbSearch.SelectedValue = "0";
				}
				this.FillRegister();
				this.txtSearchFor.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmVendorProducts_Load(object sender, EventArgs e)
		{
			try
			{
				this.FillComboVender();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void clear()
		{
			try
			{
				this.cmbSearchBy.Text = "All";
				this.FillRegister();
				this.cmbVendor.SelectedValue = 0;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillComboVender()
		{
			try
			{
				VendorSP vendorSP = new VendorSP();
				DataTable dataTable = new DataTable();
				dataTable = vendorSP.VendorViewAll();
				if (dataTable.Rows.Count > 0)
				{
					this.cmbVendor.DataSource = dataTable;
					this.cmbVendor.ValueMember = "Vendor Id";
					this.cmbVendor.DisplayMember = "Vendor Name";
					this.cmbVendor.SelectedValue = 0;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (!(this.cmbSearchBy.Text != "All"))
				{
					this.lblSearch.Enabled = false;
					this.cmbSearch.Enabled = false;
					this.cmbSearch.SelectedIndex = -1;
					this.lblSearch.Text = "";
				}
				else
				{
					this.cmbSearch.Enabled = true;
					this.lblSearch.Enabled = true;
				}
				this.FillRegister();
				this.txtSearchFor.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			foreach (DataGridViewRow row in dgdSearch.Rows)
			{
				if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true)) //3 is the column number of checkbox
				{
					row.Selected = true;
					row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
				}
				else
					row.Selected = false;
			}
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {
			List<VendorProductResponse> vendorProductList = new List<VendorProductResponse>();
			dbVendorProducts.DataSource = vendorProductList;

		}
    }
}
