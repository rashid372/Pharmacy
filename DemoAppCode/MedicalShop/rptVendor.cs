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
	public class rptVendor : Form
	{
		private MedicalShop.CompanyInfo CompanyInfo = new MedicalShop.CompanyInfo();

		private MedicalShop.CompanySP CompanySP = new MedicalShop.CompanySP();

		private MedicalShop.ManufacturerSP ManufacturerSP = new MedicalShop.ManufacturerSP();

		private string strFormat = "";

		private string strHeading = "";

		private int _pageNo = 0;

		private int _page = 0;

		private MedicalShop.frmCompanyProgress frmCompanyProgress = new MedicalShop.frmCompanyProgress();

		private IContainer components = null;

		private Label lblPlace;

		private Label lblInstitute;

		private GroupBox groupBox4;

		private Button btnExport;

		private ComboBox cmbExportType;

		private Label label5;

		private PictureBox btnClose;

		private Button btnClear;

		private DataGridView dgvVendor;

		private Label lblPhone;

		private ToolTip toolTip1;

		private BackgroundWorker bwrk1;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		public rptVendor()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.FillCompanyDetails();
				this.FillGridHeader();
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
				this.strHeading = " VENDOR REPORT";
				ExportToExcel exportToExcel = new ExportToExcel();
				if (this.strFormat == "Excel")
				{
					exportToExcel.ExportExcel(this.dgvVendor, this.strHeading, 0, 0, "Excel");
				}
				else if (this.strFormat == "Html")
				{
					exportToExcel.ExportExcel(this.dgvVendor, this.strHeading, 0, 0, "Html");
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

		private void dgvVendor_Click(object sender, EventArgs e)
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

		public void FillCompanyDetails()
		{
			try
			{
				MedicalShop.CompanySP companySP = new MedicalShop.CompanySP();
				DataTable dataTable = new DataTable();
				dataTable = companySP.CompanyViewAll();
				if (dataTable.Rows.Count > 0)
				{
					string str = dataTable.Rows[0].ItemArray[2].ToString();
					string[] strArrays = Regex.Split(str, "\r\n");
					string str1 = "";
					string[] strArrays1 = strArrays;
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						str1 = string.Concat(str1, strArrays1[i], " ");
					}
					this.lblInstitute.Text = dataTable.Rows[0].ItemArray[1].ToString();
					this.lblPlace.Text = str1;
					this.lblPhone.Text = string.Concat("Phone : ", dataTable.Rows[0].ItemArray[6].ToString());
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillGridHeader()
		{
			try
			{
				int lightSkyBlue = 0;
				System.Drawing.Font font = new System.Drawing.Font(this.dgvVendor.Font, FontStyle.Bold);
				DataTable dataTable = new DataTable();
				this.dgvVendor.Columns.Clear();
				this.dgvVendor.Columns.Add("0", "Sl No");
				this.dgvVendor.Columns.Add("1", "Name");
				this.dgvVendor.Columns.Add("2", "Address");
				this.dgvVendor.Columns.Add("3", "Country");
				this.dgvVendor.Columns.Add("4", "State");
				this.dgvVendor.Columns.Add("5", "Pin Code");
				this.dgvVendor.Columns.Add("6", "Phone");
				this.dgvVendor.Columns.Add("7", "Mobile");
				this.dgvVendor.Columns.Add("8", "Email Address");
				this.dgvVendor.Rows.Add();
				this.dgvVendor[0, lightSkyBlue].Value = "Sl No";
				this.dgvVendor[1, lightSkyBlue].Value = "Name";
				this.dgvVendor[2, lightSkyBlue].Value = "Address";
				this.dgvVendor[3, lightSkyBlue].Value = "Country";
				this.dgvVendor[4, lightSkyBlue].Value = "State";
				this.dgvVendor[5, lightSkyBlue].Value = "Pin Code";
				this.dgvVendor[6, lightSkyBlue].Value = "Phone";
				this.dgvVendor[7, lightSkyBlue].Value = "Mobile";
				this.dgvVendor[8, lightSkyBlue].Value = "Email Address";
				this.dgvVendor.Rows[lightSkyBlue].DefaultCellStyle.BackColor = Color.LightSkyBlue;
				this.dgvVendor.CurrentRow.DefaultCellStyle.SelectionBackColor = this.dgvVendor.CurrentRow.DefaultCellStyle.BackColor;
				this.dgvVendor.CurrentRow.DefaultCellStyle.SelectionForeColor = this.dgvVendor.CurrentRow.DefaultCellStyle.ForeColor;
				this.dgvVendor.Rows[lightSkyBlue].DefaultCellStyle.Font = font;
				this.dgvVendor.Rows[lightSkyBlue].Frozen = true;
				VendorSP vendorSP = new VendorSP();
				DataTable dataTable1 = new DataTable();
				dataTable1 = vendorSP.VendorViewAllExceptNA();
				int num = 1;
				if (dataTable1.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable1.Rows)
					{
						this.dgvVendor.Rows.Add();
						lightSkyBlue++;
						this.dgvVendor.Rows[lightSkyBlue].Cells[0].Value = num;
						this.dgvVendor.Rows[lightSkyBlue].Cells[1].Value = row.ItemArray[1].ToString();
						this.dgvVendor.Rows[lightSkyBlue].Cells[3].Value = row.ItemArray[3].ToString();
						this.dgvVendor.Rows[lightSkyBlue].Cells[4].Value = row.ItemArray[4].ToString();
						this.dgvVendor.Rows[lightSkyBlue].Cells[5].Value = row.ItemArray[5].ToString();
						this.dgvVendor.Rows[lightSkyBlue].Cells[6].Value = row.ItemArray[6].ToString();
						this.dgvVendor.Rows[lightSkyBlue].Cells[7].Value = row.ItemArray[7].ToString();
						this.dgvVendor.Rows[lightSkyBlue].Cells[8].Value = row.ItemArray[8].ToString();
						string str = row.ItemArray[2].ToString();
						string[] strArrays = Regex.Split(str, "\r\n");
						string str1 = "";
						string[] strArrays1 = strArrays;
						for (int i = 0; i < (int)strArrays1.Length; i++)
						{
							str1 = string.Concat(str1, strArrays1[i], "  ");
						}
						if (!(str1 == " , "))
						{
							int length = str1.Length;
							string str2 = str1.Substring(0, length - 2);
							this.dgvVendor.Rows[lightSkyBlue].Cells[2].Value = str2;
						}
						else
						{
							this.dgvVendor.Rows[lightSkyBlue].Cells[2].Value = "";
						}
						num++;
					}
				}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptVendor));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle window = new DataGridViewCellStyle();
			this.btnClear = new Button();
			this.groupBox4 = new GroupBox();
			this.btnExport = new Button();
			this.cmbExportType = new ComboBox();
			this.lblPhone = new Label();
			this.lblPlace = new Label();
			this.lblInstitute = new Label();
			this.label5 = new Label();
			this.btnClose = new PictureBox();
			this.dgvVendor = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.toolTip1 = new ToolTip(this.components);
			this.bwrk1 = new BackgroundWorker();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.panel5 = new Panel();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.groupBox4.SuspendLayout();
			((ISupportInitialize)this.btnClose).BeginInit();
			((ISupportInitialize)this.dgvVendor).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
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
			this.groupBox4.Location = new Point(752, 114);
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
			this.cmbExportType.Items.AddRange(new object[] { "Print", "Excel", "Html" });
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
			this.lblInstitute.BackColor = Color.Transparent;
			this.lblInstitute.Font = new System.Drawing.Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblInstitute.ForeColor = Color.DimGray;
			this.lblInstitute.Location = new Point(52, 43);
			this.lblInstitute.Name = "lblInstitute";
			this.lblInstitute.Size = new System.Drawing.Size(894, 30);
			this.lblInstitute.TabIndex = 5;
			this.lblInstitute.Text = "Name";
			this.lblInstitute.TextAlign = ContentAlignment.TopCenter;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Black;
			this.label5.Location = new Point(3, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Vendor";
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
			this.dgvVendor.AllowUserToAddRows = false;
			this.dgvVendor.AllowUserToDeleteRows = false;
			this.dgvVendor.AllowUserToResizeColumns = false;
			this.dgvVendor.AllowUserToResizeRows = false;
			this.dgvVendor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvVendor.BackgroundColor = Color.White;
			this.dgvVendor.BorderStyle = BorderStyle.Fixed3D;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = Color.LightSkyBlue;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvVendor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvVendor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVendor.ColumnHeadersVisible = false;
			DataGridViewColumnCollection columns = this.dgvVendor.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6, this.Column7 };
			columns.AddRange(column1);
			window.Alignment = DataGridViewContentAlignment.MiddleLeft;
			window.BackColor = SystemColors.Window;
			window.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			window.ForeColor = Color.Black;
			window.SelectionBackColor = Color.White;
			window.SelectionForeColor = Color.Black;
			window.WrapMode = DataGridViewTriState.False;
			this.dgvVendor.DefaultCellStyle = window;
			this.dgvVendor.GridColor = Color.WhiteSmoke;
			this.dgvVendor.Location = new Point(12, 179);
			this.dgvVendor.MultiSelect = false;
			this.dgvVendor.Name = "dgvVendor";
			this.dgvVendor.ReadOnly = true;
			this.dgvVendor.RowHeadersVisible = false;
			this.dgvVendor.ScrollBars = ScrollBars.Vertical;
			this.dgvVendor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvVendor.Size = new System.Drawing.Size(972, 415);
			this.dgvVendor.TabIndex = 2;
			this.dgvVendor.Click += new EventHandler(this.dgvVendor_Click);
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
			this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 138;
			this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 139;
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
			this.dataGridViewTextBoxColumn6.Width = 139;
			this.dataGridViewTextBoxColumn7.HeaderText = "Column7";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 138;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			this.BackgroundImage = Resources.report_bg;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(996, 660);
			base.ControlBox = false;
			base.Controls.Add(this.btnClear);
			base.Controls.Add(this.lblPhone);
			base.Controls.Add(this.lblPlace);
			base.Controls.Add(this.lblInstitute);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.dgvVendor);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.KeyPreview = true;
			base.Name = "rptVendor";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.WindowState = FormWindowState.Maximized;
			base.KeyPress += new KeyPressEventHandler(this.rptVendor_KeyPress);
			base.Load += new EventHandler(this.rptVendor_Load);
			this.groupBox4.ResumeLayout(false);
			((ISupportInitialize)this.btnClose).EndInit();
			((ISupportInitialize)this.dgvVendor).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		private void rptVendor_KeyPress(object sender, KeyPressEventArgs e)
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

		private void rptVendor_Load(object sender, EventArgs e)
		{
			try
			{
				this.cmbExportType.SelectedIndex = 0;
				this.FillCompanyDetails();
				this.FillGridHeader();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}