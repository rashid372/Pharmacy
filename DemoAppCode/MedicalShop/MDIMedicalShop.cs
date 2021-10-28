using MedicalShop.Properties;
using Microsoft.SqlServer.Management.Smo;
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
	public class MDIMedicalShop : Form
	{
		private IContainer components = null;

		private MenuStrip menuStrip;

		private System.Windows.Forms.ToolTip ToolTip;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem initialRecordsToolStripMenuItem;

		private ToolStripMenuItem transactToolStripMenuItem;

		private ToolStripMenuItem createCompanyToolStripMenuItem;

		private ToolStripMenuItem selectCompanyToolStripMenuItem;

		private ToolStripMenuItem editCompanyToolStripMenuItem;

		private ToolStripMenuItem inventoryToolStripMenuItem;

		private ToolStripMenuItem settingsToolStripMenuItem;

		private ToolStripMenuItem registersToolStripMenuItem;

		private ToolStripMenuItem accountingStatementsToolStripMenuItem;

		private ToolStripMenuItem reminderToolStripMenuItem;

		private ToolStripMenuItem productAvailabilitySearchToolStripMenuItem;

		private ToolStripMenuItem draftMailToolStripMenuItem;

		private ToolStripMenuItem exitToolStripMenuItem;

		private ToolStripMenuItem deleteCompanyToolStripMenuItem;

		private ToolStripMenuItem backupToolStripMenuItem;

		private ToolStripMenuItem restoreToolStripMenuItem;

		private ToolStripMenuItem closeCompanyToolStripMenuItem;

		private ToolStripMenuItem accountGroupToolStripMenuItem;

		private ToolStripMenuItem accountLedgerToolStripMenuItem;

		private ToolStripMenuItem manufacturerToolStripMenuItem;

		private ToolStripMenuItem shelfToolStripMenuItem;

		private ToolStripMenuItem genericNameToolStripMenuItem;

		private ToolStripMenuItem productGroupToolStripMenuItem;

		private ToolStripMenuItem productToolStripMenuItem;

		private ToolStripMenuItem vendorToolStripMenuItem;

		private ToolStripMenuItem salesManToolStripMenuItem;

		private ToolStripMenuItem unitToolStripMenuItem;

		private ToolStripMenuItem patientToolStripMenuItem;

		private ToolStripMenuItem purchaseToolStripMenuItem;

		private ToolStripMenuItem purchaseReturnToolStripMenuItem;

		private ToolStripMenuItem salesToolStripMenuItem;

		private ToolStripMenuItem counterSaleToolStripMenuItem;

		private ToolStripMenuItem salesReturnToolStripMenuItem;

		private ToolStripMenuItem paymentVoucherToolStripMenuItem;

		private ToolStripMenuItem receiptVoucherToolStripMenuItem;

		private ToolStripMenuItem journalEntryToolStripMenuItem;

		private ToolStripMenuItem stockEntryToolStripMenuItem;

		private ToolStripMenuItem finacialYearToolStripMenuItem;

		private ToolStripMenuItem newFinancialYearToolStripMenuItem;

		private ToolStripMenuItem editFinancialYearToolStripMenuItem;

		private ToolStripMenuItem changeFinancialYearToolStripMenuItem;

		private ToolStripMenuItem changeFinancialYearToolStripMenuItem1;

		private ToolStripMenuItem generalSettingsToolStripMenuItem;

		private ToolStripMenuItem uSerToolStripMenuItem;

		private ToolStripMenuItem createUserToolStripMenuItem;

		private ToolStripMenuItem privilegeSettingsToolStripMenuItem;

		private ToolStripMenuItem changePasswordToolStripMenuItem;

		private ToolStripMenuItem greetingToolStripMenuItem;

		private ToolStripMenuItem calculatorToolStripMenuItem;

		private ToolStripMenuItem addPrinterToolStripMenuItem;

		private ToolStripMenuItem microsoftWordToolStripMenuItem;

		private ToolStripMenuItem microsoftExcelToolStripMenuItem;

		private ToolStripMenuItem telephoneDirectoryToolStripMenuItem;

		private ToolStripMenuItem draftMailToolStripMenuItem1;

		private ToolStripMenuItem schedulerToolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem paymentToolStripMenuItem;

		private ToolStripMenuItem purchaseReturnToolStripMenuItem1;

		private ToolStripMenuItem salesToolStripMenuItem1;

		private ToolStripMenuItem counterSaleToolStripMenuItem1;

		private ToolStripMenuItem salesReturnToolStripMenuItem1;

		private ToolStripMenuItem paymentVoucherToolStripMenuItem1;

		private ToolStripMenuItem receiptVoucherToolStripMenuItem1;

		private ToolStripMenuItem journalEntryToolStripMenuItem1;

		private ToolStripMenuItem balanceSheetToolStripMenuItem;

		private ToolStripMenuItem profitLossAnalysisToolStripMenuItem;

		private ToolStripMenuItem cashBookToolStripMenuItem;

		private ToolStripMenuItem bankBookToolStripMenuItem;

		private ToolStripMenuItem daToolStripMenuItem;

		private SaveFileDialog saveBackupDialog;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem logouttoolStripMenuItem;

		private ToolStripMenuItem stockRegisterToolStripMenuItem;

		private ToolStripStatusLabel toolStripStatusLabel;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel btnReminder;

		private Panel pReminder;

		private Label lblReminder;

		private PictureBox pictureBox1;

		private Panel panel6;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Timer timMov;

		private Timer timMovOut;

		private Label lblExpiry;

		private Label lblLowStock;

		private Timer timer1;

		private ToolStripMenuItem reminderToolStripMenuItem1;

		private ToolStripMenuItem productToolStripMenuItem1;

		private ToolStripMenuItem damageStockRegisterToolStripMenuItem;

		private ToolStripMenuItem stockNewToolStripMenuItem;

		private ToolStripMenuItem Transaction;

		private ToolStripMenuItem shortExpiryToolStripMenuItem;

		private ToolStripMenuItem stockAtMinimumLevelToolStripMenuItem;

		private ToolStripMenuItem productStatisticsToolStripMenuItem;

		private ToolStripMenuItem taxReportToolStripMenuItem;

		private ToolStripMenuItem priceListToolStripMenuItem;

        private ToolStripMenuItem DailyExpenseToolStripMenuItem;
        private ToolStripMenuItem AdvancedReportsToolStripMenuItem;
        private ToolStripMenuItem StockandPriceToolStripMenuItem;
        private ToolStripMenuItem MostRunningProductsToolStripMenuItem;
        private ToolStripMenuItem MostPurchaseProductsToolStripMenuItem;

        private ToolStripMenuItem MonthlyExpenseToolStripMenuItem;

        private ToolStripMenuItem stockAndSaleToolStripMenuItem;

		private ToolStripMenuItem ledgerBalane;

		private ToolStripMenuItem purchaseToolStripMenuItem2;

		private ToolStripMenuItem purchaseReturnToolStripMenuItem3;

		private ToolStripMenuItem salesToolStripMenuItem2;

		private ToolStripMenuItem salesReturnToolStripMenuItem2;

		private ToolStripMenuItem counterSaleToolStripMenuItem2;

		private ToolStripMenuItem instantSaleToolStripMenuItem;

		private ToolStripMenuItem paymentToolStripMenuItem2;

		private ToolStripMenuItem receiptToolStripMenuItem1;

		private ToolStripMenuItem journalToolStripMenuItem1;

		private ToolStripMenuItem initialRecords;

		private ToolStripMenuItem accountGroupToolStripMenuItem2;

		private ToolStripMenuItem accountLedgerToolStripMenuItem2;

		private ToolStripMenuItem genericNameToolStripMenuItem2;

		private ToolStripMenuItem productGroupToolStripMenuItem2;

		private ToolStripMenuItem productBatchToolStripMenuItem1;

		private ToolStripMenuItem manufactureToolStripMenuItem;

		private ToolStripMenuItem vendorToolStripMenuItem2;

		private ToolStripMenuItem salesManToolStripMenuItem1;

		private ToolStripMenuItem patientToolStripMenuItem1;

		private ToolStripMenuItem docotorToolStripMenuItem;

		private ToolStripMenuItem userToolStripMenuItem2;

		private ToolStripMenuItem Inventory;

		private ToolStripMenuItem stockToolStripMenuItem;

		private ToolStripMenuItem damageStockToolStripMenuItem1;

		private PictureBox btnClose;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem help;

		private ToolStripMenuItem contentsToolStripMenuItem;

		private ToolStripMenuItem aboutToolStripMenuItem;

		private int childFormNumber = 0;

		private static Server srvSql;

		public static MDIMedicalShop MDIObj;

		public static bool ReminderPopUpOpenStatis;

		private int x = 5;

		private int pyb = 2;

		private int pyb2 = 182;

		private int checkCount = 0;

		private int checkCountNew = 0;

		private Point p = new Point();

		private bool isEmpty = true;

		private bool isClose = true;

		private MDIForm frmQuickLaunch = new MDIForm();

		static MDIMedicalShop()
		{
			MDIMedicalShop.ReminderPopUpOpenStatis = true;
		}

		public MDIMedicalShop()
		{
			this.InitializeComponent();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmAboutUs frmAboutU = new frmAboutUs();
			frmAboutUs item = Application.OpenForms["frmAboutUs"] as frmAboutUs;
			if (item != null)
			{
				item.MdiParent = this;
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
				frmAboutU.WindowState = FormWindowState.Normal;
				frmAboutU.MdiParent = this;
				frmAboutU.Show();
			}
		}

		private void accountGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmAccountGroup _frmAccountGroup = new frmAccountGroup();
			frmAccountGroup item = Application.OpenForms["frmAccountGroup"] as frmAccountGroup;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmAccountGroup.WindowState = FormWindowState.Normal;
				_frmAccountGroup.MdiParent = this;
				_frmAccountGroup.Show();
			}
		}

		private void accountGroupToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptAccountGroup _rptAccountGroup = new rptAccountGroup();
			rptAccountGroup item = Application.OpenForms["rptAccountGroup"] as rptAccountGroup;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptAccountGroup.WindowState = FormWindowState.Normal;
				_rptAccountGroup.MdiParent = this;
				_rptAccountGroup.Show();
			}
		}

		private void accountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmAccountLedger _frmAccountLedger = new frmAccountLedger();
			frmAccountLedger item = Application.OpenForms["frmAccountLedger"] as frmAccountLedger;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmAccountLedger.MdiParent = this;
				_frmAccountLedger.Show();
			}
		}

		private void accountLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
		{
		}

		private void accountLedgerToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptAccountledger _rptAccountledger = new rptAccountledger();
			rptAccountledger item = Application.OpenForms["rptAccountledger"] as rptAccountledger;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptAccountledger.WindowState = FormWindowState.Normal;
				_rptAccountledger.MdiParent = this;
				_rptAccountledger.Show();
			}
		}

		private void addPrinterToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo()
				{
					FileName = "rundll32.exe",
					CreateNoWindow = true,
					Arguments = "shell32.dll,SHHelpShortcuts_RunDLL AddPrinter",
					UseShellExecute = true
				};
				Process.Start(processStartInfo);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void backupToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptBalanceSheet _rptBalanceSheet = new rptBalanceSheet();
			rptBalanceSheet item = Application.OpenForms["rptBalanceSheet"] as rptBalanceSheet;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptBalanceSheet.MdiParent = this;
				_rptBalanceSheet.Show();
			}
		}

		private void bankBookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptBankBook _rptBankBook = new rptBankBook();
			rptBankBook item = Application.OpenForms["rptBankBook"] as rptBankBook;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptBankBook.WindowState = FormWindowState.Normal;
				_rptBankBook.MdiParent = this;
				_rptBankBook.Show();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.isClose = false;
			this.timMovOut.Enabled = true;
		}

		private void btnClose_Click_1(object sender, EventArgs e)
		{
			this.isClose = false;
			this.timMovOut.Enabled = true;
		}

		private void btnReminder_Click(object sender, EventArgs e)
		{
			if (this.isClose)
			{
				this.isClose = false;
				this.timMovOut.Enabled = true;
			}
			else
			{
				this.isClose = true;
				this.ReminderPopUp();
			}
		}

		private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.Cascade);
		}

		private void cashBookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptCashBook _rptCashBook = new rptCashBook();
			rptCashBook item = Application.OpenForms["rptCashBook"] as rptCashBook;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptCashBook.WindowState = FormWindowState.Normal;
				_rptCashBook.MdiParent = this;
				_rptCashBook.Show();
			}
		}

		private void changeFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSelectFinancialYear _frmSelectFinancialYear = new frmSelectFinancialYear();
			frmSelectFinancialYear item = Application.OpenForms["frmSelectFinancialYear"] as frmSelectFinancialYear;
			if (item != null)
			{
				_frmSelectFinancialYear.MdiParent = this;
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
				_frmSelectFinancialYear.MdiParent = this;
				_frmSelectFinancialYear.Show();
			}
		}

		private void changeFinancialYearToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public bool checkAnyData()
		{
			bool flag = false;
			ReminderSP reminderSP = new ReminderSP();
			ProductSP productSP = new ProductSP();
			ProductBatchSP productBatchSP = new ProductBatchSP();
			DataTable dataTable = new DataTable();
			DataTable allLowStockProduct = new DataTable();
			DataTable dataTable1 = new DataTable();
			dataTable = reminderSP.ReminderViewBydate(DateTime.Today);
			allLowStockProduct = productSP.GetAllLowStockProduct();
			dataTable1 = productBatchSP.ShortExpiryBatchGet(DateTime.Today);
			this.checkCount = dataTable.Rows.Count + allLowStockProduct.Rows.Count + dataTable1.Rows.Count;
			if (this.checkCount > this.checkCountNew)
			{
				this.checkCountNew = this.checkCount;
				this.lblReminder.Text = "";
				this.EnableStaticTimer();
			}
			if ((dataTable.Rows.Count != 0 || allLowStockProduct.Rows.Count != 0 ? true : dataTable1.Rows.Count != 0))
			{
				flag = true;
			}
			else
			{
				this.checkCountNew = 0;
				this.checkCount = 0;
				this.pyb2 = this.pyb2 - 4;
				this.p.X = base.Right - 258;
				this.p.Y = base.Bottom - this.pyb2;
				this.pReminder.Location = this.p;
				this.timMovOut.Enabled = true;
				flag = false;
			}
			return flag;
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form[] mdiChildren = base.MdiChildren;
			for (int i = 0; i < (int)mdiChildren.Length; i++)
			{
				mdiChildren[i].Close();
			}
		}

		private void closeCompanyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to close company?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Restart();
			}
		}

		private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("hh.exe", string.Concat(Application.StartupPath, "\\PharmizHelp.chm"));
			}
			catch (Exception exception)
			{
			}
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void counterSaleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCounterSale _frmCounterSale = new frmCounterSale();
			frmCounterSale item = Application.OpenForms["frmCounterSale"] as frmCounterSale;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmCounterSale.MdiParent = this;
				_frmCounterSale.Show();
			}
		}

		private void counterSaleToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmCounterSaleRegister _frmCounterSaleRegister = new frmCounterSaleRegister();
			frmCounterSaleRegister item = Application.OpenForms["frmCounterSaleRegister"] as frmCounterSaleRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmCounterSaleRegister.WindowState = FormWindowState.Normal;
				_frmCounterSaleRegister.MdiParent = this;
				_frmCounterSaleRegister.Show();
			}
		}

		private void counterSaleToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptCounterSale _rptCounterSale = new rptCounterSale();
			rptCounterSale item = Application.OpenForms["rptCounterSale"] as rptCounterSale;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptCounterSale.WindowState = FormWindowState.Normal;
				_rptCounterSale.MdiParent = this;
				_rptCounterSale.Show();
			}
		}

		private void createCompanyToolStripMenuItem_Click(object sender, EventArgs e)
		{
            frmMedicalShop _frmMedicalShop = new frmMedicalShop();
            frmMedicalShop item = Application.OpenForms["frmMedicalShop"] as frmMedicalShop;
            if (item != null)
            {
                item.MdiParent = this;
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
                _frmMedicalShop.WindowState = FormWindowState.Normal;
                _frmMedicalShop.MdiParent = this;
                _frmMedicalShop.Show();
            }
        }

		private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmUserCreation _frmUserCreation = new frmUserCreation();
			frmUserCreation item = Application.OpenForms["frmUserCreation"] as frmUserCreation;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmUserCreation.WindowState = FormWindowState.Normal;
				_frmUserCreation.MdiParent = this;
				_frmUserCreation.Show();
			}
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void damageStockRegisterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmDamageStockRegister _frmDamageStockRegister = new frmDamageStockRegister();
			frmDamageStockRegister item = Application.OpenForms["frmDamageStockRegister"] as frmDamageStockRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmDamageStockRegister.WindowState = FormWindowState.Normal;
				_frmDamageStockRegister.MdiParent = this;
				_frmDamageStockRegister.Show();
			}
		}

		private void damageStockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmDamageStock _frmDamageStock = new frmDamageStock();
			frmDamageStock item = Application.OpenForms["frmDamageStock"] as frmDamageStock;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmDamageStock.WindowState = FormWindowState.Normal;
				_frmDamageStock.MdiParent = this;
				_frmDamageStock.Show();
			}
		}

		private void damageStockToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rptDamageStock _rptDamageStock = new rptDamageStock();
			rptDamageStock item = Application.OpenForms["rptDamageStock"] as rptDamageStock;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptDamageStock.WindowState = FormWindowState.Normal;
				_rptDamageStock.MdiParent = this;
				_rptDamageStock.Show();
			}
		}

		private void daToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptDayBook _rptDayBook = new rptDayBook();
			rptDayBook item = Application.OpenForms["rptDayBook"] as rptDayBook;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptDayBook.WindowState = FormWindowState.Normal;
				_rptDayBook.MdiParent = this;
				_rptDayBook.Show();
			}
		}

		public void DeleteCompany()
		{
			if ((CompanyInfo._companyId == "" ? false : CompanyInfo._companyId != null))
			{
				if (MessageBox.Show("Do you want to delete this company?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					(new PrimaryDBSP()).CompanyPathDeleteByCompanyId(CompanyInfo._companyId);
					DBConnection dBConnection = new DBConnection();
					MessageBox.Show("Company deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Application.Restart();
				}
			}
		}

		private void deleteCompanyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
                DeleteCompany();

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

		private void docotorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rtpDoctor _rtpDoctor = new rtpDoctor();
			rtpDoctor item = Application.OpenForms["rtpDoctor"] as rtpDoctor;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rtpDoctor.WindowState = FormWindowState.Normal;
				_rtpDoctor.MdiParent = this;
				_rtpDoctor.Show();
			}
		}

		private void draftMailToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmSendMail _frmSendMail = new frmSendMail();
			frmSendMail item = Application.OpenForms["frmSendMail"] as frmSendMail;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmSendMail.WindowState = FormWindowState.Normal;
				_frmSendMail.MdiParent = this;
				_frmSendMail.Show();
			}
		}

		private void editCompanyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmMedicalShop _frmMedicalShop = new frmMedicalShop();
			frmMedicalShop item = Application.OpenForms["frmMedicalShop"] as frmMedicalShop;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmMedicalShop.WindowState = FormWindowState.Normal;
				_frmMedicalShop.MdiParent = this;
				_frmMedicalShop.CallThisFormFromMDIForEdit();
			}
		}

        private void selectCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectCompany _frmMedicalShop = new frmSelectCompany();
            frmSelectCompany item = Application.OpenForms["frmSelectCompany"] as frmSelectCompany;
            if (item != null)
            {
                item.MdiParent = this;
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
                _frmMedicalShop.WindowState = FormWindowState.Normal;
                _frmMedicalShop.MdiParent = this;
                _frmMedicalShop.Show();
            }
        }

        private void editFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCreateFinancialYear _frmCreateFinancialYear = new frmCreateFinancialYear();
			frmCreateFinancialYear item = Application.OpenForms["frmCreateFinancialYear"] as frmCreateFinancialYear;
			if (item != null)
			{
				item.MdiParent = this;
				_frmCreateFinancialYear.CallThisFormFromMDI(true);
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
				_frmCreateFinancialYear.WindowState = FormWindowState.Normal;
				_frmCreateFinancialYear.MdiParent = this;
				_frmCreateFinancialYear.CallThisFormFromMDI(true);
				_frmCreateFinancialYear.Show();
			}
		}

		public void EnableStaticTimer()
		{
			this.timer1.Enabled = true;
			this.ReminderPopUp();
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmGeneralSettings frmGeneralSetting = new frmGeneralSettings();
			frmGeneralSettings item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
			if (item != null)
			{
				item.MdiParent = this;
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
				frmGeneralSetting.WindowState = FormWindowState.Normal;
				frmGeneralSetting.MdiParent = this;
				frmGeneralSetting.Show();
			}
		}

		private void genericNameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmGenericNames frmGenericName = new frmGenericNames();
			frmGenericNames item = Application.OpenForms["frmGenericNames"] as frmGenericNames;
			if (item != null)
			{
				item.MdiParent = this;
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
				frmGenericName.WindowState = FormWindowState.Normal;
				frmGenericName.MdiParent = this;
				frmGenericName.Show();
			}
		}

		private void genericNameToolStripMenuItem1_Click(object sender, EventArgs e)
		{
		}

		private void genericNameToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptGenericName _rptGenericName = new rptGenericName();
			rptGenericName item = Application.OpenForms["rptGenericName"] as rptGenericName;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptGenericName.WindowState = FormWindowState.Normal;
				_rptGenericName.MdiParent = this;
				_rptGenericName.Show();
			}
		}

		private void greetingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmGreetingText _frmGreetingText = new frmGreetingText();
			frmGreetingText item = Application.OpenForms["frmGreetingText"] as frmGreetingText;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmGreetingText.WindowState = FormWindowState.Normal;
				_frmGreetingText.MdiParent = this;
				_frmGreetingText.Show();
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MDIMedicalShop));
			this.menuStrip = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.createCompanyToolStripMenuItem = new ToolStripMenuItem();
			this.selectCompanyToolStripMenuItem = new ToolStripMenuItem();
			this.editCompanyToolStripMenuItem = new ToolStripMenuItem();
			this.deleteCompanyToolStripMenuItem = new ToolStripMenuItem();
			this.backupToolStripMenuItem = new ToolStripMenuItem();
			this.restoreToolStripMenuItem = new ToolStripMenuItem();
			this.logouttoolStripMenuItem = new ToolStripMenuItem();
			this.closeCompanyToolStripMenuItem = new ToolStripMenuItem();
			this.initialRecordsToolStripMenuItem = new ToolStripMenuItem();
			this.accountGroupToolStripMenuItem = new ToolStripMenuItem();
			this.accountLedgerToolStripMenuItem = new ToolStripMenuItem();
			this.shelfToolStripMenuItem = new ToolStripMenuItem();
			this.genericNameToolStripMenuItem = new ToolStripMenuItem();
			this.productGroupToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem3 = new ToolStripMenuItem();
			this.unitToolStripMenuItem = new ToolStripMenuItem();
			this.productToolStripMenuItem = new ToolStripMenuItem();
			this.manufacturerToolStripMenuItem = new ToolStripMenuItem();
			this.vendorToolStripMenuItem = new ToolStripMenuItem();
			this.salesManToolStripMenuItem = new ToolStripMenuItem();
			this.patientToolStripMenuItem = new ToolStripMenuItem();
			this.greetingToolStripMenuItem = new ToolStripMenuItem();
			this.transactToolStripMenuItem = new ToolStripMenuItem();
			this.purchaseToolStripMenuItem = new ToolStripMenuItem();
			this.purchaseReturnToolStripMenuItem = new ToolStripMenuItem();
			this.salesToolStripMenuItem = new ToolStripMenuItem();
			this.salesReturnToolStripMenuItem = new ToolStripMenuItem();
			this.counterSaleToolStripMenuItem = new ToolStripMenuItem();
			this.paymentVoucherToolStripMenuItem = new ToolStripMenuItem();
			this.receiptVoucherToolStripMenuItem = new ToolStripMenuItem();
			this.journalEntryToolStripMenuItem = new ToolStripMenuItem();
			this.inventoryToolStripMenuItem = new ToolStripMenuItem();
			this.stockEntryToolStripMenuItem = new ToolStripMenuItem();
			this.stockNewToolStripMenuItem = new ToolStripMenuItem();
			this.settingsToolStripMenuItem = new ToolStripMenuItem();
			this.finacialYearToolStripMenuItem = new ToolStripMenuItem();
			this.newFinancialYearToolStripMenuItem = new ToolStripMenuItem();
			this.editFinancialYearToolStripMenuItem = new ToolStripMenuItem();
			this.changeFinancialYearToolStripMenuItem = new ToolStripMenuItem();
			this.changeFinancialYearToolStripMenuItem1 = new ToolStripMenuItem();
			this.generalSettingsToolStripMenuItem = new ToolStripMenuItem();
			this.uSerToolStripMenuItem = new ToolStripMenuItem();
			this.createUserToolStripMenuItem = new ToolStripMenuItem();
			this.privilegeSettingsToolStripMenuItem = new ToolStripMenuItem();
			this.changePasswordToolStripMenuItem = new ToolStripMenuItem();
			this.registersToolStripMenuItem = new ToolStripMenuItem();
			this.paymentToolStripMenuItem = new ToolStripMenuItem();
			this.purchaseReturnToolStripMenuItem1 = new ToolStripMenuItem();
			this.salesToolStripMenuItem1 = new ToolStripMenuItem();
			this.counterSaleToolStripMenuItem1 = new ToolStripMenuItem();
			this.salesReturnToolStripMenuItem1 = new ToolStripMenuItem();
			this.paymentVoucherToolStripMenuItem1 = new ToolStripMenuItem();
			this.receiptVoucherToolStripMenuItem1 = new ToolStripMenuItem();
			this.journalEntryToolStripMenuItem1 = new ToolStripMenuItem();
			this.stockRegisterToolStripMenuItem = new ToolStripMenuItem();
			this.damageStockRegisterToolStripMenuItem = new ToolStripMenuItem();
			this.reminderToolStripMenuItem = new ToolStripMenuItem();
			this.productAvailabilitySearchToolStripMenuItem = new ToolStripMenuItem();
			this.draftMailToolStripMenuItem = new ToolStripMenuItem();
			this.calculatorToolStripMenuItem = new ToolStripMenuItem();
			this.addPrinterToolStripMenuItem = new ToolStripMenuItem();
			this.microsoftWordToolStripMenuItem = new ToolStripMenuItem();
			this.microsoftExcelToolStripMenuItem = new ToolStripMenuItem();
			this.telephoneDirectoryToolStripMenuItem = new ToolStripMenuItem();
			this.draftMailToolStripMenuItem1 = new ToolStripMenuItem();
			this.schedulerToolStripMenuItem1 = new ToolStripMenuItem();
			this.accountingStatementsToolStripMenuItem = new ToolStripMenuItem();
			this.cashBookToolStripMenuItem = new ToolStripMenuItem();
			this.bankBookToolStripMenuItem = new ToolStripMenuItem();
			this.daToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem2 = new ToolStripMenuItem();
			this.ledgerBalane = new ToolStripMenuItem();
			this.profitLossAnalysisToolStripMenuItem = new ToolStripMenuItem();
			this.balanceSheetToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem1 = new ToolStripMenuItem();
			this.initialRecords = new ToolStripMenuItem();
			this.accountGroupToolStripMenuItem2 = new ToolStripMenuItem();
			this.accountLedgerToolStripMenuItem2 = new ToolStripMenuItem();
			this.genericNameToolStripMenuItem2 = new ToolStripMenuItem();
			this.productGroupToolStripMenuItem2 = new ToolStripMenuItem();
			this.productBatchToolStripMenuItem1 = new ToolStripMenuItem();
			this.manufactureToolStripMenuItem = new ToolStripMenuItem();
			this.vendorToolStripMenuItem2 = new ToolStripMenuItem();
			this.salesManToolStripMenuItem1 = new ToolStripMenuItem();
			this.patientToolStripMenuItem1 = new ToolStripMenuItem();
			this.docotorToolStripMenuItem = new ToolStripMenuItem();
			this.userToolStripMenuItem2 = new ToolStripMenuItem();
			this.reminderToolStripMenuItem1 = new ToolStripMenuItem();
			this.Transaction = new ToolStripMenuItem();
			this.purchaseToolStripMenuItem2 = new ToolStripMenuItem();
			this.purchaseReturnToolStripMenuItem3 = new ToolStripMenuItem();
			this.salesToolStripMenuItem2 = new ToolStripMenuItem();
			this.salesReturnToolStripMenuItem2 = new ToolStripMenuItem();
			this.counterSaleToolStripMenuItem2 = new ToolStripMenuItem();
			this.instantSaleToolStripMenuItem = new ToolStripMenuItem();
			this.paymentToolStripMenuItem2 = new ToolStripMenuItem();
			this.receiptToolStripMenuItem1 = new ToolStripMenuItem();
			this.journalToolStripMenuItem1 = new ToolStripMenuItem();
			this.Inventory = new ToolStripMenuItem();
			this.stockToolStripMenuItem = new ToolStripMenuItem();
			this.damageStockToolStripMenuItem1 = new ToolStripMenuItem();
			this.productToolStripMenuItem1 = new ToolStripMenuItem();
			this.stockAndSaleToolStripMenuItem = new ToolStripMenuItem();
			this.shortExpiryToolStripMenuItem = new ToolStripMenuItem();
			this.stockAtMinimumLevelToolStripMenuItem = new ToolStripMenuItem();
			this.productStatisticsToolStripMenuItem = new ToolStripMenuItem();
			this.taxReportToolStripMenuItem = new ToolStripMenuItem();
			this.priceListToolStripMenuItem = new ToolStripMenuItem();
            this.DailyExpenseToolStripMenuItem = new ToolStripMenuItem();
            this.AdvancedReportsToolStripMenuItem = new ToolStripMenuItem();
            
            this.StockandPriceToolStripMenuItem = new ToolStripMenuItem();
            this.MostRunningProductsToolStripMenuItem = new ToolStripMenuItem();
            this.MostPurchaseProductsToolStripMenuItem = new ToolStripMenuItem();
            this.MonthlyExpenseToolStripMenuItem = new ToolStripMenuItem();
            this.help = new ToolStripMenuItem();
			this.contentsToolStripMenuItem = new ToolStripMenuItem();
			this.aboutToolStripMenuItem = new ToolStripMenuItem();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.saveBackupDialog = new SaveFileDialog();
			this.toolStripStatusLabel = new ToolStripStatusLabel();
			this.statusStrip = new StatusStrip();
			this.btnReminder = new ToolStripStatusLabel();
			this.timMov = new Timer(this.components);
			this.timMovOut = new Timer(this.components);
			this.timer1 = new Timer(this.components);
			this.pReminder = new Panel();
			this.btnClose = new PictureBox();
			this.lblExpiry = new Label();
			this.lblLowStock = new Label();
			this.lblReminder = new Label();
			this.pictureBox1 = new PictureBox();
			this.panel6 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.pReminder.SuspendLayout();
			((ISupportInitialize)this.btnClose).BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			ToolStripItemCollection items = this.menuStrip.Items;
			ToolStripItem[] transaction = new ToolStripItem[] { this.fileToolStripMenuItem, this.initialRecordsToolStripMenuItem, this.transactToolStripMenuItem, this.inventoryToolStripMenuItem, this.settingsToolStripMenuItem, this.registersToolStripMenuItem, this.reminderToolStripMenuItem, this.productAvailabilitySearchToolStripMenuItem, this.draftMailToolStripMenuItem, this.accountingStatementsToolStripMenuItem, this.toolStripMenuItem1, this.help, this.exitToolStripMenuItem };
			items.AddRange(transaction);
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1016, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			ToolStripItemCollection dropDownItems = this.fileToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.createCompanyToolStripMenuItem, this.selectCompanyToolStripMenuItem, this.editCompanyToolStripMenuItem, this.deleteCompanyToolStripMenuItem, this.backupToolStripMenuItem, this.restoreToolStripMenuItem, this.logouttoolStripMenuItem, this.closeCompanyToolStripMenuItem };
			dropDownItems.AddRange(transaction);
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.fileToolStripMenuItem.Text = "Company";
			this.createCompanyToolStripMenuItem.Enabled = true;
			this.createCompanyToolStripMenuItem.Name = "createCompanyToolStripMenuItem";
			this.createCompanyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.createCompanyToolStripMenuItem.Text = "Create Company";
			this.createCompanyToolStripMenuItem.Click += new EventHandler(this.createCompanyToolStripMenuItem_Click);
			this.selectCompanyToolStripMenuItem.Enabled = true;
			this.selectCompanyToolStripMenuItem.Name = "selectCompanyToolStripMenuItem";
			this.selectCompanyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.selectCompanyToolStripMenuItem.Text = "Select Company";
            this.selectCompanyToolStripMenuItem.Click += new EventHandler(this.selectCompanyToolStripMenuItem_Click);
            this.editCompanyToolStripMenuItem.Name = "editCompanyToolStripMenuItem";
			this.editCompanyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.editCompanyToolStripMenuItem.Text = "Edit Company";
			this.editCompanyToolStripMenuItem.Click += new EventHandler(this.editCompanyToolStripMenuItem_Click);
			this.deleteCompanyToolStripMenuItem.Name = "deleteCompanyToolStripMenuItem";
			this.deleteCompanyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.deleteCompanyToolStripMenuItem.Text = "Delete Company";
			this.deleteCompanyToolStripMenuItem.Click += new EventHandler(this.deleteCompanyToolStripMenuItem_Click);
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.backupToolStripMenuItem.Text = "Backup  ";
			this.backupToolStripMenuItem.Click += new EventHandler(this.backupToolStripMenuItem_Click);
			this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
			this.restoreToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.restoreToolStripMenuItem.Text = "Restore";
			this.restoreToolStripMenuItem.Click += new EventHandler(this.restoreToolStripMenuItem_Click);
			this.logouttoolStripMenuItem.Enabled = true;
			this.logouttoolStripMenuItem.Name = "logouttoolStripMenuItem";
			this.logouttoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.logouttoolStripMenuItem.Text = "Logout";
			this.logouttoolStripMenuItem.Click += new EventHandler(this.logouttoolStripMenuItem_Click);
			this.closeCompanyToolStripMenuItem.Enabled = true;
			this.closeCompanyToolStripMenuItem.Name = "closeCompanyToolStripMenuItem";
			this.closeCompanyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.closeCompanyToolStripMenuItem.Text = "Close Company";
			this.closeCompanyToolStripMenuItem.Click += new EventHandler(this.closeCompanyToolStripMenuItem_Click);
			ToolStripItemCollection toolStripItemCollections = this.initialRecordsToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.accountGroupToolStripMenuItem, this.accountLedgerToolStripMenuItem, this.shelfToolStripMenuItem, this.genericNameToolStripMenuItem, this.productGroupToolStripMenuItem, this.toolStripMenuItem3, this.unitToolStripMenuItem, this.productToolStripMenuItem, this.manufacturerToolStripMenuItem, this.vendorToolStripMenuItem, this.salesManToolStripMenuItem, this.patientToolStripMenuItem, this.greetingToolStripMenuItem };
			toolStripItemCollections.AddRange(transaction);
			this.initialRecordsToolStripMenuItem.Name = "initialRecordsToolStripMenuItem";
			this.initialRecordsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
			this.initialRecordsToolStripMenuItem.Text = "Initial Records";
			this.accountGroupToolStripMenuItem.Name = "accountGroupToolStripMenuItem";
			this.accountGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.accountGroupToolStripMenuItem.Text = "Account Group";
			this.accountGroupToolStripMenuItem.Click += new EventHandler(this.accountGroupToolStripMenuItem_Click);
			this.accountLedgerToolStripMenuItem.Name = "accountLedgerToolStripMenuItem";
			this.accountLedgerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.accountLedgerToolStripMenuItem.Text = "Account Ledger";
			this.accountLedgerToolStripMenuItem.Click += new EventHandler(this.accountLedgerToolStripMenuItem_Click);
			this.shelfToolStripMenuItem.Name = "shelfToolStripMenuItem";
			this.shelfToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.shelfToolStripMenuItem.Text = "Shelf";
			this.shelfToolStripMenuItem.Click += new EventHandler(this.shelfToolStripMenuItem_Click);
			this.genericNameToolStripMenuItem.Name = "genericNameToolStripMenuItem";
			this.genericNameToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.genericNameToolStripMenuItem.Text = "Generic Name";
			this.genericNameToolStripMenuItem.Click += new EventHandler(this.genericNameToolStripMenuItem_Click);
			this.productGroupToolStripMenuItem.Name = "productGroupToolStripMenuItem";
			this.productGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.productGroupToolStripMenuItem.Text = "Product Group";
			this.productGroupToolStripMenuItem.Click += new EventHandler(this.productGroupToolStripMenuItem_Click);
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem3.Text = "Product Batch";
			this.toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem3_Click);
			this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
			this.unitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.unitToolStripMenuItem.Text = "Unit";
			this.unitToolStripMenuItem.Click += new EventHandler(this.unitToolStripMenuItem_Click);
			this.productToolStripMenuItem.Name = "productToolStripMenuItem";
			this.productToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.productToolStripMenuItem.Text = "Product";
			this.productToolStripMenuItem.Click += new EventHandler(this.productToolStripMenuItem_Click);
			this.manufacturerToolStripMenuItem.Name = "manufacturerToolStripMenuItem";
			this.manufacturerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.manufacturerToolStripMenuItem.Text = "Manufacture";
			this.manufacturerToolStripMenuItem.Click += new EventHandler(this.manufacturerToolStripMenuItem_Click);
			this.vendorToolStripMenuItem.Name = "vendorToolStripMenuItem";
			this.vendorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.vendorToolStripMenuItem.Text = "Vendor";
			this.vendorToolStripMenuItem.Click += new EventHandler(this.vendorToolStripMenuItem_Click);
			this.salesManToolStripMenuItem.Name = "salesManToolStripMenuItem";
			this.salesManToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.salesManToolStripMenuItem.Text = "Sales Man";
			this.salesManToolStripMenuItem.Click += new EventHandler(this.salesManToolStripMenuItem_Click);
			this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
			this.patientToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.patientToolStripMenuItem.Text = "Daily Customer";
			this.patientToolStripMenuItem.Click += new EventHandler(this.patientToolStripMenuItem_Click);
			this.greetingToolStripMenuItem.Name = "greetingToolStripMenuItem";
			this.greetingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.greetingToolStripMenuItem.Text = "Greeting Text";
			this.greetingToolStripMenuItem.Click += new EventHandler(this.greetingToolStripMenuItem_Click);
			ToolStripItemCollection dropDownItems1 = this.transactToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.purchaseToolStripMenuItem, this.purchaseReturnToolStripMenuItem, this.salesToolStripMenuItem, this.salesReturnToolStripMenuItem, this.counterSaleToolStripMenuItem, this.paymentVoucherToolStripMenuItem, this.receiptVoucherToolStripMenuItem, this.journalEntryToolStripMenuItem };
			dropDownItems1.AddRange(transaction);
			this.transactToolStripMenuItem.Name = "transactToolStripMenuItem";
			this.transactToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.transactToolStripMenuItem.Text = "Transactions";
			this.transactToolStripMenuItem.Click += new EventHandler(this.transactToolStripMenuItem_Click);
			this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
			this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.purchaseToolStripMenuItem.Text = "Purchase";
			this.purchaseToolStripMenuItem.Click += new EventHandler(this.purchaseToolStripMenuItem_Click);
			this.purchaseReturnToolStripMenuItem.Name = "purchaseReturnToolStripMenuItem";
			this.purchaseReturnToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.purchaseReturnToolStripMenuItem.Text = "Purchase Return";
			this.purchaseReturnToolStripMenuItem.Click += new EventHandler(this.purchaseReturnToolStripMenuItem_Click_1);
			this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
			this.salesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.salesToolStripMenuItem.Text = "Sales";
			this.salesToolStripMenuItem.Click += new EventHandler(this.salesToolStripMenuItem_Click);
			this.salesReturnToolStripMenuItem.Name = "salesReturnToolStripMenuItem";
			this.salesReturnToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.salesReturnToolStripMenuItem.Text = "Sales Return";
			this.salesReturnToolStripMenuItem.Click += new EventHandler(this.salesReturnToolStripMenuItem_Click);
			this.counterSaleToolStripMenuItem.Name = "counterSaleToolStripMenuItem";
			this.counterSaleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.counterSaleToolStripMenuItem.Text = "Counter Sale";
			this.counterSaleToolStripMenuItem.Click += new EventHandler(this.counterSaleToolStripMenuItem_Click);
			this.paymentVoucherToolStripMenuItem.Name = "paymentVoucherToolStripMenuItem";
			this.paymentVoucherToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.paymentVoucherToolStripMenuItem.Text = "Payment Voucher";
			this.paymentVoucherToolStripMenuItem.Click += new EventHandler(this.paymentVoucherToolStripMenuItem_Click);
			this.receiptVoucherToolStripMenuItem.Name = "receiptVoucherToolStripMenuItem";
			this.receiptVoucherToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.receiptVoucherToolStripMenuItem.Text = "Receipt Voucher";
			this.receiptVoucherToolStripMenuItem.Click += new EventHandler(this.receiptVoucherToolStripMenuItem_Click);
			this.journalEntryToolStripMenuItem.Name = "journalEntryToolStripMenuItem";
			this.journalEntryToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.journalEntryToolStripMenuItem.Text = "Journal Entry";
			this.journalEntryToolStripMenuItem.Click += new EventHandler(this.journalEntryToolStripMenuItem_Click);
			ToolStripItemCollection toolStripItemCollections1 = this.inventoryToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.stockEntryToolStripMenuItem, this.stockNewToolStripMenuItem };
			toolStripItemCollections1.AddRange(transaction);
			this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
			this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.inventoryToolStripMenuItem.Text = "Inventory";
			this.stockEntryToolStripMenuItem.Name = "stockEntryToolStripMenuItem";
			this.stockEntryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.stockEntryToolStripMenuItem.Text = "Stock Entry";
			this.stockEntryToolStripMenuItem.Click += new EventHandler(this.stockEntryToolStripMenuItem_Click);
			this.stockNewToolStripMenuItem.Name = "stockNewToolStripMenuItem";
			this.stockNewToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.stockNewToolStripMenuItem.Text = "Damage Stock";
			this.stockNewToolStripMenuItem.Click += new EventHandler(this.stockNewToolStripMenuItem_Click);
			ToolStripItemCollection dropDownItems2 = this.settingsToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.finacialYearToolStripMenuItem, this.generalSettingsToolStripMenuItem, this.uSerToolStripMenuItem, this.changePasswordToolStripMenuItem };
			dropDownItems2.AddRange(transaction);
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			ToolStripItemCollection toolStripItemCollections2 = this.finacialYearToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.newFinancialYearToolStripMenuItem, this.editFinancialYearToolStripMenuItem, this.changeFinancialYearToolStripMenuItem, this.changeFinancialYearToolStripMenuItem1 };
			toolStripItemCollections2.AddRange(transaction);
			this.finacialYearToolStripMenuItem.Name = "finacialYearToolStripMenuItem";
			this.finacialYearToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.finacialYearToolStripMenuItem.Text = "Finacial Year";
			this.newFinancialYearToolStripMenuItem.Name = "newFinancialYearToolStripMenuItem";
			this.newFinancialYearToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.newFinancialYearToolStripMenuItem.Text = "New Financial Year";
			this.newFinancialYearToolStripMenuItem.Click += new EventHandler(this.newFinancialYearToolStripMenuItem_Click);
			this.editFinancialYearToolStripMenuItem.Name = "editFinancialYearToolStripMenuItem";
			this.editFinancialYearToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.editFinancialYearToolStripMenuItem.Text = "Edit Financial Year";
			this.editFinancialYearToolStripMenuItem.Click += new EventHandler(this.editFinancialYearToolStripMenuItem_Click);
			this.changeFinancialYearToolStripMenuItem.Name = "changeFinancialYearToolStripMenuItem";
			this.changeFinancialYearToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.changeFinancialYearToolStripMenuItem.Text = "Change Financial Year";
			this.changeFinancialYearToolStripMenuItem.Click += new EventHandler(this.changeFinancialYearToolStripMenuItem_Click);
			this.changeFinancialYearToolStripMenuItem1.Name = "changeFinancialYearToolStripMenuItem1";
			this.changeFinancialYearToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
			this.changeFinancialYearToolStripMenuItem1.Text = "Close Financial Year";
			this.changeFinancialYearToolStripMenuItem1.Click += new EventHandler(this.changeFinancialYearToolStripMenuItem1_Click);
			this.generalSettingsToolStripMenuItem.Name = "generalSettingsToolStripMenuItem";
			this.generalSettingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.generalSettingsToolStripMenuItem.Text = "General Settings";
			this.generalSettingsToolStripMenuItem.Click += new EventHandler(this.generalSettingsToolStripMenuItem_Click);
			ToolStripItemCollection dropDownItems3 = this.uSerToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.createUserToolStripMenuItem, this.privilegeSettingsToolStripMenuItem };
			dropDownItems3.AddRange(transaction);
			this.uSerToolStripMenuItem.Name = "uSerToolStripMenuItem";
			this.uSerToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.uSerToolStripMenuItem.Text = "User";
			this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
			this.createUserToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.createUserToolStripMenuItem.Text = "Create User";
			this.createUserToolStripMenuItem.Click += new EventHandler(this.createUserToolStripMenuItem_Click);
			this.privilegeSettingsToolStripMenuItem.Enabled = false;
			this.privilegeSettingsToolStripMenuItem.Name = "privilegeSettingsToolStripMenuItem";
			this.privilegeSettingsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.privilegeSettingsToolStripMenuItem.Text = "Privilege Settings";
			this.changePasswordToolStripMenuItem.Enabled = false;
			this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
			this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.changePasswordToolStripMenuItem.Text = "Change Password";
			ToolStripItemCollection toolStripItemCollections3 = this.registersToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.paymentToolStripMenuItem, this.purchaseReturnToolStripMenuItem1, this.salesToolStripMenuItem1, this.counterSaleToolStripMenuItem1, this.salesReturnToolStripMenuItem1, this.paymentVoucherToolStripMenuItem1, this.receiptVoucherToolStripMenuItem1, this.journalEntryToolStripMenuItem1, this.stockRegisterToolStripMenuItem, this.damageStockRegisterToolStripMenuItem };
			toolStripItemCollections3.AddRange(transaction);
			this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
			this.registersToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.registersToolStripMenuItem.Text = "Registers";
			this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
			this.paymentToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.paymentToolStripMenuItem.Text = "Purchase";
			this.paymentToolStripMenuItem.Click += new EventHandler(this.paymentToolStripMenuItem_Click_1);
			this.purchaseReturnToolStripMenuItem1.Name = "purchaseReturnToolStripMenuItem1";
			this.purchaseReturnToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.purchaseReturnToolStripMenuItem1.Text = "Purchase Return";
			this.purchaseReturnToolStripMenuItem1.Click += new EventHandler(this.purchaseReturnToolStripMenuItem1_Click);
			this.salesToolStripMenuItem1.Name = "salesToolStripMenuItem1";
			this.salesToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.salesToolStripMenuItem1.Text = "Sales";
			this.salesToolStripMenuItem1.Click += new EventHandler(this.salesToolStripMenuItem1_Click);
			this.counterSaleToolStripMenuItem1.Name = "counterSaleToolStripMenuItem1";
			this.counterSaleToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.counterSaleToolStripMenuItem1.Text = "Counter Sale";
			this.counterSaleToolStripMenuItem1.Click += new EventHandler(this.counterSaleToolStripMenuItem1_Click);
			this.salesReturnToolStripMenuItem1.Name = "salesReturnToolStripMenuItem1";
			this.salesReturnToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.salesReturnToolStripMenuItem1.Text = "Sales Return";
			this.salesReturnToolStripMenuItem1.Click += new EventHandler(this.salesReturnToolStripMenuItem1_Click);
			this.paymentVoucherToolStripMenuItem1.Name = "paymentVoucherToolStripMenuItem1";
			this.paymentVoucherToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.paymentVoucherToolStripMenuItem1.Text = "Payment";
			this.paymentVoucherToolStripMenuItem1.Click += new EventHandler(this.paymentVoucherToolStripMenuItem1_Click);
			this.receiptVoucherToolStripMenuItem1.Name = "receiptVoucherToolStripMenuItem1";
			this.receiptVoucherToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.receiptVoucherToolStripMenuItem1.Text = "Receipt";
			this.receiptVoucherToolStripMenuItem1.Click += new EventHandler(this.receiptVoucherToolStripMenuItem1_Click);
			this.journalEntryToolStripMenuItem1.Name = "journalEntryToolStripMenuItem1";
			this.journalEntryToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.journalEntryToolStripMenuItem1.Text = "Journal Entry";
			this.journalEntryToolStripMenuItem1.Click += new EventHandler(this.journalEntryToolStripMenuItem1_Click);
			this.stockRegisterToolStripMenuItem.Name = "stockRegisterToolStripMenuItem";
			this.stockRegisterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.stockRegisterToolStripMenuItem.Text = "Stock";
			this.stockRegisterToolStripMenuItem.Click += new EventHandler(this.stockRegisterToolStripMenuItem_Click);
			this.damageStockRegisterToolStripMenuItem.Name = "damageStockRegisterToolStripMenuItem";
			this.damageStockRegisterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.damageStockRegisterToolStripMenuItem.Text = "Damage Stock";
			this.damageStockRegisterToolStripMenuItem.Click += new EventHandler(this.damageStockRegisterToolStripMenuItem_Click);
			this.reminderToolStripMenuItem.Name = "reminderToolStripMenuItem";
			this.reminderToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
			this.reminderToolStripMenuItem.Text = "Reminders";
			this.reminderToolStripMenuItem.Click += new EventHandler(this.reminderToolStripMenuItem_Click);
			this.productAvailabilitySearchToolStripMenuItem.Name = "productAvailabilitySearchToolStripMenuItem";
			this.productAvailabilitySearchToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
			this.productAvailabilitySearchToolStripMenuItem.Text = "Product Availability Search";
			this.productAvailabilitySearchToolStripMenuItem.Click += new EventHandler(this.productAvailabilitySearchToolStripMenuItem_Click);
			ToolStripItemCollection dropDownItems4 = this.draftMailToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.calculatorToolStripMenuItem, this.addPrinterToolStripMenuItem, this.microsoftWordToolStripMenuItem, this.microsoftExcelToolStripMenuItem, this.telephoneDirectoryToolStripMenuItem, this.draftMailToolStripMenuItem1, this.schedulerToolStripMenuItem1 };
			dropDownItems4.AddRange(transaction);
			this.draftMailToolStripMenuItem.Name = "draftMailToolStripMenuItem";
			this.draftMailToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.draftMailToolStripMenuItem.Text = "Utilities";
			this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
			this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.calculatorToolStripMenuItem.Text = "Calculator";
			this.calculatorToolStripMenuItem.Click += new EventHandler(this.calculatorToolStripMenuItem_Click);
			this.addPrinterToolStripMenuItem.Name = "addPrinterToolStripMenuItem";
			this.addPrinterToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.addPrinterToolStripMenuItem.Text = "Add Printer";
			this.addPrinterToolStripMenuItem.Click += new EventHandler(this.addPrinterToolStripMenuItem_Click_1);
			this.microsoftWordToolStripMenuItem.Name = "microsoftWordToolStripMenuItem";
			this.microsoftWordToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.microsoftWordToolStripMenuItem.Text = "Microsoft Word";
			this.microsoftWordToolStripMenuItem.Click += new EventHandler(this.microsoftWordToolStripMenuItem_Click);
			this.microsoftExcelToolStripMenuItem.Name = "microsoftExcelToolStripMenuItem";
			this.microsoftExcelToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.microsoftExcelToolStripMenuItem.Text = "Microsoft Excel";
			this.microsoftExcelToolStripMenuItem.Click += new EventHandler(this.microsoftExcelToolStripMenuItem_Click);
			this.telephoneDirectoryToolStripMenuItem.Name = "telephoneDirectoryToolStripMenuItem";
			this.telephoneDirectoryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.telephoneDirectoryToolStripMenuItem.Text = "Telephone Directory";
			this.telephoneDirectoryToolStripMenuItem.Click += new EventHandler(this.telephoneDirectoryToolStripMenuItem_Click);
			this.draftMailToolStripMenuItem1.Name = "draftMailToolStripMenuItem1";
			this.draftMailToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.draftMailToolStripMenuItem1.Text = "Draft Mail";
			this.draftMailToolStripMenuItem1.Click += new EventHandler(this.draftMailToolStripMenuItem1_Click);
			this.schedulerToolStripMenuItem1.Name = "schedulerToolStripMenuItem1";
			this.schedulerToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.schedulerToolStripMenuItem1.Text = "Scheduler";
			this.schedulerToolStripMenuItem1.Click += new EventHandler(this.schedulerToolStripMenuItem1_Click);
			ToolStripItemCollection toolStripItemCollections4 = this.accountingStatementsToolStripMenuItem.DropDownItems;
			transaction = new ToolStripItem[] { this.cashBookToolStripMenuItem, this.bankBookToolStripMenuItem, this.daToolStripMenuItem, this.toolStripMenuItem2, this.ledgerBalane, this.profitLossAnalysisToolStripMenuItem, this.balanceSheetToolStripMenuItem };
			toolStripItemCollections4.AddRange(transaction);
			this.accountingStatementsToolStripMenuItem.Name = "accountingStatementsToolStripMenuItem";
			this.accountingStatementsToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
			this.accountingStatementsToolStripMenuItem.Text = "Accounting Statements";
			this.cashBookToolStripMenuItem.Name = "cashBookToolStripMenuItem";
			this.cashBookToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.cashBookToolStripMenuItem.Text = "Cash Book";
			this.cashBookToolStripMenuItem.Click += new EventHandler(this.cashBookToolStripMenuItem_Click);
			this.bankBookToolStripMenuItem.Name = "bankBookToolStripMenuItem";
			this.bankBookToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.bankBookToolStripMenuItem.Text = "Bank Book";
			this.bankBookToolStripMenuItem.Click += new EventHandler(this.bankBookToolStripMenuItem_Click);
			this.daToolStripMenuItem.Name = "daToolStripMenuItem";
			this.daToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.daToolStripMenuItem.Text = "Day Book";
			this.daToolStripMenuItem.Click += new EventHandler(this.daToolStripMenuItem_Click);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 22);
			this.toolStripMenuItem2.Text = "Trial Balance";
			this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
			this.ledgerBalane.Name = "ledgerBalane";
			this.ledgerBalane.Size = new System.Drawing.Size(199, 22);
			this.ledgerBalane.Text = "Ledger Balance";
			this.ledgerBalane.Click += new EventHandler(this.ledgerBalane_Click);
			this.profitLossAnalysisToolStripMenuItem.Name = "profitLossAnalysisToolStripMenuItem";
			this.profitLossAnalysisToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.profitLossAnalysisToolStripMenuItem.Text = "Profit And Loss Analysis";
			this.profitLossAnalysisToolStripMenuItem.Click += new EventHandler(this.profitLossAnalysisToolStripMenuItem_Click_1);
			this.balanceSheetToolStripMenuItem.Name = "balanceSheetToolStripMenuItem";
			this.balanceSheetToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.balanceSheetToolStripMenuItem.Text = "Balance Sheet";
			this.balanceSheetToolStripMenuItem.Click += new EventHandler(this.balanceSheetToolStripMenuItem_Click);
			ToolStripItemCollection dropDownItems5 = this.toolStripMenuItem1.DropDownItems;
			transaction = new ToolStripItem[] { this.initialRecords, this.reminderToolStripMenuItem1, this.Transaction, this.Inventory, this.productToolStripMenuItem1, this.stockAndSaleToolStripMenuItem, this.shortExpiryToolStripMenuItem, this.stockAtMinimumLevelToolStripMenuItem, this.productStatisticsToolStripMenuItem, this.taxReportToolStripMenuItem, this.priceListToolStripMenuItem , this.DailyExpenseToolStripMenuItem, this.AdvancedReportsToolStripMenuItem,this.MonthlyExpenseToolStripMenuItem ,this.StockandPriceToolStripMenuItem,this.MostRunningProductsToolStripMenuItem ,this.MostPurchaseProductsToolStripMenuItem};
			dropDownItems5.AddRange(transaction);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem1.Text = "Reports";
			ToolStripItemCollection toolStripItemCollections5 = this.initialRecords.DropDownItems;
			transaction = new ToolStripItem[] { this.accountGroupToolStripMenuItem2, this.accountLedgerToolStripMenuItem2, this.genericNameToolStripMenuItem2, this.productGroupToolStripMenuItem2, this.productBatchToolStripMenuItem1, this.manufactureToolStripMenuItem, this.vendorToolStripMenuItem2, this.salesManToolStripMenuItem1, this.patientToolStripMenuItem1, this.docotorToolStripMenuItem, this.userToolStripMenuItem2 };
			toolStripItemCollections5.AddRange(transaction);
			this.initialRecords.Name = "initialRecords";
			this.initialRecords.Size = new System.Drawing.Size(196, 22);
			this.initialRecords.Text = "Initial Records";
			this.accountGroupToolStripMenuItem2.Name = "accountGroupToolStripMenuItem2";
			this.accountGroupToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.accountGroupToolStripMenuItem2.Text = "Account Group";
			this.accountGroupToolStripMenuItem2.Click += new EventHandler(this.accountGroupToolStripMenuItem2_Click);
			this.accountLedgerToolStripMenuItem2.Name = "accountLedgerToolStripMenuItem2";
			this.accountLedgerToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.accountLedgerToolStripMenuItem2.Text = "Account Ledger";
			this.accountLedgerToolStripMenuItem2.Click += new EventHandler(this.accountLedgerToolStripMenuItem2_Click);
			this.genericNameToolStripMenuItem2.Name = "genericNameToolStripMenuItem2";
			this.genericNameToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.genericNameToolStripMenuItem2.Text = "Generic Name";
			this.genericNameToolStripMenuItem2.Click += new EventHandler(this.genericNameToolStripMenuItem2_Click);
			this.productGroupToolStripMenuItem2.Name = "productGroupToolStripMenuItem2";
			this.productGroupToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.productGroupToolStripMenuItem2.Text = "Product Group";
			this.productGroupToolStripMenuItem2.Click += new EventHandler(this.productGroupToolStripMenuItem2_Click);
			this.productBatchToolStripMenuItem1.Name = "productBatchToolStripMenuItem1";
			this.productBatchToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.productBatchToolStripMenuItem1.Text = "Product Batch";
			this.productBatchToolStripMenuItem1.Click += new EventHandler(this.productBatchToolStripMenuItem1_Click);
			this.manufactureToolStripMenuItem.Name = "manufactureToolStripMenuItem";
			this.manufactureToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.manufactureToolStripMenuItem.Text = "Manufacture";
			this.manufactureToolStripMenuItem.Click += new EventHandler(this.manufactureToolStripMenuItem_Click);
			this.vendorToolStripMenuItem2.Name = "vendorToolStripMenuItem2";
			this.vendorToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.vendorToolStripMenuItem2.Text = "Vendor";
			this.vendorToolStripMenuItem2.Click += new EventHandler(this.vendorToolStripMenuItem2_Click);
			this.salesManToolStripMenuItem1.Name = "salesManToolStripMenuItem1";
			this.salesManToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.salesManToolStripMenuItem1.Text = "Sales Man";
			this.salesManToolStripMenuItem1.Click += new EventHandler(this.salesManToolStripMenuItem1_Click);
			this.patientToolStripMenuItem1.Name = "patientToolStripMenuItem1";
			this.patientToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.patientToolStripMenuItem1.Text = "Daily Customer";
			this.patientToolStripMenuItem1.Click += new EventHandler(this.patientToolStripMenuItem1_Click);
			this.docotorToolStripMenuItem.Name = "docotorToolStripMenuItem";
			this.docotorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.docotorToolStripMenuItem.Text = "Doctor";
			this.docotorToolStripMenuItem.Click += new EventHandler(this.docotorToolStripMenuItem_Click);
			this.userToolStripMenuItem2.Name = "userToolStripMenuItem2";
			this.userToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.userToolStripMenuItem2.Text = "User";
			this.userToolStripMenuItem2.Click += new EventHandler(this.userToolStripMenuItem2_Click);
			this.reminderToolStripMenuItem1.Name = "reminderToolStripMenuItem1";
			this.reminderToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
			this.reminderToolStripMenuItem1.Text = "Reminder";
			this.reminderToolStripMenuItem1.Click += new EventHandler(this.reminderToolStripMenuItem1_Click);
			ToolStripItemCollection dropDownItems6 = this.Transaction.DropDownItems;
			transaction = new ToolStripItem[] { this.purchaseToolStripMenuItem2, this.purchaseReturnToolStripMenuItem3, this.salesToolStripMenuItem2, this.salesReturnToolStripMenuItem2, this.counterSaleToolStripMenuItem2, this.instantSaleToolStripMenuItem, this.paymentToolStripMenuItem2, this.receiptToolStripMenuItem1, this.journalToolStripMenuItem1 };
			dropDownItems6.AddRange(transaction);
			this.Transaction.Name = "Transaction";
			this.Transaction.Size = new System.Drawing.Size(196, 22);
			this.Transaction.Text = "Transaction";
			this.purchaseToolStripMenuItem2.Name = "purchaseToolStripMenuItem2";
			this.purchaseToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
			this.purchaseToolStripMenuItem2.Text = "Purchase";
			this.purchaseToolStripMenuItem2.Click += new EventHandler(this.purchaseToolStripMenuItem2_Click);
			this.purchaseReturnToolStripMenuItem3.Name = "purchaseReturnToolStripMenuItem3";
			this.purchaseReturnToolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
			this.purchaseReturnToolStripMenuItem3.Text = "Purchase Return";
			this.purchaseReturnToolStripMenuItem3.Click += new EventHandler(this.purchaseReturnToolStripMenuItem3_Click);
			this.salesToolStripMenuItem2.Name = "salesToolStripMenuItem2";
			this.salesToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
			this.salesToolStripMenuItem2.Text = "Sales";
			this.salesToolStripMenuItem2.Click += new EventHandler(this.salesToolStripMenuItem2_Click);
			this.salesReturnToolStripMenuItem2.Name = "salesReturnToolStripMenuItem2";
			this.salesReturnToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
			this.salesReturnToolStripMenuItem2.Text = "Sales Return";
			this.salesReturnToolStripMenuItem2.Click += new EventHandler(this.salesReturnToolStripMenuItem2_Click);
			this.counterSaleToolStripMenuItem2.Name = "counterSaleToolStripMenuItem2";
			this.counterSaleToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
			this.counterSaleToolStripMenuItem2.Text = "Counter Sale";
			this.counterSaleToolStripMenuItem2.Click += new EventHandler(this.counterSaleToolStripMenuItem2_Click);
			this.instantSaleToolStripMenuItem.Name = "instantSaleToolStripMenuItem";
			this.instantSaleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.instantSaleToolStripMenuItem.Text = "Instant Sale";
			this.instantSaleToolStripMenuItem.Click += new EventHandler(this.instantSaleToolStripMenuItem_Click);
			this.paymentToolStripMenuItem2.Name = "paymentToolStripMenuItem2";
			this.paymentToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
			this.paymentToolStripMenuItem2.Text = "Payment";
			this.paymentToolStripMenuItem2.Click += new EventHandler(this.paymentToolStripMenuItem2_Click);
			this.receiptToolStripMenuItem1.Name = "receiptToolStripMenuItem1";
			this.receiptToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.receiptToolStripMenuItem1.Text = "Receipt";
			this.receiptToolStripMenuItem1.Click += new EventHandler(this.receiptToolStripMenuItem1_Click);
			this.journalToolStripMenuItem1.Name = "journalToolStripMenuItem1";
			this.journalToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.journalToolStripMenuItem1.Text = "Journal";
			this.journalToolStripMenuItem1.Click += new EventHandler(this.journalToolStripMenuItem1_Click);
			ToolStripItemCollection toolStripItemCollections6 = this.Inventory.DropDownItems;
			transaction = new ToolStripItem[] { this.stockToolStripMenuItem, this.damageStockToolStripMenuItem1 };
			toolStripItemCollections6.AddRange(transaction);
			this.Inventory.Name = "Inventory";
			this.Inventory.Size = new System.Drawing.Size(196, 22);
			this.Inventory.Text = "Inventory";
			this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
			this.stockToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.stockToolStripMenuItem.Text = "Stock Entry";
			this.stockToolStripMenuItem.Click += new EventHandler(this.stockToolStripMenuItem_Click);
			this.damageStockToolStripMenuItem1.Name = "damageStockToolStripMenuItem1";
			this.damageStockToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
			this.damageStockToolStripMenuItem1.Text = "Damage Stock";
			this.damageStockToolStripMenuItem1.Click += new EventHandler(this.damageStockToolStripMenuItem1_Click);
			this.productToolStripMenuItem1.Name = "productToolStripMenuItem1";
			this.productToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
			this.productToolStripMenuItem1.Text = "Stock";
			this.productToolStripMenuItem1.Click += new EventHandler(this.productToolStripMenuItem1_Click);
			this.stockAndSaleToolStripMenuItem.Name = "stockAndSaleToolStripMenuItem";
			this.stockAndSaleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.stockAndSaleToolStripMenuItem.Text = "Stock And Sale";
			this.stockAndSaleToolStripMenuItem.Click += new EventHandler(this.stockAndSaleToolStripMenuItem_Click);
			this.shortExpiryToolStripMenuItem.Name = "shortExpiryToolStripMenuItem";
			this.shortExpiryToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.shortExpiryToolStripMenuItem.Text = "Short Expiry ";
			this.shortExpiryToolStripMenuItem.Click += new EventHandler(this.shortExpiryToolStripMenuItem_Click);
			this.stockAtMinimumLevelToolStripMenuItem.Name = "stockAtMinimumLevelToolStripMenuItem";
			this.stockAtMinimumLevelToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.stockAtMinimumLevelToolStripMenuItem.Text = "Stock At Minimum Level";
			this.stockAtMinimumLevelToolStripMenuItem.Click += new EventHandler(this.stockAtMinimumLevelToolStripMenuItem_Click);
			this.productStatisticsToolStripMenuItem.Name = "productStatisticsToolStripMenuItem";
			this.productStatisticsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.productStatisticsToolStripMenuItem.Text = "Product Statistics";
			this.productStatisticsToolStripMenuItem.Click += new EventHandler(this.productStatisticsToolStripMenuItem_Click);
			this.taxReportToolStripMenuItem.Name = "taxReportToolStripMenuItem";
			this.taxReportToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.taxReportToolStripMenuItem.Text = "Tax Report";
			this.taxReportToolStripMenuItem.Click += new EventHandler(this.taxReportToolStripMenuItem_Click);
			this.priceListToolStripMenuItem.Name = "priceListToolStripMenuItem";
			this.priceListToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.priceListToolStripMenuItem.Text = "Price List";
			this.priceListToolStripMenuItem.Click += new EventHandler(this.priceListToolStripMenuItem_Click);

            this.DailyExpenseToolStripMenuItem.Name = "DailyExpenseToolStripMenuItem";
            this.DailyExpenseToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.DailyExpenseToolStripMenuItem.Text = "Daily Expense";
            this.DailyExpenseToolStripMenuItem.Click += new EventHandler(this.DailyExpenseToolStripMenuItem_Click);

            this.AdvancedReportsToolStripMenuItem.Name = "AdvancedReportsToolStripMenuItem";
            this.AdvancedReportsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.AdvancedReportsToolStripMenuItem.Text = "Advance Reports";
            this.AdvancedReportsToolStripMenuItem.Click += new EventHandler(this.AdvancedReportsToolStripMenuItem_Click);



            this.StockandPriceToolStripMenuItem.Name = "StockandPriceToolStripMenuItem";
            this.StockandPriceToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.StockandPriceToolStripMenuItem.Text = "Remaining Stock";
            this.StockandPriceToolStripMenuItem.Click += new EventHandler(this.stockAndPriceToolStripMenuItem_Click);

            this.MostRunningProductsToolStripMenuItem.Name = "MostRunningProductsToolStripMenuItem";
            this.MostRunningProductsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.MostRunningProductsToolStripMenuItem.Text = "Most Running Sale Products";
            this.MostRunningProductsToolStripMenuItem.Click += new EventHandler(this.MostRunningProductsToolStripMenuItem_Click);

            this.MostPurchaseProductsToolStripMenuItem.Name = "MostPurchaseProductsToolStripMenuItem";
            this.MostPurchaseProductsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.MostPurchaseProductsToolStripMenuItem.Text = "Most Purchase Products";
            this.MostPurchaseProductsToolStripMenuItem.Click += new EventHandler(this.MostPurchaseProductsToolStripMenuItem_Click);

            this.MonthlyExpenseToolStripMenuItem.Name = "MonthlyExpenseToolStripMenuItem";
            this.MonthlyExpenseToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.MonthlyExpenseToolStripMenuItem.Text = "Monthly Expense";
            this.MonthlyExpenseToolStripMenuItem.Click += new EventHandler(this.MonthlyExpenseToolStripMenuItem_Click);
            ToolStripItemCollection dropDownItems7 = this.help.DropDownItems;
			transaction = new ToolStripItem[] { this.contentsToolStripMenuItem, this.aboutToolStripMenuItem };
			dropDownItems7.AddRange(transaction);
			this.help.Name = "help";
			this.help.Size = new System.Drawing.Size(40, 20);
			this.help.Text = "Help";
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.contentsToolStripMenuItem.Text = "Contents";
			this.contentsToolStripMenuItem.Click += new EventHandler(this.contentsToolStripMenuItem_Click);
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.aboutToolStripMenuItem.Text = "Data Reports";
			this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.exitToolStripMenuItem.Text = "Close";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
			this.toolStripStatusLabel.Text = "Status";
			ToolStripItemCollection items1 = this.statusStrip.Items;
			transaction = new ToolStripItem[] { this.toolStripStatusLabel, this.btnReminder };
			items1.AddRange(transaction);
			this.statusStrip.Location = new Point(0, 431);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.statusStrip.Size = new System.Drawing.Size(1016, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			this.btnReminder.BackColor = Color.White;
			this.btnReminder.Enabled = false;
			this.btnReminder.IsLink = true;
			this.btnReminder.LinkColor = Color.FromArgb(192, 0, 0);
			this.btnReminder.Name = "btnReminder";
			this.btnReminder.Size = new System.Drawing.Size(57, 17);
			this.btnReminder.Text = "Reminders";
			this.btnReminder.TextDirection = ToolStripTextDirection.Horizontal;
			this.btnReminder.VisitedLinkColor = Color.FromArgb(192, 0, 0);
			this.btnReminder.Click += new EventHandler(this.btnReminder_Click);
			this.timMov.Interval = 10;
			this.timMov.Tick += new EventHandler(this.timMov_Tick);
			this.timMovOut.Interval = 10;
			this.timMovOut.Tick += new EventHandler(this.timMovOut_Tick);
			this.timer1.Interval = 500;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			this.pReminder.BackColor = Color.FromArgb(214, 228, 243);
			this.pReminder.BackgroundImage = Resources.form_bottom;
			this.pReminder.BackgroundImageLayout = ImageLayout.Stretch;
			this.pReminder.Controls.Add(this.btnClose);
			this.pReminder.Controls.Add(this.lblExpiry);
			this.pReminder.Controls.Add(this.lblLowStock);
			this.pReminder.Controls.Add(this.lblReminder);
			this.pReminder.Controls.Add(this.pictureBox1);
			this.pReminder.Controls.Add(this.panel6);
			this.pReminder.Controls.Add(this.panel5);
			this.pReminder.Controls.Add(this.panel4);
			this.pReminder.Controls.Add(this.panel3);
			this.pReminder.Controls.Add(this.panel2);
			this.pReminder.Location = new Point(383, 164);
			this.pReminder.Margin = new System.Windows.Forms.Padding(0);
			this.pReminder.Name = "pReminder";
			this.pReminder.Size = new System.Drawing.Size(250, 143);
			this.pReminder.TabIndex = 5;
			this.pReminder.Visible = false;
			this.btnClose.BackColor = Color.Transparent;
			this.btnClose.Cursor = Cursors.Hand;
			this.btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
			this.btnClose.Location = new Point(234, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(15, 15);
			this.btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
			this.btnClose.TabIndex = 10;
			this.btnClose.TabStop = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click_1);
			this.lblExpiry.BackColor = Color.Transparent;
			this.lblExpiry.Location = new Point(4, 92);
			this.lblExpiry.Name = "lblExpiry";
			this.lblExpiry.Size = new System.Drawing.Size(181, 19);
			this.lblExpiry.TabIndex = 9;
			this.lblExpiry.Text = "Product Expiry";
			this.lblExpiry.MouseLeave += new EventHandler(this.lblExpiry_MouseLeave);
			this.lblExpiry.Click += new EventHandler(this.lblExpiry_Click);
			this.lblExpiry.MouseHover += new EventHandler(this.lblExpiry_MouseHover);
			this.lblLowStock.BackColor = Color.Transparent;
			this.lblLowStock.Location = new Point(4, 70);
			this.lblLowStock.Name = "lblLowStock";
			this.lblLowStock.Size = new System.Drawing.Size(181, 19);
			this.lblLowStock.TabIndex = 8;
			this.lblLowStock.Text = "Low Stock";
			this.lblLowStock.MouseLeave += new EventHandler(this.lblLowStock_MouseLeave);
			this.lblLowStock.Click += new EventHandler(this.lblLowStock_Click);
			this.lblLowStock.MouseHover += new EventHandler(this.lblLowStock_MouseHover);
			this.lblReminder.BackColor = Color.Transparent;
			this.lblReminder.Location = new Point(53, 15);
			this.lblReminder.Name = "lblReminder";
			this.lblReminder.Size = new System.Drawing.Size(181, 55);
			this.lblReminder.TabIndex = 6;
			this.lblReminder.MouseLeave += new EventHandler(this.lblReminder_MouseLeave);
			this.lblReminder.Click += new EventHandler(this.lblReminder_Click);
			this.lblReminder.MouseHover += new EventHandler(this.lblReminder_MouseHover);
			this.pictureBox1.BackColor = Color.Transparent;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(7, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.panel6.BackColor = Color.FromArgb(255, 209, 150);
			this.panel6.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Margin = new System.Windows.Forms.Padding(0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(248, 7);
			this.panel6.TabIndex = 4;
			this.panel6.Visible = false;
			this.panel5.BackColor = Color.FromArgb(255, 209, 150);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 142);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(248, 1);
			this.panel5.TabIndex = 3;
			this.panel4.BackColor = Color.FromArgb(47, 47, 146);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(248, 1);
			this.panel4.TabIndex = 2;
			this.panel3.BackColor = Color.FromArgb(255, 209, 150);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(249, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 143);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(255, 209, 150);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 143);
			this.panel2.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.White;
			this.BackgroundImage = Resources._01;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(1016, 453);
			base.Controls.Add(this.pReminder);
			base.Controls.Add(this.statusStrip);
			base.Controls.Add(this.menuStrip);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.MainMenuStrip = this.menuStrip;
			base.Name = "MDIMedicalShop";
			this.Text = "MDIMedicalShop";
			base.WindowState = FormWindowState.Maximized;
			base.Load += new EventHandler(this.MDIMedicalShop_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.pReminder.ResumeLayout(false);
			((ISupportInitialize)this.btnClose).EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void instantSaleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptInstantSale _rptInstantSale = new rptInstantSale();
			rptInstantSale item = Application.OpenForms["rptInstantSale"] as rptInstantSale;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptInstantSale.WindowState = FormWindowState.Normal;
				_rptInstantSale.MdiParent = this;
				_rptInstantSale.Show();
			}
		}

		private void journalEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmJournalEntry _frmJournalEntry = new frmJournalEntry();
			frmJournalEntry item = Application.OpenForms["frmJournalEntry"] as frmJournalEntry;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmJournalEntry.WindowState = FormWindowState.Normal;
				_frmJournalEntry.MdiParent = this;
				_frmJournalEntry.Show();
			}
		}

		private void journalEntryToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmJournalRegister _frmJournalRegister = new frmJournalRegister();
			frmJournalRegister item = Application.OpenForms["frmJournalRegister"] as frmJournalRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmJournalRegister.WindowState = FormWindowState.Normal;
				_frmJournalRegister.MdiParent = this;
				_frmJournalRegister.Show();
			}
		}

		private void journalToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rptJournalRegister _rptJournalRegister = new rptJournalRegister();
			rptJournalRegister item = Application.OpenForms["rptJournalRegister"] as rptJournalRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptJournalRegister.WindowState = FormWindowState.Normal;
				_rptJournalRegister.MdiParent = this;
				_rptJournalRegister.Show();
			}
		}

		private void lblExpiry_Click(object sender, EventArgs e)
		{
			try
			{
				Point location = this.lblExpiry.Location;
				int y = location.Y + 1;
				int x = this.lblExpiry.Location.X;
				Point point = new Point(x, y);
				this.lblExpiry.Location = point;
				frmReminderView _frmReminderView = new frmReminderView();
				frmReminderView item = Application.OpenForms["frmReminderView"] as frmReminderView;
				if (item != null)
				{
					item.MdiParent = this;
					item.CallFromReminderPopUp("tpExpiry");
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
					_frmReminderView.WindowState = FormWindowState.Normal;
					_frmReminderView.MdiParent = this;
					_frmReminderView.CallFromReminderPopUp("tpExpiry");
					_frmReminderView.Show();
				}
				location = this.lblExpiry.Location;
				y = location.Y - 1;
				x = this.lblExpiry.Location.X;
				Point point1 = new Point(x, y);
				this.lblExpiry.Location = point1;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void lblExpiry_MouseHover(object sender, EventArgs e)
		{
			this.lblExpiry.Cursor = Cursors.Hand;
			this.lblExpiry.Font = new System.Drawing.Font(this.lblExpiry.Font, FontStyle.Bold);
		}

		private void lblExpiry_MouseLeave(object sender, EventArgs e)
		{
			this.lblExpiry.Font = new System.Drawing.Font(this.lblExpiry.Font, FontStyle.Regular);
		}

		private void lblLowStock_Click(object sender, EventArgs e)
		{
			try
			{
				Point location = this.lblLowStock.Location;
				int y = location.Y + 1;
				int x = this.lblLowStock.Location.X;
				Point point = new Point(x, y);
				this.lblLowStock.Location = point;
				frmReminderView _frmReminderView = new frmReminderView();
				frmReminderView item = Application.OpenForms["frmReminderView"] as frmReminderView;
				if (item != null)
				{
					item.MdiParent = this;
					if (item.WindowState != FormWindowState.Minimized)
					{
						item.Activate();
					}
					else
					{
						item.WindowState = FormWindowState.Normal;
					}
					item.CallFromReminderPopUp("tpLowStock");
				}
				else
				{
					_frmReminderView.WindowState = FormWindowState.Normal;
					_frmReminderView.MdiParent = this;
					_frmReminderView.CallFromReminderPopUp("tpLowStock");
					_frmReminderView.Show();
				}
				location = this.lblLowStock.Location;
				y = location.Y - 1;
				x = this.lblLowStock.Location.X;
				Point point1 = new Point(x, y);
				this.lblLowStock.Location = point1;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void lblLowStock_MouseHover(object sender, EventArgs e)
		{
			this.lblLowStock.Cursor = Cursors.Hand;
			this.lblLowStock.Font = new System.Drawing.Font(this.lblLowStock.Font, FontStyle.Bold);
		}

		private void lblLowStock_MouseLeave(object sender, EventArgs e)
		{
			this.lblLowStock.Font = new System.Drawing.Font(this.lblLowStock.Font, FontStyle.Regular);
		}

		private void lblReminder_Click(object sender, EventArgs e)
		{
			try
			{
				Point location = this.lblReminder.Location;
				int y = location.Y + 1;
				int x = this.lblReminder.Location.X;
				Point point = new Point(x, y);
				this.lblReminder.Location = point;
				frmScheduler _frmScheduler = new frmScheduler();
				frmScheduler item = Application.OpenForms["frmScheduler"] as frmScheduler;
				if (item != null)
				{
					item.MdiParent = this;
					item.CallthisFormFromReminderPOpUp();
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
					_frmScheduler.WindowState = FormWindowState.Normal;
					_frmScheduler.MdiParent = this;
					_frmScheduler.CallthisFormFromReminderPOpUp();
					_frmScheduler.Show();
				}
				location = this.lblReminder.Location;
				y = location.Y - 1;
				x = this.lblReminder.Location.X;
				Point point1 = new Point(x, y);
				this.lblReminder.Location = point1;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void lblReminder_MouseHover(object sender, EventArgs e)
		{
			this.lblReminder.Cursor = Cursors.Hand;
			this.lblReminder.Font = new System.Drawing.Font(this.lblReminder.Font, FontStyle.Bold);
		}

		private void lblReminder_MouseLeave(object sender, EventArgs e)
		{
			this.lblReminder.Font = new System.Drawing.Font(this.lblReminder.Font, FontStyle.Regular);
		}

		private void ledgerBalane_Click(object sender, EventArgs e)
		{
			rptLedgerBalance _rptLedgerBalance = new rptLedgerBalance();
			rptLedgerBalance item = Application.OpenForms["rptLedgerBalance"] as rptLedgerBalance;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptLedgerBalance.WindowState = FormWindowState.Normal;
				_rptLedgerBalance.MdiParent = this;
				_rptLedgerBalance.Show();
			}
		}

		private void logouttoolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to Logout?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				if (Application.OpenForms.Count != 1)
				{
					for (int i = 0; i < Application.OpenForms.Count; i++)
					{
						if ((Application.OpenForms[i] == this ? false : Application.OpenForms[i].Name != "MDIForm"))
						{
							Application.OpenForms[i].Close();
							i--;
						}
					}
				}
			}
		}

		private void manufacturerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmManufacture _frmManufacture = new frmManufacture();
			frmManufacture item = Application.OpenForms["frmManufacture"] as frmManufacture;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmManufacture.WindowState = FormWindowState.Normal;
				_frmManufacture.MdiParent = this;
				_frmManufacture.Show();
			}
		}

		private void manufactureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptManufacture _rptManufacture = new rptManufacture();
			rptManufacture item = Application.OpenForms["rptManufacture "] as rptManufacture;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptManufacture.WindowState = FormWindowState.Normal;
				_rptManufacture.MdiParent = this;
				_rptManufacture.Show();
			}
		}

		private void MDIMedicalShop_Load(object sender, EventArgs e)
		{
			try
			{
				MDIMedicalShop.MDIObj = this;
				this.ShowQuickLinkform();
				DataTable dataTable = new DataTable();
				dataTable = (new FinacialYearSP()).FinacialYearViewAll();
				if (dataTable.Rows.Count != 0)
				{
					FinacialYearInfo._fromDate = DateTime.Parse(dataTable.Rows[0].ItemArray[1].ToString());
					FinacialYearInfo._toDate = DateTime.Parse(dataTable.Rows[0].ItemArray[2].ToString());
					FinacialYearInfo._activeOrNot = true;
				}
				else
				{
					frmCreateFinancialYear _frmCreateFinancialYear = new frmCreateFinancialYear();
					_frmCreateFinancialYear.CallThisFormFromCompanyCreation(true);
					_frmCreateFinancialYear.Activate();
				}
				string[] str = new string[] { "Pharmacy  [ ", FinacialYearInfo._fromDate.ToString("dd-MMM-yyyy"), " To ", FinacialYearInfo._toDate.ToString("dd-MMM-yyyy"), " ]" };
				this.Text = string.Concat(str);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void microsoftExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.FileName = "EXCEL.EXE";
				process.Start();
			}
			catch (Exception exception)
			{
				MessageBox.Show("Can't run excel", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void microsoftWordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.FileName = "WINWORD.EXE";
				process.Start();
			}
			catch (Exception exception)
			{
				MessageBox.Show("Can't run word", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void newFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCreateFinancialYear _frmCreateFinancialYear = new frmCreateFinancialYear();
			frmCreateFinancialYear item = Application.OpenForms["frmCreateFinancialYear"] as frmCreateFinancialYear;
			if (item != null)
			{
				item.MdiParent = this;
				_frmCreateFinancialYear.CallThisFormFromMDI(false);
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
				_frmCreateFinancialYear.WindowState = FormWindowState.Normal;
				_frmCreateFinancialYear.MdiParent = this;
				_frmCreateFinancialYear.CallThisFormFromMDI(false);
				_frmCreateFinancialYear.Show();
			}
		}

		private void OpenFile(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
			}
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void patientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmDailyCustomer _frmDailyCustomer = new frmDailyCustomer();
			frmDailyCustomer item = Application.OpenForms["frmDailyCustomer"] as frmDailyCustomer;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmDailyCustomer.WindowState = FormWindowState.Normal;
				_frmDailyCustomer.MdiParent = this;
				_frmDailyCustomer.Show();
			}
		}

		private void patientToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rptDailyCustomer _rptDailyCustomer = new rptDailyCustomer();
			rptDailyCustomer item = Application.OpenForms["rptDailyCustomer"] as rptDailyCustomer;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptDailyCustomer.WindowState = FormWindowState.Normal;
				_rptDailyCustomer.MdiParent = this;
				_rptDailyCustomer.Show();
			}
		}

		private void paymentToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			frmPurchaseRegister _frmPurchaseRegister = new frmPurchaseRegister();
			frmPurchaseRegister item = Application.OpenForms["frmPurchaseRegister"] as frmPurchaseRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmPurchaseRegister.WindowState = FormWindowState.Normal;
				_frmPurchaseRegister.MdiParent = this;
				_frmPurchaseRegister.Show();
			}
		}

		private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
		{
		}

		private void paymentToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptPayment _rptPayment = new rptPayment();
			rptPayment item = Application.OpenForms["rptPayment"] as rptPayment;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptPayment.WindowState = FormWindowState.Normal;
				_rptPayment.MdiParent = this;
				_rptPayment.Show();
			}
		}

		private void paymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmPayment _frmPayment = new frmPayment();
			frmPayment item = Application.OpenForms["frmPayment"] as frmPayment;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmPayment.MdiParent = this;
				_frmPayment.Show();
			}
		}

		private void paymentVoucherToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmPaymentRegister _frmPaymentRegister = new frmPaymentRegister();
			frmPaymentRegister item = Application.OpenForms["frmPaymentRegister"] as frmPaymentRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmPaymentRegister.WindowState = FormWindowState.Normal;
				_frmPaymentRegister.MdiParent = this;
				_frmPaymentRegister.Show();
			}
		}

		private void priceListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptPriceList _rptPriceList = new rptPriceList();
			rptPriceList item = Application.OpenForms["rptPriceList"] as rptPriceList;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptPriceList.WindowState = FormWindowState.Normal;
				_rptPriceList.MdiParent = this;
				_rptPriceList.Show();
			}
		}

        private void stockAndPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptStockAndPrice _rptStockandPrice = new rptStockAndPrice();
            rptStockAndPrice item = Application.OpenForms["rptStockAndPrice"] as rptStockAndPrice;
            if (item != null)
            {
                item.MdiParent = this;
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
                _rptStockandPrice.WindowState = FormWindowState.Normal;
                _rptStockandPrice.MdiParent = this;
                _rptStockandPrice.Show();
            }
        }

        private void MostRunningProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptMostRunningProducts _rptMostRunningProducts = new rptMostRunningProducts();
            rptMostRunningProducts item = Application.OpenForms["rptMostRunningProducts"] as rptMostRunningProducts;
            if (item != null)
            {
                item.MdiParent = this;
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
                _rptMostRunningProducts.WindowState = FormWindowState.Normal;
                _rptMostRunningProducts.MdiParent = this;
                _rptMostRunningProducts.Show();
            }
        }
        private void MostPurchaseProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptMostPurchaseProducts _rptMostpurchaseProducts = new rptMostPurchaseProducts();
            rptMostPurchaseProducts item = Application.OpenForms["rptMostPurchaseProducts"] as rptMostPurchaseProducts;
            if (item != null)
            {
                item.MdiParent = this;
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
                _rptMostpurchaseProducts.WindowState = FormWindowState.Normal;
                _rptMostpurchaseProducts.MdiParent = this;
                _rptMostpurchaseProducts.Show();
            }
        }
        private void DailyExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptDailyIncomeExpense _rptDailyincomeexpense = new rptDailyIncomeExpense();
            rptDailyIncomeExpense item = Application.OpenForms["rptDailyIncomeExpense"] as rptDailyIncomeExpense;
            if (item != null)
            {
                item.MdiParent = this;
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
                _rptDailyincomeexpense.WindowState = FormWindowState.Normal;
                _rptDailyincomeexpense.MdiParent = this;
                _rptDailyincomeexpense.Show();
            }
        }
        private void AdvancedReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PharmacyWPFUI.MainWindow _rptAdvancedReports = new PharmacyWPFUI.MainWindow();
            //_rptAdvancedReports.Show();
            //CSharp.WpfDemo.App _rptAdvancedReports = new CSharp.WpfDemo.App();
            // _rptAdvancedReports.MainWindow= new CSharp.WpfDemo.Window1() ;

            //   CSharp.WpfDemo.App app = new CSharp.WpfDemo.App();
            //AdvanceReport rp = new AdvanceReport();
            //rp.Show();

            //CSharp.WpfDemo.Window2 _rptAdvancedReports = new CSharp.WpfDemo.Window2();
            //_rptAdvancedReports.Show();

            //AdvanceReport _rptProductBatch = new AdvanceReport();
            //AdvanceReport item = Application.OpenForms["AdvanceReport"] as AdvanceReport;

            rptAdvanced _rptProductBatch = new rptAdvanced();
            rptAdvanced item = Application.OpenForms["rptAdvanced"] as rptAdvanced;
            if (item != null)
            {
                item.MdiParent = this;
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
                _rptProductBatch.WindowState = FormWindowState.Normal;
                _rptProductBatch.MdiParent = this;
                _rptProductBatch.Show();
            }

        }
        private void MonthlyExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptMonthlyIncomeExpense _rptMonthlyincomeexpense = new rptMonthlyIncomeExpense();
            rptMonthlyIncomeExpense item = Application.OpenForms["rptMonthlyIncomeExpense"] as rptMonthlyIncomeExpense;
            if (item != null)
            {
                item.MdiParent = this;
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
                _rptMonthlyincomeexpense.WindowState = FormWindowState.Normal;
                _rptMonthlyincomeexpense.MdiParent = this;
                _rptMonthlyincomeexpense.Show();
            }
        }

        private void productAvailabilitySearchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmProductAvailability _frmProductAvailability = new frmProductAvailability();
			frmProductAvailability item = Application.OpenForms["frmProductAvailability"] as frmProductAvailability;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmProductAvailability.MdiParent = this;
				_frmProductAvailability.Show();
			}
		}

		private void productBatchToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rptProductBatch _rptProductBatch = new rptProductBatch();
			rptProductBatch item = Application.OpenForms["rptProductBatch"] as rptProductBatch;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptProductBatch.WindowState = FormWindowState.Normal;
				_rptProductBatch.MdiParent = this;
				_rptProductBatch.Show();
			}
		}

		private void productGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmProductGroup _frmProductGroup = new frmProductGroup();
			frmProductGroup item = Application.OpenForms["frmProductGroup"] as frmProductGroup;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmProductGroup.WindowState = FormWindowState.Normal;
				_frmProductGroup.MdiParent = this;
				_frmProductGroup.Show();
			}
		}

		private void productGroupToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptProductGroup _rptProductGroup = new rptProductGroup();
			rptProductGroup item = Application.OpenForms["rptProductGroup"] as rptProductGroup;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptProductGroup.WindowState = FormWindowState.Normal;
				_rptProductGroup.MdiParent = this;
				_rptProductGroup.Show();
			}
		}

		private void productStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptStatistics rptStatistic = new rptStatistics();
			rptStatistics item = Application.OpenForms["rptStatistics"] as rptStatistics;
			if (item != null)
			{
				item.MdiParent = this;
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
				rptStatistic.WindowState = FormWindowState.Normal;
				rptStatistic.MdiParent = this;
				rptStatistic.Show();
			}
		}

		private void productToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmProduct _frmProduct = new frmProduct();
			frmProduct item = Application.OpenForms["frmProduct"] as frmProduct;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmProduct.MdiParent = this;
				_frmProduct.Show();
			}
		}

		private void productToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rtpStock _rtpStock = new rtpStock();
			rtpStock item = Application.OpenForms["rtpStock"] as rtpStock;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rtpStock.WindowState = FormWindowState.Normal;
				_rtpStock.MdiParent = this;
				_rtpStock.Show();
			}
		}

		private void profitLossAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptProfitAndLossAnalysis rptProfitAndLossAnalysi = new rptProfitAndLossAnalysis();
			rptProfitAndLossAnalysis item = Application.OpenForms["rptProfitAndLossAnalysis"] as rptProfitAndLossAnalysis;
			if (item != null)
			{
				item.MdiParent = this;
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
				rptProfitAndLossAnalysi.MdiParent = this;
				rptProfitAndLossAnalysi.Show();
			}
		}

		private void profitLossAnalysisToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			rptProfitAndLossAnalysis rptProfitAndLossAnalysi = new rptProfitAndLossAnalysis();
			rptProfitAndLossAnalysis item = Application.OpenForms["rptProfitAndLossAnalysis"] as rptProfitAndLossAnalysis;
			if (item != null)
			{
				item.MdiParent = this;
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
				rptProfitAndLossAnalysi.MdiParent = this;
				rptProfitAndLossAnalysi.Show();
			}
		}

		private void purchaseReturnToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			frmPurchaseReturn _frmPurchaseReturn = new frmPurchaseReturn();
			frmPurchaseReturn item = Application.OpenForms["frmPurchaseReturn"] as frmPurchaseReturn;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmPurchaseReturn.MdiParent = this;
				_frmPurchaseReturn.Show();
			}
		}

		private void purchaseReturnToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmPurchaseReturnRegister _frmPurchaseReturnRegister = new frmPurchaseReturnRegister();
			frmPurchaseReturnRegister item = Application.OpenForms["frmPurchaseReturnRegister"] as frmPurchaseReturnRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmPurchaseReturnRegister.WindowState = FormWindowState.Normal;
				_frmPurchaseReturnRegister.MdiParent = this;
				_frmPurchaseReturnRegister.Show();
			}
		}

		private void purchaseReturnToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			rptPurchaseReturn _rptPurchaseReturn = new rptPurchaseReturn();
			rptPurchaseReturn item = Application.OpenForms["rptPurchaseReturn"] as rptPurchaseReturn;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptPurchaseReturn.WindowState = FormWindowState.Normal;
				_rptPurchaseReturn.MdiParent = this;
				_rptPurchaseReturn.Show();
			}
		}

		private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmPurchaseInvoice _frmPurchaseInvoice = new frmPurchaseInvoice();
			frmPurchaseInvoice item = Application.OpenForms["frmPurchaseInvoice"] as frmPurchaseInvoice;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmPurchaseInvoice.MdiParent = this;
				_frmPurchaseInvoice.Show();
			}
		}

		private void purchaseToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptPurchase _rptPurchase = new rptPurchase();
			rptPurchase item = Application.OpenForms["rptPurchase"] as rptPurchase;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptPurchase.WindowState = FormWindowState.Normal;
				_rptPurchase.MdiParent = this;
				_rptPurchase.Show();
			}
		}

		private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void receiptToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rptReceipt _rptReceipt = new rptReceipt();
			rptReceipt item = Application.OpenForms["rptPayment"] as rptReceipt;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptReceipt.WindowState = FormWindowState.Normal;
				_rptReceipt.MdiParent = this;
				_rptReceipt.Show();
			}
		}

		private void receiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmReceipt _frmReceipt = new frmReceipt();
			frmReceipt item = Application.OpenForms["frmReceipt"] as frmReceipt;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmReceipt.MdiParent = this;
				_frmReceipt.Show();
			}
		}

		private void receiptVoucherToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmReceiptRegister _frmReceiptRegister = new frmReceiptRegister();
			frmReceiptRegister item = Application.OpenForms["frmReceiptRegister"] as frmReceiptRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmReceiptRegister.WindowState = FormWindowState.Normal;
				_frmReceiptRegister.MdiParent = this;
				_frmReceiptRegister.Show();
			}
		}

		public void ReminderPopUp()
		{
			this.isEmpty = true;
			ReminderSP reminderSP = new ReminderSP();
			DataTable dataTable = new DataTable();
			dataTable = reminderSP.ReminderViewBydate(DateTime.Today);
			if (dataTable.Rows.Count <= 0)
			{
				this.lblReminder.Text = "";
				this.lblReminder.Enabled = false;
			}
			else
			{
				string str = "";
				int num = 1;
				int num1 = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					num1++;
					string[] strArrays = new string[] { str, "", num.ToString(), ":", row.ItemArray[3].ToString().Replace("\n\r", " "), "\n" };
					str = string.Concat(strArrays);
					num++;
					if (num1 == 3)
					{
						break;
					}
				}
				this.lblReminder.Text = str;
				this.lblReminder.Enabled = true;
				this.isEmpty = false;
			}
			SettingsInfo settingsInfo = new SettingsInfo();
			settingsInfo = (new SettingsSP()).SettingsView("1");
			ProductSP productSP = new ProductSP();
			DataTable allLowStockProduct = new DataTable();
			allLowStockProduct = productSP.GetAllLowStockProduct();
			if ((allLowStockProduct.Rows.Count <= 0 ? true : !settingsInfo.LowStockAlertStatus))
			{
				this.lblLowStock.Enabled = false;
			}
			else
			{
				if (!this.lblLowStock.Enabled)
				{
					this.lblLowStock.Enabled = true;
				}
				this.isEmpty = false;
			}
			DateTime today = DateTime.Today;
			string[] strArrays1 = settingsInfo.ExpiryReminderWithin.Split(new char[] { '+' });
			if (strArrays1[1].ToString() == "Days")
			{
				today = today.AddDays((double)int.Parse(strArrays1[0].ToString()));
			}
			else if (strArrays1[1].ToString() == "Months")
			{
				today = today.AddMonths(int.Parse(strArrays1[0].ToString()));
			}
			else if (strArrays1[1].ToString() == "Year")
			{
				today = today.AddYears(int.Parse(strArrays1[0].ToString()));
			}
			ProductBatchSP productBatchSP = new ProductBatchSP();
			DataTable dataTable1 = new DataTable();
			dataTable1 = productBatchSP.ShortExpiryBatchGet(today);
			if ((dataTable1.Rows.Count <= 0 ? true : !settingsInfo.ExpiryReminderNeeded))
			{
				this.lblExpiry.Enabled = false;
			}
			else
			{
				if (!this.lblExpiry.Enabled)
				{
					this.lblExpiry.Enabled = true;
				}
				this.isEmpty = false;
			}
			if ((dataTable.Rows.Count != 0 || allLowStockProduct.Rows.Count != 0 ? false : dataTable1.Rows.Count == 0))
			{
				this.pyb2 = this.pyb2 - 4;
				this.p.X = base.Right - 258;
				this.p.Y = base.Bottom - this.pyb2;
				this.pReminder.Location = this.p;
				this.timMovOut.Enabled = true;
			}
			if (this.isEmpty)
			{
				this.btnReminder.Enabled = false;
				this.pReminder.Visible = false;
			}
			else if ((UserInfo._currentUserId == "" ? true : UserInfo._currentUserId == null))
			{
				this.btnReminder.Enabled = false;
			}
			else if (!this.pReminder.Visible)
			{
				this.btnReminder.Enabled = true;
				this.pReminder.Visible = true;
				this.p.X = base.Right - 258;
				this.p.Y = base.Bottom;
				this.pReminder.Location = this.p;
				this.timMov.Enabled = true;
				this.pyb = 2;
				this.pyb2 = 182;
			}
		}

		private void reminderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmReminderView _frmReminderView = new frmReminderView();
			frmReminderView item = Application.OpenForms["frmReminderView"] as frmReminderView;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmReminderView.WindowState = FormWindowState.Normal;
				_frmReminderView.MdiParent = this;
				_frmReminderView.Show();
			}
		}

		private void reminderToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rptReminder _rptReminder = new rptReminder();
			rptReminder item = Application.OpenForms["rptReminder"] as rptReminder;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptReminder.WindowState = FormWindowState.Normal;
				_rptReminder.MdiParent = this;
				_rptReminder.Show();
			}
		}

		private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void salesManToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSalesMan _frmSalesMan = new frmSalesMan();
			frmSalesMan item = Application.OpenForms["frmSalesMan"] as frmSalesMan;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmSalesMan.WindowState = FormWindowState.Normal;
				_frmSalesMan.MdiParent = this;
				_frmSalesMan.Show();
			}
		}

		private void salesManToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			rtpSalesMan _rtpSalesMan = new rtpSalesMan();
			rtpSalesMan item = Application.OpenForms["rtpSalesMan"] as rtpSalesMan;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rtpSalesMan.WindowState = FormWindowState.Normal;
				_rtpSalesMan.MdiParent = this;
				_rtpSalesMan.Show();
			}
		}

		private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSalesReturn _frmSalesReturn = new frmSalesReturn();
			frmSalesReturn item = Application.OpenForms["frmSalesReturn"] as frmSalesReturn;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmSalesReturn.MdiParent = this;
				_frmSalesReturn.Show();
			}
		}

		private void salesReturnToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmsalesReturnRegister _frmsalesReturnRegister = new frmsalesReturnRegister();
			frmsalesReturnRegister item = Application.OpenForms["frmsalesReturnRegister"] as frmsalesReturnRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmsalesReturnRegister.WindowState = FormWindowState.Normal;
				_frmsalesReturnRegister.MdiParent = this;
				_frmsalesReturnRegister.Show();
			}
		}

		private void salesReturnToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptSalesReturn _rptSalesReturn = new rptSalesReturn();
			rptSalesReturn item = Application.OpenForms["rptSalesReturn"] as rptSalesReturn;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptSalesReturn.WindowState = FormWindowState.Normal;
				_rptSalesReturn.MdiParent = this;
				_rptSalesReturn.Show();
			}
		}

		private void salesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSalesInvoice _frmSalesInvoice = new frmSalesInvoice();
			frmSalesInvoice item = Application.OpenForms["frmSalesInvoice"] as frmSalesInvoice;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmSalesInvoice.MdiParent = this;
				_frmSalesInvoice.Show();
			}
		}

		private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmSalesRegister _frmSalesRegister = new frmSalesRegister();
			frmSalesRegister item = Application.OpenForms["frmSalesRegister"] as frmSalesRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmSalesRegister.WindowState = FormWindowState.Normal;
				_frmSalesRegister.MdiParent = this;
				_frmSalesRegister.Show();
			}
		}

		private void salesToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptSales rptSale = new rptSales();
			rptSales item = Application.OpenForms["rptSales"] as rptSales;
			if (item != null)
			{
				item.MdiParent = this;
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
				rptSale.WindowState = FormWindowState.Normal;
				rptSale.MdiParent = this;
				rptSale.Show();
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog()
			{
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				string fileName = saveFileDialog.FileName;
			}
		}

		private void schedulerToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmScheduler _frmScheduler = new frmScheduler();
			frmScheduler item = Application.OpenForms["frmScheduler"] as frmScheduler;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmScheduler.WindowState = FormWindowState.Normal;
				_frmScheduler.MdiParent = this;
				_frmScheduler.Show();
			}
		}

		private void shelfToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmShelf _frmShelf = new frmShelf();
			frmShelf item = Application.OpenForms["frmShelf"] as frmShelf;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmShelf.WindowState = FormWindowState.Normal;
				_frmShelf.MdiParent = this;
				_frmShelf.Show();
			}
		}

		private void shortExpiryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptShortExpiry _rptShortExpiry = new rptShortExpiry();
			rptShortExpiry item = Application.OpenForms["rptShortExpiry"] as rptShortExpiry;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptShortExpiry.WindowState = FormWindowState.Normal;
				_rptShortExpiry.MdiParent = this;
				_rptShortExpiry.Show();
			}
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			Form form = new Form()
			{
				MdiParent = this
			};
			MDIMedicalShop mDIMedicalShop = this;
			int num = mDIMedicalShop.childFormNumber;
			int num1 = num;
			mDIMedicalShop.childFormNumber = num + 1;
			form.Text = string.Concat("Window ", num1);
			form.Show();
		}

		public void ShowQuickLinkform()
		{
			MDIForm item = Application.OpenForms["MDIForm"] as MDIForm;
			if (item != null)
			{
				item.MdiParent = this;
				item.Activate();
			}
			else
			{
				this.frmQuickLaunch.MdiParent = this;
				this.frmQuickLaunch.Show();
			}
		}

		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void stockAndSaleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptStockAndSale _rptStockAndSale = new rptStockAndSale();
			rptStockAndSale item = Application.OpenForms["rptStockAndSale"] as rptStockAndSale;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptStockAndSale.WindowState = FormWindowState.Normal;
				_rptStockAndSale.MdiParent = this;
				_rptStockAndSale.Show();
			}
		}

		private void stockAtMinimumLevelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptMinimumStock _rptMinimumStock = new rptMinimumStock();
			rptMinimumStock item = Application.OpenForms["rptMinimumStock"] as rptMinimumStock;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptMinimumStock.WindowState = FormWindowState.Normal;
				_rptMinimumStock.MdiParent = this;
				_rptMinimumStock.Show();
			}
		}

		private void stockEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmStockEntry _frmStockEntry = new frmStockEntry();
			frmStockEntry item = Application.OpenForms["frmStockEntry"] as frmStockEntry;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmStockEntry.WindowState = FormWindowState.Normal;
				_frmStockEntry.MdiParent = this;
				_frmStockEntry.Show();
			}
		}

		private void stockNewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmDamageStock _frmDamageStock = new frmDamageStock();
			frmDamageStock item = Application.OpenForms["frmDamageStock"] as frmDamageStock;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmDamageStock.WindowState = FormWindowState.Normal;
				_frmDamageStock.MdiParent = this;
				_frmDamageStock.Show();
			}
		}

		private void stockRegisterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmStockRegister _frmStockRegister = new frmStockRegister();
			frmStockRegister item = Application.OpenForms["frmStockRegister"] as frmStockRegister;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmStockRegister.WindowState = FormWindowState.Normal;
				_frmStockRegister.MdiParent = this;
				_frmStockRegister.Show();
			}
		}

		private void stockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptStockEtry _rptStockEtry = new rptStockEtry();
			rptStockEtry item = Application.OpenForms["rptStockEtry"] as rptStockEtry;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptStockEtry.WindowState = FormWindowState.Normal;
				_rptStockEtry.MdiParent = this;
				_rptStockEtry.Show();
			}
		}

		private void taxReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rptTaxReport _rptTaxReport = new rptTaxReport();
			rptTaxReport item = Application.OpenForms["rptTaxReport"] as rptTaxReport;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptTaxReport.WindowState = FormWindowState.Normal;
				_rptTaxReport.MdiParent = this;
				_rptTaxReport.Show();
			}
		}

		private void telephoneDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmTelephoneDirectory _frmTelephoneDirectory = new frmTelephoneDirectory();
			frmTelephoneDirectory item = Application.OpenForms["frmTelephoneDirectory "] as frmTelephoneDirectory;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmTelephoneDirectory.WindowState = FormWindowState.Normal;
				_frmTelephoneDirectory.MdiParent = this;
				_frmTelephoneDirectory.Show();
			}
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.TileVertical);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.isClose)
			{
				this.x = this.x + 5;
				if (this.x == 25)
				{
					this.ReminderPopUp();
					this.x = 0;
				}
			}
			else if (this.checkAnyData())
			{
				this.btnReminder.Enabled = true;
			}
			else
			{
				this.btnReminder.Enabled = false;
			}
		}

		private void timMov_Tick(object sender, EventArgs e)
		{
			this.pyb = this.pyb + 4;
			this.p.X = base.Right - 258;
			this.p.Y = base.Bottom - this.pyb;
			this.pReminder.Location = this.p;
			if (this.pyb >= 182)
			{
				this.timMov.Enabled = false;
			}
		}

		private void timMovOut_Tick(object sender, EventArgs e)
		{
			this.pyb2 = this.pyb2 - 4;
			this.p.X = base.Right - 258;
			this.p.Y = base.Bottom - this.pyb2;
			this.pReminder.Location = this.p;
			if (this.pyb2 <= 2)
			{
				this.timMovOut.Enabled = false;
				this.pReminder.Visible = false;
			}
		}

		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptTrialBalance _rptTrialBalance = new rptTrialBalance();
			rptTrialBalance item = Application.OpenForms["rptTrialBalance"] as rptTrialBalance;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptTrialBalance.MdiParent = this;
				_rptTrialBalance.Show();
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			frmProductBatch _frmProductBatch = new frmProductBatch();
			frmProductBatch item = Application.OpenForms["frmProductBatch"] as frmProductBatch;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmProductBatch.WindowState = FormWindowState.Normal;
				_frmProductBatch.MdiParent = this;
				_frmProductBatch.Show();
			}
		}

		private void transactToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void unitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmUnit _frmUnit = new frmUnit();
			frmUnit item = Application.OpenForms["frmUnit "] as frmUnit;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmUnit.WindowState = FormWindowState.Normal;
				_frmUnit.MdiParent = this;
				_frmUnit.Show();
			}
		}

		private void userToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptUser _rptUser = new rptUser();
			rptUser item = Application.OpenForms["rptUser "] as rptUser;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptUser.WindowState = FormWindowState.Normal;
				_rptUser.MdiParent = this;
				_rptUser.Show();
			}
		}

		private void vedioHelpToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmVendor _frmVendor = new frmVendor();
			frmVendor item = Application.OpenForms["frmVendor"] as frmVendor;
			if (item != null)
			{
				item.MdiParent = this;
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
				_frmVendor.MdiParent = this;
				_frmVendor.Show();
			}
		}

		private void vendorToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			rptVendor _rptVendor = new rptVendor();
			rptVendor item = Application.OpenForms["rptVendor "] as rptVendor;
			if (item != null)
			{
				item.MdiParent = this;
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
				_rptVendor.WindowState = FormWindowState.Normal;
				_rptVendor.MdiParent = this;
				_rptVendor.Show();
			}
		}
	}
}