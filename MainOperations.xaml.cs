using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for MainOperations.xaml
    /// </summary>

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

    public partial class MainOperations : Window
    {
        private string _currentShape; // Stores the shape type being dragged
        public ObservableCollection<MainOperationsRecord> Collection { get; set; }
        public MainOperations()
        {
            InitializeComponent();
            MainHeader.SetWindowName("1. Main Operations");
            NumericTextBox.Focus(); // Set initial focus to the NumericTextBox

            CircleButton.MouseMove += Shape_MouseMove;
            SquareButton.MouseMove += Shape_MouseMove;
            TriangleButton.MouseMove += Shape_MouseMove;

            DrawingCanvas.Drop += DrawingCanvas_Drop;
            DrawingCanvas.AllowDrop = true;
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
        }
        // Event handler for restricting input to numeric only
        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regular expression to allow only numeric input (digits only)
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text); // If non-numeric, set Handled to true to prevent input
        }
        // Handles the dragging of shapes from the buttons
        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (1==1)//(e.LeftButton == MouseButtonState.Pressed)
            {
                _currentShape = button.Content.ToString();
                DragDrop.DoDragDrop(button, button.Content, DragDropEffects.Copy);
            }
        }

        // Handles the dropping of shapes onto the canvas
        private void DrawingCanvas_Drop(object sender, DragEventArgs e)
        {
            Point dropPosition = e.GetPosition(DrawingCanvas);
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string shapeType = (string)e.Data.GetData(DataFormats.StringFormat);

                UIElement shape = CreateShape(shapeType, dropPosition);
                if (shape != null)
                {
                    DrawingCanvas.Children.Add(shape);
                }
            }
        }

        // Creates the shape element (Circle, Square, Triangle)
        private UIElement CreateShape(string shapeType, Point dropPosition)
        {
            const int outlineWidth = 16;
            const int outlineHeight = 16;

            Shape shape = null;
            TextBox textBox = new TextBox()
            {
                Text = shapeType,
                Width = 60,
                Height = 20,
                FontSize = 12,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            if (shapeType == "Cassier")
            {
                shape = new Ellipse() { Width = outlineWidth, Height = outlineHeight, Fill = TriangleButton.Background, Stroke = Brushes.Black, StrokeThickness = 1 };
            }
            else if (shapeType == "Table")
            {
                shape = new Rectangle() { Width = outlineWidth, Height = outlineHeight, Fill = SquareButton.Background, Stroke = Brushes.Black, StrokeThickness = 1 };
            }
            else if (shapeType == "Additional")
            {
                shape = CreateTriangle(outlineWidth, outlineHeight);
            }

            if (shape != null)
            {
                Canvas.SetLeft(shape, dropPosition.X);
                Canvas.SetTop(shape, dropPosition.Y);

                // Adding TextBox over the shape to change the text
                Canvas.SetLeft(textBox, dropPosition.X - outlineHeight);
                Canvas.SetTop(textBox, dropPosition.Y - outlineWidth);

                DrawingCanvas.Children.Add(textBox);

                // Allowing text to be changed after being placed on the canvas
                textBox.MouseDoubleClick += (sender, args) =>
                {
                    textBox.IsReadOnly = false;
                    textBox.Focus();
                };
                textBox.LostFocus += (sender, args) =>
                {
                    textBox.IsReadOnly = true;
                };
            }

            return shape;
        }

        // Creates a triangle using a Polygon. Parameters: Height, Width of triangle's outline square
        private Shape CreateTriangle(int a, int b)
        {
            Polygon triangle = new Polygon()
            {
                Stroke = Brushes.Black,
                Fill = CircleButton.Background, //Brushes.LightCoral,
                StrokeThickness = 1,
                Points = new PointCollection(new Point[]
                {
                    new Point(a/2, 0),  // Top
                    new Point(0, a), // Bottom Left
                    new Point(a, b) // Bottom Right
                })
            };
            return triangle;
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
        private void NumericKeysEnterButton_Click(object sender, RoutedEventArgs e)
        {
            NumericTextBox.Text = "";
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

        // Set the cursor to the end of the text when the NumericTextBox regains focus
        private void NumericTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
        }
    }
}
