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
	public class frmDamageStock : Form
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

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewComboBoxColumn cmbProduct;

		private DataGridViewComboBoxColumn cmbBatch;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column8;

		private DataGridViewTextBoxColumn c;

		private DataGridViewTextBoxColumn Column9;

		private DataGridViewTextBoxColumn Column11;

		private DataGridViewTextBoxColumn Column18;

		private DataGridViewTextBoxColumn Column19;

		private DamageStcokMasterSP damageStockMasterSP = new DamageStcokMasterSP();

		private DamageStockDetailsSP damageStockDetailsSP = new DamageStockDetailsSP();

		private DamageStcokMasterInfo damageStockMasterInfo = new DamageStcokMasterInfo();

		private DamageStockDetailsInfo damageStockDetailsInfo = new DamageStockDetailsInfo();

		private MedicalShop.StockPostingInfo StockPostingInfo = new MedicalShop.StockPostingInfo();

		private MedicalShop.StockPostingSP StockPostingSP = new MedicalShop.StockPostingSP();

		private MedicalShop.ProductBatchInfo ProductBatchInfo = new MedicalShop.ProductBatchInfo();

		private MedicalShop.ProductBatchSP ProductBatchSP = new MedicalShop.ProductBatchSP();

		private ProductSP productsp = new ProductSP();

		private MedicalShop.ProductInfo ProductInfo = new MedicalShop.ProductInfo();

		private bool isEditBatchNull = false;

		private bool isSaved = false;
        private string damageStockMasterId = "";

        private string strDefaultCurrency = "";

		private bool isInEditMode = false;

		private DataTable dtblItem = new DataTable();

		private MedicalShop.frmDamageStockRegister frmDamageStockRegister;

		private int i = 0;

		private bool isFormClose = false;

		public frmDamageStock()
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
                //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                damageStockMasterSP.DamageStcokMasterDelete(damageStockMasterId);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearFunction();


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
				if (this.dgvStock.CurrentRow != null)
				{
					try
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
					catch (Exception exception)
					{
					}
					if (this.dgvStock.Rows.Count > 0)
					{
						this.dgvStock.Focus();
						this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
					}
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
						this.dgvStock.Focus();
						this.dgvStock.ClearSelection();
						this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
						this.dgvStock.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckQuantityNull())
				{
					MessageBox.Show("Incomplete  details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvStock.Rows.Count > 0)
					{
						this.dgvStock.Focus();
						this.dgvStock.ClearSelection();
						this.dgvStock.CurrentCell = this.dgvStock.Rows[0].Cells[0];
						this.dgvStock.Rows[0].Cells[0].Selected = true;
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

		public void CalculateTotal()
		{
			try
			{
				decimal num = new decimal(0);
				foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
				{
					if (row.Cells[8].Value != null)
					{
						if (row.Cells[8].Value.ToString() != "")
						{
							num = num + decimal.Parse(row.Cells[8].Value.ToString());
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
						if ((row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null ? false : row.Cells[6].Value != null))
						{
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != "") ? false : row.Cells[6].Value.ToString() != ""))
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
								if ((row.Cells[1].Value.ToString() == "" ? false : row.Cells[2].Value.ToString() != ""))
								{
									if ((Id != row.Cells[1].Value.ToString() ? true : !(Batch == row.Cells[2].Value.ToString())))
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
						if (row.Cells[6].Value == null)
						{
							flag = true;
							break;
						}
						else if (row.Cells[6].Value.ToString() == "")
						{
							flag = true;
							break;
						}
						else if (!(decimal.Parse(row.Cells[6].Value.ToString()) <= new decimal(0)))
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
				this.dtpDate.Text = "";
				this.txtDescription.Clear();
				this.btnDelete.Enabled = false;
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.btnDelete.Enabled = false;
				this.lblAmount.Text = "0.00";
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
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.frmDamageStockRegister.Close();
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

		private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				MedicalShop.ProductBatchInfo productBatchInfo = new MedicalShop.ProductBatchInfo();
				MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					if (e.ColumnIndex == 6)
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
					if ((e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 ? true : e.ColumnIndex == 6))
					{
						if ((this.dgvStock.Rows[e.RowIndex].Cells[3].Value == null ? true : this.dgvStock.Rows[e.RowIndex].Cells[6].Value == null))
						{
							this.dgvStock.Rows[e.RowIndex].Cells[8].Value = "";
						}
						else if ((this.dgvStock.Rows[e.RowIndex].Cells[3].Value.ToString() == "" ? true : !(this.dgvStock.Rows[e.RowIndex].Cells[6].Value.ToString() != "")))
						{
							this.dgvStock.Rows[e.RowIndex].Cells[8].Value = "";
						}
						else
						{
							decimal num = new decimal(0, 0, 0, false, 2);
							decimal num1 = new decimal(0, 0, 0, false, 2);
							decimal num2 = new decimal(0, 0, 0, false, 2);
							try
							{
								num = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[3].Value.ToString());
							}
							catch (Exception exception)
							{
								num = new decimal(0);
							}
							try
							{
								num1 = decimal.Parse(this.dgvStock.Rows[e.RowIndex].Cells[6].Value.ToString());
							}
							catch (Exception exception1)
							{
								num1 = new decimal(0);
							}
							num2 = num * num1;
							this.dgvStock.Rows[e.RowIndex].Cells[8].Value = Math.Round(num2, 2);
						}
					}
				}
			}
			catch (Exception exception3)
			{
				Exception exception2 = exception3;
				MessageBox.Show(exception2.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvStock_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 2)
				{
					if ((this.dgvStock.CurrentRow.Cells[0].Value == null ? false : this.dgvStock.CurrentRow.Cells[1].Value != null))
					{
						if ((this.dgvStock.CurrentRow.Cells[0].Value.ToString() == "" ? false : this.dgvStock.CurrentRow.Cells[1].Value.ToString() != ""))
						{
							DataGridViewComboBoxCell item = (DataGridViewComboBoxCell)this.dgvStock[e.ColumnIndex, e.RowIndex];
							item.DataSource = null;
							MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
							DataTable dataTable = new DataTable();
							dataTable = productBatchSP.ProductBatchViewAllByProductId(this.dgvStock.CurrentRow.Cells[e.ColumnIndex - 1].Value.ToString());
							item.DataSource = dataTable;
							item.ValueMember = dataTable.Columns[2].ToString();
							item.DisplayMember = dataTable.Columns[2].ToString();
						}
					}
				}
				this.dgvStock.BeginEdit(true);
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
						flag = (this.dgvStock.CurrentCell.ColumnIndex == 3 || this.dgvStock.CurrentCell.ColumnIndex == 5 ? false : this.dgvStock.CurrentCell.ColumnIndex != 6);
					}
					if (!flag)
					{
						try
						{
							if ((this.dgvStock.CurrentRow.Cells[0].Value == null ? false : this.dgvStock.CurrentRow.Cells[1].Value != null))
							{
								if ((this.dgvStock.CurrentRow.Cells[0].Value.ToString() == "" ? false : this.dgvStock.CurrentRow.Cells[1].Value.ToString() != ""))
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
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
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
			DataTable dataTable = new DataTable();
			try
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
									if (!this.isEditBatchNull)
									{
										this.dgvStock.Rows[e.RowIndex].Cells[2].Value = "";
									}
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
										this.dgvStock.CurrentRow.Cells[4].Value = manufacturerInfo.ManufactureName;
									}
									unitInfo = unitSP.UnitView(productInfo.UnitId);
									if (unitInfo.UnitName != null)
									{
										this.dgvStock.CurrentRow.Cells[7].Value = unitInfo.UnitName;
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
							DataTable dataTable1 = new DataTable();
							string str2 = this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString();
							string str3 = this.dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString();
							dataTable1 = productBatchSP.ProductBatchViewByProductAndBatchName(str2, str3);
							if (dataTable1.Rows.Count > 0)
							{
								str = dataTable1.Rows[0].ItemArray[0].ToString();
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
								else if ((this.dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString() != productBatchInfo.BatchName ? true : !(this.dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() == productBatchInfo.ProductId)))
								{
									flag = true;
								}
								else
								{
									dataTable = this.productsp.CurrentQuantiyOfProduct(str);
									if (dataTable.Rows.Count <= 0)
									{
										this.dgvStock.Rows[e.RowIndex].Cells[5].Value = 0;
									}
									else
									{
										this.dgvStock.Rows[e.RowIndex].Cells[5].Value = dataTable.Rows[0].ItemArray[0].ToString();
									}
									this.dgvStock.Rows[e.RowIndex].Cells[3].Value = Math.Round(productBatchInfo.PurchaseRate, 2);
									flag = false;
								}
							}
						}
						if (flag)
						{
							this.dgvStock.Rows[e.RowIndex].Cells[3].Value = "";
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
					if (this.dgvStock.CurrentCell == this.dgvStock[8, this.dgvStock.Rows.Count - 1])
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

		private void dgvStock_Leave(object sender, EventArgs e)
		{
		}

		private void dgvStock_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
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

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void DoWhenComingFromStockRegister(MedicalShop.frmDamageStockRegister frm, string strVcouherNo)
		{
			try
			{
				this.ClearFunction();
				base.Show();
				this.isEditBatchNull = true;
				this.frmDamageStockRegister = frm;
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
				this.damageStockMasterInfo = this.damageStockMasterSP.DamageStcokMasterView(strVcouherNo);
				if (this.damageStockMasterInfo.DamageStockMasterId != null)
				{
					this.txtVoucherNo.Text = this.damageStockMasterInfo.DamageStockMasterId;
					this.dtpDate.Text = this.damageStockMasterInfo.Date.ToString();
					this.txtDescription.Text = this.damageStockMasterInfo.Description;
					DataTable dataTable1 = new DataTable();
					dataTable = this.damageStockDetailsSP.DamageStockDetailsViewByMasterId(strVcouherNo);
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
								DataGridViewComboBoxCell item = (DataGridViewComboBoxCell)this.dgvStock[2, productId];
								dataTable1 = this.ProductBatchSP.ProductBatchViewAllByProductId(this.ProductBatchInfo.ProductId);
								item.DataSource = dataTable1;
								item.ValueMember = dataTable1.Columns[2].ToString();
								item.DisplayMember = dataTable1.Columns[2].ToString();
								this.dgvStock.Rows[productId].Cells[2].Value = this.ProductBatchInfo.BatchName;
								this.dgvStock.Rows[productId].Cells[3].Value = this.ProductBatchInfo.PurchaseRate;
								manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
								this.dgvStock.Rows[productId].Cells[4].Value = manufacturerInfo.ManufactureName;
								DataTable dataTable2 = new DataTable();
								dataTable2 = this.productsp.CurrentQuantiyOfProduct(this.ProductBatchInfo.ProductBatchId);
								if (dataTable2.Rows.Count <= 0)
								{
									this.dgvStock.Rows[productId].Cells[5].Value = 0;
								}
								else
								{
									this.dgvStock.Rows[productId].Cells[5].Value = decimal.Parse(dataTable2.Rows[0].ItemArray[0].ToString()) + decimal.Parse(row.ItemArray[3].ToString());
								}
								DataGridViewCell str = this.dgvStock.Rows[productId].Cells[6];
								double num3 = double.Parse(row.ItemArray[3].ToString());
								str.Value = num3.ToString();
								unitInfo = unitSP.UnitView(productInfo.UnitId);
								this.dgvStock.Rows[productId].Cells[7].Value = unitInfo.UnitName;
								if (!(decimal.Parse(row.ItemArray[3].ToString()) != new decimal(0)))
								{
									this.dgvStock.Rows[productId].Cells[8].Value = 0;
								}
								else
								{
									decimal purchaseRate = this.ProductBatchInfo.PurchaseRate;
									num = decimal.Parse(purchaseRate.ToString());
									num1 = decimal.Parse(row.ItemArray[3].ToString());
									num2 = num * num1;
									this.dgvStock.Rows[productId].Cells[8].Value = Math.Round(num2, 2);
								}
								this.dgvStock.Rows[productId].Cells[9].Value = row.ItemArray[0].ToString();
								productId++;
							}
						}
						this.CalculateTotal();
					}
				}
				this.isEditBatchNull = false;
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
					this.frmDamageStockRegister.DoWhenComingFromStock(this.isInEditMode);
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

		public void FillComboItem()
		{
			try
			{
				this.cmbProduct.DataSource = null;
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
				str = this.damageStockMasterSP.DamageStcokMasterGetMax();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDamageStock));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.dgvStock = new dgv.DataGridViewEnter();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.cmbProduct = new DataGridViewComboBoxColumn();
			this.cmbBatch = new DataGridViewComboBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.c = new DataGridViewTextBoxColumn();
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
			this.dgvStock.AllowUserToDeleteRows = false;
			this.dgvStock.AllowUserToResizeColumns = false;
			this.dgvStock.AllowUserToResizeRows = false;
			this.dgvStock.BackgroundColor = Color.White;
			this.dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvStock.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.cmbProduct, this.cmbBatch, this.Column5, this.Column8, this.c, this.Column9, this.Column11, this.Column18, this.Column19 };
			columns.AddRange(column1);
			this.dgvStock.GridColor = Color.WhiteSmoke;
			this.dgvStock.Location = new Point(13, 52);
			this.dgvStock.Name = "dgvStock";
			this.dgvStock.RowHeadersVisible = false;
			this.dgvStock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvStock.Size = new System.Drawing.Size(652, 183);
			this.dgvStock.TabIndex = 3;
			this.dgvStock.CellLeave += new DataGridViewCellEventHandler(this.dgvStock_CellLeave);
			this.dgvStock.RowEnter += new DataGridViewCellEventHandler(this.dgvStock_RowEnter);
			this.dgvStock.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvStock_RowsAdded);
			this.dgvStock.CurrentCellDirtyStateChanged += new EventHandler(this.dgvStock_CurrentCellDirtyStateChanged);
			this.dgvStock.CellEndEdit += new DataGridViewCellEventHandler(this.dgvStock_CellEndEdit);
			this.dgvStock.CellValueChanged += new DataGridViewCellEventHandler(this.dgvStock_CellValueChanged);
			this.dgvStock.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvStock_EditingControlShowing);
			this.dgvStock.CellEnter += new DataGridViewCellEventHandler(this.dgvStock_CellEnter);
			this.dgvStock.KeyPress += new KeyPressEventHandler(this.dgvStock_KeyPress);
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
			this.cmbBatch.Width = 150;
			this.Column5.HeaderText = "Rate";
			this.Column5.MaxInputLength = 7;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = DataGridViewTriState.False;
			this.Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column8.HeaderText = "Manufacture";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Resizable = DataGridViewTriState.False;
			this.Column8.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.c.HeaderText = "Current Qty";
			this.c.Name = "c";
			this.c.ReadOnly = true;
			this.c.Resizable = DataGridViewTriState.False;
			this.c.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.c.Visible = false;
			this.Column9.HeaderText = "Damaged Qty";
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
			this.lblAmount.Location = new Point(470, 246);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(32, 13);
			this.lblAmount.TabIndex = 97;
			this.lblAmount.Text = "0.00";
			this.lblDebitAmt.AutoSize = true;
			this.lblDebitAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblDebitAmt.Location = new Point(415, 246);
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
			this.label13.Location = new Point(427, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 53;
			this.label13.Text = "Date:";
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(485, 13);
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
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Damage Stock";
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
			base.Name = "frmDamageStock";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Damage Stock";
			base.FormClosing += new FormClosingEventHandler(this.frmStock_FormClosing);
			base.KeyUp += new KeyEventHandler(this.frmStockEntry_KeyUp);
			base.KeyDown += new KeyEventHandler(this.frmJournalEntry_KeyDown);
			base.Load += new EventHandler(this.frmStockEntry_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvStock).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		public void SaveOrEdit()
		{
			try
			{
				string text = "";
				string str = "";
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
					this.damageStockMasterInfo.DamageStockMasterId = text;
					this.damageStockMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
					this.damageStockMasterInfo.Description = "";
					if (this.isInEditMode)
					{
						this.damageStockDetailsSP.DamageStockDetailsDeleteByMasterId(this.txtVoucherNo.Text);
					}
					foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
					{
						if ((row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null ? false : row.Cells[6].Value != null))
						{
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != "") ? false : row.Cells[6].Value.ToString() != ""))
							{
								str = "";
								string str1 = row.Cells[1].Value.ToString();
								string str2 = row.Cells[2].Value.ToString();
								DataTable dataTable = new DataTable();
								dataTable = this.ProductBatchSP.ProductBatchViewByProductAndBatchName(str1, str2);
								if (dataTable.Rows.Count > 0)
								{
									str = dataTable.Rows[0].ItemArray[0].ToString();
								}
								if (str != "")
								{
									this.damageStockDetailsInfo.DamageStockMasterId = text;
									this.damageStockDetailsInfo.ProductBatchId = str;
									if (row.Cells[8].Value == null)
									{
										this.damageStockDetailsInfo.Qty = new decimal(0);
									}
									else if (!(row.Cells[8].Value.ToString() == ""))
									{
										this.damageStockDetailsInfo.Qty = decimal.Parse(row.Cells[6].Value.ToString());
									}
									else
									{
										this.damageStockDetailsInfo.Qty = new decimal(0);
									}
									this.damageStockDetailsInfo.Description = row.Cells[3].Value.ToString();
									this.damageStockDetailsSP.DamageStockDetailsAdd(this.damageStockDetailsInfo);
									this.StockPostingInfo.VoucherNumber = text;
									this.StockPostingInfo.ProductBatchId = str;
									this.StockPostingInfo.InwardQuantity = new decimal(0);
									this.StockPostingInfo.OutwardQuantity = decimal.Parse(row.Cells[6].Value.ToString());
									this.StockPostingInfo.VoucherType = "Damage Stock";
									this.StockPostingInfo.Description = "";
									this.StockPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
									this.StockPostingSP.StockPostingAdd(this.StockPostingInfo);
								}
							}
						}
					}
					if (this.isInEditMode)
					{
						this.damageStockMasterSP.DamageStcokMasterEdit(this.damageStockMasterInfo);
					}
					else
					{
						this.damageStockMasterSP.DamageStcokMasterAdd(this.damageStockMasterInfo);
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
				if (this.dgvStock.CurrentCell.ColumnIndex == 6)
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
					frmDamageStock _frmDamageStock = this;
					_frmDamageStock.i = _frmDamageStock.i + 1;
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