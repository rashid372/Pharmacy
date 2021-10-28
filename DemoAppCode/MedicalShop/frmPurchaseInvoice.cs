using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmPurchaseInvoice : Form
	{
		private int rowIndex;

		private int columnIndex;

		private bool isSaved = false;

		private bool isRepeated = false;

		private ProductSP productsp = new ProductSP();

		private LedgerPostingSP ledgerpostingsp = new LedgerPostingSP();

		private frmPurchaseRegister frmRegister;

		private DataTable dtblRemovedPurchaseId = new DataTable();

		private bool isBychequeTextNull = false;

		private bool isInEditMode = false;

		private bool isFromPurchaseregister = false;

		private bool isFormClose = false;

		private bool isCellEdit = false;

		private bool isCellValueChanged = false;

		private string strDefaultCurrency = "";

		private int inDescriptionCount = 0;

		private bool isCreditPurchase = false;

		private int p = 0;

		private int j = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label lblBlnceAmount;

		private Label lblDueDays;

		private Button btnVendor;

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

		private TextBox txtDueDays;

		private ComboBox cmbCashVendor;

		private Label label15;

		private dgv.DataGridViewEnter dgvPurchaseInvoice;

		private Label label5;

		private TextBox txtDescription;

		private GroupBox groupBox2;

		private Label label9;

		private Label label10;

		private DateTimePicker dtpChequeDate;

		private TextBox txtChequeNo;

		private ComboBox cmbCashBankAccount;

		private ComboBox cmbPaymentMode;

		private Label lblLedger;

		private Label label6;

		private Label label11;

		private TextBox txtPendingAmount;

		private TextBox txtpaidAmount;

		private Label label16;

		private Label lblRoundedGrandTotal;

		private Label lblRoundedGrand;

		private Label lblGrandTotal;

		private Label lblGrand;

		private Label label22;

		private TextBox txtBillDiscount;

		private TextBox txtAdjustment;

		private Label label21;

		private Label lblTotalAmount;

		private Label lblTot;
        private Label lblRows;
        private Label lblCountRows;
        private Label lblTaxAmount;

		private Label lblTax;

		private CheckBox chbxprint;

		private Label lblVendor;

		private ComboBox cmbVendor;

		private Button btnRemove;

		private Label label7;

		private Label label4;

		private TabControl tcReminder;

		private TabPage tpPurchase;

		private TabPage tpPayment;

		private Button btnPaymentBtn;

		private ListBox lstbxBatch;

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
        private InvoiceDataInfo invoicedatainfo;
        private PrintingPurchaseInvoice printprcinvoice = new PrintingPurchaseInvoice();
        private PurchaseMasterSP purchasemaster = new PurchaseMasterSP();
        private PurchaseMasterInfo purchasemasterinfo = new PurchaseMasterInfo();

        public frmPurchaseInvoice()
		{
            this.invoicedatainfo = new InvoiceDataInfo();
            this.InitializeComponent();
           
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
		}

		private void btnPaymentBtn_Click(object sender, EventArgs e)
		{
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvPurchaseInvoice.CurrentRow != null)
				{
					if (!(this.dgvPurchaseInvoice.Rows[this.dgvPurchaseInvoice.CurrentRow.Index].DefaultCellStyle.BackColor != Color.Cornsilk))
					{
						MessageBox.Show("Can't remove returned product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						try
						{
							string str = "";
							if (this.dgvPurchaseInvoice.Rows.Count != 1)
							{
								str = (this.dgvPurchaseInvoice.Rows[this.dgvPurchaseInvoice.CurrentRow.Index].Cells[18].Value == null ? "" : this.dgvPurchaseInvoice.Rows[this.dgvPurchaseInvoice.CurrentRow.Index].Cells[18].Value.ToString());
								this.dgvPurchaseInvoice.Rows.RemoveAt(this.dgvPurchaseInvoice.CurrentRow.Index);
							}
							else
							{
								str = (this.dgvPurchaseInvoice.Rows[0].Cells[18].Value == null ? "" : this.dgvPurchaseInvoice.Rows[0].Cells[18].Value.ToString());
								this.dgvPurchaseInvoice.Rows.Clear();
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
						if (this.dgvPurchaseInvoice.Rows.Count > 0)
						{
							this.dgvPurchaseInvoice.Focus();
							this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[0].Cells[0];
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
        public string GenerateInvoiceNumber()
        {
            string str = "";
            try
            {
                str = this.purchasemaster.PurchaseMasterInvoiceMax().ToString();
                this.txtInvoice.Text = str;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return str;
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
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnSave_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					this.txtDescription.Focus();
					this.txtDescription.SelectionStart = 0;
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
					item.CallThisFormPurchase(this);
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
					_frmPopup.CallThisFormPurchase(this);
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
				decimal num2 = new decimal(0, 0, 0, false, 2);
				decimal num3 = new decimal(0, 0, 0, false, 2);
				if (this.txtAdjustment.Text == "")
				{
					this.txtAdjustment.Text = num.ToString();
				}
				if (this.txtBillDiscount.Text == "")
				{
					this.txtBillDiscount.Text = num1.ToString();
				}
				num2 = (decimal.Parse(this.lblTotalAmount.Text) - decimal.Parse(this.txtBillDiscount.Text)) + decimal.Parse(this.txtAdjustment.Text);
				this.lblGrandTotal.Text = num2.ToString();
				if (this.isCreditPurchase)
				{
					if (this.txtpaidAmount.Text != "")
					{
						if (decimal.Parse(this.txtpaidAmount.Text) != new decimal(0))
						{
							decimal num4 = decimal.Parse(this.txtpaidAmount.Text);
							decimal num5 = decimal.Parse(this.lblGrandTotal.Text);
							decimal num6 = num5 - num4;
							if (!(num6 >= new decimal(0)))
							{
								this.txtPendingAmount.Text = "0.00";
							}
							else
							{
								this.txtPendingAmount.Text = num6.ToString();
							}
						}
					}
				}
				num3 = Math.Round(num2, 2);
				this.lblRoundedGrandTotal.Text = string.Concat(num3.ToString(), this.strDefaultCurrency);
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
				if (this.dgvPurchaseInvoice.Rows.Count > 0)
				{
					decimal num = new decimal(0);
					decimal num1 = new decimal(0);
					decimal num2 = new decimal(0, 0, 0, false, 2);
					decimal num3 = new decimal(0, 0, 0, false, 2);
					decimal num4 = new decimal(0, 0, 0, false, 2);
					decimal num5 = new decimal(0, 0, 0, false, 2);
					foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseInvoice.Rows)
					{
						if (row.Cells[1].Value != null)
						{
							if (row.Cells[1].Value.ToString() != "")
							{
								if (row.Cells[16].Value != null)
								{
									if (row.Cells[16].Value.ToString() != "")
									{
										num = num + decimal.Parse(row.Cells[16].Value.ToString());
									}
								}
								if (row.Cells[17].Value != null)
								{
									if (row.Cells[17].Value.ToString() != "")
									{
										num1 = num1 + decimal.Parse(row.Cells[17].Value.ToString());
									}
								}
							}
						}
					}
					this.lblTaxAmount.Text = num.ToString();
					this.lblTotalAmount.Text = num1.ToString();
					if (this.txtAdjustment.Text == "")
					{
						this.txtAdjustment.Text = num2.ToString();
					}
					if (this.txtBillDiscount.Text == "")
					{
						this.txtBillDiscount.Text = num3.ToString();
					}
					num4 = (decimal.Parse(this.lblTotalAmount.Text) - decimal.Parse(this.txtBillDiscount.Text)) + decimal.Parse(this.txtAdjustment.Text);
					this.lblGrandTotal.Text = num4.ToString();
					num5 = Math.Round(num4, 2);
					this.lblRoundedGrandTotal.Text = string.Concat(num5.ToString(), this.strDefaultCurrency);
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

		public bool CheckBatchNull()
		{
			bool flag = false;
			try
			{
				foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseInvoice.Rows)
				{
					if ((row.Cells[1].Value == null ? false : row.Cells[2].Value != null))
					{
						if ((row.Cells[1].Value.ToString() == "" ? false : row.Cells[2].Value.ToString() != ""))
						{
							if (!(row.Cells[2].Value.ToString() == "NA"))
							{
								if (row.Cells[3].Value == null)
								{
									flag = true;
									break;
								}
								else if (row.Cells[3].Value.ToString() == "")
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
			PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
			PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
			bool flag = true;
			try
			{
				if (this.txtInvoice.Text.Trim() != "")
				{
					string str = this.txtInvoice.Text.Trim();
					if (!this.isInEditMode)
					{
						flag = purchaseMasterSP.CheckExistanceOfPurchaseInvoice(str);
					}
					else if (this.txtVoucherNo.Text != "")
					{
						flag = (!(purchaseMasterSP.PurchaseMasterView(this.txtVoucherNo.Text).PurchaseInvoiceNo.ToLower() != str.ToLower()) ? false : purchaseMasterSP.CheckExistanceOfPurchaseInvoice(str));
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
				if (this.dgvPurchaseInvoice.Rows.Count > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseInvoice.Rows)
					{
						if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
						{
							flag = true;
						}
						else
						{
							flag = (row.Cells[8].Value != null ? false : row.Cells[9].Value == null);
						}
						if (!flag)
						{
							if ((row.Cells[8].Value == null ? true : row.Cells[8].Value.ToString() == ""))
							{
								row.Cells[8].Value = 0;
							}
							if ((row.Cells[9].Value == null ? true : row.Cells[9].Value.ToString() == ""))
							{
								row.Cells[9].Value = 0;
							}
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") ? false : row.Cells[2].Value.ToString() != ""))
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

		public int CheckOnSaveForExistenceOfProduct()
		{
			bool flag = false;
			int num = 0;
			for (int i = 0; i < this.dgvPurchaseInvoice.Rows.Count; i++)
			{
				if ((this.dgvPurchaseInvoice.Rows[i].Cells[1].Value == null ? false : this.dgvPurchaseInvoice.Rows[i].Cells[2].Value != null))
				{
					if ((this.dgvPurchaseInvoice.Rows[i].Cells[1].Value.ToString() == "" ? false : this.dgvPurchaseInvoice.Rows[i].Cells[2].Value.ToString() != ""))
					{
						for (int j = 0; j < this.dgvPurchaseInvoice.Rows.Count; j++)
						{
							if ((this.dgvPurchaseInvoice.Rows[j].Cells[1].Value == null ? false : this.dgvPurchaseInvoice.Rows[j].Cells[2].Value != null))
							{
								if ((this.dgvPurchaseInvoice.Rows[j].Cells[1].Value.ToString() == "" ? false : this.dgvPurchaseInvoice.Rows[j].Cells[2].Value.ToString() != ""))
								{
									if ((this.dgvPurchaseInvoice.Rows[i].Cells[1].Value.ToString() != this.dgvPurchaseInvoice.Rows[j].Cells[1].Value.ToString() ? false : this.dgvPurchaseInvoice.Rows[i].Cells[2].Value.ToString() == this.dgvPurchaseInvoice.Rows[j].Cells[2].Value.ToString()))
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
				if ((this.txtpaidAmount.Text == "" ? false : this.isCreditPurchase))
				{
					flag = (!(decimal.Parse(this.txtpaidAmount.Text) > decimal.Parse(this.lblGrandTotal.Text)) ? false : true);
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
				if (this.dgvPurchaseInvoice.RowCount > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseInvoice.Rows)
					{
						if (this.dgvPurchaseInvoice.CurrentRow.Index != row.Index)
						{
							if ((row.Cells[1].Value == null ? false : row.Cells[2].Value != null))
							{
								if ((row.Cells[1].Value.ToString() == "" ? false : row.Cells[2].Value.ToString() != ""))
								{
									if ((Id != row.Cells[1].Value.ToString() ? true : !(Batch == row.Cells[2].Value.ToString().ToLower().Trim())))
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
				foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseInvoice.Rows)
				{
					if (row.Cells[0].Value != null)
					{
						if (row.Cells[0].Value.ToString() != "")
						{
							if (row.Cells[8].Value == null)
							{
								if (row.Cells[9].Value == null)
								{
									flag = true;
									break;
								}
								else if (row.Cells[9].Value.ToString() == "")
								{
									flag = true;
									break;
								}
								else if (!(decimal.Parse(row.Cells[9].Value.ToString()) <= new decimal(0)))
								{
									flag = false;
								}
								else
								{
									flag = true;
									break;
								}
							}
							else if (!(row.Cells[8].Value.ToString() == ""))
							{
								if (decimal.Parse(row.Cells[8].Value.ToString()) <= new decimal(0))
								{
									if (row.Cells[9].Value == null)
									{
										flag = true;
										break;
									}
									else if (row.Cells[9].Value.ToString() == "")
									{
										flag = true;
										break;
									}
									else if (!(decimal.Parse(row.Cells[9].Value.ToString()) <= new decimal(0)))
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
							else if (row.Cells[9].Value == null)
							{
								flag = true;
								break;
							}
							else if (row.Cells[9].Value.ToString() == "")
							{
								flag = true;
								break;
							}
							else if (!(decimal.Parse(row.Cells[9].Value.ToString()) <= new decimal(0)))
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

		public bool CheckWhenByBank()
		{
			try
			{
				if (this.cmbPaymentMode.Text == "By Cheque")
				{
					if (!(this.txtChequeNo.Text.Trim() == ""))
					{
						this.isBychequeTextNull = false;
					}
					else
					{
						this.isBychequeTextNull = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return this.isBychequeTextNull;
		}

		public void ClearFunction()
		{
			try
			{
				base.ActiveControl = this.dtpDate;
				this.lstbxBatch.Visible = false;
                this.lblRows.Text = "0";
                this.txtVoucherNo.Text = this.GetMaxofPurchaseMasterId();
                //this.txtInvoice.Text = this.GetMaxofPurchaseInvoice();
				this.FillComboCashVender();
				this.dtpDate.Text = "";
				this.btnSave.Text = "&Save";
				this.isRepeated = false;
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.isFromPurchaseregister = false;
					this.frmRegister.Close();
				}
				this.dtblRemovedPurchaseId.Rows.Clear();
				this.tcReminder.SelectedTab = this.tpPurchase;
				if (!this.isInEditMode)
				{
					CompanySP companySP = new CompanySP();
					DataTable dataTable = new DataTable();
					dataTable = companySP.CompanyViewAll();
					this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
				}
				this.txtDueDays.Text = "";
				this.txtInvoice.Text = "";
				this.dgvPurchaseInvoice.Rows.Clear();
				this.FillComboItem();
				this.isSaved = false;
				this.txtDescription.Text = "";
				this.cmbPaymentMode.SelectedIndex = 0;
				this.txtChequeNo.Clear();
				this.isFormClose = false;
				this.dtpChequeDate.Text = "";
				this.lblTaxAmount.Text = "0.00";
				this.txtPendingAmount.Clear();
				this.lblTotalAmount.Text = "0.00";
				this.txtAdjustment.Clear();
				this.isCellEdit = false;
				this.isBychequeTextNull = false;
				this.txtBillDiscount.Clear();
				this.txtpaidAmount.Clear();
				this.lblRoundedGrandTotal.Text = "0.00";
				this.lblGrandTotal.Text = "0.00";
				this.chbxprint.Checked = false;
				this.btnDelete.Enabled = false;
				this.btnClear.Text = "C&lear";
				this.FillComboVender();
				this.txtPendingAmount.Clear();
				this.txtDueDays.Visible = false;
				this.isCreditPurchase = false;
				this.dtblRemovedPurchaseId.Rows.Clear();
				this.cmbVendor.SelectedValue = 0;
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
				if (e.KeyCode == Keys.Back)
				{
					this.cmbPaymentMode.Focus();
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
				if ((e.KeyCode != Keys.Return ? false : this.cmbCashVendor.Text != ""))
				{
					this.txtInvoice.Focus();
					this.txtInvoice.SelectionStart = this.txtInvoice.SelectionLength;
				}
				if (e.KeyCode == Keys.Back)
				{
					if (this.cmbCashVendor.Text != "")
					{
						this.dtpDate.Focus();
					}
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
							this.txtDueDays.Text = "";
							this.txtDueDays.Visible = true;
							if (!this.isInEditMode)
							{
								this.isCreditPurchase = true;
							}
							this.lblDueDays.Visible = true;
							this.cmbVendor.Visible = false;
							this.btnVendor.Visible = false;
							this.lblVendor.Visible = false;
							AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
							AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
							accountLedgerInfo = accountLedgerSP.AccountLedgerView(this.cmbCashVendor.SelectedValue.ToString());
							if (accountLedgerInfo.AccountGroupId == "11")
							{
								this.txtDueDays.Visible = false;
								if (!this.isInEditMode)
								{
									this.isCreditPurchase = false;
								}
								this.lblDueDays.Visible = false;
								this.cmbVendor.Visible = true;
								this.btnVendor.Visible = true;
								this.lblVendor.Visible = true;
								this.tcReminder.SelectedTab = this.tpPurchase;
							}
							else if (accountLedgerInfo.AccountGroupId != null)
							{
								DataTable dataTable = new DataTable();
								dataTable = accountLedgerSP.CheckGroupIdUnderCash(accountLedgerInfo.AccountGroupId);
								foreach (DataRow row in dataTable.Rows)
								{
									if (row.ItemArray[0].ToString() == "11")
									{
										this.txtDueDays.Visible = false;
										if (!this.isInEditMode)
										{
											this.isCreditPurchase = false;
										}
										this.lblDueDays.Visible = false;
										this.cmbVendor.Visible = true;
										this.btnVendor.Visible = true;
										this.lblVendor.Visible = true;
										this.tcReminder.SelectedTab = this.tpPurchase;
										break;
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
						frmPurchaseInvoice _frmPurchaseInvoice = this;
						_frmPurchaseInvoice.j = _frmPurchaseInvoice.j + 1;
					}
					else
					{
						this.j = 0;
						if (!this.txtDueDays.Visible)
						{
							this.cmbVendor.Focus();
						}
						else
						{
							this.txtDueDays.Focus();
							this.txtDueDays.SelectionStart = 0;
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

		private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (!(this.cmbPaymentMode.Text == "By Cash"))
				{
					this.txtChequeNo.Enabled = true;
					this.dtpChequeDate.Enabled = true;
				}
				else
				{
					this.txtChequeNo.Clear();
					this.txtChequeNo.Enabled = false;
					this.dtpChequeDate.Text = "";
					this.dtpChequeDate.Enabled = false;
				}
				this.FillCashBankAccountCombo();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbVendor_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if (this.cmbVendor.Text != "")
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

		private void cmbVendor_Leave(object sender, EventArgs e)
		{
			if (this.dgvPurchaseInvoice.Focused)
			{
				this.p = 1;
			}
		}

		public void CollectSelectedIds(string pPurchaseReturnDetailsId)
		{
			try
			{
				DataRow dataRow = this.dtblRemovedPurchaseId.NewRow();
				this.dtblRemovedPurchaseId.Rows.Add(dataRow);
				dataRow["DetailsOne"] = pPurchaseReturnDetailsId;
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
				if (this.dtblRemovedPurchaseId.Rows.Count == 0)
				{
					DataColumn dataColumn = new DataColumn("DetailsOne");
					this.dtblRemovedPurchaseId.Columns.Add(dataColumn);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DeleteSelectedPurchaseDetailsId()
		{
			try
			{
				PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
				foreach (DataRow row in this.dtblRemovedPurchaseId.Rows)
				{
					purchaseDetailsSP.PurchaseDetailsDelete(row.ItemArray[0].ToString());
				}
				this.dtblRemovedPurchaseId.Rows.Clear();
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
				if (this.dgvPurchaseInvoice.CurrentRow != null)
				{
					if (this.dgvPurchaseInvoice.CurrentRow.DefaultCellStyle.BackColor != Color.Cornsilk)
					{
						this.dgvPurchaseInvoice.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
						this.isCellEdit = true;
					}
				}
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
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					ProductBatchInfo productBatchInfo = new ProductBatchInfo();
					ProductBatchSP productBatchSP = new ProductBatchSP();
					if ((this.btnClear.Focused || this.btnDelete.Focused || this.btnClose.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
					{
						if ((e.ColumnIndex == 0 ? true : e.ColumnIndex == 1))
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
							{
								if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
								{
									this.FillBatchCombo(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
								}
							}
						}
						if (e.ColumnIndex == 3)
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
							{
								if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() != "")
								{
									if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().ToUpper() == "NA")
									{
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
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

		private void dgvPurchaseInvoice_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.rowIndex = e.RowIndex;
				this.columnIndex = e.ColumnIndex;
				if (this.isCellEdit)
				{
					if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 ? false : e.ColumnIndex != 2))
					{
						this.dgvPurchaseInvoice.BeginEdit(true);
					}
				}
				if (e.ColumnIndex != 2)
				{
					this.lstbxBatch.Visible = false;
				}
				else if (this.dgvPurchaseInvoice.CurrentRow != null)
				{
					if (this.dgvPurchaseInvoice.CurrentRow.Cells[e.ColumnIndex - 1].Value == null)
					{
						this.lstbxBatch.Visible = false;
					}
					else if (!(this.dgvPurchaseInvoice.CurrentRow.Cells[e.ColumnIndex - 1].Value.ToString() != ""))
					{
						this.lstbxBatch.Visible = false;
					}
					else if (this.dgvPurchaseInvoice.Rows[this.rowIndex].DefaultCellStyle.BackColor != Color.Cornsilk)
					{
						this.FillBatchCombo(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
						Point left = new Point();
						Rectangle cellDisplayRectangle = this.dgvPurchaseInvoice.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.X = cellDisplayRectangle.Left + this.dgvPurchaseInvoice.Left;
						cellDisplayRectangle = this.dgvPurchaseInvoice.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.Y = cellDisplayRectangle.Bottom + this.dgvPurchaseInvoice.Top;
						this.lstbxBatch.Visible = true;
						this.lstbxBatch.Location = left;
					}
				}
				if (e.ColumnIndex == 0)
				{
					this.p = 0;
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
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					if (this.dgvPurchaseInvoice.CurrentCell == null)
					{
						flag = true;
					}
					else
					{
						flag = (this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 4 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 5 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 6 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 8 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 9 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 11 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 12 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 13 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 15 ? false : this.dgvPurchaseInvoice.CurrentCell.ColumnIndex != 16);
					}
					if (!flag)
					{
						if ((this.dgvPurchaseInvoice.CurrentRow.Cells[0].Value == null ? false : this.dgvPurchaseInvoice.CurrentRow.Cells[1].Value != null))
						{
							if ((this.dgvPurchaseInvoice.CurrentRow.Cells[0].Value.ToString() == "" ? false : this.dgvPurchaseInvoice.CurrentRow.Cells[1].Value.ToString() != ""))
							{
								try
								{
									decimal.Parse(this.dgvPurchaseInvoice.CurrentCell.Value.ToString());
								}
								catch (Exception exception)
								{
									this.dgvPurchaseInvoice.CurrentCell.Value = 0;
								}
							}
						}
					}
					if ((e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 12 ? true : e.ColumnIndex == 15))
					{
						if ((this.btnClear.Focused || this.btnDelete.Focused || this.btnClose.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
							{
								if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
								{
									DecimalValidation decimalValidation = new DecimalValidation();
									TextBox textBox = new TextBox()
									{
										Text = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
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
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
									}
								}
							}
						}
					}
					DataTable dataTable = new DataTable();
					if ((e.ColumnIndex == 1 || e.ColumnIndex == 8 ? true : e.ColumnIndex == 9))
					{
						if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[1].Value == null || this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value == null ? false : this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value != null))
						{
							if ((!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[1].Value.ToString() != "") || !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value.ToString() != "") ? false : this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value.ToString() != ""))
							{
								decimal num = new decimal(0);
								if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[9].Value != null)
								{
									num = (!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() == "") ? decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[9].Value.ToString()) : new decimal(0));
								}
								else
								{
									num = new decimal(0);
								}
								string str = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[1].Value.ToString();
								dataTable = this.productsp.GetCurrentStockOfProduct(str);
								if (dataTable.Rows.Count > 0)
								{
									ProductInfo productInfo = new ProductInfo();
									productInfo = this.productsp.ProductView(str);
									if (productInfo.StockMaximumLevel > new decimal(0))
									{
										decimal num1 = new decimal(0);
										decimal num2 = new decimal(0);
										decimal num3 = new decimal(0);
										decimal qty = new decimal(0);
										decimal freeQty = new decimal(0);
										num1 = decimal.Parse(dataTable.Rows[0].ItemArray[0].ToString());
										if (this.isInEditMode)
										{
											PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
											PurchaseDetailsInfo purchaseDetailsInfo = new PurchaseDetailsInfo();
											if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[18].Value == null)
											{
												num2 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value.ToString());
												num3 = (num1 + num2) + num;
												if (productInfo.StockMaximumLevel < num3)
												{
													if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
													{
														if (!this.isSaved)
														{
															if (e.ColumnIndex == 9)
															{
																if (num > new decimal(0))
																{
																	MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
																}
															}
															if (e.ColumnIndex == 8)
															{
																if (num2 > new decimal(0))
																{
																	MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
																}
															}
														}
													}
												}
											}
											else
											{
												purchaseDetailsInfo = purchaseDetailsSP.PurchaseDetailsView(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[18].Value.ToString());
												qty = purchaseDetailsInfo.Qty;
												freeQty = purchaseDetailsInfo.FreeQty;
												num3 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value.ToString());
												num2 = (((num1 - qty) - freeQty) + num) + num3;
												if (productInfo.StockMaximumLevel < num2)
												{
													if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
													{
														if (!this.isSaved)
														{
															if (e.ColumnIndex == 9)
															{
																if (num > new decimal(0))
																{
																	MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
																}
															}
															if (e.ColumnIndex == 8)
															{
																if (num3 > new decimal(0))
																{
																	MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
																}
															}
														}
													}
												}
											}
										}
										else
										{
											num2 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value.ToString());
											num3 = (num1 + num2) + num;
											if (productInfo.StockMaximumLevel < num3)
											{
												if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
												{
													if (!this.isSaved)
													{
														if (e.ColumnIndex == 9)
														{
															if (num > new decimal(0))
															{
																MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
															}
														}
														if (e.ColumnIndex == 8)
														{
															if (num2 > new decimal(0))
															{
																MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (e.ColumnIndex == 12)
					{
						if ((this.btnClear.Focused || this.btnDelete.Focused || this.btnClose.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
							{
								if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
								{
									if (decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value.ToString()) > new decimal(100))
									{
										if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
										{
											if (!this.isSaved)
											{
												MessageBox.Show("Check discount percent", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											}
										}
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
									}
								}
							}
						}
					}
					if (e.ColumnIndex == 15)
					{
						if ((this.btnClear.Focused || this.btnDelete.Focused || this.btnClose.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
							{
								if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
								{
									if (decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[15].Value.ToString()) > new decimal(100))
									{
										if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
										{
											if (!this.isSaved)
											{
												MessageBox.Show("Check tax percent", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											}
										}
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
									}
								}
							}
						}
					}
					if ((e.ColumnIndex == 2 || e.ColumnIndex == 1 || e.ColumnIndex == 4 || e.ColumnIndex == 8 || e.ColumnIndex == 12 ? true : e.ColumnIndex == 15))
					{
						if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[4].Value == null ? true : this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value == null))
						{
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value = "";
						}
						else if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() == "" ? true : !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value.ToString() != "")))
						{
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value = "";
						}
						else
						{
							decimal num4 = new decimal(0, 0, 0, false, 2);
							decimal num5 = new decimal(0, 0, 0, false, 2);
							decimal num6 = new decimal(0, 0, 0, false, 2);
							num4 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[4].Value.ToString());
							num5 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[8].Value.ToString());
							num6 = num4 * num5;
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value = num6;
						}
					}
					bool flag1 = true;
					if ((e.ColumnIndex == 2 || e.ColumnIndex == 1 || e.ColumnIndex == 4 || e.ColumnIndex == 8 || e.ColumnIndex == 11 || e.ColumnIndex == 12 || e.ColumnIndex == 14 ? true : e.ColumnIndex == 15))
					{
						if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value == null ? true : this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value == null))
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value == null)
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = "";
							}
							else if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value == null)
							{
								if (!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString() != "0.00"))
								{
									this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = "";
								}
								else
								{
									this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString();
								}
							}
						}
						else if (!(!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString() != "0") || !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString() != "") ? true : !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() != "")))
						{
							decimal num7 = new decimal(0, 0, 0, false, 2);
							decimal num8 = new decimal(0, 0, 0, false, 2);
							num7 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString());
							num8 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value.ToString()) / new decimal(100);
							if (!(num7 >= num8))
							{
								if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
								{
									if (!this.isSaved)
									{
										MessageBox.Show("Discount greater than net value", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									}
								}
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value = "";
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = num7 - new decimal(0);
							}
							else
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = num7 - (num7 * num8);
							}
						}
						else if (!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString() == "0" ? false : !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString() == "")))
						{
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = "";
						}
						else if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[12].Value.ToString() == "")
						{
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[11].Value.ToString();
						}
						if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value == null ? true : this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value == null))
						{
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[16].Value = "";
						}
						else if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value.ToString() == "" ? true : !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value.ToString() != "")))
						{
							this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[16].Value = "";
						}
						else
						{
							flag1 = false;
							decimal num9 = new decimal(0, 0, 0, false, 2);
							string str1 = "";
							decimal num10 = new decimal(0, 0, 0, false, 2);
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[15].Value != null)
							{
								num9 = (!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[15].Value.ToString() == "") ? decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[15].Value.ToString()) : new decimal(0));
							}
							else
							{
								num9 = new decimal(0);
							}
							num10 = decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value.ToString());
							str1 = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value.ToString();
							if (str1 == "Included")
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[16].Value = Math.Round((num10 * num9) / (new decimal(100) + num9), 2);
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[17].Value = num10;
							}
							else if (!(str1 == "Excluded"))
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[17].Value = num10;
							}
							else
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[16].Value = Math.Round((num10 * num9) / new decimal(100), 2);
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[17].Value = num10 + decimal.Parse(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[16].Value.ToString());
							}
						}
						if (flag1)
						{
							if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value == null)
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[17].Value = "";
							}
							else if (!(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value.ToString() != ""))
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[17].Value = "";
							}
							else
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[17].Value = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[13].Value.ToString();
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
					bool flag = false;
					string str = "";
					ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
					ManufacturerSP manufacturerSP = new ManufacturerSP();
					UnitInfo unitInfo = new UnitInfo();
					UnitSP unitSP = new UnitSP();
					ProductBatchInfo productBatchInfo = new ProductBatchInfo();
					ProductBatchSP productBatchSP = new ProductBatchSP();
					if (this.dgvPurchaseInvoice.CurrentCell != null)
					{
						if ((this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 0 ? true : this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 1))
						{
							ProductInfo productInfo = new ProductInfo();
							if (this.dgvPurchaseInvoice.CurrentCell.Value != null)
							{
								if (this.dgvPurchaseInvoice.CurrentCell.Value.ToString() != "")
								{
									string str1 = this.dgvPurchaseInvoice.CurrentCell.Value.ToString();
									productInfo = this.productsp.ProductView(str1);
									if (productInfo.ProductId != null)
									{
										if (this.dgvPurchaseInvoice.CurrentCell.ColumnIndex != 0)
										{
											this.dgvPurchaseInvoice.CurrentRow.Cells[0].Value = str1;
										}
										else
										{
											this.FillComboItem();
											this.dgvPurchaseInvoice.CurrentRow.Cells[1].Value = str1;
										}
										manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
										if (manufacturerInfo.ManufactureId != null)
										{
											this.dgvPurchaseInvoice.CurrentRow.Cells[7].Value = manufacturerInfo.ManufactureName;
										}
										unitInfo = unitSP.UnitView(productInfo.UnitId);
										if (unitInfo.UnitName != null)
										{
											this.dgvPurchaseInvoice.CurrentRow.Cells[10].Value = unitInfo.UnitName;
										}
									}
									else
									{
										this.dgvPurchaseInvoice.CurrentRow.Cells[0].Value = "";
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value = "";
									}
								}
							}
							else if (this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 1)
							{
								this.dgvPurchaseInvoice.CurrentRow.Cells[0].Value = "";
							}
						}
						if (e.ColumnIndex == 2)
						{
							string lower = "";
							if (this.dgvPurchaseInvoice.CurrentRow.Cells[1].Value != null)
							{
								if (this.dgvPurchaseInvoice.CurrentRow.Cells[1].Value.ToString() != "")
								{
									this.FillBatchCombo(this.dgvPurchaseInvoice.CurrentRow.Cells[1].Value.ToString());
									for (int i = 0; i < this.lstbxBatch.Items.Count; i++)
									{
										lower = this.lstbxBatch.Items[i].ToString().ToLower();
										if (this.dgvPurchaseInvoice.CurrentCell.Value == null)
										{
											this.lstbxBatch.SelectedItem = null;
										}
										else if (!lower.StartsWith(this.dgvPurchaseInvoice.CurrentCell.Value.ToString().ToLower()))
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
						if ((e.ColumnIndex == 2 || e.ColumnIndex == 1 ? true : e.ColumnIndex == 0))
						{
							flag = false;
							if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[0].Value == null || this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[1].Value == null ? true : this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value == null))
							{
								flag = true;
							}
							else if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[0].Value.ToString() == "" ? true : !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value.ToString() != "")))
							{
								flag = true;
							}
							else
							{
								DataTable dataTable = new DataTable();
								string str2 = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[1].Value.ToString();
								string lower1 = this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower();
								dataTable = productBatchSP.ProductBatchViewByProductAndBatchName(str2, lower1.Trim());
								if (dataTable.Rows.Count > 0)
								{
									str = dataTable.Rows[0].ItemArray[0].ToString();
								}
								if (!(str.Trim() != ""))
								{
									flag = true;
								}
								else
								{
									productBatchInfo = productBatchSP.ProductBatchView(str);
									if (productBatchInfo.ProductBatchId == null)
									{
										flag = true;
									}
									else if ((this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower().Trim() != productBatchInfo.BatchName.ToLower().Trim() ? true : !(this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[1].Value.ToString() == productBatchInfo.ProductId)))
									{
										flag = true;
									}
									else
									{
										if (!(productBatchInfo.ExpiryDate == DateTime.Parse("01/01/1753")))
										{
											this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[3].Value = productBatchInfo.ExpiryDate;
										}
										else
										{
											this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[3].Value = "";
										}
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[4].Value = Math.Round(productBatchInfo.PurchaseRate, 2);
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[5].Value = Math.Round(productBatchInfo.SalesRate, 2);
										this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[6].Value = Math.Round(productBatchInfo.MRP);
										flag = false;
									}
								}
							}
							if (flag)
							{
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[4].Value = "";
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[5].Value = "";
								this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[6].Value = "";
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
				if (this.dgvPurchaseInvoice.CurrentCell is DataGridViewComboBoxCell)
				{
					this.dgvPurchaseInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
				if (this.dgvPurchaseInvoice.CurrentCell is DataGridViewTextBoxCell)
				{
					this.dgvPurchaseInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
				DataGridViewTextBoxEditingControl control = e.Control as DataGridViewTextBoxEditingControl;
				if (control != null)
				{
					control.KeyPress += new KeyPressEventHandler(this.TextBoxCellEditControlKeyPress);
				}
                if (e.Control is ComboBox)
                {

                    if (this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 1)
                    {
                        ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                        ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                    }

                    // ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (this.dgvPurchaseInvoice.CurrentRow != null)
				{
					if (!(this.dgvPurchaseInvoice.Rows[this.rowIndex].DefaultCellStyle.BackColor != Color.Cornsilk))
					{
						if (this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 2)
						{
							e.Handled = true;
						}
						if (e.KeyCode == Keys.Return)
						{
							e.Handled = false;
						}
					}
					else if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 2 : false))
					{
						if (this.dgvPurchaseInvoice.CurrentRow != null)
						{
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
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvPurchaseInvoice.CurrentCell == this.dgvPurchaseInvoice[17, this.dgvPurchaseInvoice.Rows.Count - 1])
					{
						this.txtAdjustment.Focus();
						this.dgvPurchaseInvoice.ClearSelection();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if ((this.dgvPurchaseInvoice.CurrentCell == null || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex != 0 ? false : this.dgvPurchaseInvoice.CurrentCell.RowIndex == 0))
					{
						if (this.p != 1)
						{
							frmPurchaseInvoice _frmPurchaseInvoice = this;
							_frmPurchaseInvoice.p = _frmPurchaseInvoice.p + 1;
						}
						else
						{
							this.p = 0;
							this.dgvPurchaseInvoice.ClearSelection();
							if (!this.txtDueDays.Visible)
							{
								this.cmbVendor.Focus();
							}
							else
							{
								this.txtDueDays.Focus();
								this.txtDueDays.SelectionStart = 0;
							}
						}
					}
				}
				if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 2 : false))
				{
					if (this.dgvPurchaseInvoice.Rows[this.rowIndex].DefaultCellStyle.BackColor != Color.Cornsilk)
					{
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
					if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value == null)
					{
						this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value = "Included";
					}
					else if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value.ToString() == "")
					{
						this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[14].Value = "Included";
					}
					if (this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
					{
						this.dgvPurchaseInvoice.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseInvoice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.FillComboItem();
		}

		private void dgvPurchaseInvoice_Scroll(object sender, ScrollEventArgs e)
		{
			this.lstbxBatch.Visible = false;
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void DoPaymentLedgerPosting(string strPaymentId)
		{
			try
			{
				if (this.txtpaidAmount.Text != "")
				{
					if (decimal.Parse(this.txtpaidAmount.Text) > new decimal(0))
					{
						LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo()
						{
							VoucherNumber = strPaymentId,
							VoucherType = "Payment Voucher",
							Description = "By payment",
							Date = DateTime.Parse(this.dtpDate.Text),
							LedgerId = this.cmbCashBankAccount.SelectedValue.ToString(),
							Credit = decimal.Parse(this.txtpaidAmount.Text),
							Debit = new decimal(0)
						};
						this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
						ledgerPostingInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
						ledgerPostingInfo.Debit = decimal.Parse(this.txtpaidAmount.Text);
						ledgerPostingInfo.Credit = new decimal(0);
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

		public void DoWhenComingFromRegister(frmPurchaseRegister frmpurchaseregister, string strPurchaseMasterId)
		{
			try
			{
				base.Show();
				this.isCellValueChanged = true;
				this.isFromPurchaseregister = true;
				this.isInEditMode = true;
				this.btnSave.Text = "&Update";
				this.btnDelete.Enabled = true;
				this.btnClear.Text = "&New";
				bool flag = true;
				decimal num = new decimal(0, 0, 0, false, 2);
				decimal num1 = new decimal(0, 0, 0, false, 2);
				decimal num2 = new decimal(0, 0, 0, false, 2);
				decimal num3 = new decimal(0, 0, 0, false, 2);
				decimal num4 = new decimal(0, 0, 0, false, 2);
				decimal num5 = new decimal(0, 0, 0, false, 2);
				string str = "";
				this.frmRegister = frmpurchaseregister;
				int white = 0;
				PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
				PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
				PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
				PurchaseDetailsInfo purchaseDetailsInfo = new PurchaseDetailsInfo();
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
				purchaseMasterInfo = purchaseMasterSP.PurchaseMasterView(strPurchaseMasterId);
				if (purchaseMasterInfo.PurchaseMasterId != null)
				{
					this.txtVoucherNo.Text = purchaseMasterInfo.PurchaseMasterId;
					this.dtpDate.Text = purchaseMasterInfo.Date.ToString();
					this.FillComboCashVender();
					this.txtInvoice.Text = purchaseMasterInfo.PurchaseInvoiceNo;
					if (purchaseMasterInfo.LedgerId != null)
					{
						this.cmbCashVendor.SelectedValue = purchaseMasterInfo.LedgerId;
						if (!(accountLedgerSP.AccountLedgerView(purchaseMasterInfo.LedgerId).AccountGroupId == "11"))
						{
							this.txtDueDays.Text = purchaseMasterInfo.DueDays.ToString();
						}
						else
						{
							this.cmbVendor.SelectedValue = purchaseMasterInfo.VendorId;
						}
					}
					TextBox textBox = this.txtAdjustment;
					decimal additionalCost = purchaseMasterInfo.AdditionalCost;
					double num6 = double.Parse(additionalCost.ToString());
					textBox.Text = num6.ToString();
					TextBox str1 = this.txtBillDiscount;
					additionalCost = purchaseMasterInfo.BillDiscount;
					num6 = double.Parse(additionalCost.ToString());
					str1.Text = num6.ToString();
					this.txtDescription.Text = purchaseMasterInfo.Description;
					dataTable = purchaseDetailsSP.PurchaseDetailsViewAllByMasterId(strPurchaseMasterId);
					if (dataTable.Rows.Count > 0)
					{
						foreach (DataRow row in dataTable.Rows)
						{
							num = new decimal(0, 0, 0, false, 2);
							num1 = new decimal(0, 0, 0, false, 2);
							num2 = new decimal(0, 0, 0, false, 2);
							num3 = new decimal(0, 0, 0, false, 2);
							num4 = new decimal(0, 0, 0, false, 2);
							num5 = new decimal(0, 0, 0, false, 2);
							str = "";
							flag = true;
							if (row.ItemArray[2].ToString() != null)
							{
								this.dgvPurchaseInvoice.Rows.Add();
								if (!purchaseDetailsSP.PurchaseDetailsCheckOnDelete(row.ItemArray[0].ToString()))
								{
									this.dgvPurchaseInvoice.Rows[white].ReadOnly = false;
									this.dgvPurchaseInvoice.Rows[white].DefaultCellStyle.BackColor = Color.White;
								}
								else
								{
									this.dgvPurchaseInvoice.Rows[white].ReadOnly = true;
									this.dgvPurchaseInvoice.Rows[white].DefaultCellStyle.BackColor = Color.Cornsilk;
								}
								productBatchInfo = productBatchSP.ProductBatchView(row.ItemArray[2].ToString());
								this.dgvPurchaseInvoice.Rows[white].Cells[0].Value = productBatchInfo.ProductId;
								productInfo = this.productsp.ProductView(productBatchInfo.ProductId);
								this.dgvPurchaseInvoice.Rows[white].Cells[1].Value = productBatchInfo.ProductId;
								this.FillBatchCombo(productBatchInfo.ProductId);
								this.dgvPurchaseInvoice.Rows[white].Cells[2].Value = productBatchInfo.BatchName;
								if (!(DateTime.Parse(productBatchInfo.ExpiryDate.ToString()) == DateTime.Parse("01/01/1753")))
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[3].Value = productBatchInfo.ExpiryDate;
								}
								else
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[3].Value = "";
								}
								DataGridViewCell item = this.dgvPurchaseInvoice.Rows[white].Cells[4];
								num6 = double.Parse(row.ItemArray[3].ToString());
								item.Value = num6.ToString();
								DataGridViewCell dataGridViewCell = this.dgvPurchaseInvoice.Rows[white].Cells[5];
								additionalCost = productBatchInfo.SalesRate;
								num6 = double.Parse(additionalCost.ToString());
								dataGridViewCell.Value = num6.ToString();
								DataGridViewCell item1 = this.dgvPurchaseInvoice.Rows[white].Cells[6];
								additionalCost = productBatchInfo.MRP;
								num6 = double.Parse(additionalCost.ToString());
								item1.Value = num6.ToString();
								manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
								this.dgvPurchaseInvoice.Rows[white].Cells[7].Value = manufacturerInfo.ManufactureName;
								DataGridViewCell dataGridViewCell1 = this.dgvPurchaseInvoice.Rows[white].Cells[8];
								num6 = double.Parse(row.ItemArray[5].ToString());
								dataGridViewCell1.Value = num6.ToString();
								this.dgvPurchaseInvoice.Rows[white].Cells[9].Value = row.ItemArray[6].ToString();
								unitInfo = unitSP.UnitView(productInfo.UnitId);
								this.dgvPurchaseInvoice.Rows[white].Cells[10].Value = unitInfo.UnitName;
								if ((decimal.Parse(row.ItemArray[3].ToString()) == new decimal(0) ? true : !(row.ItemArray[5].ToString() != "")))
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[11].Value = 0;
								}
								else
								{
									num = decimal.Parse(row.ItemArray[3].ToString());
									num1 = decimal.Parse(row.ItemArray[5].ToString());
									num2 = num * num1;
									this.dgvPurchaseInvoice.Rows[white].Cells[11].Value = Math.Round(num2, 2);
								}
								this.dgvPurchaseInvoice.Rows[white].Cells[12].Value = Math.Round(decimal.Parse(row.ItemArray[4].ToString()), 2);
								if (!(num2 == new decimal(0) ? true : !(row.ItemArray[4].ToString() != "")))
								{
									num3 = decimal.Parse(row.ItemArray[4].ToString());
									num4 = Math.Round(num2 - ((num2 * num3) / new decimal(100)), 2);
									this.dgvPurchaseInvoice.Rows[white].Cells[13].Value = num4;
								}
								else if (num2 == new decimal(0))
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[13].Value = 0;
								}
								else if (decimal.Parse(row.ItemArray[4].ToString()) == new decimal(0))
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[13].Value = Math.Round(num2);
								}
								if ((num4 == new decimal(0) ? true : !(decimal.Parse(row.ItemArray[7].ToString()) != new decimal(0))))
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[16].Value = 0;
								}
								else
								{
									flag = false;
									num5 = decimal.Parse(row.ItemArray[7].ToString());
									str = row.ItemArray[8].ToString();
									if (str == "False")
									{
										this.dgvPurchaseInvoice.Rows[white].Cells[16].Value = Math.Round((num4 * num5) / (new decimal(100) + num5), 2);
										this.dgvPurchaseInvoice.Rows[white].Cells[17].Value = num4;
									}
									else if (!(str == "True"))
									{
										this.dgvPurchaseInvoice.Rows[white].Cells[17].Value = num4;
									}
									else
									{
										this.dgvPurchaseInvoice.Rows[white].Cells[16].Value = Math.Round((num4 * num5) / new decimal(100), 2);
										this.dgvPurchaseInvoice.Rows[white].Cells[17].Value = num4 + decimal.Parse(this.dgvPurchaseInvoice.Rows[white].Cells[16].Value.ToString());
									}
								}
								if (flag)
								{
									if (!(num4 != new decimal(0)))
									{
										this.dgvPurchaseInvoice.Rows[white].Cells[17].Value = 0;
									}
									else
									{
										this.dgvPurchaseInvoice.Rows[white].Cells[17].Value = num4;
									}
								}
								if (!(row.ItemArray[8].ToString() == "True"))
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[14].Value = "Included";
								}
								else
								{
									this.dgvPurchaseInvoice.Rows[white].Cells[14].Value = "Excluded";
								}
								this.dgvPurchaseInvoice.Rows[white].Cells[15].Value = Math.Round(decimal.Parse(row.ItemArray[7].ToString()), 2);
								this.dgvPurchaseInvoice.Rows[white].Cells[18].Value = row.ItemArray[0].ToString();
								white++;
							}
						}
						this.CalculateTotal();
						this.dgvPurchaseInvoice.ClearSelection();
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
				if (this.isFromPurchaseregister)
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

		private void dtpChequeDate_KeyDown(object sender, KeyEventArgs e)
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
					this.txtChequeNo.Focus();
					this.txtChequeNo.SelectionStart = 0;
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

		public void FillCashBankAccountCombo()
		{
			try
			{
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				DataTable dataTable = new DataTable();
				if (!(this.cmbPaymentMode.Text == "By Cash"))
				{
					this.lblLedger.Text = "Bank Account";
					dataTable = accountLedgerSP.AccountLedgerViewUnderBank();
				}
				else
				{
					this.lblLedger.Text = "Cash Account";
					dataTable = accountLedgerSP.AccountLedgerViewUnderCash();
				}
				this.cmbCashBankAccount.DataSource = dataTable;
				this.cmbCashBankAccount.DisplayMember = dataTable.Columns[1].ToString();
				this.cmbCashBankAccount.ValueMember = dataTable.Columns[0].ToString();
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
					this.cmbProduct.ValueMember = dataTable.Columns[0].ToString();
					this.cmbProduct.DisplayMember = dataTable.Columns[1].ToString();
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
					this.cmbVendor.SelectedValue = 0;
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
				else if (e.KeyCode == Keys.F3)
				{
					if (this.tcReminder.SelectedTab == this.tpPayment)
					{
						this.tcReminder.SelectedTab = this.tpPurchase;
					}
					else
					{
						this.tcReminder.SelectedTab = this.tpPayment;
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
					this.ClearFunction();
					CompanySP companySP = new CompanySP();
					DataTable dataTable = new DataTable();
					dataTable = companySP.CompanyViewAll();
					this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
				}
				this.CreateDataTableForDeletedIDs();
				this.dtpDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpDate.MaxDate = FinacialYearInfo._toDate;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public string GetMaxofPurchaseMasterId()
		{
			string str = "";
			try
			{
				str = (new PurchaseMasterSP()).PurchaseMasterGetMax().ToString();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return str;
		}

        public string GetMaxofPurchaseInvoice()
        {
            string str = "";
            try
            {
                str = (new PurchaseMasterSP()).PurchaseMasterInvoiceMax().ToString();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPurchaseInvoice));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.chbxprint = new CheckBox();
			this.panel8 = new Panel();
			this.pbxSearch = new PictureBox();
			this.tcReminder = new TabControl();
			this.tpPurchase = new TabPage();
			this.lstbxBatch = new ListBox();
			this.dgvPurchaseInvoice = new dgv.DataGridViewEnter();
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
			this.btnRemove = new Button();
			this.tpPayment = new TabPage();
			this.label16 = new Label();
			this.label11 = new Label();
			this.cmbPaymentMode = new ComboBox();
			this.txtPendingAmount = new TextBox();
			this.label6 = new Label();
			this.txtpaidAmount = new TextBox();
			this.lblLedger = new Label();
			this.groupBox2 = new GroupBox();
			this.label9 = new Label();
			this.label10 = new Label();
			this.dtpChequeDate = new DateTimePicker();
			this.txtChequeNo = new TextBox();
			this.cmbCashBankAccount = new ComboBox();
			this.btnPaymentBtn = new Button();
			this.label4 = new Label();
			this.label7 = new Label();
			this.lblRoundedGrandTotal = new Label();
			this.lblRoundedGrand = new Label();
			this.lblGrandTotal = new Label();
			this.lblGrand = new Label();
			this.label22 = new Label();
			this.txtBillDiscount = new TextBox();
			this.txtAdjustment = new TextBox();
			this.label21 = new Label();
			this.lblTotalAmount = new Label();
			this.lblTot = new Label();
			this.lblTaxAmount = new Label();
            this.lblCountRows = new Label();
            this.lblRows = new Label();
            this.lblTax = new Label();
			this.label5 = new Label();
			this.txtDescription = new TextBox();
			this.label15 = new Label();
			this.txtInvoice = new TextBox();
			this.label14 = new Label();
			this.label13 = new Label();
			this.txtDueDays = new TextBox();
			this.lblBlnceAmount = new Label();
			this.lblVendor = new Label();
			this.lblDueDays = new Label();
			this.btnVendor = new Button();
			this.dtpDate = new DateTimePicker();
			this.btnNewledgers = new Button();
			this.cmbVendor = new ComboBox();
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
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.pbxSearch).BeginInit();
			this.tcReminder.SuspendLayout();
			this.tpPurchase.SuspendLayout();
			((ISupportInitialize)this.dgvPurchaseInvoice).BeginInit();
			this.tpPayment.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.chbxprint);
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
			this.btnSave.TabIndex = 15;
			this.btnSave.Text = "Save";
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
			this.btnDelete.Text = "Delete";
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
			this.btnClear.Text = "Clear";
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
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.chbxprint.AutoSize = true;
			this.chbxprint.Location = new Point(360, 489);
			this.chbxprint.Name = "chbxprint";
			this.chbxprint.Size = new System.Drawing.Size(97, 17);
			this.chbxprint.TabIndex = 55665;
			this.chbxprint.Text = "Print after save";
			this.chbxprint.UseVisualStyleBackColor = true;
			this.chbxprint.KeyDown += new KeyEventHandler(this.chbxprint_KeyDown);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.pbxSearch);
			this.panel8.Controls.Add(this.tcReminder);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.lblRoundedGrandTotal);
			this.panel8.Controls.Add(this.lblRoundedGrand);
			this.panel8.Controls.Add(this.lblGrandTotal);
			this.panel8.Controls.Add(this.lblGrand);
			this.panel8.Controls.Add(this.label22);
			this.panel8.Controls.Add(this.txtBillDiscount);
			this.panel8.Controls.Add(this.txtAdjustment);
			this.panel8.Controls.Add(this.label21);
			this.panel8.Controls.Add(this.lblTotalAmount);
			this.panel8.Controls.Add(this.lblTot);
			this.panel8.Controls.Add(this.lblTaxAmount);
            this.panel8.Controls.Add(this.lblRows);
            this.panel8.Controls.Add(this.lblCountRows);
            this.panel8.Controls.Add(this.lblTax);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label15);
			this.panel8.Controls.Add(this.txtInvoice);
			this.panel8.Controls.Add(this.label14);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.txtDueDays);
			this.panel8.Controls.Add(this.lblBlnceAmount);
			this.panel8.Controls.Add(this.lblVendor);
			this.panel8.Controls.Add(this.lblDueDays);
			this.panel8.Controls.Add(this.btnVendor);
			this.panel8.Controls.Add(this.dtpDate);
			this.panel8.Controls.Add(this.btnNewledgers);
			this.panel8.Controls.Add(this.cmbVendor);
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
			this.pbxSearch.Image = (Image)componentResourceManager.GetObject("pbxSearch.Image");
			this.pbxSearch.Location = new Point(619, 83);
			this.pbxSearch.Name = "pbxSearch";
			this.pbxSearch.Size = new System.Drawing.Size(81, 28);
			this.pbxSearch.TabIndex = 36456462;
			this.pbxSearch.TabStop = false;
			this.pbxSearch.Click += new EventHandler(this.btnSearch_Click);
			this.pbxSearch.MouseHover += new EventHandler(this.pbxSearch_MouseHover);
			this.tcReminder.Controls.Add(this.tpPurchase);
			this.tcReminder.Controls.Add(this.tpPayment);
			this.tcReminder.Location = new Point(5, 95);
			this.tcReminder.Name = "tcReminder";
			this.tcReminder.SelectedIndex = 0;
			this.tcReminder.Size = new System.Drawing.Size(766, 234);
			this.tcReminder.TabIndex = 36456460;
			this.tcReminder.Selecting += new TabControlCancelEventHandler(this.tcReminder_Selecting);
			this.tpPurchase.BackColor = Color.White;
			this.tpPurchase.Controls.Add(this.lstbxBatch);
			this.tpPurchase.Controls.Add(this.dgvPurchaseInvoice);
			this.tpPurchase.Controls.Add(this.btnRemove);
			this.tpPurchase.Location = new Point(4, 22);
			this.tpPurchase.Name = "tpPurchase";
			this.tpPurchase.Padding = new System.Windows.Forms.Padding(7);
			this.tpPurchase.Size = new System.Drawing.Size(758, 208);
			this.tpPurchase.TabIndex = 1;
			this.tpPurchase.Text = "Purchase";
			this.tpPurchase.UseVisualStyleBackColor = true;
			this.lstbxBatch.FormattingEnabled = true;
			this.lstbxBatch.Location = new Point(307, 52);
			this.lstbxBatch.Name = "lstbxBatch";
			this.lstbxBatch.Size = new System.Drawing.Size(150, 95);
			this.lstbxBatch.TabIndex = 36456459;
			this.lstbxBatch.TabStop = false;
			this.lstbxBatch.MouseClick += new MouseEventHandler(this.lstbxBatch_MouseClick);
			this.lstbxBatch.DoubleClick += new EventHandler(this.lstbxBatch_DoubleClick);
			this.lstbxBatch.KeyDown += new KeyEventHandler(this.lstbxBatch_KeyDown);
			this.dgvPurchaseInvoice.AllowUserToDeleteRows = false;
			this.dgvPurchaseInvoice.AllowUserToResizeColumns = false;
			this.dgvPurchaseInvoice.AllowUserToResizeRows = false;
			this.dgvPurchaseInvoice.BackgroundColor = Color.White;
			this.dgvPurchaseInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvPurchaseInvoice.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.cmbProduct, this.cmbBatch, this.Column4, this.Column5, this.Column6, this.Column7, this.Column8, this.Column9, this.Column10, this.Column11, this.Column12, this.Column13, this.Column14, this.Column15, this.Column16, this.Column17, this.Column18, this.Column19 };
			columns.AddRange(column1);
			this.dgvPurchaseInvoice.GridColor = Color.WhiteSmoke;
			this.dgvPurchaseInvoice.Location = new Point(6, 5);
			this.dgvPurchaseInvoice.Name = "dgvPurchaseInvoice";
			this.dgvPurchaseInvoice.RowHeadersVisible = false;
			this.dgvPurchaseInvoice.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvPurchaseInvoice.Size = new System.Drawing.Size(747, 171);
			this.dgvPurchaseInvoice.TabIndex = 5;
			this.dgvPurchaseInvoice.CellLeave += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellLeave);
			this.dgvPurchaseInvoice.KeyDown += new KeyEventHandler(this.dgvPurchaseInvoice_KeyDown);
			this.dgvPurchaseInvoice.CellClick += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellClick);
			this.dgvPurchaseInvoice.RowEnter += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_RowEnter);
			this.dgvPurchaseInvoice.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvPurchaseInvoice_RowsAdded);
			this.dgvPurchaseInvoice.Leave += new EventHandler(this.dgvPurchaseInvoice_Leave);
			this.dgvPurchaseInvoice.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvPurchaseInvoice_CellValidating);
			this.dgvPurchaseInvoice.CurrentCellDirtyStateChanged += new EventHandler(this.dgvPurchaseInvoice_CurrentCellDirtyStateChanged);
			this.dgvPurchaseInvoice.CellEndEdit += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellEndEdit);
			this.dgvPurchaseInvoice.CellValueChanged += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellValueChanged);
			this.dgvPurchaseInvoice.Scroll += new ScrollEventHandler(this.dgvPurchaseInvoice_Scroll);
			this.dgvPurchaseInvoice.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvPurchaseInvoice_EditingControlShowing);
			this.dgvPurchaseInvoice.KeyUp += new KeyEventHandler(this.dgvPurchaseInvoice_KeyUp);
			this.dgvPurchaseInvoice.CellEnter += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellEnter);
			this.dgvPurchaseInvoice.KeyPress += new KeyPressEventHandler(this.dgvPurchaseInvoice_KeyPress);
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
			DataGridViewComboBoxCell.ObjectCollection items = this.Column15.Items;
			object[] objArray = new object[] { "Included", "Excluded" };
			items.AddRange(objArray);
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
			this.Column19.HeaderText = "PurchaseDetailsId";
			this.Column19.Name = "Column19";
			this.Column19.ReadOnly = true;
			this.Column19.Resizable = DataGridViewTriState.False;
			this.Column19.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column19.Visible = false;
			this.btnRemove.BackColor = Color.SteelBlue;
			this.btnRemove.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRemove.ForeColor = Color.White;
			this.btnRemove.Location = new Point(670, 182);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(85, 23);
			this.btnRemove.TabIndex = 36456457;
			this.btnRemove.TabStop = false;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.tpPayment.Controls.Add(this.label16);
			this.tpPayment.Controls.Add(this.label11);
			this.tpPayment.Controls.Add(this.cmbPaymentMode);
			this.tpPayment.Controls.Add(this.txtPendingAmount);
			this.tpPayment.Controls.Add(this.label6);
			this.tpPayment.Controls.Add(this.txtpaidAmount);
			this.tpPayment.Controls.Add(this.lblLedger);
			this.tpPayment.Controls.Add(this.groupBox2);
			this.tpPayment.Controls.Add(this.cmbCashBankAccount);
			this.tpPayment.Controls.Add(this.btnPaymentBtn);
			this.tpPayment.Location = new Point(4, 22);
			this.tpPayment.Name = "tpPayment";
			this.tpPayment.Size = new System.Drawing.Size(758, 208);
			this.tpPayment.TabIndex = 2;
			this.tpPayment.Text = "Payment";
			this.tpPayment.UseVisualStyleBackColor = true;
			this.label16.AutoSize = true;
			this.label16.Location = new Point(101, 162);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 13);
			this.label16.TabIndex = 65;
			this.label16.Text = "Pending Amount:";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(119, 138);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(70, 13);
			this.label11.TabIndex = 64;
			this.label11.Text = "Paid Amount:";
			this.cmbPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbPaymentMode.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.cmbPaymentMode.Items;
			objArray = new object[] { "By Cash", "By Cheque" };
			objectCollections.AddRange(objArray);
			this.cmbPaymentMode.Location = new Point(203, 22);
			this.cmbPaymentMode.Name = "cmbPaymentMode";
			this.cmbPaymentMode.Size = new System.Drawing.Size(132, 21);
			this.cmbPaymentMode.TabIndex = 9;
			this.cmbPaymentMode.SelectedIndexChanged += new EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
			this.cmbPaymentMode.KeyUp += new KeyEventHandler(this.cmbPaymentMode_KeyUp);
			this.cmbPaymentMode.KeyDown += new KeyEventHandler(this.cmbPaymentMode_KeyDown);
			this.txtPendingAmount.BackColor = Color.White;
			this.txtPendingAmount.Location = new Point(203, 162);
			this.txtPendingAmount.Name = "txtPendingAmount";
			this.txtPendingAmount.ReadOnly = true;
			this.txtPendingAmount.Size = new System.Drawing.Size(132, 20);
			this.txtPendingAmount.TabIndex = 14;
			this.txtPendingAmount.TabStop = false;
			this.txtPendingAmount.Leave += new EventHandler(this.txtPendingAmount_Leave);
			this.txtPendingAmount.KeyPress += new KeyPressEventHandler(this.txtPendingAmount_KeyPress);
			this.txtPendingAmount.KeyDown += new KeyEventHandler(this.txtPendingAmount_KeyDown);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(108, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Payment Mode:";
			this.txtpaidAmount.Location = new Point(203, 138);
			this.txtpaidAmount.Name = "txtpaidAmount";
			this.txtpaidAmount.Size = new System.Drawing.Size(132, 20);
			this.txtpaidAmount.TabIndex = 13;
			this.txtpaidAmount.Enter += new EventHandler(this.txtpaidAmount_Enter);
			this.txtpaidAmount.Leave += new EventHandler(this.txtpaidAmount_Leave);
			this.txtpaidAmount.KeyPress += new KeyPressEventHandler(this.txtpaidAmount_KeyPress);
			this.txtpaidAmount.KeyDown += new KeyEventHandler(this.txtpaidAmount_KeyDown);
			this.lblLedger.AutoSize = true;
			this.lblLedger.Location = new Point(100, 49);
			this.lblLedger.Name = "lblLedger";
			this.lblLedger.Size = new System.Drawing.Size(89, 13);
			this.lblLedger.TabIndex = 14;
			this.lblLedger.Text = "Cash/Bank  A/C:";
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.dtpChequeDate);
			this.groupBox2.Controls.Add(this.txtChequeNo);
			this.groupBox2.Location = new Point(88, 73);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(267, 62);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cheque Details";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(29, 42);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(73, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Cheque Date:";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(38, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 13);
			this.label10.TabIndex = 13;
			this.label10.Text = "Cheque No:";
			this.dtpChequeDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpChequeDate.Format = DateTimePickerFormat.Custom;
			this.dtpChequeDate.Location = new Point(116, 35);
			this.dtpChequeDate.Name = "dtpChequeDate";
			this.dtpChequeDate.Size = new System.Drawing.Size(132, 20);
			this.dtpChequeDate.TabIndex = 12;
			this.dtpChequeDate.KeyDown += new KeyEventHandler(this.dtpChequeDate_KeyDown);
			this.txtChequeNo.Location = new Point(116, 9);
			this.txtChequeNo.Name = "txtChequeNo";
			this.txtChequeNo.Size = new System.Drawing.Size(132, 20);
			this.txtChequeNo.TabIndex = 11;
			this.txtChequeNo.KeyDown += new KeyEventHandler(this.txtChequeNo_KeyDown);
			this.cmbCashBankAccount.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbCashBankAccount.FormattingEnabled = true;
			this.cmbCashBankAccount.Location = new Point(203, 49);
			this.cmbCashBankAccount.Name = "cmbCashBankAccount";
			this.cmbCashBankAccount.Size = new System.Drawing.Size(132, 21);
			this.cmbCashBankAccount.TabIndex = 10;
			this.cmbCashBankAccount.KeyDown += new KeyEventHandler(this.cmbCashBankAccount_KeyDown);
			this.btnPaymentBtn.BackColor = Color.SteelBlue;
			this.btnPaymentBtn.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnPaymentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnPaymentBtn.ForeColor = Color.White;
			this.btnPaymentBtn.Location = new Point(341, 49);
			this.btnPaymentBtn.Name = "btnPaymentBtn";
			this.btnPaymentBtn.Size = new System.Drawing.Size(54, 23);
			this.btnPaymentBtn.TabIndex = 36456456;
			this.btnPaymentBtn.TabStop = false;
			this.btnPaymentBtn.Text = "New";
			this.btnPaymentBtn.UseVisualStyleBackColor = false;
			this.btnPaymentBtn.Click += new EventHandler(this.btnPaymentBtn_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(551, 385);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(205, 13);
			this.label4.TabIndex = 36456459;
			this.label4.Text = "------------------------------------------------------------------";
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.ForeColor = Color.Red;
			this.label7.Location = new Point(761, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 13);
			this.label7.TabIndex = 36456458;
			this.label7.Text = "*";
			this.lblRoundedGrandTotal.AutoSize = true;
			this.lblRoundedGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblRoundedGrandTotal.Location = new Point(681, 431);
			this.lblRoundedGrandTotal.Name = "lblRoundedGrandTotal";
			this.lblRoundedGrandTotal.Size = new System.Drawing.Size(32, 13);
			this.lblRoundedGrandTotal.TabIndex = 74;
			this.lblRoundedGrandTotal.Text = "0.00";
			this.lblRoundedGrand.AutoSize = true;
			this.lblRoundedGrand.Location = new Point(571, 431);
			this.lblRoundedGrand.Name = "lblRoundedGrand";
			this.lblRoundedGrand.Size = new System.Drawing.Size(110, 13);
			this.lblRoundedGrand.TabIndex = 73;
			this.lblRoundedGrand.Text = "Rounded GrandTotal:";
			this.lblGrandTotal.AutoSize = true;
			this.lblGrandTotal.Location = new Point(681, 410);
			this.lblGrandTotal.Name = "lblGrandTotal";
			this.lblGrandTotal.Size = new System.Drawing.Size(28, 13);
			this.lblGrandTotal.TabIndex = 71;
			this.lblGrandTotal.Text = "0.00";
			this.lblGrand.AutoSize = true;
			this.lblGrand.Location = new Point(572, 410);
			this.lblGrand.Name = "lblGrand";
			this.lblGrand.Size = new System.Drawing.Size(66, 13);
			this.lblGrand.TabIndex = 70;
			this.lblGrand.Text = "Grand Total:";
			this.label22.AutoSize = true;
			this.label22.Location = new Point(286, 345);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(68, 13);
			this.label22.TabIndex = 69;
			this.label22.Text = "Bill Discount:";
			this.txtBillDiscount.Location = new Point(363, 345);
			this.txtBillDiscount.MaxLength = 6;
			this.txtBillDiscount.Name = "txtBillDiscount";
			this.txtBillDiscount.Size = new System.Drawing.Size(140, 20);
			this.txtBillDiscount.TabIndex = 7;
			this.txtBillDiscount.Enter += new EventHandler(this.txtBillDiscount_Enter);
			this.txtBillDiscount.Leave += new EventHandler(this.txtBillDiscount_Leave);
			this.txtBillDiscount.KeyPress += new KeyPressEventHandler(this.txtBillDiscount_KeyPress);
			this.txtBillDiscount.KeyDown += new KeyEventHandler(this.txtBillDiscount_KeyDown);
			this.txtAdjustment.Location = new Point(120, 345);
			this.txtAdjustment.MaxLength = 6;
			this.txtAdjustment.Name = "txtAdjustment";
			this.txtAdjustment.Size = new System.Drawing.Size(154, 20);
			this.txtAdjustment.TabIndex = 6;
			this.txtAdjustment.Enter += new EventHandler(this.txtAdjustment_Enter);
			this.txtAdjustment.Leave += new EventHandler(this.txtAdjustment_Leave);
			this.txtAdjustment.KeyPress += new KeyPressEventHandler(this.txtAdjustment_KeyPress);
			this.txtAdjustment.KeyDown += new KeyEventHandler(this.txtAdjustment_KeyDown);
			this.label21.AutoSize = true;
			this.label21.Location = new Point(11, 345);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(101, 13);
			this.label21.TabIndex = 66;
			this.label21.Text = "Adjustment Amount:";
			this.lblTotalAmount.AutoSize = true;
			this.lblTotalAmount.Location = new Point(681, 363);
			this.lblTotalAmount.Name = "lblTotalAmount";
			this.lblTotalAmount.Size = new System.Drawing.Size(28, 13);
			this.lblTotalAmount.TabIndex = 65;
			this.lblTotalAmount.Text = "0.00";
			this.lblTotalAmount.TextChanged += new EventHandler(this.lblTotalAmount_TextChanged);
			this.lblTot.AutoSize = true;
			this.lblTot.Location = new Point(572, 362);
			this.lblTot.Name = "lblTot";
			this.lblTot.Size = new System.Drawing.Size(73, 13);
			this.lblTot.TabIndex = 64;
			this.lblTot.Text = "Total Amount:";
			this.lblTaxAmount.AutoSize = true;
			this.lblTaxAmount.Location = new Point(681, 340);
			this.lblTaxAmount.Name = "lblTaxAmount";
			this.lblTaxAmount.Size = new System.Drawing.Size(28, 13);
			this.lblTaxAmount.TabIndex = 63;
			this.lblTaxAmount.Text = "0.00";
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRows.Location = new System.Drawing.Point(471, 274);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(32, 13);
            this.lblRows.TabIndex = 97;
            this.lblRows.Text = "0";

            // 
            // lblCountRows
            // 
            this.lblCountRows.AutoSize = true;
            this.lblCountRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRows.Location = new System.Drawing.Point(419, 274);
            this.lblCountRows.Name = "lblCountRows";
            this.lblCountRows.Size = new System.Drawing.Size(44, 13);
            this.lblCountRows.TabIndex = 96;
            this.lblCountRows.Text = "Count:";
            // 
            this.lblTax.AutoSize = true;
			this.lblTax.Location = new Point(572, 340);
			this.lblTax.Name = "lblTax";
			this.lblTax.Size = new System.Drawing.Size(67, 13);
			this.lblTax.TabIndex = 62;
			this.lblTax.Text = "Tax Amount:";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(11, 363);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 61;
			this.label5.Text = "Description:";
			this.txtDescription.Location = new Point(14, 379);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(260, 55);
			this.txtDescription.TabIndex = 8;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.txtDescription.KeyDown += new KeyEventHandler(this.txtDescription_KeyDown);
			this.label15.AutoSize = true;
			this.label15.Location = new Point(506, 61);
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
			this.label14.Location = new Point(506, 41);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(62, 13);
			this.label14.TabIndex = 51;
			this.label14.Text = "Invoice No:";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(506, 15);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 50;
			this.label13.Text = "Date:";
			this.txtDueDays.Location = new Point(134, 61);
			this.txtDueDays.MaxLength = 15;
			this.txtDueDays.Name = "txtDueDays";
			this.txtDueDays.Size = new System.Drawing.Size(140, 20);
			this.txtDueDays.TabIndex = 4;
			this.txtDueDays.Enter += new EventHandler(this.txtDueDays_Enter);
			this.txtDueDays.Leave += new EventHandler(this.txtDueDays_Leave);
			this.txtDueDays.KeyUp += new KeyEventHandler(this.txtDueDays_KeyUp);
			this.txtDueDays.KeyPress += new KeyPressEventHandler(this.txtDueDays_KeyPress);
			this.txtDueDays.KeyDown += new KeyEventHandler(this.txtDueDays_KeyDown);
			this.lblBlnceAmount.AutoSize = true;
			this.lblBlnceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblBlnceAmount.Location = new Point(616, 61);
			this.lblBlnceAmount.Name = "lblBlnceAmount";
			this.lblBlnceAmount.Size = new System.Drawing.Size(32, 13);
			this.lblBlnceAmount.TabIndex = 47;
			this.lblBlnceAmount.Text = "0.00";
			this.lblVendor.AutoSize = true;
			this.lblVendor.Location = new Point(11, 68);
			this.lblVendor.Name = "lblVendor";
			this.lblVendor.Size = new System.Drawing.Size(44, 13);
			this.lblVendor.TabIndex = 38;
			this.lblVendor.Text = "Vendor:";
			this.lblDueDays.AutoSize = true;
			this.lblDueDays.Location = new Point(11, 68);
			this.lblDueDays.Name = "lblDueDays";
			this.lblDueDays.Size = new System.Drawing.Size(57, 13);
			this.lblDueDays.TabIndex = 38;
			this.lblDueDays.Text = "Due Days:";
			this.btnVendor.BackColor = Color.SteelBlue;
			this.btnVendor.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnVendor.ForeColor = Color.White;
			this.btnVendor.Location = new Point(280, 58);
			this.btnVendor.Name = "btnVendor";
			this.btnVendor.Size = new System.Drawing.Size(54, 23);
			this.btnVendor.TabIndex = 37565;
			this.btnVendor.TabStop = false;
			this.btnVendor.Text = "New";
			this.btnVendor.UseVisualStyleBackColor = false;
			this.btnVendor.Click += new EventHandler(this.btnVendor_Click);
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(619, 8);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(140, 20);
			this.dtpDate.TabIndex = 1;
			this.dtpDate.KeyDown += new KeyEventHandler(this.dtpDate_KeyDown);
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
			this.cmbVendor.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbVendor.FormattingEnabled = true;
			this.cmbVendor.Location = new Point(134, 61);
			this.cmbVendor.Name = "cmbVendor";
			this.cmbVendor.Size = new System.Drawing.Size(140, 21);
			this.cmbVendor.TabIndex = 4;
			this.cmbVendor.Leave += new EventHandler(this.cmbVendor_Leave);
			this.cmbVendor.KeyUp += new KeyEventHandler(this.cmbVendor_KeyUp);
			this.cmbVendor.KeyDown += new KeyEventHandler(this.txtDueDays_KeyDown);
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
			this.label1.Size = new System.Drawing.Size(116, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Purchase Invoice";
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
			base.Name = "frmPurchaseInvoice";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Purchase Invoice";
			base.FormClosing += new FormClosingEventHandler(this.frmPurchaseInvoice_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmPurchaseInvoice_KeyDown);
			base.Load += new EventHandler(this.frmPurchaseInvoice_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.pbxSearch).EndInit();
			this.tcReminder.ResumeLayout(false);
			this.tpPurchase.ResumeLayout(false);
			((ISupportInitialize)this.dgvPurchaseInvoice).EndInit();
			this.tpPayment.ResumeLayout(false);
			this.tpPayment.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
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
				if (this.dgvPurchaseInvoice.CurrentRow != null)
				{
					if (this.rowIndex >= 0)
					{
						if (this.lstbxBatch.Text != "")
						{
							this.dgvPurchaseInvoice.Rows[this.rowIndex].Cells[2].Value = this.lstbxBatch.Text;
						}
						this.dgvPurchaseInvoice.Rows[this.rowIndex].Cells[2].Selected = true;
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
					if (this.dgvPurchaseInvoice.CurrentRow != null)
					{
						if (this.rowIndex >= 0)
						{
							if (this.lstbxBatch.Text != "")
							{
								this.dgvPurchaseInvoice.Rows[this.rowIndex].Cells[2].Value = this.lstbxBatch.Text;
							}
							this.lstbxBatch.Visible = false;
							this.dgvPurchaseInvoice.Focus();
							this.dgvPurchaseInvoice.Rows[this.rowIndex].Cells[2].Selected = true;
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

		private void lstbxBatch_MouseClick(object sender, MouseEventArgs e)
		{
		}

		private void pbxSearch_MouseHover(object sender, EventArgs e)
		{
			this.pbxSearch.Cursor = Cursors.Hand;
		}

		public void ReturnFromPopUp(DataTable dtbl)
		{
			base.Enabled = true;
			int count = this.dgvPurchaseInvoice.Rows.Count - 1;
			this.FillComboItem();
			ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
			ManufacturerSP manufacturerSP = new ManufacturerSP();
			UnitInfo unitInfo = new UnitInfo();
			UnitSP unitSP = new UnitSP();
			ProductInfo productInfo = new ProductInfo();
			foreach (DataRow row in dtbl.Rows)
			{
				bool flag = false;
				foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvPurchaseInvoice.Rows)
				{
					if ((dataGridViewRow.Cells[1].Value == null ? false : dataGridViewRow.Cells[2].Value != null))
					{
						if ((dataGridViewRow.Cells[1].Value.ToString() != row.ItemArray[0].ToString() ? false : dataGridViewRow.Cells[2].Value.ToString() == row.ItemArray[1].ToString()))
						{
							flag = true;
						}
					}
				}
				if (!flag)
				{
					this.dgvPurchaseInvoice.Rows.Add();
					this.dgvPurchaseInvoice.Rows[count].Cells[0].Value = row.ItemArray[0].ToString();
					this.dgvPurchaseInvoice.Rows[count].Cells[1].Value = row.ItemArray[0].ToString();
					this.FillBatchCombo(row.ItemArray[0].ToString());
					this.dgvPurchaseInvoice.Rows[count].Cells[2].Value = row.ItemArray[1].ToString();
					productInfo = this.productsp.ProductView(row.ItemArray[0].ToString());
					manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
					if (manufacturerInfo.ManufactureId != null)
					{
						this.dgvPurchaseInvoice.Rows[count].Cells[7].Value = manufacturerInfo.ManufactureName;
					}
					unitInfo = unitSP.UnitView(productInfo.UnitId);
					if (unitInfo.UnitName != null)
					{
						this.dgvPurchaseInvoice.Rows[count].Cells[10].Value = unitInfo.UnitName;
					}
					count++;
				}
			}
			this.dgvPurchaseInvoice.Focus();
		}

		public void SaveFunction()
		{
			try
			{

                string text = "";
                string str = "";
                string str1 = "";
                this.isRepeated = false;
                if (this.cmbCashVendor.SelectedValue == null)
                {

                    MessageBox.Show("Select cash account/vendor", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.cmbCashVendor.Focus();
                    //invoicedatainfo.CashAccountant = this.cmbCashVendor.SelectedText;
                }
                else if (this.cmbCashVendor.Text == "")
                
                   
                {
                    MessageBox.Show("Select account ledger", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.cmbCashVendor.Focus();
                    //invoicedatainfo.CashAccountant = this.cmbCashVendor.Text;
                   
					
				}
				else if (this.txtInvoice.Text.Trim() == "")
				{
                    this.txtInvoice.Text = text;
                   // invoicedatainfo.InvoiceNo = txtInvoice.Text;

                    MessageBox.Show("Enter invoice number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtInvoice.Focus();
				}
				else if (this.CheckExistName())
				{
					MessageBox.Show("Invoice number already exists", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtInvoice.Focus();
					this.txtInvoice.SelectAll();
				}
				else if (!(!this.cmbVendor.Visible ? true : this.cmbVendor.SelectedValue != null))
				{
                   // invoicedatainfo.Vendor = this.cmbVendor.SelectedValue.ToString();
                    MessageBox.Show("Select vendor", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.cmbVendor.Focus();
				}
				else if (!this.CheckGridNull())
				{
					MessageBox.Show("Incomplete Details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tcReminder.SelectedTab = this.tpPurchase;
					if (this.dgvPurchaseInvoice.Rows.Count > 0)
					{
						this.dgvPurchaseInvoice.Focus();
						this.dgvPurchaseInvoice.ClearSelection();
						this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[0].Cells[0];
						this.dgvPurchaseInvoice.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckBatchNull())
				{
					MessageBox.Show("Incomplete Details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tcReminder.SelectedTab = this.tpPurchase;
					if (this.dgvPurchaseInvoice.Rows.Count > 0)
					{
						this.dgvPurchaseInvoice.Focus();
						this.dgvPurchaseInvoice.ClearSelection();
						this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[0].Cells[0];
						this.dgvPurchaseInvoice.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckQuantityNull())
				{
					MessageBox.Show("Incomplete Details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tcReminder.SelectedTab = this.tpPurchase;
					if (this.dgvPurchaseInvoice.Rows.Count > 0)
					{
						this.dgvPurchaseInvoice.Focus();
						this.dgvPurchaseInvoice.ClearSelection();
						this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[0].Cells[0];
						this.dgvPurchaseInvoice.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckOnSaveForExistenceOfProduct() >= 0)
				{
					int num = this.CheckOnSaveForExistenceOfProduct();
					MessageBox.Show("Repeated product batch exists", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tcReminder.SelectedTab = this.tpPurchase;
					this.dgvPurchaseInvoice.Focus();
					if (this.dgvPurchaseInvoice.Rows.Count > 0)
					{
						this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[num].Cells[0];
						this.dgvPurchaseInvoice.Rows[num].Selected = true;
					}
				}
				else if (!(this.cmbCashBankAccount.SelectedValue == null || this.cmbCashBankAccount.SelectedValue.ToString() == "" ? false : this.cmbCashBankAccount.SelectedIndex != -1))
				{
					if (!(this.cmbPaymentMode.Text == "By Cash"))
					{
						MessageBox.Show("Select bank account", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Select cash account", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					this.cmbCashBankAccount.Focus();
					this.tcReminder.SelectedTab = this.tpPayment;
				}
				else if (this.CheckWhenByBank())
				{
					MessageBox.Show("Enter cheque no", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tcReminder.SelectedTab = this.tpPayment;
					this.txtChequeNo.Focus();
				}
				else if (this.CheckBillDiscount())
				{
					MessageBox.Show("Bill discount cannot be greater than total amount", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtBillDiscount.Focus();
				}
				else if (!this.CheckPaidAmount())
				{
					this.isSaved = true;
					this.DeleteSelectedPurchaseDetailsId();
					this.SaveToPurchaseMaster();
					if (!this.isInEditMode)
					{
						this.SavePaymentDetails();
					}
					this.SavePurchaseLedgerPosting();
					this.SaveToStockPosting();
					if (this.chbxprint.Checked)
					{
					}
					if (!this.isInEditMode)
					{
						MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.ClearFunction();
					}
					else
					{
						MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						base.Close();
					}
				}
				else
				{
					MessageBox.Show("Paid amount cannot be greater than grand total", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tcReminder.SelectedTab = this.tpPayment;
					this.txtpaidAmount.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void SavePaymentDetails()
		{
			try
			{
				if (!this.isInEditMode)
				{
					if (this.isCreditPurchase)
					{
						if (this.txtpaidAmount.Text != "")
						{
							if (decimal.Parse(this.txtpaidAmount.Text) > new decimal(0))
							{
								if ((this.cmbCashBankAccount.SelectedValue == null ? false : this.txtpaidAmount.Text != ""))
								{
									PaymentMasterInfo paymentMasterInfo = new PaymentMasterInfo();
									PaymentDetailsInfo paymentDetailsInfo = new PaymentDetailsInfo();
									PaymentMasterSP paymentMasterSP = new PaymentMasterSP();
									PaymentDetailsSP paymentDetailsSP = new PaymentDetailsSP();
									if (this.cmbCashBankAccount.SelectedValue != null)
									{
										paymentMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
										paymentMasterInfo.LedgerId = this.cmbCashBankAccount.SelectedValue.ToString();
										paymentMasterInfo.Description = this.txtDescription.Text;
										if (!(this.cmbPaymentMode.Text == "By Cheque"))
										{
											paymentMasterInfo.PaymentMode = "By Cash";
											paymentDetailsInfo.ChequeDate = DateTime.Parse("01/01/1753");
											paymentDetailsInfo.ChequeNumber = "";
										}
										else
										{
											paymentMasterInfo.PaymentMode = "By Cheque";
											paymentDetailsInfo.ChequeDate = this.dtpChequeDate.Value;
											paymentDetailsInfo.ChequeNumber = this.txtChequeNo.Text;
										}
										paymentDetailsInfo.Amount = decimal.Parse(this.txtpaidAmount.Text);
										paymentDetailsInfo.VoucherNumber = "";
										paymentDetailsInfo.VoucherType = "";
										paymentDetailsInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
										paymentDetailsInfo.Description = this.txtDescription.Text;
										paymentMasterInfo.PaymentMasterId = paymentMasterSP.PaymentMasterGetMax();
										paymentDetailsInfo.PaymentMasterId = paymentMasterInfo.PaymentMasterId;
										paymentMasterSP.PaymentMasterAdd(paymentMasterInfo);
										paymentDetailsSP.PaymentDetailsAdd(paymentDetailsInfo);
										this.DoPaymentLedgerPosting(paymentMasterInfo.PaymentMasterId);
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

		public void SavePurchaseLedgerPosting()
		{
			try
			{
                
				LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo()
				{
                    
                    
					VoucherNumber = this.txtVoucherNo.Text,
                   
					VoucherType = "Purchase Invoice",
					Description = "By purchase",
					Date = DateTime.Parse(this.dtpDate.Text)
				};
				if (this.isInEditMode)
				{
					DataTable dataTable = this.ledgerpostingsp.LedgerPostingViewByVoucherTypeAndVoucherNumber(this.txtVoucherNo.Text, "Purchase Invoice");
					if (dataTable.Rows.Count > 0)
					{
						ledgerPostingInfo.LedgerPostingId = dataTable.Rows[0][0].ToString();
						ledgerPostingInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
						ledgerPostingInfo.Credit = decimal.Parse(this.lblGrandTotal.Text);
						ledgerPostingInfo.Debit = new decimal(0);
						this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
						ledgerPostingInfo.LedgerPostingId = dataTable.Rows[1][0].ToString();
						ledgerPostingInfo.LedgerId = "1";
						ledgerPostingInfo.Debit = decimal.Parse(this.lblGrandTotal.Text);
						ledgerPostingInfo.Credit = new decimal(0);
						this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
					}
				}
				else
				{
					ledgerPostingInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
					ledgerPostingInfo.Credit = decimal.Parse(this.lblGrandTotal.Text);
					ledgerPostingInfo.Debit = new decimal(0);
					this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
					ledgerPostingInfo.LedgerId = "1";
					ledgerPostingInfo.Debit = decimal.Parse(this.lblGrandTotal.Text);
					ledgerPostingInfo.Credit = new decimal(0);
					this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void SaveToPurchaseMaster()
		{
			bool flag;
			bool flag1;
			try
			{
				string text = "";
				string str = "";
				string str1 = "";
				PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
				PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
				PurchaseDetailsInfo purchaseDetailsInfo = new PurchaseDetailsInfo();
				PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				ProductBatchInfo productBatchInfo1 = new ProductBatchInfo();
				if ((!(this.txtVoucherNo.Text != "") || this.cmbCashVendor.SelectedValue == null ? false : this.txtInvoice.Text != ""))
				{
					if (this.isInEditMode)
					{
						text = this.txtVoucherNo.Text;
                        invoicedatainfo.vocherNo = this.txtVoucherNo.Text;
                       // invoicedatainfo.vocherNo = this.txtVoucherNo.SelectedText.ToString();

                    }
					else
					{
						text = this.GetMaxofPurchaseMasterId();
						if (text != this.txtVoucherNo.Text)
						{
                            invoicedatainfo.vocherNo = this.txtVoucherNo.Text;
							MessageBox.Show(string.Concat("Voucher number changed from ", this.txtVoucherNo.Text, "to ", text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					this.txtVoucherNo.Text = text;
                    invoicedatainfo.vocherNo = this.txtVoucherNo.Text;
                    purchaseMasterInfo.PurchaseMasterId = text;
					purchaseMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
                    invoicedatainfo.SaleDate = DateTime.Parse(this.dtpDate.Text);
                    purchaseMasterInfo.LedgerId = this.cmbCashVendor.SelectedValue.ToString();
					if (this.txtDueDays.Text.Trim() == "")
					{
						this.txtDueDays.Text = "0";
					}
					purchaseMasterInfo.DueDays = int.Parse(this.txtDueDays.Text);
					purchaseMasterInfo.PurchaseInvoiceNo = this.txtInvoice.Text.Trim();
					if (this.txtBillDiscount.Text.Trim() == "")
					{
						this.txtBillDiscount.Text = "0.00";
					}
					purchaseMasterInfo.BillDiscount = decimal.Parse(this.txtBillDiscount.Text);
					purchaseMasterInfo.Description = this.txtDescription.Text.Trim();
					if (this.txtAdjustment.Text.Trim() == "")
					{
						this.txtAdjustment.Text = "0.00";
					}
					purchaseMasterInfo.AdditionalCost = decimal.Parse(this.txtAdjustment.Text);
					if (!(accountLedgerSP.AccountLedgerView(this.cmbCashVendor.SelectedValue.ToString()).AccountGroupId == "11"))
					{
						purchaseMasterInfo.VendorId = "";
					}
					else
					{
						purchaseMasterInfo.VendorId = this.cmbVendor.SelectedValue.ToString();
					}
					if (this.isInEditMode)
					{
						foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseInvoice.Rows)
						{
							if (row.DefaultCellStyle.BackColor != Color.Cornsilk)
							{
								if (row.Cells[18].Value != null)
								{
									purchaseDetailsSP.PurchaseDetailsDelete(row.Cells[18].Value.ToString());
								}
							}
						}
					}
					foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvPurchaseInvoice.Rows)
					{
						if (dataGridViewRow.Cells[0].Value == null || dataGridViewRow.Cells[1].Value == null || dataGridViewRow.Cells[2].Value == null)
						{
							flag = true;
						}
						else
						{
							flag = (dataGridViewRow.Cells[8].Value != null ? false : dataGridViewRow.Cells[9].Value == null);
						}
						if (!flag)
						{
							if (!(dataGridViewRow.Cells[0].Value.ToString() != "") || !(dataGridViewRow.Cells[1].Value.ToString() != "") || !(dataGridViewRow.Cells[2].Value.ToString() != ""))
							{
								flag1 = true;
							}
							else
							{
								flag1 = (dataGridViewRow.Cells[8].Value.ToString() != "" ? false : !(dataGridViewRow.Cells[9].Value.ToString() != ""));
							}
							if (!flag1)
							{
								if (dataGridViewRow.Cells[2].Value != null)
								{
									if (dataGridViewRow.Cells[2].Value.ToString() != "")
									{
										productBatchInfo.ProductId = dataGridViewRow.Cells[1].Value.ToString();
										if (dataGridViewRow.Cells[2].Value == null)
										{
											productBatchInfo.BatchName = "";
										}
										else if (!(dataGridViewRow.Cells[2].Value.ToString() == ""))
										{
											productBatchInfo.BatchName = dataGridViewRow.Cells[2].Value.ToString();
										}
										else
										{
											productBatchInfo.BatchName = "";
										}
										if (dataGridViewRow.Cells[3].Value == null)
										{
											productBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
										}
										else if (!(dataGridViewRow.Cells[3].Value.ToString() == ""))
										{
											productBatchInfo.ExpiryDate = DateTime.Parse(dataGridViewRow.Cells[3].Value.ToString());
											productBatchInfo.ExpiryDate = productBatchInfo.ExpiryDate.Date;
										}
										else
										{
											productBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
										}
										if (dataGridViewRow.Cells[2].Value.ToString() == "NA")
										{
											productBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
										}
										if (dataGridViewRow.Cells[4].Value == null)
										{
											productBatchInfo.PurchaseRate = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[4].Value.ToString() == ""))
										{
											productBatchInfo.PurchaseRate = decimal.Parse(dataGridViewRow.Cells[4].Value.ToString());
										}
										else
										{
											productBatchInfo.PurchaseRate = new decimal(0);
										}
										if (dataGridViewRow.Cells[5].Value == null)
										{
											productBatchInfo.SalesRate = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[5].Value.ToString() == ""))
										{
											productBatchInfo.SalesRate = decimal.Parse(dataGridViewRow.Cells[5].Value.ToString());
										}
										else
										{
											productBatchInfo.SalesRate = new decimal(0);
										}
										if (dataGridViewRow.Cells[6].Value == null)
										{
											productBatchInfo.MRP = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[6].Value.ToString() == ""))
										{
											productBatchInfo.MRP = decimal.Parse(dataGridViewRow.Cells[6].Value.ToString());
										}
										else
										{
											productBatchInfo.MRP = new decimal(0);
										}
										productBatchInfo.Description = "";
										str1 = "";
										string str2 = dataGridViewRow.Cells[1].Value.ToString();
										string str3 = dataGridViewRow.Cells[2].Value.ToString();
										DataTable dataTable = new DataTable();
										dataTable = productBatchSP.ProductBatchViewByProductAndBatchName(str2, str3);
										if (dataTable.Rows.Count > 0)
										{
											str1 = dataTable.Rows[0].ItemArray[0].ToString();
										}
										if (!(str1 != ""))
										{
											str = productBatchSP.ProductBatchAdd(productBatchInfo);
										}
										else
										{
											productBatchInfo1 = productBatchSP.ProductBatchView(str1);
											if (productBatchInfo1.ProductBatchId == null)
											{
												str = productBatchSP.ProductBatchAdd(productBatchInfo);
											}
											else if ((str1 != productBatchInfo1.ProductBatchId ? true : !(dataGridViewRow.Cells[1].Value.ToString() == productBatchInfo1.ProductId)))
											{
												str = productBatchSP.ProductBatchAdd(productBatchInfo);
											}
											else
											{
												productBatchInfo.ProductBatchId = str1;
												if (dataGridViewRow.Cells[4].Value == null)
												{
													productBatchInfo.PurchaseRate = productBatchInfo1.PurchaseRate;
												}
												else if (dataGridViewRow.Cells[4].Value.ToString() == "")
												{
													productBatchInfo.PurchaseRate = productBatchInfo1.PurchaseRate;
												}
												else if (!(decimal.Parse(dataGridViewRow.Cells[4].Value.ToString()) == new decimal(0)))
												{
													productBatchInfo.PurchaseRate = decimal.Parse(dataGridViewRow.Cells[4].Value.ToString());
												}
												else
												{
													productBatchInfo.PurchaseRate = productBatchInfo1.PurchaseRate;
												}
												if (dataGridViewRow.Cells[5].Value == null)
												{
													productBatchInfo.SalesRate = productBatchInfo1.SalesRate;
												}
												else if (dataGridViewRow.Cells[5].Value.ToString() == "")
												{
													productBatchInfo.SalesRate = productBatchInfo1.SalesRate;
												}
												else if (!(decimal.Parse(dataGridViewRow.Cells[5].Value.ToString()) == new decimal(0)))
												{
													productBatchInfo.SalesRate = decimal.Parse(dataGridViewRow.Cells[5].Value.ToString());
												}
												else
												{
													productBatchInfo.SalesRate = productBatchInfo1.SalesRate;
												}
												if (dataGridViewRow.Cells[6].Value == null)
												{
													productBatchInfo.MRP = productBatchInfo1.MRP;
												}
												else if (dataGridViewRow.Cells[6].Value.ToString() == "")
												{
													productBatchInfo.MRP = productBatchInfo1.MRP;
												}
												else if (!(decimal.Parse(dataGridViewRow.Cells[6].Value.ToString()) == new decimal(0)))
												{
													productBatchInfo.MRP = decimal.Parse(dataGridViewRow.Cells[6].Value.ToString());
												}
												else
												{
													productBatchInfo.MRP = productBatchInfo1.MRP;
												}
												productBatchSP.ProductBatchEdit(productBatchInfo);
												str = str1;
											}
										}
										purchaseDetailsInfo.PurchaseMasterId = text;
										purchaseDetailsInfo.ProductBatchId = str;
										if (dataGridViewRow.Cells[4].Value == null)
										{
											purchaseDetailsInfo.Rate = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[4].Value.ToString() == ""))
										{
											purchaseDetailsInfo.Rate = decimal.Parse(dataGridViewRow.Cells[4].Value.ToString());
										}
										else
										{
											purchaseDetailsInfo.Rate = new decimal(0);
										}
										if (dataGridViewRow.Cells[12].Value == null)
										{
											purchaseDetailsInfo.Discount = 0f;
										}
										else if (!(dataGridViewRow.Cells[12].Value.ToString() == ""))
										{
											purchaseDetailsInfo.Discount = float.Parse(dataGridViewRow.Cells[12].Value.ToString());
										}
										else
										{
											purchaseDetailsInfo.Discount = 0f;
										}
										if (dataGridViewRow.Cells[8].Value == null)
										{
											purchaseDetailsInfo.Qty = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[8].Value.ToString() == ""))
										{
											purchaseDetailsInfo.Qty = decimal.Parse(dataGridViewRow.Cells[8].Value.ToString());
										}
										else
										{
											purchaseDetailsInfo.Qty = new decimal(0);
										}
										if (dataGridViewRow.Cells[9].Value == null)
										{
											purchaseDetailsInfo.FreeQty = new decimal(0);
										}
										else if (!(dataGridViewRow.Cells[9].Value.ToString() == ""))
										{
											purchaseDetailsInfo.FreeQty = decimal.Parse(dataGridViewRow.Cells[9].Value.ToString());
										}
										else
										{
											purchaseDetailsInfo.FreeQty = new decimal(0);
										}
										if (dataGridViewRow.Cells[14].Value == null)
										{
											purchaseDetailsInfo.TaxIncludedOrNot = false;
											purchaseDetailsInfo.TaxPercentage = 0f;
										}
										else if (!(dataGridViewRow.Cells[14].Value.ToString() == ""))
										{
											if (!(dataGridViewRow.Cells[14].Value.ToString() == "Excluded"))
											{
												purchaseDetailsInfo.TaxIncludedOrNot = false;
											}
											else
											{
												purchaseDetailsInfo.TaxIncludedOrNot = true;
											}
											if (dataGridViewRow.Cells[15].Value == null)
											{
												purchaseDetailsInfo.TaxPercentage = 0f;
											}
											else if (!(dataGridViewRow.Cells[15].Value.ToString() == ""))
											{
												purchaseDetailsInfo.TaxPercentage = float.Parse(dataGridViewRow.Cells[15].Value.ToString());
											}
											else
											{
												purchaseDetailsInfo.TaxPercentage = 0f;
											}
										}
										else
										{
											purchaseDetailsInfo.TaxIncludedOrNot = false;
											purchaseDetailsInfo.TaxPercentage = 0f;
										}
										purchaseDetailsInfo.Description = "";
										if (!(dataGridViewRow.DefaultCellStyle.BackColor == Color.Cornsilk))
										{
											purchaseDetailsSP.PurchaseDetailsAdd(purchaseDetailsInfo);
										}
										else
										{
											purchaseDetailsInfo.PurchaseDetailsId = dataGridViewRow.Cells[18].Value.ToString();
											purchaseDetailsSP.PurchaseDetailsEdit(purchaseDetailsInfo);
										}
									}
								}
							}
						}
					}
					if (this.isInEditMode)
					{
						purchaseMasterSP.PurchaseMasterEdit(purchaseMasterInfo);
					}
					else
					{
						purchaseMasterSP.PurchaseMasterAdd(purchaseMasterInfo);
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
				PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
				DataTable dataTable = new DataTable();
				if (this.txtVoucherNo.Text != "")
				{
					if (this.isInEditMode)
					{
						stockPostingSP.StockPostingDeleteByVoucherAndType(this.txtVoucherNo.Text, "Purchase Invoice");
					}
					dataTable = purchaseDetailsSP.PurchaseDetailsViewAllByMasterId(this.txtVoucherNo.Text);
					foreach (DataRow row in dataTable.Rows)
					{
						stockPostingInfo.VoucherNumber = row.ItemArray[1].ToString();
						stockPostingInfo.ProductBatchId = row.ItemArray[2].ToString();
						num = decimal.Parse(row.ItemArray[5].ToString()) + decimal.Parse(row.ItemArray[6].ToString());
						stockPostingInfo.InwardQuantity = num;
						stockPostingInfo.OutwardQuantity = new decimal(0);
						stockPostingInfo.VoucherType = "Purchase Invoice";
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

		private void tcReminder_Selecting(object sender, TabControlCancelEventArgs e)
		{
			try
			{
				if (e.TabPage == this.tpPayment)
				{
					if ((!this.isCreditPurchase ? false : !this.isInEditMode))
					{
						if (this.txtpaidAmount.Text == "")
						{
							this.txtpaidAmount.Text = this.lblGrandTotal.Text;
							this.txtPendingAmount.Text = "0.00";
						}
						else if (decimal.Parse(this.txtpaidAmount.Text) == new decimal(0))
						{
							this.txtpaidAmount.Text = this.lblGrandTotal.Text;
							this.txtPendingAmount.Text = "0.00";
						}
						base.ActiveControl = this.cmbPaymentMode;
						e.Cancel = false;
					}
					else
					{
						base.ActiveControl = this.cmbPaymentMode;
						e.Cancel = true;
					}
				}
				else if (this.dgvPurchaseInvoice.Rows.Count > 0)
				{
					this.dgvPurchaseInvoice.Focus();
					this.dgvPurchaseInvoice.ClearSelection();
					this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[0].Cells[0];
					this.dgvPurchaseInvoice.Rows[0].Cells[0].Selected = true;
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
				if ((this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 4 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 5 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 5 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 6 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 8 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 9 || this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 12 ? true : this.dgvPurchaseInvoice.CurrentCell.ColumnIndex == 15))
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

		private void txtAdjustment_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtAdjustment.Text) == new decimal(0))
				{
					this.txtAdjustment.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtAdjustment.Text = "";
			}
		}

		private void txtAdjustment_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					SendKeys.Send("{TAB}");
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtAdjustment.Text == "" ? true : this.txtAdjustment.SelectionStart == 0))
					{
						if (this.tcReminder.SelectedTab != this.tpPurchase)
						{
							this.txtpaidAmount.Focus();
							this.txtpaidAmount.SelectionStart = 0;
						}
						else if (this.dgvPurchaseInvoice.Rows.Count > 0)
						{
							int count = 0;
							count = this.dgvPurchaseInvoice.Rows.Count;
							this.dgvPurchaseInvoice.Focus();
						}
						else if (!this.txtDueDays.Visible)
						{
							this.cmbVendor.Focus();
						}
						else
						{
							this.txtDueDays.Focus();
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

		private void txtAdjustment_KeyPress(object sender, KeyPressEventArgs e)
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
						string text = this.txtAdjustment.Text;
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

		private void txtAdjustment_Leave(object sender, EventArgs e)
		{
			try
			{
				this.CalculateTotal();
			}
			catch
			{
				this.txtAdjustment.Text = "0.00";
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
						this.txtAdjustment.Focus();
						this.txtAdjustment.SelectionStart = 0;
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

		private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode != Keys.Return ? false : this.txtChequeNo.Text.Trim() != ""))
				{
					SendKeys.Send("{TAB}");
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtChequeNo.Text == "" ? true : this.txtChequeNo.SelectionStart == 0))
					{
						this.cmbCashBankAccount.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtDescription.Text == "" ? true : this.txtDescription.SelectionStart == 0))
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
					frmPurchaseInvoice _frmPurchaseInvoice = this;
					_frmPurchaseInvoice.inDescriptionCount = _frmPurchaseInvoice.inDescriptionCount + 1;
					if (this.inDescriptionCount == 2)
					{
						this.inDescriptionCount = 0;
						this.btnSave.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtDueDays_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtDueDays.Text) == new decimal(0))
				{
					this.txtDueDays.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtDueDays.Text = "";
			}
		}

		private void txtDueDays_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
				if (e.KeyCode == Keys.Return)
				{
					if (this.tcReminder.SelectedTab != this.tpPurchase)
					{
						this.cmbPaymentMode.Focus();
					}
					else if (this.dgvPurchaseInvoice.Rows.Count > 0)
					{
						this.dgvPurchaseInvoice.ClearSelection();
						this.dgvPurchaseInvoice.CurrentCell = this.dgvPurchaseInvoice.Rows[0].Cells[0];
						this.dgvPurchaseInvoice.Focus();
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

		private void txtDueDays_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtDueDays.Text == "" ? true : this.txtDueDays.SelectionStart == 0))
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

		private void txtDueDays_Leave(object sender, EventArgs e)
		{
			try
			{
				decimal.Parse(this.txtDueDays.Text);
				if (this.dgvPurchaseInvoice.Focused)
				{
					this.p = 1;
				}
			}
			catch
			{
				this.txtDueDays.Text = "0";
			}
		}

		private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode != Keys.Return ? false : this.txtInvoice.Text.Trim() != ""))
				{
					SendKeys.Send("{TAB}");
					if (this.cmbVendor.Visible)
					{
					}
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

		private void txtpaidAmount_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtpaidAmount.Text) == new decimal(0))
				{
					this.txtpaidAmount.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtpaidAmount.Text = "";
			}
		}

		private void txtpaidAmount_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode != Keys.Return ? false : this.txtpaidAmount.Text.Trim() != ""))
				{
					this.txtAdjustment.Focus();
				}
				if (e.KeyCode == Keys.Back)
				{
					if ((this.txtpaidAmount.Text == "" ? true : this.txtpaidAmount.SelectionStart == 0))
					{
						if (!this.dtpChequeDate.Enabled)
						{
							this.cmbCashBankAccount.Focus();
						}
						else
						{
							this.dtpChequeDate.Focus();
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

		private void txtpaidAmount_KeyPress(object sender, KeyPressEventArgs e)
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
						string text = this.txtpaidAmount.Text;
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

		private void txtpaidAmount_Leave(object sender, EventArgs e)
		{
			try
			{
				this.CalculateGrandTotal();
			}
			catch
			{
				this.txtpaidAmount.Text = "0.00";
			}
		}

		private void txtPendingAmount_KeyDown(object sender, KeyEventArgs e)
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

		private void txtPendingAmount_KeyPress(object sender, KeyPressEventArgs e)
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
						string text = this.txtPendingAmount.Text;
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

		private void txtPendingAmount_Leave(object sender, EventArgs e)
		{
			try
			{
				decimal.Parse(this.txtPendingAmount.Text);
			}
			catch
			{
				this.txtPendingAmount.Text = "0.00";
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