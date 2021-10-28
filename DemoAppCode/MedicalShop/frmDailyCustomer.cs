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
	public class frmDailyCustomer : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel8;

		private Button btnRemove;

		private dgv.DataGridViewEnter dgvProduct;

		private DataGridViewTextBoxColumn ProductCode;

		private DataGridViewComboBoxColumn Product;
       


        private Label label5;

		private TextBox txtDescription;

		private Label label7;

		private TextBox txtPhone;

		private TextBox txtAddress;

		private GroupBox gpbRegister;

		private Panel panel9;

		private DataGridView dgvCustomer;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn Customer;

		private TextBox txtSearch;

		private Label label6;

		private Label label4;

		private Label label3;

		private TextBox txtPatient;

		private Label label2;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private ShelfSP shelfsp = new ShelfSP();

		private ProductSP productsp = new ProductSP();

		private PatientSP patientsp = new PatientSP();

		private PatientMedicineDetailsSP patientmedicinedetailsSP = new PatientMedicineDetailsSP();

		private ComboBox cbm;

		private DataGridViewCell currentCell;

		private bool isInEditMode = false;

		private bool isFormClose = false;

		private string strPatientIdForEdit = "";

		private string strPatientName = "";

		private int inDescriptionCount = 0;

		private int inAddressCount = 0;

		private bool isSaved = false;

		public frmDailyCustomer()
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
                patientsp.PatientDelete(this.strPatientIdForEdit);
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
				try
				{
					if (this.dgvProduct.Rows.Count != 1)
					{
						this.dgvProduct.Rows.RemoveAt(this.dgvProduct.CurrentCell.RowIndex);
					}
					else
					{
						this.dgvProduct.Rows.Clear();
					}
				}
				catch (Exception exception)
				{
				}
				if (this.dgvProduct.Rows.Count > 0)
				{
					this.dgvProduct.Focus();
					this.dgvProduct.CurrentCell = this.dgvProduct.Rows[0].Cells[0];
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
				if (this.isInEditMode)
				{
					this.SaveOrEdit();
				}
				else
				{
                    //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SaveOrEdit();
                }
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cbm_SelectedIndexChanged(object sender, EventArgs e)
		{
			base.BeginInvoke(new MethodInvoker(this.EndEdit));
		}

		public bool CheckExistanceOfPatientName()
		{
			bool flag = true;
			flag = this.patientsp.PatientCheckExistanceOfName(this.txtPatient.Text);
			if ((!flag ? false : this.isInEditMode))
			{
				if (this.txtPatient.Text.ToLower() == this.strPatientName.ToLower())
				{
					flag = false;
				}
			}
			return flag;
		}

		public void ClearFunction()
		{
			try
			{
				this.strPatientIdForEdit = "";
				this.strPatientName = "";
				this.txtAddress.Clear();
				this.txtPatient.Clear();
				this.txtDescription.Clear();
				this.txtPhone.Clear();
				this.txtSearch.Clear();
				this.FillCustomerGrid();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.dgvProduct.Rows.Clear();
				this.FillProductCombo();
				this.isInEditMode = false;
				this.btnDelete.Enabled = false;
				this.isSaved = false;
				this.txtPatient.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvCustomer.CurrentRow != null)
				{
					if ((this.dgvCustomer.Rows.Count <= 0 ? false : e.ColumnIndex > -1))
					{
						if (this.dgvCustomer.CurrentRow.Cells[0].Value != null)
						{
							if (this.dgvCustomer.CurrentRow.Cells[0].Value.ToString() != "")
							{
								this.strPatientIdForEdit = this.dgvCustomer.CurrentRow.Cells[0].Value.ToString();
								this.strPatientName = this.dgvCustomer.CurrentRow.Cells[1].Value.ToString();
								this.FillControlsForEdit();
								this.dgvCustomer.CurrentRow.Selected = true;
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

		private void dgvCustomer_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
				this.dgvCustomer_CellClick(sender, dataGridViewCellEventArg);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			try
			{
				((DataGridView)sender).ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvCustomer_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvCustomer.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(this.dgvCustomer.CurrentCell.ColumnIndex, this.dgvCustomer.CurrentCell.RowIndex);
						this.dgvCustomer_CellClick(sender, dataGridViewCellEventArg);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.btnClear.Focused || this.btnClose.Focused ? false : !this.isFormClose))
					{
						if (this.cbm != null)
						{
							this.cbm.SelectedIndexChanged -= new EventHandler(this.cbm_SelectedIndexChanged);
						}
						string str = "";
						if (this.dgvProduct.CurrentCell != null)
						{
							if ((this.dgvProduct.CurrentCell.ColumnIndex == 0 ? true : this.dgvProduct.CurrentCell.ColumnIndex == 1))
							{
								if ((this.dgvProduct.CurrentCell.Value == null ? false : this.dgvProduct.CurrentCell.Value.ToString() != ""))
								{
									str = this.dgvProduct.CurrentCell.Value.ToString();
									foreach (DataGridViewRow row in (IEnumerable)this.dgvProduct.Rows)
									{
										if ((row.Cells[0].Value == null ? false : row.Cells[1].Value != null))
										{
											if ((row.Cells[0].Value.ToString() == "" ? false : row.Cells[1].Value.ToString() != ""))
											{
												if ((row.Cells[0].Value.ToString() != str ? false : row.Cells[1].Value.ToString() == str))
												{
													if (row.Index != this.dgvProduct.CurrentCell.RowIndex)
													{
														if ((this.btnClose.Focused || this.btnClear.Focused || this.btnDelete.Focused || this.isFormClose || this.btnSave.Focused ? false : MDIMedicalShop.MDIObj.ActiveMdiChild == this))
														{
															if (!this.isSaved)
															{
																MessageBox.Show("Product already selected", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
															}
															this.dgvProduct.CurrentCell.Value = "";
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
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvProduct_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvProduct.CurrentCell != null)
				{
					string str = "";
					if (this.dgvProduct.CurrentCell.ColumnIndex == 0)
					{
						ProductInfo productInfo = new ProductInfo()
						{
							ProductId = null
						};
						if ((this.dgvProduct.CurrentCell.Value == null ? false : this.dgvProduct.CurrentCell.Value.ToString() != ""))
						{
							str = this.dgvProduct.CurrentCell.Value.ToString();
							productInfo = this.productsp.ProductView(str);
						}
						if ((productInfo.ProductId == null ? false : !(productInfo.ProductId == "0")))
						{
							this.dgvProduct.CurrentRow.Cells[1].Value = str;
						}
						else
						{
							this.dgvProduct.CurrentRow.Cells[0].Value = "";
							this.dgvProduct.CurrentRow.Cells[1].Value = "";
						}
					}
					else if (this.dgvProduct.CurrentCell.ColumnIndex == 1)
					{
						if ((this.dgvProduct.CurrentCell.Value == null ? false : this.dgvProduct.CurrentCell.Value.ToString() != "0"))
						{
							str = this.dgvProduct.CurrentCell.Value.ToString();
							this.dgvProduct.CurrentRow.Cells[0].Value = str;
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

		private void dgvProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (e.Control is ComboBox)
			{
				this.cbm = (ComboBox)e.Control;
				if (this.cbm != null)
				{
					this.cbm.SelectedIndexChanged += new EventHandler(this.cbm_SelectedIndexChanged);
				}
				this.currentCell = this.dgvProduct.CurrentCell;
			}
		}

		private void dgvProduct_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					if (this.dgvProduct.CurrentCell != null)
					{
						if ((this.dgvProduct.CurrentCell.ColumnIndex != 1 ? false : this.dgvProduct.CurrentRow.Index == this.dgvProduct.Rows.Count - 1))
						{
							if ((this.dgvProduct.CurrentCell.Value == null || this.dgvProduct.CurrentCell.Value.ToString() == "0" ? true : this.dgvProduct.CurrentCell.Value.ToString() == ""))
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
								this.dgvProduct.ClearSelection();
								this.txtDescription.Focus();
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

		private void dgvProduct_Leave(object sender, EventArgs e)
		{
			try
			{
				this.dgvProduct.ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			try
			{
				this.FillProductCombo();
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

		private void EndEdit()
		{
			try
			{
				if (this.cbm != null)
				{
					DataRowView selectedItem = this.cbm.SelectedItem as DataRowView;
					if (selectedItem != null)
					{
						if (!(selectedItem[0].ToString() != "0"))
						{
							this.dgvProduct[this.currentCell.ColumnIndex - 1, this.currentCell.RowIndex].Value = "";
						}
						else
						{
							this.dgvProduct[this.currentCell.ColumnIndex - 1, this.currentCell.RowIndex].Value = selectedItem[0].ToString();
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

		public void FillControlsForEdit()
		{
			try
			{
				PatientInfo patientInfo = new PatientInfo();
				patientInfo = this.patientsp.PatientView(this.strPatientIdForEdit);
				this.txtPatient.Text = patientInfo.Name;
				this.txtAddress.Text = patientInfo.Address;
				this.txtPhone.Text = patientInfo.PhoneNo;
				this.txtDescription.Text = patientInfo.Description;
				this.dgvProduct.Rows.Clear();
				int str = 0;
				DataTable dataTable = new DataTable();
				dataTable = this.patientmedicinedetailsSP.PatientMedicineDetailsViewAllByPatientId(this.strPatientIdForEdit);
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgvProduct.Rows.Add();
					this.dgvProduct.Rows[str].Cells[0].Value = row.ItemArray[2].ToString();
					this.dgvProduct.Rows[str].Cells[1].Value = row.ItemArray[2].ToString();
                    //this.dgvProduct.Rows[str].Cells[2].Value = row.ItemArray[5].ToString();
                    //this.dgvProduct.Rows[str].Cells[3].Value = row.ItemArray[6].ToString();
                    //this.dgvProduct.Rows[str].Cells[4].Value = row.ItemArray[7].ToString();
                    
                    str++;
				}
				this.dgvProduct.ClearSelection();
				this.btnDelete.Enabled = true;
				this.btnClear.Text = "&New";
				this.btnSave.Text = "&Update";
				this.isInEditMode = true;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillCustomerGrid()
		{
			DataRow row = null;
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.patientsp.PatientViewAllByStatus(true);
				this.dgvCustomer.Rows.Clear();
				int str = 0;
				foreach (DataRow row1 in dataTable.Rows)
				{
					if (!(row1.ItemArray[0].ToString() == "0"))
					{
						str++;
					}
					else
					{
						dataTable.Rows.RemoveAt(str);
						break;
					}
				}
				str = 0;
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dgvCustomer.Rows.Add();
					this.dgvCustomer.Rows[str].Cells[0].Value = dataRow.ItemArray[0].ToString();
					this.dgvCustomer.Rows[str].Cells[1].Value = dataRow.ItemArray[1].ToString();
					str++;
				}
				this.dgvCustomer.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dgvCustomer.ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillProductCombo()
		{
			this.Product.DataSource = null;
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
				this.Product.DataSource = dataTable;
				this.Product.ValueMember = dataTable.Columns[0].ToString();
				this.Product.DisplayMember = dataTable.Columns[1].ToString();
			}
		}

		private void frmDailyCustomer_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.isFormClose = true;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmDailyCustomer_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == Keys.Escape)
				{
					if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
					{
						base.Close();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmDailyCustomer_Load(object sender, EventArgs e)
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

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDailyCustomer));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.btnRemove = new Button();
			this.label5 = new Label();
			this.txtDescription = new TextBox();
			this.label7 = new Label();
			this.txtPhone = new TextBox();
			this.txtAddress = new TextBox();
			this.gpbRegister = new GroupBox();
			this.panel9 = new Panel();
			this.dgvCustomer = new DataGridView();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtPatient = new TextBox();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dgvProduct = new dgv.DataGridViewEnter();

			this.ProductCode = new DataGridViewTextBoxColumn();
           
			this.Product = new DataGridViewComboBoxColumn();
			this.ID = new DataGridViewTextBoxColumn();
			this.Customer = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gpbRegister.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgvCustomer).BeginInit();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.dgvProduct).BeginInit();
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
			this.panel1.Location = new Point(7, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(650, 424);
			this.panel1.TabIndex = 3;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 370);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(405, 370);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(486, 370);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 370);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.btnRemove);
			this.panel8.Controls.Add(this.dgvProduct);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.txtPhone);
			this.panel8.Controls.Add(this.txtAddress);
			this.panel8.Controls.Add(this.gpbRegister);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtPatient);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 330);
			this.panel8.TabIndex = 6;
			this.btnRemove.BackColor = Color.SteelBlue;
			this.btnRemove.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRemove.ForeColor = Color.White;
			this.btnRemove.Location = new Point(303, 235);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(63, 23);
			this.btnRemove.TabIndex = 39;
			this.btnRemove.TabStop = false;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 265);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Description:";
			this.txtDescription.Location = new Point(134, 262);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 55);
			this.txtDescription.TabIndex = 10;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Phone";
			this.txtPhone.Location = new Point(134, 97);
			this.txtPhone.MaxLength = 15;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(232, 20);
			this.txtPhone.TabIndex = 8;
			this.txtPhone.Leave += new EventHandler(this.txtPhone_Leave);
			this.txtPhone.KeyPress += new KeyPressEventHandler(this.txtPhone_KeyPress);
			this.txtAddress.Location = new Point(134, 36);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(232, 55);
			this.txtAddress.TabIndex = 1;
			this.txtAddress.Enter += new EventHandler(this.txtAddress_Enter);
			this.txtAddress.KeyPress += new KeyPressEventHandler(this.txtAddress_KeyPress);
			this.gpbRegister.BackColor = Color.White;
			this.gpbRegister.Controls.Add(this.panel9);
			this.gpbRegister.Location = new Point(390, 8);
			this.gpbRegister.Name = "gpbRegister";
			this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gpbRegister.Size = new System.Drawing.Size(251, 309);
			this.gpbRegister.TabIndex = 7;
			this.gpbRegister.TabStop = false;
			this.gpbRegister.Text = "Register";
			this.panel9.Controls.Add(this.dgvCustomer);
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 286);
			this.panel9.TabIndex = 0;
			this.dgvCustomer.AllowUserToAddRows = false;
			this.dgvCustomer.AllowUserToDeleteRows = false;
			this.dgvCustomer.AllowUserToOrderColumns = true;
			this.dgvCustomer.AllowUserToResizeColumns = false;
			this.dgvCustomer.AllowUserToResizeRows = false;
			this.dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCustomer.BackgroundColor = Color.White;
			this.dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvCustomer.Columns;
			DataGridViewColumn[] d = new DataGridViewColumn[] { this.ID, this.Customer };
			columns.AddRange(d);
			this.dgvCustomer.GridColor = Color.WhiteSmoke;
			this.dgvCustomer.Location = new Point(7, 35);
			this.dgvCustomer.MultiSelect = false;
			this.dgvCustomer.Name = "dgvCustomer";
			this.dgvCustomer.ReadOnly = true;
			this.dgvCustomer.RowHeadersVisible = false;
			this.dgvCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvCustomer.Size = new System.Drawing.Size(225, 243);
			this.dgvCustomer.TabIndex = 18;
			this.dgvCustomer.TabStop = false;
			this.dgvCustomer.CellClick += new DataGridViewCellEventHandler(this.dgvCustomer_CellClick);
			this.dgvCustomer.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvCustomer_ColumnHeaderMouseClick);
			this.dgvCustomer.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCustomer_DataBindingComplete);
			this.dgvCustomer.KeyUp += new KeyEventHandler(this.dgvCustomer_KeyUp);
			this.txtSearch.Location = new Point(79, 9);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(153, 20);
			this.txtSearch.TabIndex = 17;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(4, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Search For:";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(372, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Address:";
			this.txtPatient.Location = new Point(134, 10);
			this.txtPatient.MaxLength = 50;
			this.txtPatient.Name = "txtPatient";
			this.txtPatient.Size = new System.Drawing.Size(232, 20);
			this.txtPatient.TabIndex = 0;
			this.txtPatient.Leave += new EventHandler(this.txtPatient_Leave);
			this.txtPatient.KeyPress += new KeyPressEventHandler(this.txtPatient_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Name:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 33);
			this.panel6.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Daily Customer";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 423);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(648, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(648, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(649, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 424);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 424);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn2.HeaderText = "Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 222;
			this.dgvProduct.AllowUserToDeleteRows = false;
			this.dgvProduct.AllowUserToOrderColumns = true;
			this.dgvProduct.AllowUserToResizeColumns = false;
			this.dgvProduct.AllowUserToResizeRows = false;
			this.dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvProduct.BackgroundColor = SystemColors.Window;
			this.dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection dataGridViewColumnCollections = this.dgvProduct.Columns;
			d = new DataGridViewColumn[] { this.ProductCode, this.Product };
			dataGridViewColumnCollections.AddRange(d);
			this.dgvProduct.GridColor = Color.WhiteSmoke;
			this.dgvProduct.Location = new Point(8, 123);
			this.dgvProduct.MultiSelect = false;
			this.dgvProduct.Name = "dgvProduct";
			this.dgvProduct.RowHeadersVisible = false;
			this.dgvProduct.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvProduct.Size = new System.Drawing.Size(358, 109);
			this.dgvProduct.TabIndex = 19;
			this.dgvProduct.TabStop = false;
			this.dgvProduct.CellLeave += new DataGridViewCellEventHandler(this.dgvProduct_CellLeave);
			this.dgvProduct.KeyDown += new KeyEventHandler(this.dgvProduct_KeyDown);
			this.dgvProduct.CellClick += new DataGridViewCellEventHandler(this.dgvProduct_CellClick);
			this.dgvProduct.RowEnter += new DataGridViewCellEventHandler(this.dgvProduct_RowEnter);
			this.dgvProduct.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvProduct_RowsAdded);
			this.dgvProduct.Leave += new EventHandler(this.dgvProduct_Leave);
			this.dgvProduct.CellEndEdit += new DataGridViewCellEventHandler(this.dgvProduct_CellEndEdit);
			this.dgvProduct.CellValueChanged += new DataGridViewCellEventHandler(this.dgvProduct_CellValueChanged);
			this.dgvProduct.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvProduct_EditingControlShowing);
			this.ProductCode.HeaderText = "Product Code";
			this.ProductCode.Name = "ProductCode";

          
            this.Product.HeaderText = "Product";
			this.Product.Name = "Product";
			this.Product.Resizable = DataGridViewTriState.True;
			this.Product.SortMode = DataGridViewColumnSortMode.Automatic;
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Resizable = DataGridViewTriState.False;
			this.ID.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.ID.Visible = false;
			this.Customer.DataPropertyName = "Name";
			this.Customer.HeaderText = "Name";
			this.Customer.Name = "Customer";
			this.Customer.ReadOnly = true;
			this.Customer.Resizable = DataGridViewTriState.False;
			this.Customer.SortMode = DataGridViewColumnSortMode.NotSortable;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(664, 438);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmDailyCustomer";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Daily Customer";
			base.FormClosing += new FormClosingEventHandler(this.frmDailyCustomer_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmDailyCustomer_KeyDown);
			base.Load += new EventHandler(this.frmDailyCustomer_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbRegister.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgvCustomer).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((ISupportInitialize)this.dgvProduct).EndInit();
			base.ResumeLayout(false);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		public void SaveOrEdit()
		{
			try
			{
				if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this.txtPatient.Text = this.txtPatient.Text.Trim();
					this.txtAddress.Text = this.txtAddress.Text.Trim();
					this.txtPhone.Text = this.txtPhone.Text.Trim();
					this.txtAddress.Text = this.txtAddress.Text.Trim();
					if (this.txtPatient.Text == "")
					{
						MessageBox.Show("Enter customer name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtPatient.Focus();
					}
					else if (this.CheckExistanceOfPatientName())
					{
						MessageBox.Show("Customer name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtPatient.SelectAll();
						this.txtPatient.Focus();
					}
					else if ((this.ValidatePhoneNo() ? true : !this.ValidateMobile()))
					{
                        for (int i = 0; i < this.dgvProduct.Rows.Count; i++)
                        {
                            bool flag = false;
                            if (this.dgvProduct.Rows[i].Cells[0].Value != null)
                            {
                               
                                
                                    for (int j = 0; j < this.dgvProduct.Rows.Count; j++)
                                    {


                                        if (this.dgvProduct.Rows[j].Cells[0].Value != null)
                                        {
                                            
                                           


                                                if (this.dgvProduct.Rows[i].Cells[0].Value.ToString() == this.dgvProduct.Rows[j].Cells[0].Value.ToString())
                                                {
                                                   
                                                        if (i != j)
                                                        {
                                                            this.dgvProduct.Rows.RemoveAt(j);
                                                            flag = true;
                                                            j--;
                                                        }
                                                    }
                                                
                                            
                                        }
                                    }
                                }
                                if (flag)
                                {
                                    i--;
                                }
                            }
                        
						this.isSaved = true;
						PatientInfo patientInfo = new PatientInfo();
						PatientMedicineDetailsInfo patientMedicineDetailsInfo = new PatientMedicineDetailsInfo();
						patientInfo.Name = this.txtPatient.Text;
						patientInfo.Address = this.txtAddress.Text;
						patientInfo.PhoneNo = this.txtPhone.Text;
						patientInfo.MobileNo = "";
						patientInfo.Description = this.txtDescription.Text;
						patientInfo.DailyCustomerOrNot = true;
                        if (!(this.btnSave.Text == "&Save"))
                        {
                            patientInfo.PatientId = this.strPatientIdForEdit;
                            this.patientsp.PatientEdit(patientInfo);

                            this.patientmedicinedetailsSP.PatientMedicineDetailsDeleteByPatientId(patientInfo.PatientId);
                            patientMedicineDetailsInfo.PatientId = this.strPatientIdForEdit;
                            patientMedicineDetailsInfo.Description = "";
                            foreach (DataGridViewRow row in (IEnumerable)this.dgvProduct.Rows)
                            {
                               

                                //if ((row.Cells[1].Value == null ? false : row.Cells[1].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.productName = row.Cells[1].Value.ToString();
                                //    // this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                //}

                                //if ((row.Cells[2].Value == null ? false : row.Cells[2].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.saleRate = row.Cells[2].Value.ToString();
                                //    // this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                //}
                                //if ((row.Cells[3].Value == null ? false : row.Cells[3].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.qty = row.Cells[3].Value.ToString();
                                //    // this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                //}
                                //if ((row.Cells[4].Value == null ? false : row.Cells[4].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.ActiveOrNot = Boolean.Parse(row.Cells[4].Value.ToString());
                                //  //  this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);

                                //}

                                
                                if ((row.Cells[0].Value == null ? false : row.Cells[0].Value.ToString().Trim() != ""))
                                {
                                    patientMedicineDetailsInfo.ProductId = row.Cells[0].Value.ToString();
                                      this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                }
                            }
                            
                            MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.ClearFunction();
                       }
                        else
                        {
                            patientInfo.PatientId = "0";
                            patientInfo.PatientId= this.patientsp.PatientAdd(patientInfo).ToString();

                            this.patientmedicinedetailsSP.PatientMedicineDetailsDeleteByPatientId(patientInfo.PatientId);
                            patientMedicineDetailsInfo.PatientId = patientInfo.PatientId;
                            patientMedicineDetailsInfo.Description = "";
                            foreach (DataGridViewRow row in (IEnumerable)this.dgvProduct.Rows)
                            {
                                

                                //if ((row.Cells[1].Value == null ? false : row.Cells[1].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.productName = row.Cells[1].Value.ToString();
                                //    // this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                //}

                                //if ((row.Cells[2].Value == null ? false : row.Cells[2].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.saleRate = row.Cells[2].Value.ToString();
                                //    // this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                //}
                                //if ((row.Cells[3].Value == null ? false : row.Cells[3].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.qty = row.Cells[3].Value.ToString();
                                //    // this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                //}
                                //if ((row.Cells[4].Value == null ? false : row.Cells[4].Value.ToString().Trim() != ""))
                                //{
                                //    patientMedicineDetailsInfo.ActiveOrNot = Boolean.Parse(row.Cells[4].Value.ToString());


                                //}


                                if ((row.Cells[0].Value == null ? false : row.Cells[0].Value.ToString().Trim() != ""))
                                {
                                    patientMedicineDetailsInfo.ProductId = row.Cells[0].Value.ToString();
                                    this.patientmedicinedetailsSP.PatientMedicineDetailsAdd(patientMedicineDetailsInfo);
                                }


                            }


                            MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            this.ClearFunction();

                        }
					
					}
					else
					{
						MessageBox.Show("Invalid phone number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtPhone.Focus();
						this.txtPhone.SelectAll();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtAddress_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtAddress.Text = this.txtAddress.Text.Trim();
				if (!(this.txtAddress.Text == ""))
				{
					this.txtAddress.SelectionStart = this.txtAddress.Text.Length;
					this.txtAddress.Focus();
				}
				else
				{
					this.txtAddress.SelectionStart = 0;
					this.txtAddress.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.inAddressCount = 0;
				}
				else
				{
					frmDailyCustomer _frmDailyCustomer = this;
					_frmDailyCustomer.inAddressCount = _frmDailyCustomer.inAddressCount + 1;
					if (this.inAddressCount == 2)
					{
						this.inAddressCount = 0;
						this.txtPhone.Focus();
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
					frmDailyCustomer _frmDailyCustomer = this;
					_frmDailyCustomer.inDescriptionCount = _frmDailyCustomer.inDescriptionCount + 1;
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

		private void txtPatient_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					string str = this.txtAddress.Text.Trim();
					if (!(str == ""))
					{
						this.txtAddress.SelectionStart = str.Length;
						this.txtAddress.Focus();
					}
					else
					{
						this.txtAddress.SelectionStart = 0;
						this.txtAddress.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtPatient_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvCustomer.Focused || this.btnClose.Focused || this.btnDelete.Focused ? false : !this.isFormClose))
					{
						if (this.txtPatient.Text.Trim() == "")
						{
							this.txtPatient.Focus();
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

		private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.dgvCustomer.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtPhone_Leave(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvCustomer.Focused)
				{
					if (this.dgvProduct.Rows.Count == 0)
					{
						this.dgvProduct.Rows.Add();
					}
					this.dgvProduct.Focus();
					this.dgvProduct.CurrentCell = this.dgvProduct.Rows[0].Cells[0];
					this.dgvProduct.ClearSelection();
					this.dgvProduct.CurrentCell.Selected = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvCustomer.Rows.Count; i++)
				{
					if (!this.dgvCustomer[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvCustomer.Rows[i].Visible = false;
					}
					else
					{
						this.dgvCustomer.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public bool ValidateMobile()
		{
			bool flag = false;
			try
			{
				if (this.txtPhone.Text != "")
				{
					int num = 0;
					if (!(new Regex("^((([0-9]{4}([-| ]{1}))?[0-9]{7})|((([+]?([0-9]{2})?)|([0][0]?([0-9]{2})?))?([-| ]{1})?[0-9]{9,12})|)$")).IsMatch(this.txtPhone.Text))
					{
						num = 1;
						flag = true;
					}
					if (num == 0)
					{
						flag = false;
					}
					else if (!this.btnClose.Focused)
					{
						this.txtPhone.SelectAll();
						this.txtPhone.Focus();
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

		public bool ValidatePhoneNo()
		{
			bool flag = true;
			if ((this.txtPhone.Text.Length <= 0 || this.txtPhone.Text.Length >= 6 ? this.txtPhone.Text.Length <= 14 : false))
			{
				bool flag1 = false;
				int num = 0;
				int num1 = 0;
				int num2 = 0;
				string text = this.txtPhone.Text;
				for (int i = 0; i < text.Length; i++)
				{
					char chr = text[i];
					if (!char.IsDigit(chr))
					{
						if (!(Convert.ToInt32(chr) == 32 || Convert.ToInt32(chr) == 43 ? true : Convert.ToInt32(chr) == 45))
						{
							flag1 = true;
							break;
						}
						else if (!(this.txtPhone.Text.StartsWith("-") ? false : !this.txtPhone.Text.StartsWith(" ")))
						{
							flag1 = true;
							break;
						}
						else if (!(this.txtPhone.Text.EndsWith("-") ? false : !this.txtPhone.Text.EndsWith("+")))
						{
							flag1 = true;
							break;
						}
						else if ((this.txtPhone.Text.IndexOf(chr) <= 0 ? true : Convert.ToInt32(chr) != 43))
						{
							if (Convert.ToInt32(chr) == 43)
							{
								num++;
							}
							if (Convert.ToInt32(chr) == 45)
							{
								num1++;
							}
							if (Convert.ToInt32(chr) == 32)
							{
								num2++;
							}
						}
						else
						{
							flag1 = true;
							break;
						}
					}
				}
				if ((num > 1 || num1 > 2 ? true : num2 > 2))
				{
					flag1 = true;
				}
				if (flag1)
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}
	}
}