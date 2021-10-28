using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmProduct : Form
	{
		private MedicalShop.ProductInfo ProductInfo = new MedicalShop.ProductInfo();

		private MedicalShop.ProductSP ProductSP = new MedicalShop.ProductSP();

		private MedicalShop.ProductBatchInfo ProductBatchInfo = new MedicalShop.ProductBatchInfo();

		private MedicalShop.ProductBatchSP ProductBatchSP = new MedicalShop.ProductBatchSP();

		private MedicalShop.ProductGroupInfo ProductGroupInfo = new MedicalShop.ProductGroupInfo();

		private MedicalShop.ProductGroupSP ProductGroupSP = new MedicalShop.ProductGroupSP();

		private MedicalShop.ManufacturerInfo ManufacturerInfo = new MedicalShop.ManufacturerInfo();

		private MedicalShop.ManufacturerSP ManufacturerSP = new MedicalShop.ManufacturerSP();

		private MedicalShop.ShelfInfo ShelfInfo = new MedicalShop.ShelfInfo();

		private MedicalShop.ShelfSP ShelfSP = new MedicalShop.ShelfSP();

		private MedicalShop.GenericNameInfo GenericNameInfo = new MedicalShop.GenericNameInfo();

		private MedicalShop.GenericNameSP GenericNameSP = new MedicalShop.GenericNameSP();

		private MedicalShop.UnitInfo UnitInfo = new MedicalShop.UnitInfo();

		private MedicalShop.UnitSP UnitSP = new MedicalShop.UnitSP();

		private string _ID = "";

		private string _Search = "";

		private string _checkProductCode = "false";

		private string _checkProductName = "false";

		private string _productNameFromgrid = "";

		private int inDiscriptionCount = 0;

		private bool isFormClose = false;

		private bool isAutoGenerate = false;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private ComboBox cmbProductGroup;

		private Label label9;

		private TextBox txtProductName;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private TextBox txtStockMaxLevel;

		private TextBox txtStockMinLevel;

		private ComboBox cmbManufacture;

		private Label label5;

		private Label label8;

		private Label label7;

		private GroupBox groupBox1;

		private Label label4;

		private Label label3;

		private TextBox txtProductCode;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Button btnNewProductGroup;

		private Label label15;

		private Button btnNewUnit;

		private ComboBox cmbUnit;

		private Button btnNewGenericName;

		private Button btnNewShelf;

		private Button btnNewManufacture;

		private ComboBox cmbGenericName;

		private ComboBox cmbShelf;

		private ComboBox cmbMedicineFor;

		private TextBox txtDescription;

		private Panel panel9;

		private Label lblSearch;

		private ComboBox cmbSearch;

		private TextBox txtSearchFor;

		private Label label6;

		private ComboBox cmbSearchBy;

		private Label lblSearc;

		private DataGridView dgdSearch;

		private Label label16;

		private Label label19;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		public frmProduct()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click_1(object sender, EventArgs e)
		{
			try
			{
				this.clear();
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

		private void btnDelete_Click_1(object sender, EventArgs e)
		{
			try
			{

                ProductSP.ProductDelete(this._ID);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                clear();
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnNewGenericName_Click(object sender, EventArgs e)
		{
      
            frmGenericNames genericNames = new frmGenericNames();
            genericNames.Show();
		}

		private void btnNewManufacture_Click(object sender, EventArgs e)
		{
   
            frmManufacture manufacture = new frmManufacture();
            manufacture.Show();
        }

		public void btnNewProductGroup_Click(object sender, EventArgs e)
		{

            frmProductGroup productGroup = new frmProductGroup();
            productGroup.Show();
        }

		private void btnNewShelf_Click(object sender, EventArgs e)
		{

            frmShelf shelf = new frmShelf();
            shelf.Show();
		}

		private void btnNewUnit_Click(object sender, EventArgs e)
		{

            frmUnit Unit = new frmUnit();
            Unit.Show();
		}

		private void btnSave_Click_1(object sender, EventArgs e)
		{
			try
			{
				this.saveOrEditDetails();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public bool CheckExistanceOfProductCode()
		{
			bool flag = false;
			if (this.txtProductCode.Text.Trim() != "")
			{
				if (this.btnSave.Text != "&Update")
				{
					MedicalShop.ProductInfo productInfo = new MedicalShop.ProductInfo();
					flag = (this.ProductSP.ProductView(this.txtProductCode.Text).ProductId != null ? true : false);
				}
			}
			return flag;
		}

		public bool CheckExistanceOfProductName()
		{
			bool flag;
			string str = this.ProductSP.productNameCheck(this.txtProductName.Text.Trim());
			if (!(str != ""))
			{
				flag = false;
			}
			else if (!(this.btnSave.Text == "&Update"))
			{
				flag = true;
			}
			else
			{
				flag = (!(this._productNameFromgrid.ToLower() == str.ToLower()) ? true : false);
			}
			return flag;
		}

		public void clear()
		{
			try
			{
				this.cmbSearchBy.Text = "All";
				this.FillRegister();
				this.cmbProductGroupFill();
				this.cmbManufactureFill();
				this.cmbShelfFill();
				this.cmbGenericNameFill();
				this.cmbMedicineforFill();
				this.cmbUnitFill();
				this.txtProductCode.Enabled = true;
				this.txtProductCode.BackColor = Color.White;
				if (!(this.ProductSP.ProductGroupGenerationSettingsCheck() == "true"))
				{
					this.txtProductCode.BackColor = Color.White;
					this.isAutoGenerate = false;
					this.txtProductCode.Enabled = true;
					this.txtProductCode.Text = "";
				}
				else
				{
					this.txtProductCode.Enabled = false;
					this.txtProductCode.Text = this.ProductSP.ProductGetMax().ToString();
					this.txtProductCode.BackColor = Color.WhiteSmoke;
					this.isAutoGenerate = true;
				}
				this.txtProductName.Text = "";
				this.txtStockMinLevel.Text = "0.0";
				this.txtStockMaxLevel.Text = "0.0";
				this.txtDescription.Text = "";
				this.txtSearchFor.Text = "";
				this._ID = "";
				this.lblSearch.Enabled = false;
				this.cmbSearch.Enabled = false;
				this.btnDelete.Enabled = false;
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				if (!this.txtProductCode.Enabled)
				{
					this.txtProductName.Focus();
				}
				else
				{
					this.txtProductCode.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void cmbGenericNameFill()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.GenericNameSP.GenericNameViewAll();
				this.cmbGenericName.DataSource = dataTable;
				this.cmbGenericName.DisplayMember = "Name";
				this.cmbGenericName.ValueMember = "ID";
				this.cmbGenericName.SelectedValue = 0;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void cmbManufactureFill()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.ManufacturerSP.ManufacturerViewAll();
				this.cmbManufacture.DataSource = dataTable;
				this.cmbManufacture.DisplayMember = "Name";
				this.cmbManufacture.ValueMember = "ID";
				this.cmbManufacture.SelectedValue = 0;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void cmbMedicineforFill()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.ProductSP.MedicineForViewAll();
				this.cmbMedicineFor.DataSource = dataTable;
				this.cmbMedicineFor.DisplayMember = "MedicineFor";
				this.cmbMedicineFor.SelectedIndex = -1;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbProductGroup_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbProductGroup_Leave(object sender, EventArgs e)
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

		private void cmbProductGroup_SelectedIndexChanged(object sender, EventArgs e)
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

		public void cmbProductGroupFill()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.ProductGroupSP.ProductGroupViewAll();
				this.cmbProductGroup.DataSource = dataTable;
				this.cmbProductGroup.DisplayMember = "Name";
				this.cmbProductGroup.ValueMember = "ID";
				this.cmbProductGroup.SelectedValue = 1;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtSearchFor.Focus();
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
				if (!(this.cmbSearchBy.Text != "All"))
				{
					this.lblSearch.Enabled = false;
					this.cmbSearch.Enabled = false;
					this.cmbSearch.SelectedIndex = -1;
					this.lblSearch.Text = "";
				}
				else
				{
					this.cmbSearch.Enabled = true;
					this.lblSearch.Enabled = true;
				}
				this.FillRegister();
				this.txtSearchFor.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.cmbSearch.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchBy_Leave(object sender, EventArgs e)
		{
		}

		private void cmbSearchBy_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			try
			{
				if (this.cmbSearchBy.Text == "Product Group")
				{
					MedicalShop.ProductGroupSP productGroupSP = new MedicalShop.ProductGroupSP();
					DataTable dataTable = new DataTable();
					dataTable = productGroupSP.ProductGroupViewAll();
					this.cmbSearch.DataSource = dataTable;
					this.cmbSearch.DisplayMember = "Name";
					this.cmbSearch.ValueMember = "ID";
					this.cmbSearch.SelectedValue = "1";
				}
				else if (this.cmbSearchBy.Text == "Generic Name")
				{
					MedicalShop.GenericNameSP genericNameSP = new MedicalShop.GenericNameSP();
					DataTable dataTable1 = new DataTable();
					dataTable1 = genericNameSP.GenericNameViewAll();
					this.cmbSearch.DataSource = dataTable1;
					this.cmbSearch.DisplayMember = "Name";
					this.cmbSearch.ValueMember = "ID";
					this.cmbSearch.SelectedValue = "0";
				}
				else if (this.cmbSearchBy.Text == "Shelf")
				{
					MedicalShop.ShelfSP shelfSP = new MedicalShop.ShelfSP();
					DataTable dataTable2 = new DataTable();
					dataTable2 = shelfSP.ShelfViewAll();
					this.cmbSearch.DataSource = dataTable2;
					this.cmbSearch.DisplayMember = "Shelf Name";
					this.cmbSearch.ValueMember = "Shelf Id";
					this.cmbSearch.SelectedValue = "0";
				}
				else if (this.cmbSearchBy.Text == "Medicine For")
				{
					MedicalShop.ProductSP productSP = new MedicalShop.ProductSP();
					DataTable dataTable3 = new DataTable();
					dataTable3 = productSP.MedicineForViewAll();
					this.cmbSearch.DataSource = dataTable3;
					this.cmbSearch.DisplayMember = "MedicineFor";
				}
				else if (!(this.cmbSearchBy.Text == "Manufacture"))
				{
					this.cmbSearch.SelectedIndex = -1;
				}
				else
				{
					MedicalShop.ManufacturerSP manufacturerSP = new MedicalShop.ManufacturerSP();
					DataTable dataTable4 = new DataTable();
					dataTable4 = manufacturerSP.ManufacturerViewAll();
					this.cmbSearch.DataSource = dataTable4;
					this.cmbSearch.DisplayMember = "Name";
					this.cmbSearch.ValueMember = "ID";
					this.cmbSearch.SelectedValue = "0";
				}
				this.FillRegister();
				this.txtSearchFor.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void cmbShelfFill()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.ShelfSP.ShelfViewAll();
				this.cmbShelf.DataSource = dataTable;
				this.cmbShelf.DisplayMember = "Shelf Name";
				this.cmbShelf.ValueMember = "Shelf Id";
				this.cmbShelf.SelectedValue = 0;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbUnit_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.btnClear.Focused || this.txtSearchFor.Focused || this.dgdSearch.Focused || this.cmbSearchBy.Focused || this.cmbSearch.Focused || this.txtProductCode.Focused || this.cmbProductGroup.Focused || this.cmbManufacture.Focused || this.cmbShelf.Focused || this.cmbGenericName.Focused || this.txtStockMaxLevel.Focused || this.txtStockMinLevel.Focused || this.cmbMedicineFor.Focused ? false : !this.isFormClose))
					{
						if ((this.cmbUnit.SelectedValue == null ? true : this.cmbUnit.SelectedIndex == -1))
						{
							this.cmbUnit.Focus();
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

		public void cmbUnitFill()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.UnitSP.UnitViewAll();
				this.cmbUnit.DataSource = dataTable;
				this.cmbUnit.DisplayMember = "Unit Name";
				this.cmbUnit.ValueMember = "Unit Id";
				this.cmbUnit.SelectedIndex = -1;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			double num;
			try
			{
				if (this.dgdSearch.CurrentRow != null)
				{
					if (this.dgdSearch.RowCount > 0)
					{
						this._ID = this.dgdSearch.CurrentRow.Cells[0].Value.ToString().ToLower();
						this._productNameFromgrid = this.dgdSearch.CurrentRow.Cells[1].Value.ToString().ToLower();
						this.txtProductCode.Enabled = false;
						this.txtProductCode.BackColor = Color.WhiteSmoke;
						DataTable dataTable = this.ProductSP.ProductViewAllDetails(this._ID);
						if (dataTable.Rows.Count > 0)
						{
							this.txtProductCode.Text = dataTable.Rows[0].ItemArray[0].ToString();
							this.txtProductName.Text = dataTable.Rows[0].ItemArray[1].ToString();
							this.cmbProductGroup.SelectedValue = dataTable.Rows[0].ItemArray[2].ToString();
							this.cmbManufacture.SelectedValue = dataTable.Rows[0].ItemArray[4].ToString();
							this.cmbShelf.SelectedValue = dataTable.Rows[0].ItemArray[6].ToString();
							this.cmbGenericName.SelectedValue = dataTable.Rows[0].ItemArray[8].ToString();
							string str = dataTable.Rows[0].ItemArray[10].ToString();
							if (!(str != "0.0000"))
							{
								this.txtStockMinLevel.Text = "0.0";
							}
							else
							{
								TextBox textBox = this.txtStockMinLevel;
								num = double.Parse(str);
								textBox.Text = num.ToString();
							}
							string str1 = dataTable.Rows[0].ItemArray[11].ToString();
							if (!(str1 != "0.0000"))
							{
								this.txtStockMaxLevel.Text = "0.0";
							}
							else
							{
								TextBox textBox1 = this.txtStockMaxLevel;
								num = double.Parse(str1);
								textBox1.Text = num.ToString();
							}
							this.cmbMedicineFor.Text = dataTable.Rows[0].ItemArray[12].ToString();
							this.txtDescription.Text = dataTable.Rows[0].ItemArray[13].ToString();
							this.cmbUnit.SelectedValue = dataTable.Rows[0].ItemArray[14].ToString();
						}
						this.dgdSearch.CurrentRow.Selected = true;
						this.btnSave.Text = "&Update";
						this.btnClear.Text = "&New";
						this.btnDelete.Enabled = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			((DataGridView)sender).ClearSelection();
		}

		private void dgdSearch_KeyUp_1(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgdSearch.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(0, this.dgdSearch.CurrentRow.Index);
						this.dgdSearch_CellClick(sender, dataGridViewCellEventArg);
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

		public void FillRegister()
		{
			try
			{
				DataTable dataTable = new DataTable();
				if (this.cmbSearchBy.Text == "All")
				{
					dataTable = this.ProductSP.ProductViewAll();
				}
				else if (this.cmbSearchBy.Text == "Product Group")
				{
                    if (this.cmbSearch.SelectedValue != null)
                        dataTable = this.ProductGroupSP.ProductVewByProductGroupId(this.cmbSearch.SelectedValue.ToString());
					this.lblSearch.Text = "Product Group";
				}
				else if (this.cmbSearchBy.Text == "Generic Name")
				{
                    if (this.cmbSearch.SelectedValue != null)
                        dataTable = this.GenericNameSP.ProductViewByGenericNameId(this.cmbSearch.SelectedValue.ToString());
					this.lblSearch.Text = "Generic Name";
				}
				else if (this.cmbSearchBy.Text == "Shelf")
				{
                    if(this.cmbSearch.SelectedValue != null)
					dataTable = this.ShelfSP.ProductViewByShelfId(this.cmbSearch.SelectedValue.ToString());

					this.lblSearch.Text = "Shelf";
				}
				else if (this.cmbSearchBy.Text == "Medicine For")
				{
					dataTable = this.ProductSP.ProductViewByMedicineFor(this.cmbSearch.Text);
					this.lblSearch.Text = "Medicine For";
				}
				else if (this.cmbSearchBy.Text == "Manufacture")
				{
                    if (this.cmbSearch.SelectedValue != null)
                    {
                        dataTable = this.ManufacturerSP.ProductViewByManufactureId(this.cmbSearch.SelectedValue.ToString());
                    
                    }
                    this.lblSearch.Text = "Manufacture";
                }
				this.dgdSearch.Rows.Clear();
				int str = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgdSearch.Rows.Add();
					this.dgdSearch.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
					this.dgdSearch.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
					str++;
				}
				this.dgdSearch.ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmProduct_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmProduct_Load(object sender, EventArgs e)
		{
			try
			{
				this.clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmProduct));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label19 = new Label();
			this.label16 = new Label();
			this.txtDescription = new TextBox();
			this.label15 = new Label();
			this.btnNewUnit = new Button();
			this.cmbUnit = new ComboBox();
			this.btnNewGenericName = new Button();
			this.btnNewShelf = new Button();
			this.btnNewManufacture = new Button();
			this.cmbGenericName = new ComboBox();
			this.cmbShelf = new ComboBox();
			this.btnNewProductGroup = new Button();
			this.cmbProductGroup = new ComboBox();
			this.label9 = new Label();
			this.txtProductName = new TextBox();
			this.label13 = new Label();
			this.label12 = new Label();
			this.cmbMedicineFor = new ComboBox();
			this.label11 = new Label();
			this.label10 = new Label();
			this.txtStockMaxLevel = new TextBox();
			this.txtStockMinLevel = new TextBox();
			this.cmbManufacture = new ComboBox();
			this.label5 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.groupBox1 = new GroupBox();
			this.panel9 = new Panel();
			this.lblSearch = new Label();
			this.cmbSearch = new ComboBox();
			this.txtSearchFor = new TextBox();
			this.label6 = new Label();
			this.cmbSearchBy = new ComboBox();
			this.lblSearc = new Label();
			this.dgdSearch = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtProductCode = new TextBox();
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
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgdSearch).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(650, 440);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 386);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click_1);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(405, 386);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click_1);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(486, 386);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click_1);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 386);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label19);
			this.panel8.Controls.Add(this.label16);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label15);
			this.panel8.Controls.Add(this.btnNewUnit);
			this.panel8.Controls.Add(this.cmbUnit);
			this.panel8.Controls.Add(this.btnNewGenericName);
			this.panel8.Controls.Add(this.btnNewShelf);
			this.panel8.Controls.Add(this.btnNewManufacture);
			this.panel8.Controls.Add(this.cmbGenericName);
			this.panel8.Controls.Add(this.cmbShelf);
			this.panel8.Controls.Add(this.btnNewProductGroup);
			this.panel8.Controls.Add(this.cmbProductGroup);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Controls.Add(this.txtProductName);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.label12);
			this.panel8.Controls.Add(this.cmbMedicineFor);
			this.panel8.Controls.Add(this.label11);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Controls.Add(this.txtStockMaxLevel);
			this.panel8.Controls.Add(this.txtStockMinLevel);
			this.panel8.Controls.Add(this.cmbManufacture);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.groupBox1);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtProductCode);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 346);
			this.panel8.TabIndex = 0;
			this.panel8.Paint += new PaintEventHandler(this.panel8_Paint);
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label19.ForeColor = Color.Red;
			this.label19.Location = new Point(372, 252);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(12, 13);
			this.label19.TabIndex = 45;
			this.label19.Text = "*";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(11, 292);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(63, 13);
			this.label16.TabIndex = 43;
			this.label16.Text = "Description:";
			this.txtDescription.Location = new Point(134, 276);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 55);
			this.txtDescription.TabIndex = 10;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label15.AutoSize = true;
			this.label15.Location = new Point(11, 257);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(29, 13);
			this.label15.TabIndex = 41;
			this.label15.Text = "Unit:";
			this.btnNewUnit.BackColor = Color.SteelBlue;
			this.btnNewUnit.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewUnit.ForeColor = Color.White;
			this.btnNewUnit.Location = new Point(312, 247);
			this.btnNewUnit.Name = "btnNewUnit";
			this.btnNewUnit.Size = new System.Drawing.Size(54, 23);
			this.btnNewUnit.TabIndex = 40;
			this.btnNewUnit.Text = "New";
			this.btnNewUnit.UseVisualStyleBackColor = false;
			this.btnNewUnit.Click += new EventHandler(this.btnNewUnit_Click);
			this.cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbUnit.FormattingEnabled = true;
			this.cmbUnit.Location = new Point(134, 249);
			this.cmbUnit.Name = "cmbUnit";
			this.cmbUnit.Size = new System.Drawing.Size(172, 21);
			this.cmbUnit.TabIndex = 9;
			this.cmbUnit.Leave += new EventHandler(this.cmbUnit_Leave);
			this.cmbUnit.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.cmbUnit.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.btnNewGenericName.BackColor = Color.SteelBlue;
			this.btnNewGenericName.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewGenericName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewGenericName.ForeColor = Color.White;
			this.btnNewGenericName.Location = new Point(312, 141);
			this.btnNewGenericName.Name = "btnNewGenericName";
			this.btnNewGenericName.Size = new System.Drawing.Size(54, 23);
			this.btnNewGenericName.TabIndex = 38;
			this.btnNewGenericName.Text = "New";
			this.btnNewGenericName.UseVisualStyleBackColor = false;
			this.btnNewGenericName.Click += new EventHandler(this.btnNewGenericName_Click);
			this.btnNewShelf.BackColor = Color.SteelBlue;
			this.btnNewShelf.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewShelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewShelf.ForeColor = Color.White;
			this.btnNewShelf.Location = new Point(312, 114);
			this.btnNewShelf.Name = "btnNewShelf";
			this.btnNewShelf.Size = new System.Drawing.Size(54, 23);
			this.btnNewShelf.TabIndex = 37;
			this.btnNewShelf.Text = "New";
			this.btnNewShelf.UseVisualStyleBackColor = false;
			this.btnNewShelf.Click += new EventHandler(this.btnNewShelf_Click);
			this.btnNewManufacture.BackColor = Color.SteelBlue;
			this.btnNewManufacture.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewManufacture.ForeColor = Color.White;
			this.btnNewManufacture.Location = new Point(312, 89);
			this.btnNewManufacture.Name = "btnNewManufacture";
			this.btnNewManufacture.Size = new System.Drawing.Size(54, 23);
			this.btnNewManufacture.TabIndex = 35;
			this.btnNewManufacture.Text = "New";
			this.btnNewManufacture.UseVisualStyleBackColor = false;
			this.btnNewManufacture.Click += new EventHandler(this.btnNewManufacture_Click);
			this.cmbGenericName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbGenericName.FormattingEnabled = true;
			this.cmbGenericName.Location = new Point(134, 143);
			this.cmbGenericName.Name = "cmbGenericName";
			this.cmbGenericName.Size = new System.Drawing.Size(172, 21);
			this.cmbGenericName.TabIndex = 5;
			this.cmbGenericName.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.cmbGenericName.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.cmbShelf.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbShelf.FormattingEnabled = true;
			this.cmbShelf.Location = new Point(134, 116);
			this.cmbShelf.Name = "cmbShelf";
			this.cmbShelf.Size = new System.Drawing.Size(172, 21);
			this.cmbShelf.TabIndex = 4;
			this.cmbShelf.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.cmbShelf.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.btnNewProductGroup.BackColor = Color.SteelBlue;
			this.btnNewProductGroup.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewProductGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewProductGroup.ForeColor = Color.White;
			this.btnNewProductGroup.Location = new Point(312, 60);
			this.btnNewProductGroup.Name = "btnNewProductGroup";
			this.btnNewProductGroup.Size = new System.Drawing.Size(54, 23);
			this.btnNewProductGroup.TabIndex = 34;
			this.btnNewProductGroup.Text = "New";
			this.btnNewProductGroup.UseVisualStyleBackColor = false;
			this.btnNewProductGroup.Click += new EventHandler(this.btnNewProductGroup_Click);
			this.cmbProductGroup.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbProductGroup.FormattingEnabled = true;
			this.cmbProductGroup.Location = new Point(134, 62);
			this.cmbProductGroup.Name = "cmbProductGroup";
			this.cmbProductGroup.Size = new System.Drawing.Size(172, 21);
			this.cmbProductGroup.TabIndex = 2;
			this.cmbProductGroup.Leave += new EventHandler(this.cmbProductGroup_Leave);
			this.cmbProductGroup.SelectedIndexChanged += new EventHandler(this.cmbProductGroup_SelectedIndexChanged);
			this.cmbProductGroup.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.cmbProductGroup.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.ForeColor = Color.Red;
			this.label9.Location = new Point(372, 41);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 32;
			this.label9.Text = "*";
			this.txtProductName.Location = new Point(134, 36);
			this.txtProductName.MaxLength = 50;
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(232, 20);
			this.txtProductName.TabIndex = 1;
			this.txtProductName.Leave += new EventHandler(this.txtProductName_Leave);
			this.txtProductName.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label13.AutoSize = true;
			this.label13.Location = new Point(11, 230);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(71, 13);
			this.label13.TabIndex = 29;
			this.label13.Text = "Medicine For:";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(11, 203);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(90, 13);
			this.label12.TabIndex = 27;
			this.label12.Text = "Stock Max Level:";
			this.cmbMedicineFor.FormattingEnabled = true;
			this.cmbMedicineFor.Location = new Point(134, 222);
			this.cmbMedicineFor.Name = "cmbMedicineFor";
			this.cmbMedicineFor.Size = new System.Drawing.Size(232, 21);
			this.cmbMedicineFor.TabIndex = 8;
			this.cmbMedicineFor.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.cmbMedicineFor.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.label11.AutoSize = true;
			this.label11.Location = new Point(11, 177);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(87, 13);
			this.label11.TabIndex = 23;
			this.label11.Text = "Stock Min Level:";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(8, 151);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Generic Name:";
			this.txtStockMaxLevel.Location = new Point(134, 196);
			this.txtStockMaxLevel.MaxLength = 8;
			this.txtStockMaxLevel.Name = "txtStockMaxLevel";
			this.txtStockMaxLevel.Size = new System.Drawing.Size(232, 20);
			this.txtStockMaxLevel.TabIndex = 7;
			this.txtStockMaxLevel.Text = "0.0";
			this.txtStockMaxLevel.Enter += new EventHandler(this.txtStockMaxLevel_Enter);
			this.txtStockMaxLevel.Leave += new EventHandler(this.txtStockMaxLevel_Leave);
			this.txtStockMaxLevel.KeyPress += new KeyPressEventHandler(this.txtStockMaxLevel_KeyPress);
			this.txtStockMinLevel.Location = new Point(134, 170);
			this.txtStockMinLevel.MaxLength = 8;
			this.txtStockMinLevel.Name = "txtStockMinLevel";
			this.txtStockMinLevel.Size = new System.Drawing.Size(232, 20);
			this.txtStockMinLevel.TabIndex = 6;
			this.txtStockMinLevel.Text = "0.0";
			this.txtStockMinLevel.Enter += new EventHandler(this.txtStockMinLevel_Enter);
			this.txtStockMinLevel.Leave += new EventHandler(this.txtStockMinLevel_Leave);
			this.txtStockMinLevel.KeyPress += new KeyPressEventHandler(this.txtStockMinLevel_KeyPress);
			this.cmbManufacture.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbManufacture.FormattingEnabled = true;
			this.cmbManufacture.Location = new Point(134, 89);
			this.cmbManufacture.Name = "cmbManufacture";
			this.cmbManufacture.Size = new System.Drawing.Size(172, 21);
			this.cmbManufacture.TabIndex = 3;
			this.cmbManufacture.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.cmbManufacture.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 124);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Shelf:";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 70);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Product Group:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 97);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Manufacture:";
			this.groupBox1.BackColor = Color.White;
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Location = new Point(390, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(251, 323);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Register";
			this.panel9.Controls.Add(this.lblSearch);
			this.panel9.Controls.Add(this.cmbSearch);
			this.panel9.Controls.Add(this.txtSearchFor);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Controls.Add(this.cmbSearchBy);
			this.panel9.Controls.Add(this.lblSearc);
			this.panel9.Controls.Add(this.dgdSearch);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 300);
			this.panel9.TabIndex = 0;
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new Point(6, 43);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(59, 13);
			this.lblSearch.TabIndex = 21;
			this.lblSearch.Text = "Search By:";
			this.cmbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearch.FormattingEnabled = true;
			this.cmbSearch.Location = new Point(86, 35);
			this.cmbSearch.Name = "cmbSearch";
			this.cmbSearch.Size = new System.Drawing.Size(148, 21);
			this.cmbSearch.TabIndex = 1;
			this.cmbSearch.TabStop = false;
			this.cmbSearch.Leave += new EventHandler(this.cmbSearchBy_Leave);
			this.cmbSearch.SelectedIndexChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
			this.cmbSearch.KeyPress += new KeyPressEventHandler(this.cmbSearch_KeyPress);
			this.cmbSearch.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.txtSearchFor.Location = new Point(86, 62);
			this.txtSearchFor.MaxLength = 50;
			this.txtSearchFor.Name = "txtSearchFor";
			this.txtSearchFor.Size = new System.Drawing.Size(148, 20);
			this.txtSearchFor.TabIndex = 2;
			this.txtSearchFor.TabStop = false;
			this.txtSearchFor.Leave += new EventHandler(this.cmbSearchBy_Leave);
			this.txtSearchFor.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.txtSearchFor.TextChanged += new EventHandler(this.txtSearchFor_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Search For:";
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbSearchBy.Items;
			object[] objArray = new object[] { "All", "Product Group", "Generic Name", "Shelf", "Medicine For", "Manufacture" };
			items.AddRange(objArray);
			this.cmbSearchBy.Location = new Point(86, 8);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchBy.TabIndex = 0;
			this.cmbSearchBy.TabStop = false;
			this.cmbSearchBy.Leave += new EventHandler(this.cmbSearchBy_Leave);
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged_1);
			this.cmbSearchBy.KeyPress += new KeyPressEventHandler(this.cmbSearchBy_KeyPress);
			this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbProductGroup_KeyDown);
			this.lblSearc.AutoSize = true;
			this.lblSearc.Location = new Point(6, 15);
			this.lblSearc.Name = "lblSearc";
			this.lblSearc.Size = new System.Drawing.Size(59, 13);
			this.lblSearc.TabIndex = 16;
			this.lblSearc.Text = "Search By:";
			this.dgdSearch.AllowUserToAddRows = false;
			this.dgdSearch.AllowUserToDeleteRows = false;
			this.dgdSearch.AllowUserToOrderColumns = true;
			this.dgdSearch.AllowUserToResizeColumns = false;
			this.dgdSearch.AllowUserToResizeRows = false;
			this.dgdSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgdSearch.BackgroundColor = Color.White;
			this.dgdSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgdSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2 };
			columns.AddRange(column1);
			this.dgdSearch.GridColor = Color.WhiteSmoke;
			this.dgdSearch.Location = new Point(9, 88);
			this.dgdSearch.MultiSelect = false;
			this.dgdSearch.Name = "dgdSearch";
			this.dgdSearch.ReadOnly = true;
			this.dgdSearch.RowHeadersVisible = false;
			this.dgdSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgdSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgdSearch.Size = new System.Drawing.Size(225, 203);
			this.dgdSearch.TabIndex = 3;
			this.dgdSearch.TabStop = false;
			this.dgdSearch.CellClick += new DataGridViewCellEventHandler(this.dgdSearch_CellClick);
			this.dgdSearch.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgdSearch_DataBindingComplete);
			this.dgdSearch.Leave += new EventHandler(this.cmbSearchBy_Leave);
			this.dgdSearch.KeyUp += new KeyEventHandler(this.dgdSearch_KeyUp_1);
			this.Column1.HeaderText = "Product Code";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column2.HeaderText = "Name";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(372, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Product Name:";
			this.txtProductCode.Location = new Point(134, 10);
			this.txtProductCode.MaxLength = 50;
			this.txtProductCode.Name = "txtProductCode";
			this.txtProductCode.Size = new System.Drawing.Size(232, 20);
			this.txtProductCode.TabIndex = 0;
			this.txtProductCode.Leave += new EventHandler(this.txtProductCode_Leave);
			this.txtProductCode.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Product Code:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 33);
			this.panel6.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Product";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 439);
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
			this.panel3.Size = new System.Drawing.Size(1, 440);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 440);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Width = 111;
			this.dataGridViewTextBoxColumn2.HeaderText = "Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 111;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 454);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmProduct";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Product";
			base.FormClosing += new FormClosingEventHandler(this.frmProduct_FormClosing);
			base.Load += new EventHandler(this.frmProduct_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgdSearch).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panel8_Paint(object sender, PaintEventArgs e)
		{
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool flag;
			if (keyData != Keys.Tab)
			{
				base.ProcessDialogKey(keyData);
				flag = false;
			}
			else if (!this.txtDescription.Focused)
			{
				base.ProcessDialogKey(keyData);
				flag = true;
			}
			else
			{
				this.btnSave.Focus();
				flag = false;
			}
			return flag;
		}

		private void saveOrEditDetails()
		{
			frmGeneralSettings frmGeneralSetting;
			frmGeneralSettings item;
			try
			{
				DataTable dataTable = new DataTable();
				if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this.txtProductCode.Text = this.txtProductCode.Text.Trim();
					this.txtProductName.Text = this.txtProductName.Text.Trim();
					if (!(this.txtProductCode.Text != ""))
					{
						MessageBox.Show("Enter product code", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtProductCode.Select();
						this.txtProductCode.Focus();
					}
					else if (!(this.txtProductName.Text != ""))
					{
						MessageBox.Show("Enter product name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtProductName.Select();
						this.txtProductName.Focus();
					}
					else if (!(decimal.Parse(this.txtStockMinLevel.Text.Trim()) <= decimal.Parse(this.txtStockMaxLevel.Text)))
					{
						MessageBox.Show("Stock Min level should not be greater than stock max level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtStockMinLevel.Select();
						this.txtStockMinLevel.Focus();
					}
					else if ((this.cmbUnit.SelectedValue == null || !(this.cmbUnit.SelectedValue.ToString() != "") ? true : this.cmbUnit.SelectedIndex == -1))
					{
						MessageBox.Show("Select unit", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.cmbUnit.Select();
						this.cmbUnit.Focus();
					}
					else
					{
						this.ProductInfo.ProductName = this.txtProductName.Text;
						if (this.cmbProductGroup.SelectedValue == null)
						{
							this.ProductInfo.ProductGroupId = "";
						}
						else
						{
							this.ProductInfo.ProductGroupId = this.cmbProductGroup.SelectedValue.ToString();
						}
						if (this.cmbManufacture.SelectedValue == null)
						{
							this.ProductInfo.ManufactureId = "";
						}
						else
						{
							this.ProductInfo.ManufactureId = this.cmbManufacture.SelectedValue.ToString();
						}
						if (this.cmbShelf.SelectedValue == null)
						{
							this.ProductInfo.ShelfId = "";
						}
						else
						{
							this.ProductInfo.ShelfId = this.cmbShelf.SelectedValue.ToString();
						}
						if (this.cmbGenericName.SelectedValue == null)
						{
							this.ProductInfo.GenericNameId = "";
						}
						else
						{
							this.ProductInfo.GenericNameId = this.cmbGenericName.SelectedValue.ToString();
						}
						this.ProductInfo.StockMinimumLevel = decimal.Parse(this.txtStockMinLevel.Text);
						this.ProductInfo.StockMaximumLevel = decimal.Parse(this.txtStockMaxLevel.Text);
						if (!(this.cmbMedicineFor.Text != ""))
						{
							this.ProductInfo.MedicineFor = "";
						}
						else
						{
							this.ProductInfo.MedicineFor = this.cmbMedicineFor.Text;
						}
						if (this.cmbUnit.SelectedValue == null)
						{
							this.ProductInfo.UnitId = "";
						}
						else
						{
							this.ProductInfo.UnitId = this.cmbUnit.SelectedValue.ToString();
						}
						this.ProductInfo.Description = this.txtDescription.Text;
						this.ProductInfo.ProductId = this.txtProductCode.Text.Trim();
						this.ProductInfo.ProductName = this.txtProductName.Text.Trim();
						this.ProductBatchInfo.ProductId = this.txtProductCode.Text;
						this.ProductBatchInfo.BatchName = "NA";
						this.ProductBatchInfo.ExpiryDate = DateTime.Parse("1/1/1753");
						this.ProductBatchInfo.PurchaseRate = new decimal(0);
						this.ProductBatchInfo.SalesRate = new decimal(0);
						this.ProductBatchInfo.MRP = new decimal(0);
						this.ProductBatchInfo.Description = "";
						if (this.isAutoGenerate)
						{
							if (this.CheckExistanceOfProductName())
							{
								MessageBox.Show("Product name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.txtProductName.Focus();
								this.txtProductName.SelectAll();
							}
							else if (!(this.btnSave.Text == "&Save"))
							{
								this.ProductSP.ProductEdit(this.ProductInfo);
								MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.clear();
							}
							else
							{
								this.ProductSP.ProductAdd(this.ProductInfo);
								this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
								MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								frmGeneralSetting = new frmGeneralSettings();
								item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
								if (item != null)
								{
									item.Fill();
								}
								this.clear();
							}
						}
						else if (this.CheckExistanceOfProductCode())
						{
							MessageBox.Show("Product code already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.txtProductCode.Focus();
							this.txtProductCode.SelectAll();
						}
						else if (this.CheckExistanceOfProductName())
						{
							MessageBox.Show("Product name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.txtProductName.Focus();
							this.txtProductName.SelectAll();
						}
						else if (!(this.btnSave.Text == "&Save"))
						{
							this.ProductSP.ProductEdit(this.ProductInfo);
							MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							frmGeneralSetting = new frmGeneralSettings();
							item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
							if (item != null)
							{
								item.Fill();
							}
							this.clear();
						}
						else
						{
							this.ProductSP.ProductAdd(this.ProductInfo);
							this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
							MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							frmGeneralSetting = new frmGeneralSettings();
							item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
							if (item != null)
							{
								item.Fill();
							}
							this.clear();
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
				if (e.KeyChar == '\r')
				{
					if (!this.txtDescription.Focused)
					{
						this.inDiscriptionCount = 0;
						e.Handled = true;
						SendKeys.Send("{TAB}");
					}
					else if (e.KeyChar != '\r')
					{
						this.inDiscriptionCount = 0;
					}
					else
					{
						frmProduct _frmProduct = this;
						_frmProduct.inDiscriptionCount = _frmProduct.inDiscriptionCount + 1;
						if (this.inDiscriptionCount == 2)
						{
							this.inDiscriptionCount = 0;
							this.btnSave.Focus();
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

		private void txtProductCode_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearchFor.Focused || this.dgdSearch.Focused || this.cmbSearchBy.Focused || this.cmbSearch.Focused ? false : !this.isFormClose))
					{
						if (this.txtProductCode.Text.Trim() == "")
						{
							this.txtProductCode.Focus();
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

		private void txtProductName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearchFor.Focused || this.dgdSearch.Focused || this.cmbSearchBy.Focused || this.cmbSearch.Focused || this.txtProductCode.Focused ? false : !this.isFormClose))
					{
						if (this.txtProductName.Text.Trim() == "")
						{
							this.txtProductName.Focus();
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

		private void txtSearchFor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgdSearch.Rows.Count; i++)
				{
					if (!this.dgdSearch[1, i].Value.ToString().ToLower().StartsWith(this.txtSearchFor.Text.ToLower()))
					{
						this.dgdSearch.Rows[i].Visible = false;
					}
					else
					{
						this.dgdSearch.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtStockMaxLevel_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtStockMaxLevel.Text) == new decimal(0))
				{
					this.txtStockMaxLevel.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtStockMaxLevel.Text = "";
			}
		}

		private void txtStockMaxLevel_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					e.Handled = true;
					SendKeys.Send("{TAB}");
				}
				else
				{
					if (this.txtStockMaxLevel.TextLength == 16)
					{
						e.Handled = true;
					}
					if (!char.IsNumber(e.KeyChar))
					{
						e.Handled = true;
					}
					if (e.KeyChar == '\b')
					{
						e.Handled = false;
					}
					if (e.KeyChar == '.')
					{
						if (!this.txtStockMaxLevel.Text.Contains("."))
						{
							e.Handled = false;
						}
						else
						{
							e.Handled = true;
						}
					}
					if (e.KeyChar == '\r')
					{
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtStockMaxLevel_Leave(object sender, EventArgs e)
		{
			try
			{
				try
				{
					decimal.Parse(this.txtStockMaxLevel.Text);
				}
				catch
				{
					this.txtStockMaxLevel.Text = "0.0";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtStockMinLevel_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtStockMinLevel.Text) == new decimal(0))
				{
					this.txtStockMinLevel.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtStockMinLevel.Text = "";
			}
		}

		private void txtStockMinLevel_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					e.Handled = true;
					SendKeys.Send("{TAB}");
				}
				else
				{
					if (this.txtStockMinLevel.TextLength == 16)
					{
						e.Handled = true;
					}
					if (!char.IsNumber(e.KeyChar))
					{
						e.Handled = true;
					}
					if (e.KeyChar == '\b')
					{
						e.Handled = false;
					}
					if (e.KeyChar == '.')
					{
						if (!this.txtStockMinLevel.Text.Contains("."))
						{
							e.Handled = false;
						}
						else
						{
							e.Handled = true;
						}
					}
					if (e.KeyChar == '\r')
					{
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtStockMinLevel_Leave(object sender, EventArgs e)
		{
			try
			{
				try
				{
					decimal.Parse(this.txtStockMinLevel.Text);
				}
				catch
				{
					this.txtStockMinLevel.Text = "0.0";
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