using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;

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
            Collection.Add(new MainOperationsRecord() { OperationNumber = 1, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "14:20" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 2, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 2, Date = "11/6/2024", Time = "15:10" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 3, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 3, Date = "11/6/2024", Time = "15:50" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 4, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 2, Date = "11/6/2024", Time = "16:30" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 5, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 4, Date = "11/6/2024", Time = "16:45" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 6, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 5, Date = "11/6/2024", Time = "17:24" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 7, Name = "Tea", Price = 30, Quantity = 1, Total = 30, Table = 1, Date = "11/6/2024", Time = "17:51" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 8, Name = "Ice cream", Price = 80, Quantity = 1, Total = 80, Table = 2, Date = "11/6/2024", Time = "18:42" });
            Collection.Add(new MainOperationsRecord() { OperationNumber = 9, Name = "Coffee", Price = 50, Quantity = 1, Total = 50, Table = 3, Date = "11/6/2024", Time = "19:05" }); 
            Collection.Add(new MainOperationsRecord() { OperationNumber = 10, Name = "Coffee", Price = 50, Quantity = 1, Total = 50, Table = 5, Date = "11/6/2024", Time = "19:28" });
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
