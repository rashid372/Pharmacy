using MedicalShop.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MedicalShop
{
	public class rptJournalRegister : Form
	{
		private MedicalShop.CompanySP CompanySP = new MedicalShop.CompanySP();

		private MedicalShop.CompanyInfo CompanyInfo = new MedicalShop.CompanyInfo();

		private MedicalShop.JournalMasterSP JournalMasterSP = new MedicalShop.JournalMasterSP();

		private MedicalShop.frmCompanyProgress frmCompanyProgress = new MedicalShop.frmCompanyProgress();

		private int _pageNo = 0;

		private int _page = 0;

		private string strFormat = "";

		private string strHeading = "";

		private IContainer components = null;

		private Label lblPlace;

		private Label lblCompanyName;

		private GroupBox groupBox4;

		private Button btnExport;

		private ComboBox cmbExportType;

		private Label label5;

		private PictureBox btnClose;

		private Button btnClear;

		private DataGridView dgvReport;

		private Label lblPhone;

		private ToolTip toolTip1;

		private BackgroundWorker bwrk1;

		private Label label1;

		private Panel panel1;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column7;

		private Panel panel2;

		private Panel panel3;

		private Panel panel4;

		private Panel panel5;

		private Label label2;

		private GroupBox groupBox1;

		private DateTimePicker dtpFromDate;

		private DateTimePicker dtpToDate;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private GroupBox groupBox2;

		private ComboBox cmbSearchFor;

		private Label label4;

		private ComboBox cmbSearchBy;

		public rptJournalRegister()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.rptJournalRegister_Load(sender, e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				base.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void bwrk1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				this.strHeading = "JOURNAL REGISTER REPORT";
				ExportToExcel exportToExcel = new ExportToExcel();
				if (this.strFormat == "Excel")
				{
					exportToExcel.ExportExcel(this.dgvReport, this.strHeading, 0, 0, "Excel");
				}
				else if (this.strFormat == "Html")
				{
					exportToExcel.ExportExcel(this.dgvReport, this.strHeading, 0, 0, "Html");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void bwrk1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				if ((this.frmCompanyProgress == null ? false : this.frmCompanyProgress.Visible))
				{
					this.frmCompanyProgress.Close();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbExportType_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbSearchBy_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.dgvReport.Rows.Clear();
				this.LoadGridColumns();
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchFor_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbSearchFor_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.dgvReport.Rows.Clear();
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				DataTable dataTable = new DataTable();
				this.cmbSearchBy.DataSource = null;
				if (this.cmbSearchFor.Text == "All")
				{
					this.cmbSearchBy.Visible = false;
				}
				else if (this.cmbSearchFor.Text == "Voucher No")
				{
					this.cmbSearchBy.Visible = true;
					dataTable = this.JournalMasterSP.JournalMasterViewAll();
					if (dataTable.Rows.Count > 0)
					{
						this.cmbSearchBy.DataSource = dataTable;
						this.cmbSearchBy.DisplayMember = "ID";
						this.cmbSearchBy.ValueMember = "ID";
					}
				}
				else if (this.cmbSearchFor.Text == "Account Ledger")
				{
					this.cmbSearchBy.Visible = true;
					dataTable = accountLedgerSP.AccountLedgerViewAll();
					if (dataTable.Rows.Count > 0)
					{
						this.cmbSearchBy.DataSource = dataTable;
						this.cmbSearchBy.DisplayMember = "Name";
						this.cmbSearchBy.ValueMember = "ID";
					}
				}
				this.LoadGridColumns();
				this.FillRegister();
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

		private void dtpFromDate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.dgvReport.Rows.Clear();
				this.LoadGridColumns();
				this.FillRegister();
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
				this.dgvReport.Rows.Clear();
				this.LoadGridColumns();
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillRegister()
		{
			try
			{
				DataTable dataTable = new DataTable();
				if (this.cmbSearchFor.Text == "All")
				{
					dataTable = this.JournalMasterSP.JournalReportForAll(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text));
				}
				else if (this.cmbSearchFor.Text == "Voucher No")
				{
					if (this.cmbSearchBy.Text != "")
					{
						dataTable = this.JournalMasterSP.JournalReportForVoucherNo(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text), this.cmbSearchBy.SelectedValue.ToString());
					}
				}
				else if (this.cmbSearchFor.Text == "Account Ledger")
				{
					if (this.cmbSearchBy.Text != "")
					{
						dataTable = this.JournalMasterSP.JournalReportForAccountledger(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text), this.cmbSearchBy.SelectedValue.ToString());
					}
				}
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgvReport.Rows.Add();
					this.dgvReport[0, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[0].ToString();
					DataGridViewCell item = this.dgvReport[1, this.dgvReport.Rows.Count - 1];
					DateTime dateTime = DateTime.Parse(row.ItemArray[1].ToString());
					item.Value = dateTime.ToString("dd-MMM-yyyy");
					this.dgvReport[2, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[2].ToString();
					this.dgvReport[3, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[3].ToString();
					this.dgvReport[4, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[4].ToString();
				}
				this.dgvReport.CurrentCell = null;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptJournalRegister));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle window = new DataGridViewCellStyle();
			this.label1 = new Label();
			this.btnClear = new Button();
			this.groupBox4 = new GroupBox();
			this.btnExport = new Button();
			this.cmbExportType = new ComboBox();
			this.lblPhone = new Label();
			this.lblPlace = new Label();
			this.lblCompanyName = new Label();
			this.label5 = new Label();
			this.btnClose = new PictureBox();
			this.dgvReport = new DataGridView();
			this.toolTip1 = new ToolTip(this.components);
			this.bwrk1 = new BackgroundWorker();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.panel5 = new Panel();
			this.label2 = new Label();
			this.groupBox1 = new GroupBox();
			this.dtpToDate = new DateTimePicker();
			this.dtpFromDate = new DateTimePicker();
			this.groupBox2 = new GroupBox();
			this.cmbSearchBy = new ComboBox();
			this.cmbSearchFor = new ComboBox();
			this.label4 = new Label();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.groupBox4.SuspendLayout();
			((ISupportInitialize)this.btnClose).BeginInit();
			((ISupportInitialize)this.dgvReport).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(5, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "From:";
			this.btnClear.BackColor = Color.Transparent;
			this.btnClear.BackgroundImage = Resources.RefreshIcon;
			this.btnClear.BackgroundImageLayout = ImageLayout.Center;
			this.btnClear.Cursor = Cursors.Hand;
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClear.FlatAppearance.BorderColor = Color.LightSkyBlue;
			this.btnClear.FlatAppearance.MouseOverBackColor = Color.PowderBlue;
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.ImageAlign = ContentAlignment.BottomCenter;
			this.btnClear.Location = new Point(12, 87);
			this.btnClear.Margin = new System.Windows.Forms.Padding(10);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(30, 30);
			this.btnClear.TabIndex = 2;
			this.toolTip1.SetToolTip(this.btnClear, "Reset");
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.groupBox4.BackColor = Color.Transparent;
			this.groupBox4.Controls.Add(this.btnExport);
			this.groupBox4.Controls.Add(this.cmbExportType);
			this.groupBox4.Location = new Point(752, 151);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(232, 45);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.btnExport.BackColor = Color.Transparent;
			this.btnExport.BackgroundImage = Resources.ExportIcon;
			this.btnExport.BackgroundImageLayout = ImageLayout.Center;
			this.btnExport.Cursor = Cursors.Hand;
			this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExport.FlatAppearance.BorderColor = Color.LightSkyBlue;
			this.btnExport.FlatAppearance.MouseOverBackColor = Color.PowderBlue;
			this.btnExport.FlatStyle = FlatStyle.Flat;
			this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnExport.ImageAlign = ContentAlignment.BottomCenter;
			this.btnExport.Location = new Point(189, 11);
			this.btnExport.Margin = new System.Windows.Forms.Padding(10);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(30, 30);
			this.btnExport.TabIndex = 3;
			this.toolTip1.SetToolTip(this.btnExport, "Export");
			this.btnExport.UseVisualStyleBackColor = false;
			this.btnExport.Click += new EventHandler(this.btnExport_Click);
			this.cmbExportType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbExportType.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbExportType.Items;
			object[] objArray = new object[] { "Print", "Excel", "Html" };
			items.AddRange(objArray);
			this.cmbExportType.Location = new Point(6, 18);
			this.cmbExportType.Name = "cmbExportType";
			this.cmbExportType.Size = new System.Drawing.Size(170, 21);
			this.cmbExportType.TabIndex = 0;
			this.cmbExportType.KeyDown += new KeyEventHandler(this.cmbExportType_KeyDown);
			this.lblPhone.BackColor = Color.Transparent;
			this.lblPhone.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblPhone.ForeColor = Color.Black;
			this.lblPhone.Location = new Point(328, 95);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(337, 18);
			this.lblPhone.TabIndex = 6;
			this.lblPhone.Text = "Phone : 0494 2423344";
			this.lblPhone.TextAlign = ContentAlignment.TopCenter;
			this.lblPlace.BackColor = Color.Transparent;
			this.lblPlace.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblPlace.ForeColor = Color.Black;
			this.lblPlace.Location = new Point(57, 74);
			this.lblPlace.Name = "lblPlace";
			this.lblPlace.Size = new System.Drawing.Size(878, 18);
			this.lblPlace.TabIndex = 6;
			this.lblPlace.Text = "Kakkenchery ,Malappuram";
			this.lblPlace.TextAlign = ContentAlignment.TopCenter;
			this.lblCompanyName.BackColor = Color.Transparent;
			this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblCompanyName.ForeColor = Color.DimGray;
			this.lblCompanyName.Location = new Point(52, 43);
			this.lblCompanyName.Name = "lblCompanyName";
			this.lblCompanyName.Size = new System.Drawing.Size(894, 30);
			this.lblCompanyName.TabIndex = 5;
			this.lblCompanyName.Text = "Name";
			this.lblCompanyName.TextAlign = ContentAlignment.TopCenter;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Black;
			this.label5.Location = new Point(3, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Journal";
			this.btnClose.BackColor = Color.Transparent;
			this.btnClose.Cursor = Cursors.Hand;
			this.btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
			this.btnClose.Location = new Point(971, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(25, 25);
			this.btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
			this.btnClose.TabIndex = 1;
			this.btnClose.TabStop = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.dgvReport.AllowUserToAddRows = false;
			this.dgvReport.AllowUserToDeleteRows = false;
			this.dgvReport.AllowUserToResizeColumns = false;
			this.dgvReport.AllowUserToResizeRows = false;
			this.dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvReport.BackgroundColor = Color.White;
			this.dgvReport.BorderStyle = BorderStyle.Fixed3D;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReport.ColumnHeadersVisible = false;
			DataGridViewColumnCollection columns = this.dgvReport.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6, this.Column7 };
			columns.AddRange(column1);
			window.Alignment = DataGridViewContentAlignment.MiddleLeft;
			window.BackColor = SystemColors.Window;
			window.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			window.ForeColor = Color.Black;
			window.SelectionBackColor = Color.White;
			window.SelectionForeColor = Color.Black;
			window.WrapMode = DataGridViewTriState.False;
			this.dgvReport.DefaultCellStyle = window;
			this.dgvReport.GridColor = Color.WhiteSmoke;
			this.dgvReport.Location = new Point(12, 233);
			this.dgvReport.MultiSelect = false;
			this.dgvReport.Name = "dgvReport";
			this.dgvReport.ReadOnly = true;
			this.dgvReport.RowHeadersVisible = false;
			this.dgvReport.ScrollBars = ScrollBars.Vertical;
			this.dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvReport.Size = new System.Drawing.Size(972, 361);
			this.dgvReport.TabIndex = 2;
			this.bwrk1.DoWork += new DoWorkEventHandler(this.bwrk1_DoWork);
			this.bwrk1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwrk1_RunWorkerCompleted);
			this.panel1.BackgroundImage = Resources.head_bg;
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 33);
			this.panel1.TabIndex = 14;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 33);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 627);
			this.panel2.TabIndex = 15;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(995, 33);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 627);
			this.panel3.TabIndex = 16;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 33);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(994, 1);
			this.panel4.TabIndex = 17;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 659);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(994, 1);
			this.panel5.TabIndex = 18;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(436, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "To:";
			this.groupBox1.BackColor = Color.Transparent;
			this.groupBox1.Controls.Add(this.dtpToDate);
			this.groupBox1.Controls.Add(this.dtpFromDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new Point(12, 130);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(734, 42);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpToDate.Format = DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new Point(501, 14);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(95, 20);
			this.dtpToDate.TabIndex = 50;
			this.dtpToDate.ValueChanged += new EventHandler(this.dtpToDate_ValueChanged);
			this.dtpToDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpFromDate.Format = DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new Point(67, 14);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(95, 20);
			this.dtpFromDate.TabIndex = 48;
			this.dtpFromDate.ValueChanged += new EventHandler(this.dtpFromDate_ValueChanged);
			this.dtpFromDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.groupBox2.BackColor = Color.Transparent;
			this.groupBox2.Controls.Add(this.cmbSearchBy);
			this.groupBox2.Controls.Add(this.cmbSearchFor);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new Point(12, 178);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(734, 42);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			this.cmbSearchBy.Location = new Point(263, 17);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchBy.TabIndex = 18;
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbSearchBy_KeyDown);
			this.cmbSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchFor.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.cmbSearchFor.Items;
			objArray = new object[] { "All", "Voucher No", "Account Ledger" };
			objectCollections.AddRange(objArray);
			this.cmbSearchFor.Location = new Point(86, 17);
			this.cmbSearchFor.Name = "cmbSearchFor";
			this.cmbSearchFor.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchFor.TabIndex = 16;
			this.cmbSearchFor.SelectedIndexChanged += new EventHandler(this.cmbSearchFor_SelectedIndexChanged);
			this.cmbSearchFor.KeyDown += new KeyEventHandler(this.cmbSearchFor_KeyDown);
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Search For:";
			this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 138;
			this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 138;
			this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 138;
			this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 139;
			this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 138;
			this.dataGridViewTextBoxColumn6.HeaderText = "Column6";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 138;
			this.dataGridViewTextBoxColumn7.HeaderText = "Column7";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 138;
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column2.HeaderText = "Column2";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column3.HeaderText = "Column3";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column4.HeaderText = "Column4";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column5.HeaderText = "Column5";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column6.HeaderText = "Column6";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column7.HeaderText = "Column7";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			this.BackgroundImage = Resources.report_bg;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(996, 660);
			base.ControlBox = false;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnClear);
			base.Controls.Add(this.lblPhone);
			base.Controls.Add(this.lblPlace);
			base.Controls.Add(this.lblCompanyName);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.dgvReport);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.KeyPreview = true;
			base.Name = "rptJournalRegister";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.WindowState = FormWindowState.Maximized;
			base.KeyPress += new KeyPressEventHandler(this.rptJournalRegister_KeyPress);
			base.Load += new EventHandler(this.rptJournalRegister_Load);
			this.groupBox4.ResumeLayout(false);
			((ISupportInitialize)this.btnClose).EndInit();
			((ISupportInitialize)this.dgvReport).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		public void LoadCompanyDetails()
		{
			try
			{
				DataTable dataTable = new DataTable();
				this.CompanyInfo = this.CompanySP.CompanyView(MedicalShop.CompanyInfo._companyId);
				this.lblCompanyName.Text = this.CompanyInfo.CompanyName;
				this.lblPhone.Text = string.Concat("Phone : ", this.CompanyInfo.Pincode);
				string[] strArrays = Regex.Split(this.CompanyInfo.Address, "\r\n");
				string str = "";
				string[] strArrays1 = strArrays;
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					str = string.Concat(str, strArrays1[i], "  ");
				}
				if (!(str == " , "))
				{
					int length = str.Length;
					string str1 = str.Substring(0, length - 2);
					this.lblPlace.Text = str1;
				}
				else
				{
					this.lblPlace.Text = "";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void LoadGridColumns()
		{
			try
			{
				this.dgvReport.Columns.Clear();
				this.dgvReport.Rows.Clear();
				this.dgvReport.Columns.Add("Voucher No", "Voucher No");
				this.dgvReport.Columns.Add("Date", "Date");
				this.dgvReport.Columns.Add("Ledger", "Ledger");
				this.dgvReport.Columns.Add("Debit", "Debit");
				this.dgvReport.Columns.Add("Credit", "Credit");
				this.dgvReport.Rows.Add(1);
				this.dgvReport.Rows[0].Frozen = true;
				this.dgvReport[0, this.dgvReport.Rows.Count - 1].Value = "Voucher No";
				this.dgvReport[1, this.dgvReport.Rows.Count - 1].Value = "Date";
				this.dgvReport[2, this.dgvReport.Rows.Count - 1].Value = "Ledger";
				this.dgvReport[3, this.dgvReport.Rows.Count - 1].Value = "Debit";
				this.dgvReport[4, this.dgvReport.Rows.Count - 1].Value = "Credit";
				System.Drawing.Font font = new System.Drawing.Font(this.dgvReport.Font, FontStyle.Bold);
				this.dgvReport.Rows[0].DefaultCellStyle.Font = font;
				this.dgvReport.Rows[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
				this.dgvReport.CurrentRow.DefaultCellStyle.SelectionBackColor = this.dgvReport.CurrentRow.DefaultCellStyle.BackColor;
				this.dgvReport.CurrentRow.DefaultCellStyle.SelectionForeColor = this.dgvReport.CurrentRow.DefaultCellStyle.ForeColor;
				this.dgvReport.Rows[0].DefaultCellStyle.Font = font;
				this.dgvReport.Rows[0].Frozen = true;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rptJournalRegister_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\u001B')
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

		private void rptJournalRegister_Load(object sender, EventArgs e)
		{
			try
			{
				this.dtpFromDate.Value = FinacialYearInfo._fromDate;
				this.dtpToDate.Value = FinacialYearInfo._toDate;
				this.dtpFromDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpFromDate.MaxDate = FinacialYearInfo._toDate;
				this.dtpToDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpToDate.MaxDate = FinacialYearInfo._toDate;
				this.dgvReport.Rows.Clear();
				this.cmbExportType.SelectedIndex = 0;
				this.cmbSearchFor.SelectedIndex = 0;
				this.LoadCompanyDetails();
				this.LoadGridColumns();
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}