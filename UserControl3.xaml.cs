using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace POS_restaurant
{
    /// <summary>
    /// Bottom events conveyer for Main Operations window
    /// </summary>
    public class MenuWidget
    {
        public string IconPath { get; set; } // Path to the icon image
        public string Line1Text { get; set; }
        public string Line2Text { get; set; }
        public string Line3Text { get; set; }
        public string Line1Color { get; set; } // Color as a string, e.g., #FF0000 for red
        public string Line2Color { get; set; }
        public string Line3Color { get; set; }
    }
    public partial class UserControl3 : UserControl
    {

        public List<MenuWidget> MenuWidgets { get; set; } = new List<MenuWidget>();
        public UserControl3()
        {
            InitializeComponent();
            // Sample data for testing
            MenuWidgets = new List<MenuWidget>
            {
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsOnDelivery_04.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsOnDelivery_04.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "unpaid", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "unpaid", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsNotPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1Description 1Description 1", Line3Text = "paid", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2Description 1Description 1Description 1", Line3Text = "pending", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "unpaid", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsPaid_03.png", Line1Text = "Item 2", Line2Text = "Description 2", Line3Text = "More info", Line1Color = "#0000FF", Line2Color = "#FF00FF", Line3Color = "#FFFF00" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsOnDelivery_04.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                new MenuWidget { IconPath = "pack://application:,,,/Images/OrderIsOnDelivery_04.png", Line1Text = "Item 1", Line2Text = "Description 1", Line3Text = "More info", Line1Color = "#FF0000", Line2Color = "#00FF00", Line3Color = "#0000FF" },
                // Add more items as needed
            };

            DataContext = this; // Set the DataContext for binding
        }
        // Method to scroll left
        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            MenuScrollViewer.ScrollToHorizontalOffset(MenuScrollViewer.HorizontalOffset - 50);
        }

        // Method to scroll right
        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            MenuScrollViewer.ScrollToHorizontalOffset(MenuScrollViewer.HorizontalOffset + 50);
        }

        // Method to serialize the MenuWidgets list to JSON
        private void SerializeMenuWidgets(string filePath)
        {
            var json = JsonSerializer.Serialize(MenuWidgets, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        // Method to deserialize the MenuWidgets list from JSON
        private void DeserializeMenuWidgets(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                MenuWidgets = JsonSerializer.Deserialize<List<MenuWidget>>(json);
                DataContext = null; // Reset DataContext to refresh binding
                DataContext = this;
            }
            else
            {
                MessageBox.Show("JSON file not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Example method to call serialization and deserialization
        private void SaveMenuData()
        {
            SerializeMenuWidgets("menu_data.json");
        }

        private void LoadMenuData()
        {
            DeserializeMenuWidgets("menu_data.json");
        }
    }
}
