using MedicalShop.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmCompanyProgress : Form
	{
		private IContainer components = null;

		private PictureBox pictureBox1;

		private Label label1;

		public frmCompanyProgress()
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

		private void frmCompanyProgress_Load(object sender, EventArgs e)
		{
			this.pictureBox1.Show();
		}

		private void InitializeComponent()
		{
			this.pictureBox1 = new PictureBox();
			this.label1 = new Label();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Image = Resources.indicator;
			this.pictureBox1.Location = new Point(5, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(14, 17);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Location = new Point(47, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Exporting...";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			this.BackgroundImage = Resources.formBG;
			this.BackgroundImageLayout = ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(116, 35);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmCompanyProgress";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Load += new EventHandler(this.frmCompanyProgress_Load);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void ShowFromReport()
		{
			this.label1.Text = "Exporting...";
			base.ShowDialog();
		}

		public void ShowFromSendMail()
		{
			this.label1.Text = "Sending...";
			base.ShowDialog();
		}
	}
}