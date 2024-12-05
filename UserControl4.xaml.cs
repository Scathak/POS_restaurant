using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        // Define a custom event that passes the button content to the parent window
        public event EventHandler<string> FunctionButtonClicked;

        // Define a Dependency Property for Transparency
        public static readonly DependencyProperty TransparencyProperty =
            DependencyProperty.Register(
                nameof(Transparency),
                typeof(double),
                typeof(UserControl4),
                new PropertyMetadata(1.0, OnTransparencyChanged));
        
        // CLR Property Wrapper for Transparency
        public double Transparency
        {
            get => (double)GetValue(TransparencyProperty);
            set => SetValue(TransparencyProperty, value);
        }
        public UserControl4()
        {
            InitializeComponent();
            NumericTextBox.Focus(); // Set initial focus to the NumericTextBox
        }
        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regular expression to allow only numeric input (digits only)
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text); // If non-numeric, set Handled to true to prevent input
        }
        // Event handler for function buttons
        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Raise the event, passing the button content as the argument
                FunctionButtonClicked?.Invoke(this, button.Content.ToString());
            }
        }
        private void NumericKeysDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int cursorPosition = NumericTextBox.CaretIndex;

            if (cursorPosition > 0) // Ensure there's a character before the cursor to delete
            {
                // Remove the character before the cursor position
                NumericTextBox.Text = NumericTextBox.Text.Remove(cursorPosition - 1, 1);
                NumericTextBox.CaretIndex = cursorPosition - 1; // Move the cursor back one position
            }
        }

        private void NumericKeysButton_Click(object sender, RoutedEventArgs e)
        {
            var key = (sender as Button).Content.ToString();
            int caretIndex = NumericTextBox.CaretIndex;
            // Insert the new digit at the current caret position
            NumericTextBox.Text = NumericTextBox.Text.Insert(caretIndex, key);
            // Update the caret position to be after the inserted digit
            NumericTextBox.CaretIndex = caretIndex + 1;
        }
        // Event handler to return focus to NumericTextBox after a button is clicked
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            NumericTextBox.Focus();
        }

        // Callback for Transparency changes
        private static void OnTransparencyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UserControl4 control)
            {
                double newTransparency = (double)e.NewValue;
                control.NumericKeypad.Opacity = newTransparency;
            }
        }
    }
}
