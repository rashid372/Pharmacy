using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmCounterSale : Form
	{
        private bool _canUpdate = true;

        private bool _needUpdate = false;

        private int rowIndex;

		private int columnIndex;

		private bool isFormClose = false;

		private bool isrepeated = false;
        private InvoiceDataInfo invoicedatainfo;

        private CounterSaleMasterSP mastersp = new CounterSaleMasterSP();

		private CounterSaleDetailsSP detailssp = new CounterSaleDetailsSP();

		private CounterSaleMasterInfo MasterInfo = new CounterSaleMasterInfo();

		private CounterSaleDetailsInfo DetailsInfo = new CounterSaleDetailsInfo();

		private MedicalShop.StockPostingInfo StockPostingInfo = new MedicalShop.StockPostingInfo();

		private MedicalShop.StockPostingSP StockPostingSP = new MedicalShop.StockPostingSP();

		private MedicalShop.ProductBatchInfo ProductBatchInfo = new MedicalShop.ProductBatchInfo();

		private MedicalShop.ProductBatchSP ProductBatchSP = new MedicalShop.ProductBatchSP();

		private ProductSP productsp = new ProductSP();

		private MedicalShop.ProductInfo ProductInfo = new MedicalShop.ProductInfo();

		private string strDefaultCurrency = "";

		private bool isInEditMode = false;

		private DataTable dtblItem = new DataTable();

		private MedicalShop.frmCounterSaleRegister frmCounterSaleRegister;

		private string StockMasterIdForDelete = "";

		private int i = 0;

		private ComboBox cbm;

		private DataGridViewCell currentCell;

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
        private Label lblRows;
        private Label lblCountRows;




        private Button btnRemove;

		private CheckBox cbPrint;

		private dgv.DataGridViewEnter dgvCounterSale;

		private CheckBox cbxsale;

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

		private Label lblTotalNew;

		public frmCounterSale()
		{

			this.InitializeComponent();
            this.invoicedatainfo = new InvoiceDataInfo();
        //    this.prnDocument = new PrintDocument();
        //    this.prnPreview = new PrintPreviewDialog();
        //    this.prnDialog = new PrintDialog();
        //    prnDocument.PrintPage += new PrintPageEventHandler(prnDocument_PrintPage);
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
                //ProductBatchSP.ProductBatchDeleteByProductId(this.str);
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
					if (this.dgvCounterSale.CurrentRow != null)
					{
						if (this.dgvCounterSale.Rows.Count != 1)
						{
							this.dgvCounterSale.Rows.RemoveAt(this.dgvCounterSale.CurrentCell.RowIndex);
                            this.lblRows.Text = (dgvCounterSale.Rows.Count -1).ToString();
                        }
						else
						{
							this.dgvCounterSale.Rows.Clear();
                            this.lblRows.Text.Clone();
						}
					}
				}
				catch (Exception exception)
				{
				}
				if (this.dgvCounterSale.Rows.Count > 0)
				{
					this.dgvCounterSale.Focus();
					this.dgvCounterSale.CurrentCell = this.dgvCounterSale.Rows[0].Cells[0];
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
                //if (this.btnSave.Text == "&Save")
                //{
                //    // MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    this.SaveOrEdit();
                //    //Printing print = new Printing();
                //    if (this.lblAmount.Text != null && this.lblAmount.Text != "0")
                //    {
                //        this.lblAmount.Text=   this.lblAmount.Text.Replace("Rs", "");
  
                //        invoicedatainfo.TotalAmount = decimal.Parse(this.lblAmount.Text.ToString().Trim());
                //    }
                   
                //    if (cbPrint.Checked)
                //    {
                //        PrintingCountersale countersale = new PrintingCountersale();
                //        countersale.Data = invoicedatainfo;
                //        countersale.PrintReport();
                //    }

                //    this.ClearFunction();
                //}
                //else
                if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (!this.CheckGridNull())
				{
					MessageBox.Show("Incomplete  details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvCounterSale.Rows.Count > 0)
					{
						this.dgvCounterSale.Focus();
						this.dgvCounterSale.ClearSelection();
						this.dgvCounterSale.CurrentCell = this.dgvCounterSale.Rows[0].Cells[0];
						this.dgvCounterSale.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckBatchNull())
				{
					MessageBox.Show("Incomplete  details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvCounterSale.Rows.Count > 0)
					{
						this.dgvCounterSale.Focus();
						this.dgvCounterSale.ClearSelection();
						this.dgvCounterSale.CurrentCell = this.dgvCounterSale.Rows[0].Cells[0];
						this.dgvCounterSale.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckQuantityNull())
				{
					MessageBox.Show("Incomplete  details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.dgvCounterSale.Rows.Count > 0)
					{
						this.dgvCounterSale.Focus();
						this.dgvCounterSale.ClearSelection();
						this.dgvCounterSale.CurrentCell = this.dgvCounterSale.Rows[0].Cells[0];
						this.dgvCounterSale.Rows[0].Cells[0].Selected = true;
					}
				}
				else if (this.CheckOnSaveForExistenceOfProduct() >= 0)
				{
					int num = this.CheckOnSaveForExistenceOfProduct();
					MessageBox.Show("Repeated product batch exists", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.dgvCounterSale.Focus();
					if (this.dgvCounterSale.Rows.Count > 0)
					{
						this.dgvCounterSale.CurrentCell = this.dgvCounterSale.Rows[num].Cells[0];
						this.dgvCounterSale.Rows[num].Selected = true;
					}
				}
				else if (this.btnSave.Text == "&Save")
				{
					this.SaveOrEdit();

						this.SaveToLedgerPosting();
                    if (this.lblAmount.Text != null && this.lblAmount.Text != "0")
                    {
                        this.lblAmount.Text = this.lblAmount.Text.Replace("Rs", "");

                        invoicedatainfo.TotalAmount = decimal.Parse(this.lblAmount.Text.ToString().Trim());
                    }
                   
                  

                    MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.cbPrint.Checked)
					{
                        PrintingCountersale countersale = new PrintingCountersale();
                        countersale.Data = invoicedatainfo;

                        if (this.cbPrint.Checked)
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

                        countersale.PrintReport();
                        invoicedatainfo = new InvoiceDataInfo();
                    }
					this.ClearFunction();
				}
				else if (this.btnSave.Text == "&Update")
				{
					this.SaveOrEdit();

                    if (this.lblAmount.Text != null && this.lblAmount.Text != "0")
                    {
                        this.lblAmount.Text = this.lblAmount.Text.Replace("Rs", "");

                        invoicedatainfo.TotalAmount = decimal.Parse(this.lblAmount.Text.ToString().Trim());
                    }
                   


                    if (this.cbxsale.Checked)
					{
						this.SaveToLedgerPosting();
                        // ReadInvoice = false;

                    }
					MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (this.cbPrint.Checked)
					{
                        PrintingCountersale countersale = new PrintingCountersale();
                        countersale.Data = invoicedatainfo;
                        if (this.cbPrint.Checked)
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


                        countersale.PrintReport();
                        invoicedatainfo = new InvoiceDataInfo();
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
				foreach (DataGridViewRow row in (IEnumerable)this.dgvCounterSale.Rows)
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
				this.lblTotalNew.Text = num.ToString();

               
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cbPrint_CheckedChanged(object sender, EventArgs e)
		{
		}

		public bool CheckBatchNull()
		{
			bool flag = false;
			try
			{
				foreach (DataGridViewRow row in (IEnumerable)this.dgvCounterSale.Rows)
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

		public bool CheckGridNull()
		{
			bool flag = false;
			try
			{
				if (this.dgvCounterSale.Rows.Count > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvCounterSale.Rows)
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
			for (int i = 0; i < this.dgvCounterSale.Rows.Count; i++)
			{
				if ((this.dgvCounterSale.Rows[i].Cells[1].Value == null ? false : this.dgvCounterSale.Rows[i].Cells[2].Value != null))
				{
					if ((this.dgvCounterSale.Rows[i].Cells[1].Value.ToString() == "" ? false : this.dgvCounterSale.Rows[i].Cells[2].Value.ToString() != ""))
					{
						for (int j = 0; j < this.dgvCounterSale.Rows.Count; j++)
						{
							if ((this.dgvCounterSale.Rows[j].Cells[1].Value == null ? false : this.dgvCounterSale.Rows[j].Cells[2].Value != null))
							{
								if ((this.dgvCounterSale.Rows[j].Cells[1].Value.ToString() == "" ? false : this.dgvCounterSale.Rows[j].Cells[2].Value.ToString() != ""))
								{
									if ((this.dgvCounterSale.Rows[i].Cells[1].Value.ToString() != this.dgvCounterSale.Rows[j].Cells[1].Value.ToString() ? false : this.dgvCounterSale.Rows[i].Cells[2].Value.ToString() == this.dgvCounterSale.Rows[j].Cells[2].Value.ToString()))
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
				if (this.dgvCounterSale.RowCount > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvCounterSale.Rows)
					{
						if (this.dgvCounterSale.CurrentRow.Index != row.Index)
						{
							if ((row.Cells[1].Value == null ? false : row.Cells[2].Value != null))
							{
								if ((row.Cells[1].Value.ToString() == "" ? false : row.Cells[1].Value.ToString() != ""))
								{
									if ((Id != row.Cells[1].Value.ToString() ? true : !(Batch == row.Cells[2].Value.ToString().ToLower())))
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
				foreach (DataGridViewRow row in (IEnumerable)this.dgvCounterSale.Rows)
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
               
                this.txtVoucherNo.Enabled = false;
				this.GenerateVoucherNumber();
				this.dgvCounterSale.Rows.Clear();
                this.lblRows.Text = "0";
				this.FillComboItem();
				this.lstbxBatch.Visible = false;
				this.cbxsale.Checked = true;
				this.dtpDate.Text = "";
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
              
				this.lblTotalNew.Text = "0.00";
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.frmCounterSaleRegister.Close();
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

		private void dgvCounterSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dgvCounterSale_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					MedicalShop.ProductBatchInfo productBatchInfo = new MedicalShop.ProductBatchInfo();
					MedicalShop.ProductBatchSP productBatchSP = new MedicalShop.ProductBatchSP();
					if ((e.ColumnIndex == 0 ? true : e.ColumnIndex == 1))
					{
						if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						{
							if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
							{
								this.FillBatchCombo(this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
							}
						}
					}
					if (e.ColumnIndex == 3)
					{
						if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
						{
							if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() != "")
							{
								if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().ToUpper() == "NA")
								{
									this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
								}
							}
						}
					}
					if ((e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 8 ? true : e.ColumnIndex == 10))
					{
						if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
						{
							if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
							{
								if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
								{
									DecimalValidation decimalValidation = new DecimalValidation();
									TextBox textBox = new TextBox()
									{
										Text = this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
									};
									if (!decimalValidation.checkString(textBox))
									{
										if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
										{
											MessageBox.Show("Only decimal values allowed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										}
										this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
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

		private void dgvCounterSale_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.rowIndex = e.RowIndex;
				this.columnIndex = e.ColumnIndex;
				if (e.ColumnIndex != 2)
				{
					this.lstbxBatch.Visible = false;
				}
				else if (this.dgvCounterSale.CurrentRow != null)
				{
					if (this.dgvCounterSale.CurrentRow.Cells[e.ColumnIndex - 1].Value == null)
					{
						this.lstbxBatch.Visible = false;
					}
					else if (!(this.dgvCounterSale.CurrentRow.Cells[e.ColumnIndex - 1].Value.ToString() != ""))
					{
						this.lstbxBatch.Visible = false;
					}
					else
					{
						this.FillBatchCombo(this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
						Point left = new Point();
						Rectangle cellDisplayRectangle = this.dgvCounterSale.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.X = cellDisplayRectangle.Left + this.dgvCounterSale.Left;
						cellDisplayRectangle = this.dgvCounterSale.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
						left.Y = cellDisplayRectangle.Bottom + this.dgvCounterSale.Top;
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

		private void dgvCounterSale_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			int num;
			bool flag;
			try
			{
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
				{
					if (this.dgvCounterSale.CurrentRow != null)
					{
					}
					if (this.dgvCounterSale.CurrentCell == null)
					{
						flag = true;
					}
					else
					{
						flag = (this.dgvCounterSale.CurrentCell.ColumnIndex == 4 || this.dgvCounterSale.CurrentCell.ColumnIndex == 5 || this.dgvCounterSale.CurrentCell.ColumnIndex == 6 ? false : this.dgvCounterSale.CurrentCell.ColumnIndex != 8);
					}
					if (!flag)
					{
						if ((this.dgvCounterSale.CurrentRow.Cells[0].Value == null ? false : this.dgvCounterSale.CurrentRow.Cells[1].Value != null))
						{
							if ((this.dgvCounterSale.CurrentRow.Cells[1].Value.ToString() == "" ? false : this.dgvCounterSale.CurrentRow.Cells[1].Value.ToString() != ""))
							{
								try
								{
									if (this.dgvCounterSale.CurrentCell.Value == null)
									{
										num = 0;
										this.dgvCounterSale.CurrentCell.Value = num.ToString();
									}
									else
									{
										this.dgvCounterSale.CurrentCell.Value = decimal.Parse(this.dgvCounterSale.CurrentCell.Value.ToString());
									}
								}
								catch (Exception exception)
								{
									num = 0;
									this.dgvCounterSale.CurrentCell.Value = num.ToString();
								}
							}
						}
					}
					if ((e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 4 || e.ColumnIndex == 5 ? true : e.ColumnIndex == 8))
					{
						if ((this.dgvCounterSale.Rows[e.RowIndex].Cells[5].Value == null ? true : this.dgvCounterSale.Rows[e.RowIndex].Cells[8].Value == null))
						{
							this.dgvCounterSale.Rows[e.RowIndex].Cells[10].Value = "";
						}
						else if ((this.dgvCounterSale.Rows[e.RowIndex].Cells[5].Value.ToString() == "" ? true : !(this.dgvCounterSale.Rows[e.RowIndex].Cells[8].Value.ToString() != "")))
						{
							this.dgvCounterSale.Rows[e.RowIndex].Cells[10].Value = "";
						}
						else
						{
							decimal num1 = new decimal(0, 0, 0, false, 2);
							decimal num2 = new decimal(0, 0, 0, false, 2);
							decimal num3 = new decimal(0, 0, 0, false, 2);
							try
							{
								num1 = decimal.Parse(this.dgvCounterSale.Rows[e.RowIndex].Cells[5].Value.ToString());
							}
							catch (Exception exception1)
							{
								num1 = new decimal(0);
							}
							try
							{
								num2 = decimal.Parse(this.dgvCounterSale.Rows[e.RowIndex].Cells[8].Value.ToString());
							}
							catch (Exception exception2)
							{
								num2 = new decimal(0);
							}
							num3 = num1 * num2;
							this.dgvCounterSale.Rows[e.RowIndex].Cells[10].Value = Math.Round(num3, 2);
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

		private void dgvCounterSale_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
		}

		private void dgvCounterSale_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
				this.CalculateTotal();
				if (this.dgvCounterSale.CurrentCell != null)
				{
					if ((this.dgvCounterSale.CurrentCell.ColumnIndex == 0 ? true : this.dgvCounterSale.CurrentCell.ColumnIndex == 1))
					{
						MedicalShop.ProductInfo productInfo = new MedicalShop.ProductInfo();
						if (this.dgvCounterSale.CurrentCell.Value != null)
						{
							if (this.dgvCounterSale.CurrentCell.Value.ToString() != "")
							{
								string str1 = this.dgvCounterSale.CurrentCell.Value.ToString();
								productInfo = this.productsp.ProductView(str1);
								if (productInfo.ProductId != null)
								{
									if (this.dgvCounterSale.CurrentCell.ColumnIndex != 0)
									{
										this.dgvCounterSale.CurrentRow.Cells[0].Value = str1;
									}
									else
									{
										this.FillComboItem();
										this.dgvCounterSale.CurrentRow.Cells[1].Value = str1;
									}
									manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
									if (manufacturerInfo.ManufactureId != null)
									{
										this.dgvCounterSale.CurrentRow.Cells[7].Value = manufacturerInfo.ManufactureName;
									}
									unitInfo = unitSP.UnitView(productInfo.UnitId);
									if (unitInfo.UnitName != null)
									{
										this.dgvCounterSale.CurrentRow.Cells[9].Value = unitInfo.UnitName;
									}
								}
								else
								{
									this.dgvCounterSale.CurrentRow.Cells[0].Value = "";
									this.dgvCounterSale.Rows[e.RowIndex].Cells[2].Value = "";
								}
							}
						}
						else if (this.dgvCounterSale.CurrentCell.ColumnIndex == 1)
						{
							this.dgvCounterSale.CurrentRow.Cells[0].Value = "";
						}
					}
					if (e.ColumnIndex == 2)
					{
						string lower = "";
						if (this.dgvCounterSale.CurrentRow.Cells[1].Value != null)
						{
							if (this.dgvCounterSale.CurrentRow.Cells[1].Value.ToString() != "")
							{
								this.FillBatchCombo(this.dgvCounterSale.CurrentRow.Cells[1].Value.ToString());
								for (int i = 0; i < this.lstbxBatch.Items.Count; i++)
								{
									lower = this.lstbxBatch.Items[i].ToString().ToLower();
									if (this.dgvCounterSale.CurrentCell.Value == null)
									{
										this.lstbxBatch.SelectedItem = null;
									}
									else if (!lower.StartsWith(this.dgvCounterSale.CurrentCell.Value.ToString().ToLower()))
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
						if ((this.dgvCounterSale.Rows[e.RowIndex].Cells[1].Value == null ? true : this.dgvCounterSale.Rows[e.RowIndex].Cells[2].Value == null))
						{
						//	flag = true;
                            flag = true;
                        }
						else if ((this.dgvCounterSale.Rows[e.RowIndex].Cells[1].Value.ToString() == "" ? true : !(this.dgvCounterSale.Rows[e.RowIndex].Cells[2].Value.ToString() != "")))
						{
							flag = true;
						}
						else
						{
							DataTable dataTable = new DataTable();
							string str2 = this.dgvCounterSale.Rows[e.RowIndex].Cells[1].Value.ToString();
							string lower1 = this.dgvCounterSale.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower();
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
								else if ((this.dgvCounterSale.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower().Trim() != productBatchInfo.BatchName.ToLower().Trim() ? true : !(this.dgvCounterSale.Rows[e.RowIndex].Cells[1].Value.ToString() == productBatchInfo.ProductId)))
								{
									flag = true;
								}
								else
								{
									if (!(productBatchInfo.ExpiryDate == DateTime.Parse("01/01/1753")))
									{
										this.dgvCounterSale.Rows[e.RowIndex].Cells[3].Value = productBatchInfo.ExpiryDate;
									}
									else
									{
										this.dgvCounterSale.Rows[e.RowIndex].Cells[3].Value = "";
									}
									this.dgvCounterSale.Rows[e.RowIndex].Cells[4].Value = Math.Round(productBatchInfo.PurchaseRate, 2);
									this.dgvCounterSale.Rows[e.RowIndex].Cells[5].Value = Math.Round(productBatchInfo.SalesRate, 2);
									this.dgvCounterSale.Rows[e.RowIndex].Cells[6].Value = Math.Round(productBatchInfo.MRP, 2);
									flag = false;
								}
							}
						}
						if (flag)
						{
							this.dgvCounterSale.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
							this.dgvCounterSale.Rows[e.RowIndex].Cells[4].Value = "";
							this.dgvCounterSale.Rows[e.RowIndex].Cells[5].Value = "";
							this.dgvCounterSale.Rows[e.RowIndex].Cells[6].Value = "";
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

		private void dgvCounterSale_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvCounterSale.CurrentCell is DataGridViewComboBoxCell)
				{
                    if (dgvCounterSale.IsCurrentCellDirty)
                    {
                        dgvCounterSale.CommitEdit(DataGridViewDataErrorContexts.Commit);
                       
                    }
                    //this.dgvCounterSale.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
				if (this.dgvCounterSale.CurrentCell is DataGridViewTextBoxCell)
				{
					this.dgvCounterSale.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvCounterSale_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			try
			{
				DataGridViewTextBoxEditingControl control = e.Control as DataGridViewTextBoxEditingControl;
				if (control != null)
				{
					control.KeyPress += new KeyPressEventHandler(this.TextBoxCellEditControlKeyPress);
				}
				if (this.dgvCounterSale.CurrentCellAddress.X == this.cmbBatch.DisplayIndex)
				{
					ComboBox comboBox = e.Control as ComboBox;
					if (comboBox != null)
					{
						comboBox.DropDownStyle = ComboBoxStyle.DropDown;
					}
					this.currentCell = this.dgvCounterSale.CurrentCell;
				}
                if (e.Control is ComboBox)
                {
                   
                    if (this.dgvCounterSale.CurrentCell.ColumnIndex ==1)
                    {
                       
                       ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                        ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                       // MessageBox.Show(((ComboBox)e.Control).AutoScrollOffset.ToString());
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

		private void dgvCounterSale_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
                if (e.KeyCode == Keys.F6)
                {
                    if (this.dgvCounterSale.CurrentRow != null)
                    {
                        if (this.dgvCounterSale.Rows[this.rowIndex].Cells[0].Value != null)
                        {
                            var popup = new frmPurchaseRateWindow(this.dgvCounterSale.Rows[this.rowIndex].Cells[0].Value.ToString());
                            popup.Show();
                        }
                        
                    }

                }

                if (this.dgvCounterSale.CurrentRow != null)
				{
					if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvCounterSale.CurrentCell.ColumnIndex == 2 : false))
					{
						if (this.dgvCounterSale.CurrentRow != null)
						{
							this.dgvCounterSale.Rows[this.rowIndex].Cells[2].Value = "";
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

		private void dgvCounterSale_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvCounterSale.CurrentCell == this.dgvCounterSale[10, this.dgvCounterSale.Rows.Count - 1])
					{
						this.txtDescription.Focus();
						this.dgvCounterSale.ClearSelection();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvCounterSale_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (this.dgvCounterSale.CurrentRow != null)
				{
					if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ? this.dgvCounterSale.CurrentCell.ColumnIndex == 2 : false))
					{
						this.dgvCounterSale.Rows[this.rowIndex].Cells[2].Value = "";
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

		private void dgvCounterSale_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 0)
				{
					if (this.dgvCounterSale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
					{
						this.dgvCounterSale.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
                        if (this.dgvCounterSale.Rows[e.RowIndex].Cells[0].Value == null)
                        {
                            lblRows.Text = (dgvCounterSale.RowCount - 1).ToString();
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

		private void dgvCounterSale_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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

		private void dgvCounterSale_Scroll(object sender, ScrollEventArgs e)
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
				this.isFormClose = true;
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void DoWhenComingFromRegister(MedicalShop.frmCounterSaleRegister frm, string strVcouherNo)
		{
			try
			{
				this.ClearFunction();
				base.Show();
				this.frmCounterSaleRegister = frm;
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
				LedgerPostingSP ledgerPostingSP = new LedgerPostingSP();
				UnitSP unitSP = new UnitSP();
				this.btnClear.Text = "&New";
				this.btnSave.Text = "&Update";
				this.btnDelete.Enabled = true;
				int productId = 0;
				this.FillComboItem();
				this.MasterInfo = this.mastersp.CounterSaleMasterView(strVcouherNo);
				if (this.MasterInfo.CounterSaleMasterId != null)
				{
					this.txtVoucherNo.Text = this.MasterInfo.CounterSaleMasterId;
					this.dtpDate.Text = this.MasterInfo.Date.ToString();
					this.txtDescription.Text = this.MasterInfo.Description;
					if (ledgerPostingSP.LedgerPostingViewByVoucherTypeAndVoucherNumber(this.txtVoucherNo.Text, "Counter Sale").Rows.Count <= 0)
					{
						this.cbxsale.Checked = false;
					}
					else
					{
						this.cbxsale.Checked = true;
					}
					dataTable = this.detailssp.CounterSaleDetailsViewAllByMasterId(strVcouherNo);
					if (dataTable.Rows.Count > 0)
					{
						foreach (DataRow row in dataTable.Rows)
						{
							if (row.ItemArray[2].ToString() != null)
							{
								this.dgvCounterSale.Rows.Add();
								this.ProductBatchInfo = productBatchSP.ProductBatchView(row.ItemArray[2].ToString());
								this.dgvCounterSale.Rows[productId].Cells[0].Value = this.ProductBatchInfo.ProductId;
								productInfo = this.productsp.ProductView(this.ProductBatchInfo.ProductId);
								this.dgvCounterSale.Rows[productId].Cells[1].Value = this.ProductBatchInfo.ProductId;
								this.FillBatchCombo(this.ProductBatchInfo.ProductId);
								this.dgvCounterSale.Rows[productId].Cells[2].Value = this.ProductBatchInfo.BatchName;
								if (!(DateTime.Parse(this.ProductBatchInfo.ExpiryDate.ToString()) == DateTime.Parse("01/01/1753")))
								{
									this.dgvCounterSale.Rows[productId].Cells[3].Value = this.ProductBatchInfo.ExpiryDate;
								}
								else
								{
									this.dgvCounterSale.Rows[productId].Cells[3].Value = "";
								}
								DataGridViewCell item = this.dgvCounterSale.Rows[productId].Cells[4];
								decimal purchaseRate = this.ProductBatchInfo.PurchaseRate;
								double num3 = double.Parse(purchaseRate.ToString());
								item.Value = num3.ToString();
								DataGridViewCell str = this.dgvCounterSale.Rows[productId].Cells[5];
								num3 = double.Parse(row.ItemArray[4].ToString());
								str.Value = num3.ToString();
								DataGridViewCell dataGridViewCell = this.dgvCounterSale.Rows[productId].Cells[6];
								purchaseRate = this.ProductBatchInfo.MRP;
								num3 = double.Parse(purchaseRate.ToString());
								dataGridViewCell.Value = num3.ToString();
								manufacturerInfo = manufacturerSP.ManufacturerView(productInfo.ManufactureId);
								this.dgvCounterSale.Rows[productId].Cells[7].Value = manufacturerInfo.ManufactureName;
								DataGridViewCell item1 = this.dgvCounterSale.Rows[productId].Cells[8];
								num3 = double.Parse(row.ItemArray[3].ToString());
								item1.Value = num3.ToString();
								unitInfo = unitSP.UnitView(productInfo.UnitId);
								this.dgvCounterSale.Rows[productId].Cells[9].Value = unitInfo.UnitName;
								if ((decimal.Parse(row.ItemArray[3].ToString()) == new decimal(0) ? true : !(row.ItemArray[4].ToString() != "")))
								{
									this.dgvCounterSale.Rows[productId].Cells[10].Value = 0;
								}
								else
								{
									num = decimal.Parse(row.ItemArray[3].ToString());
									num1 = decimal.Parse(row.ItemArray[4].ToString());
									num2 = num * num1;
									this.dgvCounterSale.Rows[productId].Cells[10].Value = Math.Round(num2, 2);
								}
								this.dgvCounterSale.Rows[productId].Cells[11].Value = row.ItemArray[0].ToString();
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
            this.lblRows.Text = (dgvCounterSale.Rows.Count -1).ToString();
		}

		public void DoWhenQuitingForm()
		{
			try
			{
				if (this.isInEditMode)
				{
					this.frmCounterSaleRegister.DoWhenComingFromCounterSale(this.isInEditMode);
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
					this.dgvCounterSale.Focus();
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
				if (this.dgvCounterSale.Focused)
				{
					if (this.dgvCounterSale.Rows.Count == 0)
					{
						this.dgvCounterSale.Rows.Add();
					}
					this.dgvCounterSale.Focus();
					this.dgvCounterSale.CurrentCell = this.dgvCounterSale.Rows[0].Cells[0];
					this.dgvCounterSale.ClearSelection();
					this.dgvCounterSale.CurrentCell.Selected = true;
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

		private void frmCounterSale_KeyDown(object sender, KeyEventArgs e)
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
				str = this.mastersp.CounterSaleMasterGetMax();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCounterSale));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.lstbxBatch = new ListBox();
			this.cbxsale = new CheckBox();
			this.cbPrint = new CheckBox();
			this.txtDescription = new TextBox();
			this.label3 = new Label();
			this.lblAmount = new Label();
			this.lblDebitAmt = new Label();
            this.lblCountRows = new Label();
            this.lblRows = new Label();
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
			this.dgvCounterSale = new dgv.DataGridViewEnter();
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
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.lblTotalNew = new Label();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.dgvCounterSale).BeginInit();
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
			this.panel8.Controls.Add(this.lblTotalNew);
			this.panel8.Controls.Add(this.lstbxBatch);
			this.panel8.Controls.Add(this.dgvCounterSale);
			this.panel8.Controls.Add(this.cbxsale);
			this.panel8.Controls.Add(this.cbPrint);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.lblAmount);
            this.panel8.Controls.Add(this.lblRows);
            this.panel8.Controls.Add(this.lblCountRows);

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
			this.lstbxBatch.FormattingEnabled = true;
			this.lstbxBatch.Location = new Point(313, 100);
			this.lstbxBatch.Name = "lstbxBatch";
			this.lstbxBatch.Size = new System.Drawing.Size(150, 95);
			this.lstbxBatch.TabIndex = 36456460;
			this.lstbxBatch.TabStop = false;
			this.lstbxBatch.DoubleClick += new EventHandler(this.lstbxBatch_DoubleClick);
			this.lstbxBatch.KeyDown += new KeyEventHandler(this.lstbxBatch_KeyDown);
			this.cbxsale.AutoSize = true;
			this.cbxsale.Location = new Point(325, 274);
			this.cbxsale.Name = "cbxsale";
			this.cbxsale.Size = new System.Drawing.Size(88, 17);
			this.cbxsale.TabIndex = 99;
			this.cbxsale.Text = "Post this sale";
			this.cbxsale.UseVisualStyleBackColor = true;
			this.cbPrint.AutoSize = true;
			this.cbPrint.Location = new Point(325, 295);
			this.cbPrint.Name = "cbPrint";
			this.cbPrint.Size = new System.Drawing.Size(97, 17);
			this.cbPrint.TabIndex = 5;
			this.cbPrint.Text = "Print after save";
			this.cbPrint.UseVisualStyleBackColor = true;
			this.cbPrint.CheckedChanged += new EventHandler(this.cbPrint_CheckedChanged);
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
            // 
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
			this.label1.Size = new System.Drawing.Size(90, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Counter Sale";
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
			this.dgvCounterSale.AllowUserToDeleteRows = false;
			this.dgvCounterSale.AllowUserToResizeColumns = false;
			this.dgvCounterSale.AllowUserToResizeRows = false;
			this.dgvCounterSale.BackgroundColor = Color.White;
			this.dgvCounterSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvCounterSale.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.cmbProduct, this.cmbBatch, this.Column4, this.Column5, this.Column2, this.Column3, this.Column8, this.Column9, this.Column11, this.Column18, this.Column19 };
			columns.AddRange(column1);
			this.dgvCounterSale.GridColor = Color.WhiteSmoke;
			this.dgvCounterSale.Location = new Point(13, 52);
			this.dgvCounterSale.Name = "dgvCounterSale";
			this.dgvCounterSale.RowHeadersVisible = false;
			this.dgvCounterSale.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvCounterSale.Size = new System.Drawing.Size(652, 183);
			this.dgvCounterSale.TabIndex = 3;
			this.dgvCounterSale.CellLeave += new DataGridViewCellEventHandler(this.dgvCounterSale_CellLeave);
			this.dgvCounterSale.KeyDown += new KeyEventHandler(this.dgvCounterSale_KeyDown);
			this.dgvCounterSale.RowEnter += new DataGridViewCellEventHandler(this.dgvCounterSale_RowEnter);
			this.dgvCounterSale.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvCounterSale_RowsAdded);
			this.dgvCounterSale.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvCounterSale_CellValidating);
			this.dgvCounterSale.CurrentCellDirtyStateChanged += new EventHandler(this.dgvCounterSale_CurrentCellDirtyStateChanged);
			this.dgvCounterSale.CellEndEdit += new DataGridViewCellEventHandler(this.dgvCounterSale_CellEndEdit);
			this.dgvCounterSale.CellValueChanged += new DataGridViewCellEventHandler(this.dgvCounterSale_CellValueChanged);
			this.dgvCounterSale.Scroll += new ScrollEventHandler(this.dgvCounterSale_Scroll);
			this.dgvCounterSale.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvCounterSale_EditingControlShowing);
			this.dgvCounterSale.KeyUp += new KeyEventHandler(this.dgvCounterSale_KeyUp);
			this.dgvCounterSale.CellEnter += new DataGridViewCellEventHandler(this.dgvCounterSale_CellEnter);
			this.dgvCounterSale.KeyPress += new KeyPressEventHandler(this.dgvCounterSale_KeyPress);
			this.dgvCounterSale.CellContentClick += new DataGridViewCellEventHandler(this.dgvCounterSale_CellContentClick);
			dataGridViewCellStyle.SelectionForeColor = Color.Red;
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
            this.cmbProduct.AutoComplete = true;
            

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
			this.Column5.Visible = false;
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
			this.lblTotalNew.AutoSize = true;
			this.lblTotalNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTotalNew.Location = new Point(449, 295);
			this.lblTotalNew.Name = "lblTotalNew";
			this.lblTotalNew.Size = new System.Drawing.Size(32, 13);
			this.lblTotalNew.TabIndex = 36456461;
			this.lblTotalNew.Text = "0.00";
			this.lblTotalNew.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(692, 445);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmCounterSale";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Counter Sale";
			base.FormClosing += new FormClosingEventHandler(this.frmStock_FormClosing);
			base.KeyUp += new KeyEventHandler(this.frmStockEntry_KeyUp);
			base.KeyDown += new KeyEventHandler(this.frmCounterSale_KeyDown);
			base.Load += new EventHandler(this.frmStockEntry_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((ISupportInitialize)this.dgvCounterSale).EndInit();
			base.ResumeLayout(false);
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void lstbxBatch_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvCounterSale.CurrentRow != null)
				{
					if (this.rowIndex >= 0)
					{
						if (this.lstbxBatch.Text != "")
						{
							this.dgvCounterSale.Rows[this.rowIndex].Cells[2].Value = this.lstbxBatch.Text;
						}
						this.dgvCounterSale.Rows[this.rowIndex].Cells[2].Selected = true;
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
					if (this.dgvCounterSale.CurrentRow != null)
					{
						if (this.rowIndex >= 0)
						{
							if (this.lstbxBatch.Text != "")
							{
								this.dgvCounterSale.Rows[this.rowIndex].Cells[2].Value = this.lstbxBatch.Text;
							}
							this.lstbxBatch.Visible = false;
							this.dgvCounterSale.Focus();
							this.dgvCounterSale.Rows[this.rowIndex].Cells[2].Selected = true;
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
                        invoicedatainfo.vocherNo = text;
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
                    invoicedatainfo.vocherNo= txtVoucherNo.Text;
                    this.MasterInfo.CounterSaleMasterId = text;
					this.MasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
                    invoicedatainfo.SaleDate = DateTime.Parse(this.dtpDate.Text);
                    this.MasterInfo.Description = "";
					if (this.isInEditMode)
					{
						this.detailssp.CounterSaleDetailsDeleteByMasterId(this.txtVoucherNo.Text);
					}
					foreach (DataGridViewRow row in (IEnumerable)this.dgvCounterSale.Rows)
					{
                        InvoiceItemsInfo itemData = new InvoiceItemsInfo();

                        if ((row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null ? false : row.Cells[8].Value != null))
						{
							if ((!(row.Cells[0].Value.ToString() != "") || !(row.Cells[1].Value.ToString() != "") || !(row.Cells[2].Value.ToString() != "") ? false : row.Cells[8].Value.ToString() != ""))
							{
								if (row.Cells[2].Value != null)
								{
									if (row.Cells[2].Value.ToString() != "")
									{
										this.ProductBatchInfo.ProductId = row.Cells[1].Value.ToString();
                                        itemData.ProductId = row.Cells[0].Value.ToString();
                                        itemData.ProductName = row.Cells[1].FormattedValue.ToString();

                                        if (row.Cells[2].Value == null)
										{
											this.ProductBatchInfo.BatchName = "";
                                            itemData.Batch = productBatchInfo.BatchName;
                                        }
										else if (!(row.Cells[2].Value.ToString() == ""))
										{
											this.ProductBatchInfo.BatchName = row.Cells[2].Value.ToString();
                                            itemData.Batch = productBatchInfo.BatchName;
                                        }
										else
										{
											this.ProductBatchInfo.BatchName = "";
                                            itemData.Batch = productBatchInfo.BatchName;
                                        }
										if (row.Cells[3].Value == null)
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										else if (!(row.Cells[3].Value.ToString() == ""))
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse(row.Cells[3].Value.ToString());
											this.ProductBatchInfo.ExpiryDate = this.ProductBatchInfo.ExpiryDate.Date;
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										else
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										if (row.Cells[2].Value.ToString() == "NA")
										{
											this.ProductBatchInfo.ExpiryDate = DateTime.Parse("01/01/1753");
                                            itemData.Expiry = productBatchInfo.ExpiryDate;
                                        }
										if (row.Cells[4].Value == null)
										{
											this.ProductBatchInfo.PurchaseRate = new decimal(0);
										}
										else if (!(row.Cells[4].Value.ToString() == ""))
										{
											this.ProductBatchInfo.PurchaseRate = decimal.Parse(row.Cells[4].Value.ToString());
                                            productBatchInfo.PurchaseRate = productBatchInfo.PurchaseRate;
                                        }
										else
										{
											this.ProductBatchInfo.PurchaseRate = new decimal(0);
                                            productBatchInfo.PurchaseRate = productBatchInfo.PurchaseRate;
                                        }
										if (row.Cells[5].Value == null)
										{
											this.ProductBatchInfo.SalesRate = new decimal(0);
                                            itemData.Rate = productBatchInfo.SalesRate;

                                        }
										else if (!(row.Cells[5].Value.ToString() == ""))
										{
											this.ProductBatchInfo.SalesRate = decimal.Parse(row.Cells[5].Value.ToString());
                                            itemData.Rate = productBatchInfo.SalesRate;
                                        }
										else
										{
											this.ProductBatchInfo.SalesRate = new decimal(0);
                                            itemData.Rate = productBatchInfo.SalesRate;
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
                                                    itemData.Rate = this.ProductBatchInfo.SalesRate;
                                                }
												else if (row.Cells[5].Value.ToString() == "")
												{
													this.ProductBatchInfo.SalesRate = productBatchInfo.SalesRate;
                                                    itemData.Rate = this.ProductBatchInfo.SalesRate;
                                                }
												else if (!(decimal.Parse(row.Cells[5].Value.ToString()) == new decimal(0)))
												{
													this.ProductBatchInfo.SalesRate = decimal.Parse(row.Cells[5].Value.ToString());
                                                    itemData.Rate = this.ProductBatchInfo.SalesRate;
                                                }
												else
												{
													this.ProductBatchInfo.SalesRate = productBatchInfo.SalesRate;
                                                    itemData.Rate = this.ProductBatchInfo.SalesRate;
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
										this.DetailsInfo.CounterSaleMasterId = text;
										this.DetailsInfo.ProductbatchId = str;
										if (row.Cells[5].Value == null)
										{
											this.DetailsInfo.Rate = new decimal(0);
                                            itemData.Rate = this.DetailsInfo.Rate;
                                        }
										else if (!(row.Cells[5].Value.ToString() == ""))
										{
											this.DetailsInfo.Rate = decimal.Parse(row.Cells[5].Value.ToString());
                                            itemData.Rate = this.DetailsInfo.Rate;
                                        }
										else
										{
											this.DetailsInfo.Rate = new decimal(0);
                                            itemData.Rate = this.DetailsInfo.Rate;
                                        }
										if (row.Cells[8].Value == null)
										{
											this.DetailsInfo.Qty = new decimal(0);
                                            itemData.Quantity = this.DetailsInfo.Qty.ToString();
                                        }
										else if (!(row.Cells[8].Value.ToString() == ""))
										{
											this.DetailsInfo.Qty = decimal.Parse(row.Cells[8].Value.ToString());
                                            itemData.Quantity = this.DetailsInfo.Qty.ToString();
                                           //itemData.Quantity = decimal.Parse(row.Cells[8].Value.ToString());
                                        }
										else
										{
											this.DetailsInfo.Qty = new decimal(0);
                                            itemData.Quantity = this.DetailsInfo.Qty.ToString();
                                            

                                        }
                                        itemData.TotalAmount = decimal.Parse(row.Cells[10].Value.ToString());
                                      //  itemData.GrossAmount = decimal.Parse(row.Cells[11].Value.ToString());
                                        this.DetailsInfo.Description = "";
                                        invoicedatainfo.invoiceitem.Add(itemData);
                                        this.detailssp.CounterSaleDetailsAdd(this.DetailsInfo);
                                        
                                      //  invoicedatainfo.invoiceitem.Add(itemData);
                                        this.StockPostingInfo.VoucherNumber = text;
										this.StockPostingInfo.ProductBatchId = str;
										this.StockPostingInfo.InwardQuantity = new decimal(0);
										this.StockPostingInfo.OutwardQuantity = decimal.Parse(row.Cells[8].Value.ToString());
										this.StockPostingInfo.VoucherType = "Counter Sale";
										this.StockPostingInfo.Description = "From Counter Sale";
										this.StockPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
										this.StockPostingSP.StockPostingAdd(this.StockPostingInfo);
                                        
                                    }
								}
							}
						}
					}
					if (this.isInEditMode)
					{
						this.mastersp.CounterSaleMasterEdit(this.MasterInfo);
					}
					else
					{
						this.mastersp.CounterSaleMasterAdd(this.MasterInfo);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}


        public void SaveToLedgerPosting()
		{
			try
			{
				if (this.txtVoucherNo.Text != "")
				{
					if (this.cbxsale.Checked)
					{
						LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo();
						LedgerPostingSP ledgerPostingSP = new LedgerPostingSP();
						ledgerPostingInfo.VoucherNumber = this.txtVoucherNo.Text;
						ledgerPostingInfo.VoucherType = "Counter Sale";
						ledgerPostingInfo.Description = "By Counter Sale";
						ledgerPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
						if (this.isInEditMode)
						{
							DataTable dataTable = ledgerPostingSP.LedgerPostingViewByVoucherTypeAndVoucherNumber(this.txtVoucherNo.Text, "Counter Sale");
							if (dataTable.Rows.Count <= 0)
							{
								ledgerPostingInfo.LedgerId = "2";
								ledgerPostingInfo.Credit = new decimal(0);
								ledgerPostingInfo.Debit = decimal.Parse(this.lblTotalNew.Text);
								ledgerPostingSP.LedgerPostingAdd(ledgerPostingInfo);
								ledgerPostingInfo.LedgerId = "3";
								ledgerPostingInfo.Debit = new decimal(0);
								ledgerPostingInfo.Credit = decimal.Parse(this.lblTotalNew.Text);
								ledgerPostingSP.LedgerPostingAdd(ledgerPostingInfo);
							}
							else
							{
								ledgerPostingInfo.LedgerPostingId = dataTable.Rows[0][0].ToString();
								ledgerPostingInfo.LedgerId = "2";
								ledgerPostingInfo.Credit = new decimal(0);
								ledgerPostingInfo.Debit = decimal.Parse(this.lblTotalNew.Text);
								ledgerPostingSP.LedgerPostingEdit(ledgerPostingInfo);
								ledgerPostingInfo.LedgerPostingId = dataTable.Rows[1][0].ToString();
								ledgerPostingInfo.LedgerId = "3";
								ledgerPostingInfo.Debit = new decimal(0);
								ledgerPostingInfo.Credit = decimal.Parse(this.lblTotalNew.Text);
								ledgerPostingSP.LedgerPostingEdit(ledgerPostingInfo);
							}
						}
						else
						{
							ledgerPostingInfo.LedgerId = "2";
							ledgerPostingInfo.Credit = new decimal(0);
							ledgerPostingInfo.Debit = decimal.Parse(this.lblTotalNew.Text);
							ledgerPostingSP.LedgerPostingAdd(ledgerPostingInfo);
							ledgerPostingInfo.LedgerId = "3";
							ledgerPostingInfo.Debit = new decimal(0);
							ledgerPostingInfo.Credit = decimal.Parse(this.lblTotalNew.Text);
							ledgerPostingSP.LedgerPostingAdd(ledgerPostingInfo);
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

		private void TextBoxCellEditControlKeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((this.dgvCounterSale.CurrentCell.ColumnIndex == 4 || this.dgvCounterSale.CurrentCell.ColumnIndex == 5 || this.dgvCounterSale.CurrentCell.ColumnIndex == 6 ? true : this.dgvCounterSale.CurrentCell.ColumnIndex == 8))
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
					frmCounterSale _frmCounterSale = this;
					_frmCounterSale.i = _frmCounterSale.i + 1;
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