using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmAboutUs : Form
	{
		private IContainer components = null;

		private PictureBox pbPharmiz;

		private Label label3;

		private Label label2;

		private LinkLabel lnklblPharmiz;

		private LinkLabel lnklblCybro;

		private Label label5;

		private Label label6;

		private Label label8;

		private Label label9;

		private Panel panel1;

		private Panel panel6;

		private Label label18;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel9;

		private Panel panel10;

		private Panel panel8;

		private Label label1;

		private PictureBox pictureBox1;

		public frmAboutUs()
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

		private void frmAboutUs_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\u001B')
				{
					base.Close();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmiz", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lnklblPharmiz = new System.Windows.Forms.LinkLabel();
            this.lnklblCybro = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbPharmiz = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbPharmiz)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(7, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(547, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(521, 40);
            this.label9.TabIndex = 2;
            // 
            // lnklblPharmiz
            // 
            this.lnklblPharmiz.AutoSize = true;
            this.lnklblPharmiz.Location = new System.Drawing.Point(83, 186);
            this.lnklblPharmiz.Name = "lnklblPharmiz";
            this.lnklblPharmiz.Size = new System.Drawing.Size(0, 13);
            this.lnklblPharmiz.TabIndex = 3;
            this.lnklblPharmiz.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblPharmiz_LinkClicked);
            // 
            // lnklblCybro
            // 
            this.lnklblCybro.AutoSize = true;
            this.lnklblCybro.Location = new System.Drawing.Point(83, 166);
            this.lnklblCybro.Name = "lnklblCybro";
            this.lnklblCybro.Size = new System.Drawing.Size(0, 13);
            this.lnklblCybro.TabIndex = 3;
            this.lnklblCybro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCybro_LinkClicked);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 93);
            this.label6.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Our Portals:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(475, 53);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 21);
            this.label2.TabIndex = 2;
            // 
            // pbPharmiz
            // 
            this.pbPharmiz.Location = new System.Drawing.Point(8, 8);
            this.pbPharmiz.Name = "pbPharmiz";
            this.pbPharmiz.Size = new System.Drawing.Size(200, 60);
            this.pbPharmiz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPharmiz.TabIndex = 1;
            this.pbPharmiz.TabStop = false;
            this.pbPharmiz.Click += new System.EventHandler(this.pbPharmiz_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 460);
            this.panel1.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Controls.Add(this.pictureBox1);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.pbPharmiz);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.lnklblPharmiz);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.lnklblCybro);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(1, 34);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(562, 367);
            this.panel8.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(354, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(562, 33);
            this.panel6.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(11, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "About Us";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(562, 1);
            this.panel7.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 459);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(562, 1);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(562, 1);
            this.panel4.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(563, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1, 460);
            this.panel9.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1, 460);
            this.panel10.TabIndex = 0;
            // 
            // frmAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 474);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAboutUs";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Us";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAboutUs_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbPharmiz)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

		}

		private void lnklblCybro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("IExplore.exe", "http://www.cybrosys.com/");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmiz", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void lnklblPharmiz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("IExplore.exe", "http://www.pharmiz.com/");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmiz", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void pbPharmiz_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("IExplore.exe", "http://www.pharmiz.com/");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmiz", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}