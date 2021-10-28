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
	public class frmMedicalShop : Form
	{
        private CompanyInfo CompanyInfo = new CompanyInfo();
        private CompanySP CompanySP = new CompanySP();

        private UserInfo UserInfo = new UserInfo();
        private UserSP UserSP = new UserSP();
        private Boolean isAutoGenerate = true;

        private bool isFormClose = false;

		private bool isInEditMode = false;

		private bool isCompanyCreated = false;

		private int inDescriptionCount = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private TextBox txtAddress;

		private Label label4;

		private Label label3;

		private TextBox txtName;

		private Label label2;

		private Panel panel6;

		private Label lblMedicalShop;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Label label11;

		private Label label10;

		private Label label9;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private TextBox txtWebsite;

		private TextBox txtEmail;

		private TextBox txtFax;

		private TextBox txtPhone;

		private TextBox txtCity;

		private TextBox txtState;

		private ComboBox cmbCountry;

		private Label label17;

		private Label label18;

		private TextBox txtCurrency;

		private TextBox txtCST;

		private TextBox txtTin;

		private Label label19;

		private TextBox txtLicenseNo;

		private Label label20;

		private CheckBox cbDefault;

		private CheckBox cbDrugList;

		private GroupBox gpbUser;

		private Label label21;

		private Label label16;

		private Label label14;

		private TextBox txtConfirmPassword;

		private Label label12;

		private TextBox txtPassword;

		private TextBox txtUserName;

		private Label label13;

		private Label label22;

		public frmMedicalShop()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
                Clear();
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

        private void Clear()
        {
            foreach (Control control in this.panel8.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
            this.txtPassword.Clear();
            this.txtConfirmPassword.Clear();
            this.cbDrugList.Checked = false;
            this.cbDefault.Checked = false;
            this.txtUserName.Text = "Admin";
            this.cmbCountry.Text = "Pakistan";
            this.txtName.Focus();
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

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
                saveOrEditDetails();
                //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
        private void saveOrEditDetails()
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
                    
                    this.txtName.Text = this.txtName.Text.Trim();
                    this.txtCurrency.Text = this.txtCurrency.Text.Trim();
                    this.txtPassword.Text = this.txtPassword.Text.Trim();
                    this.txtConfirmPassword.Text = this.txtConfirmPassword.Text.Trim();
                    if (!(this.txtName.Text != ""))
                    {
                        MessageBox.Show("Enter company name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtName.Select();
                        this.txtName.Focus();
                    }
                    else if (!(this.txtCurrency.Text != ""))
                    {
                        MessageBox.Show("Enter currency", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtCurrency.Select();
                        this.txtCurrency.Focus();
                    }
                    else if (!(this.txtPassword.Text != ""))
                    {
                        MessageBox.Show("Enter password", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtPassword.Select();
                        this.txtPassword.Focus();
                    }
                    else if (!(this.txtConfirmPassword.Text != ""))
                    {
                        MessageBox.Show("Enter Confirmed Password", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtConfirmPassword.Select();
                        this.txtConfirmPassword.Focus();
                    }


                    else
                    {
                        this.CompanyInfo.CompanyName = this.txtName.Text;
                        this.CompanyInfo.Currency = this.txtCurrency.Text;
                        this.UserInfo.Password = this.txtPassword.Text;
                        this.UserInfo.ActiveOrNot = true;
                        this.UserInfo.Username = this.txtUserName.Text;
                        this.UserInfo.Description = "System generated!";
                        if (this.txtAddress.Text == null)
                        {
                            this.CompanyInfo.Address = "";
                        }
                        else
                        {
                            this.CompanyInfo.Address = this.txtAddress.Text.ToString();
                        }
                        if (this.cmbCountry.SelectedValue == null)
                        {
                            this.CompanyInfo.Country = "";
                        }
                        else
                        {
                            this.CompanyInfo.Country = this.cmbCountry.SelectedValue.ToString();
                        }
                        if (this.txtState.Text == null)
                        {
                            this.CompanyInfo.State = "";
                        }
                        else
                        {
                            this.CompanyInfo.State = this.txtState.Text.ToString();
                        }
                        if (this.txtCity.Text == null)
                        {
                            this.CompanyInfo.City = "";
                        }
                        else
                        {
                            this.CompanyInfo.City = this.txtCity.Text.ToString();
                        }
                        if (this.txtPhone.Text == null)
                        {
                            //this.CompanyInfo. = "";
                        }
                        else
                        {
                            //this.CompanyInfo.City = this.txtCity.Text.ToString();
                        }
                        if (this.txtFax.Text == null)
                        {
                            this.CompanyInfo.Fax = "";
                        }
                        else
                        {
                            ValidateFax();
                            this.CompanyInfo.Fax = this.txtFax.Text.ToString();
                        }
                        if (this.txtEmail.Text == null)
                        {
                            this.CompanyInfo.Email = "";
                        }
                        else
                        {
                            ValidateEmail();
                            this.CompanyInfo.Email = this.txtEmail.Text.ToString();
                        }
                        if (this.txtWebsite.Text == null)
                        {
                            this.CompanyInfo.Website = "";
                        }
                        else
                        {
                            ValidateWebAddress();
                            this.CompanyInfo.Website = this.txtWebsite.Text.ToString();
                        }
                        if (this.txtLicenseNo.Text == null)
                        {
                            this.CompanyInfo.DrugLicense = "";
                        }
                        else
                        {
                            this.CompanyInfo.DrugLicense = this.txtLicenseNo.Text.ToString();
                        }
                        if (this.txtTin.Text == null)
                        {
                            this.CompanyInfo.TinNumber = "";
                        }
                        else
                        {
                            this.CompanyInfo.TinNumber = this.txtTin.Text.ToString();
                        }
                        if (this.txtCST.Text == null)
                        {
                            this.CompanyInfo.CstNumber = "";
                        }
                        else
                        {
                            this.CompanyInfo.CstNumber = this.txtCST.Text.ToString();
                        }
                        this.CompanyInfo.Pincode = "0001";
                        
                        if (this.isAutoGenerate)
                        {
                            if (this.CheckExistanceOfCompanyName())
                            {
                                MessageBox.Show("Company name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.txtName.Focus();
                                this.txtName.SelectAll();
                            }
                            else if (isInEditMode)
                            {
                                this.CompanySP.CompanyEdit(this.CompanyInfo);
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.Clear();
                            }
                            else
                            {
                                this.CompanySP.CompanyAdd(this.CompanyInfo);
                                this.UserSP.UserAdd(this.UserInfo);
                                isCompanyCreated = true;
                                MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.Clear();
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
        public bool CheckExistanceOfCompanyName()
        {
            bool flag=false;
            //string str = this.ProductSP.productNameCheck(this.txtProductName.Text.Trim());
            //if (!(str != ""))
            //{
            //    flag = false;
            //}
            //else if (!(this.btnSave.Text == "&Update"))
            //{
            //    flag = true;
            //}
            //else
            //{
            //    flag = (!(this._productNameFromgrid.ToLower() == str.ToLower()) ? true : false);
            //}
            return flag;
        }
        public void CallThisFormFromMDIForEdit()
		{
			this.isInEditMode = true;
			CompanyInfo companyInfo = new CompanyInfo();
			companyInfo = (new CompanySP()).CompanyView(CompanyInfo._companyId);
			this.txtName.Text = companyInfo.CompanyName;
			this.txtAddress.Text = companyInfo.Address;
			this.cmbCountry.Text = companyInfo.Country;
			this.txtState.Text = companyInfo.State;
			this.txtCity.Text = companyInfo.City;
			this.txtPhone.Text = companyInfo.Pincode;
			this.txtFax.Text = companyInfo.Fax;
			this.txtEmail.Text = companyInfo.Email;
			this.txtWebsite.Text = companyInfo.Website;
			this.txtLicenseNo.Text = companyInfo.DrugLicense;
			this.txtCST.Text = companyInfo.CstNumber;
			this.txtTin.Text = companyInfo.TinNumber;
			this.txtCurrency.Text = companyInfo.Currency;
			this.gpbUser.Visible = false;
			this.cbDrugList.Visible = false;
			PrimaryDBSP primaryDBSP = new PrimaryDBSP();
			CompanyPathInfo companyPathInfo = new CompanyPathInfo();
			if (primaryDBSP.CompanyPathView(CompanyInfo._companyId).DefaultOrNot)
			{
				this.cbDefault.Checked = true;
			}
			base.Show();
		}

		private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Space)
				{
					SendKeys.Send("{F4}");
					e.Handled = true;
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

		private void frmMedicalShop_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmMedicalShop_Load(object sender, EventArgs e)
		{
			try
			{
				this.txtName.Focus();
				if (this.isInEditMode)
				{
					this.Text = "Edit Company";
					this.lblMedicalShop.Text = "Edit Company";
				}
				else
				{
					this.Text = "Create Company";
					this.lblMedicalShop.Text = "Create Company";
					this.cmbCountry.Text = "Pakistan";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMedicalShop));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label22 = new Label();
			this.cbDefault = new CheckBox();
			this.cbDrugList = new CheckBox();
			this.gpbUser = new GroupBox();
			this.label21 = new Label();
			this.label16 = new Label();
			this.label14 = new Label();
			this.txtConfirmPassword = new TextBox();
			this.label12 = new Label();
			this.txtPassword = new TextBox();
			this.txtUserName = new TextBox();
			this.label13 = new Label();
			this.label17 = new Label();
			this.label18 = new Label();
			this.txtCurrency = new TextBox();
			this.txtCST = new TextBox();
			this.txtTin = new TextBox();
			this.label19 = new Label();
			this.txtLicenseNo = new TextBox();
			this.label20 = new Label();
			this.label11 = new Label();
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label6 = new Label();
			this.label5 = new Label();
			this.txtWebsite = new TextBox();
			this.txtEmail = new TextBox();
			this.txtFax = new TextBox();
			this.txtPhone = new TextBox();
			this.txtCity = new TextBox();
			this.txtState = new TextBox();
			this.cmbCountry = new ComboBox();
			this.txtAddress = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtName = new TextBox();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.lblMedicalShop = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gpbUser.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnSave);
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
			this.panel1.Size = new System.Drawing.Size(652, 383);
			this.panel1.TabIndex = 0;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(405, 329);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 16;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(486, 329);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 17;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 329);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 18;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label22);
			this.panel8.Controls.Add(this.cbDefault);
			this.panel8.Controls.Add(this.cbDrugList);
			this.panel8.Controls.Add(this.gpbUser);
			this.panel8.Controls.Add(this.label17);
			this.panel8.Controls.Add(this.label18);
			this.panel8.Controls.Add(this.txtCurrency);
			this.panel8.Controls.Add(this.txtCST);
			this.panel8.Controls.Add(this.txtTin);
			this.panel8.Controls.Add(this.label19);
			this.panel8.Controls.Add(this.txtLicenseNo);
			this.panel8.Controls.Add(this.label20);
			this.panel8.Controls.Add(this.label11);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtWebsite);
			this.panel8.Controls.Add(this.txtEmail);
			this.panel8.Controls.Add(this.txtFax);
			this.panel8.Controls.Add(this.txtPhone);
			this.panel8.Controls.Add(this.txtCity);
			this.panel8.Controls.Add(this.txtState);
			this.panel8.Controls.Add(this.cmbCountry);
			this.panel8.Controls.Add(this.txtAddress);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(650, 289);
			this.panel8.TabIndex = 0;
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label22.ForeColor = Color.Red;
			this.label22.Location = new Point(634, 91);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(12, 13);
			this.label22.TabIndex = 48;
			this.label22.Text = "*";
			this.cbDefault.AutoSize = true;
			this.cbDefault.Location = new Point(351, 254);
			this.cbDefault.Name = "cbDefault";
			this.cbDefault.Size = new System.Drawing.Size(91, 17);
			this.cbDefault.TabIndex = 47;
			this.cbDefault.TabStop = false;
			this.cbDefault.Text = "Set as default";
			this.cbDefault.UseVisualStyleBackColor = true;
			this.cbDrugList.AutoSize = true;
			this.cbDrugList.Location = new Point(351, 231);
			this.cbDrugList.Name = "cbDrugList";
			this.cbDrugList.Size = new System.Drawing.Size(94, 17);
			this.cbDrugList.TabIndex = 46;
			this.cbDrugList.TabStop = false;
			this.cbDrugList.Text = "Import drug list";
			this.cbDrugList.UseVisualStyleBackColor = true;
			this.gpbUser.Controls.Add(this.label21);
			this.gpbUser.Controls.Add(this.label16);
			this.gpbUser.Controls.Add(this.label14);
			this.gpbUser.Controls.Add(this.txtConfirmPassword);
			this.gpbUser.Controls.Add(this.label12);
			this.gpbUser.Controls.Add(this.txtPassword);
			this.gpbUser.Controls.Add(this.txtUserName);
			this.gpbUser.Controls.Add(this.label13);
			this.gpbUser.Location = new Point(338, 114);
			this.gpbUser.Name = "gpbUser";
			this.gpbUser.Size = new System.Drawing.Size(303, 100);
			this.gpbUser.TabIndex = 45;
			this.gpbUser.TabStop = false;
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label21.ForeColor = Color.Red;
			this.label21.Location = new Point(285, 73);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(12, 13);
			this.label21.TabIndex = 52;
			this.label21.Text = "*";
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.ForeColor = Color.Red;
			this.label16.Location = new Point(285, 47);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(12, 13);
			this.label16.TabIndex = 51;
			this.label16.Text = "*";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(6, 73);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(94, 13);
			this.label14.TabIndex = 49;
			this.label14.Text = "Confirm Password:";
			this.txtConfirmPassword.Location = new Point(111, 66);
			this.txtConfirmPassword.MaxLength = 15;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.PasswordChar = '*';
			this.txtConfirmPassword.Size = new System.Drawing.Size(172, 20);
			this.txtConfirmPassword.TabIndex = 15;
			this.txtConfirmPassword.Leave += new EventHandler(this.txtConfirmPassword_Leave);
			this.txtConfirmPassword.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.label12.AutoSize = true;
			this.label12.Location = new Point(6, 47);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 13);
			this.label12.TabIndex = 47;
			this.label12.Text = "Password:";
			this.txtPassword.Location = new Point(111, 40);
			this.txtPassword.MaxLength = 15;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(172, 20);
			this.txtPassword.TabIndex = 14;
			this.txtPassword.Leave += new EventHandler(this.txtPassword_Leave);
			this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtUserName.BackColor = Color.WhiteSmoke;
			this.txtUserName.Location = new Point(111, 14);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.ReadOnly = true;
			this.txtUserName.Size = new System.Drawing.Size(172, 20);
			this.txtUserName.TabIndex = 13;
			this.txtUserName.TabStop = false;
			this.txtUserName.Text = "Admin";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(6, 21);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 13);
			this.label13.TabIndex = 44;
			this.label13.Text = "User Name";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(348, 95);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(52, 13);
			this.label17.TabIndex = 44;
			this.label17.Text = "Currency:";
			this.label18.AutoSize = true;
			this.label18.Location = new Point(348, 69);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 13);
			this.label18.TabIndex = 43;
			this.label18.Text = "CTS No:";
			this.txtCurrency.Location = new Point(442, 88);
			this.txtCurrency.MaxLength = 4;
			this.txtCurrency.Name = "txtCurrency";
			this.txtCurrency.Size = new System.Drawing.Size(192, 20);
			this.txtCurrency.TabIndex = 12;
			this.txtCurrency.Leave += new EventHandler(this.txtCurrency_Leave);
			this.txtCurrency.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtCST.Location = new Point(442, 62);
			this.txtCST.MaxLength = 15;
			this.txtCST.Name = "txtCST";
			this.txtCST.Size = new System.Drawing.Size(192, 20);
			this.txtCST.TabIndex = 11;
			this.txtCST.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtTin.Location = new Point(442, 36);
			this.txtTin.MaxLength = 15;
			this.txtTin.Name = "txtTin";
			this.txtTin.Size = new System.Drawing.Size(192, 20);
			this.txtTin.TabIndex = 10;
			this.txtTin.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.label19.AutoSize = true;
			this.label19.Location = new Point(348, 43);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(45, 13);
			this.label19.TabIndex = 35;
			this.label19.Text = "TIN No:";
			this.txtLicenseNo.Location = new Point(442, 10);
			this.txtLicenseNo.MaxLength = 20;
			this.txtLicenseNo.Name = "txtLicenseNo";
			this.txtLicenseNo.Size = new System.Drawing.Size(192, 20);
			this.txtLicenseNo.TabIndex = 9;
			this.txtLicenseNo.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.label20.AutoSize = true;
			this.label20.Location = new Point(348, 17);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(90, 13);
			this.label20.TabIndex = 34;
			this.label20.Text = "Drug Lisence No:";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(8, 261);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(54, 13);
			this.label11.TabIndex = 31;
			this.label11.Text = "Web Site:";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(8, 235);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(47, 13);
			this.label10.TabIndex = 30;
			this.label10.Text = "Email Id:";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(8, 209);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 13);
			this.label9.TabIndex = 29;
			this.label9.Text = "Fax";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 183);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 13);
			this.label8.TabIndex = 28;
			this.label8.Text = "Phone:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 157);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 13);
			this.label7.TabIndex = 27;
			this.label7.Text = "City";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(8, 131);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 26;
			this.label6.Text = "State";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(11, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Country";
			this.txtWebsite.Location = new Point(109, 254);
			this.txtWebsite.MaxLength = 50;
			this.txtWebsite.Name = "txtWebsite";
			this.txtWebsite.Size = new System.Drawing.Size(192, 20);
			this.txtWebsite.TabIndex = 8;
			this.txtWebsite.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtEmail.Location = new Point(109, 228);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(192, 20);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtFax.Location = new Point(109, 202);
			this.txtFax.MaxLength = 15;
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(192, 20);
			this.txtFax.TabIndex = 6;
			this.txtFax.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtPhone.Location = new Point(109, 176);
			this.txtPhone.MaxLength = 15;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(192, 20);
			this.txtPhone.TabIndex = 5;
			this.txtPhone.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtCity.Location = new Point(109, 150);
			this.txtCity.MaxLength = 50;
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(192, 20);
			this.txtCity.TabIndex = 4;
			this.txtCity.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.txtState.Location = new Point(109, 124);
			this.txtState.MaxLength = 50;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(192, 20);
			this.txtState.TabIndex = 3;
			this.txtState.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbCountry.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbCountry.Items;
			object[] objArray = new object[] { "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbajan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegowina", "Botswana", "Brazil", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic Kongo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Faroe Islands", "Fiji", "Finland", "France", "French Guayana", "French Polynesia", "Gabon", "Gambia", "Georgia - Sakartvelo", "Germany", "Ghana", "Greece", "Greenland - Kalaallit Nunaat", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-Bissau", "Guyana", "Guyane", "Haiti", "Honduras", "Hong Kong", "Hrvatska (Croatia)", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Islands", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea - Democratic People´s Republic", "Korea - Republic", "Kosova", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia (FYROM)", "Madagascar", "Malawi", "Malaysia", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montserrat", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestina", "Panama", "Papau New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation (Asian Region)", "Russian Federation (European Region)", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa (American Samoa)", "Samoa (Western Samoa)", "San Marino", "Saudi Arabia", "Senegal", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "Somaliland", "South Africa", "Spain", "Sri Lanka", "St. Helena", "Sudan", "Suriname", "Svalbard and Jan Mayen", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Tibet", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "USA", "Uzbekistan", "Vanuatu", "Vatican City State - Holy See", "Venezuela", "Vietnam", "Virgin Islands (British)", "Virgin Islands (U.S.)", "Wallis and Futuna", "Western Sahara", "Yemen", "Yugoslavia", "Zambia", "Zimbabwe" };
			items.AddRange(objArray);
			this.cmbCountry.Location = new Point(109, 97);
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.Size = new System.Drawing.Size(192, 21);
			this.cmbCountry.TabIndex = 2;
			this.cmbCountry.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.cmbCountry.KeyDown += new KeyEventHandler(this.cmbCountry_KeyDown);
			this.txtAddress.Location = new Point(109, 36);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(192, 55);
			this.txtAddress.TabIndex = 1;
			this.txtAddress.Enter += new EventHandler(this.txtAddress_Enter);
			this.txtAddress.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(307, 13);
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
			this.txtName.Location = new Point(109, 10);
			this.txtName.MaxLength = 50;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(192, 20);
			this.txtName.TabIndex = 0;
			this.txtName.Leave += new EventHandler(this.txtName_Leave);
			this.txtName.KeyPress += new KeyPressEventHandler(this.txtName_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Name:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.lblMedicalShop);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(650, 33);
			this.panel6.TabIndex = 3;
			this.lblMedicalShop.AutoSize = true;
			this.lblMedicalShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblMedicalShop.Location = new Point(11, 7);
			this.lblMedicalShop.Name = "lblMedicalShop";
			this.lblMedicalShop.Size = new System.Drawing.Size(95, 15);
			this.lblMedicalShop.TabIndex = 4;
			this.lblMedicalShop.Text = "Medical Shop";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(650, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 382);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(650, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(650, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(651, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 383);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 383);
			this.panel2.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(666, 397);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmMedicalShop";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Medical Shop";
			base.FormClosing += new FormClosingEventHandler(this.frmMedicalShop_FormClosing);
			base.Load += new EventHandler(this.frmMedicalShop_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbUser.ResumeLayout(false);
			this.gpbUser.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
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

		private void txtConfirmPassword_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.btnClear.Focused || this.btnClose.Focused || this.isFormClose || this.txtUserName.Focused || this.txtPassword.Focused || this.txtCurrency.Focused || this.txtTin.Focused || this.txtCST.Focused || this.txtWebsite.Focused || this.txtFax.Focused || this.txtEmail.Focused || this.txtPhone.Focused || this.txtState.Focused || this.cmbCountry.Focused || this.txtName.Focused || this.txtAddress.Focused ? false : !this.txtLicenseNo.Focused))
					{
						if (this.txtConfirmPassword.Text.Trim() == "")
						{
							this.txtConfirmPassword.Focus();
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

		private void txtCurrency_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.btnClear.Focused || this.btnClose.Focused || this.isFormClose || this.txtUserName.Focused || this.txtTin.Focused || this.txtCST.Focused || this.txtWebsite.Focused || this.txtFax.Focused || this.txtEmail.Focused || this.txtPhone.Focused || this.txtState.Focused || this.cmbCountry.Focused || this.txtName.Focused || this.txtAddress.Focused ? false : !this.txtLicenseNo.Focused))
					{
						if (this.txtCurrency.Text.Trim() == "")
						{
							this.txtCurrency.Focus();
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

		private void txtName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (!this.txtAddress.Focused)
					{
						this.inDescriptionCount = 0;
						SendKeys.Send("{TAB}");
					}
					else
					{
						frmMedicalShop _frmMedicalShop = this;
						_frmMedicalShop.inDescriptionCount = _frmMedicalShop.inDescriptionCount + 1;
						if (this.inDescriptionCount == 2)
						{
							this.inDescriptionCount = 0;
							SendKeys.Send("{TAB}");
						}
					}
				}
				else if (!(e.KeyChar != ' ' ? true : !this.txtPassword.Focused))
				{
					e.Handled = true;
				}
				else if ((e.KeyChar != ' ' ? true : !this.txtConfirmPassword.Focused))
				{
					this.inDescriptionCount = 0;
				}
				else
				{
					e.Handled = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.btnClear.Focused || this.btnClose.Focused ? false : !this.isFormClose))
					{
						if (this.txtName.Text.Trim() == "")
						{
							this.txtName.Focus();
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

		private void txtPassword_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.btnClear.Focused || this.btnClose.Focused || this.isFormClose || this.txtUserName.Focused || this.txtCurrency.Focused || this.txtTin.Focused || this.txtCST.Focused || this.txtWebsite.Focused || this.txtFax.Focused || this.txtEmail.Focused || this.txtPhone.Focused || this.txtState.Focused || this.cmbCountry.Focused || this.txtName.Focused || this.txtAddress.Focused ? false : !this.txtLicenseNo.Focused))
					{
						if (this.txtPassword.Text.Trim() == "")
						{
							this.txtPassword.Focus();
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

		public bool ValidateEmail()
		{
			bool flag = true;
			Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
			if (this.txtEmail.Text.Length > 0)
			{
				if (!regex.IsMatch(this.txtEmail.Text))
				{
					MessageBox.Show("Invalid Email", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					flag = false;
					this.txtEmail.Focus();
					this.txtEmail.SelectAll();
				}
			}
			return flag;
		}

		public bool ValidateFax()
		{
			bool flag = true;
			if ((this.txtFax.Text.Length <= 0 || this.txtFax.Text.Length >= 6 ? this.txtFax.Text.Length <= 14 : false))
			{
				bool flag1 = false;
				int num = 0;
				int num1 = 0;
				int num2 = 0;
				string text = this.txtFax.Text;
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
						else if (!(this.txtFax.Text.StartsWith("-") ? false : !this.txtFax.Text.StartsWith(" ")))
						{
							flag1 = true;
							break;
						}
						else if (!(this.txtFax.Text.EndsWith("-") ? false : !this.txtFax.Text.EndsWith("+")))
						{
							flag1 = true;
							break;
						}
						else if ((this.txtFax.Text.IndexOf(chr) <= 0 ? true : Convert.ToInt32(chr) != 43))
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
					MessageBox.Show("Invalid fax number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtFax.Focus();
					this.txtFax.SelectAll();
				}
			}
			else
			{
				flag = false;
				MessageBox.Show("Invalid fax number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.txtFax.Focus();
				this.txtFax.SelectAll();
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
					MessageBox.Show("Invalid phone number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtPhone.Focus();
					this.txtPhone.SelectAll();
				}
			}
			else
			{
				flag = false;
				MessageBox.Show("Invalid phone number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.txtPhone.Focus();
				this.txtPhone.SelectAll();
			}
			return flag;
		}

		public bool ValidateWebAddress()
		{
			bool flag = true;
			Regex regex = new Regex("([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?");
			if (this.txtWebsite.Text.Length > 0)
			{
				if (!regex.IsMatch(this.txtWebsite.Text))
				{
					flag = false;
					MessageBox.Show("Invalid web address", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtWebsite.Focus();
					this.txtWebsite.SelectAll();
				}
			}
			return flag;
		}
	}
}