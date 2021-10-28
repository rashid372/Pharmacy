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
	public class rptStockandPrice: Form
	{
        private MedicalShop.DoctorSP DoctorSP = new MedicalShop.DoctorSP();

        private MedicalShop.CompanyInfo CompanyInfo = new MedicalShop.CompanyInfo();

        private MedicalShop.CompanySP CompanySP = new MedicalShop.CompanySP();

        private MedicalShop.frmCompanyProgress frmCompanyProgress = new MedicalShop.frmCompanyProgress();

        private string strFormat = "";

        private string strHeading = "";

        private int _pageNo = 0;

        private int _page = 0;

        private int inRow = 0;

        private bool nextPage = false;

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

        private GroupBox groupBox1;

        private DateTimePicker dtpTo;

        private DateTimePicker dtpFrom;
        private Label label2;

        private Label label1;

        private GroupBox groupBox2;

        private Label lblSearc;

        private ComboBox cmbSearchBy;

        private ComboBox cmbSearch;

        private CheckBox cbxPrint;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        public rptStockandPrice()
        {
            this.InitializeComponent();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.rtpProduct_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bwrk1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.strHeading = "STOCK AND PRICE REPORT";
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

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.FillLowStockGridAccordingToSearch();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillSerachComboOfLowStock();
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void FillLowStockGrid()
        {
            try
            {
                AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
                //ProductSP productSP = new ProductSP();
                int str = 1;
                DataTable dataTable = new DataTable();
                foreach (DataRow row in accountLedgerSP.stockByManufactureAndPrice().Rows)
                {
                    this.dgvReport.Rows.Add();
                    this.dgvReport.Rows[str].Cells[0].Value = str;
                    this.dgvReport[1, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[0].ToString();
                    this.dgvReport[2, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[1].ToString();
                    this.dgvReport[3, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[2].ToString();
                    this.dgvReport[4, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[3].ToString();
                    this.dgvReport[5, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[4].ToString();
                    this.dgvReport[6, this.dgvReport.Rows.Count - 1].Value = row.ItemArray[5].ToString();
                    str++;
                    
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FillLowStockGridAccordingToSearch()
        {
            try
            {
                if (!(this.cmbSearchBy.Text != "All"))
                {
                    this.LoadGridColumns();
                    this.FillLowStockGrid();
                    this.cmbSearch.Visible = false;
                }
                else
                {
                    int num = 0;
                    
                    
                     if (this.cmbSearchBy.Text == "Manufacture")
                    {
                        num = 2;
                    }
                    if (this.cmbSearch.SelectedIndex > 0)
                    {
                        for (int i = 1; i < this.dgvReport.Rows.Count; i++)
                        {
                            if (!this.dgvReport.Rows[i].Cells[num].Value.ToString().ToLower().StartsWith(this.cmbSearch.Text.ToString().ToLower()))
                            {
                                this.dgvReport.Rows[i].Visible = false;
                            }
                            else
                            {
                                this.dgvReport.Rows[i].Visible = true;
                            }
                        }
                    }
                    this.cmbSearch.Visible = true;
                }
            }
            catch (Exception exception2)
            {
                Exception exception1 = exception2;
                MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FillSerachComboOfLowStock()
        {
            try
            {
                 if (!(this.cmbSearchBy.Text == "Manufacture"))
                {
                    this.cmbSearch.SelectedIndex = -1;
                }
                else
                {
                    ManufacturerSP manufacturerSP = new ManufacturerSP();
                    DataTable dataTable4 = new DataTable();
                    dataTable4 = manufacturerSP.ManufacturerViewAll();
                    this.cmbSearch.DataSource = dataTable4;
                    this.cmbSearch.DisplayMember = "Name";
                    
                    this.cmbSearch.ValueMember = "ID";
                    this.cmbSearch.SelectedValue = "0";
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbExportType = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bwrk1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxPrint = new System.Windows.Forms.CheckBox();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.lblSearc = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = global::MedicalShop.Properties.Resources.RefreshIcon;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.Location = new System.Drawing.Point(12, 87);
            this.btnClear.Margin = new System.Windows.Forms.Padding(10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 30);
            this.btnClear.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnClear, "Reset");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.cmbExportType);
            this.groupBox4.Location = new System.Drawing.Point(752, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 45);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImage = global::MedicalShop.Properties.Resources.ExportIcon;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.Location = new System.Drawing.Point(189, 11);
            this.btnExport.Margin = new System.Windows.Forms.Padding(10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(30, 30);
            this.btnExport.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnExport, "Export");
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbExportType
            // 
            this.cmbExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExportType.FormattingEnabled = true;
            this.cmbExportType.Location = new System.Drawing.Point(6, 18);
            this.cmbExportType.Name = "cmbExportType";
            this.cmbExportType.Size = new System.Drawing.Size(170, 21);
            this.cmbExportType.TabIndex = 0;
            this.cmbExportType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbExportType_KeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(328, 95);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(337, 18);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone : 0494 2423344";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlace
            // 
            this.lblPlace.BackColor = System.Drawing.Color.Transparent;
            this.lblPlace.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlace.ForeColor = System.Drawing.Color.Black;
            this.lblPlace.Location = new System.Drawing.Point(57, 74);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(878, 18);
            this.lblPlace.TabIndex = 6;
            this.lblPlace.Text = "Kakkenchery ,Malappuram";
            this.lblPlace.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.DimGray;
            this.lblCompanyName.Location = new System.Drawing.Point(52, 43);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(894, 30);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "Name";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stock And Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "From:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(971, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeColumns = false;
            this.dgvReport.AllowUserToResizeRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReport.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReport.Location = new System.Drawing.Point(12, 233);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(972, 361);
            this.dgvReport.TabIndex = 2;
            // 
            // bwrk1
            // 
            this.bwrk1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrk1_DoWork);
            this.bwrk1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrk1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MedicalShop.Properties.Resources.head_bg;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 33);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 627);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(995, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 627);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(994, 1);
            this.panel4.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 659);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(994, 1);
            this.panel5.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 42);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(200, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(117, 20);
            this.dtpTo.TabIndex = 27;
            this.dtpTo.ValueChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            this.dtpTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFrom_KeyDown);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(49, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(117, 20);
            this.dtpFrom.TabIndex = 26;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            this.dtpFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFrom_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbxPrint);
            this.groupBox2.Controls.Add(this.cmbSearch);
            this.groupBox2.Controls.Add(this.cmbSearchBy);
            this.groupBox2.Controls.Add(this.lblSearc);
            this.groupBox2.Location = new System.Drawing.Point(14, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 42);
            this.groupBox2.TabIndex = 21;
           this. groupBox2.Visible = true;
            this.groupBox2.TabStop = false;
            // 
            // cbxPrint
            // 
            this.cbxPrint.AutoSize = true;
            this.cbxPrint.Location = new System.Drawing.Point(515, 20);
            this.cbxPrint.Name = "cbxPrint";
            this.cbxPrint.Size = new System.Drawing.Size(138, 17);
            this.cbxPrint.TabIndex = 105;
            this.cbxPrint.Text = "Available Products Only";
            this.cbxPrint.UseVisualStyleBackColor = true;
            this.cbxPrint.CheckedChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(293, 15);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(148, 21);
            this.cmbSearch.TabIndex = 28;
            this.cmbSearch.TabStop = false;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            this.cmbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbExportType_KeyDown);
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(86, 15);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
            this.cmbSearchBy.TabIndex = 27;
            this.cmbSearchBy.TabStop = false;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            this.cmbSearchBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbExportType_KeyDown);
            // 
            // lblSearc
            // 
            this.lblSearc.AutoSize = true;
            this.lblSearc.Location = new System.Drawing.Point(6, 19);
            this.lblSearc.Name = "lblSearc";
            this.lblSearc.Size = new System.Drawing.Size(59, 13);
            this.lblSearc.TabIndex = 26;
            this.lblSearc.Text = "Search By:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 138;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 138;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 138;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 139;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 138;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 138;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Column7";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 138;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // rptStockandPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MedicalShop.Properties.Resources.report_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(996, 660);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "rptStockandPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rtpProduct_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtpProduct_KeyPress);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private void RefreshForm()
        {
            try
            {
                SettingsSP settingsSP = new SettingsSP();
                SettingsInfo settingsInfo = new SettingsInfo();
                settingsInfo = settingsSP.SettingsView("1");
                this.FillLowStockGrid();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rtpProduct_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rtpProduct_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbSearch.Visible = false;
                this.cbxPrint.Checked = false;
                this.cmbSearchBy.Text = "All";
                this.cmbExportType.SelectedIndex = 0;
                this.LoadCompanyDetails();
                this.LoadGridColumns();
                this.RefreshForm();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        public void FillGrid()
        {
            AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
            DataTable dataTable = new DataTable();
            dataTable = accountLedgerSP.stockByManufactureAndPrice();
            int str = 1;
            this.dgvReport.Rows.Clear();
            this.LoadGridColumns();
            foreach (DataRow row in dataTable.Rows)
            {
                this.dgvReport.Rows.Add();
                this.dgvReport.Rows[str].Cells[0].Value = str;
                this.dgvReport.Rows[str].Cells["manufactureId"].Value = row.ItemArray[0].ToString();
                this.dgvReport.Rows[str].Cells["manufactureName"].Value = row.ItemArray[1].ToString();
                this.dgvReport.Rows[str].Cells["productId"].Value = row.ItemArray[2].ToString();
                this.dgvReport.Rows[str].Cells["productName"].Value = row.ItemArray[3].ToString();
                this.dgvReport.Rows[str].Cells["productCount"].Value = row.ItemArray[4].ToString();
                this.dgvReport.Rows[str].Cells["price"].Value = row.ItemArray[5].ToString();
               
                str++;
            }
        }
        public void LoadGridColumns()
        {
            try
            {
                this.dgvReport.Columns.Clear();
                this.dgvReport.Rows.Clear();
                this.dgvReport.Columns.Add("Sl No", "Sl No");
                this.dgvReport.Columns.Add("manufactureId", "manufactureId");
                this.dgvReport.Columns.Add("manufactureName", "manufactureName");
                this.dgvReport.Columns.Add("productId", "productId");
                this.dgvReport.Columns.Add("productName.", "productName");
                this.dgvReport.Columns.Add("productCount", "productCount");
                this.dgvReport.Columns.Add("price", "price");
                
                this.dgvReport.Columns[2].Width = 200;
                this.dgvReport.Columns[0].Width = 50;
                this.dgvReport.Columns[4].Width = 200;
                this.dgvReport.Rows.Add(1);
                this.dgvReport.Rows[0].Frozen = true;
                this.dgvReport[0, this.dgvReport.Rows.Count - 1].Value = "Sl No";
                this.dgvReport[1, this.dgvReport.Rows.Count - 1].Value = "manufactureId";
                this.dgvReport[2, this.dgvReport.Rows.Count - 1].Value = "manufactureName";
                this.dgvReport[3, this.dgvReport.Rows.Count - 1].Value = "productId";
                this.dgvReport[4, this.dgvReport.Rows.Count - 1].Value = "productName";
                this.dgvReport[5, this.dgvReport.Rows.Count - 1].Value = "productCount";
                this.dgvReport[6, this.dgvReport.Rows.Count - 1].Value = "price";
               
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
       
        private void daToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptStockandPrice _rptstockandprice = new rptStockandPrice();
            rptStockandPrice item = Application.OpenForms["rptStockandPrice"] as rptStockandPrice;
            if (item != null)
            {
                item.MdiParent = this;
                if (item.WindowState != FormWindowState.Minimized)
                {
                    item.Activate();
                }
                else
                {
                    item.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                _rptstockandprice.WindowState = FormWindowState.Normal;
                _rptstockandprice.MdiParent = this;
                _rptstockandprice.Show();
            }
        }
        private void dtpFrom_KeyDown(object sender, KeyEventArgs e)
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

    }
	}

