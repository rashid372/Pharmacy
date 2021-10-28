namespace Telerik.Reporting.Examples.CSharp.SalesReports
{
    partial class DailySaleReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.productNameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.batchNameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.purchaseRateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.rateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.discountCaptionTextBox = new Telerik.Reporting.TextBox();
            this.qtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.profitCaptionTextBox = new Telerik.Reporting.TextBox();
            this.totalCaptionTextBox = new Telerik.Reporting.TextBox();
            this.DSDate = new Telerik.Reporting.SqlDataSource();
            this.DSDailySaleReport = new Telerik.Reporting.SqlDataSource();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.batchNameCountFunctionTextBox = new Telerik.Reporting.TextBox();
            this.purchaseRateSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.rateSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.discountSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.qtySumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.profitSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.totalSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.productNameDataTextBox = new Telerik.Reporting.TextBox();
            this.batchNameDataTextBox = new Telerik.Reporting.TextBox();
            this.purchaseRateDataTextBox = new Telerik.Reporting.TextBox();
            this.rateDataTextBox = new Telerik.Reporting.TextBox();
            this.discountDataTextBox = new Telerik.Reporting.TextBox();
            this.qtyDataTextBox = new Telerik.Reporting.TextBox();
            this.profitDataTextBox = new Telerik.Reporting.TextBox();
            this.totalDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productNameCaptionTextBox,
            this.batchNameCaptionTextBox,
            this.purchaseRateCaptionTextBox,
            this.rateCaptionTextBox,
            this.discountCaptionTextBox,
            this.qtyCaptionTextBox,
            this.profitCaptionTextBox,
            this.totalCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // productNameCaptionTextBox
            // 
            this.productNameCaptionTextBox.CanGrow = true;
            this.productNameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.productNameCaptionTextBox.Name = "productNameCaptionTextBox";
            this.productNameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.productNameCaptionTextBox.Style.Font.Bold = true;
            this.productNameCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.productNameCaptionTextBox.StyleName = "Caption";
            this.productNameCaptionTextBox.Value = "Product";
            // 
            // batchNameCaptionTextBox
            // 
            this.batchNameCaptionTextBox.CanGrow = true;
            this.batchNameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0464854240417481D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.batchNameCaptionTextBox.Name = "batchNameCaptionTextBox";
            this.batchNameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.batchNameCaptionTextBox.Style.Font.Bold = true;
            this.batchNameCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.batchNameCaptionTextBox.StyleName = "Caption";
            this.batchNameCaptionTextBox.Value = "Batch";
            // 
            // purchaseRateCaptionTextBox
            // 
            this.purchaseRateCaptionTextBox.CanGrow = true;
            this.purchaseRateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.0721375942230225D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.purchaseRateCaptionTextBox.Name = "purchaseRateCaptionTextBox";
            this.purchaseRateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.purchaseRateCaptionTextBox.Style.Font.Bold = true;
            this.purchaseRateCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.purchaseRateCaptionTextBox.StyleName = "Caption";
            this.purchaseRateCaptionTextBox.Value = "Purchase Rate";
            // 
            // rateCaptionTextBox
            // 
            this.rateCaptionTextBox.CanGrow = true;
            this.rateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0977895259857178D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.rateCaptionTextBox.Name = "rateCaptionTextBox";
            this.rateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.rateCaptionTextBox.Style.Font.Bold = true;
            this.rateCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.rateCaptionTextBox.StyleName = "Caption";
            this.rateCaptionTextBox.Value = "Sale Rate";
            // 
            // discountCaptionTextBox
            // 
            this.discountCaptionTextBox.CanGrow = true;
            this.discountCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1234416961669922D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.discountCaptionTextBox.Name = "discountCaptionTextBox";
            this.discountCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.discountCaptionTextBox.Style.Font.Bold = true;
            this.discountCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.discountCaptionTextBox.StyleName = "Caption";
            this.discountCaptionTextBox.Value = "Discount";
            // 
            // qtyCaptionTextBox
            // 
            this.qtyCaptionTextBox.CanGrow = true;
            this.qtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1490936279296875D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qtyCaptionTextBox.Name = "qtyCaptionTextBox";
            this.qtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qtyCaptionTextBox.Style.Font.Bold = true;
            this.qtyCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.qtyCaptionTextBox.StyleName = "Caption";
            this.qtyCaptionTextBox.Value = "Quantity";
            // 
            // profitCaptionTextBox
            // 
            this.profitCaptionTextBox.CanGrow = true;
            this.profitCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.1747455596923828D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.profitCaptionTextBox.Name = "profitCaptionTextBox";
            this.profitCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.profitCaptionTextBox.Style.Font.Bold = true;
            this.profitCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.profitCaptionTextBox.StyleName = "Caption";
            this.profitCaptionTextBox.Value = "Profit";
            // 
            // totalCaptionTextBox
            // 
            this.totalCaptionTextBox.CanGrow = true;
            this.totalCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.2003979682922363D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.totalCaptionTextBox.Name = "totalCaptionTextBox";
            this.totalCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.totalCaptionTextBox.Style.Font.Bold = true;
            this.totalCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.totalCaptionTextBox.StyleName = "Caption";
            this.totalCaptionTextBox.Value = "Total";
            // 
            // DSDate
            // 
            this.DSDate.ConnectionString = "Telerik.Reporting.Examples.CSharp.Properties.Settings.Pharmacy";
            this.DSDate.Name = "DSDate";
            this.DSDate.SelectCommand = "dbo.DateCounterSale";
            this.DSDate.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // DSDailySaleReport
            // 
            this.DSDailySaleReport.ConnectionString = "Telerik.Reporting.Examples.CSharp.Properties.Settings.Pharmacy";
            this.DSDailySaleReport.Name = "DSDailySaleReport";
            this.DSDailySaleReport.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@fromdate", System.Data.DbType.DateTime, "= Parameters.fromdate.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@todate", System.Data.DbType.DateTime, "= Parameters.todate.Value")});
            this.DSDailySaleReport.SelectCommand = "dbo.SalesAndCounterSalesReportForAll";
            this.DSDailySaleReport.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.batchNameCountFunctionTextBox,
            this.purchaseRateSumFunctionTextBox,
            this.rateSumFunctionTextBox,
            this.discountSumFunctionTextBox,
            this.qtySumFunctionTextBox,
            this.profitSumFunctionTextBox,
            this.totalSumFunctionTextBox});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = true;
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Grand total:";
            // 
            // batchNameCountFunctionTextBox
            // 
            this.batchNameCountFunctionTextBox.CanGrow = true;
            this.batchNameCountFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0464854240417481D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.batchNameCountFunctionTextBox.Name = "batchNameCountFunctionTextBox";
            this.batchNameCountFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.batchNameCountFunctionTextBox.Style.Font.Bold = true;
            this.batchNameCountFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.batchNameCountFunctionTextBox.StyleName = "Data";
            this.batchNameCountFunctionTextBox.Value = "= Count(Fields.batchName)";
            // 
            // purchaseRateSumFunctionTextBox
            // 
            this.purchaseRateSumFunctionTextBox.CanGrow = true;
            this.purchaseRateSumFunctionTextBox.Format = "{0:0.00 }";
            this.purchaseRateSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.0721375942230225D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.purchaseRateSumFunctionTextBox.Name = "purchaseRateSumFunctionTextBox";
            this.purchaseRateSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.purchaseRateSumFunctionTextBox.Style.Font.Bold = true;
            this.purchaseRateSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.purchaseRateSumFunctionTextBox.StyleName = "Data";
            this.purchaseRateSumFunctionTextBox.Value = "= Sum(Fields.purchaseRate)";
            // 
            // rateSumFunctionTextBox
            // 
            this.rateSumFunctionTextBox.CanGrow = true;
            this.rateSumFunctionTextBox.Format = "{0:0.00 }";
            this.rateSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0977895259857178D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.rateSumFunctionTextBox.Name = "rateSumFunctionTextBox";
            this.rateSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.rateSumFunctionTextBox.Style.Font.Bold = true;
            this.rateSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.rateSumFunctionTextBox.StyleName = "Data";
            this.rateSumFunctionTextBox.Value = "= Sum(Fields.rate)";
            // 
            // discountSumFunctionTextBox
            // 
            this.discountSumFunctionTextBox.CanGrow = true;
            this.discountSumFunctionTextBox.Format = "{0:0.00 }";
            this.discountSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1234416961669922D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.discountSumFunctionTextBox.Name = "discountSumFunctionTextBox";
            this.discountSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.discountSumFunctionTextBox.Style.Font.Bold = true;
            this.discountSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.discountSumFunctionTextBox.StyleName = "Data";
            this.discountSumFunctionTextBox.Value = "= Sum(Fields.discount)";
            // 
            // qtySumFunctionTextBox
            // 
            this.qtySumFunctionTextBox.CanGrow = true;
            this.qtySumFunctionTextBox.Format = "{0:0.00 }";
            this.qtySumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1490936279296875D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qtySumFunctionTextBox.Name = "qtySumFunctionTextBox";
            this.qtySumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qtySumFunctionTextBox.Style.Font.Bold = true;
            this.qtySumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.qtySumFunctionTextBox.StyleName = "Data";
            this.qtySumFunctionTextBox.Value = "= Sum(Fields.qty)";
            // 
            // profitSumFunctionTextBox
            // 
            this.profitSumFunctionTextBox.CanGrow = true;
            this.profitSumFunctionTextBox.Format = "{0:0.00 }";
            this.profitSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.1747455596923828D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.profitSumFunctionTextBox.Name = "profitSumFunctionTextBox";
            this.profitSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.profitSumFunctionTextBox.Style.Font.Bold = true;
            this.profitSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.profitSumFunctionTextBox.StyleName = "Data";
            this.profitSumFunctionTextBox.Value = "= Sum(Fields.Profit)";
            // 
            // totalSumFunctionTextBox
            // 
            this.totalSumFunctionTextBox.CanGrow = true;
            this.totalSumFunctionTextBox.Format = "{0:0.00 }";
            this.totalSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.2003979682922363D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.totalSumFunctionTextBox.Name = "totalSumFunctionTextBox";
            this.totalSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.totalSumFunctionTextBox.Style.Font.Bold = true;
            this.totalSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.totalSumFunctionTextBox.StyleName = "Data";
            this.totalSumFunctionTextBox.Value = "= Sum(Fields.Total)";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0817751884460449D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1234416961669922D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0817751884460449D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.49999997019767761D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.22605037689209D), Telerik.Reporting.Drawing.Unit.Inch(0.49999997019767761D));
            this.titleTextBox.Style.Font.Bold = true;
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Sale Profit / Loss Statement";
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= Fields.Profit", Telerik.Reporting.FilterOperator.LessThan, "1"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22083334624767304D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productNameDataTextBox,
            this.batchNameDataTextBox,
            this.purchaseRateDataTextBox,
            this.rateDataTextBox,
            this.discountDataTextBox,
            this.qtyDataTextBox,
            this.profitDataTextBox,
            this.totalDataTextBox});
            this.detail.Name = "detail";
            // 
            // productNameDataTextBox
            // 
            this.productNameDataTextBox.CanGrow = true;
            this.productNameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.productNameDataTextBox.Name = "productNameDataTextBox";
            this.productNameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.productNameDataTextBox.Style.Font.Bold = true;
            this.productNameDataTextBox.Style.Font.Italic = false;
            this.productNameDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.productNameDataTextBox.StyleName = "Data";
            this.productNameDataTextBox.Value = "= Fields.productName";
            // 
            // batchNameDataTextBox
            // 
            this.batchNameDataTextBox.CanGrow = true;
            this.batchNameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0464854240417481D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.batchNameDataTextBox.Name = "batchNameDataTextBox";
            this.batchNameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.batchNameDataTextBox.Style.Font.Bold = true;
            this.batchNameDataTextBox.Style.Font.Italic = false;
            this.batchNameDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.batchNameDataTextBox.StyleName = "Data";
            this.batchNameDataTextBox.Value = "= Fields.batchName";
            // 
            // purchaseRateDataTextBox
            // 
            this.purchaseRateDataTextBox.CanGrow = true;
            this.purchaseRateDataTextBox.Format = "{0:0.00 }";
            this.purchaseRateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.0721375942230225D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.purchaseRateDataTextBox.Name = "purchaseRateDataTextBox";
            this.purchaseRateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.purchaseRateDataTextBox.Style.Font.Bold = true;
            this.purchaseRateDataTextBox.Style.Font.Italic = false;
            this.purchaseRateDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.purchaseRateDataTextBox.StyleName = "Data";
            this.purchaseRateDataTextBox.Value = "= Fields.purchaseRate";
            // 
            // rateDataTextBox
            // 
            this.rateDataTextBox.CanGrow = true;
            this.rateDataTextBox.Format = "{0:0.00 }";
            this.rateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0977895259857178D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.rateDataTextBox.Name = "rateDataTextBox";
            this.rateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.rateDataTextBox.Style.Font.Bold = true;
            this.rateDataTextBox.Style.Font.Italic = false;
            this.rateDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.rateDataTextBox.StyleName = "Data";
            this.rateDataTextBox.Value = "= Fields.rate";
            // 
            // discountDataTextBox
            // 
            this.discountDataTextBox.CanGrow = true;
            this.discountDataTextBox.Format = "{0:0.00 }";
            this.discountDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1234416961669922D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.discountDataTextBox.Name = "discountDataTextBox";
            this.discountDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.discountDataTextBox.Style.Font.Bold = true;
            this.discountDataTextBox.Style.Font.Italic = false;
            this.discountDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.discountDataTextBox.StyleName = "Data";
            this.discountDataTextBox.Value = "= Fields.discount";
            // 
            // qtyDataTextBox
            // 
            this.qtyDataTextBox.CanGrow = true;
            this.qtyDataTextBox.Format = "{0:0}";
            this.qtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1490936279296875D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qtyDataTextBox.Name = "qtyDataTextBox";
            this.qtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qtyDataTextBox.Style.Font.Bold = true;
            this.qtyDataTextBox.Style.Font.Italic = false;
            this.qtyDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.qtyDataTextBox.StyleName = "Data";
            this.qtyDataTextBox.Value = "= Fields.qty";
            // 
            // profitDataTextBox
            // 
            this.profitDataTextBox.CanGrow = true;
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= Fields.Profit", Telerik.Reporting.FilterOperator.LessThan, "01"));
            formattingRule2.Style.BackgroundColor = System.Drawing.Color.Red;
            formattingRule2.Style.Color = System.Drawing.Color.Black;
            formattingRule2.Style.Font.Italic = true;
            formattingRule2.Style.Font.Underline = true;
            this.profitDataTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.profitDataTextBox.Format = "{0:N2}";
            this.profitDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.1747455596923828D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.profitDataTextBox.Name = "profitDataTextBox";
            this.profitDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.profitDataTextBox.Style.Font.Bold = true;
            this.profitDataTextBox.Style.Font.Italic = false;
            this.profitDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.profitDataTextBox.StyleName = "Data";
            this.profitDataTextBox.Value = "= Fields.Profit";
            // 
            // totalDataTextBox
            // 
            this.totalDataTextBox.CanGrow = true;
            this.totalDataTextBox.Format = "{0:0.00 RS}";
            this.totalDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.2003979682922363D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.totalDataTextBox.Name = "totalDataTextBox";
            this.totalDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0048187971115112D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.totalDataTextBox.Style.Font.Bold = true;
            this.totalDataTextBox.Style.Font.Italic = false;
            this.totalDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.totalDataTextBox.StyleName = "Data";
            this.totalDataTextBox.Value = "= Fields.Total";
            // 
            // DailySaleReport
            // 
            this.DataSource = this.DSDailySaleReport;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.reportFooter,
            this.pageFooter,
            this.reportHeader,
            this.detail});
            this.Name = "DailySaleReport";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AvailableValues.DataSource = this.DSDate;
            reportParameter1.AvailableValues.DisplayMember = "= Fields.date";
            reportParameter1.AvailableValues.ValueMember = "= Fields.date.Date";
            reportParameter1.Name = "fromdate";
            reportParameter1.Text = "From";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter1.Visible = true;
            reportParameter2.AvailableValues.DataSource = this.DSDate;
            reportParameter2.AvailableValues.DisplayMember = "= Fields.date";
            reportParameter2.AvailableValues.ValueMember = "= Fields.date";
            reportParameter2.Name = "todate";
            reportParameter2.Text = "To";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule3.Style.Color = System.Drawing.Color.White;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Color = System.Drawing.Color.Black;
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Color = System.Drawing.Color.Black;
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(8.22605037689209D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private SqlDataSource DSDailySaleReport;
        private SqlDataSource DSDate;
        private GroupHeaderSection labelsGroupHeaderSection;
        private TextBox productNameCaptionTextBox;
        private TextBox batchNameCaptionTextBox;
        private TextBox purchaseRateCaptionTextBox;
        private TextBox rateCaptionTextBox;
        private TextBox discountCaptionTextBox;
        private TextBox qtyCaptionTextBox;
        private TextBox profitCaptionTextBox;
        private TextBox totalCaptionTextBox;
        private GroupFooterSection labelsGroupFooterSection;
        private ReportFooterSection reportFooter;
        private TextBox textBox1;
        private TextBox batchNameCountFunctionTextBox;
        private TextBox purchaseRateSumFunctionTextBox;
        private TextBox rateSumFunctionTextBox;
        private TextBox discountSumFunctionTextBox;
        private TextBox qtySumFunctionTextBox;
        private TextBox profitSumFunctionTextBox;
        private TextBox totalSumFunctionTextBox;
        private PageFooterSection pageFooter;
        private TextBox currentTimeTextBox;
        private TextBox pageInfoTextBox;
        private ReportHeaderSection reportHeader;
        private TextBox titleTextBox;
        private DetailSection detail;
        private TextBox productNameDataTextBox;
        private TextBox batchNameDataTextBox;
        private TextBox purchaseRateDataTextBox;
        private TextBox rateDataTextBox;
        private TextBox discountDataTextBox;
        private TextBox qtyDataTextBox;
        private TextBox profitDataTextBox;
        private TextBox totalDataTextBox;
    }
}