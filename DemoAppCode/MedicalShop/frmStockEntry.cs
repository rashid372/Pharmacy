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
	public class frmStockEntry : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private Label label13;

		private DateTimePicker dtpDate;

		private TextBox txtVoucherNo;

		private Label label2;

		private TextBox txtDescription;

		private Label label3;

		private Label lblAmount;

		private Label lblDebitAmt;

		private Button btnRemove;

		private CheckBox cbPrint;

		private dgv.DataGridViewEnter dgvStock;

		private ListBox lstbxBatch;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewComboBoxColumn cmbProduct;

		private DataGridViewTextBoxColumn cmbBatch;

		private DateInGrid.CalendarColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column8;

		private DataGridViewTextBoxColumn Column9;

		private DataGridViewTextBoxColumn Column11;

		private DataGridViewTextBoxColumn Column18;

		private DataGridViewTextBoxColumn Column19;

		private PictureBox pbxSearch;

		private int rowIndex;

		private int columnIndex;

		private bool isSearch = false;

		private bool isSaved = false;

		private MedicalShop.StockMasterSP mastersp = new MedicalShop.StockMasterSP();

		private MedicalShop.StockDetailsSP detailssp = new MedicalShop.StockDetailsSP();

		private MedicalShop.StockDetailsSP StockDetailsSP = new MedicalShop.StockDetailsSP();

		private MedicalShop.StockMasterInfo StockMasterInfo = new MedicalShop.StockMasterInfo();

		private MedicalShop.StockDetailsInfo StockDetailsInfo = new MedicalShop.StockDetailsInfo();

		private MedicalShop.StockPostingInfo StockPostingInfo = new MedicalShop.StockPostingInfo();

		private MedicalShop.StockPostingSP StockPostingSP = new MedicalShop.StockPostingSP();

		private MedicalShop.ProductBatchInfo ProductBatchInfo = new MedicalShop.ProductBatchInfo();

		private MedicalShop.ProductBatchSP ProductBatchSP = new MedicalShop.ProductBatchSP();

		private ProductSP productsp = new ProductSP();

		private MedicalShop.StockMasterSP StockMasterSP = new MedicalShop.StockMasterSP();

		private MedicalShop.ProductInfo ProductInfo = new MedicalShop.ProductInfo();

		private string strDefaultCurrency = "";

		private bool isInEditMode = false;

		private bool isRepeated = false;

		private DataTable dtblItem = new DataTable();

		private MedicalShop.frmStockRegister frmStockRegister;

		private string StockMasterIdForDelete = "";

		private int i = 0;

		private bool isFormClose = false;

		private ComboBox cbm;

		private DataGridViewCell currentCell;

		public frmStockEntry()
		{
			this.InitializeComponent();
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
                //StockPostingSP .PatientDelete(this.strPatientIdForEdit);
                //MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //ClearFunction();
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
				try
				{
					if (this.dgvStock.CurrentRow != null)
					{
						if (this.dgvStock.Rows.Count != 1)
						{
							this.dgvStock.Rows.RemoveAt(this.dgvStock.CurrentCell.RowIndex);
						}
						else
						{
							this.dgvStock.Rows.Clear();
						}
					}
				}
				catch (Exception exception)
				{
				}
				if (this.dgvStock.Rows.Count > 0)
				{
					this.dgvStock.Focus();
					this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
				}
				this.CalculateTotal();
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
				else if (!this.CheckGridNull())
				{
					MessageBox.Show("Incomplete  details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvStock.Rows.Count > 0)
					{
						this.isRepeated = true;
						this.dgvStock.Focus();
						this.dgvStock.ClearSelection();
						this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
						this.dgvStock.Rows[0].Cells[0].Selected = true;
						this.isRepeated = false;
					}
				}
				else if (this.CheckQuantityNull())
				{
					MessageBox.Show("Incomplete  details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvStock.Rows.Count > 0)
					{
						this.isRepeated = true;
						this.dgvStock.Focus();
						this.dgvStock.ClearSelection();
						this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
						this.dgvStock.Rows[0].Cells[0].Selected = true;
						this.isRepeated = false;
					}
				}
				else if (this.CheckOnSaveForExistenceOfProduct() >= 0)
				{
					int num = this.CheckOnSaveForExistenceOfProduct();
					MessageBox.Show("Repeated product batch exists", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.dgvStock.Focus();
					if (this.dgvStock.Rows.Count > 0)
					{
						this.dgvStock.CurrentCell = this.dgvStock.Rows[num].Cells[0];
						this.dgvStock.Rows[num].Selected = true;
					}
				}
				else if (this.btnSave.Text == "&Save")
				{
					this.isSaved = true;
					this.SaveOrEdit();
					MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.cbPrint.Checked)
					{
					}
					this.ClearFunction();
				}
				else if (this.btnSave.Text == "&Update")
				{
					this.SaveOrEdit();
					MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.cbPrint.Checked)
					{
					}
					base.Close();
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
					item.CallThisFormStock(this);
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
					_frmPopup.CallThisFormStock(this);
					_frmPopup.Show();
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
				decimal num = new decimal(0);
				foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
				{
					if (row.Cells[10].Value != null)
					{
						if (row.Cells[10].Value.ToString() != "")
						{
							num = num + decimal.Parse(row.Cells[10].Value.ToString());
							Math.Round(num, 2);
						}
					}
				}
				this.lblAmount.Text = string.Concat(num.ToString(), this.strDefaultCurrency);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public bool CheckGridNull()
		{
			bool flag = false;
			try
			{
				if (this.dgvStock.Rows.Count > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
					{
						if ((row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null ? false : row.Cells[8].Value != null))
						{
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != "") ? false : row.Cells[8].Value.ToString() != ""))
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

		public int CheckOnSaveForExistenceOfProduct()
		{
			bool flag = false;
			int num = 0;
			for (int i = 0; i < this.dgvStock.Rows.Count; i++)
			{
				if ((this.dgvStock.Rows[i].Cells[1].Value == null ? false : this.dgvStock.Rows[i].Cells[2].Value != null))
				{
					if ((this.dgvStock.Rows[i].Cells[1].Value.ToString() == "" ? false : this.dgvStock.Rows[i].Cells[2].Value.ToString() != ""))
					{
						for (int j = 0; j < this.dgvStock.Rows.Count; j++)
						{
							if ((this.dgvStock.Rows[j].Cells[1].Value == null ? false : this.dgvStock.Rows[j].Cells[2].Value != null))
							{
								if ((this.dgvStock.Rows[j].Cells[1].Value.ToString() == "" ? false : this.dgvStock.Rows[j].Cells[2].Value.ToString() != ""))
								{
									if ((this.dgvStock.Rows[i].Cells[1].Value.ToString() != this.dgvStock.Rows[j].Cells[1].Value.ToString() ? false : this.dgvStock.Rows[i].Cells[2].Value.ToString() == this.dgvStock.Rows[j].Cells[2].Value.ToString()))
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

		public bool CheckProductRepeat(string Id, string Batch)
		{
			bool flag = false;
			try
			{
				if (this.dgvStock.RowCount > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
					{
						if (this.dgvStock.CurrentRow.Index != row.Index)
						{
							if ((row.Cells[1].Value == null ? false : row.Cells[2].Value != null))
							{
								if ((row.Cells[1].Value.ToString() == "" ? false : row.Cells[1].Value.ToString() != ""))
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
			foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
			{
				if (row.Cells[1].Value != null)
				{
					if (row.Cells[1].Value.ToString() != "")
					{
						if (row.Cells[8].Value == null)
						{
							flag = true;
							break;
						}
						else if (row.Cells[8].Value.ToString() == "")
						{
							flag = true;
							break;
						}
						else if (!(decimal.Parse(row.Cells[8].Value.ToString()) <= new decimal(0)))
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
			return flag;
		}

		public void ClearFunction()
		{
			try
			{
				this.txtVoucherNo.Enabled = false;
				this.GenerateVoucherNumber();
				this.dgvStock.Rows.Clear();
				this.FillComboItem();
				this.lstbxBatch.Visible = false;
				this.dtpDate.Text = "";
				this.isSaved = false;
				this.strDefaultCurrency = "";
				if (!this.isInEditMode)
				{
					CompanySP companySP = new CompanySP();
					DataTable dataTable = new DataTable();
					dataTable = companySP.CompanyViewAll();
					if (dataTable.Rows.Count > 0)
					{
						this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
					}
				}
				this.txtDescription.Clear();
				this.btnDelete.Enabled = false;
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.btnDelete.Enabled = false;
				this.lblAmount.Text = string.Concat("0.00", this.strDefaultCurrency);
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.frmStockRegister.Close();
				}
				this.cbPrint.Checked = false;
				this.dtpDate.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
		}

		private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					MedicalShop.ProductBatchInfo productBatchInfo = new MedicalShop.ProductBatchInfo();
					MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
					if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 ? true : e.ColumnIndex == 2))
					{
						if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								this.FillBatchCombo(this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
							}
						}
					}
					if (e.ColumnIndex == 3)
					{
						if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
						{
							if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() != "")
							{
								if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().ToUpper() == "NA")
								{
									this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
								}
							}
						}
					}
					if ((e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 8 ? true : e.ColumnIndex == 10))
					{
						if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								DecimalValidation decimalValidation = new DecimalValidation();
								TextBox textBox = new TextBox()
								{
									Text = this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
								};
								if (!decimalValidation.checkString(textBox))
								{
									if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
									{
										MessageBox.Show("Only decimal values allowed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									}
									this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
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

		private void dgvStock_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.rowIndex = e.RowIndex;
				this.columnIndex = e.ColumnIndex;
				if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 ? true : e.ColumnIndex == 2))
				{
					if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
					{
						if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
						{
							this.FillBatchCombo(this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
						}
					}
				}
				if (e.ColumnIndex != 2)
				{
					this.lstbxBatch.Visible = false;
				}
				else if (this.dgvStock.CurrentRow != null)
				{
					if (this.dgvStock.CurrentRow.Cells[e.ColumnIndex - 1].Value == null)
					{
						this.lstbxBatch.Visible = false;
					}
					else if (!(this.dgvStock.CurrentRow.Cells[e.ColumnIndex - 1].Value.ToString() != ""))
					{
						this.lstbxBatch.Visible = false;
					}
					else
					{
						this.FillBatchCombo(this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
						Point left = new Point();
						Rectangle cellDisplayRectangle = this.dgvStock.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.X = cellDisplayRectangle.Left + this.dgvStock.Left;
						cellDisplayRectangle = this.dgvStock.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.Y = cellDisplayRectangle.Bottom + this.dgvStock.Top;
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

		private void dgvStock_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			int num;
			bool flag;
			try
			{
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					if (this.dgvStock.CurrentCell == null)
					{
						flag = true;
					}
					else
					{
						flag = (this.dgvStock.CurrentCell.ColumnIndex == 4 || this.dgvStock.CurrentCell.ColumnIndex == 5 || this.dgvStock.CurrentCell.ColumnIndex == 6 ? false : this.dgvStock.CurrentCell.ColumnIndex != 8);
					}
					if (!flag)
					{
						if ((this.dgvStock.CurrentRow.Cells[0].Value == null ? false : this.dgvStock.CurrentRow.Cells[1].Value != null))
						{
							if ((this.dgvStock.CurrentRow.Cells[1].Value.ToString() == "" ? false : this.dgvStock.CurrentRow.Cells[1].Value.ToString() != ""))
							{
								try
								{
									if (this.dgvStock.CurrentCell.Value == null)
									{
										num = 0;
										this.dgvStock.CurrentCell.Value = num.ToString();
									}
									else
									{
										this.dgvStock.CurrentCell.Value = decimal.Parse(this.dgvStock.CurrentCell.Value.ToString());
									}
								}
								catch (Exception exception)
								{
									num = 0;
									this.dgvStock.CurrentCell.Value = num.ToString();
								}
							}
						}
					}
					if ((e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 8 ? true : e.ColumnIndex == 10))
					{
						if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								DecimalValidation decimalValidation = new DecimalValidation();
								TextBox textBox = new TextBox()
								{
									Text = this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
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
									this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
								}
							}
						}
					}
					DataTable dataTable = new DataTable();
					if ((e.ColumnIndex == 1 ? true : e.ColumnIndex == 8))
					{
						if ((this.dgvStock.Rows[e.RowIndex].Cells[1].Value == null || this.dgvStock.Rows[e.RowIndex].Cells[2].Value == null ? false : this.dgvStock.Rows[e.RowIndex].Cells[8].Value != null))
						{
							if ((!(this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() != "") || !(this.dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString() != "") ? false : this.dgvStock.Rows[e.RowIndex].Cells[8].Value.ToString() != ""))
							{
								string str = this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString();
								dataTable = this.productsp.GetCurrentStockOfProduct(str);
								MedicalShop.ProductInfo productInfo = new MedicalShop.ProductInfo();
								productInfo = this.productsp.ProductView(str);
								if (productInfo.StockMaximumLevel > new decimal(0))
								{
									decimal num1 = new decimal(0);
									decimal num2 = new decimal(0);
									decimal num3 = new decimal(0);
									decimal qty = new decimal(0);
									decimal num4 = new decimal(0);
									if (dataTable.Rows.Count > 0)
									{
										num1 = decimal.Parse(dataTable.Rows[0].ItemArray[0].ToString());
										if (this.isInEditMode)
										{
											MedicalShop.StockDetailsSP stockDetailsSP = new MedicalShop.StockDetailsSP();
											MedicalShop.StockDetailsInfo stockDetailsInfo = new MedicalShop.StockDetailsInfo();
											if (this.dgvStock.Rows[e.RowIndex].Cells[11].Value == null)
											{
												num2 = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[8].Value.ToString());
												num3 = num1 + num2;
												if (productInfo.StockMaximumLevel < num3)
												{
													if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
													{
														if (!this.isSaved)
														{
															MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
														}
													}
												}
											}
											else
											{
												stockDetailsInfo = stockDetailsSP.StockDetailsView(this.dgvStock.Rows[e.RowIndex].Cells[11].Value.ToString());
												qty = stockDetailsInfo.Qty;
												num3 = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[8].Value.ToString());
												num2 = (num1 - qty) + num3;
												if (productInfo.StockMaximumLevel < num2)
												{
													if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
													{
														if (!this.isSaved)
														{
															MessageBox.Show("Exceeded maximum stock level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
														}
													}
												}
											}
										}
										else
										{
											num2 = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[8].Value.ToString());
											num3 = num1 + num2;
											if (productInfo.StockMaximumLevel < num3)
											{
												if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
												{
													if (!this.isSaved)
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
					if ((e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 4 ? true : e.ColumnIndex == 8))
					{
						if ((this.dgvStock.Rows[e.RowIndex].Cells[4].Value == null ? true : this.dgvStock.Rows[e.RowIndex].Cells[8].Value == null))
						{
							this.dgvStock.Rows[e.RowIndex].Cells[10].Value = "";
						}
						else if ((this.dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString() == "" ? true : !(this.dgvStock.Rows[e.RowIndex].Cells[8].Value.ToString() != "")))
						{
							this.dgvStock.Rows[e.RowIndex].Cells[10].Value = "";
						}
						else
						{
							decimal num5 = new decimal(0, 0, 0, false, 2);
							decimal num6 = new decimal(0, 0, 0, false, 2);
							decimal num7 = new decimal(0, 0, 0, false, 2);
							try
							{
								num5 = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString());
							}
							catch (Exception exception1)
							{
								num5 = new decimal(0);
							}
							try
							{
								num6 = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[8].Value.ToString());
							}
							catch (Exception exception2)
							{
								num6 = new decimal(0);
							}
							num7 = num5 * num6;
							this.dgvStock.Rows[e.RowIndex].Cells[10].Value = Math.Round(num7, 2);
						}
					}
				}
			}
			catch (Exception exception4)
			{
				Exception exception3 = exception4;
				MessageBox.Show(exception3.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
		}

		private void dgvStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = false;
			string str = "";
			ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
			ManufacturerSP manufacturerSP = new ManufacturerSP();
			UnitInfo unitInfo = new UnitInfo();
			UnitSP unitSP = new UnitSP();
			MedicalShop.ProductBatchInfo productBatchInfo = new MedicalShop.ProductBatchInfo();
			MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
			try
			{
				if (!this.isSearch)
				{
					this.CalculateTotal();
					if (this.dgvStock.CurrentCell != null)
					{
						if ((this.dgvStock.CurrentCell.ColumnIndex == 0 ? true : this.dgvStock.CurrentCell.ColumnIndex == 1))
						{
							MedicalShop.ProductInfo productInfo = new MedicalShop.ProductInfo();
							if (this.dgvStock.CurrentCell.Value != null)
							{
								if (this.dgvStock.CurrentCell.Value.ToString() != "")
								{
									string str1 = this.dgvStock.CurrentCell.Value.ToString();
									productInfo = this.productsp.ProductView(str1);
									if (productInfo.ProductId != null)
									{
										if (this.dgvStock.CurrentCell.ColumnIndex != 0)
										{
											this.dgvStock.CurrentRow.Cells[0].Value = str1;
										}
										else
										{
											this.FillComboItem();
											this.dgvStock.CurrentRow.Cells[1].Value = str1;
										}
										manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
										if (manufacturerInfo.ManufactureId != null)
										{
											this.dgvStock.CurrentRow.Cells[7].Value = manufacturerInfo.ManufactureName;
										}
										unitInfo = unitSP.UnitView(productInfo.UnitId);
										if (unitInfo.UnitName != null)
										{
											this.dgvStock.CurrentRow.Cells[9].Value = unitInfo.UnitName;
										}
									}
									else
									{
										this.dgvStock.CurrentRow.Cells[0].Value = "";
										this.dgvStock.Rows[e.RowIndex].Cells[2].Value = "";
									}
								}
							}
							else if (this.dgvStock.CurrentCell.ColumnIndex == 1)
							{
								this.dgvStock.CurrentRow.Cells[0].Value = "";
							}
						}
						if (e.ColumnIndex == 2)
						{
							string lower = "";
							if (this.dgvStock.CurrentRow.Cells[1].Value != null)
							{
								if (this.dgvStock.CurrentRow.Cells[1].Value.ToString() != "")
								{
									this.FillBatchCombo(this.dgvStock.CurrentRow.Cells[1].Value.ToString());
									for (int i = 0; i < this.lstbxBatch.Items.Count; i++)
									{
										lower = this.lstbxBatch.Items[i].ToString().ToLower();
										if (this.dgvStock.CurrentCell.Value == null)
										{
											this.lstbxBatch.SelectedItem = null;
										}
										else if (!lower.StartsWith(this.dgvStock.CurrentCell.Value.ToString().ToLower()))
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
							if ((this.dgvStock.Rows[e.RowIndex].Cells[1].Value == null ? true : this.dgvStock.Rows[e.RowIndex].Cells[2].Value == null))
							{
								flag = true;
							}
							else if ((this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() == "" ? true : !(this.dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString() != "")))
							{
								flag = true;
							}
							else
							{
								DataTable dataTable = new DataTable();
								string str2 = this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString();
								string lower1 = this.dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower();
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
									else if ((this.dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower().Trim() != productBatchInfo.BatchName.ToLower().Trim() ? true : !(this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() == productBatchInfo.ProductId)))
									{
										flag = true;
									}
									else
									{
										if (!(productBatchInfo.ExpiryDate == DateTime.Parse("01/01/1753")))
										{
											this.dgvStock.Rows[e.RowIndex].Cells[3].Value = productBatchInfo.ExpiryDate;
										}
										else
										{
											this.dgvStock.Rows[e.RowIndex].Cells[3].Value = "";
										}
										this.dgvStock.Rows[e.RowIndex].Cells[4].Value = Math.Round(productBatchInfo.PurchaseRate, 2);
										this.dgvStock.Rows[e.RowIndex].Cells[5].Value = Math.Round(productBatchInfo.SalesRate, 2);
										this.dgvStock.Rows[e.RowIndex].Cells[6].Value = Math.Round(productBatchInfo.MRP, 2);
										flag = false;
									}
								}
							}
							if (flag)
							{
								this.dgvStock.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
								this.dgvStock.Rows[e.RowIndex].Cells[4].Value = "";
								this.dgvStock.Rows[e.RowIndex].Cells[5].Value = "";
								this.dgvStock.Rows[e.RowIndex].Cells[6].Value = "";
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

		private void dgvStock_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvStock.CurrentCell is DataGridViewComboBoxCell)
				{
					this.dgvStock.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
				if (this.dgvStock.CurrentCell is DataGridViewTextBoxCell)
				{
					this.dgvStock.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			try
			{
				DataGridViewTextBoxEditingControl control = e.Control as DataGridViewTextBoxEditingControl;
				if (control != null)
				{
					control.KeyPress += new KeyPressEventHandler(this.TextBoxCellEditControlKeyPress);
				}
				if (this.dgvStock.CurrentCellAddress.X == this.cmbBatch.DisplayIndex)
				{
					ComboBox comboBox = e.Control as ComboBox;
					if (comboBox != null)
					{
						comboBox.DropDownStyle = ComboBoxStyle.DropDown;
					}
					this.currentCell = this.dgvStock.CurrentCell;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvStock.CurrentCell.ColumnIndex == 2 : false))
				{
					if (this.dgvStock.CurrentRow != null)
					{
						this.dgvStock.Rows[this.rowIndex].Cells[2].Value = "";
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

		private void dgvStock_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvStock.CurrentCell == this.dgvStock[10, this.dgvStock.Rows.Count - 1])
					{
						this.txtDescription.Focus();
						this.dgvStock.ClearSelection();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvStock.CurrentCell.ColumnIndex == 2 : false))
				{
					this.dgvStock.Rows[this.rowIndex].Cells[2].Value = "";
					this.lstbxBatch.Focus();
					if (this.lstbxBatch.SelectedValue != null)
					{
						this.lstbxBatch.SelectedIndex = 0;
					}
					e.Handled = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_Leave(object sender, EventArgs e)
		{
		}

		private void dgvStock_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 0)
				{
					if (this.dgvStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
					{
						this.dgvStock.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			try
			{
				this.FillComboItem();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_Scroll(object sender, ScrollEventArgs e)
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

		public void DoWhenComingFromStockRegister(MedicalShop.frmStockRegister frm, string strVcouherNo)
		{
			try
			{
				this.ClearFunction();
				base.Show();
				this.frmStockRegister = frm;
				this.isInEditMode = true;
				decimal num = new decimal(0, 0, 0, false, 2);
				decimal num1 = new decimal(0, 0, 0, false, 2);
				decimal num2 = new decimal(0, 0, 0, false, 2);
				MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
				DataTable dataTable = new DataTable();
				MedicalShop.ProductInfo productInfo = new MedicalShop.ProductInfo();
				ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
				ManufacturerSP manufacturerSP = new ManufacturerSP();
				UnitInfo unitInfo = new UnitInfo();
				UnitSP unitSP = new UnitSP();
				this.btnClear.Text = "&New";
				this.btnSave.Text = "&Update";
				this.btnDelete.Enabled = true;
				int productId = 0;
				this.FillComboItem();
				this.StockMasterInfo = this.StockMasterSP.StockMasterView(strVcouherNo);
				if (this.StockMasterInfo.StockMasterId != null)
				{
					this.txtVoucherNo.Text = this.StockMasterInfo.StockMasterId;
					this.dtpDate.Text = this.StockMasterInfo.Date.ToString();
					this.txtDescription.Text = this.StockMasterInfo.Description;
					dataTable = this.StockMasterSP.StockDetailsViewAllBystockMasterId(strVcouherNo);
					if (dataTable.Rows.Count > 0)
					{
						foreach (DataRow row in dataTable.Rows)
						{
							num = new decimal(0, 0, 0, false, 2);
							num1 = new decimal(0, 0, 0, false, 2);
							num2 = new decimal(0, 0, 0, false, 2);
							if (row.ItemArray[2].ToString() != null)
							{
								this.dgvStock.Rows.Add();
								this.ProductBatchInfo = productBatchSP.ProductBatchView(row.ItemArray[2].ToString());
								this.dgvStock.Rows[productId].Cells[0].Value = this.ProductBatchInfo.ProductId;
								productInfo = this.productsp.ProductView(this.ProductBatchInfo.ProductId);
								this.dgvStock.Rows[productId].Cells[1].Value = this.ProductBatchInfo.ProductId;
								this.FillBatchCombo(this.ProductBatchInfo.ProductId);
								this.dgvStock.Rows[productId].Cells[2].Value = this.ProductBatchInfo.BatchName;
								if (!(DateTime.Parse(this.ProductBatchInfo.ExpiryDate.ToString()) == DateTime.Parse("01/01/1753")))
								{
									this.dgvStock.Rows[productId].Cells[3].Value = this.ProductBatchInfo.ExpiryDate;
								}
								else
								{
									this.dgvStock.Rows[productId].Cells[3].Value = "";
								}
								DataGridViewCell item = this.dgvStock.Rows[productId].Cells[4];
								double num3 = double.Parse(row.ItemArray[5].ToString());
								item.Value = num3.ToString();
								DataGridViewCell str = this.dgvStock.Rows[productId].Cells[5];
								decimal salesRate = this.ProductBatchInfo.SalesRate;
								num3 = double.Parse(salesRate.ToString());
								str.Value = num3.ToString();
								DataGridViewCell dataGridViewCell = this.dgvStock.Rows[productId].Cells[6];
								salesRate = this.ProductBatchInfo.MRP;
								num3 = double.Parse(salesRate.ToString());
								dataGridViewCell.Value = num3.ToString();
								manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
								this.dgvStock.Rows[productId].Cells[7].Value = manufacturerInfo.ManufactureName;
								DataGridViewCell item1 = this.dgvStock.Rows[productId].Cells[8];
								num3 = double.Parse(row.ItemArray[3].ToString());
								item1.Value = num3.ToString();
								unitInfo = unitSP.UnitView(productInfo.UnitId);
								this.dgvStock.Rows[productId].Cells[9].Value = unitInfo.UnitName;
								if ((decimal.Parse(row.ItemArray[3].ToString()) == new decimal(0) ? true : !(row.ItemArray[5].ToString() != "")))
								{
									this.dgvStock.Rows[productId].Cells[10].Value = 0;
								}
								else
								{
									num = decimal.Parse(row.ItemArray[3].ToString());
									num1 = decimal.Parse(row.ItemArray[5].ToString());
									num2 = num * num1;
									this.dgvStock.Rows[productId].Cells[10].Value = Math.Round(num2, 2);
								}
								this.dgvStock.Rows[productId].Cells[11].Value = row.ItemArray[0].ToString();
								productId++;
							}
						}
						this.CalculateTotal();
					}
				}
				this.dtpDate.Focus();
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
					this.frmStockRegister.DoWhenComingFromStock(this.isInEditMode);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.dgvStock.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpDate_Leave(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvStock.Focused)
				{
					if (this.dgvStock.Rows.Count == 0)
					{
						this.dgvStock.Rows.Add();
					}
					this.dgvStock.Focus();
					this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
					this.dgvStock.ClearSelection();
					this.dgvStock.CurrentCell.Selected = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillBatchCombo(string productId)
		{
			try
			{
				this.lstbxBatch.Items.Clear();
				MedicalShop.ProductBatchInfo productBatchInfo = new MedicalShop.ProductBatchInfo();
				MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
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

		public void FillComboItem()
		{
			try
			{
				this.dtblItem = (new ProductSP()).ProductViewAll();
				if (this.dtblItem.Rows.Count > 0)
				{
					if (this.dtblItem.Rows.Count > 0)
					{
						DataRow dataRow = null;
						dataRow = this.dtblItem.NewRow();
						dataRow[0] = 0;
						dataRow[1] = "";
						this.dtblItem.Rows.InsertAt(dataRow, 0);
					}
					this.cmbProduct.DataSource = this.dtblItem;
					this.cmbProduct.ValueMember = this.dtblItem.Columns[0].ToString();
					this.cmbProduct.DisplayMember = this.dtblItem.Columns[1].ToString();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmJournalEntry_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
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
				else if (e.KeyCode == Keys.Escape)
				{
					if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
					{
						base.Close();
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmStock_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmStockEntry_KeyUp(object sender, KeyEventArgs e)
		{
		}

		private void frmStockEntry_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.isInEditMode)
				{
					this.ClearFunction();
					CompanySP companySP = new CompanySP();
					DataTable dataTable = new DataTable();
					dataTable = companySP.CompanyViewAll();
					if (dataTable.Rows.Count > 0)
					{
						this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
					}
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

		public string GenerateVoucherNumber()
		{
			string str = "";
			try
			{
				str = this.mastersp.StockMasterGetMax();
				this.txtVoucherNo.Text = str;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmStockEntry));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.pbxSearch = new PictureBox();
			this.lstbxBatch = new ListBox();
			this.dgvStock = new dgv.DataGridViewEnter();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.cmbProduct = new DataGridViewComboBoxColumn();
			this.cmbBatch = new DataGridViewTextBoxColumn();
			this.Column4 = new DateInGrid.CalendarColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.Column9 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column18 = new DataGridViewTextBoxColumn();
			this.Column19 = new DataGridViewTextBoxColumn();
			this.cbPrint = new CheckBox();
			this.txtDescription = new TextBox();
			this.label3 = new Label();
			this.lblAmount = new Label();
			this.lblDebitAmt = new Label();
			this.btnRemove = new Button();
			this.txtVoucherNo = new TextBox();
			this.label2 = new Label();
			this.label13 = new Label();
			this.dtpDate = new DateTimePicker();
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
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.pbxSearch).BeginInit();
			((ISupportInitialize)this.dgvStock).BeginInit();
			this.panel6.SuspendLayout();
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
			this.panel1.Size = new System.Drawing.Size(678, 431);
			this.panel1.TabIndex = 1;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(348, 383);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(429, 383);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(510, 383);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(591, 383);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.pbxSearch);
			this.panel8.Controls.Add(this.lstbxBatch);
			this.panel8.Controls.Add(this.dgvStock);
			this.panel8.Controls.Add(this.cbPrint);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.lblAmount);
			this.panel8.Controls.Add(this.lblDebitAmt);
			this.panel8.Controls.Add(this.btnRemove);
			this.panel8.Controls.Add(this.txtVoucherNo);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.dtpDate);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(676, 338);
			this.panel8.TabIndex = 2;
			this.pbxSearch.Image = (Image)componentResourceManager.GetObject("pbxSearch.Image");
			this.pbxSearch.Location = new Point(584, 8);
			this.pbxSearch.Name = "pbxSearch";
			this.pbxSearch.Size = new System.Drawing.Size(81, 28);
			this.pbxSearch.TabIndex = 36456461;
			this.pbxSearch.TabStop = false;
			this.pbxSearch.Click += new EventHandler(this.btnSearch_Click);
			this.pbxSearch.MouseHover += new EventHandler(this.pbxSearch_MouseHover);
			this.lstbxBatch.FormattingEnabled = true;
			this.lstbxBatch.Location = new Point(315, 98);
			this.lstbxBatch.Name = "lstbxBatch";
			this.lstbxBatch.Size = new System.Drawing.Size(150, 95);
			this.lstbxBatch.TabIndex = 36456460;
			this.lstbxBatch.TabStop = false;
			this.lstbxBatch.DoubleClick += new EventHandler(this.lstbxBatch_DoubleClick);
			this.lstbxBatch.KeyDown += new KeyEventHandler(this.lstbxBatch_KeyDown);
			this.dgvStock.AllowUserToDeleteRows = false;
			this.dgvStock.AllowUserToResizeColumns = false;
			this.dgvStock.AllowUserToResizeRows = false;
			this.dgvStock.BackgroundColor = Color.White;
			this.dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvStock.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.cmbProduct, this.cmbBatch, this.Column4, this.Column5, this.Column2, this.Column3, this.Column8, this.Column9, this.Column11, this.Column18, this.Column19 };
			columns.AddRange(column1);
			this.dgvStock.GridColor = Color.WhiteSmoke;
			this.dgvStock.Location = new Point(13, 52);
			this.dgvStock.Name = "dgvStock";
			this.dgvStock.RowHeadersVisible = false;
			this.dgvStock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvStock.Size = new System.Drawing.Size(652, 183);
			this.dgvStock.TabIndex = 3;
			this.dgvStock.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dgvStock_CellBeginEdit);
			this.dgvStock.CellLeave += new DataGridViewCellEventHandler(this.dgvStock_CellLeave);
			this.dgvStock.KeyDown += new KeyEventHandler(this.dgvStock_KeyDown);
			this.dgvStock.RowEnter += new DataGridViewCellEventHandler(this.dgvStock_RowEnter);
			this.dgvStock.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvStock_RowsAdded);
			this.dgvStock.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvStock_CellValidating);
			this.dgvStock.CurrentCellDirtyStateChanged += new EventHandler(this.dgvStock_CurrentCellDirtyStateChanged);
			this.dgvStock.CellEndEdit += new DataGridViewCellEventHandler(this.dgvStock_CellEndEdit);
			this.dgvStock.CellValueChanged += new DataGridViewCellEventHandler(this.dgvStock_CellValueChanged);
			this.dgvStock.Scroll += new ScrollEventHandler(this.dgvStock_Scroll);
			this.dgvStock.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvStock_EditingControlShowing);
			this.dgvStock.KeyUp += new KeyEventHandler(this.dgvStock_KeyUp);
			this.dgvStock.CellEnter += new DataGridViewCellEventHandler(this.dgvStock_CellEnter);
			this.dgvStock.KeyPress += new KeyPressEventHandler(this.dgvStock_KeyPress);
			dataGridViewCellStyle.SelectionForeColor = Color.White;
			this.Column1.DefaultCellStyle = dataGridViewCellStyle;
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
			dataGridViewCellStyle1.NullValue = null;
			this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column4.HeaderText = "Expiry Date";
			this.Column4.Name = "Column4";
			this.Column4.Resizable = DataGridViewTriState.False;
			this.Column5.HeaderText = "Purchase Rate";
			this.Column5.MaxInputLength = 7;
			this.Column5.Name = "Column5";
			this.Column5.Resizable = DataGridViewTriState.False;
			this.Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column2.HeaderText = "Sales Rate";
			this.Column2.MaxInputLength = 7;
			this.Column2.Name = "Column2";
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column3.HeaderText = "MRP";
			this.Column3.MaxInputLength = 7;
			this.Column3.Name = "Column3";
			this.Column3.Resizable = DataGridViewTriState.False;
			this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column8.HeaderText = "Manufacture";
			this.Column8.MaxInputLength = 500;
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Resizable = DataGridViewTriState.False;
			this.Column8.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column9.HeaderText = "Qty";
			this.Column9.MaxInputLength = 6;
			this.Column9.Name = "Column9";
			this.Column9.Resizable = DataGridViewTriState.False;
			this.Column9.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column11.HeaderText = "Unit";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			this.Column11.Resizable = DataGridViewTriState.False;
			this.Column11.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column18.HeaderText = "Amount";
			this.Column18.Name = "Column18";
			this.Column18.ReadOnly = true;
			this.Column18.Resizable = DataGridViewTriState.False;
			this.Column18.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column19.HeaderText = "StockDetailsId";
			this.Column19.Name = "Column19";
			this.Column19.ReadOnly = true;
			this.Column19.Resizable = DataGridViewTriState.False;
			this.Column19.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column19.Visible = false;
			this.cbPrint.AutoSize = true;
			this.cbPrint.Location = new Point(95, 316);
			this.cbPrint.Name = "cbPrint";
			this.cbPrint.Size = new System.Drawing.Size(97, 17);
			this.cbPrint.TabIndex = 5;
			this.cbPrint.Text = "Print after save";
			this.cbPrint.UseVisualStyleBackColor = true;
			this.txtDescription.Location = new Point(95, 248);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(222, 62);
			this.txtDescription.TabIndex = 4;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 251);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 98;
			this.label3.Text = "Description:";
			this.lblAmount.AutoSize = true;
			this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblAmount.Location = new Point(537, 246);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(32, 13);
			this.lblAmount.TabIndex = 97;
			this.lblAmount.Text = "0.00";
			this.lblDebitAmt.AutoSize = true;
			this.lblDebitAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblDebitAmt.Location = new Point(482, 246);
			this.lblDebitAmt.Name = "lblDebitAmt";
			this.lblDebitAmt.Size = new System.Drawing.Size(40, 13);
			this.lblDebitAmt.TabIndex = 96;
			this.lblDebitAmt.Text = "Total:";
			this.btnRemove.BackColor = Color.SteelBlue;
			this.btnRemove.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRemove.ForeColor = Color.White;
			this.btnRemove.Location = new Point(593, 241);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(63, 23);
			this.btnRemove.TabIndex = 6;
			this.btnRemove.TabStop = false;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.txtVoucherNo.BackColor = Color.WhiteSmoke;
			this.txtVoucherNo.Location = new Point(106, 13);
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.ReadOnly = true;
			this.txtVoucherNo.Size = new System.Drawing.Size(238, 20);
			this.txtVoucherNo.TabIndex = 1;
			this.txtVoucherNo.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Voucher No:";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(357, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 53;
			this.label13.Text = "Date:";
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(396, 13);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(131, 20);
			this.dtpDate.TabIndex = 2;
			this.dtpDate.Leave += new EventHandler(this.dtpDate_Leave);
			this.dtpDate.KeyPress += new KeyPressEventHandler(this.dtpDate_KeyPress);
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(676, 33);
			this.panel6.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Stock Entry";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(676, 1);
			this.panel7.TabIndex = 1;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 430);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(676, 1);
			this.panel5.TabIndex = 1;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(676, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(677, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 431);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 431);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "SI";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 329;
			this.dataGridViewTextBoxColumn2.HeaderText = "Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 328;
			this.dataGridViewTextBoxColumn3.HeaderText = "Description";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Visible = false;
			this.dataGridViewTextBoxColumn3.Width = 219;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(692, 445);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmStockEntry";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Stock Entry";
			base.FormClosing += new FormClosingEventHandler(this.frmStock_FormClosing);
			base.KeyUp += new KeyEventHandler(this.frmStockEntry_KeyUp);
			base.KeyDown += new KeyEventHandler(this.frmJournalEntry_KeyDown);
			base.Load += new EventHandler(this.frmStockEntry_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.pbxSearch).EndInit();
			((ISupportInitialize)this.dgvStock).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void lstbxBatch_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvStock.CurrentRow != null)
				{
					if (this.rowIndex >= 0)
					{
						if (this.lstbxBatch.Text != "")
						{
							this.dgvStock.Rows[this.rowIndex].Cells[2].Value = this.lstbxBatch.Text;
						}
						this.dgvStock.Rows[this.rowIndex].Cells[2].Selected = true;
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
					if (this.dgvStock.CurrentRow != null)
					{
						if (this.rowIndex >= 0)
						{
							if (this.lstbxBatch.Text != "")
							{
								this.dgvStock.Rows[this.rowIndex].Cells[2].Value = this.lstbxBatch.Text;
							}
							this.lstbxBatch.Visible = false;
							this.dgvStock.Focus();
							this.dgvStock.Rows[this.rowIndex].Cells[2].Selected = true;
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

		private void pbxSearch_MouseHover(object sender, EventArgs e)
		{
			try
			{
				this.pbxSearch.Cursor = Cursors.Hand;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void ReturnFromPopUp(DataTable dtbl)
		{
			base.Enabled = true;
			int count = this.dgvStock.Rows.Count - 1;
			this.FillComboItem();
			ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
			ManufacturerSP manufacturerSP = new ManufacturerSP();
			UnitInfo unitInfo = new UnitInfo();
			UnitSP unitSP = new UnitSP();
			foreach (DataRow row in dtbl.Rows)
			{
				bool flag = false;
				foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvStock.Rows)
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
					this.dgvStock.Rows.Add();
					this.dgvStock.Rows[count].Cells[0].Value = row.ItemArray[0].ToString();
					this.dgvStock.Rows[count].Cells[1].Value = row.ItemArray[0].ToString();
					this.FillBatchCombo(row.ItemArray[0].ToString());
					this.dgvStock.Rows[count].Cells[2].Value = row.ItemArray[1].ToString();
					this.ProductInfo = this.productsp.ProductView(row.ItemArray[0].ToString());
					manufacturerInfo = manufacturerSP.ManufacturerView(this.ProductInfo.ManufactureId);
					if (manufacturerInfo.ManufactureId != null)
					{
						this.dgvStock.Rows[count].Cells[7].Value = manufacturerInfo.ManufactureName;
					}
					unitInfo = unitSP.UnitView(this.ProductInfo.UnitId);
					if (unitInfo.UnitName != null)
					{
						this.dgvStock.Rows[count].Cells[9].Value = unitInfo.UnitName;
					}
					count++;
				}
			}
			this.dgvStock.Focus();
		}

		public void SaveOrEdit()
		{
			try
			{
				string text = "";
				string str = "";
				string str1 = "";
				MedicalShop.ProductBatchInfo productBatchInfo = new MedicalShop.ProductBatchInfo();
				if (this.txtVoucherNo.Text != "")
				{
					if (this.isInEditMode)
					{
						text = this.txtVoucherNo.Text;
					}
					else
					{
						text = this.GenerateVoucherNumber();
						if (text != this.txtVoucherNo.Text)
						{
							MessageBox.Show(string.Concat("Voucher number changed from ", this.txtVoucherNo.Text, "to ", text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					this.txtVoucherNo.Text = text;
					this.StockMasterInfo.StockMasterId = text;
					this.StockMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
					this.StockMasterInfo.Description = this.txtDescription.Text.Trim();
					if (this.isInEditMode)
					{
						this.StockDetailsSP.StockDetailsDeleteByMasterId(this.txtVoucherNo.Text);
					}
					foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
					{
						if ((row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null ? false : row.Cells[8].Value != null))
						{
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != "") ? false : row.Cells[8].Value.ToString() != ""))
							{
								if (row.Cells[2].Value != null)
								{
									if (row.Cells[2].Value.ToString() != "")
									{
										this.ProductBatchInfo.ProductId = row.Cells[1].Value.ToString();
										if (row.Cells[2].Value == null)
										{
											this.ProductBatchInfo.BatchName = "";
										}
										else if (!(row.Cells[2].Value.ToString() == ""))
										{
											this.ProductBatchInfo.BatchName = row.Cells[2].Value.ToString();
										}
										else
										{
											this.ProductBatchInfo.BatchName = "";
										}
										if (row.Cells[3].Value == null)
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
										}
										else if (!(row.Cells[3].Value.ToString() == ""))
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse(row.Cells[3].Value.ToString());
											this.ProductBatchInfo.ExpiryDate = this.ProductBatchInfo.ExpiryDate.Date;
										}
										else
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
										}
										if (row.Cells[2].Value.ToString() == "NA")
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
										}
										if (row.Cells[4].Value == null)
										{
											this.ProductBatchInfo.PurchaseRate = new decimal(0);
										}
										else if (!(row.Cells[4].Value.ToString() == ""))
										{
											this.ProductBatchInfo.PurchaseRate = decimal.Parse(row.Cells[4].Value.ToString());
										}
										else
										{
											this.ProductBatchInfo.PurchaseRate = new decimal(0);
										}
										if (row.Cells[5].Value == null)
										{
											this.ProductBatchInfo.SalesRate = new decimal(0);
										}
										else if (!(row.Cells[5].Value.ToString() == ""))
										{
											this.ProductBatchInfo.SalesRate = decimal.Parse(row.Cells[5].Value.ToString());
										}
										else
										{
											this.ProductBatchInfo.SalesRate = new decimal(0);
										}
										if (row.Cells[6].Value == null)
										{
											this.ProductBatchInfo.MRP = new decimal(0);
										}
										else if (!(row.Cells[6].Value.ToString() == ""))
										{
											this.ProductBatchInfo.MRP = decimal.Parse(row.Cells[6].Value.ToString());
										}
										else
										{
											this.ProductBatchInfo.MRP = new decimal(0);
										}
										this.ProductBatchInfo.Description = "";
										str1 = "";
										string str2 = row.Cells[1].Value.ToString();
										string str3 = row.Cells[2].Value.ToString();
										DataTable dataTable = new DataTable();
										dataTable = this.ProductBatchSP.ProductBatchViewByProductAndBatchName(str2, str3);
										if (dataTable.Rows.Count > 0)
										{
											str1 = dataTable.Rows[0].ItemArray[0].ToString();
										}
										if (!(str1 != ""))
										{
											str = this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
										}
										else
										{
											productBatchInfo = this.ProductBatchSP.ProductBatchView(str1);
											if (productBatchInfo.ProductBatchId == null)
											{
												str = this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
											}
											else if ((str1 != productBatchInfo.ProductBatchId ? true : !(row.Cells[1].Value.ToString() == productBatchInfo.ProductId)))
											{
												str = this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
											}
											else
											{
												this.ProductBatchInfo.ProductBatchId = str1;
												if (row.Cells[4].Value == null)
												{
													this.ProductBatchInfo.PurchaseRate = productBatchInfo.PurchaseRate;
												}
												else if (row.Cells[4].Value.ToString() == "")
												{
													this.ProductBatchInfo.PurchaseRate = productBatchInfo.PurchaseRate;
												}
												else if (!(decimal.Parse(row.Cells[4].Value.ToString()) == new decimal(0)))
												{
													this.ProductBatchInfo.PurchaseRate = decimal.Parse(row.Cells[4].Value.ToString());
												}
												else
												{
													this.ProductBatchInfo.PurchaseRate = productBatchInfo.PurchaseRate;
												}
												if (row.Cells[5].Value == null)
												{
													this.ProductBatchInfo.SalesRate = productBatchInfo.SalesRate;
												}
												else if (row.Cells[5].Value.ToString() == "")
												{
													this.ProductBatchInfo.SalesRate = productBatchInfo.SalesRate;
												}
												else if (!(decimal.Parse(row.Cells[5].Value.ToString()) == new decimal(0)))
												{
													this.ProductBatchInfo.SalesRate = decimal.Parse(row.Cells[5].Value.ToString());
												}
												else
												{
													this.ProductBatchInfo.SalesRate = productBatchInfo.SalesRate;
												}
												if (row.Cells[6].Value == null)
												{
													this.ProductBatchInfo.MRP = productBatchInfo.MRP;
												}
												else if (row.Cells[6].Value.ToString() == "")
												{
													this.ProductBatchInfo.MRP = productBatchInfo.MRP;
												}
												else if (!(decimal.Parse(row.Cells[6].Value.ToString()) == new decimal(0)))
												{
													this.ProductBatchInfo.MRP = decimal.Parse(row.Cells[6].Value.ToString());
												}
												else
												{
													this.ProductBatchInfo.MRP = productBatchInfo.MRP;
												}
												this.ProductBatchSP.ProductBatchEdit(this.ProductBatchInfo);
												str = str1;
											}
										}
										this.StockDetailsInfo.StockMasterId = text;
										this.StockDetailsInfo.ProductBatchId = str;
										if (row.Cells[4].Value == null)
										{
											this.StockDetailsInfo.Rate = new decimal(0);
										}
										else if (!(row.Cells[4].Value.ToString() == ""))
										{
											this.StockDetailsInfo.Rate = decimal.Parse(row.Cells[4].Value.ToString());
										}
										else
										{
											this.StockDetailsInfo.Rate = new decimal(0);
										}
										if (row.Cells[8].Value == null)
										{
											this.StockDetailsInfo.Qty = new decimal(0);
										}
										else if (!(row.Cells[8].Value.ToString() == ""))
										{
											this.StockDetailsInfo.Qty = decimal.Parse(row.Cells[8].Value.ToString());
										}
										else
										{
											this.StockDetailsInfo.Qty = new decimal(0);
										}
										this.StockDetailsInfo.Description = "";
										this.StockDetailsSP.StockDetailsAdd(this.StockDetailsInfo);
										this.StockPostingInfo.VoucherNumber = text;
										this.StockPostingInfo.ProductBatchId = str;
										this.StockPostingInfo.InwardQuantity = decimal.Parse(row.Cells[8].Value.ToString());
										this.StockPostingInfo.OutwardQuantity = new decimal(0);
										this.StockPostingInfo.VoucherType = "Stock Entry";
										this.StockPostingInfo.Description = "";
										this.StockPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
										this.StockPostingSP.StockPostingAdd(this.StockPostingInfo);
									}
								}
							}
						}
					}
					if (this.isInEditMode)
					{
						this.StockMasterSP.StockMasterEdit(this.StockMasterInfo);
					}
					else
					{
						this.StockMasterSP.StockMasterAdd(this.StockMasterInfo);
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
				if ((this.dgvStock.CurrentCell.ColumnIndex == 4 || this.dgvStock.CurrentCell.ColumnIndex == 5 || this.dgvStock.CurrentCell.ColumnIndex == 6 ? true : this.dgvStock.CurrentCell.ColumnIndex == 8))
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

		private void txtDescription_Enter(object sender, EventArgs e)
		{
			try
			{
				string str = this.txtDescription.Text.Trim();
				if (!(str == ""))
				{
					this.txtDescription.SelectionStart = str.Length;
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

		private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.i = 0;
				}
				else
				{
					frmStockEntry _frmStockEntry = this;
					_frmStockEntry.i = _frmStockEntry.i + 1;
					if (this.i == 2)
					{
						this.i = 0;
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
	}
}