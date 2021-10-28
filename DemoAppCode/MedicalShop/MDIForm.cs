using MedicalShop.Properties;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class MDIForm : Form
	{
		private static Server srvSql;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Panel panel3;

		private Panel panel4;

		private Panel pnlMAin;

		private Panel panel6;

		private Label label5;

		private PictureBox Sales;

		private Label label4;

		private PictureBox Purchase;

		private Label label3;

		private PictureBox Vendor;

		private Label label2;

		private PictureBox Product;

		private Label label1;

		private PictureBox AccountLedger;

		private Label label9;

		private PictureBox ReceiptVoucher;

		private Label label10;

		private PictureBox PaymentVoucher;

		private Label label11;

		private PictureBox SalesReturn;

		private Label label12;

		private PictureBox PurchaseReturn;

		private Label label6;

		private PictureBox CounterSale;

		private Label lblHeading;

		private SaveFileDialog saveBackupDialog;

		private Label label7;

		private PictureBox Search;

		private Label label18;

		private PictureBox Close;

		private Label label17;

		private PictureBox Logout;

		private Label label16;

		private PictureBox ChangePassword;

		private Label label15;

		private PictureBox ChangeFinancialYear;

		private Label label14;

		private PictureBox ProfitAndLoss;

		private Label label13;

		private PictureBox BalanceSheet;

		private Label label8;

		private PictureBox TrialBalance;

		private LinkLabel lnklblPharmiz;

		public MDIForm()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MDIForm));
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.saveBackupDialog = new SaveFileDialog();
			this.pnlMAin = new Panel();
			this.lnklblPharmiz = new LinkLabel();
			this.TrialBalance = new PictureBox();
			this.label18 = new Label();
			this.Close = new PictureBox();
			this.label17 = new Label();
			this.Logout = new PictureBox();
			this.label16 = new Label();
			this.ChangePassword = new PictureBox();
			this.label15 = new Label();
			this.ChangeFinancialYear = new PictureBox();
			this.label14 = new Label();
			this.ProfitAndLoss = new PictureBox();
			this.label13 = new Label();
			this.BalanceSheet = new PictureBox();
			this.label8 = new Label();
			this.label7 = new Label();
			this.Search = new PictureBox();
			this.lblHeading = new Label();
			this.label9 = new Label();
			this.ReceiptVoucher = new PictureBox();
			this.label10 = new Label();
			this.PaymentVoucher = new PictureBox();
			this.label11 = new Label();
			this.SalesReturn = new PictureBox();
			this.label12 = new Label();
			this.PurchaseReturn = new PictureBox();
			this.label6 = new Label();
			this.CounterSale = new PictureBox();
			this.label5 = new Label();
			this.Sales = new PictureBox();
			this.label4 = new Label();
			this.Purchase = new PictureBox();
			this.label3 = new Label();
			this.Vendor = new PictureBox();
			this.label2 = new Label();
			this.Product = new PictureBox();
			this.label1 = new Label();
			this.AccountLedger = new PictureBox();
			this.panel6 = new Panel();
			this.pnlMAin.SuspendLayout();
			((ISupportInitialize)this.TrialBalance).BeginInit();
			((ISupportInitialize)this.Close).BeginInit();
			((ISupportInitialize)this.Logout).BeginInit();
			((ISupportInitialize)this.ChangePassword).BeginInit();
			((ISupportInitialize)this.ChangeFinancialYear).BeginInit();
			((ISupportInitialize)this.ProfitAndLoss).BeginInit();
			((ISupportInitialize)this.BalanceSheet).BeginInit();
			((ISupportInitialize)this.Search).BeginInit();
			((ISupportInitialize)this.ReceiptVoucher).BeginInit();
			((ISupportInitialize)this.PaymentVoucher).BeginInit();
			((ISupportInitialize)this.SalesReturn).BeginInit();
			((ISupportInitialize)this.PurchaseReturn).BeginInit();
			((ISupportInitialize)this.CounterSale).BeginInit();
			((ISupportInitialize)this.Sales).BeginInit();
			((ISupportInitialize)this.Purchase).BeginInit();
			((ISupportInitialize)this.Vendor).BeginInit();
			((ISupportInitialize)this.Product).BeginInit();
			((ISupportInitialize)this.AccountLedger).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = Color.FromArgb(120, 181, 246);
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1, 466);
			this.panel1.TabIndex = 0;
			this.panel2.BackColor = Color.FromArgb(120, 181, 246);
			this.panel2.Dock = DockStyle.Right;
			this.panel2.Location = new Point(649, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 466);
			this.panel2.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(120, 181, 246);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(1, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(648, 1);
			this.panel3.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(120, 181, 246);
			this.panel4.Dock = DockStyle.Bottom;
			this.panel4.Location = new Point(1, 465);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(648, 1);
			this.panel4.TabIndex = 3;
			this.pnlMAin.BackgroundImage = (Image)componentResourceManager.GetObject("pnlMAin.BackgroundImage");
			this.pnlMAin.BackgroundImageLayout = ImageLayout.None;
			this.pnlMAin.Controls.Add(this.lnklblPharmiz);
			this.pnlMAin.Controls.Add(this.TrialBalance);
			this.pnlMAin.Controls.Add(this.label18);
			this.pnlMAin.Controls.Add(this.Close);
			this.pnlMAin.Controls.Add(this.label17);
			this.pnlMAin.Controls.Add(this.Logout);
			this.pnlMAin.Controls.Add(this.label16);
			this.pnlMAin.Controls.Add(this.ChangePassword);
			this.pnlMAin.Controls.Add(this.label15);
			this.pnlMAin.Controls.Add(this.ChangeFinancialYear);
			this.pnlMAin.Controls.Add(this.label14);
			this.pnlMAin.Controls.Add(this.ProfitAndLoss);
			this.pnlMAin.Controls.Add(this.label13);
			this.pnlMAin.Controls.Add(this.BalanceSheet);
			this.pnlMAin.Controls.Add(this.label8);
			this.pnlMAin.Controls.Add(this.label7);
			this.pnlMAin.Controls.Add(this.Search);
			this.pnlMAin.Controls.Add(this.lblHeading);
			this.pnlMAin.Controls.Add(this.label9);
			this.pnlMAin.Controls.Add(this.ReceiptVoucher);
			this.pnlMAin.Controls.Add(this.label10);
			this.pnlMAin.Controls.Add(this.PaymentVoucher);
			this.pnlMAin.Controls.Add(this.label11);
			this.pnlMAin.Controls.Add(this.SalesReturn);
			this.pnlMAin.Controls.Add(this.label12);
			this.pnlMAin.Controls.Add(this.PurchaseReturn);
			this.pnlMAin.Controls.Add(this.label6);
			this.pnlMAin.Controls.Add(this.CounterSale);
			this.pnlMAin.Controls.Add(this.label5);
			this.pnlMAin.Controls.Add(this.Sales);
			this.pnlMAin.Controls.Add(this.label4);
			this.pnlMAin.Controls.Add(this.Purchase);
			this.pnlMAin.Controls.Add(this.label3);
			this.pnlMAin.Controls.Add(this.Vendor);
			this.pnlMAin.Controls.Add(this.label2);
			this.pnlMAin.Controls.Add(this.Product);
			this.pnlMAin.Controls.Add(this.label1);
			this.pnlMAin.Controls.Add(this.AccountLedger);
			this.pnlMAin.Controls.Add(this.panel6);
			this.pnlMAin.Dock = DockStyle.Fill;
			this.pnlMAin.Location = new Point(1, 1);
			this.pnlMAin.Name = "pnlMAin";
			this.pnlMAin.Size = new System.Drawing.Size(648, 464);
			this.pnlMAin.TabIndex = 4;
			this.lnklblPharmiz.AutoSize = true;
			this.lnklblPharmiz.BackColor = Color.Transparent;
			this.lnklblPharmiz.LinkColor = Color.White;
			this.lnklblPharmiz.Location = new Point(544, 41);
			this.lnklblPharmiz.Name = "lnklblPharmiz";
			this.lnklblPharmiz.Size = new System.Drawing.Size(93, 13);
			this.lnklblPharmiz.TabIndex = 44;
			this.lnklblPharmiz.TabStop = true;
			this.lnklblPharmiz.Text = "www.pharmacy.com";
			this.lnklblPharmiz.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnklblPharmiz_LinkClicked);
			this.TrialBalance.BackColor = Color.Transparent;
			this.TrialBalance.Image = Resources.trail_balance;
			this.TrialBalance.Location = new Point(222, 367);
			this.TrialBalance.Name = "TrialBalance";
			this.TrialBalance.Size = new System.Drawing.Size(50, 50);
			this.TrialBalance.TabIndex = 42;
			this.TrialBalance.TabStop = false;
			this.TrialBalance.Click += new EventHandler(this.label8_Click);
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label18.Location = new Point(494, 388);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(38, 13);
			this.label18.TabIndex = 41;
			this.label18.Text = "Close";
			this.label18.Click += new EventHandler(this.label18_Click);
			this.label18.MouseDown += new MouseEventHandler(this.label18_MouseDown);
			this.label18.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label18.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label18.MouseUp += new MouseEventHandler(this.label18_MouseUp);
			this.Close.BackColor = Color.Transparent;
			this.Close.Image = Resources.close;
			this.Close.Location = new Point(438, 367);
			this.Close.Name = "Close";
			this.Close.Size = new System.Drawing.Size(50, 50);
			this.Close.TabIndex = 40;
			this.Close.TabStop = false;
			this.Close.Click += new EventHandler(this.label18_Click);
			this.Close.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Close.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label17.AutoSize = true;
			this.label17.Enabled = false;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label17.Location = new Point(494, 332);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(46, 13);
			this.label17.TabIndex = 39;
			this.label17.Text = "Logout";
			this.label17.Click += new EventHandler(this.label17_Click);
			this.label17.MouseDown += new MouseEventHandler(this.label17_MouseDown);
			this.label17.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label17.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label17.MouseUp += new MouseEventHandler(this.label17_MouseUp);
			this.Logout.BackColor = Color.Transparent;
			this.Logout.Enabled = false;
			this.Logout.Image = Resources.logg_out;
			this.Logout.Location = new Point(438, 311);
			this.Logout.Name = "Logout";
			this.Logout.Size = new System.Drawing.Size(50, 50);
			this.Logout.TabIndex = 38;
			this.Logout.TabStop = false;
			this.Logout.Click += new EventHandler(this.label17_Click);
			this.Logout.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Logout.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label16.AutoSize = true;
			this.label16.Enabled = false;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.Location = new Point(494, 276);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(108, 13);
			this.label16.TabIndex = 37;
			this.label16.Text = "Change Password";
			this.label16.Click += new EventHandler(this.label16_Click);
			this.label16.MouseDown += new MouseEventHandler(this.label16_MouseDown);
			this.label16.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label16.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label16.MouseUp += new MouseEventHandler(this.label16_MouseUp);
			this.ChangePassword.BackColor = Color.Transparent;
			this.ChangePassword.Enabled = false;
			this.ChangePassword.Image = Resources.change_pasword;
			this.ChangePassword.Location = new Point(438, 255);
			this.ChangePassword.Name = "ChangePassword";
			this.ChangePassword.Size = new System.Drawing.Size(50, 50);
			this.ChangePassword.TabIndex = 36;
			this.ChangePassword.TabStop = false;
			this.ChangePassword.Click += new EventHandler(this.label16_Click);
			this.ChangePassword.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.ChangePassword.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(494, 220);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(135, 13);
			this.label15.TabIndex = 35;
			this.label15.Text = "Change Financial Year";
			this.label15.Click += new EventHandler(this.label15_Click);
			this.label15.MouseDown += new MouseEventHandler(this.label15_MouseDown);
			this.label15.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label15.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label15.MouseUp += new MouseEventHandler(this.label15_MouseUp);
			this.ChangeFinancialYear.BackColor = Color.Transparent;
			this.ChangeFinancialYear.Image = Resources.Change_financial_year;
			this.ChangeFinancialYear.Location = new Point(438, 199);
			this.ChangeFinancialYear.Name = "ChangeFinancialYear";
			this.ChangeFinancialYear.Size = new System.Drawing.Size(50, 50);
			this.ChangeFinancialYear.TabIndex = 34;
			this.ChangeFinancialYear.TabStop = false;
			this.ChangeFinancialYear.Click += new EventHandler(this.label15_Click);
			this.ChangeFinancialYear.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.ChangeFinancialYear.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(494, 164);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(93, 13);
			this.label14.TabIndex = 33;
			this.label14.Text = "Profit And Loss";
			this.label14.Click += new EventHandler(this.label14_Click);
			this.label14.MouseDown += new MouseEventHandler(this.label14_MouseDown);
			this.label14.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label14.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label14.MouseUp += new MouseEventHandler(this.label14_MouseUp);
			this.ProfitAndLoss.BackColor = Color.Transparent;
			this.ProfitAndLoss.Image = Resources.Profit_and_loss_analysis;
			this.ProfitAndLoss.Location = new Point(438, 143);
			this.ProfitAndLoss.Name = "ProfitAndLoss";
			this.ProfitAndLoss.Size = new System.Drawing.Size(50, 50);
			this.ProfitAndLoss.TabIndex = 32;
			this.ProfitAndLoss.TabStop = false;
			this.ProfitAndLoss.Click += new EventHandler(this.label14_Click);
			this.ProfitAndLoss.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.ProfitAndLoss.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label13.Location = new Point(494, 108);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(90, 13);
			this.label13.TabIndex = 31;
			this.label13.Text = "Balance Sheet";
			this.label13.Click += new EventHandler(this.label13_Click);
			this.label13.MouseDown += new MouseEventHandler(this.label13_MouseDown);
			this.label13.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label13.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label13.MouseUp += new MouseEventHandler(this.label13_MouseUp);
			this.BalanceSheet.BackColor = Color.Transparent;
			this.BalanceSheet.Image = Resources.balance_sheet;
			this.BalanceSheet.Location = new Point(438, 87);
			this.BalanceSheet.Name = "BalanceSheet";
			this.BalanceSheet.Size = new System.Drawing.Size(50, 50);
			this.BalanceSheet.TabIndex = 30;
			this.BalanceSheet.TabStop = false;
			this.BalanceSheet.Click += new EventHandler(this.label13_Click);
			this.BalanceSheet.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.BalanceSheet.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(278, 388);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(82, 13);
			this.label8.TabIndex = 29;
			this.label8.Text = "Trial Balance";
			this.label8.Click += new EventHandler(this.label8_Click);
			this.label8.MouseDown += new MouseEventHandler(this.label8_MouseDown);
			this.label8.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label8.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label8.MouseUp += new MouseEventHandler(this.label8_MouseUp);
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(278, 332);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 13);
			this.label7.TabIndex = 27;
			this.label7.Text = "Search";
			this.label7.Click += new EventHandler(this.label7_Click);
			this.label7.MouseDown += new MouseEventHandler(this.label7_MouseDown);
			this.label7.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label7.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label7.MouseUp += new MouseEventHandler(this.label7_MouseUp);
			this.Search.BackColor = Color.Transparent;
			this.Search.Image = Resources.product_availability_search;
			this.Search.Location = new Point(222, 311);
			this.Search.Name = "Search";
			this.Search.Size = new System.Drawing.Size(50, 50);
			this.Search.TabIndex = 26;
			this.Search.TabStop = false;
			this.Search.Click += new EventHandler(this.label7_Click);
			this.Search.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Search.MouseHover += new EventHandler(this.label1_MouseHover);
			this.lblHeading.AutoSize = true;
			this.lblHeading.BackColor = Color.Transparent;
			this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblHeading.Location = new Point(8, 34);
			this.lblHeading.Name = "lblHeading";
			this.lblHeading.Size = new System.Drawing.Size(118, 20);
			this.lblHeading.TabIndex = 25;
			this.lblHeading.Text = "Quick Launch";
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(278, 276);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(102, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Receipt Voucher";
			this.label9.Click += new EventHandler(this.label9_Click);
			this.label9.MouseDown += new MouseEventHandler(this.label9_MouseDown);
			this.label9.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label9.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label9.MouseUp += new MouseEventHandler(this.label9_MouseUp);
			this.ReceiptVoucher.BackColor = Color.Transparent;
			this.ReceiptVoucher.Image = Resources.reciept;
			this.ReceiptVoucher.Location = new Point(222, 255);
			this.ReceiptVoucher.Name = "ReceiptVoucher";
			this.ReceiptVoucher.Size = new System.Drawing.Size(50, 50);
			this.ReceiptVoucher.TabIndex = 19;
			this.ReceiptVoucher.TabStop = false;
			this.ReceiptVoucher.Click += new EventHandler(this.label9_Click);
			this.ReceiptVoucher.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.ReceiptVoucher.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label10.Location = new Point(278, 220);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(106, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "Payment Voucher";
			this.label10.Click += new EventHandler(this.label10_Click);
			this.label10.MouseDown += new MouseEventHandler(this.label10_MouseDown);
			this.label10.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label10.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label10.MouseUp += new MouseEventHandler(this.label10_MouseUp);
			this.PaymentVoucher.BackColor = Color.Transparent;
			this.PaymentVoucher.Image = Resources.payment;
			this.PaymentVoucher.Location = new Point(222, 199);
			this.PaymentVoucher.Name = "PaymentVoucher";
			this.PaymentVoucher.Size = new System.Drawing.Size(50, 50);
			this.PaymentVoucher.TabIndex = 17;
			this.PaymentVoucher.TabStop = false;
			this.PaymentVoucher.Click += new EventHandler(this.label10_Click);
			this.PaymentVoucher.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.PaymentVoucher.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label11.Location = new Point(278, 164);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 13);
			this.label11.TabIndex = 16;
			this.label11.Text = "Sales Return";
			this.label11.Click += new EventHandler(this.label11_Click);
			this.label11.MouseDown += new MouseEventHandler(this.label11_MouseDown);
			this.label11.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label11.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label11.MouseUp += new MouseEventHandler(this.label11_MouseUp);
			this.SalesReturn.BackColor = Color.Transparent;
			this.SalesReturn.Image = Resources.sale_return;
			this.SalesReturn.Location = new Point(222, 143);
			this.SalesReturn.Name = "SalesReturn";
			this.SalesReturn.Size = new System.Drawing.Size(50, 50);
			this.SalesReturn.TabIndex = 15;
			this.SalesReturn.TabStop = false;
			this.SalesReturn.Click += new EventHandler(this.label11_Click);
			this.SalesReturn.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.SalesReturn.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label12.Location = new Point(278, 108);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(102, 13);
			this.label12.TabIndex = 14;
			this.label12.Text = "Purchase Return";
			this.label12.Click += new EventHandler(this.label12_Click);
			this.label12.MouseDown += new MouseEventHandler(this.label12_MouseDown);
			this.label12.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label12.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label12.MouseUp += new MouseEventHandler(this.label12_MouseUp);
			this.PurchaseReturn.BackColor = Color.Transparent;
			this.PurchaseReturn.Image = Resources.purchase_return;
			this.PurchaseReturn.Location = new Point(222, 87);
			this.PurchaseReturn.Name = "PurchaseReturn";
			this.PurchaseReturn.Size = new System.Drawing.Size(50, 50);
			this.PurchaseReturn.TabIndex = 13;
			this.PurchaseReturn.TabStop = false;
			this.PurchaseReturn.Click += new EventHandler(this.label12_Click);
			this.PurchaseReturn.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.PurchaseReturn.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(67, 388);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Counter Sale";
			this.label6.Click += new EventHandler(this.label6_Click);
			this.label6.MouseDown += new MouseEventHandler(this.label6_MouseDown);
			this.label6.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label6.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label6.MouseUp += new MouseEventHandler(this.label6_MouseUp);
			this.CounterSale.BackColor = Color.Transparent;
			this.CounterSale.Image = Resources.counter_sale;
			this.CounterSale.Location = new Point(11, 367);
			this.CounterSale.Name = "CounterSale";
			this.CounterSale.Size = new System.Drawing.Size(50, 50);
			this.CounterSale.TabIndex = 11;
			this.CounterSale.TabStop = false;
			this.CounterSale.Click += new EventHandler(this.label6_Click);
			this.CounterSale.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.CounterSale.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(67, 332);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Sales";
			this.label5.Click += new EventHandler(this.label5_Click);
			this.label5.MouseDown += new MouseEventHandler(this.label5_MouseDown);
			this.label5.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label5.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label5.MouseUp += new MouseEventHandler(this.label5_MouseUp);
			this.Sales.BackColor = Color.Transparent;
			this.Sales.Image = Resources.sales;
			this.Sales.Location = new Point(11, 311);
			this.Sales.Name = "Sales";
			this.Sales.Size = new System.Drawing.Size(50, 50);
			this.Sales.TabIndex = 9;
			this.Sales.TabStop = false;
			this.Sales.Click += new EventHandler(this.label5_Click);
			this.Sales.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Sales.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(67, 276);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Purchase";
			this.label4.Click += new EventHandler(this.label4_Click);
			this.label4.MouseDown += new MouseEventHandler(this.label4_MouseDown);
			this.label4.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label4.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label4.MouseUp += new MouseEventHandler(this.label4_MouseUp);
			this.Purchase.BackColor = Color.Transparent;
			this.Purchase.Image = Resources.purchase;
			this.Purchase.Location = new Point(11, 255);
			this.Purchase.Name = "Purchase";
			this.Purchase.Size = new System.Drawing.Size(50, 50);
			this.Purchase.TabIndex = 7;
			this.Purchase.TabStop = false;
			this.Purchase.Click += new EventHandler(this.label4_Click);
			this.Purchase.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Purchase.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(67, 220);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Vendor";
			this.label3.Click += new EventHandler(this.label3_Click);
			this.label3.MouseDown += new MouseEventHandler(this.label3_MouseDown);
			this.label3.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label3.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label3.MouseUp += new MouseEventHandler(this.label3_MouseUp);
			this.Vendor.BackColor = Color.Transparent;
			this.Vendor.Image = Resources.vendor_new;
			this.Vendor.Location = new Point(11, 199);
			this.Vendor.Name = "Vendor";
			this.Vendor.Size = new System.Drawing.Size(50, 50);
			this.Vendor.TabIndex = 5;
			this.Vendor.TabStop = false;
			this.Vendor.Click += new EventHandler(this.label3_Click);
			this.Vendor.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Vendor.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(67, 164);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Product";
			this.label2.Click += new EventHandler(this.label2_Click);
			this.label2.MouseDown += new MouseEventHandler(this.label2_MouseDown);
			this.label2.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label2.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label2.MouseUp += new MouseEventHandler(this.label2_MouseUp);
			this.Product.BackColor = Color.Transparent;
			this.Product.Image = Resources.Product_creation;
			this.Product.Location = new Point(11, 143);
			this.Product.Name = "Product";
			this.Product.Size = new System.Drawing.Size(50, 50);
			this.Product.TabIndex = 3;
			this.Product.TabStop = false;
			this.Product.Click += new EventHandler(this.label2_Click);
			this.Product.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.Product.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(67, 108);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Account Ledger";
			this.label1.Click += new EventHandler(this.label1_Click);
			this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
			this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.label1.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label1.MouseUp += new MouseEventHandler(this.label1_MouseUp);
			this.AccountLedger.BackColor = Color.Transparent;
			this.AccountLedger.Image = Resources.Account_ledger;
			this.AccountLedger.Location = new Point(11, 87);
			this.AccountLedger.Name = "AccountLedger";
			this.AccountLedger.Size = new System.Drawing.Size(50, 50);
			this.AccountLedger.TabIndex = 1;
			this.AccountLedger.TabStop = false;
			this.AccountLedger.Click += new EventHandler(this.label1_Click);
			this.AccountLedger.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			this.AccountLedger.MouseHover += new EventHandler(this.label1_MouseHover);
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Dock = DockStyle.Bottom;
			this.panel6.Location = new Point(0, 448);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 16);
			this.panel6.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(650, 466);
			base.ControlBox = false;
			base.Controls.Add(this.pnlMAin);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.Name = "MDIForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "MDIForm";
			base.Activated += new EventHandler(this.MDIForm_Activated);
			this.pnlMAin.ResumeLayout(false);
			this.pnlMAin.PerformLayout();
			((ISupportInitialize)this.TrialBalance).EndInit();
			((ISupportInitialize)this.Close).EndInit();
			((ISupportInitialize)this.Logout).EndInit();
			((ISupportInitialize)this.ChangePassword).EndInit();
			((ISupportInitialize)this.ChangeFinancialYear).EndInit();
			((ISupportInitialize)this.ProfitAndLoss).EndInit();
			((ISupportInitialize)this.BalanceSheet).EndInit();
			((ISupportInitialize)this.Search).EndInit();
			((ISupportInitialize)this.ReceiptVoucher).EndInit();
			((ISupportInitialize)this.PaymentVoucher).EndInit();
			((ISupportInitialize)this.SalesReturn).EndInit();
			((ISupportInitialize)this.PurchaseReturn).EndInit();
			((ISupportInitialize)this.CounterSale).EndInit();
			((ISupportInitialize)this.Sales).EndInit();
			((ISupportInitialize)this.Purchase).EndInit();
			((ISupportInitialize)this.Vendor).EndInit();
			((ISupportInitialize)this.Product).EndInit();
			((ISupportInitialize)this.AccountLedger).EndInit();
			base.ResumeLayout(false);
		}

		private void label1_Click(object sender, EventArgs e)
		{
			frmAccountLedger _frmAccountLedger = new frmAccountLedger();
			frmAccountLedger item = Application.OpenForms["frmAccountLedger"] as frmAccountLedger;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmAccountLedger.WindowState = FormWindowState.Normal;
				_frmAccountLedger.MdiParent = MDIMedicalShop.MDIObj;
				_frmAccountLedger.Show();
			}
		}

		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label1);
		}

		private void label1_MouseHover(object sender, EventArgs e)
		{
			this.MakeCursorAsHand();
		}

		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			this.MakeCursorAsHand();
		}

		private void label1_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label1);
		}

		private void label10_Click(object sender, EventArgs e)
		{
			frmPayment _frmPayment = new frmPayment();
			frmPayment item = Application.OpenForms["frmPayment"] as frmPayment;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmPayment.WindowState = FormWindowState.Normal;
				_frmPayment.MdiParent = MDIMedicalShop.MDIObj;
				_frmPayment.Show();
			}
		}

		private void label10_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label10);
		}

		private void label10_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label10);
		}

		private void label11_Click(object sender, EventArgs e)
		{
			frmSalesReturn _frmSalesReturn = new frmSalesReturn();
			frmSalesReturn item = Application.OpenForms["frmSalesReturn"] as frmSalesReturn;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmSalesReturn.WindowState = FormWindowState.Normal;
				_frmSalesReturn.MdiParent = MDIMedicalShop.MDIObj;
				_frmSalesReturn.Show();
			}
		}

		private void label11_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label11);
		}

		private void label11_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label11);
		}

		private void label12_Click(object sender, EventArgs e)
		{
			frmPurchaseReturn _frmPurchaseReturn = new frmPurchaseReturn();
			frmPurchaseReturn item = Application.OpenForms["frmPurchaseReturn"] as frmPurchaseReturn;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmPurchaseReturn.WindowState = FormWindowState.Normal;
				_frmPurchaseReturn.MdiParent = MDIMedicalShop.MDIObj;
				_frmPurchaseReturn.Show();
			}
		}

		private void label12_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label12);
		}

		private void label12_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label12);
		}

		private void label13_Click(object sender, EventArgs e)
		{
			rptBalanceSheet _rptBalanceSheet = new rptBalanceSheet();
			rptBalanceSheet item = Application.OpenForms["rptBalanceSheet"] as rptBalanceSheet;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_rptBalanceSheet.WindowState = FormWindowState.Normal;
				_rptBalanceSheet.MdiParent = MDIMedicalShop.MDIObj;
				_rptBalanceSheet.Show();
			}
		}

		private void label13_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label13);
		}

		private void label13_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label13);
		}

		private void label14_Click(object sender, EventArgs e)
		{
			rptProfitAndLossAnalysis rptProfitAndLossAnalysi = new rptProfitAndLossAnalysis();
			rptProfitAndLossAnalysis item = Application.OpenForms["rptProfitAndLossAnalysis"] as rptProfitAndLossAnalysis;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				rptProfitAndLossAnalysi.WindowState = FormWindowState.Normal;
				rptProfitAndLossAnalysi.MdiParent = MDIMedicalShop.MDIObj;
				rptProfitAndLossAnalysi.Show();
			}
		}

		private void label14_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label14);
		}

		private void label14_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label14);
		}

		private void label15_Click(object sender, EventArgs e)
		{
			frmSelectFinancialYear _frmSelectFinancialYear = new frmSelectFinancialYear();
			frmSelectFinancialYear item = Application.OpenForms["frmSelectFinancialYear"] as frmSelectFinancialYear;
			if (item != null)
			{
				_frmSelectFinancialYear.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmSelectFinancialYear.WindowState = FormWindowState.Normal;
				_frmSelectFinancialYear.MdiParent = MDIMedicalShop.MDIObj;
				_frmSelectFinancialYear.Show();
			}
		}

		private void label15_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label15);
		}

		private void label15_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label15);
		}

		private void label16_Click(object sender, EventArgs e)
		{
		}

		private void label16_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label16);
		}

		private void label16_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label16);
		}

		private void label17_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to Logout?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				if (Application.OpenForms.Count != 1)
				{
					for (int i = 0; i < Application.OpenForms.Count; i++)
					{
						if ((Application.OpenForms[i] == MDIMedicalShop.MDIObj ? false : Application.OpenForms[i] != this))
						{
							Application.OpenForms[i].Close();
							i--;
						}
					}
				}
			}
		}

		private void label17_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label17);
		}

		private void label17_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label17);
		}

		private void label18_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void label18_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label18);
		}

		private void label18_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label18);
		}

		private void label2_Click(object sender, EventArgs e)
		{
			frmProduct _frmProduct = new frmProduct();
			frmProduct item = Application.OpenForms["frmProduct"] as frmProduct;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmProduct.WindowState = FormWindowState.Normal;
				_frmProduct.MdiParent = MDIMedicalShop.MDIObj;
				_frmProduct.Show();
			}
		}

		private void label2_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label2);
		}

		private void label2_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label2);
		}

		private void label3_Click(object sender, EventArgs e)
		{
			frmVendor _frmVendor = new frmVendor();
			frmVendor item = Application.OpenForms["frmVendor"] as frmVendor;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmVendor.WindowState = FormWindowState.Normal;
				_frmVendor.MdiParent = MDIMedicalShop.MDIObj;
				_frmVendor.Show();
			}
		}

		private void label3_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label3);
		}

		private void label3_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label3);
		}

		private void label4_Click(object sender, EventArgs e)
		{
			frmPurchaseInvoice _frmPurchaseInvoice = new frmPurchaseInvoice();
			frmPurchaseInvoice item = Application.OpenForms["frmPurchaseInvoice"] as frmPurchaseInvoice;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmPurchaseInvoice.WindowState = FormWindowState.Normal;
				_frmPurchaseInvoice.MdiParent = MDIMedicalShop.MDIObj;
				_frmPurchaseInvoice.Show();
			}
		}

		private void label4_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label4);
		}

		private void label4_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label4);
		}

		private void label5_Click(object sender, EventArgs e)
		{
			frmSalesInvoice _frmSalesInvoice = new frmSalesInvoice();
			frmSalesInvoice item = Application.OpenForms["frmSalesInvoice"] as frmSalesInvoice;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmSalesInvoice.WindowState = FormWindowState.Normal;
				_frmSalesInvoice.MdiParent = MDIMedicalShop.MDIObj;
				_frmSalesInvoice.Show();
			}
		}

		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label5);
		}

		private void label5_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label5);
		}

		private void label6_Click(object sender, EventArgs e)
		{
			frmCounterSale _frmCounterSale = new frmCounterSale();
			frmCounterSale item = Application.OpenForms["frmCounterSale"] as frmCounterSale;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmCounterSale.WindowState = FormWindowState.Normal;
				_frmCounterSale.MdiParent = MDIMedicalShop.MDIObj;
				_frmCounterSale.Show();
			}
		}

		private void label6_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label6);
		}

		private void label6_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label6);
		}

		private void label7_Click(object sender, EventArgs e)
		{
			frmProductAvailability _frmProductAvailability = new frmProductAvailability();
			frmProductAvailability item = Application.OpenForms["frmProductAvailability"] as frmProductAvailability;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmProductAvailability.WindowState = FormWindowState.Normal;
				_frmProductAvailability.MdiParent = MDIMedicalShop.MDIObj;
				_frmProductAvailability.Show();
			}
		}

		private void label7_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label7);
		}

		private void label7_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label7);
		}

		private void label8_Click(object sender, EventArgs e)
		{
			rptTrialBalance _rptTrialBalance = new rptTrialBalance();
			rptTrialBalance item = Application.OpenForms["rptTrialBalance"] as rptTrialBalance;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_rptTrialBalance.WindowState = FormWindowState.Normal;
				_rptTrialBalance.MdiParent = MDIMedicalShop.MDIObj;
				_rptTrialBalance.Show();
			}
		}

		private void label8_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label8);
		}

		private void label8_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label8);
		}

		private void label9_Click(object sender, EventArgs e)
		{
			frmReceipt _frmReceipt = new frmReceipt();
			frmReceipt item = Application.OpenForms["frmReceipt"] as frmReceipt;
			if (item != null)
			{
				item.MdiParent = MDIMedicalShop.MDIObj;
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
				_frmReceipt.WindowState = FormWindowState.Normal;
				_frmReceipt.MdiParent = MDIMedicalShop.MDIObj;
				_frmReceipt.Show();
			}
		}

		private void label9_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(this.label9);
		}

		private void label9_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(this.label9);
		}

		private void lnklblPharmiz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("IExplore.exe", "http://www.pharmacy.com/");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void MakeCursorAsHand()
		{
			try
			{
				foreach (Control control in this.pnlMAin.Controls)
				{
					if ((control is Label ? true : control is PictureBox))
					{
						if (control.Name != "lblHeading")
						{
							control.Cursor = Cursors.Hand;
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

		private void MDIForm_Activated(object sender, EventArgs e)
		{
			base.SendToBack();
		}

		public void MouseDown(Label lbl)
		{
			try
			{
				int y = lbl.Location.Y + 1;
				lbl.Location = new Point(lbl.Location.X, y);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void MouseUp(Label lbl)
		{
			try
			{
				int y = lbl.Location.Y - 1;
				lbl.Location = new Point(lbl.Location.X, y);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}