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
using static POS_restaurant.MenuManagementWindow;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for ComplimentaryInventoryWindow.xaml
    /// </summary>
    public partial class ComplimentaryInventoryWindow : Window
    {
        // in millimiters
        public class ItemSize
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public int Length { get; set; }
        }
        public class ComplimentaryInventoryRecord
        {
            [Key]
            public int Number { get; set; }
            public string Name { get; set; }
            public ItemSize Size { get; set; }
            public double Weight { get; set; }
            public int QuantityInStock { get; set; }
            public decimal InitialPrice { get; set; }
            public string Currency { get; set; }
            public string EncountingDate { get; set; }
        }
        public ObservableCollection<ComplimentaryInventoryRecord> ComplimentaryInventoryCollection { get; set; }
        public ComplimentaryInventoryWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("3. Inventory of commercial equipment");
            ComplimentaryInventoryCollection = [
                new ComplimentaryInventoryRecord(){Number = 1, Name = "Table", Size = new ItemSize(){Height = 1200, Width = 750, Length = 600}, Weight = 1.5, QuantityInStock = 10, InitialPrice = 800, Currency = "TL", EncountingDate = "01/01/2024" },
                new ComplimentaryInventoryRecord(){Number = 2, Name = "Chair", Size = new ItemSize(){Height = 850, Width = 600, Length = 600}, Weight = 0.8, QuantityInStock = 5, InitialPrice = 450, Currency = "TL", EncountingDate = "01/01/2024" },
                new ComplimentaryInventoryRecord(){Number = 3, Name = "Fridge", Size = new ItemSize(){Height = 2000, Width = 800, Length = 800}, Weight = 35, QuantityInStock = 2, InitialPrice = 3000, Currency = "TL", EncountingDate = "01/01/2024" },
            ];

            ComplimentaryInventoryDataGrid.ItemsSource = ComplimentaryInventoryCollection;
        }
    }
}
