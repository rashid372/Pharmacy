using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalShop
{
   
    public class Printing
    {
        public Printing()
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

      private  decimal grossTotalInvoice = 0;


        // for Report:
        private int CurrentY;
        private int CurrentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;

        private int customTopMargin = 50;
        private int customRightMargin = 50;
        private int customBottomMargin = 0;
        private int customLeftMargin = 50;
        private int customCenterMargin = 150;

        private bool ReadInvoice;
        private int AmountPosition;

        // for Database:
        private SqlConnection cnn;
        private SqlCommand cmd;
        private SqlDataReader rdrInvoice;
        private string strCon;
        private string InvSql;

        // for Invoice Head:
        private string InvTitle;
        private string InvFooter;
        private string InvSubTitle1;
        private string InvSubTitle2;
        private string InvSubTitle3;
        private string InvImage;

        private List<InvoiceItemsInfo> tempList = new List<InvoiceItemsInfo>();
        // Font and Color:------------------
        // Title Font

        private Font ReciptHeadFont = new Font("Times New Roman", 16, FontStyle.Bold);
        private Font ReciptBodyFont = new Font("Times New Roman", 10, FontStyle.Italic);

        private Font InvTitleFont = new Font("Times New Roman", 20, FontStyle.Bold);
        private Font InvFooterFont = new Font("Times New Roman", 10, FontStyle.Regular);
        // Title Font height
        private int InvTitleHeight;
        // SubTitle Font
        private Font InvSubTitleFont = new Font("Times New Roman", 12, FontStyle.Regular);
        // SubTitle Font height
        private int InvSubTitleHeight;
        // Invoice Font
        private Font InvoiceFont = new Font("Times New Roman", 8, FontStyle.Regular);
        private Font InvoiceFontBold = new Font("Times New Roman", 8, FontStyle.Bold);
        // Invoice Font height
        private int InvoiceFontHeight;
        // Blue Color
        private SolidBrush BlueBrush = new SolidBrush(Color.Black);
        // Red Color
        private SolidBrush RedBrush = new SolidBrush(Color.Black);
        // Black Color
        private SolidBrush BlackBrush = new SolidBrush(Color.Black);
        private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e )
        {
            leftMargin = (int)e.MarginBounds.Left - customLeftMargin;
            rightMargin = (int)e.MarginBounds.Right + customRightMargin;
            topMargin = (int)e.MarginBounds.Top - customTopMargin;
            bottomMargin = (int)e.MarginBounds.Bottom - customBottomMargin;
            InvoiceWidth = (int)e.MarginBounds.Width;
            InvoiceHeight = (int)e.MarginBounds.Height;

            if (!ReadInvoice)
                //ReadInvoiceData();


            InvTitle = invoicedatainfo.CompanyName;
            InvSubTitle1 = invoicedatainfo.Address;
            InvSubTitle2 = invoicedatainfo.Phone;
            InvFooter = invoicedatainfo.WarrantyText;


            SetInvoiceHead(e.Graphics); // Draw Invoice Head
            SetOrderData(e.Graphics, invoicedatainfo); // Draw Order Data
            SetInvoiceData(e.Graphics, e, invoicedatainfo); // Draw Invoice Data
           // SetInvoiceFooter(e.Graphics);

            ReadInvoice = true;
        }

        private string GetReciptHead()
        {
            

            StringBuilder header = new StringBuilder();
            if (!string.IsNullOrEmpty(invoicedatainfo.CompanyName) && invoicedatainfo.CompanyName!= " ")
            {
                header.AppendLine("           "+invoicedatainfo.CompanyName);
            }
            if (!string.IsNullOrEmpty(invoicedatainfo.Address) && invoicedatainfo.Address != " ")
            {
                header.AppendLine("     "+invoicedatainfo.Address.Trim());
            }
            if (!string.IsNullOrEmpty(invoicedatainfo.Phone) && invoicedatainfo.Phone != " ")
            {
                header.AppendLine("         Phone Number : "+invoicedatainfo.Phone.Trim());
            }
            header.AppendLine(" ");
            if (!string.IsNullOrEmpty(invoicedatainfo.InvoiceNo) && invoicedatainfo.InvoiceNo != " ")
            {
                header.AppendLine("Date :"+FormateString(invoicedatainfo.SaleDate.ToString(),8) +" Invoice NO:" + FormateString(invoicedatainfo.InvoiceNo.ToString(),8));
            }
            if (!string.IsNullOrEmpty(invoicedatainfo.CustomerCode) && invoicedatainfo.CustomerCode != " ")
            {
                header.AppendLine("Customer Code :" + FormateString(invoicedatainfo.CustomerCode.ToString(),8) + "  Name : " + invoicedatainfo.CustomerName);
            }

            header.AppendLine("--------------------------------------------");
            lblReceiptHead.Text = header.ToString();
            lblReceiptHead.Font = ReciptHeadFont;
            return lblReceiptHead.Text.ToString();
        }
        private string GetReciptBody()
        {
            decimal grossTotal = 0;
            StringBuilder body = new StringBuilder();
            body.AppendLine("NAME           PRICE     QTY  DISC   TOTAL ");
            body.AppendLine("--------------------------------------------");
            if (invoicedatainfo.invoiceitem.Count > 0)
            {
                foreach (var item in invoicedatainfo.invoiceitem)
                {
                    grossTotal += item.GrossAmount;
                    if (item.ProductName.Length > 13)
                    {
                        body.AppendLine(FormateString(item.ProductName.Remove(13),14) + " " + FormateString( item.Rate.ToString(),10) + " " + FormateString(item.Quantity.ToString(), 5) + " "  + FormateString(item.BillDiscount.ToString() +"%",3) + " " + FormateString(item.TotalAmount.ToString("0.##"), 8));
                    }
                    else
                    {
                        body.AppendLine(FormateString(item.ProductName, 14) + " " + FormateString(item.Rate.ToString(), 10) + " " + FormateString(item.Quantity.ToString(), 5) + " " + FormateString(item.BillDiscount.ToString() +"%", 3) + "%" + FormateString(item.TotalAmount.ToString("0.##"), 8));
                    }
                   
                }
           
            }
            body.AppendLine("--------------------------------------------");
            if (invoicedatainfo.TotalAmount > 0 )
            {
                body.AppendLine("Gross Total  :                  " + grossTotal.ToString("0.##"));
                body.AppendLine("Discount     :                  " + (( invoicedatainfo.BillDiscount + grossTotal) - invoicedatainfo.TotalAmount).ToString("0.##"));
                body.AppendLine("Total        :                  " + invoicedatainfo.TotalAmount.ToString("0.##"));
            }
            if (invoicedatainfo.GrandTotal > 0)
            {
                body.AppendLine("Grand Total  :                  " + invoicedatainfo.GrandTotal.ToString("0.##"));
            }

            body.AppendLine("--------------------------------------------");
            body.AppendLine("Thank you for visiting at "+ ConfigurationSettings.AppSettings["Wr_CompanyName"].ToString());

            return body.ToString();
        }

        private void SetInvoiceHead(Graphics g )
        {
            //ReadInvoiceHead();
        
            CurrentY = topMargin ;
            CurrentX = leftMargin ;
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

        private void SetInvoiceFooter(Graphics g)
        {
            CurrentY = topMargin + 300;
            CurrentX = leftMargin;

            // Draw line:
            CurrentY = CurrentY + InvTitleHeight + 8;
           // g.DrawLine(new Pen(Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);

            
            InvTitleHeight = (int)(InvFooterFont.GetHeight(g));
            

            // Get Titles Length:
            int lenInvTitle = (int)g.MeasureString(InvFooter, InvFooterFont).Width;
            // Set Titles Left:
            int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;

            // Draw Invoice Head:
            if (InvFooter != "")
            {
               
                g.DrawString(InvFooter, InvFooterFont, BlueBrush, xInvTitle, CurrentY);
            }
            
        }
        private void SetOrderData(Graphics g,InvoiceDataInfo invoicedatainfo)
        {// Set Company Name, City, Salesperson, Order ID and Order Date
            string FieldValue = "";
            customCenterMargin = customCenterMargin +(InvoiceWidth / 2);
            InvoiceFontHeight = (int)(InvoiceFont.GetHeight(g));
            // Set Company Name:
            CurrentX = leftMargin;
            CurrentY = CurrentY + 8;

            FieldValue = "Customer: " + invoicedatainfo.CustomerName;
            g.DrawString(FieldValue, InvoiceFontBold, BlackBrush, CurrentX, CurrentY);
            // Set City:
            CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            FieldValue = "Customer Code: " + invoicedatainfo.CustomerCode;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, customCenterMargin, CurrentY);


            // Set Order ID:
            CurrentX = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = "Invoice #: " + invoicedatainfo.InvoiceNo;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            CurrentX = leftMargin;
            FieldValue = "Sale Man: " + invoicedatainfo.SaleMan;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, customCenterMargin, CurrentY);

            // Set Order Date:
            CurrentX = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = "Date: " + invoicedatainfo.SaleDate.Date;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
            FieldValue = "Day: " + invoicedatainfo.SaleDate.Date.DayOfWeek;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, customCenterMargin, CurrentY);

            CurrentY = CurrentY + InvoiceFontHeight + 10;
            g.DrawString("Sale Invoice", InvoiceFontBold, BlackBrush, customCenterMargin-100, CurrentY);
            // Draw line:
            CurrentY = CurrentY + InvoiceFontHeight + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
                
        }
        bool StopReading = false;
        private void SetInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e, InvoiceDataInfo invoicedatainfo)
        {// Set Invoice Table:
            string FieldValue = "";
            int CurrentRecord = 0;
            int RecordsPerPage = 30; // twenty items in a page
            decimal Amount = 0;
            

            // Set Table Head:
            int xProductID = leftMargin;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Product Code", InvoiceFontBold, BlueBrush, xProductID, CurrentY);

            int xProductName = xProductID + (int)g.MeasureString("Product Code", InvoiceFont).Width + 10;
            g.DrawString("Product Name", InvoiceFontBold, BlueBrush, xProductName, CurrentY);

            int xBatch = xProductName + (int)g.MeasureString("Product Name", InvoiceFont).Width + 152;
            g.DrawString("Batch", InvoiceFontBold, BlueBrush, xBatch, CurrentY);

            int xUnitPrice = xBatch + (int)g.MeasureString("Batch", InvoiceFont).Width + 20;
            g.DrawString("Rate", InvoiceFontBold, BlueBrush, xUnitPrice, CurrentY);


            int xQuantity = xUnitPrice + (int)g.MeasureString("Rate", InvoiceFont).Width + 15;
            g.DrawString("Qty", InvoiceFontBold, BlueBrush, xQuantity, CurrentY);

            int xDiscount = xQuantity + (int)g.MeasureString("Qty", InvoiceFont).Width + 15;
            g.DrawString("Discount", InvoiceFontBold, BlueBrush, xDiscount, CurrentY);

            int xgrossAMount= xDiscount + (int)g.MeasureString("Discount", InvoiceFont).Width + 15;
            g.DrawString("Gross", InvoiceFontBold, BlueBrush, xgrossAMount, CurrentY);

            int xlessAMount = xgrossAMount + (int)g.MeasureString("Gross", InvoiceFont).Width + 15;
            g.DrawString("Less", InvoiceFontBold, BlueBrush, xlessAMount, CurrentY);

            AmountPosition = xlessAMount + (int)g.MeasureString("Less", InvoiceFont).Width + 25;
            g.DrawString("Total Amount", InvoiceFontBold, BlueBrush, AmountPosition, CurrentY);

            // Set Invoice Table:
            CurrentY = CurrentY + InvoiceFontHeight + 8;

            int rec = (invoicedatainfo.invoiceitem.Count / RecordsPerPage);
            if (rec  > 0)
            {
                RecordsPerPage += 10;
            }

                foreach (var item in invoicedatainfo.invoiceitem.OrderBy(x => x.ProductName))
            {
                if (CurrentRecord > RecordsPerPage)
                {
                    tempList.Add(item);
                    continue;
                }
               

                FieldValue = item.ProductId;
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductID, CurrentY);
                    FieldValue = item.ProductName;
                    // if Length of (Product Name) > 20, Draw 20 character only
                    if (FieldValue.Length > 30)
                        FieldValue = FieldValue.Remove(30, FieldValue.Length - 30);
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductName, CurrentY);
                    FieldValue =  item.Batch;
                    if (FieldValue.Length > 15)
                    FieldValue = FieldValue.Remove(15, FieldValue.Length - 15);
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xBatch, CurrentY);
                    FieldValue = String.Format("{0:0.00}", item.Rate);
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xUnitPrice, CurrentY);
                    FieldValue = item.Quantity.ToString();
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xQuantity, CurrentY);
                    FieldValue =  item.BillDiscount +"%";
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xDiscount, CurrentY);

                FieldValue = (item.Rate * Convert.ToDecimal( item.Quantity)).ToString();
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xgrossAMount, CurrentY);

                FieldValue = String.Format("{0:0}", (item.Rate * Convert.ToDecimal(item.Quantity) - item.TotalAmount).ToString());
                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xlessAMount, CurrentY);

                Amount = Convert.ToDecimal(item.TotalAmount);
                    // Format Extended Price and Align to Right:
                    FieldValue = String.Format("{0:0.00}", item.TotalAmount);
                    int xAmount = AmountPosition + (int)g.MeasureString("Total Price", InvoiceFont).Width;
                    xAmount = xAmount - (int)g.MeasureString(FieldValue, InvoiceFont).Width;
                    g.DrawString(FieldValue, InvoiceFont, BlackBrush, xAmount, CurrentY);
                    CurrentY = CurrentY + InvoiceFontHeight;

                    grossTotalInvoice += item.GrossAmount;

                    CurrentRecord++;

                }

