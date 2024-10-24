using System.Windows;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for FoodInventoryWindow.xaml
    /// </summary>
    public partial class FoodInventoryWindow : Window
    {
        public FoodInventoryWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("2. Inventory of products for sale");
        }
    }
}
