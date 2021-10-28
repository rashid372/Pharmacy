using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmProductDetails : Form
	{
		private bool isFromLowStockTab = false;

		private bool isFromExpiryTab = false;

		private bool isFromProductAvailability = false;

		private frmReminderView frmreminder;

		private frmProductAvailability frmproduct;

		private IContainer components = null;

		private Panel panel1;

		private Button btnClose;

		private Panel panel8;

		private Label label7;

		private Label label3;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private dgv.DataGridViewEnter dgvBacth;

		private Label label9;

		private Label label8;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label lblProduct;

		private Label lblGroup;

		private Label lblManufacture;

		private Label lblShelf;

		private Label lblGenericName;

		private Label lblStock;

		private Label lblfor;

		private Label lblCode;

		private Label lblTotal;

		private Label label10;

		private DataGridViewTextBoxColumn Batch;

		private DataGridViewTextBoxColumn ExDate;

		private DataGridViewTextBoxColumn Stock;

		private DataGridViewTextBoxColumn Rate;

		private DataGridViewTextBoxColumn SalesRate;

		private DataGridViewTextBoxColumn MRP;

		public frmProductDetails()
		{
			this.InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
				{
					base.Close();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallThisFormFromProductAvailabilityForm(frmProductAvailability frm, string strProductId, string strproduct, string strstock, string strshelf, string strGroup, string strManufacture, string strGenericname, string strMedicinefor)
		{
			this.frmproduct = frm;
			this.lblCode.Text = strProductId;
			this.lblProduct.Text = strproduct;
			this.lblStock.Text = strstock;
			this.lblShelf.Text = strshelf;
			this.lblGroup.Text = strGroup;
			this.lblManufacture.Text = strManufacture;
			this.lblGenericName.Text = strGenericname;
			this.lblfor.Text = strMedicinefor;
			this.FillBatchDetails(strProductId);
		}

		public void CallThisFormFromReminderForm(frmReminderView frm, string strProductId, string strproduct, string strstock, string strshelf, string strGroup, string strManufacture, string strGenericname, string strMedicinefor, string strPurchaserate, string strSalesrate, string strMRP, string strBatch, string strexpirydate, bool isFromLowStock)
		{
			if (!isFromLowStock)
			{
				this.isFromExpiryTab = true;
			}
			else
			{
				this.isFromLowStockTab = true;
			}
			this.frmreminder = frm;
			this.lblCode.Text = strProductId;
			this.lblProduct.Text = strproduct;
			this.lblStock.Text = strstock;
			this.lblShelf.Text = strshelf;
			this.lblGroup.Text = strGroup;
			this.lblManufacture.Text = strManufacture;
			this.lblGenericName.Text = strGenericname;
			this.lblfor.Text = strMedicinefor;
			if (!this.isFromLowStockTab)
			{
				this.dgvBacth.Rows.Clear();
				this.dgvBacth.Rows.Add();
				this.dgvBacth.Rows[0].Cells[0].Value = strBatch;
				this.dgvBacth.Rows[0].Cells[1].Value = strexpirydate;
				if (strBatch.Trim().ToLower() == "na")
				{
					this.dgvBacth.Rows[0].Cells[1].Value = "";
				}
				this.dgvBacth.Rows[0].Cells[3].Value = strPurchaserate;
				this.dgvBacth.Rows[0].Cells[4].Value = strSalesrate;
				this.dgvBacth.Rows[0].Cells[5].Value = strMRP;
				string[] strArrays = strstock.Split(new char[] { ' ' });
				this.dgvBacth.Rows[0].Cells[2].Value = strArrays[0].ToString();
				this.lblTotal.Text = string.Concat(Math.Round(decimal.Parse(strArrays[0].ToString()), 2), " ", strArrays[1].ToString());
			}
			else
			{
				this.FillBatchDetails(strProductId);
			}
		}

		private void dgvBacth_KeyDown(object sender, KeyEventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void FillBatchDetails(string strProductCode)
		{
			ProductSP productSP = new ProductSP();
			DataTable dataTable = new DataTable();
			dataTable = productSP.GetAllLowStockProductBatchDetailsByProdcutCode(strProductCode);
			this.dgvBacth.DataSource = dataTable;
			decimal num = new decimal(0);
			foreach (DataGridViewRow row in (IEnumerable)this.dgvBacth.Rows)
			{
				if (row.Cells["Batch"].Value.ToString().Trim().ToLower() == "na")
				{
					row.Cells["ExDate"].Value = "";
				}
				decimal num1 = new decimal(0);
				try
				{
					num1 = decimal.Parse(row.Cells["Stock"].Value.ToString());
				}
				catch (Exception exception)
				{
					num1 = new decimal(0);
				}
				num = num + num1;
			}
			string[] strArrays = this.lblStock.Text.Split(new char[] { ' ' });
			this.lblTotal.Text = string.Concat(Math.Round(decimal.Parse(num.ToString().Trim()), 2), " ", strArrays[1].ToString());
		}

		private void frmProductDetails_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (this.isFromLowStockTab)
				{
					if (this.frmreminder != null)
					{
						this.frmreminder.ReturnFromProductDetails("tpLowStock");
					}
				}
				else if (this.isFromLowStockTab)
				{
					if (this.frmreminder != null)
					{
						this.frmreminder.ReturnFromProductDetails("tpExpiry");
					}
				}
				else if (this.isFromProductAvailability)
				{
					if (this.frmproduct != null)
					{
						this.frmproduct.Activate();
						if (this.frmproduct.WindowState == FormWindowState.Minimized)
						{
							this.frmproduct.WindowState = FormWindowState.Normal;
						}
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmProductDetails_Load(object sender, EventArgs e)
		{
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmProductDetails));
			this.panel1 = new Panel();
			this.lblTotal = new Label();
			this.label10 = new Label();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.lblProduct = new Label();
			this.lblGroup = new Label();
			this.lblManufacture = new Label();
			this.lblShelf = new Label();
			this.lblGenericName = new Label();
			this.lblStock = new Label();
			this.lblfor = new Label();
			this.lblCode = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.dgvBacth = new dgv.DataGridViewEnter();
			this.Batch = new DataGridViewTextBoxColumn();
			this.ExDate = new DataGridViewTextBoxColumn();
			this.Stock = new DataGridViewTextBoxColumn();
			this.Rate = new DataGridViewTextBoxColumn();
			this.SalesRate = new DataGridViewTextBoxColumn();
			this.MRP = new DataGridViewTextBoxColumn();
			this.label7 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.dgvBacth).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.lblTotal);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.panel8);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(7, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(650, 424);
			this.panel1.TabIndex = 2;
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTotal.Location = new Point(243, 393);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(40, 13);
			this.lblTotal.TabIndex = 26;
			this.lblTotal.Text = "Total:";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(149, 393);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 25;
			this.label10.Text = "Total:";
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(566, 388);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.lblProduct);
			this.panel8.Controls.Add(this.lblGroup);
			this.panel8.Controls.Add(this.lblManufacture);
			this.panel8.Controls.Add(this.lblShelf);
			this.panel8.Controls.Add(this.lblGenericName);
			this.panel8.Controls.Add(this.lblStock);
			this.panel8.Controls.Add(this.lblfor);
			this.panel8.Controls.Add(this.lblCode);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.dgvBacth);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 348);
			this.panel8.TabIndex = 0;
			this.lblProduct.AutoSize = true;
			this.lblProduct.Location = new Point(135, 37);
			this.lblProduct.Margin = new System.Windows.Forms.Padding(5);
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.Size = new System.Drawing.Size(39, 13);
			this.lblProduct.TabIndex = 32;
			this.lblProduct.Text = "Group:";
			this.lblGroup.AutoSize = true;
			this.lblGroup.Location = new Point(135, 60);
			this.lblGroup.Margin = new System.Windows.Forms.Padding(5);
			this.lblGroup.Name = "lblGroup";
			this.lblGroup.Size = new System.Drawing.Size(39, 13);
			this.lblGroup.TabIndex = 31;
			this.lblGroup.Text = "Group:";
			this.lblManufacture.AutoSize = true;
			this.lblManufacture.Location = new Point(135, 83);
			this.lblManufacture.Margin = new System.Windows.Forms.Padding(5);
			this.lblManufacture.Name = "lblManufacture";
			this.lblManufacture.Size = new System.Drawing.Size(75, 13);
			this.lblManufacture.TabIndex = 30;
			this.lblManufacture.Text = "Product Code:";
			this.lblShelf.AutoSize = true;
			this.lblShelf.Location = new Point(135, 106);
			this.lblShelf.Margin = new System.Windows.Forms.Padding(5);
			this.lblShelf.Name = "lblShelf";
			this.lblShelf.Size = new System.Drawing.Size(75, 13);
			this.lblShelf.TabIndex = 29;
			this.lblShelf.Text = "Product Code:";
			this.lblGenericName.AutoSize = true;
			this.lblGenericName.Location = new Point(135, 129);
			this.lblGenericName.Margin = new System.Windows.Forms.Padding(5);
			this.lblGenericName.Name = "lblGenericName";
			this.lblGenericName.Size = new System.Drawing.Size(75, 13);
			this.lblGenericName.TabIndex = 28;
			this.lblGenericName.Text = "Product Code:";
			this.lblStock.AutoSize = true;
			this.lblStock.Location = new Point(135, 175);
			this.lblStock.Margin = new System.Windows.Forms.Padding(5);
			this.lblStock.Name = "lblStock";
			this.lblStock.Size = new System.Drawing.Size(75, 13);
			this.lblStock.TabIndex = 27;
			this.lblStock.Text = "Product Code:";
			this.lblfor.AutoSize = true;
			this.lblfor.Location = new Point(135, 152);
			this.lblfor.Margin = new System.Windows.Forms.Padding(5);
			this.lblfor.Name = "lblfor";
			this.lblfor.Size = new System.Drawing.Size(75, 13);
			this.lblfor.TabIndex = 26;
			this.lblfor.Text = "Product Code:";
			this.lblCode.AutoSize = true;
			this.lblCode.Location = new Point(135, 14);
			this.lblCode.Margin = new System.Windows.Forms.Padding(5);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(75, 13);
			this.lblCode.TabIndex = 25;
			this.lblCode.Text = "Product Code:";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(16, 175);
			this.label9.Margin = new System.Windows.Forms.Padding(5);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 13);
			this.label9.TabIndex = 24;
			this.label9.Text = "Current Stock:";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(20, 152);
			this.label8.Margin = new System.Windows.Forms.Padding(5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Medicine For:";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(13, 129);
			this.label6.Margin = new System.Windows.Forms.Padding(5);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 13);
			this.label6.TabIndex = 22;
			this.label6.Text = "Generic Name:";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(57, 106);
			this.label5.Margin = new System.Windows.Forms.Padding(5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "Shelf:";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(21, 83);
			this.label4.Margin = new System.Windows.Forms.Padding(5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Manufacture:";
			this.dgvBacth.AllowUserToAddRows = false;
			this.dgvBacth.AllowUserToDeleteRows = false;
			this.dgvBacth.AllowUserToOrderColumns = true;
			this.dgvBacth.AllowUserToResizeColumns = false;
			this.dgvBacth.AllowUserToResizeRows = false;
			this.dgvBacth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvBacth.BackgroundColor = Color.White;
			this.dgvBacth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvBacth.Columns;
			DataGridViewColumn[] batch = new DataGridViewColumn[] { this.Batch, this.ExDate, this.Stock, this.Rate, this.SalesRate, this.MRP };
			columns.AddRange(batch);
			this.dgvBacth.GridColor = Color.WhiteSmoke;
			this.dgvBacth.Location = new Point(14, 196);
			this.dgvBacth.MultiSelect = false;
			this.dgvBacth.Name = "dgvBacth";
			this.dgvBacth.ReadOnly = true;
			this.dgvBacth.RowHeadersVisible = false;
			this.dgvBacth.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvBacth.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvBacth.Size = new System.Drawing.Size(626, 144);
			this.dgvBacth.TabIndex = 19;
			this.dgvBacth.TabStop = false;
			this.dgvBacth.KeyDown += new KeyEventHandler(this.dgvBacth_KeyDown);
			this.Batch.DataPropertyName = "Batch";
			this.Batch.HeaderText = "Batch";
			this.Batch.Name = "Batch";
			this.Batch.ReadOnly = true;
			this.ExDate.DataPropertyName = "ExDate";
			this.ExDate.HeaderText = "Expiry Date";
			this.ExDate.Name = "ExDate";
			this.ExDate.ReadOnly = true;
			this.Stock.DataPropertyName = "Stock";
			this.Stock.HeaderText = "Stock";
			this.Stock.Name = "Stock";
			this.Stock.ReadOnly = true;
			this.Rate.DataPropertyName = "Rate";
			this.Rate.HeaderText = "Purchase Rate";
			this.Rate.Name = "Rate";
			this.Rate.ReadOnly = true;
			this.SalesRate.DataPropertyName = "Sales Rate";
			this.SalesRate.HeaderText = "Sales Rate";
			this.SalesRate.Name = "SalesRate";
			this.SalesRate.ReadOnly = true;
			this.MRP.DataPropertyName = "MRP";
			this.MRP.HeaderText = "MRP";
			this.MRP.Name = "MRP";
			this.MRP.ReadOnly = true;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(52, 60);
			this.label7.Margin = new System.Windows.Forms.Padding(5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Group:";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(44, 37);
			this.label3.Margin = new System.Windows.Forms.Padding(5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Product:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(16, 14);
			this.label2.Margin = new System.Windows.Forms.Padding(5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Product Code:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Product Details";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 423);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(648, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(648, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(649, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 424);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 424);
			this.panel2.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 438);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmProductDetails";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Product Details";
			base.FormClosing += new FormClosingEventHandler(this.frmProductDetails_FormClosing);
			base.Load += new EventHandler(this.frmProductDetails_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvBacth).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}