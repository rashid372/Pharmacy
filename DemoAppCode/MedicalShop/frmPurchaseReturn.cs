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
	public class frmPurchaseReturn : Form
	{
		private bool isSaved = false;

		private ProductSP productsp = new ProductSP();

		private DataTable dtblRemovedPurchaseReturnId = new DataTable();

		private LedgerPostingSP ledgerpostingsp = new LedgerPostingSP();

		private bool isInEditMode = false;

		private string strDefaultCurrency = "";

		private bool isFormClose = false;

		private frmPurchaseReturnRegister frmRegister;

		private int inDescriptionCount = 0;

		private bool isAnyReturn = false;

		private string CashBankAccount = "";

		private string AccountLedger = "";

		private int p = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label lblBlnceAmount;

		private DateTimePicker dtpDate;

		private Label lblCashOrParty;

		private TextBox txtVoucherNo;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private TextBox txtCashVendor;

		private Label label14;

		private Label label13;

		private TextBox txtVendor;

		private ComboBox cmbInvoice;

		private Label label15;

		private dgv.DataGridViewEnter dgvPurchaseReturn;

		private Label label5;

		private TextBox txtDescription;

		private Label lblRoundedGrandTotal;

		private Label lblRoundedGrand;

		private Label lblGrandTotal;

		private Label lblGrand;

		private CheckBox chbxprint;

		private Label lblVendor;

		private Button btnRemove;

		private Label label7;

		private GroupBox groupBox1;

		private ComboBox cmbSearchBy;

		private TextBox txtSearchFor;

		private Label lblSearchFor;

		private Label label3;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn cmbProduct;

		private DataGridViewTextBoxColumn cmbBatch;

		private DateInGrid.CalendarColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column7;

		private DataGridViewTextBoxColumn Column8;

		private DataGridViewTextBoxColumn Column9;

		private DataGridViewTextBoxColumn Column10;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column11;

		private DataGridViewTextBoxColumn Column12;

		private DataGridViewTextBoxColumn Column13;

		private DataGridViewTextBoxColumn Column14;

		private DataGridViewTextBoxColumn Column15;

		private DataGridViewTextBoxColumn Column16;

		private DataGridViewTextBoxColumn Column17;

		private DataGridViewTextBoxColumn Column18;

		private DataGridViewTextBoxColumn Column19;

		public frmPurchaseReturn()
		{
			this.InitializeComponent();
		}

		public void AssignCurrentBalance()
		{
			try
			{
				if ((this.cmbInvoice.SelectedValue == null ? true : !(this.cmbInvoice.SelectedValue.ToString() != "")))
				{
					this.lblBlnceAmount.Text = "0.00 ";
					this.lblBlnceAmount.BackColor = Color.Black;
					this.lblBlnceAmount.BackColor = Color.Transparent;
				}
				else
				{
					DataTable dataTable = new DataTable();
					dataTable = this.ledgerpostingsp.LedgerPostingGetCurerntBalanceOfLedger(this.cmbInvoice.SelectedValue.ToString(), DateTime.Parse(this.dtpDate.Text));
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
						else if (!(dataTable.Rows[0][2].ToString() == "True"))
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

		private void btnRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvPurchaseReturn.CurrentRow != null)
				{
					try
					{
						if (this.dgvPurchaseReturn.Rows.Count != 1)
						{
							this.dgvPurchaseReturn.Rows.RemoveAt(this.dgvPurchaseReturn.CurrentCell.RowIndex);
						}
						else
						{
							this.dgvPurchaseReturn.Rows.Clear();
						}
					}
					catch (Exception exception)
					{
					}
					if (this.dgvPurchaseReturn.Rows.Count > 0)
					{
						this.dgvPurchaseReturn.Focus();
						this.dgvPurchaseReturn.CurrentCell = this.dgvPurchaseReturn.Rows[0].Cells[0];
					}
					this.CalculateTotal();
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
					this.txtDescription.SelectionLength = 0;
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
				if (this.dgvPurchaseReturn.Rows.Count > 0)
				{
					decimal num = new decimal(0);
					foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseReturn.Rows)
					{
						if (row.Cells[1].Value != null)
						{
							if (row.Cells[1].Value.ToString() != "")
							{
								if (row.Cells[18].Value != null)
								{
									if (row.Cells[18].Value.ToString() != "")
									{
										num = num + decimal.Parse(row.Cells[18].Value.ToString());
									}
								}
							}
						}
					}
					this.lblGrandTotal.Text = num.ToString();
					Label label = this.lblRoundedGrandTotal;
					decimal num1 = Math.Round(num, 2);
					label.Text = string.Concat(num1.ToString(), this.strDefaultCurrency);
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

		public bool CheckExistName()
		{
			PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
			PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
			bool flag = true;
			try
			{
				if (this.txtCashVendor.Text.Trim() != "")
				{
					string str = this.txtCashVendor.Text.Trim();
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
			bool flag1;
			bool flag2 = false;
			try
			{
				if (this.dgvPurchaseReturn.Rows.Count > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseReturn.Rows)
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
							if (!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != ""))
							{
								flag1 = true;
							}
							else
							{
								flag1 = (row.Cells[8].Value.ToString() != "" ? false : !(row.Cells[9].Value.ToString() != ""));
							}
							if (!flag1)
							{
								flag2 = true;
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
			return flag2;
		}

		public bool CheckQuantityNull()
		{
			bool flag = false;
			try
			{
				foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseReturn.Rows)
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
								}
								else if (!(row.Cells[9].Value.ToString() == ""))
								{
									flag = (!(decimal.Parse(row.Cells[9].Value.ToString()) == new decimal(0)) ? false : true);
								}
								else
								{
									flag = true;
								}
							}
							else if (!(row.Cells[8].Value.ToString() == ""))
							{
								if (decimal.Parse(row.Cells[8].Value.ToString()) == new decimal(0))
								{
									if (row.Cells[9].Value == null)
									{
										flag = true;
									}
									else if (!(row.Cells[9].Value.ToString() == ""))
									{
										flag = (!(decimal.Parse(row.Cells[9].Value.ToString()) == new decimal(0)) ? false : true);
									}
									else
									{
										flag = true;
									}
								}
							}
							else if (row.Cells[9].Value == null)
							{
								flag = true;
							}
							else if (!(row.Cells[9].Value.ToString() == ""))
							{
								flag = (!(decimal.Parse(row.Cells[9].Value.ToString()) == new decimal(0)) ? false : true);
							}
							else
							{
								flag = true;
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
				base.ActiveControl = this.dtpDate;
				this.txtVoucherNo.Text = this.GetMaxofPurchaseReturnMasterId();
				this.FillComboInvoice();
				this.cmbInvoice.SelectedIndex = -1;
				this.dtpDate.Text = "";
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.frmRegister.Close();
				}
				this.isInEditMode = false;
				this.isAnyReturn = false;
				this.txtCashVendor.Text = "";
				this.lblCashOrParty.Text = "Cash Account";
				this.txtVendor.Text = "";
				this.dgvPurchaseReturn.Rows.Clear();
				this.txtDescription.Text = "";
				this.lblGrandTotal.Text = "0.00";
				this.lblRoundedGrandTotal.Text = "0.00";
				this.chbxprint.Checked = false;
				this.btnDelete.Enabled = false;
				this.btnClear.Text = "C&lear";
				this.dtblRemovedPurchaseReturnId.Rows.Clear();
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
				if ((e.KeyCode != Keys.Return ? false : this.cmbInvoice.Text != ""))
				{
					if (e.KeyCode == Keys.Return)
					{
						if (this.dgvPurchaseReturn.Rows.Count > 0)
						{
							this.dgvPurchaseReturn.Focus();
							this.dgvPurchaseReturn.ClearSelection();
							this.dgvPurchaseReturn.CurrentCell = this.dgvPurchaseReturn.Rows[0].Cells[10];
							this.dgvPurchaseReturn.Rows[0].Cells[10].Selected = true;
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

		private void cmbInvoice_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
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

		private void cmbInvoice_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtVoucherNo.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.btnClear.Focused ? false : !this.isFormClose))
					{
						if ((this.cmbInvoice.SelectedValue == null ? true : this.cmbInvoice.SelectedIndex == -1))
						{
							this.cmbInvoice.Focus();
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

		private void cmbInvoice_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cmbInvoice.SelectedValue != null)
				{
					if (this.cmbInvoice.Text != "")
					{
						this.dgvPurchaseReturn.Rows.Clear();
						bool flag = true;
						bool flag1 = false;
						decimal num = new decimal(0, 0, 0, false, 2);
						decimal num1 = new decimal(0, 0, 0, false, 2);
						decimal num2 = new decimal(0, 0, 0, false, 2);
						decimal num3 = new decimal(0, 0, 0, false, 2);
						decimal num4 = new decimal(0, 0, 0, false, 2);
						decimal num5 = new decimal(0, 0, 0, false, 2);
						string str = "";
						PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
						PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
						AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
						AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
						VendorSP vendorSP = new VendorSP();
						VendorInfo vendorInfo = new VendorInfo();
						ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
						ManufacturerSP manufacturerSP = new ManufacturerSP();
						UnitInfo unitInfo = new UnitInfo();
						UnitSP unitSP = new UnitSP();
						PurchaseReturnDetailsSP purchaseReturnDetailsSP = new PurchaseReturnDetailsSP();
						PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
						ProductBatchInfo productBatchInfo = new ProductBatchInfo();
						ProductBatchSP productBatchSP = new ProductBatchSP();
						ProductInfo productInfo = new ProductInfo();
						purchaseMasterInfo = purchaseMasterSP.PurchaseMasterView(this.cmbInvoice.SelectedValue.ToString());
						if (purchaseMasterInfo.PurchaseMasterId != null)
						{
							accountLedgerInfo = accountLedgerSP.AccountLedgerView(purchaseMasterInfo.LedgerId);
							if (accountLedgerInfo.LedgerId != null)
							{
								this.txtCashVendor.Text = accountLedgerInfo.AcccountLedgerName;
							}
							if (!(accountLedgerInfo.AccountGroupId == "11"))
							{
								this.lblCashOrParty.Text = "Party Account";
								this.lblVendor.Visible = false;
								this.txtVendor.Visible = false;
							}
							else
							{
								this.lblCashOrParty.Text = "Cash Account";
								this.lblVendor.Visible = true;
								this.txtVendor.Visible = true;
								if (purchaseMasterInfo.VendorId != "")
								{
									vendorInfo = vendorSP.VendorView(purchaseMasterInfo.VendorId);
									this.txtVendor.Text = vendorInfo.VendorName;
								}
							}
							DataTable dataTable = new DataTable();
							DataTable dataTable1 = new DataTable();
							int productId = 0;
							dataTable = purchaseDetailsSP.PurchaseDetailsPendingForReturn(purchaseMasterInfo.PurchaseMasterId);
							if (dataTable.Rows.Count > 0)
							{
								foreach (DataRow row in dataTable.Rows)
								{
									flag1 = false;
									if (!this.isInEditMode)
									{
										if (decimal.Parse(row.ItemArray[6].ToString()) == new decimal(0))
										{
											flag1 = true;
										}
									}
									if (!flag1)
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
											this.dgvPurchaseReturn.Rows.Add();
											productBatchInfo = productBatchSP.ProductBatchView(row.ItemArray[1].ToString());
											this.dgvPurchaseReturn.Rows[productId].Cells[0].Value = productBatchInfo.ProductId;
											productInfo = this.productsp.ProductView(productBatchInfo.ProductId);
											this.dgvPurchaseReturn.Rows[productId].Cells[1].Value = productInfo.ProductName;
											this.dgvPurchaseReturn.Rows[productId].Cells[2].Value = productBatchInfo.BatchName;
											if (!(productBatchInfo.ExpiryDate.ToString() == "01/01/1753"))
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[3].Value = productBatchInfo.ExpiryDate;
											}
											else
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[3].Value = "";
											}
											this.dgvPurchaseReturn.Rows[productId].Cells[4].Value = row.ItemArray[2].ToString();
											this.dgvPurchaseReturn.Rows[productId].Cells[5].Value = productBatchInfo.SalesRate;
											this.dgvPurchaseReturn.Rows[productId].Cells[6].Value = productBatchInfo.MRP;
											manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
											this.dgvPurchaseReturn.Rows[productId].Cells[7].Value = manufacturerInfo.ManufactureName;
											if (this.isInEditMode)
											{
												dataTable1 = purchaseReturnDetailsSP.PurchaseReturnDetailsViewAllByMasterId(this.txtVoucherNo.Text);
												foreach (DataRow dataRow in dataTable1.Rows)
												{
													decimal num6 = decimal.Parse(dataRow.ItemArray[3].ToString());
													decimal num7 = decimal.Parse(row.ItemArray[6].ToString());
													if (!(dataRow.ItemArray[2].ToString() == row.ItemArray[0].ToString()))
													{
														this.dgvPurchaseReturn.Rows[productId].Cells[8].Value = Math.Round(num7, 2);
														this.dgvPurchaseReturn.Rows[productId].Cells[9].Value = 0;
														this.dgvPurchaseReturn.Rows[productId].Cells[10].Value = 0;
													}
													else
													{
														if (!(num6 != new decimal(0)))
														{
															this.dgvPurchaseReturn.Rows[productId].Cells[8].Value = Math.Round(num7, 2);
															this.dgvPurchaseReturn.Rows[productId].Cells[9].Value = 0;
															this.dgvPurchaseReturn.Rows[productId].Cells[10].Value = 0;
														}
														else
														{
															this.dgvPurchaseReturn.Rows[productId].Cells[8].Value = Math.Round(num7 + num6, 2);
															this.dgvPurchaseReturn.Rows[productId].Cells[9].Value = 0;
															DataGridViewCell item = this.dgvPurchaseReturn.Rows[productId].Cells[10];
															double num8 = double.Parse(num6.ToString());
															item.Value = num8.ToString();
														}
														break;
													}
												}
											}
											else
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[8].Value = row.ItemArray[6].ToString();
												this.dgvPurchaseReturn.Rows[productId].Cells[9].Value = 0;
												this.dgvPurchaseReturn.Rows[productId].Cells[10].Value = 0;
											}
											unitInfo = unitSP.UnitView(productInfo.UnitId);
											this.dgvPurchaseReturn.Rows[productId].Cells[11].Value = unitInfo.UnitName;
											if (this.dgvPurchaseReturn.Rows[productId].Cells[10].Value == null)
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[10].Value = 0;
											}
											else if (this.dgvPurchaseReturn.Rows[productId].Cells[10].Value.ToString() == "")
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[10].Value = 0;
											}
											try
											{
												decimal.Parse(this.dgvPurchaseReturn.Rows[productId].Cells[10].Value.ToString());
											}
											catch (Exception exception)
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[10].Value = 0;
											}
											if (!(decimal.Parse(row.ItemArray[2].ToString()) != new decimal(0)))
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[12].Value = 0;
											}
											else
											{
												num = decimal.Parse(row.ItemArray[2].ToString());
												num1 = decimal.Parse(this.dgvPurchaseReturn.Rows[productId].Cells[10].Value.ToString());
												num2 = num * num1;
												this.dgvPurchaseReturn.Rows[productId].Cells[12].Value = Math.Round(num2, 2);
											}
											this.dgvPurchaseReturn.Rows[productId].Cells[13].Value = row.ItemArray[3].ToString();
											if (!(num2 == new decimal(0) ? true : !(row.ItemArray[3].ToString() != "")))
											{
												num3 = decimal.Parse(row.ItemArray[3].ToString());
												num4 = Math.Round(num2 - ((num2 * num3) / new decimal(100)), 2);
												this.dgvPurchaseReturn.Rows[productId].Cells[14].Value = num4;
											}
											else if (num2 == new decimal(0))
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[14].Value = 0;
											}
											else if (decimal.Parse(row.ItemArray[4].ToString()) == new decimal(0))
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[14].Value = Math.Round(num2);
											}
											if ((num4 == new decimal(0) ? true : !(decimal.Parse(row.ItemArray[4].ToString()) != new decimal(0))))
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[17].Value = 0;
											}
											else
											{
												flag = false;
												num5 = decimal.Parse(row.ItemArray[4].ToString());
												str = row.ItemArray[5].ToString();
												if (str == "False")
												{
													this.dgvPurchaseReturn.Rows[productId].Cells[17].Value = Math.Round((num4 * num5) / (new decimal(100) + num5), 2);
													this.dgvPurchaseReturn.Rows[productId].Cells[18].Value = num4;
												}
												else if (!(str == "True"))
												{
													this.dgvPurchaseReturn.Rows[productId].Cells[18].Value = num4;
												}
												else
												{
													this.dgvPurchaseReturn.Rows[productId].Cells[17].Value = Math.Round((num4 * num5) / new decimal(100), 2);
													this.dgvPurchaseReturn.Rows[productId].Cells[18].Value = num4 + decimal.Parse(this.dgvPurchaseReturn.Rows[productId].Cells[17].Value.ToString());
												}
											}
											if (flag)
											{
												if (!(num4 != new decimal(0)))
												{
													this.dgvPurchaseReturn.Rows[productId].Cells[18].Value = 0;
												}
												else
												{
													this.dgvPurchaseReturn.Rows[productId].Cells[18].Value = num4;
												}
											}
											if (bool.Parse(row.ItemArray[5].ToString()) != bool.Parse("True"))
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[15].Value = "Included";
											}
											else
											{
												this.dgvPurchaseReturn.Rows[productId].Cells[15].Value = "Excluded";
											}
											this.dgvPurchaseReturn.Rows[productId].Cells[16].Value = row.ItemArray[4].ToString();
											this.dgvPurchaseReturn.Rows[productId].Cells[19].Value = row.ItemArray[0].ToString();
											productId++;
										}
									}
								}
								this.CalculateTotal();
							}
							this.dgvPurchaseReturn.ClearSelection();
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

		private void cmbSearchBy_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.txtSearchFor.Clear();
			}
			catch
			{
			}
		}

		private void cmbVendor_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
				if (e.KeyCode == Keys.Return)
				{
					this.dgvPurchaseReturn.ClearSelection();
					this.dgvPurchaseReturn.CurrentCell = this.dgvPurchaseReturn.Rows[0].Cells[0];
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

		public void CollectSelectedIds(string pPurchaseReturnDetailsId)
		{
			try
			{
				DataRow dataRow = this.dtblRemovedPurchaseReturnId.NewRow();
				this.dtblRemovedPurchaseReturnId.Rows.Add(dataRow);
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
				if (this.dtblRemovedPurchaseReturnId.Rows.Count == 0)
				{
					DataColumn dataColumn = new DataColumn("DetailsOne");
					this.dtblRemovedPurchaseReturnId.Columns.Add(dataColumn);
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
				PurchaseReturnDetailsSP purchaseReturnDetailsSP = new PurchaseReturnDetailsSP();
				foreach (DataRow row in this.dtblRemovedPurchaseReturnId.Rows)
				{
					purchaseReturnDetailsSP.PurchaseReturnDetailsDelete(row.ItemArray[0].ToString());
				}
				this.dtblRemovedPurchaseReturnId.Rows.Clear();
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
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					bool flag = true;
					if (e.ColumnIndex == 10)
					{
						decimal num = new decimal(0, 0, 0, false, 2);
						decimal num1 = new decimal(0, 0, 0, false, 2);
						decimal num2 = new decimal(0, 0, 0, false, 2);
						decimal num3 = new decimal(0);
						if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[10].Value == null)
						{
							num = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[4].Value.ToString());
							num2 = num * num1;
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value = Math.Round(num2);
						}
						else if (!(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[10].Value.ToString() != ""))
						{
							num = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[4].Value.ToString());
							num2 = num * num1;
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value = Math.Round(num2);
						}
						else
						{
							num3 = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[8].Value.ToString());
							num = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[4].Value.ToString());
							num1 = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[10].Value.ToString());
							if (!(num1 <= num3))
							{
								MessageBox.Show(string.Concat("Only ", Math.Round(num3, 0), " remaining"), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[10].Value = 0;
							}
							else
							{
								num2 = num * num1;
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value = num2;
							}
						}
						if ((this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value == null ? true : this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[13].Value == null))
						{
							if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value == null)
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = 0;
							}
							else if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[13].Value == null)
							{
								if (!(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString() != "0.00"))
								{
									this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = "";
								}
								else
								{
									this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString();
								}
							}
						}
						else if (!(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString() == "0" ? true : !(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[13].Value.ToString() != "")))
						{
							decimal num4 = new decimal(0, 0, 0, false, 2);
							decimal num5 = new decimal(0, 0, 0, false, 2);
							num4 = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString());
							num5 = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[13].Value.ToString()) / new decimal(100);
							if (!(num4 >= num5))
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = num4 - new decimal(0);
							}
							else
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = num4 - (num4 * num5);
							}
						}
						else if (decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString()) == new decimal(0))
						{
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = 0;
						}
						else if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString() == "")
						{
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = 0;
						}
						else if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[13].Value.ToString() == "")
						{
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value = this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[12].Value.ToString();
						}
						if ((this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value == null ? true : this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value == null))
						{
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[17].Value = 0;
						}
						else if ((this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value.ToString() == "" ? true : !(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[15].Value.ToString() != "")))
						{
							this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[17].Value = 0;
						}
						else
						{
							flag = false;
							decimal num6 = new decimal(0, 0, 0, false, 2);
							string str = "";
							decimal num7 = new decimal(0, 0, 0, false, 2);
							if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[16].Value != null)
							{
								num6 = (!(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[16].Value.ToString() == "") ? decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[16].Value.ToString()) : new decimal(0));
							}
							else
							{
								num6 = new decimal(0);
							}
							num7 = decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value.ToString());
							str = this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[15].Value.ToString();
							if (str == "Included")
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[17].Value = Math.Round((num7 * num6) / (new decimal(100) + num6), 2);
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[18].Value = num7;
							}
							else if (!(str == "Excluded"))
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[18].Value = num7;
							}
							else
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[17].Value = Math.Round((num7 * num6) / new decimal(100), 2);
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[18].Value = num7 + decimal.Parse(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[17].Value.ToString());
							}
						}
						if (flag)
						{
							if (this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value == null)
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[18].Value = 0;
							}
							else if (!(this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value.ToString() != ""))
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[18].Value = 0;
							}
							else
							{
								this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[18].Value = this.dgvPurchaseReturn.Rows[e.RowIndex].Cells[14].Value.ToString();
							}
						}
						this.CalculateTotal();
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
				if (this.dgvPurchaseReturn.CurrentCell == null)
				{
					flag = true;
				}
				else
				{
					flag = (this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 4 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 5 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 6 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 8 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 9 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 10 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 12 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 13 || this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 14 ? false : this.dgvPurchaseReturn.CurrentCell.ColumnIndex != 16);
				}
				if (!flag)
				{
					try
					{
						decimal.Parse(this.dgvPurchaseReturn.CurrentCell.Value.ToString());
					}
					catch (Exception exception)
					{
						this.dgvPurchaseReturn.CurrentCell.Value = 0;
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
				if (e.KeyCode == Keys.Return)
				{
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
			try
			{
				this.CalculateTotal();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseReturn_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 10)
				{
					this.dgvPurchaseReturn.BeginEdit(true);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvPurchaseReturn_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvPurchaseReturn.CurrentCell == this.dgvPurchaseReturn[18, this.dgvPurchaseReturn.Rows.Count - 1])
					{
						this.txtDescription.Focus();
						this.dgvPurchaseReturn.ClearSelection();
					}
				}
			}
			catch
			{
			}
		}

		private void dgvPurchaseReturn_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if ((this.dgvPurchaseReturn.CurrentCell == null || this.dgvPurchaseReturn.CurrentCell.ColumnIndex != 0 ? false : this.dgvPurchaseReturn.CurrentCell.RowIndex == 0))
					{
						if (this.p != 1)
						{
							frmPurchaseReturn _frmPurchaseReturn = this;
							_frmPurchaseReturn.p = _frmPurchaseReturn.p + 1;
						}
						else
						{
							this.p = 0;
							this.dgvPurchaseReturn.ClearSelection();
							this.cmbInvoice.Focus();
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

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void DoWhenComingFromRegister(frmPurchaseReturnRegister frmpurchasereturnregister, string strPurchaseReturnMasterId)
		{
			try
			{
				base.Show();
				this.isInEditMode = true;
				this.btnDelete.Enabled = true;
				this.btnClear.Text = "&New";
				this.frmRegister = frmpurchasereturnregister;
				PurchaseReturnMasterSP purchaseReturnMasterSP = new PurchaseReturnMasterSP();
				PurchaseReturnMasterInfo purchaseReturnMasterInfo = new PurchaseReturnMasterInfo();
				PurchaseReturnDetailsSP purchaseReturnDetailsSP = new PurchaseReturnDetailsSP();
				PurchaseReturnDetailsInfo purchaseReturnDetailsInfo = new PurchaseReturnDetailsInfo();
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
				purchaseReturnMasterInfo = purchaseReturnMasterSP.PurchaseReturnMasterView(strPurchaseReturnMasterId);
				if (purchaseReturnMasterInfo.PurchaseReturnMasterId != null)
				{
					this.txtVoucherNo.Text = purchaseReturnMasterInfo.PurchaseReturnMasterId;
					this.dtpDate.Text = purchaseReturnMasterInfo.Date.ToString();
					this.FillComboInvoice();
					this.cmbInvoice.SelectedValue = purchaseReturnMasterInfo.PurchaseMasterId;
				}
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
				if (this.isInEditMode)
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

		public void FillComboInvoice()
		{
			try
			{
				PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
				DataTable dataTable = new DataTable();
				dataTable = purchaseMasterSP.PurchaseMasterForReturn();
				if (dataTable.Rows.Count > 0)
				{
					this.cmbInvoice.DataSource = dataTable;
					this.cmbInvoice.DisplayMember = "PurchaseInvoiceNo";
					this.cmbInvoice.ValueMember = "PurchaseMasterId";
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
				if (e.KeyCode == Keys.F2)
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
					this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
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

		public string GetMaxofPurchaseReturnMasterId()
		{
			string str = "";
			try
			{
				str = (new PurchaseReturnMasterSP()).PurchaseReturnMasterGetMax().ToString();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPurchaseReturn));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.groupBox1 = new GroupBox();
			this.cmbSearchBy = new ComboBox();
			this.txtSearchFor = new TextBox();
			this.lblSearchFor = new Label();
			this.label3 = new Label();
			this.label7 = new Label();
			this.btnRemove = new Button();
			this.chbxprint = new CheckBox();
			this.lblRoundedGrandTotal = new Label();
			this.lblRoundedGrand = new Label();
			this.lblGrandTotal = new Label();
			this.lblGrand = new Label();
			this.label5 = new Label();
			this.txtDescription = new TextBox();
			this.label15 = new Label();
			this.txtCashVendor = new TextBox();
			this.label14 = new Label();
			this.label13 = new Label();
			this.txtVendor = new TextBox();
			this.lblBlnceAmount = new Label();
			this.lblVendor = new Label();
			this.dtpDate = new DateTimePicker();
			this.cmbInvoice = new ComboBox();
			this.lblCashOrParty = new Label();
			this.txtVoucherNo = new TextBox();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.dgvPurchaseReturn = new dgv.DataGridViewEnter();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.cmbProduct = new DataGridViewTextBoxColumn();
			this.cmbBatch = new DataGridViewTextBoxColumn();
			this.Column4 = new DateInGrid.CalendarColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.Column9 = new DataGridViewTextBoxColumn();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column13 = new DataGridViewTextBoxColumn();
			this.Column14 = new DataGridViewTextBoxColumn();
			this.Column15 = new DataGridViewTextBoxColumn();
			this.Column16 = new DataGridViewTextBoxColumn();
			this.Column17 = new DataGridViewTextBoxColumn();
			this.Column18 = new DataGridViewTextBoxColumn();
			this.Column19 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.dgvPurchaseReturn).BeginInit();
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
			this.btnSave.TabIndex = 8;
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
			this.btnDelete.TabIndex = 9;
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
			this.btnClear.TabIndex = 10;
			this.btnClear.Text = "C&lear";
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
			this.btnClose.TabIndex = 11;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.groupBox1);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.btnRemove);
			this.panel8.Controls.Add(this.chbxprint);
			this.panel8.Controls.Add(this.lblRoundedGrandTotal);
			this.panel8.Controls.Add(this.lblRoundedGrand);
			this.panel8.Controls.Add(this.lblGrandTotal);
			this.panel8.Controls.Add(this.lblGrand);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.dgvPurchaseReturn);
			this.panel8.Controls.Add(this.label15);
			this.panel8.Controls.Add(this.txtCashVendor);
			this.panel8.Controls.Add(this.label14);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.txtVendor);
			this.panel8.Controls.Add(this.lblBlnceAmount);
			this.panel8.Controls.Add(this.lblVendor);
			this.panel8.Controls.Add(this.dtpDate);
			this.panel8.Controls.Add(this.cmbInvoice);
			this.panel8.Controls.Add(this.lblCashOrParty);
			this.panel8.Controls.Add(this.txtVoucherNo);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(776, 449);
			this.panel8.TabIndex = 0;
			this.groupBox1.Controls.Add(this.cmbSearchBy);
			this.groupBox1.Controls.Add(this.txtSearchFor);
			this.groupBox1.Controls.Add(this.lblSearchFor);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new Point(103, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(535, 45);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			this.cmbSearchBy.Items.AddRange(new object[] { "Product Code", "Product Name" });
			this.cmbSearchBy.Location = new Point(124, 14);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(140, 21);
			this.cmbSearchBy.TabIndex = 5;
			this.cmbSearchBy.TabStop = false;
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbSearchBy_KeyDown);
			this.txtSearchFor.Location = new Point(349, 17);
			this.txtSearchFor.MaxLength = 50;
			this.txtSearchFor.Name = "txtSearchFor";
			this.txtSearchFor.Size = new System.Drawing.Size(140, 20);
			this.txtSearchFor.TabIndex = 6;
			this.txtSearchFor.TabStop = false;
			this.txtSearchFor.TextChanged += new EventHandler(this.txtSearchFor_TextChanged);
			this.txtSearchFor.KeyDown += new KeyEventHandler(this.txtSearchFor_KeyDown);
			this.lblSearchFor.AutoSize = true;
			this.lblSearchFor.Location = new Point(281, 20);
			this.lblSearchFor.Name = "lblSearchFor";
			this.lblSearchFor.Size = new System.Drawing.Size(62, 13);
			this.lblSearchFor.TabIndex = 51;
			this.lblSearchFor.Text = "Search For:";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(59, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 51;
			this.label3.Text = "Search By:";
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.ForeColor = Color.Red;
			this.label7.Location = new Point(280, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 13);
			this.label7.TabIndex = 36456458;
			this.label7.Text = "*";
			this.btnRemove.BackColor = Color.SteelBlue;
			this.btnRemove.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRemove.ForeColor = Color.White;
			this.btnRemove.Location = new Point(674, 295);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(85, 23);
			this.btnRemove.TabIndex = 36456457;
			this.btnRemove.TabStop = false;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.chbxprint.AutoSize = true;
			this.chbxprint.Location = new Point(14, 413);
			this.chbxprint.Name = "chbxprint";
			this.chbxprint.Size = new System.Drawing.Size(97, 17);
			this.chbxprint.TabIndex = 55665;
			this.chbxprint.TabStop = false;
			this.chbxprint.Text = "Print after save";
			this.chbxprint.UseVisualStyleBackColor = true;
			this.chbxprint.KeyDown += new KeyEventHandler(this.chbxprint_KeyDown);
			this.lblRoundedGrandTotal.AutoSize = true;
			this.lblRoundedGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblRoundedGrandTotal.Location = new Point(681, 365);
			this.lblRoundedGrandTotal.Name = "lblRoundedGrandTotal";
			this.lblRoundedGrandTotal.Size = new System.Drawing.Size(32, 13);
			this.lblRoundedGrandTotal.TabIndex = 74;
			this.lblRoundedGrandTotal.Text = "0.00";
			this.lblRoundedGrand.AutoSize = true;
			this.lblRoundedGrand.Location = new Point(571, 365);
			this.lblRoundedGrand.Name = "lblRoundedGrand";
			this.lblRoundedGrand.Size = new System.Drawing.Size(110, 13);
			this.lblRoundedGrand.TabIndex = 73;
			this.lblRoundedGrand.Text = "Rounded GrandTotal:";
			this.lblGrandTotal.AutoSize = true;
			this.lblGrandTotal.Location = new Point(681, 344);
			this.lblGrandTotal.Name = "lblGrandTotal";
			this.lblGrandTotal.Size = new System.Drawing.Size(28, 13);
			this.lblGrandTotal.TabIndex = 71;
			this.lblGrandTotal.Text = "0.00";
			this.lblGrand.AutoSize = true;
			this.lblGrand.Location = new Point(572, 344);
			this.lblGrand.Name = "lblGrand";
			this.lblGrand.Size = new System.Drawing.Size(66, 13);
			this.lblGrand.TabIndex = 70;
			this.lblGrand.Text = "Grand Total:";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(11, 317);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 61;
			this.label5.Text = "Description:";
			this.txtDescription.Location = new Point(14, 333);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(260, 55);
			this.txtDescription.TabIndex = 8;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyUp += new KeyEventHandler(this.txtDescription_KeyUp);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.txtDescription.KeyDown += new KeyEventHandler(this.txtDescription_KeyDown);
			this.label15.AutoSize = true;
			this.label15.Location = new Point(506, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(86, 13);
			this.label15.TabIndex = 53;
			this.label15.Text = "Current Balance:";
			this.label15.Visible = false;
			this.txtCashVendor.BackColor = Color.WhiteSmoke;
			this.txtCashVendor.Location = new Point(618, 35);
			this.txtCashVendor.Name = "txtCashVendor";
			this.txtCashVendor.ReadOnly = true;
			this.txtCashVendor.Size = new System.Drawing.Size(140, 20);
			this.txtCashVendor.TabIndex = 3;
			this.txtCashVendor.TabStop = false;
			this.txtCashVendor.Leave += new EventHandler(this.txtInvoice_Leave);
			this.txtCashVendor.KeyDown += new KeyEventHandler(this.txtInvoice_KeyDown);
			this.label14.AutoSize = true;
			this.label14.Location = new Point(11, 42);
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
			this.txtVendor.BackColor = Color.WhiteSmoke;
			this.txtVendor.Location = new Point(134, 63);
			this.txtVendor.Name = "txtVendor";
			this.txtVendor.ReadOnly = true;
			this.txtVendor.Size = new System.Drawing.Size(140, 20);
			this.txtVendor.TabIndex = 4;
			this.txtVendor.TabStop = false;
			this.lblBlnceAmount.AutoSize = true;
			this.lblBlnceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblBlnceAmount.Location = new Point(616, 64);
			this.lblBlnceAmount.Name = "lblBlnceAmount";
			this.lblBlnceAmount.Size = new System.Drawing.Size(32, 13);
			this.lblBlnceAmount.TabIndex = 47;
			this.lblBlnceAmount.Text = "0.00";
			this.lblBlnceAmount.Visible = false;
			this.lblVendor.AutoSize = true;
			this.lblVendor.Location = new Point(11, 68);
			this.lblVendor.Name = "lblVendor";
			this.lblVendor.Size = new System.Drawing.Size(44, 13);
			this.lblVendor.TabIndex = 38;
			this.lblVendor.Text = "Vendor:";
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(619, 8);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(140, 20);
			this.dtpDate.TabIndex = 1;
			this.dtpDate.KeyDown += new KeyEventHandler(this.dtpDate_KeyDown);
			this.cmbInvoice.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbInvoice.FormattingEnabled = true;
			this.cmbInvoice.Location = new Point(134, 34);
			this.cmbInvoice.Name = "cmbInvoice";
			this.cmbInvoice.Size = new System.Drawing.Size(140, 21);
			this.cmbInvoice.TabIndex = 2;
			this.cmbInvoice.Leave += new EventHandler(this.cmbInvoice_Leave);
			this.cmbInvoice.SelectedIndexChanged += new EventHandler(this.cmbInvoice_SelectedIndexChanged);
			this.cmbInvoice.KeyUp += new KeyEventHandler(this.cmbInvoice_KeyUp);
			this.cmbInvoice.KeyDown += new KeyEventHandler(this.cmbCashVendor_KeyDown);
			this.lblCashOrParty.AutoSize = true;
			this.lblCashOrParty.Location = new Point(506, 37);
			this.lblCashOrParty.Name = "lblCashOrParty";
			this.lblCashOrParty.Size = new System.Drawing.Size(106, 13);
			this.lblCashOrParty.TabIndex = 4;
			this.lblCashOrParty.Text = "Cash/Party Account:";
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
			this.label1.Size = new System.Drawing.Size(114, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Purchase Return";
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
			this.dgvPurchaseReturn.AllowUserToAddRows = false;
			this.dgvPurchaseReturn.AllowUserToDeleteRows = false;
			this.dgvPurchaseReturn.AllowUserToResizeColumns = false;
			this.dgvPurchaseReturn.AllowUserToResizeRows = false;
			this.dgvPurchaseReturn.BackgroundColor = Color.White;
			this.dgvPurchaseReturn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvPurchaseReturn.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.cmbProduct, this.cmbBatch, this.Column4, this.Column5, this.Column6, this.Column7, this.Column8, this.Column9, this.Column10, this.Column2, this.Column11, this.Column12, this.Column13, this.Column14, this.Column15, this.Column16, this.Column17, this.Column18, this.Column19 };
			columns.AddRange(column1);
			this.dgvPurchaseReturn.GridColor = Color.WhiteSmoke;
			this.dgvPurchaseReturn.Location = new Point(12, 140);
			this.dgvPurchaseReturn.Name = "dgvPurchaseReturn";
			this.dgvPurchaseReturn.RowHeadersVisible = false;
			this.dgvPurchaseReturn.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvPurchaseReturn.Size = new System.Drawing.Size(754, 149);
			this.dgvPurchaseReturn.TabIndex = 7;
			this.dgvPurchaseReturn.CellLeave += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellLeave);
			this.dgvPurchaseReturn.KeyDown += new KeyEventHandler(this.dgvPurchaseInvoice_KeyDown);
			this.dgvPurchaseReturn.Leave += new EventHandler(this.dgvPurchaseInvoice_Leave);
			this.dgvPurchaseReturn.CellEndEdit += new DataGridViewCellEventHandler(this.dgvPurchaseInvoice_CellEndEdit);
			this.dgvPurchaseReturn.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvPurchaseInvoice_EditingControlShowing);
			this.dgvPurchaseReturn.KeyUp += new KeyEventHandler(this.dgvPurchaseReturn_KeyUp);
			this.dgvPurchaseReturn.CellEnter += new DataGridViewCellEventHandler(this.dgvPurchaseReturn_CellEnter);
			this.dgvPurchaseReturn.KeyPress += new KeyPressEventHandler(this.dgvPurchaseReturn_KeyPress);
			this.Column1.HeaderText = "Product Code";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.cmbProduct.HeaderText = "Product Name";
			this.cmbProduct.Name = "cmbProduct";
			this.cmbProduct.ReadOnly = true;
			this.cmbProduct.Resizable = DataGridViewTriState.False;
			this.cmbProduct.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.cmbBatch.HeaderText = "Batch";
			this.cmbBatch.Name = "cmbBatch";
			this.cmbBatch.ReadOnly = true;
			this.cmbBatch.Resizable = DataGridViewTriState.False;
			this.cmbBatch.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column4.HeaderText = "Expiry Date";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Resizable = DataGridViewTriState.False;
			this.Column5.HeaderText = "Purchase Rate";
			this.Column5.MaxInputLength = 7;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = DataGridViewTriState.False;
			this.Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column6.HeaderText = "Sales Rate";
			this.Column6.MaxInputLength = 7;
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Resizable = DataGridViewTriState.False;
			this.Column6.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column7.HeaderText = "MRP";
			this.Column7.MaxInputLength = 7;
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Resizable = DataGridViewTriState.False;
			this.Column7.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column8.HeaderText = "Manufacture";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Resizable = DataGridViewTriState.False;
			this.Column8.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column9.HeaderText = "Purchase Qty";
			this.Column9.MaxInputLength = 6;
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			this.Column9.Resizable = DataGridViewTriState.False;
			this.Column9.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column10.HeaderText = "Free";
			this.Column10.MaxInputLength = 6;
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			this.Column10.Resizable = DataGridViewTriState.False;
			this.Column10.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column10.Visible = false;
			this.Column2.HeaderText = "Returned Qty";
			this.Column2.MaxInputLength = 6;
			this.Column2.Name = "Column2";
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
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
			this.Column13.ReadOnly = true;
			this.Column13.Resizable = DataGridViewTriState.False;
			this.Column13.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column14.HeaderText = "Net Value";
			this.Column14.Name = "Column14";
			this.Column14.ReadOnly = true;
			this.Column14.Resizable = DataGridViewTriState.False;
			this.Column14.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column15.HeaderText = "Tax Type";
			this.Column15.Name = "Column15";
			this.Column15.ReadOnly = true;
			this.Column15.Resizable = DataGridViewTriState.False;
			this.Column15.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column16.HeaderText = "Tax %";
			this.Column16.MaxInputLength = 4;
			this.Column16.Name = "Column16";
			this.Column16.ReadOnly = true;
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
			base.Name = "frmPurchaseReturn";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Purchase Return";
			base.FormClosing += new FormClosingEventHandler(this.frmPurchaseInvoice_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmPurchaseInvoice_KeyDown);
			base.Load += new EventHandler(this.frmPurchaseInvoice_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((ISupportInitialize)this.dgvPurchaseReturn).EndInit();
			base.ResumeLayout(false);
		}

		public void SaveFunction()
		{
			try
			{
				if (this.cmbInvoice.SelectedValue == null)
				{
					MessageBox.Show("Select invoice number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.cmbInvoice.Focus();
				}
				else if (this.cmbInvoice.Text == "")
				{
					MessageBox.Show("Select invoice number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.cmbInvoice.Focus();
				}
				else if (this.CheckGridNull())
				{
					this.SaveToPurchaseReturnMaster();
					if (this.isAnyReturn)
					{
						this.SavePurchaseLedgerPosting();
						this.SaveToStockPosting();
						if (this.chbxprint.Checked)
						{
						}
						if (!this.isInEditMode)
						{
							MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (this.chbxprint.Checked)
							{
							}
							this.ClearFunction();
						}
						else
						{
							MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (this.chbxprint.Checked)
							{
							}
							base.Close();
						}
					}
					else
					{
						MessageBox.Show("Enter returned quantity", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						if (this.dgvPurchaseReturn.Rows.Count > 0)
						{
							this.dgvPurchaseReturn.Focus();
							this.dgvPurchaseReturn.ClearSelection();
						}
					}
				}
				else
				{
					MessageBox.Show("Incomplete details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvPurchaseReturn.Rows.Count <= 0)
					{
						this.cmbInvoice.Focus();
					}
					else
					{
						this.dgvPurchaseReturn.Focus();
						this.dgvPurchaseReturn.ClearSelection();
						this.dgvPurchaseReturn.CurrentCell = this.dgvPurchaseReturn.Rows[0].Cells[0];
						this.dgvPurchaseReturn.Rows[0].Cells[0].Selected = true;
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
					VoucherType = "Purchase Return",
					Description = "By purchase Return",
					Date = DateTime.Parse(this.dtpDate.Text)
				};
				if (this.cmbInvoice.SelectedValue != null)
				{
					if (this.cmbInvoice.Text != "")
					{
						PurchaseMasterInfo purchaseMasterInfo = new PurchaseMasterInfo();
						PurchaseMasterSP purchaseMasterSP = new PurchaseMasterSP();
						if (this.isInEditMode)
						{
							DataTable dataTable = this.ledgerpostingsp.LedgerPostingViewByVoucherTypeAndVoucherNumber(this.txtVoucherNo.Text, "Purchase Return");
							if (dataTable.Rows.Count > 0)
							{
								ledgerPostingInfo.LedgerPostingId = dataTable.Rows[0][0].ToString();
								purchaseMasterInfo = purchaseMasterSP.PurchaseMasterView(this.cmbInvoice.SelectedValue.ToString());
								ledgerPostingInfo.LedgerId = purchaseMasterInfo.LedgerId;
								ledgerPostingInfo.Credit = new decimal(0);
								ledgerPostingInfo.Debit = decimal.Parse(this.lblGrandTotal.Text);
								this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
								ledgerPostingInfo.LedgerPostingId = dataTable.Rows[1][0].ToString();
								ledgerPostingInfo.LedgerId = "1";
								ledgerPostingInfo.Debit = new decimal(0);
								ledgerPostingInfo.Credit = decimal.Parse(this.lblGrandTotal.Text);
								this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
							}
						}
						else
						{
							purchaseMasterInfo = purchaseMasterSP.PurchaseMasterView(this.cmbInvoice.SelectedValue.ToString());
							ledgerPostingInfo.LedgerId = purchaseMasterInfo.LedgerId;
							ledgerPostingInfo.Credit = new decimal(0);
							ledgerPostingInfo.Debit = decimal.Parse(this.lblGrandTotal.Text);
							this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
							ledgerPostingInfo.LedgerId = "1";
							ledgerPostingInfo.Debit = new decimal(0);
							ledgerPostingInfo.Credit = decimal.Parse(this.lblGrandTotal.Text);
							this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
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

		public void SaveToPurchaseReturnMaster()
		{
			try
			{
				string text = "";
				PurchaseReturnMasterSP purchaseReturnMasterSP = new PurchaseReturnMasterSP();
				PurchaseReturnMasterInfo purchaseReturnMasterInfo = new PurchaseReturnMasterInfo();
				PurchaseReturnDetailsInfo purchaseReturnDetailsInfo = new PurchaseReturnDetailsInfo();
				PurchaseReturnDetailsSP purchaseReturnDetailsSP = new PurchaseReturnDetailsSP();
				ProductBatchInfo productBatchInfo = new ProductBatchInfo();
				ProductBatchSP productBatchSP = new ProductBatchSP();
				AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				ProductBatchInfo productBatchInfo1 = new ProductBatchInfo();
				this.isAnyReturn = false;
				if ((this.txtVoucherNo.Text == "" ? false : this.cmbInvoice.SelectedValue != null))
				{
					if (this.isInEditMode)
					{
						text = this.txtVoucherNo.Text;
					}
					else
					{
						text = this.GetMaxofPurchaseReturnMasterId();
						if (text != this.txtVoucherNo.Text)
						{
							MessageBox.Show(string.Concat("Voucher number changed from ", this.txtVoucherNo.Text, "to ", text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					this.txtVoucherNo.Text = text;
					purchaseReturnMasterInfo.PurchaseReturnMasterId = text;
					purchaseReturnMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
					purchaseReturnMasterInfo.PurchaseMasterId = this.cmbInvoice.SelectedValue.ToString();
					purchaseReturnMasterInfo.Description = this.txtDescription.Text.Trim();
					if (this.isInEditMode)
					{
						purchaseReturnDetailsSP.PurchaseReturnDetailsDeleteByMasterId(this.txtVoucherNo.Text);
					}
					foreach (DataGridViewRow row in (IEnumerable)this.dgvPurchaseReturn.Rows)
					{
						if ((row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[10].Value == null ? false : row.Cells[19].Value != null))
						{
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") ? false : row.Cells[10].Value.ToString() != ""))
							{
								if (decimal.Parse(row.Cells[10].Value.ToString()) > new decimal(0))
								{
									this.isAnyReturn = true;
									purchaseReturnDetailsInfo.PurchaseReturnMasterId = text;
									purchaseReturnDetailsInfo.PurchaseDetailsId = row.Cells[19].Value.ToString();
									purchaseReturnDetailsInfo.ReturnedQty = decimal.Parse(row.Cells[10].Value.ToString());
									purchaseReturnDetailsInfo.ReturnedFreeQty = decimal.Parse(row.Cells[18].Value.ToString());
									purchaseReturnDetailsInfo.Description = "";
									purchaseReturnDetailsSP.PurchaseReturnDetailsAdd(purchaseReturnDetailsInfo);
								}
							}
						}
					}
					if (this.isAnyReturn)
					{
						if (this.isInEditMode)
						{
							purchaseReturnMasterSP.PurchaseReturnMasterEdit(purchaseReturnMasterInfo);
						}
						else
						{
							purchaseReturnMasterSP.PurchaseReturnMasterAdd(purchaseReturnMasterInfo);
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

		public void SaveToStockPosting()
		{
			try
			{
				StockPostingInfo stockPostingInfo = new StockPostingInfo();
				StockPostingSP stockPostingSP = new StockPostingSP();
				PurchaseReturnDetailsSP purchaseReturnDetailsSP = new PurchaseReturnDetailsSP();
				PurchaseDetailsInfo purchaseDetailsInfo = new PurchaseDetailsInfo();
				PurchaseDetailsSP purchaseDetailsSP = new PurchaseDetailsSP();
				DataTable dataTable = new DataTable();
				if (this.txtVoucherNo.Text != "")
				{
					if (this.isInEditMode)
					{
						stockPostingSP.StockPostingDeleteByVoucherAndType(this.txtVoucherNo.Text, "Purchase Return");
					}
					dataTable = purchaseReturnDetailsSP.PurchaseReturnDetailsViewAllByMasterId(this.txtVoucherNo.Text);
					foreach (DataRow row in dataTable.Rows)
					{
						stockPostingInfo.VoucherNumber = row.ItemArray[1].ToString();
						purchaseDetailsInfo = purchaseDetailsSP.PurchaseDetailsView(row.ItemArray[2].ToString());
						stockPostingInfo.ProductBatchId = purchaseDetailsInfo.ProductBatchId;
						stockPostingInfo.InwardQuantity = new decimal(0);
						stockPostingInfo.OutwardQuantity = decimal.Parse(row.ItemArray[3].ToString());
						stockPostingInfo.VoucherType = "Purchase Return";
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
				if (this.dgvPurchaseReturn.CurrentCell.ColumnIndex == 10)
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

		private void txtAdjustment_KeyDown(object sender, KeyEventArgs e)
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
						if (this.dgvPurchaseReturn.Rows.Count <= 0)
						{
							this.cmbInvoice.Focus();
						}
						else
						{
							this.dgvPurchaseReturn.CurrentCell = this.dgvPurchaseReturn.Rows[this.dgvPurchaseReturn.Rows.Count - 1].Cells[18];
							this.dgvPurchaseReturn.CurrentCell.Selected = true;
							this.dgvPurchaseReturn.Focus();
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
					frmPurchaseReturn _frmPurchaseReturn = this;
					_frmPurchaseReturn.inDescriptionCount = _frmPurchaseReturn.inDescriptionCount + 1;
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

		private void txtDescription_KeyUp(object sender, KeyEventArgs e)
		{
		}

		private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode != Keys.Return ? false : this.txtCashVendor.Text.Trim() != ""))
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

		private void txtInvoice_Leave(object sender, EventArgs e)
		{
			try
			{
				if ((this.cmbInvoice.Focused || this.dtpDate.Focused || this.txtVoucherNo.Focused || this.isFormClose || this.btnClear.Focused ? false : !this.btnClose.Focused))
				{
					if (this.txtCashVendor.Text.Trim() == "")
					{
						this.txtCashVendor.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSearchFor_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					if (this.dgvPurchaseReturn.Rows.Count <= 0)
					{
						this.txtSearchFor.Focus();
					}
					else
					{
						this.dgvPurchaseReturn.Focus();
						this.dgvPurchaseReturn.ClearSelection();
						this.dgvPurchaseReturn.CurrentCell = this.dgvPurchaseReturn.Rows[0].Cells[10];
						this.dgvPurchaseReturn.Rows[0].Cells[10].Selected = true;
					}
				}
			}
			catch
			{
				this.txtSearchFor.Focus();
			}
		}

		private void txtSearchFor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				string str = "";
				for (int i = 0; i < this.dgvPurchaseReturn.Rows.Count; i++)
				{
					if (this.dgvPurchaseReturn.Rows[i].Cells[0].Value != null)
					{
						str = (!(this.cmbSearchBy.Text == "Product Code") ? this.dgvPurchaseReturn[1, i].Value.ToString().ToLower() : this.dgvPurchaseReturn[0, i].Value.ToString().ToLower());
						if (!str.StartsWith(this.txtSearchFor.Text.ToLower()))
						{
							this.dgvPurchaseReturn.Rows[i].Visible = false;
						}
						else
						{
							this.dgvPurchaseReturn.Rows[i].Visible = true;
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