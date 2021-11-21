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
    public partial class frmPurchaseOrder : Form
    {
		List<PurchaseOrderInfo> purchaseOrderList = new List<PurchaseOrderInfo>();
		List<PurchaseOrderDetailsInfo> purchaseOrderDetailsList = new List<PurchaseOrderDetailsInfo>();
		private long PurchaseOrderMasterId;
		public frmPurchaseOrder()
        {
            InitializeComponent();
        }
		public void clear()
		{
			try
			{


			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	public void FillPurchaseTitle()
	{
		try
		{
				PuchaseOrderMasterSP puchaseOrderMasterSP = new PuchaseOrderMasterSP();
				DataTable data = puchaseOrderMasterSP.PuchaseOrderMasterViewByVendorIdDate(cmbVendor.SelectedValue.ToString(), DateTime.Now);
				if (data.Rows.Count > 0)
				{
					this.cmbPurchaseTitles.DataSource = data;
					this.cmbPurchaseTitles.ValueMember = "purchaseOrderMasterId";
					this.cmbPurchaseTitles.DisplayMember = "puchaseOrderTitle";

				}
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

		private void frmPurchaseOrder_Load(object sender, EventArgs e)
		{
			try
			{
				this.FillComboVender();
				this.FillPurchaseTitle();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
            {
				if (this.cmbVendor.SelectedValue != null)
				{
					int isSelected;
					int.TryParse(this.cmbVendor.SelectedValue.ToString(), out isSelected);
					if (isSelected > 0)
					{
						this.ViewPurchaseOrder(this.cmbVendor.SelectedValue.ToString());
						ViewPurchaseOrderDetails(this.cmbVendor.SelectedValue.ToString());

					}
				}

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}


		}
		private void ViewPurchaseOrder(string vendorId)
		{
            try
            {
				PurchaseOrderSP purchaseOrderSP = new PurchaseOrderSP();
				DataTable dataTable = new DataTable();
				dataTable = purchaseOrderSP.PurchaseOrderViewAllByVendorId(vendorId);
				purchaseOrderList = dataTable.AsEnumerable().Select
		   (r => new PurchaseOrderInfo
		   {
			   VendorRate = r.Field<decimal>("vendorPurchaseRate"),
			   ProductName = r.Field<string>("productName"),
			   ProductRate = r.Field<decimal>("productPurchaseRate"),
			   Stock = r.Field<decimal>("stock"),
			   RunningIndex = r.Field<decimal>("RunningIndex"),
			   ProductId = r.Field<string>("productId"),
			   VendorId = r.Field<string>("vendorId")
		   }).ToList();
				lblProductCount.Text = purchaseOrderList.Count().ToString();
				this.dgPurchaseOrder.DataSource = purchaseOrderList;

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}


		}
		private void ViewPurchaseOrderDetails(string vendorId)
		{
            try
            {
				PuchaseOrderDetailsSP puchaseOrderDetailsSP = new PuchaseOrderDetailsSP();
				DataTable dataTable = new DataTable();
				dataTable = puchaseOrderDetailsSP.PurchaseOrderDetailsViewAllByVendorId(vendorId);
				purchaseOrderDetailsList = dataTable.AsEnumerable().Select
		   (r => new PurchaseOrderDetailsInfo
		   {
			   ProductName = r.Field<string>("productName"),
			   ProductId = r.Field<string>("productId"),
			   VendorId = r.Field<string>("vendorId"),
			   PurchaseOrderMasterId = r.Field<long>("purchaseOrderMasterId"),
			   PurchaseOrderDetailsId = r.Field<long>("purchaseOrderDetailsId"),
			   PuchaseOrderTitle = r.Field<string>("puchaseOrderTitle"),
			   Discount = r.Field<double>("discount"),
			   Qty = r.Field<decimal>("qty"),
			   FreeQty = r.Field<decimal>("freeQty"),
			   Rate = r.Field<decimal>("rate")

		   }).ToList();
				if (purchaseOrderDetailsList.Count() > 0)
				{
					cmbPurchaseTitles.Text = purchaseOrderDetailsList.FirstOrDefault().PuchaseOrderTitle;

				}

				this.dgOrderedItems.DataSource = purchaseOrderDetailsList;

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}


		}
		private bool SavePurchaseOrderMaster(PuchaseOrderMasterInfo puchaseOrderMasterInfo)
        {
			bool status = false;
            try
            {
				PuchaseOrderMasterSP puchaseOrderMasterSP = new PuchaseOrderMasterSP();
				puchaseOrderMasterSP.PuchaseOrderMasterAdd(puchaseOrderMasterInfo);
				status = true;

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return status;
        }
		private bool SavePurchaseOrderDetails(PurchaseOrderDetailsInfo purchaseOrderDetailsInfo)
        {
			bool status = false;
			try
            {
				PuchaseOrderDetailsSP puchaseOrderDetailsSP = new PuchaseOrderDetailsSP();
				puchaseOrderDetailsSP.PurchaseOrderDetailsAdd(purchaseOrderDetailsInfo);

            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return status;
		}
		private bool EditPurchaseOrderDetails(PurchaseOrderDetailsInfo purchaseOrderDetailsInfo)
		{
			bool status = false;
			try
			{
				PuchaseOrderDetailsSP puchaseOrderDetailsSP = new PuchaseOrderDetailsSP();
				puchaseOrderDetailsSP.PurchaseOrderDetailsEdit(purchaseOrderDetailsInfo);

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return status;
		}

		private void txtOrderItemFilter_TextChanged(object sender, EventArgs e)
		{
			if (txtOrderItemFilter.Text != "")
			{
				List<PurchaseOrderInfo> filterpurchaseOrderList= purchaseOrderList.Where(x => x.ProductName.ToUpper().Contains(txtOrderItemFilter.Text.ToUpper())).ToList();
				dgPurchaseOrder.DataSource = filterpurchaseOrderList;
				lblProductCount.Text = filterpurchaseOrderList.Count().ToString();


			}
            else
            {
				dgPurchaseOrder.DataSource = purchaseOrderList;
				lblProductCount.Text = purchaseOrderList.Count().ToString();

			}
		}
		private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (e.ColumnIndex == senderGrid.Columns["select"].Index && e.RowIndex >= 0)
			{
				PurchaseOrderInfo selected = senderGrid.Rows[e.RowIndex].DataBoundItem as PurchaseOrderInfo;
				if(cmbPurchaseTitles.Text == "")
                {
					SavePurchaseOrderMaster(new PuchaseOrderMasterInfo { 
					CreatedBy="1",
					OrderDate=DateTime.Now,
					PuchaseOrderTitle=cmbVendor.Text +"_"+ DateTime.Now.Date,
					VendorId= cmbVendor.SelectedValue.ToString(),
					Status="Active",
					ReceivingDate=DateTime.Now.AddDays(8)

					});
					this.FillPurchaseTitle();

                }
                else
                {
					SavePurchaseOrderDetails(new PurchaseOrderDetailsInfo
					{
						PurchaseOrderMasterId=long.Parse(cmbPurchaseTitles.SelectedValue.ToString()),
						ProductId=selected.ProductId,
						Qty=selected.Quantity,
						Rate=selected.VendorRate != 0 ? selected.VendorRate: selected.ProductRate
					});
					ViewPurchaseOrderDetails(this.cmbVendor.SelectedValue.ToString());
				}

			}
		}

        private void btnSavveOrder_Click(object sender, EventArgs e)
        {
			decimal totalAmount = 0;
            try
            {
				foreach (var item in purchaseOrderDetailsList)
				{
					totalAmount += item.Qty * item.Rate;
					EditPurchaseOrderDetails(new PurchaseOrderDetailsInfo
					{
						PurchaseOrderMasterId = long.Parse(cmbPurchaseTitles.SelectedValue.ToString()),
						PurchaseOrderDetailsId = item.PurchaseOrderDetailsId,
						ProductId = item.ProductId,
						Qty = item.Qty,
						Discount = item.Discount,
						FreeQty = item.FreeQty,
						Rate = item.Rate,
						VendorId = item.VendorId
					});
				}
				lblTotalAmount.Text = totalAmount.ToString();
				ViewPurchaseOrderDetails(this.cmbVendor.SelectedValue.ToString());

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}

		}
		private void dataGridViewOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (e.ColumnIndex == senderGrid.Columns["delete"].Index && e.RowIndex >= 0)
			{
				PurchaseOrderDetailsInfo selected = senderGrid.Rows[e.RowIndex].DataBoundItem as PurchaseOrderDetailsInfo;
				if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				{
					PuchaseOrderDetailsSP puchaseOrderDetailsSP = new PuchaseOrderDetailsSP();
					puchaseOrderDetailsSP.PurchaseOrderDetailsDelete(selected.PurchaseOrderDetailsId);
					ViewPurchaseOrderDetails(this.cmbVendor.SelectedValue.ToString());
				}
			}
		}
	}
}
