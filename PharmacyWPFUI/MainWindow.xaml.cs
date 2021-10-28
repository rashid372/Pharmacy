using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PharmacyWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Link_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)e.Source;

            string reportName = btn.Content.ToString();
            ReportViewer rv = new ReportViewer();
            rv.Show();
            switch (reportName)
            {
                //// statistical reports
                //case "District-Wise Pass Percentage":

                //    Worker.RunWorkerAsync(reportName);


                //    break;
                //case "Institute-Wise Pass Percentage":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Group-Wise Pass Percentage":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Subject-Wise Pass Percentage":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "General Pass Percentage":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Item Analysis":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Item Difficulty":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Standard Deviation":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Correlation":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Mean Value":
                //    Worker.RunWorkerAsync(reportName);
                //    break;



                //// Operational  reports

                //case "Center-Wise Absentee":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Subject-Wise Absentee":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Black List of Regular Students":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Practical Absentee":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Notification Discrepancies":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Award Part Discrepancies":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Roll Part Discrepancies":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Practical Award Discrepances":
                //    Worker.RunWorkerAsync(reportName);
                //    break;

                //// Result reports

                //case "Paper-Wise Result":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Subject-Wise Result":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Result Sheet":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Result Gazzate":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Result Card":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Cancelled/Un-Alloted":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Eligibility Cases":
                //    Worker.RunWorkerAsync(reportName);
                //    break;
                //case "Over All Top Positions":
                //    var TopPositionsList = PCGAccessor.GetGeneralPassPercent();
                //    Worker.RunWorkerAsync(reportName);
                //    break;


            }

            //radBusyIndicator.BusyContent = "Report : " + reportName + " Loading....";
            //radBusyIndicator.IsBusy = Worker.IsBusy;

        }
    }
}
