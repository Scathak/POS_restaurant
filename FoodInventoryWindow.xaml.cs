using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using static POS_restaurant.ComplimentaryInventoryWindow;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for FoodInventoryWindow.xaml
    /// </summary>
    public partial class FoodInventoryWindow : Window
    {
        public class ProductsInventoryRecord
        {
            [Key]
            public int Number { get; set; }
            public string Name { get; set; }
            public string Amount { get; set; }
            public decimal Price { get; set; }
            public string Currency { get; set; }
        }
        public ObservableCollection<ProductsInventoryRecord> ProductsInventoryCollection { get; set; }
        public FoodInventoryWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("2. Inventory of products for sale");

            ProductsInventoryCollection = [
                new ProductsInventoryRecord(){Number = 1, Name = "Tea", Amount = "100 ml", Price = 10, Currency = "TL", },
                new ProductsInventoryRecord(){Number = 2, Name = "Coffee", Amount = "200 ml", Price = 30, Currency = "TL", },
                new ProductsInventoryRecord(){Number = 3, Name = "Ice cream", Amount = "30 gramm", Price = 30, Currency = "TL",},
            ];

            ProductsInventoryDataGrid.ItemsSource = ProductsInventoryCollection;
        }
    }
}
