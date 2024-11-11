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
    /// Interaction logic for MainOperations.xaml
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

    public partial class MainOperations : Window
    {
        private string _currentShape; // Stores the shape type being dragged
        private ScaleTransform _scaleTransform = new ScaleTransform(1.0, 1.0); // Initialize scale at 100%
        private const double ZoomStep = 0.1; // Amount to zoom in/out per step

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
            DrawingCanvas.RenderTransform = _scaleTransform;

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
        // Method to zoom in
        private void ZoomIn()
        {
            _scaleTransform.ScaleX += ZoomStep;
            _scaleTransform.ScaleY += ZoomStep;
        }

        // Method to zoom out
        private void ZoomOut()
        {
            // Prevent zooming out beyond 10% scale
            if (_scaleTransform.ScaleX > ZoomStep && _scaleTransform.ScaleY > ZoomStep)
            {
                _scaleTransform.ScaleX -= ZoomStep;
                _scaleTransform.ScaleY -= ZoomStep;
            }
        }

        // Event handler for mouse wheel scroll
        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

        // Event handler for keyboard key press
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Add || e.Key == Key.OemPlus) // '+' key
            {
                ZoomIn();
            }
            else if (e.Key == Key.Subtract || e.Key == Key.OemMinus) // '-' key
            {
                ZoomOut();
            }
        }

        // Event handler for Zoom In button click
        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            ZoomIn();
            SaveCanvasToJson("canvas_objects.json");
        }

        // Event handler for Zoom Out button click
        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            ZoomOut();
            LoadCanvasFromJson("canvas_objects.json");
        }
        // Method to save all Canvas objects to JSON
        private void SaveCanvasToJson(string filePath)
        {
            var shapes = new List<SerializableShape>();

            foreach (var child in DrawingCanvas.Children)
            {
                if (child is Rectangle rect)
                {
                    shapes.Add(new SerializableShape
                    {
                        ShapeType = "Rectangle",
                        Width = rect.Width,
                        Height = rect.Height,
                        X = Canvas.GetLeft(rect),
                        Y = Canvas.GetTop(rect),
                        FillColor = ((SolidColorBrush)rect.Fill).Color.ToString(),
                        StrokeColor = rect.Stroke.ToString(),
                        StrokeThickness = rect.StrokeThickness,
                    });
                }
                else if (child is Ellipse ellipse)
                {
                    shapes.Add(new SerializableShape
                    {
                        ShapeType = "Ellipse",
                        Width = ellipse.Width,
                        Height = ellipse.Height,
                        X = Canvas.GetLeft(ellipse),
                        Y = Canvas.GetTop(ellipse),
                        FillColor = ((SolidColorBrush)ellipse.Fill).Color.ToString(),
                        StrokeColor = ellipse.Stroke.ToString(),
                        StrokeThickness = ellipse.StrokeThickness,
                    });
                }
                else if (child is TextBox textBlock)
                {
                    shapes.Add(new SerializableShape
                    {
                        ShapeType = "TextBox",
                        Width = textBlock.ActualWidth,
                        Height = textBlock.ActualHeight,
                        X = Canvas.GetLeft(textBlock),
                        Y = Canvas.GetTop(textBlock),
                        Text = textBlock.Text,
                        FillColor = ((SolidColorBrush)textBlock.Foreground).Color.ToString()
                    });
                }else if (child is Polygon triangle)
                {
                    shapes.Add(new SerializableShape
                    {
                        ShapeType = "Triangle",
                        X = Canvas.GetLeft(triangle),
                        Y = Canvas.GetTop(triangle),
                        FillColor = ((SolidColorBrush)triangle.Fill).Color.ToString(),
                        StrokeColor = triangle.Stroke.ToString(),
                        StrokeThickness = triangle.StrokeThickness,
                        PointsCollection = triangle.Points,
                    });
                }
            }

            // Serialize to JSON
            var json = JsonSerializer.Serialize(shapes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        // Method to load objects from JSON and restore them on the Canvas
        private void LoadCanvasFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Clear existing objects
            DrawingCanvas.Children.Clear();

            // Deserialize JSON
            var json = File.ReadAllText(filePath);
            var shapes = JsonSerializer.Deserialize<List<SerializableShape>>(json);

            foreach (var shape in shapes)
            {
                if (shape.ShapeType == "Rectangle")
                {
                    var rect = new Rectangle
                    {
                        Width = shape.Width,
                        Height = shape.Height,
                        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(shape.FillColor)),
                        Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(shape.StrokeColor)),
                        StrokeThickness = shape.StrokeThickness,
                    };
                    Canvas.SetLeft(rect, shape.X);
                    Canvas.SetTop(rect, shape.Y);
                    DrawingCanvas.Children.Add(rect);
                }
                else if (shape.ShapeType == "Ellipse")
                {
                    var ellipse = new Ellipse
                    {
                        Width = shape.Width,
                        Height = shape.Height,
                        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(shape.FillColor)),
                        Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(shape.StrokeColor)),
                        StrokeThickness = shape.StrokeThickness,
                    };
                    Canvas.SetLeft(ellipse, shape.X);
                    Canvas.SetTop(ellipse, shape.Y);
                    DrawingCanvas.Children.Add(ellipse);
                }
                else if (shape.ShapeType == "TextBox")
                {
                    var textBox = new TextBox
                    {
                        Width = shape.Width,
                        Height= shape.Height,
                        Text = shape.Text,
                        FontSize = 12,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    Canvas.SetLeft(textBox, shape.X);
                    Canvas.SetTop(textBox, shape.Y);
                    DrawingCanvas.Children.Add(textBox);
                }
                else if (shape.ShapeType == "Triangle")
                {
                    Polygon triangle = new Polygon()
                    {
                        Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(shape.StrokeColor)),
                        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(shape.FillColor)),
                        StrokeThickness = shape.StrokeThickness,
                        Points = new PointCollection(shape.PointsCollection),
                    };
                    Canvas.SetLeft(triangle, shape.X);
                    Canvas.SetTop(triangle, shape.Y);
                    DrawingCanvas.Children.Add(triangle);
                }
            }
        }
    }
}
