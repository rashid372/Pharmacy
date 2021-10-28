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
	public class rptMonthlyIncomeExpense : Form
	{
        private MedicalShop.DoctorSP DoctorSP = new MedicalShop.DoctorSP();

        private MedicalShop.CompanyInfo CompanyInfo = new MedicalShop.CompanyInfo();

        private MedicalShop.CompanySP CompanySP = new MedicalShop.CompanySP();

        private MedicalShop.frmCompanyProgress frmCompanyProgress = new MedicalShop.frmCompanyProgress();

        private string strFormat = "";

        private string strHeading = "";

        private int _pageNo = 0;

        private int _page = 0;

        private IContainer components = null;

        private Label lblPlace;

        private Label lblCompanyName;

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

        private GroupBox groupBox2;

        private Label lblSearc;

        private ComboBox cmbSearchFor;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

        private ComboBox cmbSearchBy;

        private GroupBox groupBox1;

        private DateTimePicker dtpFrom;

        private Label label1;

        private GroupBox groupBox4;

        private Button btnExport;

        private ComboBox cmbExportType;


        public rptMonthlyIncomeExpense()
        {
            this.InitializeComponent();
        }
        


    

       




        public void FillGrid()
        {
            AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
            DataTable dataTable = new DataTable();
            dataTable = accountLedgerSP.MonthlyIncomeExpenseView(DateTime.Parse(this.dtpFrom.Text));
            int str = 1;
            this.dgvReport.Rows.Clear();
            this.LoadGridColumns();
            foreach (DataRow row in dataTable.Rows)
            {
                this.dgvReport.Rows.Add();
                this.dgvReport.Rows[str].Cells[0].Value = str;
                this.dgvReport.Rows[str].Cells["Date"].Value = row.ItemArray[0].ToString();
                this.dgvReport.Rows[str].Cells["countersale"].Value = row.ItemArray[1].ToString();
                this.dgvReport.Rows[str].Cells["sale"].Value = row.ItemArray[2].ToString();
               // this.dgvReport.Rows[str].Cells["TotalSale"].Value = row.ItemArray[3].ToString();
                this.dgvReport.Rows[str].Cells["purchases"].Value = row.ItemArray[3].ToString();
                this.dgvReport.Rows[str].Cells["CashInHand"].Value = row.ItemArray[4].ToString();

                str++;
            }

            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
           // decimal num13 = new decimal(0);
            foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvReport.Rows)
            {
                if ((dataGridViewRow.Index <= 0 ? false : dataGridViewRow.Visible))
                {
                    decimal num2 = new decimal(0);
                    try
                    {
                        num2 = decimal.Parse(dataGridViewRow.Cells[2].Value.ToString());
                    }
                    catch (Exception exception)
                    {
                    }
                    decimal num6 = new decimal(0);
                    try
                    {
                        num6 = decimal.Parse(dataGridViewRow.Cells[3].Value.ToString());
                    }
                    catch (Exception exception)
                    {
                    }
                    decimal num12 = new decimal(0);
                    try
                    {
                        num12 = decimal.Parse(dataGridViewRow.Cells[4].Value.ToString());
                    }
                    catch (Exception exception)
                    {
                    }
                    decimal num3 = new decimal(0);
                    try
                    {
                        num3 = decimal.Parse(dataGridViewRow.Cells[5].Value.ToString());
                    }
                    catch (Exception exception1)
                    {
                    }

                    decimal num5 = new decimal(0);
                    try
                    {
                        num5 = decimal.Parse(dataGridViewRow.Cells[6].Value.ToString());
                    }
                    catch (Exception exception1)
                    {
                    }
                    num = num + num3;
                    num1 = num1 + num2;
                    num8 = num8 + num6;
                    num9 = num9 + num12;
                   // num10 = num10 + num11;
                    num10 = num10 + num5;
                }
            }
            this.dgvReport.Rows.Add();
            this.dgvReport.Rows.Add();
            //this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = "____________________";
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "____________________";
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = "____________________";
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[4].Value = "____________________";
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[5].Value = "____________________";
            //this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[6].Value = "____________________";
            this.dgvReport.Rows.Add();
            num1 = Math.Round(num1, 2);
            num = Math.Round(num, 2);
            num8 = Math.Round(num8, 2);
            num9 = Math.Round(num9, 2);
            num10 = Math.Round(num10, 2);
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = num1;
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = num8;
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[4].Value = num9;
            this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[5].Value = num;
            ////this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[6].Value = num10;



            if (num1 != num)
            {
                this.dgvReport.Rows.Add();
                decimal num4 = new decimal(0);
                if (!(num1 > num))
                {
                    num4 = num - num1;
                    this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = string.Concat("Total : ", num1, "Cr");
                }
                else
                {
                    num4 = num1 - num;
                    this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = string.Concat("Total : ", num1, "Dr");
                }
                System.Drawing.Font font = new System.Drawing.Font(this.dgvReport.Font, FontStyle.Bold);
                this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
            }
        }

        private void FillGridAccordingToSearch()
        {
            this.FillGrid();
            if (!(this.cmbSearchBy.Text != "All"))
            {
                this.cmbSearchFor.Enabled = false;
            }
            else
            {
                int num = 0;
                //if (this.cmbSearchBy.Text == "Date")
                //{
                //    num = 1;
                //}
                //else if (this.cmbSearchBy.Text == "CounterSale")
                //{
                //    num = 3;
                //}
                for (int i = 1; i < this.dgvReport.Rows.Count; i++)
                {
                    if (!this.dgvReport.Rows[i].Cells[num].Value.ToString().ToLower().StartsWith(this.cmbSearchFor.Text.ToLower()))
                    {
                        this.dgvReport.Rows[i].Visible = false;
                    }
                    else
                    {
                        this.dgvReport.Rows[i].Visible = true;
                    }
                }
                this.cmbSearchFor.Enabled = true;
            }
        }

        private void FillSerachCombo()
        {
            if (this.cmbSearchBy.Text == "All")
            {
                AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
                DataTable dataTable = new DataTable();
                dataTable = accountLedgerSP.AccountLedgerViewAll();
                this.cmbSearchFor.DataSource = dataTable;
                this.cmbSearchFor.DisplayMember = "Name";
                this.cmbSearchFor.ValueMember = "ID";
                this.cmbSearchFor.SelectedValue = "1";
            }
            //if (!(this.cmbSearchBy.Text == "Date"))
            //{
            //    this.cmbSearchFor.SelectedIndex = -1;
            //}
            else
            {
                DataTable dataTable1 = new DataTable();
                DataRow dataRow = dataTable1.NewRow();
                DataColumn dataColumn = new DataColumn();
                dataTable1.Columns.Add(dataColumn);
                dataRow[dataColumn] = "Date";
                dataTable1.Rows.Add(dataRow);
                //    dataRow = dataTable1.NewRow();
                //    dataRow[dataColumn] = "CounterSale";
                //    dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Sales Invoice";
                //dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Sales Return";
                //dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Counter Sale";
                //dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Payment Voucher";
                //dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Receipt Voucher";
                //dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Damage Stock";
                //dataTable1.Rows.Add(dataRow);
                //dataRow = dataTable1.NewRow();
                //dataRow[dataColumn] = "Stock Entry";
                //dataTable1.Rows.Add(dataRow);
                this.cmbSearchFor.DataSource = dataTable1;
                this.cmbSearchFor.DisplayMember = dataTable1.Columns[0].ToString();
            }
        }




        public void LoadGridColumns()
        {
            try
            {
                this.dgvReport.Columns.Clear();
                this.dgvReport.Rows.Clear();
                this.dgvReport.Columns.Add("Sl No", "Sl No");
                this.dgvReport.Columns.Add("Date", "Date");
                this.dgvReport.Columns.Add("countersale", "countersale");
                this.dgvReport.Columns.Add("sale", "sale");
                //this.dgvReport.Columns.Add("TotalSale", "TotalSale");
                this.dgvReport.Columns.Add("purchases", "purchases");
                this.dgvReport.Columns.Add("CashInHand", "CashInHand");
                
          
               
                this.dgvReport.Columns[0].Width = 50;
                this.dgvReport.Columns[3].Width = 150;
                this.dgvReport.Rows.Add();
                this.dgvReport.Rows[0].Frozen = true;
                this.dgvReport[0, this.dgvReport.Rows.Count - 1].Value = "Sl No";
                this.dgvReport[1, this.dgvReport.Rows.Count - 1].Value = "Date";
                this.dgvReport[2, this.dgvReport.Rows.Count - 1].Value = "countersale";
                this.dgvReport[3, this.dgvReport.Rows.Count - 1].Value = "sale";
                //this.dgvReport[4, this.dgvReport.Rows.Count - 1].Value = "TotalSale";
                
                this.dgvReport[4, this.dgvReport.Rows.Count - 1].Value = "purchases";
                this.dgvReport[5, this.dgvReport.Rows.Count - 1].Value = "CashInHand";
               
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

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.FillSerachCombo();
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bwrk1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ExportToExcel exportToExcel = new ExportToExcel();
                if (this.strFormat == "Excel")
                {
                    exportToExcel.ExportExcel(this.dgvReport, this.strHeading, 0, 1, "Excel");
                }
                else if (this.strFormat == "Html")
                {
                    exportToExcel.ExportExcel(this.dgvReport, this.strHeading, 0, 1, "Html");
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
                this.FillGridAccordingToSearch();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.rptTaxReport_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }
   


        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbSearchBy.Text = "All";
                this.FillGrid();
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptMonthlyIncomeExpense));
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle window = new DataGridViewCellStyle();
            this.btnClear = new Button();
            this.lblPhone = new Label();
            this.lblPlace = new Label();
            this.lblCompanyName = new Label();
            this.label5 = new Label();
            this.btnClose = new PictureBox();
            this.dgvReport = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.Column5 = new DataGridViewTextBoxColumn();
            this.Column6 = new DataGridViewTextBoxColumn();
            this.Column7 = new DataGridViewTextBoxColumn();
            this.toolTip1 = new ToolTip(this.components);
            this.btnExport = new Button();
            this.bwrk1 = new BackgroundWorker();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.panel3 = new Panel();
            this.panel4 = new Panel();
            this.panel5 = new Panel();
            this.groupBox2 = new GroupBox();
            this.cmbSearchFor = new ComboBox();
            this.cmbSearchBy = new ComboBox();
            this.lblSearc = new Label();
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.dtpFrom = new DateTimePicker();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            this.groupBox4 = new GroupBox();
            this.cmbExportType = new ComboBox();
            ((ISupportInitialize)this.btnClose).BeginInit();
            ((ISupportInitialize)this.dgvReport).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.label5.Size = new System.Drawing.Size(111, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Monthly Expense";
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
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.Controls.Add(this.cmbSearchFor);
            this.groupBox2.Controls.Add(this.cmbSearchBy);
            this.groupBox2.Controls.Add(this.lblSearc);
            this.groupBox2.Location = new Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 49);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.cmbSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSearchFor.FormattingEnabled = true;
            this.cmbSearchFor.Location = new Point(293, 12);
            this.cmbSearchFor.Name = "cmbSearchFor";
            this.cmbSearchFor.Size = new System.Drawing.Size(148, 21);
            this.cmbSearchFor.TabIndex = 28;
            this.cmbSearchFor.TabStop = false;
            this.cmbSearchFor.SelectedIndexChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
            this.cmbSearchFor.KeyDown += new KeyEventHandler(this.cmbExportType_KeyDown);
            this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            ComboBox.ObjectCollection items = this.cmbSearchBy.Items;
            object[] objArray = new object[] { "All" };
            items.AddRange(objArray);
            this.cmbSearchBy.Location = new Point(86, 14);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
            this.cmbSearchBy.TabIndex = 27;
            this.cmbSearchBy.TabStop = false;
            this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbExportType_KeyDown);
            this.lblSearc.AutoSize = true;
            this.lblSearc.Location = new Point(6, 16);
            this.lblSearc.Name = "lblSearc";
            this.lblSearc.Size = new System.Drawing.Size(59, 13);
            this.lblSearc.TabIndex = 26;
            this.lblSearc.Text = "Search By:";
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Location = new Point(18, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 42);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Date:";
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Format = DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new Point(49, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(117, 20);
            this.dtpFrom.TabIndex = 26;
            this.dtpFrom.ValueChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
            this.dtpFrom.KeyDown += new KeyEventHandler(this.dtpFrom_KeyDown);
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
            this.groupBox4.BackColor = Color.Transparent;
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.cmbExportType);
            this.groupBox4.Location = new Point(758, 130);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 45);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.cmbExportType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbExportType.FormattingEnabled = true;
            ComboBox.ObjectCollection objectCollections = this.cmbExportType.Items;
            objArray = new object[] { "Print", "Excel", "Html" };
            objectCollections.AddRange(objArray);
            this.cmbExportType.Location = new Point(6, 18);
            this.cmbExportType.Name = "cmbExportType";
            this.cmbExportType.Size = new System.Drawing.Size(170, 21);
            this.cmbExportType.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = Color.White;
            this.BackgroundImage = Resources.report_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new System.Drawing.Size(996, 660);
            base.ControlBox = false;
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.btnClear);
            base.Controls.Add(this.lblPhone);
            base.Controls.Add(this.lblPlace);
            base.Controls.Add(this.lblCompanyName);
            base.Controls.Add(this.panel5);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.dgvReport);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.KeyPreview = true;
            base.Name = "rptMonthlyIncomeExpense";
            base.StartPosition = FormStartPosition.CenterScreen;
            base.WindowState = FormWindowState.Maximized;
            base.KeyDown += new KeyEventHandler(this.rptMinimumStock_KeyDown);
            base.Load += new EventHandler(this.rptTaxReport_Load);
            ((ISupportInitialize)this.btnClose).EndInit();
            ((ISupportInitialize)this.dgvReport).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void LoadCompanyDetails()
        {
            try
            {
                DataTable dataTable = new DataTable();
                this.CompanyInfo = this.CompanySP.CompanyView(MedicalShop.CompanyInfo._companyId);
                this.lblCompanyName.Text = this.CompanyInfo.CompanyName;
                this.lblPhone.Text = this.CompanyInfo.Pincode;
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
            this.cmbSearchBy.Text = "All";
            this.cmbSearchFor.Enabled = false;
            this.FillGrid();
        }

        private void rptMinimumStock_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
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

        private void rptTaxReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtpFrom.MinDate = FinacialYearInfo._fromDate;
                this.dtpFrom.MaxDate = FinacialYearInfo._toDate;
                this.cmbSearchFor.Enabled = false;
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

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar <= '/' || e.KeyChar >= ':' ? e.KeyChar != '\b' : false))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void daToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptMonthlyIncomeExpense _rptMonthlyincomeexpense = new rptMonthlyIncomeExpense();
            rptMonthlyIncomeExpense item = Application.OpenForms["rptMonthlyIncomeExpense"] as rptMonthlyIncomeExpense;
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
                _rptMonthlyincomeexpense.WindowState = FormWindowState.Normal;
                _rptMonthlyincomeexpense.MdiParent = this;
                _rptMonthlyincomeexpense.Show();
            }
        }

    }
	}
