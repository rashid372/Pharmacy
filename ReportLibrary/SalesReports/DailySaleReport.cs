namespace Telerik.Reporting.Examples.CSharp.SalesReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ProductSales.
    /// </summary>
    [Description("Profit and Loss Statement of specified period.")]
    public partial class DailySaleReport : Telerik.Reporting.Report
    {
        public DailySaleReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}