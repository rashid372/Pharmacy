using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalShop
{
  public  class PrintingCountersale
    {
        public PrintingCountersale()
        {
            linePrint = new LPrinter();
            this.invoicedatainfo = new InvoiceDataInfo();
            this.prnDocument = new PrintDocument();
            this.prnPreview = new PrintPreviewDialog();
            this.prnDialog = new PrintDialog();
            prnDocument.PrintPage += new PrintPageEventHandler(prnDocument_PrintPage);
        }

        // for PrintDialog, PrintPreviewDialog and PrintDocument:
        private PrintDialog prnDialog;
        private PrintPreviewDialog prnPreview;
        private PrintDocument prnDocument;
        private InvoiceDataInfo invoicedatainfo;
        private LPrinter linePrint;
        private Label lblReceiptHead = new Label();


        // for Report:
        private int CurrentY;
        private int CurrentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;

        private bool ReadInvoice;
        private int AmountPosition;

        // for Invoice Head:
        private string InvTitle;
        private string InvSubTitle1;
        private string InvSubTitle2;
        private string InvSubTitle3;
        private string InvImage;


        // Font and Color:------------------
        // Title Font

        private Font ReciptHeadFont = new Font("Times New Roman", 16, FontStyle.Bold);
        private Font ReciptBodyFont = new Font("Times New Roman", 10, FontStyle.Regular);

        private Font InvTitleFont = new Font("Times New Roman", 30, FontStyle.Regular);
        // Title Font height
        private int InvTitleHeight;
        // SubTitle Font
        private Font InvSubTitleFont = new Font("Times New Roman", 10, FontStyle.Regular);
        // SubTitle Font height
        private int InvSubTitleHeight;
        // Invoice Font
        private Font InvoiceFont = new Font("Times New Roman", 10, FontStyle.Regular);
        // Invoice Font height
        private int InvoiceFontHeight;
        // Blue Color
        private SolidBrush BlueBrush = new SolidBrush(Color.Black);
        // Red Color
        private SolidBrush RedBrush = new SolidBrush(Color.Black);
        // Black Color
        private SolidBrush BlackBrush = new SolidBrush(Color.Black);


        private string GetReciptHead()
        {


            StringBuilder header = new StringBuilder();
            if (!string.IsNullOrEmpty(invoicedatainfo.CompanyName) && invoicedatainfo.CompanyName != " ")
            {
                header.AppendLine("           " + invoicedatainfo.CompanyName);
            }
            if (!string.IsNullOrEmpty(invoicedatainfo.Address) && invoicedatainfo.Address != " ")
            {
                header.AppendLine("   " + invoicedatainfo.Address.Trim());
            }
            if (!string.IsNullOrEmpty(invoicedatainfo.Phone) && invoicedatainfo.Phone != " ")
            {
                header.AppendLine("         Phone Number : " + invoicedatainfo.Phone.Trim());
            }
            header.AppendLine(" ");
            if (!string.IsNullOrEmpty(invoicedatainfo.InvoiceNo) && invoicedatainfo.InvoiceNo != " ")
            {
                header.AppendLine("Date :" + FormateString(invoicedatainfo.SaleDate.ToString(), 8) + " Invoice NO:" + FormateString(invoicedatainfo.InvoiceNo.ToString(), 8));
            }
            if (!string.IsNullOrEmpty(invoicedatainfo.CustomerCode) && invoicedatainfo.CustomerCode != " ")
            {
                header.AppendLine("Customer Code :" + FormateString(invoicedatainfo.CustomerCode.ToString(), 8) + "  Name : " + invoicedatainfo.CustomerName);
            }

            if (!string.IsNullOrEmpty(invoicedatainfo.vocherNo) && invoicedatainfo.vocherNo != " ")
            {
                header.AppendLine("Date :" + FormateString(invoicedatainfo.SaleDate.ToString(), 8) + " Voucher NO:" + FormateString(invoicedatainfo.vocherNo.ToString(), 8));
            }

            header.AppendLine("--------------------------------------------");
            lblReceiptHead.Text = header.ToString();
            lblReceiptHead.Font = ReciptHeadFont;
            return lblReceiptHead.Text.ToString();
        }
        private string GetReciptBody()
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("NAME           PRICE     QTY   DISC    TOTAL ");
            body.AppendLine("--------------------------------------------");
            if (invoicedatainfo.invoiceitem.Count > 0)
            {
                foreach (var item in invoicedatainfo.invoiceitem)
                {
                    if (item.ProductName.Length > 13)
                    {
                        body.AppendLine(FormateString(item.ProductName.Remove(13), 14) + " " + FormateString(item.Rate.ToString(), 10) + " " + FormateString(item.Quantity.ToString(), 5) + " " + FormateString(item.BillDiscount.ToString(), 10) + " " + FormateString(item.TotalAmount.ToString(), 10));
                    }
                    else
                    {
                        body.AppendLine(FormateString(item.ProductName, 14) + " " + FormateString(item.Rate.ToString(), 10) + " " + FormateString(item.Quantity.ToString(), 5) + " " + FormateString(item.BillDiscount.ToString(), 10) + " " + FormateString(item.TotalAmount.ToString(), 10));
                    }

                }

            }
            body.AppendLine("--------------------------------------------");
            if (invoicedatainfo.TotalAmount > 0)
            {
                body.AppendLine("Total        :                  " + invoicedatainfo.TotalAmount);
                //body.AppendLine("Discount     :                  " + invoicedatainfo.BillDiscount);
            }
            if (invoicedatainfo.GrandTotal > 0)
            {
                body.AppendLine("Grand Total  :                  " + invoicedatainfo.GrandTotal);
            }

            body.AppendLine("--------------------------------------------");
            body.AppendLine("Thank you for visiting at Mumtaz Medical Store.");

            return body.ToString();
        }
        public void PrintRecipt()
        {
            if (!linePrint.Open("Invoice")) return;
           // string test = GetReciptHead() + GetReciptBody();
            linePrint.Print("Start");
            linePrint.Print(GetReciptHead());
            linePrint.Print(GetReciptBody());
            linePrint.Close();
        }

        private string FormateString(string value, int length)
        {
            if (!string.IsNullOrEmpty(value))
            {
                for (int i = 0; i <= length; i++)
                {
                    if (value.Length < length)
                    {
                        value += " ";
                    }
                }
            }
            return value;
        }


        private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            leftMargin = (int)e.MarginBounds.Left;
            rightMargin = (int)e.MarginBounds.Right;
            topMargin = (int)e.MarginBounds.Top;
            bottomMargin = (int)e.MarginBounds.Bottom;
            InvoiceWidth = (int)e.MarginBounds.Width;
            InvoiceHeight = (int)e.MarginBounds.Height;

            if (!ReadInvoice)
                //ReadInvoiceData();
                invoicedatainfo.Address = ConfigurationSettings.AppSettings["NoWr_Address"].ToString();
            invoicedatainfo.Phone = ConfigurationSettings.AppSettings["NoWr_Phone"].ToString();
            invoicedatainfo.CompanyName = ConfigurationSettings.AppSettings["NoWr_CompanyName"].ToString();

            InvTitle = invoicedatainfo.CompanyName;
            InvSubTitle1 = invoicedatainfo.Address;
            InvSubTitle2 = invoicedatainfo.Phone;

            SetInvoiceHead(e.Graphics); // Draw Invoice Head
            SetOrderData(e.Graphics, invoicedatainfo); // Draw Order Data
            SetInvoiceData(e.Graphics, e, invoicedatainfo); // Draw Invoice Data


            ReadInvoice = true;
        }
        private void SetInvoiceHead(Graphics g)
        {
            //ReadInvoiceHead();

            CurrentY = topMargin;
            CurrentX = leftMargin;
            int ImageHeight = 0;

            // Draw Invoice image:
            if (System.IO.File.Exists(InvImage))
            {
                Bitmap oInvImage = new Bitmap(InvImage);
                // Set Image Left to center Image:
                int xImage = CurrentX + (InvoiceWidth - oInvImage.Width) / 2;
                ImageHeight = oInvImage.Height; // Get Image Height
                g.DrawImage(oInvImage, xImage, CurrentY);
            }

            InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
            InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

            // Get Titles Length:
            int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
            int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
            int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
            int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
            // Set Titles Left:
            int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
            int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
            int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
            int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;

            // Draw Invoice Head:
            if (InvTitle != "")
            {
                CurrentY = CurrentY + ImageHeight;
                g.DrawString(InvTitle, InvTitleFont, BlueBrush, xInvTitle, CurrentY);
            }
            if (InvSubTitle1 != "")
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString(InvSubTitle1, InvSubTitleFont, BlueBrush, xInvSubTitle1, CurrentY);
            }
            if (InvSubTitle2 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle2, InvSubTitleFont, BlueBrush, xInvSubTitle2, CurrentY);
            }
            if (InvSubTitle3 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle3, InvSubTitleFont, BlueBrush, xInvSubTitle3, CurrentY);
            }

            // Draw line:
            CurrentY = CurrentY + InvSubTitleHeight + 8;
            g.DrawLine(new Pen(Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);
        }
        private void SetOrderData(Graphics g, InvoiceDataInfo invoicedatainfo)
        {// Set Company Name, City, Salesperson, Order ID and Order Date
            string FieldValue = "";
            InvoiceFontHeight = (int)(InvoiceFont.GetHeight(g));
            // Set Company Name:
            CurrentX = leftMargin;
            CurrentY = CurrentY + 8;

            FieldValue = "Voucher No :" + invoicedatainfo.vocherNo;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set City:
            CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            FieldValue = "Date: " + invoicedatainfo.SaleDate;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            //// set phone
            //CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            //FieldValue = "Phone: " + Phone;
            //g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set Salesperson:
            //CurrentX = leftMargin;
            //CurrentY = CurrentY + InvoiceFontHeight;
            //FieldValue = "Sale Man: " + invoicedatainfo.SaleMan;
            //g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            //// Set Order ID:
            //CurrentX = leftMargin;
            //CurrentY = CurrentY + InvoiceFontHeight;
            //FieldValue = "Invoice No: " + invoicedatainfo.InvoiceNo;
            //g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            //// Set Order Date:
            //CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            //FieldValue = "Date: " + invoicedatainfo.SaleDate;
            //g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            // Draw line:
            CurrentY = CurrentY + InvoiceFontHeight + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
        }

        private void SetInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e, InvoiceDataInfo invoicedatainfo)
        {// Set Invoice Table:
            string FieldValue = "";
            int CurrentRecord = 0;
            int RecordsPerPage = 20; // twenty items in a page
            decimal Amount = 0;
            bool StopReading = false;

            // Set Table Head:
            int xProductID = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Product ID", InvoiceFont, BlueBrush, xProductID, CurrentY);

            int xProductName = xProductID + (int)g.MeasureString("Product ID", InvoiceFont).Width + 10;
            g.DrawString("Product Name", InvoiceFont, BlueBrush, xProductName, CurrentY);

            int xUnitPrice = xProductName + (int)g.MeasureString("Product Name", InvoiceFont).Width + 152;
            g.DrawString("Unit Price", InvoiceFont, BlueBrush, xUnitPrice, CurrentY);

            int xQuantity = xUnitPrice + (int)g.MeasureString("Unit Price", InvoiceFont).Width + 4;
            g.DrawString("Quantity", InvoiceFont, BlueBrush, xQuantity, CurrentY);

            int xDiscount = xQuantity + (int)g.MeasureString("Quantity", InvoiceFont).Width + 4;
            g.DrawString("Discount", InvoiceFont, BlueBrush, xDiscount, CurrentY);

            AmountPosition = xDiscount + (int)g.MeasureString("Discount", InvoiceFont).Width + 4;
            g.DrawString("Total Price", InvoiceFont, BlueBrush, AmountPosition, CurrentY);

            // Set Invoice Table:
            CurrentY = CurrentY + InvoiceFontHeight + 8;



            foreach (var item in invoicedatainfo.invoiceitem.OrderBy(x=>x.ProductName ))
            {
                FieldValue = item.ProductId;
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductID, CurrentY);
                FieldValue = item.ProductName;
                // if Length of (Product Name) > 20, Draw 20 character only
                if (FieldValue.Length > 20)
                    FieldValue = FieldValue.Remove(20, FieldValue.Length - 20);
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductName, CurrentY);
                FieldValue = String.Format("{0:0.00}", item.Rate);
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xUnitPrice, CurrentY);
                FieldValue = item.Quantity.ToString();
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xQuantity, CurrentY);
                FieldValue = item.BillDiscount +"%";
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xDiscount, CurrentY);

                Amount = Convert.ToDecimal(item.TotalAmount);
                // Format Extended Price and Align to Right:
                FieldValue = String.Format("{0:0.00}", item.TotalAmount);
                int xAmount = AmountPosition + (int)g.MeasureString("Total Price", InvoiceFont).Width;
                xAmount = xAmount - (int)g.MeasureString(FieldValue, InvoiceFont).Width;
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xAmount, CurrentY);
                CurrentY = CurrentY + InvoiceFontHeight;




            }

            //if (CurrentRecord < RecordsPerPage)
            //    e.HasMorePages = false;
            //else
            //    e.HasMorePages = true;

            //if (StopReading)
            //{
            //    rdrInvoice.Close();
            //    cnn.Close();
            //    SetInvoiceTotal(g);
            //}
            SetInvoiceTotal(g, invoicedatainfo);
            g.Dispose();
        }

        private void SetInvoiceTotal(Graphics g, InvoiceDataInfo invoicedatainfo)
        {// Set Invoice Total:
         // Draw line:
            CurrentY = CurrentY + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
            // Get Right Edge of Invoice:
            int xRightEdg = AmountPosition + (int)g.MeasureString("Amount", InvoiceFont).Width;

            // Write Sub Total:
            int xSubTotal = AmountPosition - (int)g.MeasureString("Total Amount", InvoiceFont).Width;
            CurrentY = CurrentY + 8;
            g.DrawString("Total Amount", InvoiceFont, RedBrush, xSubTotal, CurrentY);
            string TotalValue = String.Format("{0:0.00}", invoicedatainfo.TotalAmount);
            int xTotalValue = xRightEdg - (int)g.MeasureString(TotalValue, InvoiceFont).Width;
            g.DrawString(TotalValue, InvoiceFont, BlackBrush, xTotalValue, CurrentY);

            //// Write Order Freight:
            //int xOrderFreight = AmountPosition - (int)g.MeasureString("Discount", InvoiceFont).Width;
            //CurrentY = CurrentY + InvoiceFontHeight;
            //g.DrawString("Discount", InvoiceFont, RedBrush, xOrderFreight, CurrentY);
            //string FreightValue = String.Format("{0:0.00}", invoicedatainfo.BillDiscount);
            //int xFreight = xRightEdg - (int)g.MeasureString(FreightValue, InvoiceFont).Width;
            //g.DrawString(FreightValue, InvoiceFont, BlackBrush, xFreight, CurrentY);

            //// Write Invoice Total:
            //int xInvoiceTotal = AmountPosition - (int)g.MeasureString("Invoice Total", InvoiceFont).Width;
            //CurrentY = CurrentY + InvoiceFontHeight;
            //g.DrawString("Invoice Total", InvoiceFont, RedBrush, xInvoiceTotal, CurrentY);
            //string InvoiceValue = String.Format("{0:0.00}", invoicedatainfo.GrandTotal);
            //int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
            //g.DrawString(InvoiceValue, InvoiceFont, BlackBrush, xInvoiceValue, CurrentY);
        }
        public void PrintReport()
        {
            try
            {

                if (PrinterInfo.ActivePrinterName.ToUpper().Contains("RECEIPT"))
                {
                    PrintRecipt();
                }
                else
                {
                    prnDocument.Print();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public InvoiceDataInfo Data
        {
            get
            {
                return this.invoicedatainfo;
            }
            set
            {
                this.invoicedatainfo = value;
            }
        }


    }
}
