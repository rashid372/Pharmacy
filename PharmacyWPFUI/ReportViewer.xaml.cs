using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telerik.Reporting.Examples.CSharp.SalesReports;

namespace PharmacyWPFUI
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        private void DDLReportType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DDLReportType.Text.Trim() == "Profit Loss Statement")
            {
                //Telerik.Reporting.InstanceReportSource rpt = new Telerik.Reporting.InstanceReportSource();
                //rpt.ReportDocument= new DailySaleReport();
                //reportViewer1.ReportSource = rpt;
            }
            else if (DDLReportType.Text.Trim() == "Center Wise Report")
            {

            }
            else if (DDLReportType.Text.Trim() == "Absentee Validation")
            {

            }
            else if (DDLReportType.Text.Trim() == "Missing Practical Marks")
            {

            }
            else if (DDLReportType.Text.Trim() == "Shift Wise Report")
            {

            }
            else if (DDLReportType.Text.Trim() == "Overall Statistics Part-II")
            {

            }
            else if (DDLReportType.Text.Trim() == "Overall Statistics Part-I")
            {

            }
            else if (DDLReportType.Text.Trim() == "Scanning N Assessment Count Comparision")
            {

            }
            else if (DDLReportType.Text.Trim() == "RL Part-I")
            {

            }
            else if (DDLReportType.Text.Trim() == "RL Part-II")
            {

            }
            else if (DDLReportType.Text.Trim() == "Invalid Roll NO")
            {

            }
            else if (DDLReportType.Text.Trim() == "Missing Sheets")
            {

            }
            else if (DDLReportType.Text.Trim() == "Paper Code Verification Part-II")
            {

            }
            else if (DDLReportType.Text.Trim() == "Paper Code Verification Part-I")
            {

            }
            else if (DDLReportType.Text.Trim() == "Scanning Reconcilation")
            {

            }
            else if (DDLReportType.Text.Trim() == "Count MissMatch")
            {

            }
            else if (DDLReportType.Text.Trim() == "DateWise Scanning Count")
            {

            }
            else if (DDLReportType.Text.Trim() == "NON-Assessed Sheets")
            {

            }
            else if (DDLReportType.Text.Trim() == "UN-Fit Sheets Part-II")
            {

            }
            else if (DDLReportType.Text.Trim() == "UN-Fit Sheets Part-I")
            {

            }
            else if (DDLReportType.Text.Trim() == "UN-Fit batches")
            {

            }
            else if (DDLReportType.Text.Trim() == "Subject-Wise Reconcilation Part-II")
            {

            }
            else if (DDLReportType.Text.Trim() == "RollAbsenteeNotReceived")
            {

            }
            else if (DDLReportType.Text.Trim() == "Subject-Wise Report Part-II")
            {

            }
            else if (DDLReportType.Text.Trim() == "Subject-Wise Reconcilation Part-I")
            {

            }

        }

        private void SelectReport(string ReportName)
        {
        }
    }
}
