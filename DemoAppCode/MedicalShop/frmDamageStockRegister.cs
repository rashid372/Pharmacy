using MedicalShop.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmDamageStockRegister : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnClose;

		private Panel panel8;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private DateTimePicker dtpToDate;

		private Label label3;

		private DateTimePicker dtpFromDate;

		private Label label4;

		private TextBox txtSearch;

		private DataGridView dgvRegister;

		private Button btnView;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private Button btnRefresh;

		private DataGridViewTextBoxColumn VoucherNo;

		private DataGridViewTextBoxColumn Date;

		private MedicalShop.DamageStcokMasterSP DamageStcokMasterSP = new MedicalShop.DamageStcokMasterSP();

		public frmDamageStockRegister()
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

		private void btnView_Click(object sender, EventArgs e)
		{
			try
			{
				this.CallDirectStock();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallDirectStock()
		{
			if (this.dgvRegister.CurrentRow != null)
			{
				frmDamageStock _frmDamageStock = new frmDamageStock()
				{
					MdiParent = base.MdiParent
				};
				_frmDamageStock.DoWhenComingFromStockRegister(this, this.dgvRegister.CurrentRow.Cells[0].Value.ToString());
				base.Enabled = false;
			}
		}

		private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.CallDirectStock();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void DoWhenComingFromStock(bool isInEditMode)
		{
			if (!isInEditMode)
			{
				base.Close();
			}
			else
			{
				base.Enabled = true;
				this.FillRegister();
				base.WindowState = FormWindowState.Normal;
				base.Activate();
			}
		}

		private void dtpFromDate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Space)
				{
					SendKeys.Send("{F4}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.dtpToDate.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpFromDate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillRegister();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtSearch.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpToDate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillRegister();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillRegister()
		{
			DataTable dataTable = this.DamageStcokMasterSP.DamageStcokMasterViewBetweenDate(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text));
			this.dgvRegister.Rows.Clear();
			int str = 0;
			foreach (DataRow row in dataTable.Rows)
			{
				this.dgvRegister.Rows.Add();
				this.dgvRegister.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
				DateTime dateTime = DateTime.Parse(row.ItemArray[1].ToString());
				this.dgvRegister.Rows[str].Cells[1].Value = dateTime.Date.ToString("dd-MMM-yyyy");
				str++;
			}
			this.dgvRegister.Focus();
		}

		private void frmStockRegister_Load(object sender, EventArgs e)
		{
			try
			{
				this.dtpFromDate.Value = FinacialYearInfo._fromDate;
				this.dtpToDate.Value = FinacialYearInfo._toDate;
				this.dtpFromDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpFromDate.MaxDate = FinacialYearInfo._toDate;
				this.dtpToDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpToDate.MaxDate = FinacialYearInfo._toDate;
				this.txtSearch.Clear();
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDamageStockRegister));
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.btnClose = new Button();
			this.panel1 = new Panel();
			this.btnRefresh = new Button();
			this.btnView = new Button();
			this.panel8 = new Panel();
			this.dgvRegister = new DataGridView();
			this.VoucherNo = new DataGridViewTextBoxColumn();
			this.Date = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label4 = new Label();
			this.dtpToDate = new DateTimePicker();
			this.label3 = new Label();
			this.dtpFromDate = new DateTimePicker();
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
			((ISupportInitialize)this.dgvRegister).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.dataGridViewTextBoxColumn1.HeaderText = "Voucher No";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 111;
			this.dataGridViewTextBoxColumn2.HeaderText = "Cash/Bank Account";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 110;
			this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 111;
			this.dataGridViewTextBoxColumn4.HeaderText = "Date";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 110;
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(382, 295);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = Resources.form_bottomnew;
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.btnView);
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
			this.panel1.Size = new System.Drawing.Size(469, 342);
			this.panel1.TabIndex = 5;
			this.btnRefresh.BackColor = Color.FromArgb(255, 209, 150);
			this.btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRefresh.FlatStyle = FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRefresh.Location = new Point(269, 295);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(107, 23);
			this.btnRefresh.TabIndex = 9;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new EventHandler(this.frmStockRegister_Load);
			this.btnView.BackColor = Color.FromArgb(255, 209, 150);
			this.btnView.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnView.FlatStyle = FlatStyle.Flat;
			this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnView.Location = new Point(156, 295);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(107, 23);
			this.btnView.TabIndex = 8;
			this.btnView.Text = "&View Details";
			this.btnView.UseVisualStyleBackColor = false;
			this.btnView.Click += new EventHandler(this.btnView_Click);
			this.panel8.BackgroundImage = Resources.panel1;
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.dgvRegister);
			this.panel8.Controls.Add(this.txtSearch);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.dtpToDate);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.dtpFromDate);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(467, 255);
			this.panel8.TabIndex = 4;
			this.dgvRegister.AllowUserToAddRows = false;
			this.dgvRegister.AllowUserToDeleteRows = false;
			this.dgvRegister.AllowUserToResizeColumns = false;
			this.dgvRegister.AllowUserToResizeRows = false;
			this.dgvRegister.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvRegister.BackgroundColor = Color.White;
			this.dgvRegister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvRegister.Columns;
			DataGridViewColumn[] voucherNo = new DataGridViewColumn[] { this.VoucherNo, this.Date };
			columns.AddRange(voucherNo);
			this.dgvRegister.GridColor = Color.WhiteSmoke;
			this.dgvRegister.Location = new Point(11, 72);
			this.dgvRegister.MultiSelect = false;
			this.dgvRegister.Name = "dgvRegister";
			this.dgvRegister.ReadOnly = true;
			this.dgvRegister.RowHeadersVisible = false;
			this.dgvRegister.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvRegister.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvRegister.Size = new System.Drawing.Size(445, 169);
			this.dgvRegister.TabIndex = 55;
			this.dgvRegister.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
			this.VoucherNo.HeaderText = "Voucher No";
			this.VoucherNo.Name = "VoucherNo";
			this.VoucherNo.ReadOnly = true;
			this.VoucherNo.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Date.HeaderText = "Date";
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			this.Date.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.txtSearch.Location = new Point(306, 33);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(150, 20);
			this.txtSearch.TabIndex = 54;
			this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtSearch_KeyPress);
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(178, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 13);
			this.label4.TabIndex = 53;
			this.label4.Text = "Search Voucher No:";
			this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpToDate.Format = DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new Point(72, 36);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(95, 20);
			this.dtpToDate.TabIndex = 49;
			this.dtpToDate.ValueChanged += new EventHandler(this.dtpToDate_ValueChanged);
			this.dtpToDate.KeyPress += new KeyPressEventHandler(this.dtpToDate_KeyPress);
			this.dtpToDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(23, 13);
			this.label3.TabIndex = 48;
			this.label3.Text = "To:";
			this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpFromDate.Format = DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new Point(72, 10);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(95, 20);
			this.dtpFromDate.TabIndex = 47;
			this.dtpFromDate.ValueChanged += new EventHandler(this.dtpFromDate_ValueChanged);
			this.dtpFromDate.KeyPress += new KeyPressEventHandler(this.dtpFromDate_KeyPress);
			this.dtpFromDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "From:";
			this.panel6.BackgroundImage = Resources.head_bg;
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(467, 33);
			this.panel6.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(158, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Damage Stock Register";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(467, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 341);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(467, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(467, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(468, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 342);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 342);
			this.panel2.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(483, 356);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmDamageStockRegister";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Damage Stock Register";
			base.Load += new EventHandler(this.frmStockRegister_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvRegister).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void rbtnAll_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rbtnCash_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rbtnChecque_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvRegister.RowCount > 0)
					{
						this.dgvRegister.Rows[0].Selected = true;
					}
					this.dgvRegister.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvRegister.Rows.Count; i++)
				{
					if (!this.dgvRegister[0, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvRegister.Rows[i].Visible = false;
					}
					else
					{
						this.dgvRegister.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}