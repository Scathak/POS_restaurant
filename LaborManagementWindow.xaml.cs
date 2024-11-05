using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for labourManagementWindow.xaml
    /// </summary>
 
    public class LabourRecord
    {
        [Key]
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ShiftDates { get; set; } // Comma-separated list of shift dates
    }
    public partial class labourManagementWindow : Window
    {
        // Define the list of dates and their associated colors
        private Dictionary<DateTime, Brush> coloredDates = new Dictionary<DateTime, Brush>
        {
            { new DateTime(2024, 10, 15), Brushes.LightBlue },
            { new DateTime(2024, 10, 20), Brushes.LightGreen },
            { new DateTime(2024, 10, 25), Brushes.LightPink }
        };
        
        private LabourContext _dbContext;
        private readonly string _databasePath;
        private static labourManagementWindow _instance;

        public labourManagementWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("8. Labor Management");

            _databasePath = "LabourManagement_202410251713.db";

            // Check if the database file exists
            if (!File.Exists(_databasePath))
            {
                MessageBox.Show($"DB file not found: {_databasePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                return;
            }

            // Initialize the database context and load data
            try
            {

                _dbContext = new LabourContext(_databasePath);
                _dbContext.Database.EnsureCreated();

                // Load data into DataGrid
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The data format is wrong.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
        // Public property to get the single instance of labourManagementWindow
        public static labourManagementWindow Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new labourManagementWindow();
                }
                return _instance;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            _dbContext?.Dispose();
            base.OnClosed(e);
            _instance = null; // Clear the instance when the window is closed
        }
        private void LoadData()
        {
            try
            {
                LabourDataGrid.ItemsSource = _dbContext.LabourRecords.ToList();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("The data format is wrong.");
            }
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
        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            var key = (sender as Button).Content.ToString();
            int.TryParse(NumericTextBox.Text, out int result);
            if (key == "+") { if(result < 5) result += 1; } else { if(result > 0) result -= 1; }
            NumericTextBox.Text = result.ToString();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the MainWindow (data entry form)
            var dataEntryForm = new Window1();
            // Show the data entry form
            // Use ShowDialog to open it as a modal window
            dataEntryForm.ShowDialog();
        }
    }
}
