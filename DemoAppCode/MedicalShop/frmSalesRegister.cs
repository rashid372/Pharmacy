using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmSalesRegister : Form
	{
		private SalesMasterSP mastersp = new SalesMasterSP();
        private ProductSP productsp = new ProductSP();

        private IContainer components = null;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private Panel panel1;

		private Button btnView;

		private Button btnClose;

		private Panel panel8;

		private DataGridView dgvRegister;

		private TextBox txtSearch;

		private Label label4;
        private Label label6;
        private bool isInEditMode = false;
        private ComboBox cmbPatient;

        private DateTimePicker dtpToDate;

		private Label label3;

		private DateTimePicker dtpFromDate;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;
       // private string _patientId;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private Button btnRefresh;

		private DataGridViewTextBoxColumn VoucherNo;

		private DataGridViewTextBoxColumn InvoiceNo;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Date;

        private string fromDate = string.Empty;
        private string toDate = string.Empty;

        public frmSalesRegister()
		{
			this.InitializeComponent();



        }

        //public frmSalesRegister(string patientId)
        //{
        //    this.InitializeComponent();
        //    _patientId = patientId;
        //}

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
				this.CallSalesInvoice();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallSalesInvoice()
		{
			if (this.dgvRegister.CurrentRow != null)
			{
				frmSalesInvoice _frmSalesInvoice = new frmSalesInvoice()
				{
					MdiParent = base.MdiParent
				};
				_frmSalesInvoice.DoWhenComingFromRegister(this, this.dgvRegister.CurrentRow.Cells[0].Value.ToString());
				base.Enabled = false;
			}
		}

		private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.CallSalesInvoice();
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

		public void DoWhenComingFromPayment()
		{
			base.Enabled = true;
			this.FillRegister();
			base.WindowState = FormWindowState.Normal;
			base.Activate();
		}

        public void DoWhenComingFromPaymentbyPatient()
        {
            base.Enabled = true;
            this.FillRegisterByPatient();
            base.WindowState = FormWindowState.Normal;
            base.Activate();
        }

        private void dtpFromDate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Space)
				{
					SendKeys.Send("{F4}");
				}
                if (e.KeyCode == Keys.Enter)
                {
                    this.FillRegister();
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
                if (this.cmbPatient.SelectedValue != null)
                {
                    this.FillRegisterByPatient();
                }
                else
              //  { //this.FillRegister(); }
               // this.FillRegister();

              // this.FillRegisterByPatient();
               
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
                //if (e.KeyChar == (char)Keys.Enter)
                //{
                //    this.FillRegister();
                //}
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
                if (this.cmbPatient.SelectedValue != null)
                {
                    this.FillRegisterByPatient();
                }
                else
                {

                      //  this.FillRegister();
             
                    
                }
              //  this.FillRegister();
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
			DataTable dataTable = this.mastersp.SalesMasterViewAllForRegister(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text));
			this.dgvRegister.Rows.Clear();
			int str = 0;
			foreach (DataRow row in dataTable.Rows)
			{
				this.dgvRegister.Rows.Add();
				this.dgvRegister.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
				this.dgvRegister.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
				this.dgvRegister.Rows[str].Cells[2].Value = row.ItemArray[3].ToString();
				this.dgvRegister.Rows[str].Cells[4].Value = row.ItemArray[2].ToString();
				decimal num = new decimal(0);
				DataTable dataTable1 = new DataTable();
				SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
				dataTable1 = salesDetailsSP.SalesDetailsViewAllByMasterId(row.ItemArray[0].ToString());
				foreach (DataRow dataRow in dataTable1.Rows)
				{
					if (dataRow.ItemArray[11].ToString() != null)
					{
						if (dataRow.ItemArray[11].ToString() != "")
						{
							num = num + decimal.Parse(dataRow.ItemArray[11].ToString());
						}
					}
				}
				num = num - decimal.Parse(row.ItemArray[4].ToString());
				num = Math.Round(num, 2);
				this.dgvRegister.Rows[str].Cells[3].Value = num.ToString();
				str++;
			}
			this.dgvRegister.Focus();
			base.Enabled = true;
			base.Activate();
		}

        public void FillRegisterByPatient()
        {
            DataTable dataTable = this.mastersp.SalesMasterViewAllForRegisterbyPatient(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text), this.cmbPatient.SelectedValue.ToString());
            this.dgvRegister.Rows.Clear();
            int str = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                this.dgvRegister.Rows.Add();
                this.dgvRegister.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
                this.dgvRegister.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
                this.dgvRegister.Rows[str].Cells[2].Value = row.ItemArray[3].ToString();
                this.dgvRegister.Rows[str].Cells[4].Value = row.ItemArray[2].ToString();
                decimal num = new decimal(0);
                DataTable dataTable1 = new DataTable();
                SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
                dataTable1 = salesDetailsSP.SalesDetailsViewAllByMasterId(row.ItemArray[0].ToString());
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    if (dataRow.ItemArray[11].ToString() != null)
                    {
                        if (dataRow.ItemArray[11].ToString() != "")
                        {
                            num = num + decimal.Parse(dataRow.ItemArray[11].ToString());
                        }
                    }
                }
                num = num - decimal.Parse(row.ItemArray[4].ToString());
                num = Math.Round(num, 2);
                this.dgvRegister.Rows[str].Cells[3].Value = num.ToString();
                str++;
            }
            this.dgvRegister.Focus();
            base.Enabled = true;
            base.Activate();
        }

        private void frmPurchaseRegister_Load(object sender, EventArgs e)
		{
			try
			{
                var date = DateTime.Today.Subtract(TimeSpan.FromDays(8)).Date;
                this.dtpFromDate.Value = date;
                fromDate = this.dtpFromDate.Text;
                toDate = this.dtpToDate.Text;
              //  this.dtpFromDate.Value = FinacialYearInfo._fromDate;
                this.dtpToDate.Value = FinacialYearInfo._toDate;
                this.dtpFromDate.MinDate = FinacialYearInfo._fromDate;
                this.dtpFromDate.MaxDate = FinacialYearInfo._toDate;
                this.dtpToDate.MinDate = FinacialYearInfo._fromDate;
                this.dtpToDate.MaxDate = FinacialYearInfo._toDate;




                this.txtSearch.Clear();
                
                this.FillPatientCombo();

                if (this.cmbPatient.SelectedValue != null)
                {
                    this.FillRegisterByPatient();
                }
                else
                { this.FillRegister(); }

			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSalesRegister));
			this.panel1 = new Panel();
			this.btnRefresh = new Button();
			this.btnView = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.dgvRegister = new DataGridView();
			this.VoucherNo = new DataGridViewTextBoxColumn();
			this.InvoiceNo = new DataGridViewTextBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Date = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label4 = new Label();
			this.dtpToDate = new DateTimePicker();
			this.label3 = new Label();
			this.dtpFromDate = new DateTimePicker();
            this.cmbPatient = new ComboBox();
            this.label6 = new Label();


            this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.dgvRegister).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
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
			this.panel1.TabIndex = 6;
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
			this.btnRefresh.Click += new EventHandler(this.frmPurchaseRegister_Load);
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
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.dgvRegister);
			this.panel8.Controls.Add(this.txtSearch);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.dtpToDate);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.dtpFromDate);
			this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.cmbPatient);
            this.panel8.Controls.Add(this.label6);
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
			DataGridViewColumn[] voucherNo = new DataGridViewColumn[] { this.VoucherNo, this.InvoiceNo, this.Column1, this.Column2, this.Date };
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
			this.VoucherNo.Resizable = DataGridViewTriState.False;
			this.VoucherNo.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.InvoiceNo.HeaderText = "Invoice No";
			this.InvoiceNo.Name = "InvoiceNo";
			this.InvoiceNo.ReadOnly = true;
			this.InvoiceNo.Resizable = DataGridViewTriState.False;
			this.InvoiceNo.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.HeaderText = "Ledger ";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column2.HeaderText = "Amount";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Date.HeaderText = "Date";
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			this.Date.Resizable = DataGridViewTriState.False;
			this.Date.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.txtSearch.Location = new Point(315, 33);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(141, 20);
			this.txtSearch.TabIndex = 54;
			this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtSearch_KeyPress);
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(186, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(99, 13);
			this.label4.TabIndex = 53;
			this.label4.Text = "Search Invoice No:";

            this.label6.AutoSize = true;
            this.label6.Location = new Point(186, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Search Patient:";

            this.cmbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new Point(315, 10); 
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(140, 21);
            this.cmbPatient.TabIndex = 4;
           // this.cmbPatient.Leave += new EventHandler(this.cmbPatient_Leave);
            this.cmbPatient.SelectedIndexChanged += new EventHandler(this.cmbPatient_SelectedIndexChanged);
           // this.cmbPatient.TextChanged += new EventHandler(this.cmbPatient_TextChanged);
            this.cmbPatient.KeyDown += new KeyEventHandler(this.cmbPatient_KeyDown);


            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpToDate.Format = DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new Point(72, 36);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(95, 20);
			this.dtpToDate.TabIndex = 49;
			this.dtpToDate.ValueChanged += new EventHandler(this.dtpToDate_ValueChanged);
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
			this.dtpFromDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "From:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
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
			this.label1.Size = new System.Drawing.Size(101, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Sales Register";
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
			this.dataGridViewTextBoxColumn1.HeaderText = "Voucher No";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 111;
			this.dataGridViewTextBoxColumn2.HeaderText = "Cash/Bank Account";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 110;
			this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 111;
			this.dataGridViewTextBoxColumn4.HeaderText = "Date";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 110;
			this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 88;
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
			base.Name = "frmSalesRegister";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Sales Register";
			base.Load += new EventHandler(this.frmPurchaseRegister_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvRegister).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

        public void ClearFunction()
        {
            try
            {
           InvoiceDataInfo     invoicedatainfo = new InvoiceDataInfo();
               
                this.cmbPatient.Text = "";
              
              
               
                this.FillPatientCombo();

               
              
              //  this.FillComboItem();
                
             
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void FillComboItem()
        {
            try
            {
                this.cmbPatient.DataSource = null;
                PatientSP patientsp = new PatientSP();
                DataTable dataTable = new DataTable();
                dataTable = patientsp.PatientViewAllByInvoice();
                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow dataRow = null;
                        dataRow = dataTable.NewRow();
                        dataRow[0] = 0;
                        dataRow[1] = "";
                        dataTable.Rows.InsertAt(dataRow, 0);
                    }
                    this.cmbPatient.DataSource = dataTable;
                    this.cmbPatient.ValueMember = "Id";
                    this.cmbPatient.DisplayMember = "Name";
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void DropDowncomboAndCalender(KeyEventArgs e)
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

        private void cmbPatient_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.DropDowncomboAndCalender(e);
                if (e.KeyCode == Keys.Return)
                {
                    SendKeys.Send("{TAB}");
                }
                if (e.KeyCode == Keys.Back)
                {
                    if ((this.cmbPatient.Text == "" ? true : this.cmbPatient.SelectionStart == 0))
                    {
                        this.txtSearch.Focus();
                        this.txtSearch.SelectionStart = 0;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbPatient_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPatient.Text.Trim() == "")
                {
                    this.cmbPatient.SelectedValue = "0";
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbPatient_SelectedIndexChanged_n(object sender, EventArgs e)
        {
            try
            {
                if (!this.isInEditMode)
                {
                    this.dgvRegister.Rows.Clear();
                    DataTable dataTable = new DataTable();
                    if (this.cmbPatient.SelectedValue != null)
                    {
                        if ((this.cmbPatient.Text == "" ? false : this.cmbPatient.Text != "NA"))
                        {
                            PatientSP patientSP = new PatientSP();
                            PatientInfo patientInfo = new PatientInfo();
                            ProductInfo productInfo = new ProductInfo();
                            UnitInfo unitInfo = new UnitInfo();
                            UnitSP unitSP = new UnitSP();
                            ManufacturerSP manufacturerSP = new ManufacturerSP();
                            ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
                            PatientMedicineDetailsSP patientMedicineDetailsSP = new PatientMedicineDetailsSP();
                            patientInfo = patientSP.PatientView(this.cmbPatient.SelectedValue.ToString());
                            if (patientInfo.DailyCustomerOrNot == bool.Parse("True"))
                            {
                                dataTable = patientMedicineDetailsSP.PatientMedicineDetailsViewAllByPatientId(patientInfo.PatientId);
                                if (dataTable.Rows.Count > 0)
                                {
                                    int str = 0;
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        this.dgvRegister.Rows.Add();
                                        this.dgvRegister.Rows[str].Cells[1].Value = row.ItemArray[2].ToString();
                                        this.dgvRegister.Rows[str].Cells[2].Value = row.ItemArray[2].ToString();
                                        productInfo = this.productsp.ProductView(row.ItemArray[2].ToString());
                                        if (productInfo.ManufactureId != null)
                                        {
                                            manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
                                            this.dgvRegister.Rows[str].Cells[8].Value = manufacturerInfo.ManufactureName;
                                        }
                                        if (productInfo.ManufactureId != null)
                                        {
                                            unitInfo = unitSP.UnitView(productInfo.UnitId);
                                            this.dgvRegister.Rows[str].Cells[11].Value = unitInfo.UnitName;
                                        }
                                        str++;
                                    }
                                }
                            }
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

        private void cmbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPatient.SelectedIndex > 0)
                {

                    FillRegisterByPatient();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
      
        public void FillPatientCombo()
        {
            try
            {
                PatientSP patientSP = new PatientSP();
                DataTable dataTable = new DataTable();
                dataTable = patientSP.PatientViewAllByInvoice();
                if (dataTable.Rows.Count > 0)
                {
                    this.cmbPatient.DataSource = dataTable;
                    this.cmbPatient.ValueMember = "Id";
                    this.cmbPatient.DisplayMember = "Name";
                    this.cmbPatient.SelectedValue = 0;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbPatient_KeyPress(object sender, KeyPressEventArgs e)
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
					if (!this.dgvRegister[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
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