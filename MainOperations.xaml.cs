using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for MainOperations.xaml
    /// </summary>
    public partial class MainOperations : Window
    {
        private string _currentShape; // Stores the shape type being dragged
        public MainOperations()
        {
            InitializeComponent();
            MainHeader.SetWindowName("Main Operations");

            // Attach drag-and-drop handlers
            CircleButton.MouseMove += Shape_MouseMove;
            SquareButton.MouseMove += Shape_MouseMove;
            TriangleButton.MouseMove += Shape_MouseMove;

            DrawingCanvas.Drop += DrawingCanvas_Drop;
            DrawingCanvas.AllowDrop = true;
        }
        // Handles the dragging of shapes from the buttons
        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (e.LeftButton == MouseButtonState.Pressed)
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

            if (shapeType == "Circle")
            {
                shape = new Ellipse() { Width = 100, Height = 100, Fill = Brushes.LightBlue, Stroke = Brushes.Black, StrokeThickness = 2 };
            }
            else if (shapeType == "Square")
            {
                shape = new Rectangle() { Width = 100, Height = 100, Fill = Brushes.LightGreen, Stroke = Brushes.Black, StrokeThickness = 2 };
            }
            else if (shapeType == "Triangle")
            {
                shape = CreateTriangle();
            }

            if (shape != null)
            {
                Canvas.SetLeft(shape, dropPosition.X - 50);
                Canvas.SetTop(shape, dropPosition.Y - 50);

                // Adding TextBox over the shape to change the text
                Canvas.SetLeft(textBox, dropPosition.X - 30);
                Canvas.SetTop(textBox, dropPosition.Y - 10);

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

        // Creates a triangle using a Polygon
        private Shape CreateTriangle()
        {
            Polygon triangle = new Polygon()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.LightCoral,
                StrokeThickness = 2,
                Points = new PointCollection(new Point[]
                {
                    new Point(50, 0),  // Top
                    new Point(0, 100), // Bottom Left
                    new Point(100, 100) // Bottom Right
                })
            };
            return triangle;
        }
    }
}
