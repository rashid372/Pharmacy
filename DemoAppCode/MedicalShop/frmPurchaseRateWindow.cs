using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
    public class frmPurchaseRateWindow : Form
    {
        private bool isFromMdi = true;

        private IContainer components = null;

        private Panel panel1;

        private Panel panel8;

       // private Button btnOk;

        private Button btnClose;

        private Panel panel6;

        private Label label1;

        private Panel panel7;

        private Panel panel5;

        private Panel panel4;

        private Panel panel3;

        private Panel panel2;

        private DataGridView dgvFinancial;

        private DataGridViewTextBoxColumn ID;

        private DataGridViewTextBoxColumn FinacialYear;

        private DataGridViewTextBoxColumn From;

        private DataGridViewTextBoxColumn To;

        private DataGridViewTextBoxColumn Status;

        private DataGridViewTextBoxColumn productId;

        private DataGridViewTextBoxColumn BatchName;
        private DataGridViewTextBoxColumn PurchaseRate;
        private DataGridViewTextBoxColumn SalesRate;
        private DataGridViewTextBoxColumn MRP;
        private DataGridViewTextBoxColumn qty;



        public string _productId;

        public frmPurchaseRateWindow()
        {
            this.InitializeComponent();
        }
        public frmPurchaseRateWindow(string productId)
        {
            this.InitializeComponent();
            _productId = productId;
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MessageBox.Show("Do you want to close ?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               // this.SetFinacialYear();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void CallFromUserLogin()
        {
            this.isFromMdi = false;
            this.btnClose.Enabled = false;
            base.ControlBox = false;
            base.ShowDialog();
        }

        private void dgvFinancial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               // this.SetFinacialYear();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void dgvFinancial_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F6)
                {
                    this.Close();
                }
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

        public void FillFinacialYearGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable = (new ProductSP()).PurchaseRatePopupWindow(_productId);
            this.dgvFinancial.Rows.Clear();
            int str = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                this.dgvFinancial.Rows.Add();
                //this.dgvFinancial.Rows[str].Cells[0].Value = str;
                //this.dgvFinancial.Rows[str].Cells["productId"].Value = row.ItemArray[0].ToString();
                //this.dgvFinancial.Rows[str].Cells["BatchName"].Value = row.ItemArray[1].ToString();
                this.dgvFinancial.Rows[str].Cells["purchaseRate"].Value = row.ItemArray[0].ToString();
                this.dgvFinancial.Rows[str].Cells["SalesRate"].Value = row.ItemArray[1].ToString();
                this.dgvFinancial.Rows[str].Cells["MRP"].Value = row.ItemArray[2].ToString();
                this.dgvFinancial.Rows[str].Cells["qty"].Value = row.ItemArray[3].ToString();
                str++;
            }
        }

        private void frmSelectFinancialYear_Load(object sender, EventArgs e)
        {
            try
            {
                this.FillFinacialYearGrid();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectFinancialYear));
            this.panel1 = new Panel();
           // this.btnOk = new Button();
            this.panel8 = new Panel();
            this.dgvFinancial = new DataGridView();
            this.ID = new DataGridViewTextBoxColumn();

            //
            this.productId = new DataGridViewTextBoxColumn();
            this.BatchName = new DataGridViewTextBoxColumn();
            this.PurchaseRate = new DataGridViewTextBoxColumn();
            this.SalesRate = new DataGridViewTextBoxColumn();
            this.qty = new DataGridViewTextBoxColumn();
            this.MRP = new DataGridViewTextBoxColumn();
            this.FinacialYear = new DataGridViewTextBoxColumn();
            this.From = new DataGridViewTextBoxColumn();
            this.To = new DataGridViewTextBoxColumn();
            this.Status = new DataGridViewTextBoxColumn();
            this.btnClose = new Button();
            this.panel6 = new Panel();
            this.label1 = new Label();
            this.panel7 = new Panel();
            this.panel5 = new Panel();
            this.panel4 = new Panel();
            this.panel3 = new Panel();
            this.panel2 = new Panel();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((ISupportInitialize)this.dgvFinancial).BeginInit();
            this.panel6.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.Transparent;
            this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
            this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
          //  this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 321);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            //this.btnOk.BackColor = Color.FromArgb(255, 209, 150);
            //this.btnOk.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
            //this.btnOk.FlatStyle = FlatStyle.Flat;
            //this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            //this.btnOk.Location = new Point(113, 276);
            //this.btnOk.Name = "btnOk";
            //this.btnOk.Size = new System.Drawing.Size(75, 23);
            //this.btnOk.TabIndex = 17;
            //this.btnOk.Text = "&OK";
            //this.btnOk.UseVisualStyleBackColor = false;
            //this.btnOk.Click += new EventHandler(this.btnSave_Click);
            this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
            this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel8.Controls.Add(this.dgvFinancial);
            this.panel8.Dock = DockStyle.Top;
            this.panel8.Location = new Point(1, 34);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(276, 227);
            this.panel8.TabIndex = 0;
            this.dgvFinancial.AllowUserToAddRows = false;
            this.dgvFinancial.AllowUserToDeleteRows = false;
            this.dgvFinancial.AllowUserToResizeColumns = false;
            this.dgvFinancial.AllowUserToResizeRows = false;
            this.dgvFinancial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinancial.BackgroundColor = Color.White;
            this.dgvFinancial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumnCollection columns = this.dgvFinancial.Columns;
            DataGridViewColumn[] d = new DataGridViewColumn[] { this.PurchaseRate, this.SalesRate, this.qty ,this.MRP };
            columns.AddRange(d);
            this.dgvFinancial.GridColor = Color.WhiteSmoke;
            this.dgvFinancial.Location = new Point(8, 8);
            this.dgvFinancial.Name = "dgvFinancial";
            this.dgvFinancial.ReadOnly = true;
            this.dgvFinancial.RowHeadersVisible = false;
            this.dgvFinancial.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFinancial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinancial.Size = new System.Drawing.Size(260, 211);
            this.dgvFinancial.TabIndex = 20;
            this.dgvFinancial.KeyDown += new KeyEventHandler(this.dgvFinancial_KeyDown);
            this.dgvFinancial.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvFinancial_CellDoubleClick);
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;

            this.productId.HeaderText = "productId";
            this.productId.Name = "productId";
            this.productId.ReadOnly = true;
            this.productId.Visible = true;

            this.BatchName.HeaderText = "BatchName";
            this.BatchName.Name = "BatchName";
            this.BatchName.ReadOnly = true;
            this.BatchName.Visible = true;

            this.PurchaseRate.HeaderText = "PurchaseRate";
            this.PurchaseRate.Name = "PurchaseRate";
            this.PurchaseRate.ReadOnly = true;
            this.PurchaseRate.Visible = true;

            this.SalesRate.HeaderText = "SalesRate";
            this.SalesRate.Name = "SalesRate";
            this.SalesRate.ReadOnly = true;
            this.SalesRate.Visible = true;

            this.MRP.HeaderText = "MRP";
            this.MRP.Name = "MRP";
            this.MRP.ReadOnly = true;
            this.MRP.Visible = true;


            this.qty.HeaderText = "qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Visible = true;

            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.FinacialYear.HeaderText = "Purchase Rate Window";
            this.FinacialYear.Name = "Purchase Rate Window";
            this.FinacialYear.ReadOnly = true;
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            this.From.Visible = false;
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            this.To.Visible = false;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnClose.Location = new Point(194, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnclose_Click);
            this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(276, 33);
            this.panel6.TabIndex = 3;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Purchase Rate Window";
            this.panel7.BackColor = Color.FromArgb(136, 136, 136);
            this.panel7.Dock = DockStyle.Bottom;
            this.panel7.Location = new Point(0, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(276, 1);
            this.panel7.TabIndex = 3;
            this.panel5.BackColor = Color.FromArgb(136, 136, 136);
            this.panel5.Dock = DockStyle.Bottom;
            this.panel5.Location = new Point(1, 320);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(276, 1);
            this.panel5.TabIndex = 2;
            this.panel4.BackColor = Color.FromArgb(136, 136, 136);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 1);
            this.panel4.TabIndex = 1;
            this.panel3.BackColor = Color.FromArgb(136, 136, 136);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(277, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 321);
            this.panel3.TabIndex = 1;
            this.panel2.BackColor = Color.FromArgb(136, 136, 136);
            this.panel2.Dock = DockStyle.Left;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 321);
            this.panel2.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = Color.White;
            base.CancelButton = this.btnClose;
            base.ClientSize = new System.Drawing.Size(292, 335);
            base.Controls.Add(this.panel1);
            base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "frmPurchaseRateWindow";
            base.Padding = new System.Windows.Forms.Padding(7);
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Purchase Rate Window";
            base.Load += new EventHandler(this.frmSelectFinancialYear_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((ISupportInitialize)this.dgvFinancial).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            base.ResumeLayout(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        //public void SetFinacialYear()
        //{
        //    bool flag = true;
        //    CompanyPathInfo CompanyPathInfo = new CompanyPathInfo();
        //    if (this.dgvFinancial.CurrentRow != null)
        //    {
        //        if ((this.dgvFinancial.CurrentRow.Cells[0].Value == null ? false : this.dgvFinancial.CurrentRow.Cells[0].Value.ToString().Trim() != ""))
        //        {
        //            if ((!this.isFromMdi ? false : Application.OpenForms.Count > 2))
        //            {
        //                if (this.dgvFinancial.CurrentRow.Cells[1].Value != null)
        //                {
        //                    CompanyPathInfo.CompanyId = this.dgvFinancial.CurrentRow.Cells[0].Value.ToString();
        //                    CompanyPathInfo.CompanyName = this.dgvFinancial.CurrentRow.Cells[1].Value.ToString();
        //                    CompanyPathInfo.Path = "Default";
        //                    CompanyPathInfo.DefaultOrNot = true;
        //                    flag = true;
        //                }
        //                else if (MessageBox.Show("All the open windows will be closed if u change finacial year, Continue?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
        //                {
        //                    flag = false;
        //                }
        //                else
        //                {
        //                    for (int i = 0; i < Application.OpenForms.Count; i++)
        //                    {
        //                        if ((Application.OpenForms[i] == MDIMedicalShop.MDIObj || Application.OpenForms[i] == this ? false : Application.OpenForms[i].Name != "MDIForm"))
        //                        {
        //                            Application.OpenForms[i].Close();
        //                            i--;
        //                        }
        //                    }
        //                    flag = true;
        //                }
        //            }
        //            if ((flag ? true : !this.isFromMdi))
        //            {
        //                //FinacialYearInfo._fromDate = DateTime.Parse(this.dgvFinancial.CurrentRow.Cells[2].Value.ToString());
        //                //FinacialYearInfo._toDate = DateTime.Parse(this.dgvFinancial.CurrentRow.Cells[3].Value.ToString());
        //                //FinacialYearInfo._activeOrNot = bool.Parse(this.dgvFinancial.CurrentRow.Cells[4].Value.ToString());
        //                //  (new PrimaryDBSP()).CompanyPathDeleteByCompanyId(CompanyInfo._companyId);
        //                PrimaryDBSP companyPath = new PrimaryDBSP();
        //                if (companyPath.CompanyPathCheckExistnaceOfName(CompanyPathInfo.CompanyName) != "")
        //                {
        //                    companyPath.CompanyPathEdit(CompanyPathInfo);
        //                }
        //                else
        //                {
        //                    companyPath.CompanyPathAdd(CompanyPathInfo);
        //                }

        //                base.Close();
        //                MDIMedicalShop.MDIObj.Activate();
        //                MDIMedicalShop.MDIObj.EnableStaticTimer();
        //                Application.Restart();
        //            }
        //        }
        //    }
        //}



    }
}