using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for MainOperationsWindow.xaml
    /// </summary>
    public class SerializableShape
    {
        public string ShapeType { get; set; } // "Rectangle", "Ellipse", "TextBox" or "Triangle"
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string FillColor { get; set; } // Color in hex format
        public string Text { get; set; } // Only for TextBox
        public string StrokeColor { get; set; } // Default stroke color is black
        public double StrokeThickness { get; set; }
        // Only for Triangle
        public PointCollection PointsCollection { get; set; } = new PointCollection(new Point[]
        {
            new Point(0, 0),  // Top
            new Point(0, 0), // Bottom Left
            new Point(0, 0) // Bottom Right
        });
        public SerializableShape() { }
    }

    /// <summary>
    /// Represents the different types of payment methods.
    /// </summary>
    public enum PaymentTypes
    {
        Cash,
        BankCard,
        MoneyTransfer,
        ForeignCurrency,
        DeferredPayment,
        CryptoCurrency,
        Paid,
    }
    public class DeliverySpecification
    {
        public string Address;
        public int Weight;
        public string StartTime;
        public string EndTime;
        public string Contactnumber;
        public PaymentTypes PaymentType;
        public string Notes;
    }
    public class MainOperationsRecord
    {
        [Key]
        public int OperationNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int Table { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DeliverySpecification? Delivery { get; set; }
    }
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class MainOperationsWindow : Window
    {
        public ObservableCollection<MainOperationsRecord> Collection { get; set; }

        public MainOperationsWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("1. Main Operations");

            //NumericTextBox.Focus(); // Set initial focus to the NumericTextBox

            Collection = new ObservableCollection<MainOperationsRecord>();
            Collection.Add(new MainOperationsRecord() { OperationNumber = 1, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "14:20", Delivery = new DeliverySpecification { Address = "123 Ocean Drive", Weight = 5, StartTime = "18:30", EndTime = "19:00", Contactnumber = "555-1234", PaymentType = PaymentTypes.BankCard, Notes = "Please take POS terminal." } });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 2, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "15:10", Delivery = new DeliverySpecification { Address = "123 Ocean Drive", Weight = 5, StartTime = "18:30", EndTime = "19:00", Contactnumber = "555-1234", PaymentType = PaymentTypes.Cash, Notes = "Please take exchange." } });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 3, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "15:50", Delivery = new DeliverySpecification { Address = "123 Ocean Drive", Weight = 5, StartTime = "18:30", EndTime = "19:00", Contactnumber = "555-1234", PaymentType = PaymentTypes.DeferredPayment, Notes = "Pay tomorrow." } });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 4, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "16:30", Delivery = new DeliverySpecification { Address = "123 Ocean Drive", Weight = 5, StartTime = "18:30", EndTime = "19:00", Contactnumber = "555-1234", PaymentType = PaymentTypes.MoneyTransfer, Notes = "Please include extra napkins." } });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 5, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "16:30", Delivery = null });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 6, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "16:45", Delivery = null });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 7, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "17:24", Delivery = null });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 8, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "17:51", Delivery = null });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 9, Name = "Coffee", Price = 50, Quantity = 1, Total = 50, Table = 3, Date = "11/6/2024", Time = "19:05", Delivery = null });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 9, Name = "Coffee", Price = 50, Quantity = 1, Total = 50, Table = 3, Date = "11/6/2024", Time = "19:05", Delivery = null }); 
            Collection.Add(new MainOperationsRecord() { OperationNumber = 10, Name = "Coffee", Price = 50, Quantity = 1, Total = 50, Table = 5, Date = "11/6/2024", Time = "19:28", Delivery = null });
            MainOperationDataGrid.ItemsSource = Collection;

            // Event listerner for a numeric pad
            NumericButtons.FunctionButtonClicked += NumericButtons_FunctionButtonClicked;
        }

        private void NumericButtons_FunctionButtonClicked(object sender, string buttonContent)
        {
            switch (buttonContent)
            {
                case "Enter":
                    MessageBox.Show($"Main function: {buttonContent}");
                    break;
                default:
                    MessageBox.Show($"Unhandled function: {buttonContent}");
                    break;
            }
        }
        
    }
}
