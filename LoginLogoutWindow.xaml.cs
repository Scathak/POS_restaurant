using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
            
            InitTimeDate();

            // Event listerner for a numeric pad
            NumericButtons.FunctionButtonClicked += NumericButtons_FunctionButtonClicked;
        }
        private void InitTimeDate()
        {
            // Set time on the screen first time
            CurrentDateTime.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
            // Start timer to update the clock
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => CurrentDateTime.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
            timer.Start();
        }
        private void NumericButtons_FunctionButtonClicked(object sender, string buttonContent)
        {
            switch (buttonContent)
            {
                case "Enter":
                    LoginCommand(sender, null);
                    break;
                default:
                    MessageBox.Show($"Unhandled function: {buttonContent}");
                    break;
            }
        }
        private void LoginCommand(object sender, RoutedEventArgs e)
        {
            if (NumericButtons.NumericTextBox.Text == "0000")
            {
                var loginLogoutWindow = new MainOperationsWindow();
                loginLogoutWindow.Show();
                Window.GetWindow(this).Close();
            }
        }
    }
}