if (StopReading)
            {
                SetInvoiceTotal(g,invoicedatainfo , RecordsPerPage);
                StopReading = false;
            }


            if (CurrentRecord < RecordsPerPage)
            {
                e.HasMorePages = false;
                SetInvoiceTotal(g, invoicedatainfo, RecordsPerPage);

            } else
            {
                e.HasMorePages = true;
                invoicedatainfo.invoiceitem = tempList;
                CurrentRecord = 0;
                StopReading = true;
                tempList = new List<InvoiceItemsInfo>();
            }

          
            g.Dispose();
        }
            

        private void SetInvoiceTotal(Graphics g, InvoiceDataInfo invoicedatainfo,int RecordsPerPage)
        {
            CurrentY =InvoiceHeight -( InvoiceFontHeight * RecordsPerPage);
            CurrentX = leftMargin;
            string value = "";
            customCenterMargin = InvoiceWidth / 2;
            // Set Invoice Total:
            // Draw line:
            CurrentY = CurrentY + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
            // Get Right Edge of Invoice:
            int xRightEdg = AmountPosition + (int)g.MeasureString("Amount", InvoiceFont).Width;


            // Write Gross Total:
            CurrentY = CurrentY + 8;
            CurrentX = leftMargin;
            string GrossValue = String.Format("{0:0.00}", grossTotalInvoice);
            value = "Gross Total : " + GrossValue;
            g.DrawString(value, InvoiceFontBold, RedBrush, CurrentX, CurrentY);

            // Write Discount:
            CurrentX = CurrentX + customCenterMargin;
            string discountValue = String.Format("{0:0.00}", invoicedatainfo.BillDiscount + (grossTotalInvoice - invoicedatainfo.TotalAmount));
            value = "Discount : " + discountValue;
            g.DrawString(value, InvoiceFontBold, RedBrush, CurrentX, CurrentY);

            // Write Sub Total:
            int xSubTotal = AmountPosition - (int)g.MeasureString("Sub Total", InvoiceFont).Width ;
           // CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Sub Total", InvoiceFontBold, RedBrush, xSubTotal, CurrentY);
            string TotalValue = String.Format("{0:0.00}", invoicedatainfo.TotalAmount);
            int xTotalValue = xRightEdg - (int)g.MeasureString(TotalValue, InvoiceFont).Width + 20;
            g.DrawString(TotalValue, InvoiceFontBold, BlackBrush, xTotalValue, CurrentY);

            // Write Previous:
            CurrentY = CurrentY + InvoiceFontHeight;
            CurrentX = leftMargin;
            string prevoiusValue = String.Format("{0:0.00}", 0.0);
            value = "Previous : " + prevoiusValue;
            g.DrawString(value, InvoiceFontBold, RedBrush, CurrentX, CurrentY);




            // Write Invoice Total:
            int xInvoiceTotal = AmountPosition - (int)g.MeasureString("Net Total", InvoiceFont).Width;
            
            g.DrawString("Net Total", InvoiceFontBold, RedBrush, xInvoiceTotal, CurrentY);
            string InvoiceValue = String.Format("{0:0.00}", invoicedatainfo.GrandTotal);
            int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width + 20;
            g.DrawString(InvoiceValue, InvoiceFontBold, BlackBrush, xInvoiceValue, CurrentY);

            // Draw line:
            CurrentY = CurrentY + InvoiceFontHeight + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);


            if (invoicedatainfo.WarrantyText !=string.Empty)
            {
                int xWarranty = leftMargin;
                CurrentY = CurrentY + InvoiceFontHeight +10;
               // g.DrawString("Warranty", InvFooterFont, RedBrush, xWarranty, CurrentY);
                string WarrantyValue = invoicedatainfo.WarrantyText;
                //  int xWarrantyValue = xRightEdg - (int)g.MeasureString(WarrantyValue, InvFooterFont).Width;
                // int xWarrantyValue = xWarranty + (int)g.MeasureString("Warranty", InvFooterFont).Width;
                int xWarrantyValue = xWarranty;
                g.DrawString(WarrantyValue, InvFooterFont, BlackBrush, xWarrantyValue, CurrentY);
            }

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

        public void PrintRecipt()
        {
            if (!linePrint.Open("Invoice")) return;
            // string test = GetReciptHead() + GetReciptBody();
            linePrint.Print("Start");
            linePrint.Print(GetReciptHead());
            linePrint.Print(GetReciptBody());
            linePrint.Close();
        }

        private string FormateString(string value,int length)
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
