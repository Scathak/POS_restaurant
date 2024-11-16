using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for MenuManagementWindow.xaml
    /// </summary>
    public partial class MenuManagementWindow : Window
    {
        public class MenuManagementRecord
        {
            [Key]
            public int Number { get; set; }
            public string Name { get; set; }
            public string IngredientsWithWeight { get; set; }
            public decimal ProductionCost { get; set; }
            public decimal RetailPrice { get; set; }
            public string Category { get; set; }
        }
        public class MenuCategoriesRecord
        {
            [Key]
            public int Number { get; set; }
            public string Category { get; set; }
        }
        
        public ObservableCollection<MenuManagementRecord> MenuCollection { get; set; }
        public ObservableCollection<MenuCategoriesRecord> CategoriesCollection { get; set; }
        public MenuManagementWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("7. Menu Management");

            CategoriesCollection = [
                new MenuCategoriesRecord(){Number = 1, Category = "Breakfast"},
                new MenuCategoriesRecord(){Number = 2, Category = "Main courses"},
                new MenuCategoriesRecord(){Number = 3, Category = "Desserts"},
                new MenuCategoriesRecord(){Number = 4, Category = "Drinks"},
            ];

            MenuCategoriesDataGrid.ItemsSource = CategoriesCollection;

            MenuCollection =
            [
                new MenuManagementRecord() { Number = 1, Name = "Tea", IngredientsWithWeight="Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 2, Name = "Tea", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 3, Name = "Tea", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 4, Name = "Tea", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 5, Name = "Tea", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 6, Name = "Tea", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 7, Name = "Tea", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 30, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 8, Name = "Ice cream", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 80, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 9, Name = "Coffee", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 50, RetailPrice = 1, Category = CategoriesCollection[3].Category },
                new MenuManagementRecord() { Number = 10, Name = "Coffee", IngredientsWithWeight = "Tea 10g, water 100 ml", ProductionCost = 50, RetailPrice = 1, Category = CategoriesCollection[3].Category },
            ];
            MenuManagementDataGrid.ItemsSource = MenuCollection;


        }
    }
}
