using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenLoginWindow(this, null);
        }
        private void OpenLoginWindow(object sender, RoutedEventArgs e)
        {
            LoginLogoutWindow loginWindow = new LoginLogoutWindow();
            loginWindow.Show();
            this.Close();
        }
        private void OpenFoodInventory(object sender, RoutedEventArgs e)
        {
            FoodInventoryWindow foodInventory = new FoodInventoryWindow();
            foodInventory.Show();
            this.Close();
        }
        private void OpenComplinmentaryInventory(object sender, RoutedEventArgs e)
        {
            ComplimentaryInventoryWindow complementaryInventory = new ComplimentaryInventoryWindow();
            complementaryInventory.Show();
            this.Close();
        }
        private void OpenGiftLoyalty(object sender, RoutedEventArgs e)
        {
            GiftLoyaltyWindow giftLoyalty = new GiftLoyaltyWindow();
            giftLoyalty.Show();
            this.Close();
        }
        private void OpenLaborManagement(object sender, RoutedEventArgs e)
        {
            LaborManagementWindow laborManagement = new LaborManagementWindow();
            laborManagement.Show();
            this.Close();
        }
        private void OpenAccountTracking(object sender, RoutedEventArgs e)
        {
            AccountTrackingWindow accountTracking = new AccountTrackingWindow();
            accountTracking.Show();
            this.Close();
        }
        private void OpenMenuManagement(object sender, RoutedEventArgs e)
        {
            MenuManagementWindow menuManagement = new MenuManagementWindow();
            menuManagement.Show();
            this.Close();
        }
        private void OpenPaymentsWindow(object sender, RoutedEventArgs e)
        {
            PaymentsWindow payments = new PaymentsWindow();
            payments.Show();
            this.Close();
        }
        private void OpenReportingAnalyticsWindow(object sender, RoutedEventArgs e)
        {
            ReportingAnalyticsWindow reportingAnalytics = new ReportingAnalyticsWindow();
            reportingAnalytics.Show();
            this.Close();
        }
        private void OpenSetupWindow(object sender, RoutedEventArgs e)
        {
            SetupWindow setup = new SetupWindow();
            setup.Show();
            this.Close();
        }
    }
}