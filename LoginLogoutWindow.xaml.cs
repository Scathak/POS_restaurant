using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for LoginLogoutWindow.xaml
    /// </summary>
    public partial class LoginLogoutWindow : Window
    {
        public LoginLogoutWindow()
        {
            InitializeComponent();

            // Start timer to update the clock
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => CurrentDateTime.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
            timer.Start();
        }
        private void KeyCommand(object sender, RoutedEventArgs e)
        {
            var key = (sender as Button).Content.ToString();
            //LoginTextBox.Text += key;
        }
        // Event handler for restricting input to numeric only
        private void PasswordTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regular expression to allow only numeric input (digits only)
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text); // If non-numeric, set Handled to true to prevent input
        }
        private void ClearCommand(object sender, RoutedEventArgs e)
        {
            //LoginTextBox.Text = string.Empty;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic for logging in
            MainOperations MainOperations = new MainOperations();
            MainOperations.Show();
            this.Close();
        }
        private void LoginCommand(object sender, RoutedEventArgs e)
        {
            // Add authentication logic here
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
