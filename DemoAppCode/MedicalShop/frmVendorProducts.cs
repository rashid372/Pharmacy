using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


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
		List<VendorProductResponse> vendorProductList = new List<VendorProductResponse>();
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
		public void FillRegister(string productName)
		{
			try
			{
				DataTable dataTable = new DataTable();
				if (this.cmbSearchBy.Text == "All")
				{
					dataTable = this.ProductSP.ProductViewAll();
					var data = dataTable.AsEnumerable().Where(x => x.Field<string>("name").ToUpper().Contains(productName.ToUpper())).Select
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
					var data = dataTable.AsEnumerable().Where(x => x.Field<string>("productName").ToUpper().Contains(productName.ToUpper())).Select
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
					var data = dataTable.AsEnumerable().Where(x => x.Field<string>("productName").ToUpper().Contains(productName.ToUpper())).Select
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
					var data = dataTable.AsEnumerable().Where(x => x.Field<string>("productName").ToUpper().Contains(productName.ToUpper())).Select
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
					var data = dataTable.AsEnumerable().Where(x => x.Field<string>("name").ToUpper().Contains(productName.ToUpper())).Select
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
						var data = dataTable.AsEnumerable().Where(x => x.Field<string>("productName").ToUpper().Contains(productName.ToUpper())).Select
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
			
			if (this.cmbVendor.SelectedValue == null)
			{

				MessageBox.Show("Select vendor", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.cmbVendor.Focus();
				return;
			}
			foreach (DataGridViewRow row in (IEnumerable)this.dgdSearch.Rows)
			{

				if (row.Cells[0].Value != null)
					{
					bool isSelected;
					Boolean.TryParse(row.Cells[0].Value.ToString(), out isSelected);
					if(isSelected == true)
                    {
						VendorProductResponse vendorProductResponse = new VendorProductResponse();
						if (row.Cells[1].Value != null)
						{
							vendorProductResponse.ProductId = row.Cells[1].Value.ToString();

						}
						if (row.Cells[2].Value != null)
						{
							vendorProductResponse.ProductName = row.Cells[2].Value.ToString();

						}
						vendorProductResponse.VendorId = this.cmbVendor.SelectedValue.ToString();
						vendorProductResponse.VendorName = this.cmbVendor.Text;
						vendorProductResponse.PurchaseRate = 0;
						var vndorProduct = from vp in vendorProductList
										   where vp.ProductId == vendorProductResponse.ProductId
										   select vp;
						if (vndorProduct.Count() <=0)
                        {
							VendorProductsSP vendorProductsSP = new VendorProductsSP();
						//	vendorProductList.Add(vendorProductResponse);
							vendorProductsSP.VendorProductAdd(new VendorProductsInfo { ProductId = vendorProductResponse.ProductId, VendorId = vendorProductResponse.VendorId, PurchaseRate = vendorProductResponse.PurchaseRate, CreateBy = "1" });
						}
						
					}


				}
			}
			//dbVendorProducts.DataSource = null;
			////dbVendorProducts.AutoGenerateColumns = false;
			//dbVendorProducts.DataSource = vendorProductList;
			//dbVendorProducts.Refresh();
			this.ViewVendorProducts(this.cmbVendor.SelectedValue.ToString());

		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				DataTable dataTable = new DataTable();

				if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this.SaveFunction();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		public void SaveFunction()
		{
            try
            {
                if (this.SaveToVendorProduct())
                {
					MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.clear();
					this.ViewVendorProducts(this.cmbVendor.SelectedValue.ToString());
				}
            }
            catch (Exception exp)
            {

				Exception exception = exp;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

			public bool SaveToVendorProduct()
		{
			bool status = false;
            try
            {
				VendorProductsSP vendorProductsSP = new VendorProductsSP();
                foreach (var vendorProduct in vendorProductList)
                {
					vendorProductsSP.VendorProductAdd(new VendorProductsInfo { ProductId = vendorProduct.ProductId, VendorId=vendorProduct.VendorId,PurchaseRate=vendorProduct.PurchaseRate,CreateBy="1" });

				}

				status = true;
            }
            catch (Exception exp)
            {

				Exception exception = exp;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return status;
		}

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {

			if (this.cmbVendor.SelectedValue != null)
			{
				int isSelected;
				int.TryParse(this.cmbVendor.SelectedValue.ToString(), out isSelected);
				if (isSelected > 0)
                {
					this.ViewVendorProducts(this.cmbVendor.SelectedValue.ToString());

				}
			}


		}
		private void ViewVendorProducts(string vendorId)
        {
			VendorProductsSP vendorProductsSP = new VendorProductsSP();
			DataTable dataTable = new DataTable();
			dataTable = vendorProductsSP.VendorProductViewAllByVendorId(vendorId);
			vendorProductList = dataTable.AsEnumerable().Select
	   (r => new VendorProductResponse
	   {
		   PurchaseRate = r.Field<decimal>("vendorPurchaseRate"),
		   ProductName = r.Field<string>("productName"),
		   ProductPurchaseRate = r.Field<decimal>("productPurchaseRate"),
		   VendorName = r.Field<string>("vendorName"),
		   ProductId = r.Field<string>("productId"),
		   VendorId = r.Field<string>("vendorId")
	   }).ToList();
			this.dbVendorProducts.DataSource = vendorProductList;

		}
		private void ViewVendorProductsByProductName(string vendorId,string productName)
		{
			VendorProductsSP vendorProductsSP = new VendorProductsSP();
			DataTable dataTable = new DataTable();
			dataTable = vendorProductsSP.VendorProductViewAllByProductName(vendorId, productName);
			vendorProductList = dataTable.AsEnumerable().Select
	   (r => new VendorProductResponse
	   {
		   PurchaseRate = r.Field<decimal>("vendorPurchaseRate"),
		   ProductName = r.Field<string>("productName"),
		   ProductPurchaseRate = r.Field<decimal>("productPurchaseRate"),
		   VendorName = r.Field<string>("vendorName"),
		   ProductId = r.Field<string>("productId"),
		   VendorId = r.Field<string>("vendorId")
	   }).ToList();
			this.dbVendorProducts.DataSource = vendorProductList;

		}
		private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (e.ColumnIndex == senderGrid.Columns["delete"].Index && e.RowIndex >= 0)
			{
				VendorProductsSP vendorProductsSP = new VendorProductsSP();
				if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				{
					VendorProductResponse selected = senderGrid.Rows[e.RowIndex].DataBoundItem as VendorProductResponse;
					vendorProductsSP.VendorProductDelete(selected.VendorId, selected.ProductId);
					this.ViewVendorProducts(selected.VendorId);
				}
			}
		}
        private void txtVendorProductFilter_TextChanged(object sender, EventArgs e)
        {
			if(txtVendorProductFilter.Text != "")
            {
				ViewVendorProductsByProductName(cmbVendor.SelectedValue.ToString(), txtVendorProductFilter.Text);

            }else
            {
				ViewVendorProducts(cmbVendor.SelectedValue.ToString());
			}
        }

        private void txtSearchFor_TextChanged(object sender, EventArgs e)
        {
			if(txtSearchFor.Text != "")
            {
				FillRegister(txtSearchFor.Text);

            }
            else
            {
				FillRegister();
			}
        }
    }
}
