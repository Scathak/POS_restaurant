using System.Windows;
using System.Windows.Input;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for ReportingAnalyticsWindow.xaml
    /// </summary>
    public partial class ReportingAnalyticsWindow : Window
    {
        public ReportingAnalyticsWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("10. Reporting and analytics");
        }
        private void AnalyticalPanel_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Widget clicked: Showing details about Sales Data Analysis.");
        }
    }
}
