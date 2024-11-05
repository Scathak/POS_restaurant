using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        // Only allow numeric input for the Number field
        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _); // Allow only integers
        }

        // Allow numeric and specific characters for phone numbers
        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-()+]+"); // Only numbers and symbols like (), +, and -
            e.Handled = regex.IsMatch(e.Text);
        }

        // Event handler for OK button click
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            int enteredNumber = 0;
            // Validate Number field
            if (string.IsNullOrWhiteSpace(NumberTextBox.Text) || !int.TryParse(NumberTextBox.Text, out enteredNumber))
            {
                NumberErrorText.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                NumberErrorText.Visibility = Visibility.Collapsed;
            }

            // Validate First Name field
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                FirstNameErrorText.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                FirstNameErrorText.Visibility = Visibility.Collapsed;
            }

            // Validate Phone Number field
            if (!IsValidPhoneNumber(PhoneNumberTextBox.Text))
            {
                PhoneNumberErrorText.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                PhoneNumberErrorText.Visibility = Visibility.Collapsed;
            }

            // Validate Email field
            if (!IsValidEmail(EmailTextBox.Text))
            {
                EmailErrorText.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                EmailErrorText.Visibility = Visibility.Collapsed;
            }

            if (isValid)
            {
                MessageBox.Show("Data submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Create a new LabourRecord instance
                var newRecord = new LabourRecord
                {
                    Number = enteredNumber,
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Email = EmailTextBox.Text,
                    ShiftDates = ShiftDatesTextBox.Text // Store as a string (e.g., comma-separated dates)
                };

                // Add the new record to the DbContext and save changes to the database
                try
                {
                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ClearFields();
            }

        }

        // Cancel button click event to clear all fields and hide error messages
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            this.Close();
        }

        // Validate email format
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // Validate phone number format (simple check)
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, @"^[0-9-()+\s]+$");
        }

        // Clear all input fields and hide error messages
        private void ClearFields()
        {
            NumberTextBox.Clear();
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            PhoneNumberTextBox.Clear();
            EmailTextBox.Clear();
            ShiftDatesTextBox.Clear();

            // Hide error messages
            NumberErrorText.Visibility = Visibility.Collapsed;
            FirstNameErrorText.Visibility = Visibility.Collapsed;
            PhoneNumberErrorText.Visibility = Visibility.Collapsed;
            EmailErrorText.Visibility = Visibility.Collapsed;
        }

        // Event handler to hide error messages when user starts typing
        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (sender == NumberTextBox) NumberErrorText.Visibility = Visibility.Collapsed;
            if (sender == FirstNameTextBox) FirstNameErrorText.Visibility = Visibility.Collapsed;
            if (sender == PhoneNumberTextBox) PhoneNumberErrorText.Visibility = Visibility.Collapsed;
            if (sender == EmailTextBox) EmailErrorText.Visibility = Visibility.Collapsed;
        }
    }
}
