namespace MedicalShop
{
    partial class frmProductManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdProducts = new System.Windows.Forms.DataGridView();
            this.ddlManufacture = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // grdProducts
            // 
            this.grdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProducts.Location = new System.Drawing.Point(35, 92);
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.Size = new System.Drawing.Size(842, 225);
            this.grdProducts.TabIndex = 0;
            // 
            // ddlManufacture
            // 
            this.ddlManufacture.FormattingEnabled = true;
            this.ddlManufacture.Location = new System.Drawing.Point(206, 39);
            this.ddlManufacture.Name = "ddlManufacture";
            this.ddlManufacture.Size = new System.Drawing.Size(121, 21);
            this.ddlManufacture.TabIndex = 1;
            this.ddlManufacture.SelectedIndexChanged += new System.EventHandler(this.ddlManufacture_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manufacture";
            // 
            // frmProductManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 329);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlManufacture);
            this.Controls.Add(this.grdProducts);
            this.Name = "frmProductManage";
            this.Text = "frmProductManage";
            this.Load += new System.EventHandler(this.frmProductManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdProducts;
        private System.Windows.Forms.ComboBox ddlManufacture;
        private System.Windows.Forms.Label label1;
    }
}