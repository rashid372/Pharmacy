namespace CSharp.WpfDemo
{
    using System;
    using System.Windows;
    using Telerik.Windows.Controls;

    public partial class Window1 : Window
    {
        static readonly string[] dictionaries = new [] 
            { 
                "Themes/{0}/System.Windows.xaml",
                "Themes/{0}/Telerik.Windows.Controls.xaml",
                "Themes/{0}/Telerik.Windows.Controls.Input.xaml",
                "Themes/{0}/Telerik.Windows.Controls.Navigation.xaml",
                "Themes/{0}/Telerik.ReportViewer.Wpf.xaml"
            };

        public Window1()
        {
            InitializeComponent();

        }

        void ThemeSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = (RadComboBoxItem)((RadComboBox)sender).SelectedItem;
            var themeNameParts = ((string)selectedItem.Content).Split('_');

            MergeResourceDictionaries(themeNameParts[0]);
            
            if(themeNameParts.Length > 1)
            {
                switch(themeNameParts[0])
                {
                    case "VisualStudio2013":
                        VisualStudio2013Palette.LoadPreset((VisualStudio2013Palette.ColorVariation)GetPresetEnum(typeof(VisualStudio2013Palette.ColorVariation), themeNameParts[1]));
                        break;
                    case "Office2013":
                        Office2013Palette.LoadPreset((Office2013Palette.ColorVariation)GetPresetEnum(typeof(Office2013Palette.ColorVariation), themeNameParts[1]));
                        break;
                    case "Green":
                        GreenPalette.LoadPreset((GreenPalette.ColorVariation)GetPresetEnum(typeof(GreenPalette.ColorVariation), themeNameParts[1]));
                        break;
                }
            }
        }

        object GetPresetEnum (Type enumeration, string colorVariation)
        {
            return Enum.Parse(enumeration, colorVariation); 
        }

        static void MergeResourceDictionaries(string theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();
            foreach (var dictionary in dictionaries)
            {
                var uri = string.Format(dictionary, theme);
                mergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(uri, UriKind.RelativeOrAbsolute)
                });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            var typeReportSource = new Telerik.Reporting.TypeReportSource();
          //  typeReportSource.TypeName = "Telerik.Reporting.Examples.CSharp.SalesReports.DailySaleReport, CSharp.ReportLibrary";
            typeReportSource.TypeName = "Telerik.Reporting.Examples.CSharp.ReportCatalog, CSharp.ReportLibrary";
            this.ReportViewer1.ReportSource = typeReportSource;
        }
    }
}
