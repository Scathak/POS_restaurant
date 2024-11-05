using System.Windows;
using System.Windows.Controls;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        // Navigation button click event handlers
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainOperations();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void FoodInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var foodInventoryWindow = new FoodInventoryWindow();
            foodInventoryWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void ComplimentaryInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var fomplimentaryInventoryWindow = new ComplimentaryInventoryWindow();
            fomplimentaryInventoryWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void AccountTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            var accountTrackingWindow = new AccountTrackingWindow();
            accountTrackingWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void GiftLoyaltyButton_Click(object sender, RoutedEventArgs e)
        {
            var giftLoyaltyWindow = new GiftLoyaltyWindow();
            giftLoyaltyWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void PaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            var paymentsWindow = new PaymentsWindow();
            paymentsWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void MenuManagementButton_Click(object sender, RoutedEventArgs e)
        {
            var menuManagementWindow = new MenuManagementWindow();
            menuManagementWindow.Show();
            Window.GetWindow(this).Close();
        }
        
        private void labourManagementButton_Click(object sender, RoutedEventArgs e)
        {
            var labourManagementWindow = new labourManagementWindow();
            labourManagementWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void SetupWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var setupWindow = new SetupWindow();
            setupWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void ReportingAnalytics_Click(object sender, RoutedEventArgs e)
        {
            var reportingAnalyticsWindow = new ReportingAnalyticsWindow();
            reportingAnalyticsWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginLogoutWindow = new LoginLogoutWindow();
            loginLogoutWindow.Show();
            Window.GetWindow(this).Close();
        }
        



    }
}
