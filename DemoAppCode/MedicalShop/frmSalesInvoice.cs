using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmSalesInvoice : Form
	{


        // for PrintDialog, PrintPreviewDialog and PrintDocument:
        private PrintDialog prnDialog;
        private PrintPreviewDialog prnPreview;
        private PrintDocument prnDocument;
        private InvoiceDataInfo invoicedatainfo;
        
        // for Database:
        private SqlConnection cnn;
        private SqlCommand cmd;
        private SqlDataReader rdrInvoice;
        private string strCon;
        private string InvSql;
        SalesMasterSP salesMasterSP = new SalesMasterSP();
        SalesMasterInfo salesMasterInfo = new SalesMasterInfo();






        // for Report:
        private int CurrentY;
        private int CurrentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;
        private string CustomerName;
        private string CustomerCity;
        private string SellerName;
        private string SaleID;
        private string SaleDate;
        private decimal SaleFreight;
        private decimal SubTotal;
        private decimal InvoiceTotal;
        private bool ReadInvoice;
        private int AmountPosition;
        private string Phone;
        // for Invoice Head:
        private string InvTitle;
        private string InvSubTitle1;
        private string InvSubTitle2;
        private string InvSubTitle3;
        private string InvImage;


        // Font and Color:------------------
        // Title Font
        private Font InvTitleFont = new Font("Arial", 24, FontStyle.Regular);
        // Title Font height
        private int InvTitleHeight;
        // SubTitle Font
        private Font InvSubTitleFont = new Font("Arial", 14, FontStyle.Regular);
        // SubTitle Font height
        private int InvSubTitleHeight;
        // Invoice Font
        private Font InvoiceFont = new Font("Arial", 12, FontStyle.Regular);
        // Invoice Font height
        private int InvoiceFontHeight;
        // Blue Color
        private SolidBrush BlueBrush = new SolidBrush(Color.Black);
        // Red Color
        private SolidBrush RedBrush = new SolidBrush(Color.Black);
        // Black Color
        private SolidBrush BlackBrush = new SolidBrush(Color.Black);
        private int rowIndex;

		private int columnIndex;

		private ProductSP productsp = new ProductSP();

		private LedgerPostingSP ledgerpostingsp = new LedgerPostingSP();

		private frmSalesRegister frmRegister;

		private DataTable dtblRemovedPurchaseId = new DataTable();

		private bool isRepeated = false;

		private bool isInEditMode = false;

		private bool isFromSalesregister = false;

		private bool isFormClose = false;

		private bool isCellEdit = false;

		private bool isCellValueChanged = false;

		private bool isSaved = false;

		private string strDefaultCurrency = "";

		private int inDescriptionCount = 0;

		private DataTable dtblRemovedSalesId = new DataTable();

		private ComboBox cbm;

		private DataGridViewCell currentCell;

		private bool isCreditSale = false;

		private int j = 0;

		private int p = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label lblBlnceAmount;

		private Button btnNewledgers;

		private DateTimePicker dtpDate;

		private Label label3;

		private TextBox txtVoucherNo;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private TextBox txtInvoice;

		private Label label14;

		private Label label13;

		private ComboBox cmbCashVendor;

		private Label label15;

		private Label label5;

		private TextBox txtDescription;

		private Label lblGrandTotal;

		private Label lblGrand;

		private Label label22;

		private TextBox txtBillDiscount;

		private Label lblTotalAmount;

		private Label lblTot;

		private Label lblTaxAmount;

		private Label lblTax;
        private Label lblRows;
        private Label lblCountRows;

        private Label lblRemBalance;
        private Label RemBalance;

        private CheckBox chbxprint;
        private CheckBox chbxwarranty;

        private Label label7;

		private Button btnRemove;

		private dgv.DataGridViewEnter dgvSalesInvoice;

		private ComboBox cmbSalesman;

		private Label label9;

		private ComboBox cmbDoctor;

		private Label label8;

		private ComboBox cmbPatient;

		private Label label6;

		private Button btnNewSalesman;

		private Label lblPaidAmount;

		private TextBox txtPaidAmount;

		private Label lblBalanceAmount;

		private Label lblBalance;
        private Label lblRemainingBalance;

		private ListBox lstbxBatch;

		private DataGridViewCheckBoxColumn Column2;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewComboBoxColumn cmbProduct;

		private DataGridViewTextBoxColumn cmbBatch;

		private DateInGrid.CalendarColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column7;

		private DataGridViewTextBoxColumn Column8;

		private DataGridViewTextBoxColumn Column9;

		private DataGridViewTextBoxColumn Column10;

		private DataGridViewTextBoxColumn Column11;

		private DataGridViewTextBoxColumn Column12;

		private DataGridViewTextBoxColumn Column13;

		private DataGridViewTextBoxColumn Column14;

		private DataGridViewComboBoxColumn Column15;

		private DataGridViewTextBoxColumn Column16;

		private DataGridViewTextBoxColumn Column17;

		private DataGridViewTextBoxColumn Column18;

		private DataGridViewTextBoxColumn Column19;

		private PictureBox pbxSearch;

		private Label lblTotalNew;



        private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            leftMargin = (int)e.MarginBounds.Left;
            rightMargin = (int)e.MarginBounds.Right;
            topMargin = (int)e.MarginBounds.Top;
            bottomMargin = (int)e.MarginBounds.Bottom;
            InvoiceWidth = (int)e.MarginBounds.Width;
            InvoiceHeight = (int)e.MarginBounds.Height;

            if (!ReadInvoice)
                //ReadInvoiceData();

            invoicedatainfo.Address = ConfigurationSettings.AppSettings["NoWr_Address"].ToString();
            invoicedatainfo.Phone = ConfigurationSettings.AppSettings["NoWr_Phone"].ToString();
            invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["NoWr_CompanyName"].ToString();

            InvTitle = invoicedatainfo.CompanyName;
            InvSubTitle1 = invoicedatainfo.Address;
            InvSubTitle2 = invoicedatainfo.Phone;

            SetInvoiceHead(e.Graphics); // Draw Invoice Head
            SetOrderData(e.Graphics); // Draw Order Data
            SetInvoiceData(e.Graphics, e); // Draw Invoice Data


            ReadInvoice = true;
        }

        private void SetInvoiceHead(Graphics g)
        {
            //ReadInvoiceHead();

            CurrentY = topMargin;
            CurrentX = leftMargin;
            int ImageHeight = 0;

            // Draw Invoice image:
            if (System.IO.File.Exists(InvImage))
            {
                Bitmap oInvImage = new Bitmap(InvImage);
                // Set Image Left to center Image:
                int xImage = CurrentX + (InvoiceWidth - oInvImage.Width) / 2;
                ImageHeight = oInvImage.Height; // Get Image Height
                g.DrawImage(oInvImage, xImage, CurrentY);
            }

            InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
            InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

            // Get Titles Length:
            int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
            int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
            int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
            int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
            // Set Titles Left:
            int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
            int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
            int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
            int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;

            // Draw Invoice Head:
            if (InvTitle != "")
            {
                CurrentY = CurrentY + ImageHeight;
                g.DrawString(InvTitle, InvTitleFont, BlueBrush, xInvTitle, CurrentY);
            }
            if (InvSubTitle1 != "")
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString(InvSubTitle1, InvSubTitleFont, BlueBrush, xInvSubTitle1, CurrentY);
            }
            if (InvSubTitle2 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle2, InvSubTitleFont, BlueBrush, xInvSubTitle2, CurrentY);
            }
            if (InvSubTitle3 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle3, InvSubTitleFont, BlueBrush, xInvSubTitle3, CurrentY);
            }

            // Draw line:
            CurrentY = CurrentY + InvSubTitleHeight + 8;
            g.DrawLine(new Pen(Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);
        }

        private void SetOrderData(Graphics g)
        {// Set Company Name, City, Salesperson, Order ID and Order Date
            string FieldValue = "";
            InvoiceFontHeight = (int)(InvoiceFont.GetHeight(g));
            // Set Company Name:
            CurrentX = leftMargin;
            CurrentY = CurrentY + 8;
            
            FieldValue = "Customer Name: " + invoicedatainfo.CustomerName;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set City:
            CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            FieldValue = "Customer Code: " + invoicedatainfo.CustomerCode;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            //// set phone
            //CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            //FieldValue = "Phone: " + Phone;
            //g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set Salesperson:
            CurrentX = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = "Sale Man: " + invoicedatainfo.SaleMan;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set Order ID:
            CurrentX = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = "Invoice No: " + invoicedatainfo.InvoiceNo;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set Order Date:
            CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            FieldValue =  "Date: " + invoicedatainfo.SaleDate;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            // Draw line:
            CurrentY = CurrentY + InvoiceFontHeight + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
        }

        private void SetInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e)
        {// Set Invoice Table:
            string FieldValue = "";
            int CurrentRecord = 0;
            int RecordsPerPage = 20; // twenty items in a page
            decimal Amount = 0;
            bool StopReading = false;

            // Set Table Head:
            int xProductID = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Product ID", InvoiceFont, BlueBrush, xProductID, CurrentY);

            int xProductName = xProductID + (int)g.MeasureString("Product ID", InvoiceFont).Width + 4;
            g.DrawString("Product Name", InvoiceFont, BlueBrush, xProductName, CurrentY);

            int xUnitPrice = xProductName + (int)g.MeasureString("Product Name", InvoiceFont).Width + 72;
            g.DrawString("Unit Price", InvoiceFont, BlueBrush, xUnitPrice, CurrentY);

            int xQuantity = xUnitPrice + (int)g.MeasureString("Unit Price", InvoiceFont).Width + 4;
            g.DrawString("Quantity", InvoiceFont, BlueBrush, xQuantity, CurrentY);

            int xDiscount = xQuantity + (int)g.MeasureString("Quantity", InvoiceFont).Width + 4;
            g.DrawString("Discount", InvoiceFont, BlueBrush, xDiscount, CurrentY);

            AmountPosition = xDiscount + (int)g.MeasureString("Discount", InvoiceFont).Width + 4;
            g.DrawString("Amount", InvoiceFont, BlueBrush, AmountPosition, CurrentY);

            // Set Invoice Table:
            CurrentY = CurrentY + InvoiceFontHeight + 8;



            foreach (var item in invoicedatainfo.invoiceitem)
            {
                FieldValue = item.ProductId;
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductID, CurrentY);
                FieldValue = item.ProductName;
                // if Length of (Product Name) > 20, Draw 20 character only
                if (FieldValue.Length > 20)
                    FieldValue = FieldValue.Remove(20, FieldValue.Length - 20);
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductName, CurrentY);
                FieldValue = String.Format("{0:0.00}", item.Rate);
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xUnitPrice, CurrentY);
                FieldValue = item.Quantity.ToString();
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xQuantity, CurrentY);
                FieldValue = String.Format("{0:0.00%}", item.BillDiscount);
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xDiscount, CurrentY);

                Amount = Convert.ToDecimal(item.TotalAmount);
                // Format Extended Price and Align to Right:
                FieldValue = String.Format("{0:0.00}", item.TotalAmount);
                int xAmount = AmountPosition + (int)g.MeasureString("Extended Price", InvoiceFont).Width;
                xAmount = xAmount - (int)g.MeasureString(FieldValue, InvoiceFont).Width;
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xAmount, CurrentY);
                CurrentY = CurrentY + InvoiceFontHeight;




            }

            //if (CurrentRecord < RecordsPerPage)
            //    e.HasMorePages = false;
            //else
            //    e.HasMorePages = true;

            //if (StopReading)
            //{
            //    rdrInvoice.Close();
            //    cnn.Close();
            //    SetInvoiceTotal(g);
            //}
            SetInvoiceTotal(g);
            g.Dispose();
        }

        private void SetInvoiceTotal(Graphics g)
        {// Set Invoice Total:
         // Draw line:
            CurrentY = CurrentY + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
            // Get Right Edge of Invoice:
            int xRightEdg = AmountPosition + (int)g.MeasureString(" Amount", InvoiceFont).Width;

            // Write Sub Total:
            int xSubTotal = AmountPosition - (int)g.MeasureString("Sub Total " , InvoiceFont).Width;
            CurrentY = CurrentY + 8;
            g.DrawString("Sub Total", InvoiceFont, RedBrush, xSubTotal, CurrentY);
            string TotalValue = String.Format("{0:0.00}", invoicedatainfo.TotalAmount);
            int xTotalValue = xRightEdg - (int)g.MeasureString(TotalValue, InvoiceFont).Width;
            g.DrawString(TotalValue, InvoiceFont, BlackBrush, xTotalValue, CurrentY);

            // Write Order Freight:
            int xOrderFreight = AmountPosition - (int)g.MeasureString("Discount", InvoiceFont).Width;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Discount", InvoiceFont, RedBrush, xOrderFreight, CurrentY);
            string FreightValue = String.Format("{0:0.00}", invoicedatainfo.BillDiscount);
            int xFreight = xRightEdg - (int)g.MeasureString(FreightValue, InvoiceFont).Width;
            g.DrawString(FreightValue, InvoiceFont, BlackBrush, xFreight, CurrentY);

            // Write Invoice Total:
            int xInvoiceTotal = AmountPosition - (int)g.MeasureString("Invoice Total", InvoiceFont).Width;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Invoice Total " , InvoiceFont, RedBrush, xInvoiceTotal, CurrentY);
            string InvoiceValue = String.Format("{0:0.00}", invoicedatainfo.GrandTotal);
            int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
            g.DrawString(InvoiceValue, InvoiceFont, BlackBrush, xInvoiceValue, CurrentY);
        }


        public frmSalesInvoice()
		{
			this.InitializeComponent();
            this.invoicedatainfo = new InvoiceDataInfo();
            this.prnDocument = new PrintDocument();
            this.prnPreview = new PrintPreviewDialog();
            this.prnDialog = new PrintDialog();
            prnDocument.PrintPage += new PrintPageEventHandler(prnDocument_PrintPage);
        }

		public void AssignCurrentBalance()
		{
			try
			{
				if ((this.cmbCashVendor.SelectedValue == null ? true : !(this.cmbCashVendor.SelectedValue.ToString() != "")))
				{
					this.lblBlnceAmount.Text = "0.00 ";
					this.lblBlnceAmount.BackColor = Color.Black;
					this.lblBlnceAmount.BackColor = Color.Transparent;
				}
				else
				{
					DataTable dataTable = new DataTable();
					dataTable = this.ledgerpostingsp.LedgerPostingGetCurerntBalanceOfLedger(this.cmbCashVendor.SelectedValue.ToString(), DateTime.Parse(this.dtpDate.Text));
					if (dataTable.Rows.Count <= 0)
					{
						this.lblBlnceAmount.Text = "0.00 ";
						this.lblBlnceAmount.ForeColor = Color.Black;
						this.lblBlnceAmount.BackColor = Color.Transparent;
					}
					else
					{
						decimal num = decimal.Parse(dataTable.Rows[0][0].ToString());
						num = Math.Round(num, 2);
						if ((dataTable.Rows[0][2].ToString() == null ? true : !(dataTable.Rows[0][2].ToString() != "")))
						{
							this.lblBlnceAmount.Text = "0.00 ";
							this.lblBlnceAmount.ForeColor = Color.Black;
							this.lblBlnceAmount.BackColor = Color.Transparent;
						}
						else if (!(dataTable.Rows[0][2].ToString() == "false"))
						{
							this.lblBlnceAmount.Text = string.Concat(num.ToString(), " Cr");
							this.lblBlnceAmount.ForeColor = Color.Green;
							this.lblBlnceAmount.BackColor = Color.Transparent;
						}
						else
						{
							this.lblBlnceAmount.Text = string.Concat(num.ToString(), " Dr");
							this.lblBlnceAmount.ForeColor = Color.Red;
							this.lblBlnceAmount.BackColor = Color.Transparent;
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

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearFunction();
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

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnNew_Click(object sender, EventArgs e)
		{

            frmVendor vendor = new frmVendor();
            this.Close();
            vendor.Show();

        }

		private void btnNewSalesman_Click(object sender, EventArgs e)
		{

            frmSalesMan salesman = new frmSalesMan();
            this.Close();
            salesman.Show();
        }

		private void btnPaymentBtn_Click(object sender, EventArgs e)
		{
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			try
			{
                
              
                    if (this.dgvSalesInvoice.CurrentRow != null)
				{
                    

                    if (!(this.dgvSalesInvoice.Rows[this.dgvSalesInvoice.CurrentRow.Index].DefaultCellStyle.BackColor != Color.Cornsilk))
					{
						MessageBox.Show("Can't remove returned product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						try
						{
							string str = "";
							if (this.dgvSalesInvoice.Rows.Count != 1)
							{
								str = (this.dgvSalesInvoice.Rows[this.dgvSalesInvoice.CurrentRow.Index].Cells[19].Value == null ? "" : this.dgvSalesInvoice.Rows[this.dgvSalesInvoice.CurrentRow.Index].Cells[19].Value.ToString());
								this.dgvSalesInvoice.Rows.RemoveAt(this.dgvSalesInvoice.CurrentRow.Index);
                                this.lblRows.Text = (dgvSalesInvoice.Rows.Count - 1).ToString();

                            }
							else
							{
								str = (this.dgvSalesInvoice.Rows[0].Cells[19].Value == null ? "" : this.dgvSalesInvoice.Rows[0].Cells[19].Value.ToString());
								this.dgvSalesInvoice.Rows.Clear();
								this.cmbSalesman.Focus();
							}
							this.CalculateTotal();
							if (str != "")
							{
								this.CollectSelectedIds(str);
							}
						}
						catch (Exception exception)
						{
						}
						if (this.dgvSalesInvoice.Rows.Count > 0)
						{
							this.dgvSalesInvoice.Focus();
							this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[0].Cells[0];
						}
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
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

                    //ReadInvoice = false;
                    //PrintReport(); // Print Invoice


                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }


        private void PrintReport()
        {
            try
            {
                prnDocument.Print();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					this.txtBillDiscount.Focus();
					this.txtBillDiscount.SelectionStart = 0;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				frmPopup _frmPopup = new frmPopup();
				frmPopup item = Application.OpenForms["frmPopup"] as frmPopup;
				if (item != null)
				{
					item.MdiParent = MDIMedicalShop.MDIObj;
					item.CallThisFromSales(this);
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
					_frmPopup.WindowState = FormWindowState.Normal;
					_frmPopup.MdiParent = MDIMedicalShop.MDIObj;
					_frmPopup.CallThisFromSales(this);
					_frmPopup.Show();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnVendor_Click(object sender, EventArgs e)
		{
		}

		public void CalculateGrandTotal()
		{
			try
			{
				decimal num = new decimal(0, 0, 0, false, 2);
				decimal num1 = new decimal(0, 0, 0, false, 2);
				if (this.txtBillDiscount.Text == "")
				{
					this.txtBillDiscount.Text = num.ToString();
				}
				num1 = decimal.Parse(this.lblTotalAmount.Text) - decimal.Parse(this.txtBillDiscount.Text);
				this.lblGrandTotal.Text = string.Concat(num1.ToString(), this.strDefaultCurrency);
				num1 = Math.Round(num1, 2);
				this.lblTotalNew.Text = num1.ToString();
				if (!(this.txtPaidAmount.Text != ""))
				{
					this.lblBalanceAmount.Text = "0.00";
				}
				else if (!(decimal.Parse(this.txtPaidAmount.Text) != new decimal(0)))
				{
					this.lblBalanceAmount.Text = "0.00";
				}
				else
				{
					decimal num2 = decimal.Parse(this.txtPaidAmount.Text);
					decimal num3 = num1 - num2;
					if (!(num3 >= new decimal(0)))
					{
						this.lblBalanceAmount.Text = "0.00";
					}
					else
					{
						this.lblBalanceAmount.Text = num3.ToString();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CalculateTotal()
		{
			try
			{
				if (this.dgvSalesInvoice.Rows.Count > 0)
				{
					decimal num = new decimal(0, 0, 0, false, 2);
					decimal num1 = new decimal(0, 0, 0, false, 2);
					decimal num2 = new decimal(0, 0, 0, false, 2);
					decimal num3 = new decimal(0, 0, 0, false, 2);
					decimal num4 = new decimal(0, 0, 0, false, 2);
					decimal num5 = new decimal(0, 0, 0, false, 2);
					decimal num6 = new decimal(0, 0, 0, false, 2);
					foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
					{
						if (row.Cells[2].Value != null)
						{
							if (row.Cells[2].Value.ToString() != "")
							{
								if (row.Cells[17].Value != null)
								{
									if (row.Cells[17].Value.ToString() != "")
									{
										num = num + decimal.Parse(row.Cells[17].Value.ToString());
									}
								}
								if (row.Cells[18].Value != null)
								{
									if (row.Cells[18].Value.ToString() != "")
									{
										num1 = num1 + decimal.Parse(row.Cells[18].Value.ToString());
									}
								}
							}
						}
					}
					this.lblTaxAmount.Text = num.ToString();
					this.lblTotalAmount.Text = num1.ToString();
					if (this.txtBillDiscount.Text == "")
					{
						this.txtBillDiscount.Text = num3.ToString();
					}
					num4 = decimal.Parse(this.lblTotalAmount.Text) - decimal.Parse(this.txtBillDiscount.Text);
					this.lblGrandTotal.Text = string.Concat(num4.ToString(), this.strDefaultCurrency);
					this.lblTotalNew.Text = num4.ToString();
					num5 = Math.Round(num4, 2);
					this.txtPaidAmount.Text = num4.ToString();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void chbxprint_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

        private void chbxSelect_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        public bool CheckBatchNull()
		{
			bool flag = false;
			try
			{
				foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
				{
					if ((row.Cells[2].Value == null ? false : row.Cells[3].Value != null))
					{
						if ((row.Cells[2].Value.ToString() == "" ? false : row.Cells[3].Value.ToString() != ""))
						{
							if (!(row.Cells[3].Value.ToString() == "NA"))
							{
								if (row.Cells[4].Value == null)
								{
									flag = true;
									break;
								}
								else if (row.Cells[4].Value.ToString() == "")
								{
									flag = true;
									break;
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
			return flag;
		}

		public bool CheckBillDiscount()
		{
			bool flag = false;
			try
			{
				flag = (!(decimal.Parse(this.txtBillDiscount.Text) > decimal.Parse(this.lblTotalAmount.Text)) ? false : true);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return flag;
		}

		public bool CheckExistName()
		{
			SalesMasterSP salesMasterSP = new SalesMasterSP();
			SalesMasterInfo salesMasterInfo = new SalesMasterInfo();
			bool flag = true;
			try
			{
				if (this.txtInvoice.Text.Trim() != "")
				{
					string str = this.txtInvoice.Text.Trim();
					if (!this.isInEditMode)
					{
						flag = salesMasterSP.CheckExistanceOfSalesInvoice(str);
					}
					else if (this.txtVoucherNo.Text != "")
					{
						flag = (!(salesMasterSP.SalesMasterView(this.txtVoucherNo.Text).SalesInvoiceNo.ToLower() != str.ToLower()) ? false : salesMasterSP.CheckExistanceOfSalesInvoice(str));
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return flag;
		}

		public bool CheckGridNull()
		{
			bool flag;
			bool flag1 = false;
			try
			{
				if (this.dgvSalesInvoice.Rows.Count > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
					{
						if (row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null)
						{
							flag = true;
						}
						else
						{
							flag = (row.Cells[9].Value != null ? false : row.Cells[10].Value == null);
						}
						if (!flag)
						{
							if ((row.Cells[9].Value == null ? true : row.Cells[9].Value.ToString() == ""))
							{
								row.Cells[9].Value = 0;
							}
							if ((row.Cells[10].Value == null ? true : row.Cells[10].Value.ToString() == ""))
							{
								row.Cells[10].Value = 0;
							}
							if ((!(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != "") ? false : row.Cells[3].Value.ToString() != ""))
							{
								flag1 = true;
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
			return flag1;
		}

		public string CheckNegetiveStock()
		{
			string str = "";
			try
			{
				string str1 = "";
				ProductBatchSP productBatchSP = new ProductBatchSP();
				SettingsInfo settingsInfo = new SettingsInfo();
				SettingsSP settingsSP = new SettingsSP();
				ProductSP productSP = new ProductSP();
				DataTable dataTable = new DataTable();
				ProductInfo productInfo = new ProductInfo();
				string str2 = "";
				DataTable dataTable1 = new DataTable();
				foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
				{
					dataTable1.Rows.Clear();
					if ((row.Cells[2].Value == null || row.Cells[3].Value == null ? false : row.Cells[9].Value != null))
					{
						if ((!(row.Cells[2].Value.ToString() != "") || !(row.Cells[3].Value.ToString() != "") ? false : row.Cells[9].Value.ToString() != ""))
						{
							str1 = "";
							settingsInfo = settingsSP.SettingsView("1");
							if (settingsInfo.SettingsId != null)
							{
								if (settingsInfo.NegativeStockAlertStatus == "Ignore")
								{
									str1 = "Ignore";
								}
								else if (settingsInfo.NegativeStockAlertStatus == "Warn")
								{
									str1 = "Warn";
								}
								else if (settingsInfo.NegativeStockAlertStatus == "Block")
								{
									str1 = "Block";
								}
							}
							str2 = "";
							string str3 = row.Cells[2].Value.ToString();
							string str4 = row.Cells[3].Value.ToString();
							productInfo = productSP.ProductView(row.Cells[2].Value.ToString());
							dataTable1 = productBatchSP.ProductBatchViewByProductAndBatchName(str3, str4);
							if (dataTable1.Rows.Count > 0)
							{
								str2 = dataTable1.Rows[0].ItemArray[0].ToString();
							}
							if (!(str2 != ""))
							{
								row.DefaultCellStyle.ForeColor = Color.Red;
								str = str1;
							}
							else
							{
								dataTable = productSP.CurrentQuantiyOfProduct(str2);
								if (dataTable.Rows.Count > 0)
								{
									if (this.isInEditMode)
									{
										SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
										SalesDetailsInfo salesDetailsInfo = new SalesDetailsInfo();
										if (row.Cells[19].Value != null)
										{
											salesDetailsInfo = salesDetailsSP.SalesDetailsView(row.Cells[19].Value.ToString());
											decimal num = decimal.Parse(dataTable.Rows[0].ItemArray[0].ToString());
											decimal qty = num + salesDetailsInfo.Qty;
											if (decimal.Parse(row.Cells[9].Value.ToString()) > qty)
											{
												row.DefaultCellStyle.ForeColor = Color.Red;
												str = str1;
											}
										}
										else if (decimal.Parse(row.Cells[9].Value.ToString()) > decimal.Parse(dataTable.Rows[0].ItemArray[0].ToString()))
										{
											row.DefaultCellStyle.ForeColor = Color.Red;
											str = str1;
										}
									}
									else if (decimal.Parse(row.Cells[9].Value.ToString()) > decimal.Parse(dataTable.Rows[0].ItemArray[0].ToString()))
									{
										row.DefaultCellStyle.ForeColor = Color.Red;
										str = str1;
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
			return str;
		}

		public int CheckOnSaveForExistenceOfProduct()
		{
			bool flag = false;
			int num = 0;
			for (int i = 0; i < this.dgvSalesInvoice.Rows.Count; i++)
			{
				if ((this.dgvSalesInvoice.Rows[i].Cells[2].Value == null ? false : this.dgvSalesInvoice.Rows[i].Cells[3].Value != null))
				{
					if ((this.dgvSalesInvoice.Rows[i].Cells[2].Value.ToString() == "" ? false : this.dgvSalesInvoice.Rows[i].Cells[3].Value.ToString() != ""))
					{
						for (int j = 0; j < this.dgvSalesInvoice.Rows.Count; j++)
						{
							if ((this.dgvSalesInvoice.Rows[j].Cells[2].Value == null ? false : this.dgvSalesInvoice.Rows[j].Cells[3].Value != null))
							{
								if ((this.dgvSalesInvoice.Rows[j].Cells[2].Value.ToString() == "" ? false : this.dgvSalesInvoice.Rows[j].Cells[3].Value.ToString() != ""))
								{
									if ((this.dgvSalesInvoice.Rows[i].Cells[2].Value.ToString() != this.dgvSalesInvoice.Rows[j].Cells[2].Value.ToString() ? false : this.dgvSalesInvoice.Rows[i].Cells[3].Value.ToString() == this.dgvSalesInvoice.Rows[j].Cells[3].Value.ToString()))
									{
										if (i != j)
										{
											num = i;
											flag = true;
											break;
										}
									}
								}
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
			}
			if (!flag)
			{
				num = -1;
			}
			return num;
		}

		public bool CheckPaidAmount()
		{
			bool flag = false;
			try
			{
				if (this.txtPaidAmount.Text != "")
				{
					this.lblGrandTotal.Text = this.lblGrandTotal.Text.Replace(this.strDefaultCurrency, "");
					flag = (!(decimal.Parse(this.txtPaidAmount.Text) > decimal.Parse(this.lblTotalNew.Text)) ? false : true);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return flag;
		}

		public bool CheckProductRepeat(string Id, string Batch)
		{
			bool flag = false;
			try
			{
				if (this.dgvSalesInvoice.RowCount > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
					{
						if (this.dgvSalesInvoice.CurrentRow.Index != row.Index)
						{
							if ((row.Cells[3].Value == null ? false : row.Cells[2].Value != null))
							{
								if ((row.Cells[3].Value.ToString() == "" ? false : row.Cells[2].Value.ToString() != ""))
								{
									if ((Id != row.Cells[2].Value.ToString() ? true : !(Batch == row.Cells[3].Value.ToString().ToLower().Trim())))
									{
										flag = false;
									}
									else
									{
										flag = true;
										break;
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
			return flag;
		}

		public bool CheckQuantityNull()
		{
			bool flag = false;
			try
			{
				foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
				{
					if (row.Cells[2].Value != null)
					{
						if (row.Cells[2].Value.ToString() != "")
						{
							if (row.Cells[9].Value == null)
							{
								if (row.Cells[10].Value == null)
								{
									flag = true;
									break;
								}
								else if (row.Cells[10].Value.ToString() == "")
								{
									flag = true;
									break;
								}
								else if (!(decimal.Parse(row.Cells[10].Value.ToString()) <= new decimal(0)))
								{
									flag = false;
								}
								else
								{
									flag = true;
									break;
								}
							}
							else if (!(row.Cells[9].Value.ToString() == ""))
							{
								if (decimal.Parse(row.Cells[9].Value.ToString()) <= new decimal(0))
								{
									if (row.Cells[10].Value == null)
									{
										flag = true;
										break;
									}
									else if (row.Cells[10].Value.ToString() == "")
									{
										flag = true;
										break;
									}
									else if (!(decimal.Parse(row.Cells[10].Value.ToString()) <= new decimal(0)))
									{
										flag = false;
									}
									else
									{
										flag = true;
										break;
									}
								}
							}
							else if (row.Cells[10].Value == null)
							{
								flag = true;
								break;
							}
							else if (row.Cells[10].Value.ToString() == "")
							{
								flag = true;
								break;
							}
							else if (!(decimal.Parse(row.Cells[10].Value.ToString()) <= new decimal(0)))
							{
								flag = false;
							}
							else
							{
								flag = true;
								break;
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
			return flag;
		}

		public void ClearFunction()
		{
			try
			{
                invoicedatainfo = new InvoiceDataInfo();
                base.ActiveControl = this.dtpDate;
				this.cmbPatient.Enabled = true;
				this.isSaved = false;
				this.dtblRemovedSalesId.Rows.Clear();
                this.txtInvoice.Text = this.GetMaxofSalesMasterInvoice();
				this.txtVoucherNo.Text = this.GetMaxofSalesMasterId();
				this.lstbxBatch.Visible = false;
				this.dtpDate.Text = "";
                this.lblRows.Text = "0";
				this.cmbPatient.Text = "";
				this.cmbDoctor.Text = "";
				this.FillDoctorCombo();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.FillSalesManCombo("");
				this.FillPatientCombo();
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.isFromSalesregister = false;
					this.frmRegister.Close();
				}
				this.isInEditMode = false;
				//this.txtInvoice.Text = "";
				this.dgvSalesInvoice.Rows.Clear();
				this.FillComboItem();
				this.txtDescription.Text = "";
				this.lblBalance.Visible = true;
				this.lblBalanceAmount.Visible = true;
               

				this.lblPaidAmount.Visible = true;
				this.txtPaidAmount.Visible = true;
				this.isFormClose = false;
				this.lblTaxAmount.Text = "0.00";
				this.lblTotalNew.Text = "0.00";
				this.lblTotalAmount.Text = "0.00";
                this.lblRemBalance.Text = "0.00";
                this.RemBalance.Text = "0.00";
				this.isCellEdit = false;
				this.txtBillDiscount.Clear();
				this.lblGrandTotal.Text = string.Concat("0.00", this.strDefaultCurrency);
				this.chbxprint.Checked = false;
                this.chbxwarranty.Checked = false;
                this.btnDelete.Enabled = false;
				this.txtPaidAmount.Text = "0.00";
               
				this.isCreditSale = false;
				this.dtblRemovedSalesId.Rows.Clear();
				this.FillComboItem();
				this.FillComboCashVender();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashBankAccount_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
					e.Handled = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashVendor_KeyDown(object sender, KeyEventArgs e)
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
					this.dtpDate.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashVendor_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cmbCashVendor.SelectedValue != null)
				{
					if (this.cmbCashVendor.SelectedIndex > -1)
					{
						if (this.cmbCashVendor.Text != "")
						{
							if (!this.isInEditMode)
							{
								this.isCreditSale = true;
								this.txtPaidAmount.Enabled = true;
								AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
								AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
								accountLedgerInfo = accountLedgerSP.AccountLedgerView(this.cmbCashVendor.SelectedValue.ToString());
								if (accountLedgerInfo.AccountGroupId == "11")
								{
									this.isCreditSale = false;
									this.txtPaidAmount.Enabled = false;
								}
								else if (accountLedgerInfo.AccountGroupId != null)
								{
									DataTable dataTable = new DataTable();
									dataTable = accountLedgerSP.CheckGroupIdUnderCash(accountLedgerInfo.AccountGroupId);
									foreach (DataRow row in dataTable.Rows)
									{
										if (row.ItemArray[0].ToString() == "11")
										{
											this.isCreditSale = false;
											this.txtPaidAmount.Enabled = false;
											break;
										}
									}
								}
							}
							this.AssignCurrentBalance();
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

		private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
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
					if ((this.cmbDoctor.Text == "" ? true : this.cmbDoctor.SelectionStart == 0))
					{
						this.cmbPatient.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbDoctor_Leave(object sender, EventArgs e)
		{
			try
			{
				if (this.cmbDoctor.Text.Trim() == "")
				{
					this.cmbDoctor.SelectedValue = "0";
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
						this.txtInvoice.Focus();
						this.txtInvoice.SelectionStart = 0;
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

		private void cmbPatient_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (!this.isInEditMode)
				{
					this.dgvSalesInvoice.Rows.Clear();
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
                            ProductBatchSP productBatchsp = new ProductBatchSP();
                            ProductBatchInfo productBatchInfo = new ProductBatchInfo();
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
										this.dgvSalesInvoice.Rows.Add();
										this.dgvSalesInvoice.Rows[str].Cells[1].Value = row.ItemArray[2].ToString();
										this.dgvSalesInvoice.Rows[str].Cells[2].Value = row.ItemArray[2].ToString();
                                        //this.dgvSalesInvoice.Rows[str].Cells[6].Value = row.ItemArray[1].ToString();
                                        //this.dgvSalesInvoice.Rows[str].Cells[9].Value = row.ItemArray[4].ToString();

                                        productInfo = this.productsp.ProductView(row.ItemArray[2].ToString());
										if (productInfo.ManufactureId != null)
										{
											manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
											this.dgvSalesInvoice.Rows[str].Cells[8].Value = manufacturerInfo.ManufactureName;
										}
                                        if (productInfo.ManufactureId != null)
                                        {
                                            unitInfo = unitSP.UnitView(productInfo.UnitId);
                                            this.dgvSalesInvoice.Rows[str].Cells[11].Value = unitInfo.UnitName;

                                        }

                                        //if (productInfo.ProductId != null)
                                        //{
                                        //    productBatchInfo = productBatchsp.ProductBatchNameView(productInfo.ProductId);
                                        //    this.dgvSalesInvoice.Rows[str].Cells[6].Value = productBatchInfo.BatchName;

                                        //}


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

		private void cmbPatient_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (!this.isInEditMode)
				{
					this.dgvSalesInvoice.Rows.Clear();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbPaymentMode_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbPaymentMode_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if (this.j != 1)
					{
						frmSalesInvoice _frmSalesInvoice = this;
						_frmSalesInvoice.j = _frmSalesInvoice.j + 1;
					}
					else
					{
						this.j = 0;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSalesman_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					if (this.dgvSalesInvoice.Rows.Count > 0)
					{
						this.dgvSalesInvoice.ClearSelection();
						this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[0].Cells[0];
						this.dgvSalesInvoice.Focus();
					}
				}
				else if (e.KeyCode == Keys.Back)
				{
					this.cmbDoctor.Focus();
				}
				this.DropDowncomboAndCalender(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CollectSelectedIds(string pSalesDetailsId)
		{
			try
			{
				DataRow dataRow = this.dtblRemovedSalesId.NewRow();
				this.dtblRemovedSalesId.Rows.Add(dataRow);
				dataRow["DetailsOne"] = pSalesDetailsId;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CreateDataTableForDeletedIDs()
		{
			try
			{
				if (this.dtblRemovedSalesId.Rows.Count == 0)
				{
					DataColumn dataColumn = new DataColumn("DetailsOne");
					this.dtblRemovedSalesId.Columns.Add(dataColumn);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DeleteSelectedSalesDetailsId()
		{
			try
			{
				SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
				foreach (DataRow row in this.dtblRemovedSalesId.Rows)
				{
					salesDetailsSP.SalesDetailsDelete(row.ItemArray[0].ToString());
				}
				this.dtblRemovedSalesId.Rows.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.isCellEdit = true;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				if ((this.btnClear.Focused || this.btnDelete.Focused || this.btnClose.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					if ((e.ColumnIndex == 1 ? true : e.ColumnIndex == 2))
					{
						if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								this.FillBatchCombo(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
							}
						}
					}
					if (e.ColumnIndex == 4)
					{
						if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() != "")
							{
								if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().ToUpper() == "NA")
								{
									this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
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

		private void dgvPurchaseInvoice_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 2)
				{
					if (this.dgvSalesInvoice.CurrentRow != null)
					{
						if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value = DateTime.Now;
						}
					}
				}
				this.rowIndex = e.RowIndex;
				this.columnIndex = e.ColumnIndex;
				if (this.isCellEdit)
				{
					if ((e.ColumnIndex == 2 || e.ColumnIndex == 3 ? false : e.ColumnIndex != 4))
					{
						this.dgvSalesInvoice.BeginEdit(true);
					}
				}
				if (e.ColumnIndex != 3)
				{
					this.lstbxBatch.Visible = false;
				}
				else if (this.dgvSalesInvoice.CurrentRow != null)
				{
					if (this.dgvSalesInvoice.CurrentRow.Cells[e.ColumnIndex - 1].Value == null)
					{
						this.lstbxBatch.Visible = false;
					}
					else if (!(this.dgvSalesInvoice.CurrentRow.Cells[e.ColumnIndex - 1].Value.ToString() != ""))
					{
						this.lstbxBatch.Visible = false;
					}
					else if (this.dgvSalesInvoice.Rows[this.rowIndex].DefaultCellStyle.BackColor != Color.Cornsilk)
					{
						this.FillBatchCombo(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
						Point left = new Point();
						Rectangle cellDisplayRectangle = this.dgvSalesInvoice.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.X = cellDisplayRectangle.Left + this.dgvSalesInvoice.Left;
						cellDisplayRectangle = this.dgvSalesInvoice.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.Y = cellDisplayRectangle.Bottom + this.dgvSalesInvoice.Top;
						this.lstbxBatch.Visible = true;
						this.lstbxBatch.Location = left;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			bool flag;
			try
			{
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				if ((this.btnClear.Focused || this.btnDelete.Focused || this.btnClose.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					string str = "";
					if ((e.ColumnIndex == 4 || e.ColumnIndex == 2 || e.ColumnIndex == 3 ? true : e.ColumnIndex == 4))
					{
						if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value == null || this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value == null ? false : this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value != null))
						{
							if ((!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value.ToString() != "") || !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() != "") || !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() != "") ? false : this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() != "NA"))
							{
								str = "";
								SettingsInfo settingsInfo = new SettingsInfo();
								SettingsSP settingsSP = new SettingsSP();
								ProductSP productSP = new ProductSP();
								DataTable dataTable = new DataTable();
								settingsInfo = settingsSP.SettingsView("1");
								if (settingsInfo.SettingsId != null)
								{
									if (settingsInfo.ExpiryProductTransactionStatus == "Ignore")
									{
										str = "Ignore";
									}
									else if (settingsInfo.ExpiryProductTransactionStatus == "Warn")
									{
										str = "Warn";
									}
									else if (settingsInfo.ExpiryProductTransactionStatus == "Block")
									{
										str = "Block";
									}
								}
								string str1 = "";
								DataTable dataTable1 = new DataTable();
								string str2 = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value.ToString();
								string str3 = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value.ToString();
								dataTable1 = productBatchSP.ProductBatchViewByProductAndBatchName(str2, str3);
								if (dataTable1.Rows.Count > 0)
								{
									str1 = dataTable1.Rows[0].ItemArray[0].ToString();
								}
								if (str1 != "")
								{
									productBatchInfo = productBatchSP.ProductBatchView(str1);
									if (DateTime.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value.ToString()) < DateTime.Parse(this.dtpDate.Text))
									{
										if (str == "Warn")
										{
											if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
											{
												if (!this.isSaved)
												{
													MessageBox.Show("Expired Product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
												}
											}
										}
										if (str == "Block")
										{
											if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
											{
												if (!this.isSaved)
												{
													MessageBox.Show("Expired Product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													if (e.ColumnIndex == 4)
													{
														this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value = "";
													}
													this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value = "";
												}
											}
										}
										if (str == "Ignore")
										{
										}
									}
								}
								else if (DateTime.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value.ToString()) < DateTime.Parse(this.dtpDate.Text))
								{
									if (str == "Warn")
									{
										if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
										{
											if (!this.isSaved)
											{
												MessageBox.Show("Expired Product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
											}
										}
									}
									if (str == "Block")
									{
										if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
										{
											if (!this.isSaved)
											{
												MessageBox.Show("Expired Product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Hand);
												this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value = "";
											}
										}
									}
									if (str == "Ignore")
									{
									}
								}
							}
						}
					}
					if (this.dgvSalesInvoice.CurrentCell == null)
					{
						flag = true;
					}
					else
					{
						flag = (this.dgvSalesInvoice.CurrentCell.ColumnIndex == 5 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 6 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 7 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 9 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 10 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 12 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 13 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 14 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 16 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 17 ? false : this.dgvSalesInvoice.CurrentCell.ColumnIndex != 18);
					}
					if (!flag)
					{
						if ((this.dgvSalesInvoice.CurrentRow.Cells[1].Value == null ? false : this.dgvSalesInvoice.CurrentRow.Cells[2].Value != null))
						{
							if ((this.dgvSalesInvoice.CurrentRow.Cells[1].Value.ToString() == "" ? false : this.dgvSalesInvoice.CurrentRow.Cells[2].Value.ToString() != ""))
							{
								try
								{
									decimal.Parse(this.dgvSalesInvoice.CurrentCell.Value.ToString());
								}
								catch (Exception exception)
								{
									this.dgvSalesInvoice.CurrentCell.Value = 0;
								}
							}
						}
					}
					if ((e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 13 ? true : e.ColumnIndex == 16))
					{
						if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								DecimalValidation decimalValidation = new DecimalValidation();
								TextBox textBox = new TextBox()
								{
									Text = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
								};
								if (!decimalValidation.checkString(textBox))
								{
									if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
									{
										if (!this.isSaved)
										{
											MessageBox.Show("Only decimal values allowed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										}
									}
									this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
								}
							}
						}
					}
					if (e.ColumnIndex == 13)
					{
						if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								if (decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value.ToString()) > new decimal(100))
								{
									if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
									{
										if (!this.isSaved)
										{
											MessageBox.Show("Check discount percent", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										}
									}
									this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
								}
							}
						}
					}
					if (e.ColumnIndex == 16)
					{
						if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								if (decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[16].Value.ToString()) > new decimal(100))
								{
									if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
									{
										if (!this.isSaved)
										{
											MessageBox.Show("Check tax percent", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										}
									}
									this.dgvSalesInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
								}
							}
						}
					}
					if ((e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 6 || e.ColumnIndex == 9 || e.ColumnIndex == 13 ? true : e.ColumnIndex == 16))
					{
						if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[6].Value == null ? true : this.dgvSalesInvoice.Rows[e.RowIndex].Cells[9].Value == null))
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value = "";
						}
						else if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[6].Value.ToString() == "" ? true : !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() != "")))
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value = "";
						}
						else
						{
							decimal num = new decimal(0, 0, 0, false, 2);
							decimal num1 = new decimal(0, 0, 0, false, 2);
							decimal num2 = new decimal(0, 0, 0, false, 2);
							num = decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[6].Value.ToString());
							num1 = decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[9].Value.ToString());
							num2 = num * num1;
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value = num2;
						}
					}
					if ((e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 6 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 13 || e.ColumnIndex == 15 ? true : e.ColumnIndex == 16))
					{
						if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value == null ? true : this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value == null))
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value == null)
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = "";
							}
							else if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value == null)
							{
								if (!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() != "0.00"))
								{
									this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = "";
								}
								else
								{
									this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString();
								}
							}
						}
						else if (!(!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() != "0") || !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() != "") ? true : !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value.ToString() != "")))
						{
							decimal num3 = new decimal(0, 0, 0, false, 2);
							decimal num4 = new decimal(0, 0, 0, false, 2);
							num3 = decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString());
							num4 = decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value.ToString()) / new decimal(100);
							if (!(num3 >= num4))
							{
								if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
								{
									if (!this.isSaved)
									{
										MessageBox.Show("Discount greater than net value", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									}
								}
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value = "";
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = num3 - new decimal(0);
							}
							else
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = num3 - (num3 * num4);
							}
						}
						else if (!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() == "0" ? false : !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() == "")))
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = "";
						}
						else if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[13].Value.ToString() == "")
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[12].Value.ToString();
						}
						bool flag1 = true;
						if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value == null ? true : this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value == null))
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[17].Value = "";
						}
						else if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value.ToString() == "" ? true : !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value.ToString() != "")))
						{
							this.dgvSalesInvoice.Rows[e.RowIndex].Cells[17].Value = "";
						}
						else
						{
							flag1 = false;
							decimal num5 = new decimal(0, 0, 0, false, 2);
							string str4 = "";
							decimal num6 = new decimal(0, 0, 0, false, 2);
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[16].Value != null)
							{
								num5 = (!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[16].Value.ToString() == "") ? decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[16].Value.ToString()) : new decimal(0));
							}
							else
							{
								num5 = new decimal(0);
							}
							num6 = decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value.ToString());
							str4 = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value.ToString();
							if (str4 == "Included")
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[17].Value = Math.Round((num6 * num5) / (new decimal(100) + num5), 2);
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[18].Value = num6;
							}
							else if (!(str4 == "Excluded"))
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[18].Value = num6;
							}
							else
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[17].Value = Math.Round((num6 * num5) / new decimal(100), 2);
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[18].Value = num6 + decimal.Parse(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[17].Value.ToString());
							}
						}
						if (flag1)
						{
							if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value == null)
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[18].Value = "";
							}
							else if (!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value.ToString() != ""))
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[18].Value = "";
							}
							else
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[18].Value = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[14].Value.ToString();
							}
						}
						this.CalculateTotal();
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
		}

		private void dgvPurchaseInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (!this.isCellValueChanged)
				{
					ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
					ManufacturerSP manufacturerSP = new ManufacturerSP();
					UnitInfo unitInfo = new UnitInfo();
					UnitSP unitSP = new UnitSP();
					ProductBatchInfo productBatchInfo = new ProductBatchInfo();
					ProductBatchSP productBatchSP = new ProductBatchSP();
					if (this.dgvSalesInvoice.CurrentCell != null)
					{
						if ((this.dgvSalesInvoice.CurrentCell.ColumnIndex == 1 ? true : this.dgvSalesInvoice.CurrentCell.ColumnIndex == 2))
						{
							ProductInfo productInfo = new ProductInfo();
							if (this.dgvSalesInvoice.CurrentCell.Value != null)
							{
								if (this.dgvSalesInvoice.CurrentCell.Value.ToString() != "")
								{
									string str = this.dgvSalesInvoice.CurrentCell.Value.ToString();
									productInfo = this.productsp.ProductView(str);
									if (productInfo.ProductId != null)
									{
										if (this.dgvSalesInvoice.CurrentCell.ColumnIndex != 1)
										{
											this.dgvSalesInvoice.CurrentRow.Cells[1].Value = str;
										}
										else
										{
											this.FillComboItem();
											this.dgvSalesInvoice.CurrentRow.Cells[2].Value = str;
										}
										manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
										if (manufacturerInfo.ManufactureId != null)
										{
											this.dgvSalesInvoice.CurrentRow.Cells[8].Value = manufacturerInfo.ManufactureName;
										}
										unitInfo = unitSP.UnitView(productInfo.UnitId);
										if (unitInfo.UnitName != null)
										{
											this.dgvSalesInvoice.CurrentRow.Cells[11].Value = unitInfo.UnitName;
										}
									}
									else
									{
										this.dgvSalesInvoice.CurrentRow.Cells[1].Value = "";
										this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value = "";
									}
								}
							}
							else if (this.dgvSalesInvoice.CurrentCell.ColumnIndex == 2)
							{
								this.dgvSalesInvoice.CurrentRow.Cells[1].Value = "";
							}
						}
						if (e.ColumnIndex == 3)
						{
							string lower = "";
							if (this.dgvSalesInvoice.CurrentRow.Cells[2].Value != null)
							{
								if (this.dgvSalesInvoice.CurrentRow.Cells[2].Value.ToString() != "")
								{
									this.FillBatchCombo(this.dgvSalesInvoice.CurrentRow.Cells[2].Value.ToString());
									for (int i = 0; i < this.lstbxBatch.Items.Count; i++)
									{
										lower = this.lstbxBatch.Items[i].ToString().ToLower();
										if (this.dgvSalesInvoice.CurrentCell.Value == null)
										{
											this.lstbxBatch.SelectedItem = null;
										}
										else if (!lower.StartsWith(this.dgvSalesInvoice.CurrentCell.Value.ToString().ToLower()))
										{
											this.lstbxBatch.SelectedItem = null;
										}
										else
										{
											this.lstbxBatch.SelectedItem = this.lstbxBatch.Items[i];
											break;
										}
									}
								}
							}
						}
						bool flag = false;
						string str1 = "";
						if ((e.ColumnIndex == 3 || e.ColumnIndex == 2 ? true : e.ColumnIndex == 1))
						{
							flag = false;
							if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[1].Value == null || this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value == null ? true : this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value == null))
							{
								flag = true;
							}
							else if ((!(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[1].Value.ToString() != "") || !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value.ToString() != "") ? true : !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() != "")))
							{
								flag = true;
							}
							else
							{
								str1 = "";
								DataTable dataTable = new DataTable();
								string str2 = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value.ToString();
								string lower1 = this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value.ToString().ToLower();
								dataTable = productBatchSP.ProductBatchViewByProductAndBatchName(str2, lower1.Trim());
								if (dataTable.Rows.Count > 0)
								{
									str1 = dataTable.Rows[0].ItemArray[0].ToString();
								}
								if (!(str1.Trim() != ""))
								{
									flag = true;
								}
								else
								{
									productBatchInfo = productBatchSP.ProductBatchView(str1);
									if (productBatchInfo.ProductBatchId == null)
									{
										flag = true;
									}
									else if ((this.dgvSalesInvoice.Rows[e.RowIndex].Cells[3].Value.ToString().ToLower().Trim() != productBatchInfo.BatchName.ToLower().Trim() ? true : !(this.dgvSalesInvoice.Rows[e.RowIndex].Cells[2].Value.ToString() == productBatchInfo.ProductId)))
									{
										flag = true;
									}
									else
									{
										if (!(productBatchInfo.ExpiryDate == DateTime.Parse("01/01/1753")))
										{
											this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value = productBatchInfo.ExpiryDate;
										}
										else
										{
											this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value = "";
										}
										this.dgvSalesInvoice.Rows[e.RowIndex].Cells[5].Value = Math.Round(productBatchInfo.PurchaseRate, 2);
										this.dgvSalesInvoice.Rows[e.RowIndex].Cells[6].Value = Math.Round(productBatchInfo.SalesRate, 2);
										this.dgvSalesInvoice.Rows[e.RowIndex].Cells[7].Value = Math.Round(productBatchInfo.MRP, 2);
										flag = false;
									}
								}
							}
							if (flag)
							{
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[4].Value = DateTime.Now;
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[5].Value = "";
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[6].Value = "";
								this.dgvSalesInvoice.Rows[e.RowIndex].Cells[7].Value = "";
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

		private void dgvPurchaseInvoice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvSalesInvoice.CurrentCell is DataGridViewComboBoxCell)
				{
					this.dgvSalesInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
				if (this.dgvSalesInvoice.CurrentCell is DataGridViewTextBoxCell)
				{
					this.dgvSalesInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			try
			{
                if (e.Control is ComboBox)
                {
                    
                    if (this.dgvSalesInvoice.CurrentCell.ColumnIndex == 2)
                    {
                        ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                        ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                    }

                    // ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                DataGridViewTextBoxEditingControl control = e.Control as DataGridViewTextBoxEditingControl;
				if (control != null)
				{
					control.KeyPress += new KeyPressEventHandler(this.TextBoxCellEditControlKeyPress);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_Enter(object sender, EventArgs e)
		{
		}

		private void dgvPurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
		{
            try
            {
                if (e.KeyCode == Keys.F6)
                {

                    if (this.dgvSalesInvoice.CurrentRow != null)
                    {
                        if (this.dgvSalesInvoice.Rows[this.rowIndex].Cells[1].Value != null)
                        {
                            var popup = new frmPurchaseRateWindow(this.dgvSalesInvoice.Rows[this.rowIndex].Cells[1].Value.ToString());
                            popup.Show();
                        }

                    }

                }


                if (e.KeyCode == Keys.F7)
                {

                    if (this.dgvSalesInvoice.CurrentRow != null)
                    {
                        if (this.dgvSalesInvoice.Rows[this.rowIndex].Cells[1].Value != null)
                        {
                            var popup = new frmPatientpraviousRate(this.cmbPatient.SelectedValue.ToString(), this.dgvSalesInvoice.Rows[this.rowIndex].Cells[1].Value.ToString());
                            //var popup = new frmPatientpraviousRate(this.dgvSalesInvoice.Rows[this.rowIndex].Cells[1].Value.ToString());
                            popup.Show();
                        }

                    }

                    //}
                    if (this.dgvSalesInvoice.CurrentRow != null)
                    {
                        if (!(this.dgvSalesInvoice.Rows[this.rowIndex].DefaultCellStyle.BackColor != Color.Cornsilk))
                        {
                            if (this.dgvSalesInvoice.CurrentCell.ColumnIndex == 3)
                            {
                                e.Handled = true;
                                // Keys.Enter
                            }
                            if (e.KeyCode == Keys.Return)
                            {
                                e.Handled = false;
                            }
                        }
                        else if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvSalesInvoice.CurrentCell.ColumnIndex == 3 : false))
                        {
                            if (this.dgvSalesInvoice.CurrentRow != null)
                            {
                                this.dgvSalesInvoice.Rows[this.rowIndex].Cells[3].Value = "";
                                this.lstbxBatch.Focus();
                                if (this.lstbxBatch.SelectedValue != null)
                                {
                                    this.lstbxBatch.SelectedIndex = 0;
                                }
                                e.Handled = true;
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

		private void dgvPurchaseInvoice_Leave(object sender, EventArgs e)
		{
			this.CalculateTotal();
		}

		private void dgvPurchaseInvoice_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 0)
				{
					if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value == null)
					{
						this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value = "Included";
					}
					else if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value.ToString() == "")
					{
						this.dgvSalesInvoice.Rows[e.RowIndex].Cells[15].Value = "Included";
					}
                    if (this.dgvSalesInvoice.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        lblRows.Text = (dgvSalesInvoice.RowCount - 1).ToString();
                    }
                }
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvSalesInvoice_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvSalesInvoice.CurrentCell == this.dgvSalesInvoice[18, this.dgvSalesInvoice.Rows.Count - 1])
					{
						this.txtDescription.Focus();
						this.dgvSalesInvoice.ClearSelection();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvSalesInvoice_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if ((this.dgvSalesInvoice.CurrentCell == null || this.dgvSalesInvoice.CurrentCell.ColumnIndex != 0 ? false : this.dgvSalesInvoice.CurrentCell.RowIndex == 0))
					{
						if (this.p != 1)
						{
							frmSalesInvoice _frmSalesInvoice = this;
							_frmSalesInvoice.p = _frmSalesInvoice.p + 1;
						}
						else
						{
							this.p = 0;
							this.dgvSalesInvoice.ClearSelection();
							this.cmbSalesman.Focus();
						}
					}
				}
				if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvSalesInvoice.CurrentCell.ColumnIndex == 3 : false))
				{
					if (this.dgvSalesInvoice.Rows[this.rowIndex].DefaultCellStyle.BackColor != Color.Cornsilk)
					{
						this.dgvSalesInvoice.Rows[this.rowIndex].Cells[3].Value = "";
						this.lstbxBatch.Focus();
						if (this.lstbxBatch.SelectedValue != null)
						{
							this.lstbxBatch.SelectedIndex = 0;
						}
						e.Handled = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvSalesInvoice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.FillComboItem();
		}

		private void dgvSalesInvoice_Scroll(object sender, ScrollEventArgs e)
		{
			try
			{
				this.lstbxBatch.Visible = false;
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

		public void DoReceiptLedgerPosting(string strPaymentId)
		{
			try
			{
				if (this.txtPaidAmount.Text != "")
				{
					if (decimal.Parse(this.txtPaidAmount.Text) > new decimal(0))
					{
						LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo()
						{
							VoucherNumber = strPaymentId,
							VoucherType = "Receipt Voucher",
							Description = "By Receipt",
							Date = DateTime.Parse(this.dtpDate.Text),
							LedgerId = "2",
							Credit = new decimal(0),
							Debit = decimal.Parse(this.txtPaidAmount.Text)
						};
						this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
						ledgerPostingInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
						ledgerPostingInfo.Debit = new decimal(0);
						ledgerPostingInfo.Credit = decimal.Parse(this.txtPaidAmount.Text);
						this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DoWhenComingFromRegister(frmSalesRegister frmsalesregister, string strSalesMasterId)
		{
			try
			{
				base.Show();
				this.isCellValueChanged = true;
				this.cmbPatient.Enabled = false;
				this.isFromSalesregister = true;
				this.isInEditMode = true;
				this.btnSave.Text = "&Update";
				this.btnDelete.Enabled = true;
				this.btnClear.Text = "&New";
				this.lblBalance.Visible = false;
				this.lblBalanceAmount.Visible = false;
                this.lblRemainingBalance.Visible = false;
                this.lblPaidAmount.Visible = false;
				this.txtPaidAmount.Visible = false;
				bool flag = true;
				decimal num = new decimal(0, 0, 0, false, 2);
				decimal num1 = new decimal(0, 0, 0, false, 2);
				decimal num2 = new decimal(0, 0, 0, false, 2);
				decimal num3 = new decimal(0, 0, 0, false, 2);
				decimal num4 = new decimal(0, 0, 0, false, 2);
				decimal num5 = new decimal(0, 0, 0, false, 2);
				string str = "";
				this.frmRegister = frmsalesregister;
				int white = 0;
				SalesMasterSP salesMasterSP = new SalesMasterSP();
				SalesMasterInfo salesMasterInfo = new SalesMasterInfo();
				SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
				SalesDetailsInfo salesDetailsInfo = new SalesDetailsInfo();
				DataTable dataTable = new DataTable();
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				ProductInfo productInfo = new ProductInfo();
				ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
				ManufacturerSP manufacturerSP = new ManufacturerSP();
				UnitInfo unitInfo = new UnitInfo();
				UnitSP unitSP = new UnitSP();
				salesMasterInfo = salesMasterSP.SalesMasterView(strSalesMasterId);
				if (salesMasterInfo.SalesMasterId != null)
				{
					this.txtVoucherNo.Text = salesMasterInfo.SalesMasterId;
					this.dtpDate.Text = salesMasterInfo.Date.ToString();
					this.FillComboCashVender();
					this.txtInvoice.Text = salesMasterInfo.SalesInvoiceNo;
					if (salesMasterInfo.LedgerId != null)
					{
						this.cmbCashVendor.SelectedValue = salesMasterInfo.LedgerId;
					}
					if (salesMasterInfo.SalesManId != null)
					{
						this.FillSalesManCombo(salesMasterInfo.SalesManId);
						this.cmbSalesman.SelectedValue = salesMasterInfo.SalesManId;
					}
					if (salesMasterInfo.PatientId != null)
					{
						this.FillPatientCombo();
						this.cmbPatient.SelectedValue = salesMasterInfo.PatientId;
					}
					if (salesMasterInfo.DoctorId != null)
					{
						this.cmbDoctor.SelectedValue = salesMasterInfo.DoctorId;
					}
					this.txtBillDiscount.Text = salesMasterInfo.BillDiscount.ToString();
					this.txtDescription.Text = salesMasterInfo.Description;
					dataTable = salesDetailsSP.SalesDetailsViewAllByMasterId(strSalesMasterId);
					if (dataTable.Rows.Count > 0)
					{
						foreach (DataRow row in dataTable.Rows)
						{
							flag = true;
							num = new decimal(0, 0, 0, false, 2);
							num1 = new decimal(0, 0, 0, false, 2);
							num2 = new decimal(0, 0, 0, false, 2);
							num3 = new decimal(0, 0, 0, false, 2);
							num4 = new decimal(0, 0, 0, false, 2);
							num5 = new decimal(0, 0, 0, false, 2);
							str = "";
							if (row.ItemArray[2].ToString() != null)
							{
								this.dgvSalesInvoice.Rows.Add();
								if (!salesDetailsSP.SalesDetailsCheckOnDelete(row.ItemArray[0].ToString()))
								{
									this.dgvSalesInvoice.Rows[white].ReadOnly = false;
									this.dgvSalesInvoice.Rows[white].DefaultCellStyle.BackColor = Color.White;
								}
								else
								{
									this.dgvSalesInvoice.Rows[white].ReadOnly = true;
									this.dgvSalesInvoice.Rows[white].DefaultCellStyle.BackColor = Color.Cornsilk;
								}
								this.dgvSalesInvoice.Rows[white].Cells[0].Value = row.ItemArray[8].ToString();
								productBatchInfo = productBatchSP.ProductBatchView(row.ItemArray[2].ToString());
								this.dgvSalesInvoice.Rows[white].Cells[1].Value = productBatchInfo.ProductId;
								productInfo = this.productsp.ProductView(productBatchInfo.ProductId);
								this.dgvSalesInvoice.Rows[white].Cells[2].Value = productBatchInfo.ProductId;
								this.FillBatchCombo(productBatchInfo.ProductId);
								this.dgvSalesInvoice.Rows[white].Cells[3].Value = productBatchInfo.BatchName;
								if (!(DateTime.Parse(productBatchInfo.ExpiryDate.ToString()) == DateTime.Parse("01/01/1753")))
								{
									this.dgvSalesInvoice.Rows[white].Cells[4].Value = productBatchInfo.ExpiryDate;
								}
								else
								{
									this.dgvSalesInvoice.Rows[white].Cells[4].Value = "";
								}
								DataGridViewCell item = this.dgvSalesInvoice.Rows[white].Cells[5];
								decimal purchaseRate = productBatchInfo.PurchaseRate;
								double num6 = double.Parse(purchaseRate.ToString());
								item.Value = num6.ToString();
								DataGridViewCell dataGridViewCell = this.dgvSalesInvoice.Rows[white].Cells[6];
								num6 = double.Parse(row.ItemArray[3].ToString());
								dataGridViewCell.Value = num6.ToString();
								DataGridViewCell item1 = this.dgvSalesInvoice.Rows[white].Cells[7];
								purchaseRate = productBatchInfo.MRP;
								num6 = double.Parse(purchaseRate.ToString());
								item1.Value = num6.ToString();
								manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
								this.dgvSalesInvoice.Rows[white].Cells[8].Value = manufacturerInfo.ManufactureName;
								DataGridViewCell str1 = this.dgvSalesInvoice.Rows[white].Cells[9];
								num6 = double.Parse(row.ItemArray[5].ToString());
								str1.Value = num6.ToString();
								this.dgvSalesInvoice.Rows[white].Cells[10].Value = Math.Round(decimal.Parse(row.ItemArray[6].ToString()), 2);
								unitInfo = unitSP.UnitView(productInfo.UnitId);
								this.dgvSalesInvoice.Rows[white].Cells[11].Value = unitInfo.UnitName;
								if ((decimal.Parse(row.ItemArray[3].ToString()) == new decimal(0) ? true : !(row.ItemArray[5].ToString() != "")))
								{
									num2 = new decimal(0);
									this.dgvSalesInvoice.Rows[white].Cells[12].Value = 0;
								}
								else
								{
									num = decimal.Parse(row.ItemArray[3].ToString());
									num1 = decimal.Parse(row.ItemArray[5].ToString());
									num2 = num * num1;
									this.dgvSalesInvoice.Rows[white].Cells[12].Value = Math.Round(num2, 2);
								}
								this.dgvSalesInvoice.Rows[white].Cells[13].Value = Math.Round(decimal.Parse(row.ItemArray[7].ToString()), 2);
								if (!(num2 == new decimal(0) ? true : !(row.ItemArray[7].ToString() != "")))
								{
									num3 = decimal.Parse(row.ItemArray[7].ToString());
									num4 = Math.Round(num2 - ((num2 * num3) / new decimal(100)), 2);
									this.dgvSalesInvoice.Rows[white].Cells[14].Value = num4;
								}
								else if (num2 == new decimal(0))
								{
									this.dgvSalesInvoice.Rows[white].Cells[14].Value = 0;
								}
								else if (decimal.Parse(row.ItemArray[7].ToString()) == new decimal(0))
								{
									this.dgvSalesInvoice.Rows[white].Cells[14].Value = Math.Round(num2);
								}
								if ((num4 == new decimal(0) ? true : !(decimal.Parse(row.ItemArray[10].ToString()) != new decimal(0))))
								{
									this.dgvSalesInvoice.Rows[white].Cells[17].Value = 0;
								}
								else
								{
									flag = false;
									num5 = decimal.Parse(row.ItemArray[10].ToString());
									str = row.ItemArray[9].ToString();
									if (str == "False")
									{
										this.dgvSalesInvoice.Rows[white].Cells[17].Value = Math.Round((num4 * num5) / (new decimal(100) + num5), 2);
										this.dgvSalesInvoice.Rows[white].Cells[18].Value = num4;
									}
									else if (!(str == "True"))
									{
										this.dgvSalesInvoice.Rows[white].Cells[18].Value = num4;
									}
									else
									{
										this.dgvSalesInvoice.Rows[white].Cells[17].Value = Math.Round((num4 * num5) / new decimal(100), 2);
										this.dgvSalesInvoice.Rows[white].Cells[18].Value = num4 + decimal.Parse(this.dgvSalesInvoice.Rows[white].Cells[17].Value.ToString());
									}
								}
								if (flag)
								{
									if (!(num4 != new decimal(0)))
									{
										this.dgvSalesInvoice.Rows[white].Cells[18].Value = "";
									}
									else
									{
										this.dgvSalesInvoice.Rows[white].Cells[18].Value = num4;
									}
								}
								if (!(row.ItemArray[9].ToString() == "True"))
								{
									this.dgvSalesInvoice.Rows[white].Cells[15].Value = "Included";
								}
								else
								{
									this.dgvSalesInvoice.Rows[white].Cells[15].Value = "Excluded";
								}
								this.dgvSalesInvoice.Rows[white].Cells[16].Value = Math.Round(decimal.Parse(row.ItemArray[10].ToString()), 2);
								this.dgvSalesInvoice.Rows[white].Cells[19].Value = row.ItemArray[0].ToString();
								white++;
							}
						}
						this.CalculateTotal();
						this.dgvSalesInvoice.ClearSelection();
					}
				}
				this.isCellValueChanged = false;
				base.ActiveControl = this.dtpDate;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DoWhenQuitingForm()
		{
			try
			{
				if (this.isFromSalesregister)
				{
					this.frmRegister.FillRegister();
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

		private void dtpDate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpDueDays_KeyDown(object sender, KeyEventArgs e)
		{
		}

		public void FillBatchCombo(string productId)
		{
			try
			{
				this.lstbxBatch.Items.Clear();
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				DataTable dataTable = new DataTable();
				dataTable = productBatchSP.ProductBatchViewAllByProductId(productId);
				if (dataTable.Rows.Count != 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						this.lstbxBatch.Items.Add(row.ItemArray[2]);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillComboCashVender()
		{
			try
			{
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				DataTable dataTable = new DataTable();
				dataTable = accountLedgerSP.AccountLedgerViewUnderSundryDebtorCreditorCash();
				if (dataTable.Rows.Count > 0)
				{
					this.cmbCashVendor.DataSource = dataTable;
					this.cmbCashVendor.ValueMember = "Account Ledger Id";
					this.cmbCashVendor.DisplayMember = "Account Ledger Name";
					this.cmbCashVendor.SelectedValue = 2;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillComboFromAccountledgerForm(string ledgerId)
		{
			try
			{
				base.Enabled = true;
				string str = "";
				if (this.cmbCashVendor.SelectedValue != null)
				{
					str = this.cmbCashVendor.SelectedValue.ToString();
				}
				this.FillComboCashVender();
				if (ledgerId != "")
				{
					this.cmbCashVendor.SelectedValue = ledgerId;
				}
				else if (!(str != ""))
				{
					this.cmbCashVendor.SelectedValue = -1;
				}
				else
				{
					this.cmbCashVendor.SelectedValue = str;
				}
				this.cmbCashVendor.Focus();
				base.WindowState = FormWindowState.Normal;
				base.Activate();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillComboFromSalesmanForm(string SalesmanId)
		{
			try
			{
				base.Enabled = true;
				string str = "";
				if (this.cmbSalesman.SelectedValue != null)
				{
					str = this.cmbSalesman.SelectedValue.ToString();
				}
				this.FillSalesManCombo("");
				if (SalesmanId != "")
				{
					this.cmbSalesman.SelectedValue = SalesmanId;
				}
				else if (!(str != ""))
				{
					this.cmbSalesman.SelectedValue = -1;
				}
				else
				{
					this.cmbSalesman.SelectedValue = str;
				}
				this.cmbSalesman.Focus();
				base.WindowState = FormWindowState.Normal;
				base.Activate();
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
				this.cmbProduct.DataSource = null;
				ProductSP productSP = new ProductSP();
				DataTable dataTable = new DataTable();
				dataTable = productSP.ProductViewAll();
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
					this.cmbProduct.DataSource = dataTable;
					this.cmbProduct.ValueMember = "Id";
					this.cmbProduct.DisplayMember = "Name";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillDoctorCombo()
		{
			try
			{
				DoctorSP doctorSP = new DoctorSP();
				DataTable dataTable = new DataTable();
				dataTable = doctorSP.DoctorViewAll();
				if (dataTable.Rows.Count > 0)
				{
					this.cmbDoctor.DataSource = dataTable;
					this.cmbDoctor.ValueMember = "Id";
					this.cmbDoctor.DisplayMember = "Name";
					this.cmbDoctor.SelectedValue = 0;
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
				dataTable = patientSP.PatientViewAll();
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

		public void FillSalesManCombo(string SalesManId)
		{
			try
			{
				bool flag = false;
				SalesManSP salesManSP = new SalesManSP();
				DataTable dataTable = new DataTable();
				SalesManInfo salesManInfo = new SalesManInfo();
				dataTable = salesManSP.SalesManViewAllActive();
				if (SalesManId != "")
				{
					foreach (DataRow row in dataTable.Rows)
					{
						if (row.ItemArray[0].ToString() == SalesManId)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						DataRow salesManId = dataTable.NewRow();
						dataTable.Rows.Add(salesManId);
						salesManId["Sales Man Id"] = SalesManId;
						salesManId["Sales Man Name"] = salesManSP.SalesManView(SalesManId).SalesManName;
					}
				}
				if (dataTable.Rows.Count > 0)
				{
					this.cmbSalesman.DataSource = dataTable;
					this.cmbSalesman.ValueMember = "Sales Man Id";
					this.cmbSalesman.DisplayMember = "Sales Man Name";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmPurchaseInvoice_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.isFormClose = true;
				this.DoWhenQuitingForm();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmPurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Escape)
				{
					if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
					{
						base.Close();
					}
				}
				else if (e.KeyCode == Keys.F2)
				{
					try
					{
						Process.Start("calc");
					}
					catch (Exception exception)
					{
						MessageBox.Show("Can't run calculator", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmPurchaseInvoice_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.isInEditMode)
				{
					CompanySP companySP = new CompanySP();
					DataTable dataTable = new DataTable();
					dataTable = companySP.CompanyViewAll();
                    if (dataTable.Rows.Count > 0)
                    {
                        this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
                    }
                   
					this.ClearFunction();
					this.CreateDataTableForDeletedIDs();
				}
				this.dtpDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpDate.MaxDate = FinacialYearInfo._toDate;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public string GetMaxofSalesMasterId()
		{
			string str = "";
			try
			{
				str = (new SalesMasterSP()).SalesMasterGetMax().ToString();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return str;
		}

        public string GetMaxofSalesMasterInvoice()
        {
            string str = "";
            try
            {
                str = (new SalesMasterSP()).SalesMasterGetInnoiceMax().ToString();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return str;
        }

        private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSalesInvoice));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.pbxSearch = new PictureBox();
			this.lstbxBatch = new ListBox();
			this.lblBalanceAmount = new Label();
			this.lblBalance = new Label();
            this.lblRemainingBalance = new Label();
            this.lblPaidAmount = new Label();
			this.txtPaidAmount = new TextBox();
			this.btnRemove = new Button();
			this.chbxprint = new CheckBox();
            this.chbxwarranty = new CheckBox();
            this.label7 = new Label();
			this.lblGrandTotal = new Label();
			this.lblGrand = new Label();
			this.label22 = new Label();
			this.txtBillDiscount = new TextBox();
			this.lblTotalAmount = new Label();
			this.lblTot = new Label();
            this.lblCountRows = new Label();
            this.lblRows = new Label();
            this.lblTaxAmount = new Label();
			this.lblTax = new Label();
            this.lblRemBalance = new Label();
            this.RemBalance = new Label();
			this.label5 = new Label();
			this.txtDescription = new TextBox();
			this.label15 = new Label();
			this.txtInvoice = new TextBox();
			this.label14 = new Label();
			this.label13 = new Label();
			this.lblBlnceAmount = new Label();
			this.dtpDate = new DateTimePicker();
			this.btnNewSalesman = new Button();
			this.btnNewledgers = new Button();
			this.cmbSalesman = new ComboBox();
			this.label9 = new Label();
			this.cmbDoctor = new ComboBox();
			this.label8 = new Label();
			this.cmbPatient = new ComboBox();
			this.label6 = new Label();
			this.cmbCashVendor = new ComboBox();
			this.label3 = new Label();
			this.txtVoucherNo = new TextBox();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.lblTotalNew = new Label();
			this.dgvSalesInvoice = new dgv.DataGridViewEnter();
			this.Column2 = new DataGridViewCheckBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.cmbProduct = new DataGridViewComboBoxColumn();
			this.cmbBatch = new DataGridViewTextBoxColumn();
			this.Column4 = new DateInGrid.CalendarColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.Column9 = new DataGridViewTextBoxColumn();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column13 = new DataGridViewTextBoxColumn();
			this.Column14 = new DataGridViewTextBoxColumn();
			this.Column15 = new DataGridViewComboBoxColumn();
			this.Column16 = new DataGridViewTextBoxColumn();
			this.Column17 = new DataGridViewTextBoxColumn();
			this.Column18 = new DataGridViewTextBoxColumn();
			this.Column19 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.pbxSearch).BeginInit();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.dgvSalesInvoice).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.btnClear);
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
			this.panel1.Size = new System.Drawing.Size(778, 554);
			this.panel1.TabIndex = 16;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(451, 511);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnSave.KeyDown += new KeyEventHandler(this.btnSave_KeyDown);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(532, 511);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 16;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(613, 511);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 17;
			this.btnClear.Text = "Cl&ear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(694, 511);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 18;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.lblTotalNew);
			this.panel8.Controls.Add(this.pbxSearch);
			this.panel8.Controls.Add(this.lstbxBatch);
			this.panel8.Controls.Add(this.lblBalanceAmount);
			this.panel8.Controls.Add(this.lblBalance);
            this.panel8.Controls.Add(this.lblRemainingBalance);
			this.panel8.Controls.Add(this.lblPaidAmount);
			this.panel8.Controls.Add(this.txtPaidAmount);
			this.panel8.Controls.Add(this.btnRemove);
			this.panel8.Controls.Add(this.dgvSalesInvoice);
			this.panel8.Controls.Add(this.chbxprint);
            this.panel8.Controls.Add(this.chbxwarranty);
            this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.lblGrandTotal);
			this.panel8.Controls.Add(this.lblGrand);
			this.panel8.Controls.Add(this.label22);
			this.panel8.Controls.Add(this.txtBillDiscount);
			this.panel8.Controls.Add(this.lblTotalAmount);
			this.panel8.Controls.Add(this.lblTot);
            this.panel8.Controls.Add(this.lblRows);
            this.panel8.Controls.Add(this.lblCountRows);
            this.panel8.Controls.Add(this.lblTaxAmount);
			this.panel8.Controls.Add(this.lblTax);
            this.panel8.Controls.Add(this.lblRemBalance);
            this.panel8.Controls.Add(this.RemBalance);

			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label15);
			this.panel8.Controls.Add(this.txtInvoice);
			this.panel8.Controls.Add(this.label14);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.lblBlnceAmount);
			this.panel8.Controls.Add(this.dtpDate);
			this.panel8.Controls.Add(this.btnNewSalesman);
			this.panel8.Controls.Add(this.btnNewledgers);
			this.panel8.Controls.Add(this.cmbSalesman);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Controls.Add(this.cmbDoctor);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.cmbPatient);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Controls.Add(this.cmbCashVendor);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtVoucherNo);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(776, 449);
			this.panel8.TabIndex = 0;
			this.panel8.Paint += new PaintEventHandler(this.panel8_Paint);
			this.pbxSearch.Image = (Image)componentResourceManager.GetObject("pbxSearch.Image");
			this.pbxSearch.Location = new Point(680, 98);
			this.pbxSearch.Name = "pbxSearch";
			this.pbxSearch.Size = new System.Drawing.Size(81, 28);
			this.pbxSearch.TabIndex = 36456464;
			this.pbxSearch.TabStop = false;
			this.pbxSearch.Click += new EventHandler(this.btnSearch_Click);
			this.pbxSearch.MouseHover += new EventHandler(this.pbxSearch_MouseHover);
			this.lstbxBatch.FormattingEnabled = true;
			this.lstbxBatch.Location = new Point(415, 178);
			this.lstbxBatch.Name = "lstbxBatch";
			this.lstbxBatch.Size = new System.Drawing.Size(150, 95);
			this.lstbxBatch.TabIndex = 36456460;
			this.lstbxBatch.TabStop = false;
			this.lstbxBatch.DoubleClick += new EventHandler(this.lstbxBatch_DoubleClick);
			this.lstbxBatch.KeyDown += new KeyEventHandler(this.lstbxBatch_KeyDown);
			this.lblBalanceAmount.AutoSize = true;
			this.lblBalanceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblBalanceAmount.Location = new Point(646, 424);
			this.lblBalanceAmount.Name = "lblBalanceAmount";
			this.lblBalanceAmount.Size = new System.Drawing.Size(32, 13);
			this.lblBalanceAmount.TabIndex = 36456462;
			this.lblBalanceAmount.Text = "0.00";
			this.lblBalance.AutoSize = true;
			this.lblBalance.Location = new Point(533, 424);
			this.lblBalance.Name = "lblBalance";
			this.lblBalance.Size = new System.Drawing.Size(88, 13);
			this.lblBalance.TabIndex = 36456461;
			this.lblBalance.Text = "Balance Amount:";

            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.Location = new Point(200, 500);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(88, 13);
            this.lblRemainingBalance.TabIndex = 55667;
            this.lblRemainingBalance.Text = "Remaning Balance:";
            this.lblPaidAmount.AutoSize = true;
			this.lblPaidAmount.Location = new Point(532, 401);
			this.lblPaidAmount.Name = "lblPaidAmount";
			this.lblPaidAmount.Size = new System.Drawing.Size(70, 13);
			this.lblPaidAmount.TabIndex = 36456460;
			this.lblPaidAmount.Text = "Paid Amount:";
			this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtPaidAmount.Location = new Point(648, 394);
			this.txtPaidAmount.MaxLength = 15;
			this.txtPaidAmount.Name = "txtPaidAmount";
			this.txtPaidAmount.Size = new System.Drawing.Size(111, 20);
			this.txtPaidAmount.TabIndex = 11;
			this.txtPaidAmount.Leave += new EventHandler(this.txtPaidAmount_Leave);
			this.txtPaidAmount.KeyPress += new KeyPressEventHandler(this.txtPaidAmount_KeyPress);
			this.txtPaidAmount.KeyDown += new KeyEventHandler(this.txtPaidAmount_KeyDown);
			this.btnRemove.BackColor = Color.SteelBlue;
			this.btnRemove.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRemove.ForeColor = Color.White;
			this.btnRemove.Location = new Point(674, 274);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(85, 23);
			this.btnRemove.TabIndex = 36456457;
			this.btnRemove.TabStop = false;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.chbxprint.AutoSize = true;
			this.chbxprint.Location = new Point(20, 400);
			this.chbxprint.Name = "chbxprint";
			this.chbxprint.Size = new System.Drawing.Size(97, 17);
			this.chbxprint.TabIndex = 55665;
			this.chbxprint.TabStop = false;
			this.chbxprint.Text = "Print after save";
			this.chbxprint.UseVisualStyleBackColor = true;
			this.chbxprint.KeyDown += new KeyEventHandler(this.chbxprint_KeyDown);

            // 
            // chbxwarranty
            // 
            this.chbxwarranty.AutoSize = true;
            this.chbxwarranty.Location = new System.Drawing.Point(200, 400);
            this.chbxwarranty.Name = "chbxwarranty";
            this.chbxwarranty.Size = new System.Drawing.Size(69, 17);
            this.chbxwarranty.TabIndex = 55666;
            this.chbxwarranty.TabStop = false;
            this.chbxwarranty.Text = "Warranty";
            this.chbxwarranty.UseVisualStyleBackColor = true;
            this.chbxwarranty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chbxSelect_KeyDown);

            this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.ForeColor = Color.Red;
			this.label7.Location = new Point(761, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 13);
			this.label7.TabIndex = 36456458;
			this.label7.Text = "*";
			this.lblGrandTotal.AutoSize = true;
			this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblGrandTotal.Location = new Point(645, 377);
			this.lblGrandTotal.Name = "lblGrandTotal";
			this.lblGrandTotal.Size = new System.Drawing.Size(32, 13);
			this.lblGrandTotal.TabIndex = 71;
			this.lblGrandTotal.Text = "0.00";
			this.lblGrand.AutoSize = true;
			this.lblGrand.Location = new Point(532, 377);
			this.lblGrand.Name = "lblGrand";
			this.lblGrand.Size = new System.Drawing.Size(66, 13);
			this.lblGrand.TabIndex = 70;
			this.lblGrand.Text = "Grand Total:";
			this.label22.AutoSize = true;
			this.label22.Location = new Point(532, 356);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(68, 13);
			this.label22.TabIndex = 69;
			this.label22.Text = "Bill Discount:";
			this.txtBillDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtBillDiscount.Location = new Point(648, 349);
			this.txtBillDiscount.MaxLength = 6;
			this.txtBillDiscount.Name = "txtBillDiscount";
			this.txtBillDiscount.Size = new System.Drawing.Size(111, 20);
			this.txtBillDiscount.TabIndex = 10;
			this.txtBillDiscount.Enter += new EventHandler(this.txtBillDiscount_Enter);
			this.txtBillDiscount.Leave += new EventHandler(this.txtBillDiscount_Leave);
			this.txtBillDiscount.KeyPress += new KeyPressEventHandler(this.txtBillDiscount_KeyPress);
			this.txtBillDiscount.KeyDown += new KeyEventHandler(this.txtBillDiscount_KeyDown);
			this.lblTotalAmount.AutoSize = true;
			this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTotalAmount.Location = new Point(645, 330);
			this.lblTotalAmount.Name = "lblTotalAmount";
			this.lblTotalAmount.Size = new System.Drawing.Size(32, 13);
			this.lblTotalAmount.TabIndex = 65;
			this.lblTotalAmount.Text = "0.00";
			this.lblTotalAmount.TextChanged += new EventHandler(this.lblTotalAmount_TextChanged);
			this.lblTot.AutoSize = true;
			this.lblTot.Location = new Point(532, 330);
			this.lblTot.Name = "lblTot";
			this.lblTot.Size = new System.Drawing.Size(73, 13);
			this.lblTot.TabIndex = 64;
			this.lblTot.Text = "Total Amount:";
			this.lblTaxAmount.AutoSize = true;
			this.lblTaxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTaxAmount.Location = new Point(645, 307);
			this.lblTaxAmount.Name = "lblTaxAmount";
			this.lblTaxAmount.Size = new System.Drawing.Size(32, 13);
			this.lblTaxAmount.TabIndex = 63;
			this.lblTaxAmount.Text = "0.00";
			this.lblTax.AutoSize = true;
			this.lblTax.Location = new Point(532, 307);
			this.lblTax.Name = "lblTax";
			this.lblTax.Size = new System.Drawing.Size(67, 13);
			this.lblTax.TabIndex = 62;
			this.lblTax.Text = "Tax Amount:";
           //this.lblTax.Visible = false;

            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRows.Location = new System.Drawing.Point(645, 285);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(32, 13);
            this.lblRows.TabIndex = 97;
            this.lblRows.Text = "0";
            //
            //  lblRemBalance 

            //
            this.lblRemBalance.AutoSize = true;
            this.lblRemBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemBalance.Location = new System.Drawing.Point(645, 285);
            this.lblRemBalance.Name = "lblRows";
            this.lblRemBalance.Size = new System.Drawing.Size(32, 13);
            this.lblRemBalance.TabIndex = 97;
            this.lblRemBalance.Text = "0";
            // 

            //

            //
            this.RemBalance.AutoSize = true;
            this.RemBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemBalance.Location = new System.Drawing.Point(645, 285);
            this.RemBalance.Name = "lblRows";
            this.RemBalance.Size = new System.Drawing.Size(32, 13);
            this.RemBalance.TabIndex = 97;
            this.RemBalance.Text = "0";
            //
            // lblCountRows
            // 
            this.lblCountRows.AutoSize = true;
            this.lblCountRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRows.Location = new System.Drawing.Point(532, 285);
            this.lblCountRows.Name = "lblCountRows";
            this.lblCountRows.Size = new System.Drawing.Size(44, 13);
            this.lblCountRows.TabIndex = 96;
            this.lblCountRows.Text = "Count:";
            // 
            this.label5.AutoSize = true;
			this.label5.Location = new Point(17, 319);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 61;
			this.label5.Text = "Description:";
			this.txtDescription.Location = new Point(20, 339);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(260, 55);
			this.txtDescription.TabIndex = 8;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.txtDescription.KeyDown += new KeyEventHandler(this.txtDescription_KeyDown);
			this.label15.AutoSize = true;
			this.label15.Location = new Point(340, 96);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(86, 13);
			this.label15.TabIndex = 53;
			this.label15.Text = "Current Balance:";
			this.txtInvoice.Location = new Point(619, 34);
			this.txtInvoice.MaxLength = 50;
			this.txtInvoice.Name = "txtInvoice";
			this.txtInvoice.Size = new System.Drawing.Size(140, 20);
			this.txtInvoice.TabIndex = 3;
			this.txtInvoice.Leave += new EventHandler(this.txtInvoice_Leave);
			this.txtInvoice.KeyDown += new KeyEventHandler(this.txtInvoice_KeyDown);
			this.label14.AutoSize = true;
			this.label14.Location = new Point(528, 41);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(62, 13);
			this.label14.TabIndex = 51;
			this.label14.Text = "Invoice No:";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(528, 15);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 50;
			this.label13.Text = "Date:";
			this.lblBlnceAmount.AutoSize = true;
			this.lblBlnceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblBlnceAmount.Location = new Point(432, 96);
			this.lblBlnceAmount.Name = "lblBlnceAmount";
			this.lblBlnceAmount.Size = new System.Drawing.Size(32, 13);
			this.lblBlnceAmount.TabIndex = 47;
			this.lblBlnceAmount.Text = "0.00";
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(619, 8);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(140, 20);
			this.dtpDate.TabIndex = 1;
			this.dtpDate.KeyDown += new KeyEventHandler(this.dtpDate_KeyDown);
			this.btnNewSalesman.BackColor = Color.SteelBlue;
			this.btnNewSalesman.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewSalesman.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewSalesman.ForeColor = Color.White;
			this.btnNewSalesman.Location = new Point(280, 86);
			this.btnNewSalesman.Name = "btnNewSalesman";
			this.btnNewSalesman.Size = new System.Drawing.Size(54, 23);
			this.btnNewSalesman.TabIndex = 36456456;
			this.btnNewSalesman.TabStop = false;
			this.btnNewSalesman.Text = "New";
			this.btnNewSalesman.UseVisualStyleBackColor = false;
			this.btnNewSalesman.Click += new EventHandler(this.btnNewSalesman_Click);
			this.btnNewledgers.BackColor = Color.SteelBlue;
			this.btnNewledgers.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewledgers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewledgers.ForeColor = Color.White;
			this.btnNewledgers.Location = new Point(280, 32);
			this.btnNewledgers.Name = "btnNewledgers";
			this.btnNewledgers.Size = new System.Drawing.Size(54, 23);
			this.btnNewledgers.TabIndex = 36456456;
			this.btnNewledgers.TabStop = false;
			this.btnNewledgers.Text = "New";
			this.btnNewledgers.UseVisualStyleBackColor = false;
			this.btnNewledgers.Click += new EventHandler(this.btnNew_Click);
			this.cmbSalesman.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSalesman.FormattingEnabled = true;
			this.cmbSalesman.Location = new Point(134, 88);
			this.cmbSalesman.Name = "cmbSalesman";
			this.cmbSalesman.Size = new System.Drawing.Size(140, 21);
			this.cmbSalesman.TabIndex = 6;
			this.cmbSalesman.SelectedIndexChanged += new EventHandler(this.cmbCashVendor_SelectedIndexChanged);
			this.cmbSalesman.KeyDown += new KeyEventHandler(this.cmbSalesman_KeyDown);
			this.label9.AutoSize = true;
			this.label9.Location = new Point(8, 93);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(60, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "Sales Man:";
			this.cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbDoctor.FormattingEnabled = true;
			this.cmbDoctor.Location = new Point(619, 60);
			this.cmbDoctor.Name = "cmbDoctor";
			this.cmbDoctor.Size = new System.Drawing.Size(140, 21);
			this.cmbDoctor.TabIndex = 5;
			this.cmbDoctor.Leave += new EventHandler(this.cmbDoctor_Leave);
			this.cmbDoctor.SelectedIndexChanged += new EventHandler(this.cmbCashVendor_SelectedIndexChanged);
			this.cmbDoctor.KeyDown += new KeyEventHandler(this.cmbDoctor_KeyDown);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(528, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Doctor:";
			this.cmbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.cmbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbPatient.FormattingEnabled = true;
			this.cmbPatient.Location = new Point(134, 61);
			this.cmbPatient.Name = "cmbPatient";
			this.cmbPatient.Size = new System.Drawing.Size(140, 21);
			this.cmbPatient.TabIndex = 4;
			this.cmbPatient.Leave += new EventHandler(this.cmbPatient_Leave);
			this.cmbPatient.SelectedIndexChanged += new EventHandler(this.cmbPatient_SelectedIndexChanged);
			this.cmbPatient.TextChanged += new EventHandler(this.cmbPatient_TextChanged);
			this.cmbPatient.KeyDown += new KeyEventHandler(this.cmbPatient_KeyDown);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(11, 69);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Patient:";
			this.cmbCashVendor.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbCashVendor.FormattingEnabled = true;
			this.cmbCashVendor.Location = new Point(134, 34);
			this.cmbCashVendor.Name = "cmbCashVendor";
			this.cmbCashVendor.Size = new System.Drawing.Size(140, 21);
			this.cmbCashVendor.TabIndex = 2;
			this.cmbCashVendor.SelectedIndexChanged += new EventHandler(this.cmbCashVendor_SelectedIndexChanged);
			this.cmbCashVendor.KeyDown += new KeyEventHandler(this.cmbCashVendor_KeyDown);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(11, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Cash/Party Account:";
			this.txtVoucherNo.BackColor = Color.WhiteSmoke;
			this.txtVoucherNo.Location = new Point(134, 8);
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.ReadOnly = true;
			this.txtVoucherNo.Size = new System.Drawing.Size(140, 20);
			this.txtVoucherNo.TabIndex = 0;
			this.txtVoucherNo.TabStop = false;
			this.txtVoucherNo.KeyDown += new KeyEventHandler(this.txtVoucherNo_KeyDown);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(11, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Voucher No:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(776, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Sales Invoice";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(776, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 553);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(776, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(776, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(777, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 554);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 554);
			this.panel2.TabIndex = 0;
			this.lblTotalNew.AutoSize = true;
			this.lblTotalNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTotalNew.Location = new Point(286, 352);
			this.lblTotalNew.Name = "lblTotalNew";
			this.lblTotalNew.Size = new System.Drawing.Size(32, 13);
			this.lblTotalNew.TabIndex = 36456465;
			this.lblTotalNew.Text = "0.00";
			this.lblTotalNew.Visible = false;
			this.dgvSalesInvoice.AllowUserToDeleteRows = false;
			this.dgvSalesInvoice.AllowUserToResizeColumns = false;
			this.dgvSalesInvoice.AllowUserToResizeRows = false;
			this.dgvSalesInvoice.BackgroundColor = Color.White;
			this.dgvSalesInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvSalesInvoice.Columns;
			DataGridViewColumn[] column2 = new DataGridViewColumn[] { this.Column2, this.Column1, this.cmbProduct, this.cmbBatch, this.Column4, this.Column5, this.Column6, this.Column7, this.Column8, this.Column9, this.Column10, this.Column11, this.Column12, this.Column13, this.Column14, this.Column15, this.Column16, this.Column17, this.Column18, this.Column19 };
			columns.AddRange(column2);
			this.dgvSalesInvoice.GridColor = Color.WhiteSmoke;
			this.dgvSalesInvoice.Location = new Point(14, 132);
			this.dgvSalesInvoice.Name = "dgvSalesInvoice";
			this.dgvSalesInvoice.RowHeadersVisible = false;
			this.dgvSalesInvoice.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvSalesInvoice.Size = new System.Drawing.Size(747, 135);
			this.dgvSalesInvoice.TabIndex = 7;
			this.dgvSalesInvoice.Enter += new EventHandler(this.dgvPurchaseInvoice_Enter);
			this.dgvSalesInvoice.CellLeave += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellLeave);
			this.dgvSalesInvoice.KeyDown += new KeyEventHandler(this.dgvPurchaseInvoice_KeyDown);
			this.dgvSalesInvoice.CellClick += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellClick);
			this.dgvSalesInvoice.RowEnter += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_RowEnter);
			this.dgvSalesInvoice.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvSalesInvoice_RowsAdded);
			this.dgvSalesInvoice.Leave += new EventHandler(this.dgvPurchaseInvoice_Leave);
			this.dgvSalesInvoice.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvPurchaseInvoice_CellValidating);
			this.dgvSalesInvoice.CurrentCellDirtyStateChanged += new EventHandler(this.dgvPurchaseInvoice_CurrentCellDirtyStateChanged);
			this.dgvSalesInvoice.CellEndEdit += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellEndEdit);
			this.dgvSalesInvoice.CellValueChanged += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellValueChanged);
			this.dgvSalesInvoice.Scroll += new ScrollEventHandler(this.dgvSalesInvoice_Scroll);
			this.dgvSalesInvoice.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvPurchaseInvoice_EditingControlShowing);
			this.dgvSalesInvoice.KeyUp += new KeyEventHandler(this.dgvSalesInvoice_KeyUp);
			this.dgvSalesInvoice.CellEnter += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellEnter);
			this.dgvSalesInvoice.KeyPress += new KeyPressEventHandler(this.dgvSalesInvoice_KeyPress);
			this.Column2.HeaderText = "Instant Sale";
			this.Column2.Name = "Column2";
			this.Column2.Resizable = DataGridViewTriState.True;
			this.Column1.HeaderText = "Product Code";
			this.Column1.Name = "Column1";
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.Width = 150;
			this.cmbProduct.HeaderText = "Product Name";
			this.cmbProduct.Name = "cmbProduct";
			this.cmbProduct.Resizable = DataGridViewTriState.False;
			this.cmbProduct.Width = 150;
			this.cmbBatch.HeaderText = "Batch";
			this.cmbBatch.Name = "cmbBatch";
			this.cmbBatch.Resizable = DataGridViewTriState.False;
			this.cmbBatch.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.cmbBatch.Width = 150;
			this.Column4.HeaderText = "Expiry Date";
			this.Column4.Name = "Column4";
			this.Column4.Resizable = DataGridViewTriState.False;
			this.Column5.HeaderText = "Purchase Rate";
			this.Column5.MaxInputLength = 7;
			this.Column5.Name = "Column5";
			this.Column5.Resizable = DataGridViewTriState.False;
			this.Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column5.Visible = false;
			this.Column6.HeaderText = "Sales Rate";
			this.Column6.MaxInputLength = 7;
			this.Column6.Name = "Column6";
			this.Column6.Resizable = DataGridViewTriState.False;
			this.Column6.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column7.HeaderText = "MRP";
			this.Column7.MaxInputLength = 7;
			this.Column7.Name = "Column7";
			this.Column7.Resizable = DataGridViewTriState.False;
			this.Column7.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column8.HeaderText = "Manufacture";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Resizable = DataGridViewTriState.False;
			this.Column8.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column9.HeaderText = "Qty";
			this.Column9.MaxInputLength = 6;
			this.Column9.Name = "Column9";
			this.Column9.Resizable = DataGridViewTriState.False;
			this.Column9.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column10.HeaderText = "Free";
			this.Column10.MaxInputLength = 6;
			this.Column10.Name = "Column10";
			this.Column10.Resizable = DataGridViewTriState.False;
			this.Column10.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column11.HeaderText = "Unit";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			this.Column11.Resizable = DataGridViewTriState.False;
			this.Column11.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column12.HeaderText = "Gross Value";
			this.Column12.Name = "Column12";
			this.Column12.ReadOnly = true;
			this.Column12.Resizable = DataGridViewTriState.False;
			this.Column12.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column13.HeaderText = "Discount %";
			this.Column13.MaxInputLength = 4;
			this.Column13.Name = "Column13";
			this.Column13.Resizable = DataGridViewTriState.False;
			this.Column13.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column14.HeaderText = "Net Value";
			this.Column14.Name = "Column14";
			this.Column14.ReadOnly = true;
			this.Column14.Resizable = DataGridViewTriState.False;
			this.Column14.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column15.HeaderText = "Tax Type";
			this.Column15.Items.AddRange(new object[] { "Included", "Excluded" });
			this.Column15.Name = "Column15";
			this.Column15.Resizable = DataGridViewTriState.False;
			this.Column16.HeaderText = "Tax %";
			this.Column16.MaxInputLength = 4;
			this.Column16.Name = "Column16";
			this.Column16.Resizable = DataGridViewTriState.False;
			this.Column16.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column17.HeaderText = "Tax Amount";
			this.Column17.Name = "Column17";
			this.Column17.ReadOnly = true;
			this.Column17.Resizable = DataGridViewTriState.False;
			this.Column17.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column18.HeaderText = "Amount";
			this.Column18.Name = "Column18";
			this.Column18.ReadOnly = true;
			this.Column18.Resizable = DataGridViewTriState.False;
			this.Column18.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column19.HeaderText = "SalesDetailsId";
			this.Column19.Name = "Column19";
			this.Column19.ReadOnly = true;
			this.Column19.Resizable = DataGridViewTriState.False;
			this.Column19.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column19.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(792, 568);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmSalesInvoice";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Sales Invoice";
			base.FormClosing += new FormClosingEventHandler(this.frmPurchaseInvoice_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmPurchaseInvoice_KeyDown);
			base.Load += new EventHandler(this.frmPurchaseInvoice_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.pbxSearch).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((ISupportInitialize)this.dgvSalesInvoice).EndInit();
			base.ResumeLayout(false);
		}

		private void lblTotalAmount_TextChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}

		private void lstbxBatch_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvSalesInvoice.CurrentRow != null)
				{
					if (this.rowIndex >= 0)
					{
						if (this.lstbxBatch.Text != "")
						{
							this.dgvSalesInvoice.Rows[this.rowIndex].Cells[3].Value = this.lstbxBatch.Text;
						}
						this.dgvSalesInvoice.Rows[this.rowIndex].Cells[3].Selected = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void lstbxBatch_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					if (this.dgvSalesInvoice.CurrentRow != null)
					{
						if (this.rowIndex >= 0)
						{
							if (this.lstbxBatch.Text != "")
							{
								this.dgvSalesInvoice.Rows[this.rowIndex].Cells[3].Value = this.lstbxBatch.Text;
							}
							this.lstbxBatch.Visible = false;
							this.dgvSalesInvoice.Focus();
							this.dgvSalesInvoice.Rows[this.rowIndex].Cells[3].Selected = true;
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

		private void panel8_Paint(object sender, PaintEventArgs e)
		{
		}

		private void pbxSearch_MouseHover(object sender, EventArgs e)
		{
			this.pbxSearch.Cursor = Cursors.Hand;
		}

		public void ReturnFromPopUp(DataTable dtbl)
		{
			base.Enabled = true;
			int count = this.dgvSalesInvoice.Rows.Count - 1;
			this.FillComboItem();
			ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
			ManufacturerSP manufacturerSP = new ManufacturerSP();
			UnitInfo unitInfo = new UnitInfo();
			UnitSP unitSP = new UnitSP();
			ProductInfo productInfo = new ProductInfo();
			foreach (DataRow row in dtbl.Rows)
			{
				bool flag = false;
				foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvSalesInvoice.Rows)
				{
					if ((dataGridViewRow.Cells[2].Value == null ? false : dataGridViewRow.Cells[3].Value != null))
					{
						if ((dataGridViewRow.Cells[2].Value.ToString() != row.ItemArray[0].ToString() ? false : dataGridViewRow.Cells[3].Value.ToString() == row.ItemArray[1].ToString()))
						{
							flag = true;
						}
					}
				}
				if (!flag)
				{
					this.dgvSalesInvoice.Rows.Add();
					this.dgvSalesInvoice.Rows[count].Cells[1].Value = row.ItemArray[0].ToString();
					this.dgvSalesInvoice.Rows[count].Cells[2].Value = row.ItemArray[0].ToString();
					this.FillBatchCombo(row.ItemArray[0].ToString());
					this.dgvSalesInvoice.Rows[count].Cells[3].Value = row.ItemArray[1].ToString();
					productInfo = this.productsp.ProductView(row.ItemArray[0].ToString());
					manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
					if (manufacturerInfo.ManufactureId != null)
					{
						this.dgvSalesInvoice.Rows[count].Cells[8].Value = manufacturerInfo.ManufactureName;
					}
					unitInfo = unitSP.UnitView(productInfo.UnitId);
					if (unitInfo.UnitName != null)
					{
						this.dgvSalesInvoice.Rows[count].Cells[11].Value = unitInfo.UnitName;
					}
					count++;
				}
			}
			this.dgvSalesInvoice.Focus();
		}
        public string GenerateInvoiceNumber()
        {
            string str = "";
            try
            {
                str = this.salesMasterSP.SalesMasterGetInnoiceMax();
                this.txtInvoice.Text = str;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return str;
        }
        public void SaveFunction()
        {
            try
            {
                string str = "";
                string text = "";
                if (this.txtInvoice.Text != "")
                {
                    if (this.isInEditMode)
                    {
                        text = this.txtInvoice.Text;
                        invoicedatainfo.InvoiceNo = text;
                    }
                    else
                    {
                        text = this.GenerateInvoiceNumber();
                        if (text != this.txtInvoice.Text)
                        {
                            MessageBox.Show(string.Concat("Invoice number changed from ", this.txtInvoice.Text, "to ", text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    this.txtInvoice.Text = text;
                    invoicedatainfo.InvoiceNo = txtInvoice.Text;
                    this.salesMasterInfo.SalesInvoiceNo = text;
                    str = this.CheckNegetiveStock();
                    if (this.cmbCashVendor.SelectedValue == null)
                    {
                        MessageBox.Show("Select cash account/vendor", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.cmbCashVendor.Focus();
                    }
                    else if (this.cmbCashVendor.Text == "")
                    {
                        MessageBox.Show("Select account ledger", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.cmbCashVendor.Focus();
                    }
                    else if (this.txtInvoice.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter invoice number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtInvoice.Focus();
                    }
                    else if (this.CheckExistName())
                    {
                        MessageBox.Show("Invoice number already exists", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtInvoice.Focus();
                        this.txtInvoice.SelectAll();
                    }
                    else if (!this.CheckGridNull())
                    {
                        MessageBox.Show("Incomplete Details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (this.dgvSalesInvoice.Rows.Count > 0)
                        {
                            this.dgvSalesInvoice.Focus();
                            this.dgvSalesInvoice.ClearSelection();
                            this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[0].Cells[0];
                            this.dgvSalesInvoice.Rows[0].Cells[0].Selected = true;
                        }
                    }
                    else if (this.CheckBatchNull())
                    {
                        MessageBox.Show("Incomplete Details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (this.dgvSalesInvoice.Rows.Count > 0)
                        {
                            this.dgvSalesInvoice.Focus();
                            this.dgvSalesInvoice.ClearSelection();
                            this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[0].Cells[0];
                            this.dgvSalesInvoice.Rows[0].Cells[0].Selected = true;
                        }
                    }
                    else if (this.CheckQuantityNull())
                    {
                        MessageBox.Show("Incomplete Details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (this.dgvSalesInvoice.Rows.Count > 0)
                        {
                            this.dgvSalesInvoice.Focus();
                            this.dgvSalesInvoice.ClearSelection();
                            this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[0].Cells[0];
                            this.dgvSalesInvoice.Rows[0].Cells[0].Selected = true;
                        }
                    }
                    else if (this.CheckOnSaveForExistenceOfProduct() >= 0)
                    {
                        int num = this.CheckOnSaveForExistenceOfProduct();
                        MessageBox.Show("Repeated product batch exists", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.dgvSalesInvoice.Focus();
                        if (this.dgvSalesInvoice.Rows.Count > 0)
                        {
                            this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[num].Cells[0];
                            this.dgvSalesInvoice.Rows[num].Selected = true;
                        }
                    }
                    else if (this.CheckBillDiscount())
                    {
                        MessageBox.Show("Bill discount cannot be greater than total amount", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtBillDiscount.Text = "0.00";
                        this.txtBillDiscount.Focus();
                    }
                    else if (this.CheckPaidAmount())
                    {
                        MessageBox.Show("Paid amount cannot be greater than grand total", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtPaidAmount.Text = "0.00";
                        this.txtPaidAmount.Focus();
                    }
                    else if (str == "Warn")
                    {
                        if (MessageBox.Show("Negative stock product exists,Do you want to continue?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.isSaved = true;
                            this.DeleteSelectedSalesDetailsId();
                            this.SaveToSalesMaster();
                            this.SaveReceipDetails();
                            this.SaveSalesLedgerPosting();
                            this.SaveToStockPosting();
                            if (!this.isInEditMode)
                            {
                                MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                if (this.chbxprint.Checked)
                                {
                                    ReadInvoice = false;
                                    Printing print = new Printing();
                                    print.Data = invoicedatainfo;
                                    if (this.chbxwarranty.Checked)
                                    {
                                        invoicedatainfo.Address = ConfigurationSettings.AppSettings["Wr_Address"].ToString();
                                        invoicedatainfo.Phone = ConfigurationSettings.AppSettings["Wr_Phone"].ToString();
                                        invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["Wr_CompanyName"].ToString();
                                        invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["Wr_Text"].ToString();
                                    }
                                    else
                                    {
                                        invoicedatainfo.Address = ConfigurationSettings.AppSettings["NoWr_Address"].ToString();
                                        invoicedatainfo.Phone = ConfigurationSettings.AppSettings["NoWr_Phone"].ToString();
                                        invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["NoWr_CompanyName"].ToString();
                                        invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["NoWr_Text"].ToString();
                                    }


                                    print.PrintReport();
                                    invoicedatainfo = new InvoiceDataInfo();
                                }
                                this.ClearFunction();
                            }
                            else
                            {
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                if (this.chbxprint.Checked)
                                {
                                    Printing print = new Printing();
                                    print.Data = invoicedatainfo;
                                    if (this.chbxwarranty.Checked)
                                    {
                                        invoicedatainfo.Address = ConfigurationSettings.AppSettings["Wr_Address"].ToString();
                                        invoicedatainfo.Phone = ConfigurationSettings.AppSettings["Wr_Phone"].ToString();
                                        invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["Wr_CompanyName"].ToString();
                                        invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["Wr_Text"].ToString();
                                    }
                                    else
                                    {
                                        invoicedatainfo.Address = ConfigurationSettings.AppSettings["NoWr_Address"].ToString();
                                        invoicedatainfo.Phone = ConfigurationSettings.AppSettings["NoWr_Phone"].ToString();
                                        invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["NoWr_CompanyName"].ToString();
                                        invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["NoWr_Text"].ToString();
                                    }

                                    print.PrintReport();
                                    invoicedatainfo = new InvoiceDataInfo();
                                }


                            }
                            base.Close();
                        }
                    }


                    else if (!(str == "Block"))
                    {
                        this.isSaved = true;
                        this.DeleteSelectedSalesDetailsId();
                        this.SaveToSalesMaster();
                        this.SaveReceipDetails();
                        this.SaveSalesLedgerPosting();
                        this.SaveToStockPosting();
                        if (!this.isInEditMode)
                        {
                            MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            if (this.chbxprint.Checked)
                            {
                                ReadInvoice = false;
                                Printing print = new Printing();
                                print.Data = invoicedatainfo;
                                if (this.chbxwarranty.Checked)
                                {
                                    invoicedatainfo.Address = ConfigurationSettings.AppSettings["Wr_Address"].ToString();
                                    invoicedatainfo.Phone = ConfigurationSettings.AppSettings["Wr_Phone"].ToString();
                                    invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["Wr_CompanyName"].ToString();
                                    invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["Wr_Text"].ToString();
                                }
                                else
                                {
                                    invoicedatainfo.Address = ConfigurationSettings.AppSettings["NoWr_Address"].ToString();
                                    invoicedatainfo.Phone = ConfigurationSettings.AppSettings["NoWr_Phone"].ToString();
                                    invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["NoWr_CompanyName"].ToString();
                                    invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["Nowr_Text"].ToString();
                                }


                                print.PrintReport();
                                invoicedatainfo = new InvoiceDataInfo();
                            }
                            this.ClearFunction();
                        }
                        else
                        {
                            MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            if (this.chbxprint.Checked)
                            {
                                ReadInvoice = false;
                                Printing print = new Printing();
                                print.Data = invoicedatainfo;
                                if (this.chbxwarranty.Checked)
                                {
                                    invoicedatainfo.Address = ConfigurationSettings.AppSettings["Wr_Address"].ToString();
                                    invoicedatainfo.Phone = ConfigurationSettings.AppSettings["Wr_Phone"].ToString();
                                    invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["Wr_CompanyName"].ToString();
                                    invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["Wr_Text"].ToString();
                                }
                                else
                                {
                                    invoicedatainfo.Address = ConfigurationSettings.AppSettings["NoWr_Address"].ToString();
                                    invoicedatainfo.Phone = ConfigurationSettings.AppSettings["NoWr_Phone"].ToString();
                                    invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["NoWr_CompanyName"].ToString();
                                    invoicedatainfo.WarrantyText = ConfigurationSettings.AppSettings["Nowr_Text"].ToString();
                                }


                                print.PrintReport();
                                invoicedatainfo = new InvoiceDataInfo();
                            }
                            base.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot continue ,due to negative stock products", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
		}

		public void SaveReceipDetails()
		{
			try
			{
				if (!this.isInEditMode)
				{
					if (this.isCreditSale)
					{
						if (this.txtPaidAmount.Text != "")
						{
							if (decimal.Parse(this.txtPaidAmount.Text) > new decimal(0))
							{
								if ((this.cmbCashVendor.SelectedValue == null ? false : this.txtPaidAmount.Text != ""))
								{
									ReceiptMasterInfo receiptMasterInfo = new ReceiptMasterInfo();
									ReceiptDetailsInfo receiptDetailsInfo = new ReceiptDetailsInfo();
									ReceiptMasterSP receiptMasterSP = new ReceiptMasterSP();
									ReceiptDetailsSP receiptDetailsSP = new ReceiptDetailsSP();
									if (this.cmbCashVendor.SelectedValue != null)
									{
										receiptMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
										receiptMasterInfo.LedgerId = "2";
										receiptMasterInfo.Description = this.txtDescription.Text;
										receiptMasterInfo.ReceiptMode = "By Cash";
										receiptDetailsInfo.ChequeDate = DateTime.Parse("01/01/1753");
										receiptDetailsInfo.ChequeNumber = "";
										receiptDetailsInfo.Amount = decimal.Parse(this.txtPaidAmount.Text);
										receiptDetailsInfo.VoucherNumber = "";
										receiptDetailsInfo.VoucherType = "";
										receiptDetailsInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
										receiptDetailsInfo.Description = this.txtDescription.Text;
										receiptMasterInfo.ReceiptMasterId = receiptMasterSP.ReceiptMasterGetMax();
										receiptDetailsInfo.ReceiptMasterId = receiptMasterInfo.ReceiptMasterId;
										receiptMasterSP.ReceiptMasterAdd(receiptMasterInfo);
										receiptDetailsSP.ReceiptDetailsAdd(receiptDetailsInfo);
										this.DoReceiptLedgerPosting(receiptMasterInfo.ReceiptMasterId);
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

		public void SaveSalesLedgerPosting()
		{
			try
			{
				LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo()
				{
					VoucherNumber = this.txtVoucherNo.Text,
					VoucherType = "Sales Invoice",
					Description = "By Sales",
					Date = DateTime.Parse(this.dtpDate.Text)
				};
				if (this.isInEditMode)
				{
					DataTable dataTable = this.ledgerpostingsp.LedgerPostingViewByVoucherTypeAndVoucherNumber(this.txtVoucherNo.Text, "Sales Invoice");
					if (dataTable.Rows.Count > 0)
					{
						ledgerPostingInfo.LedgerPostingId = dataTable.Rows[0][0].ToString();
						ledgerPostingInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
						ledgerPostingInfo.Credit = new decimal(0);
						ledgerPostingInfo.Debit = decimal.Parse(this.lblTotalNew.Text);
						this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
						ledgerPostingInfo.LedgerPostingId = dataTable.Rows[1][0].ToString();
						ledgerPostingInfo.LedgerId = "3";
						ledgerPostingInfo.Debit = new decimal(0);
						ledgerPostingInfo.Credit = decimal.Parse(this.lblTotalNew.Text);
						this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);


                    }
                    if (lblTotalAmount.Text != null)
                    {
                        invoicedatainfo.TotalAmount = decimal.Parse(lblTotalAmount.Text);
                    }
                  
                    if (txtBillDiscount.Text != null)
                    {
                        invoicedatainfo.BillDiscount = decimal.Parse(txtBillDiscount.Text);
                    }
                   
                    invoicedatainfo.GrandTotal = invoicedatainfo.TotalAmount - invoicedatainfo.BillDiscount;
                }
				else
				{
					ledgerPostingInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
					ledgerPostingInfo.Credit = new decimal(0);
					ledgerPostingInfo.Debit = decimal.Parse(this.lblTotalNew.Text);
                 //   invoicedatainfo.TotalAmount = ledgerPostingInfo.Debit;
                    this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
					ledgerPostingInfo.LedgerId = "3";
					ledgerPostingInfo.Debit = new decimal(0);
					ledgerPostingInfo.Credit = decimal.Parse(this.lblTotalNew.Text);
					this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
                    if (lblTotalAmount.Text != null)
                    {
                        invoicedatainfo.TotalAmount = decimal.Parse(lblTotalAmount.Text);
                    }

                    if (txtBillDiscount.Text != null)
                    {
                        invoicedatainfo.BillDiscount = decimal.Parse(txtBillDiscount.Text);
                    }
                    invoicedatainfo.GrandTotal = invoicedatainfo.TotalAmount - invoicedatainfo.BillDiscount;
                }
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void SaveToSalesMaster()
		{
			bool flag;
			bool flag1;
			try
			{
				string text = "";
				string str = "";
				string str1 = "";
				string str2 = "";
				SalesMasterSP salesMasterSP = new SalesMasterSP();
				SalesMasterInfo salesMasterInfo = new SalesMasterInfo();
				SalesDetailsInfo salesDetailsInfo = new SalesDetailsInfo();
				SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				ProductBatchInfo productBatchInfo1 = new ProductBatchInfo();
				DoctorInfo doctorInfo = new DoctorInfo();
				DoctorSP doctorSP = new DoctorSP();
				PatientSP patientSP = new PatientSP();
				PatientInfo patientInfo = new PatientInfo();
				SalesManInfo salesManInfo = new SalesManInfo();
				SalesManSP salesManSP = new SalesManSP();
				if ((!(this.txtVoucherNo.Text != "") || this.cmbCashVendor.SelectedValue == null ? false : this.txtInvoice.Text != ""))
				{
					if (this.isInEditMode)
					{
						text = this.txtVoucherNo.Text;
					}
					else
					{
						text = this.GetMaxofSalesMasterId();
						if (text != this.txtVoucherNo.Text)
						{
							MessageBox.Show(string.Concat("Voucher number changed from ", this.txtVoucherNo.Text, "to ", text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					this.txtVoucherNo.Text = text;
					salesMasterInfo.SalesMasterId = text;
					salesMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
					salesMasterInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
					salesMasterInfo.SalesInvoiceNo = this.txtInvoice.Text.Trim();
                    invoicedatainfo.InvoiceNo = this.txtInvoice.Text.Trim();
                    invoicedatainfo.SaleDate = salesMasterInfo.Date;
                    if (this.txtBillDiscount.Text.Trim() == "")
					{
						this.txtBillDiscount.Text = "0.00";
					}
					salesMasterInfo.BillDiscount = decimal.Parse(this.txtBillDiscount.Text);
                    invoicedatainfo.BillDiscount = salesMasterInfo.BillDiscount;
                   // invoicedatainfo.invoiceitem[0].BillDiscount= decimal.Parse(this.txtBillDiscount.Text);
                    salesMasterInfo.Description = this.txtDescription.Text.Trim();
					if (this.cmbDoctor.SelectedValue != null)
					{
						if (this.cmbDoctor.Text.Trim() == "")
						{
							salesMasterInfo.DoctorId = "0";
						}
						salesMasterInfo.DoctorId = this.cmbDoctor.SelectedValue.ToString();
					}
					else if (!(this.cmbDoctor.Text.Trim() != ""))
					{
						salesMasterInfo.DoctorId = "0";
					}
					else
					{
						doctorInfo.DoctorName = this.cmbDoctor.Text;
						doctorInfo.Description = "From Sales";
						salesMasterInfo.DoctorId = doctorSP.DoctorAdd(doctorInfo);
					}
					if (this.cmbPatient.SelectedValue != null)
					{
						salesMasterInfo.PatientId = this.cmbPatient.SelectedValue.ToString();
                        invoicedatainfo.CustomerCode = salesMasterInfo.PatientId;
                        invoicedatainfo.CustomerName= this.cmbPatient.Text.ToString();

                    }
					else if (!(this.cmbPatient.Text.Trim() != ""))
					{
						salesMasterInfo.PatientId = "0";
					}
					else
					{
						patientInfo.Name = this.cmbPatient.Text;
						patientInfo.PhoneNo = "";
						patientInfo.MobileNo = "";
						patientInfo.Address = "";
						patientInfo.Description = "From Sales";
						patientInfo.DailyCustomerOrNot = false;
						salesMasterInfo.PatientId = str1;
					}
					salesMasterInfo.SalesManId = this.cmbSalesman.SelectedValue.ToString();
                    
                    invoicedatainfo.SaleMan = this.cmbSalesman.Text.ToString();
                    if (this.isInEditMode)
					{
						foreach (DataGridViewRow row in (IEnumerable)this.dgvSalesInvoice.Rows)
						{
							if (row.DefaultCellStyle.BackColor != Color.Cornsilk)
							{
								if (row.Cells[19].Value != null)
								{
									salesDetailsSP.SalesDetailsDelete(row.Cells[19].Value.ToString());
								}
							}
						}
					}
					foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvSalesInvoice.Rows)
					{
                        InvoiceItemsInfo itemData = new InvoiceItemsInfo();
                        if (dataGridViewRow.Cells[1].Value == null || dataGridViewRow.Cells[2].Value == null || dataGridViewRow.Cells[3].Value == null)
						{
							flag = true;
						}
						else
						{
							flag = (dataGridViewRow.Cells[9].Value != null ? false : dataGridViewRow.Cells[10].Value == null);
						}
						if (!flag)
						{
							if (!(dataGridViewRow.Cells[1].Value.ToString() != "") || !(dataGridViewRow.Cells[2].Value.ToString() != "") || !(dataGridViewRow.Cells[3].Value.ToString() != ""))
							{
								flag1 = true;
							}
							else
							{
								flag1 = (dataGridViewRow.Cells[9].Value.ToString() != "" ? false : !(dataGridViewRow.Cells[10].Value.ToString() != ""));
							}
							if (!flag1)
							{
								if (dataGridViewRow.Cells[3].Value != null)
								{
									if (dataGridViewRow.Cells[3].Value.ToString() != "")
									{
										productBatchInfo.ProductId = dataGridViewRow.Cells[2].Value.ToString();
                                        itemData.ProductId= dataGridViewRow.Cells[2].Value.ToString();
                                        itemData.ProductName = dataGridViewRow.Cells[2].FormattedValue.ToString();
                                        if (dataGridViewRow.Cells[3].Value == null)
										{
											productBatchInfo.BatchName = "";
                                            itemData.Batch = productBatchInfo.BatchName;
                                        }
										else if (!(dataGridViewRow.Cells[3].Value.ToString() == ""))
										{
											productBatchInfo.BatchName = dataGridViewRow.Cells[3].Value.ToString();
                                            itemData.Batch = productBatchInfo.BatchName;
                                        }
										else
										{
											productBatchInfo.BatchName = "";
                                            itemData.Batch = productBatchInfo.BatchName;
                                        }
										if (dataGridViewRow.Cells[4].Value == null)
										{
											productBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										else if (!(dataGridViewRow.Cells[4].Value.ToString() == ""))
										{
											productBatchInfo.ExpiryDate = DateTime.Parse(dataGridViewRow.Cells[4].Value.ToString());
											productBatchInfo.ExpiryDate = productBatchInfo.ExpiryDate.Date;
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										else
										{
											productBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										if (dataGridViewRow.Cells[3].Value.ToString() == "NA")
										{
											productBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										if (dataGridViewRow.Cells[5].Value == null)
										{
											productBatchInfo.PurchaseRate = new decimal(0);

										}
										else if (!(dataGridViewRow.Cells[5].Value.ToString() == ""))
										{
											productBatchInfo.PurchaseRate = decimal.Parse(dataGridViewRow.Cells[5].Value.ToString());
                                           
                                        }
										else
										{
											productBatchInfo.PurchaseRate = new decimal(0);
										}
										if (dataGridViewRow.Cells[6].Value == null)
										{
											productBatchInfo.SalesRate = new decimal(0);
                                            itemData.Rate = productBatchInfo.SalesRate;
                                        }
										else if (!(dataGridViewRow.Cells[6].Value.ToString() == ""))
										{
											productBatchInfo.SalesRate = decimal.Parse(dataGridViewRow.Cells[6].Value.ToString());
                                            itemData.Rate = productBatchInfo.SalesRate;
                                        }
										else
										{
											productBatchInfo.SalesRate = new decimal(0);
                                            itemData.Rate = productBatchInfo.SalesRate;
                                        }
										if (dataGridViewRow.Cells[7].Value == null)
										{
											productBatchInfo.MRP = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[7].Value.ToString() == ""))
										{
											productBatchInfo.MRP = decimal.Parse(dataGridViewRow.Cells[7].Value.ToString());
										}
										else
										{
											productBatchInfo.MRP = new decimal(0);
										}
										productBatchInfo.Description = "";
										str2 = "";
										string str3 = dataGridViewRow.Cells[2].Value.ToString();
										string str4 = dataGridViewRow.Cells[3].Value.ToString();
										DataTable dataTable = new DataTable();
										dataTable = productBatchSP.ProductBatchViewByProductAndBatchName(str3, str4);
										if (dataTable.Rows.Count > 0)
										{
											str2 = dataTable.Rows[0].ItemArray[0].ToString();
										}
										if (!(str2 != ""))
										{
											str = productBatchSP.ProductBatchAdd(productBatchInfo);
										}
										else
										{
											productBatchInfo1 = productBatchSP.ProductBatchView(str2);
											if (productBatchInfo1.ProductBatchId == null)
											{
												str = productBatchSP.ProductBatchAdd(productBatchInfo);
											}
											else if ((str2 != productBatchInfo1.ProductBatchId ? true : !(dataGridViewRow.Cells[2].Value.ToString() == productBatchInfo1.ProductId)))
											{
												str = productBatchSP.ProductBatchAdd(productBatchInfo);
											}
											else
											{
												productBatchInfo.ProductBatchId = str2;
												if (dataGridViewRow.Cells[5].Value == null)
												{
													productBatchInfo.PurchaseRate = productBatchInfo1.PurchaseRate;
												}
												else if (dataGridViewRow.Cells[5].Value.ToString() == "")
												{
													productBatchInfo.PurchaseRate = productBatchInfo1.PurchaseRate;
												}
												else if (!(decimal.Parse(dataGridViewRow.Cells[5].Value.ToString()) == new decimal(0)))
												{
													productBatchInfo.PurchaseRate = decimal.Parse(dataGridViewRow.Cells[5].Value.ToString());
												}
												else
												{
													productBatchInfo.PurchaseRate = productBatchInfo1.PurchaseRate;
												}
												if (dataGridViewRow.Cells[6].Value == null)
												{
													productBatchInfo.SalesRate = productBatchInfo1.SalesRate;
												}
												else if (dataGridViewRow.Cells[6].Value.ToString() == "")
												{
													productBatchInfo.SalesRate = productBatchInfo1.SalesRate;
												}
												else if (!(decimal.Parse(dataGridViewRow.Cells[6].Value.ToString()) == new decimal(0)))
												{
													productBatchInfo.SalesRate = decimal.Parse(dataGridViewRow.Cells[6].Value.ToString());
												}
												else
												{
													productBatchInfo.SalesRate = productBatchInfo1.SalesRate;
												}
												if (dataGridViewRow.Cells[7].Value == null)
												{
													productBatchInfo.MRP = productBatchInfo1.MRP;
												}
												else if (dataGridViewRow.Cells[7].Value.ToString() == "")
												{
													productBatchInfo.MRP = productBatchInfo1.MRP;
												}
												else if (!(decimal.Parse(dataGridViewRow.Cells[7].Value.ToString()) == new decimal(0)))
												{
													productBatchInfo.MRP = decimal.Parse(dataGridViewRow.Cells[7].Value.ToString());
												}
												else
												{
													productBatchInfo.MRP = productBatchInfo1.MRP;
												}
												productBatchSP.ProductBatchEdit(productBatchInfo);
												str = str2;
											}
										}
										salesDetailsInfo.SalesMasterId = text;
										salesDetailsInfo.ProductBatchId = str;
										if (dataGridViewRow.Cells[6].Value == null)
										{
											salesDetailsInfo.Rate = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[6].Value.ToString() == ""))
										{
											salesDetailsInfo.Rate = decimal.Parse(dataGridViewRow.Cells[6].Value.ToString());
										}
										else
										{
											salesDetailsInfo.Rate = new decimal(0);
										}
										if (dataGridViewRow.Cells[7].Value == null)
										{
											salesDetailsInfo.MRP = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[7].Value.ToString() == ""))
										{
											salesDetailsInfo.MRP = decimal.Parse(dataGridViewRow.Cells[7].Value.ToString());
										}
										else
										{
											salesDetailsInfo.MRP = new decimal(0);
										}
										if (dataGridViewRow.Cells[13].Value == null)
										{
											salesDetailsInfo.Discount = 0f;
                                            itemData.BillDiscount =Convert.ToDecimal(salesDetailsInfo.Discount.ToString());
                                        }
										else if (!(dataGridViewRow.Cells[13].Value.ToString() == ""))
										{
											salesDetailsInfo.Discount = float.Parse(dataGridViewRow.Cells[13].Value.ToString());
                                            itemData.BillDiscount = Convert.ToDecimal(salesDetailsInfo.Discount.ToString());
                                        }
										else
										{
											salesDetailsInfo.Discount = 0f;
                                            itemData.BillDiscount = Convert.ToDecimal(salesDetailsInfo.Discount.ToString());
                                        }
										if (dataGridViewRow.Cells[9].Value == null)
										{
											salesDetailsInfo.Qty = new decimal(0);
                                            itemData.Quantity = salesDetailsInfo.Qty.ToString();
                                        }
										else if (!(dataGridViewRow.Cells[9].Value.ToString() == ""))
										{
											salesDetailsInfo.Qty = decimal.Parse(dataGridViewRow.Cells[9].Value.ToString());
                                            itemData.Quantity = salesDetailsInfo.Qty.ToString();
                                        }
										else
										{
											salesDetailsInfo.Qty = new decimal(0);
                                            itemData.Quantity = salesDetailsInfo.Qty.ToString();
                                        }
										if (dataGridViewRow.Cells[10].Value == null)
										{
											salesDetailsInfo.FreeQty = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[10].Value.ToString() == ""))
										{
											salesDetailsInfo.FreeQty = decimal.Parse(dataGridViewRow.Cells[10].Value.ToString());
										}
										else
										{
											salesDetailsInfo.FreeQty = new decimal(0);
										}
										if (dataGridViewRow.Cells[15].Value == null)
										{
											salesDetailsInfo.TaxIncludedOrNot = false;
											salesDetailsInfo.TaxPercentage = 0f;
										}
										else if (!(dataGridViewRow.Cells[15].Value.ToString() == ""))
										{
											if (!(dataGridViewRow.Cells[15].Value.ToString() == "Excluded"))
											{
												salesDetailsInfo.TaxIncludedOrNot = false;
											}
											else
											{
												salesDetailsInfo.TaxIncludedOrNot = true;
											}
											if (dataGridViewRow.Cells[16].Value == null)
											{
												salesDetailsInfo.TaxPercentage = 0f;
											}
											else if (!(dataGridViewRow.Cells[16].Value.ToString() == ""))
											{
												salesDetailsInfo.TaxPercentage = float.Parse(dataGridViewRow.Cells[16].Value.ToString());
											}
											else
											{
												salesDetailsInfo.TaxPercentage = 0f;
											}
										}
										else
										{
											salesDetailsInfo.TaxIncludedOrNot = false;
											salesDetailsInfo.TaxPercentage = 0f;
										}
                                        itemData.TotalAmount = decimal.Parse(dataGridViewRow.Cells[14].Value.ToString());
                                        itemData.GrossAmount = decimal.Parse(dataGridViewRow.Cells[12].Value.ToString());
                                        invoicedatainfo.invoiceitem.Add(itemData);
                                        salesDetailsInfo.DirectSaleOrNot = Convert.ToBoolean(this.dgvSalesInvoice[dataGridViewRow.Cells[0].ColumnIndex, dataGridViewRow.Cells[0].RowIndex].Value);
										salesDetailsInfo.Description = dataGridViewRow.Cells[18].Value.ToString();
										if (!(dataGridViewRow.DefaultCellStyle.BackColor == Color.Cornsilk))
										{
											salesDetailsSP.SalesDetailsAdd(salesDetailsInfo);
										}
										else
										{
											salesDetailsInfo.SalesDetailsId = dataGridViewRow.Cells[19].Value.ToString();
											salesDetailsSP.SalesDetailsEdit(salesDetailsInfo);
										}
									}
								}
							}
						}
					}
					if (this.isInEditMode)
					{
						salesMasterSP.SalesMasterEdit(salesMasterInfo);
					}
					else
					{
						salesMasterSP.SalesMasterAdd(salesMasterInfo);
					}
				}
              
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void SaveToStockPosting()
		{
			try
			{
				decimal num = new decimal(0, 0, 0, false, 2);
				StockPostingInfo stockPostingInfo = new StockPostingInfo();
				StockPostingSP stockPostingSP = new StockPostingSP();
				SalesDetailsSP salesDetailsSP = new SalesDetailsSP();
				DataTable dataTable = new DataTable();
				if (this.txtVoucherNo.Text != "")
				{
					if (this.isInEditMode)
					{
						stockPostingSP.StockPostingDeleteByVoucherAndType(this.txtVoucherNo.Text, "Sales Invoice");
						stockPostingSP.StockPostingDeleteByVoucherAndType(this.txtVoucherNo.Text, "Instant Sale");
					}
					dataTable = salesDetailsSP.SalesDetailsViewAllByMasterId(this.txtVoucherNo.Text);
					foreach (DataRow row in dataTable.Rows)
					{
						stockPostingInfo.VoucherNumber = row.ItemArray[1].ToString();
						stockPostingInfo.ProductBatchId = row.ItemArray[2].ToString();
						num = decimal.Parse(row.ItemArray[5].ToString()) + decimal.Parse(row.ItemArray[6].ToString());
						stockPostingInfo.InwardQuantity = new decimal(0);
						stockPostingInfo.OutwardQuantity = num;
						if (!(row.ItemArray[8].ToString() == "True"))
						{
							stockPostingInfo.VoucherType = "Sales Invoice";
						}
						else
						{
							stockPostingInfo.VoucherType = "Instant Sale";
						}
						stockPostingInfo.Description = "";
						stockPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
						stockPostingSP.StockPostingAdd(stockPostingInfo);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void TextBoxCellEditControlKeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((this.dgvSalesInvoice.CurrentCell.ColumnIndex == 5 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 6 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 7 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 9 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 10 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 13 || this.dgvSalesInvoice.CurrentCell.ColumnIndex == 14 ? true : this.dgvSalesInvoice.CurrentCell.ColumnIndex == 16))
				{
					if (!char.IsNumber(e.KeyChar))
					{
						if ((e.KeyChar == '\b' ? false : e.KeyChar != '.'))
						{
							e.Handled = true;
						}
						else
						{
							e.Handled = false;
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

		private void txtBillDiscount_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtBillDiscount.Text) == new decimal(0))
				{
					this.txtBillDiscount.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtBillDiscount.Text = "";
			}
		}

		private void txtBillDiscount_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtBillDiscount.Text == "" ? true : this.txtBillDiscount.SelectionStart == 0))
					{
						this.txtDescription.Focus();
						this.txtDescription.SelectionStart = 0;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtBillDiscount_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!char.IsNumber(e.KeyChar))
				{
					if ((e.KeyChar == '\b' ? false : e.KeyChar != '.'))
					{
						e.Handled = true;
					}
					else if (e.KeyChar != '.')
					{
						e.Handled = false;
					}
					else
					{
						string text = this.txtBillDiscount.Text;
						for (int i = 0; i < text.Length; i++)
						{
							if (text[i] == '.')
							{
								e.Handled = true;
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

		private void txtBillDiscount_Leave(object sender, EventArgs e)
		{
			try
			{
				this.CalculateTotal();
			}
			catch
			{
				this.txtBillDiscount.Text = "0.00";
			}
		}

		private void txtDescription_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtDescription.Text = this.txtDescription.Text.Trim();
				if (!(this.txtDescription.Text == ""))
				{
					this.txtDescription.SelectionStart = this.txtDescription.Text.Length;
					this.txtDescription.Focus();
				}
				else
				{
					this.txtDescription.SelectionStart = 0;
					this.txtDescription.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtDescription_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtDescription.Text == "" ? true : this.txtDescription.SelectionStart == 0))
					{
						if (this.dgvSalesInvoice.Rows.Count > 0)
						{
							int count = 0;
							count = this.dgvSalesInvoice.Rows.Count;
							this.dgvSalesInvoice.Focus();
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

		private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.inDescriptionCount = 0;
				}
				else
				{
					frmSalesInvoice _frmSalesInvoice = this;
					_frmSalesInvoice.inDescriptionCount = _frmSalesInvoice.inDescriptionCount + 1;
					if (this.inDescriptionCount == 2)
					{
						this.inDescriptionCount = 0;
						this.txtBillDiscount.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtDueDays_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
				if (e.KeyCode == Keys.Return)
				{
					if (this.dgvSalesInvoice.Rows.Count > 0)
					{
						this.dgvSalesInvoice.ClearSelection();
						this.dgvSalesInvoice.CurrentCell = this.dgvSalesInvoice.Rows[0].Cells[0];
						this.dgvSalesInvoice.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtDueDays_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode != Keys.Return ? false : this.txtInvoice.Text.Trim() != ""))
				{
					SendKeys.Send("{TAB}");
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtInvoice.Text == "" ? true : this.txtInvoice.SelectionStart == 0))
					{
						this.cmbCashVendor.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtInvoice_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.cmbCashVendor.Focused || this.dtpDate.Focused || this.txtVoucherNo.Focused || this.isFormClose || this.btnNewledgers.Focused || this.btnClear.Focused ? false : !this.btnClose.Focused))
					{
						if (this.txtInvoice.Text.Trim() == "")
						{
							this.txtInvoice.Focus();
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

		private void txtPaidAmount_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtPaidAmount.Text == "" ? true : this.txtPaidAmount.SelectionStart == 0))
					{
						this.txtBillDiscount.Focus();
						this.txtBillDiscount.SelectionStart = 0;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!char.IsNumber(e.KeyChar))
				{
					if ((e.KeyChar == '\b' ? false : e.KeyChar != '.'))
					{
						e.Handled = true;
					}
					else if (e.KeyChar != '.')
					{
						e.Handled = false;
					}
					else
					{
						string text = this.txtBillDiscount.Text;
						for (int i = 0; i < text.Length; i++)
						{
							if (text[i] == '.')
							{
								e.Handled = true;
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

		private void txtPaidAmount_Leave(object sender, EventArgs e)
		{
			try
			{
				this.CalculateGrandTotal();
			}
			catch
			{
				this.txtPaidAmount.Text = "0.00";
			}
		}

		private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
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