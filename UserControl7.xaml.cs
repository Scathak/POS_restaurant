using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for UserControl7.xaml
    /// </summary>
    public partial class UserControl7 : UserControl
    {
        // Define a custom event for button value retrieval
        public event EventHandler<string> ButtonPressed;

        // English Layout
        private readonly List<string> EnglishKeys = new List<string>
        {
            "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P",
            "A", "S", "D", "F", "G", "H", "J", "K", "L", "@",
            "Z", "X", "C", "V", "B", "N", "M", ".", ",", "?",
            "Space", "Backspace", "Enter", "123", "!","#","$","%","^","&"
        };

        // Turkish Layout
        private readonly List<string> TurkishKeys = new List<string>
        {
            "Q", "W", "E", "R", "T", "Y", "U", "İ", "O", "P",
            "A", "S", "D", "F", "G", "H", "J", "K", "L", "Ş",
            "Z", "X", "C", "V", "B", "N", "M", "Ö", "Ç", "Ğ",
            "Space", "Backspace", "Enter", "123", "!","#","$","%","^","&"
        };

        public UserControl7()
        {
            InitializeComponent();
            SetEnglishLayout(null, null); // Default to English Layout
        }

        // Event handler for English Layout
        private void SetEnglishLayout(object sender, RoutedEventArgs e)
        {
            LoadKeyboardLayout(EnglishKeys);
        }

        // Event handler for Turkish Layout
        private void SetTurkishLayout(object sender, RoutedEventArgs e)
        {
            LoadKeyboardLayout(TurkishKeys);
        }

        // Load keyboard layout dynamically
        private void LoadKeyboardLayout(List<string> layout)
        {
            KeyboardGrid.Children.Clear();

            foreach (var key in layout)
            {
                var button = new Button
                {
                    Content = key,
                    Width = 80,
                    Height = 80,
                    Margin = new Thickness(5),
                    FontSize = 20,
                    Background = key == "Space" ? Brushes.LightBlue : Brushes.LightGray,
                    Tag = key // Store the key value in the Tag
                };

                button.Click += KeyboardButton_Click;
                KeyboardGrid.Children.Add(button);
            }
        }

        // Handle button clicks
        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string value = button.Tag.ToString();
                ButtonPressed?.Invoke(this, value); // Trigger the ButtonPressed event
            }
        }
    }
}
