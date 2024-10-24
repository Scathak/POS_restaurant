using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for LaborManagementWindow.xaml
    /// </summary>
    public partial class LaborManagementWindow : Window
    {
        // Define the list of dates and their associated colors
        private Dictionary<DateTime, Brush> coloredDates = new Dictionary<DateTime, Brush>
        {
            { new DateTime(2024, 10, 15), Brushes.LightBlue },
            { new DateTime(2024, 10, 20), Brushes.LightGreen },
            { new DateTime(2024, 10, 25), Brushes.LightPink }
        };
        public LaborManagementWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("8. Labor Management");
        }
        // Handles the calendar loaded event
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            ColorCalendarDates();
        }
        // Method to color specific dates in the Calendar
        private void ColorCalendarDates()
        {
            // Get the Calendar's CalendarDayButton elements
            foreach (var child in FindVisualChildren<CalendarDayButton>(ColorCalendar))
            {
                if (child.DataContext is DateTime date)
                {
                    if (coloredDates.ContainsKey(date))
                    {
                        // Set the background color for the specified date
                        child.Background = coloredDates[date];
                    }
                }
            }
        }

        // Helper method to find visual children of a specific type
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        // Event handler to restrict input to numbers only
        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regular expression to allow only numeric input
            Regex regex = new Regex("[^0-9]+"); // Only digits
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
