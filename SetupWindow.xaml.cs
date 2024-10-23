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
using System.Windows.Shapes;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public SetupWindow()
        {
            InitializeComponent();
            // Set default index for the dropdowns
            ColorSchemeComboBox.SelectedIndex = 0; // Default: Light
            LanguageComboBox.SelectedIndex = 0; // Default: Turkish
            CurrencyComboBox.SelectedIndex = 0; // Default: Turk Lira
            DateTimeFormatComboBox.SelectedIndex = 0; // Default: First DateTime Format

            SoundToggleButton.Content = "Off";
        }
        // Event when the toggle button is checked (Auto Date & Time ON)
        private void AutoDateTimeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            DateTimeFormatComboBox.IsEnabled = false; // Disable DateTime format selection
        }

        // Event when the toggle button is unchecked (Auto Date & Time OFF)
        private void AutoDateTimeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            DateTimeFormatComboBox.IsEnabled = true; // Enable DateTime format selection
        }
        // Event handler for when the toggle button is checked (Sound On)
        private void SoundToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            SoundToggleButton.Content = "On"; // Change label to "On"
        }

        // Event handler for when the toggle button is unchecked (Sound Off)
        private void SoundToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SoundToggleButton.Content = "Off"; // Change label to "Off"
        }
    }
}
