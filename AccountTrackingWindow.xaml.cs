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
using static POS_restaurant.ComplimentaryInventoryWindow;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for AccountTrackingWindow.xaml
    /// </summary>
    public partial class AccountTrackingWindow : Window
    {
        public class AccountingRecord
        {
            [Key]
            public int Code { get; set; }
            public string Date { get; set; }
            public decimal Rent { get; set; }
            public decimal Ingredients { get; set; }
            public decimal Labor { get; set; }
            public decimal Supplies { get; set; }
            public decimal Utilities { get; set; }
            public decimal Marketing { get; set; }
            public decimal Maintenance { get; set; }
            public decimal Insurance { get; set; }
            public decimal Licensing { get; set; }
            public decimal Debt { get; set; }
        }
        public ObservableCollection<AccountingRecord> AccoutingCollection { get; set; }
        public AccountTrackingWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("4. Account tracking");

            AccoutingCollection = [
                new AccountingRecord(){Code = 101, Date = "10/20/2024", Rent = 2000, Ingredients = 5000, Labor = 0, Supplies = 5000, Utilities = 500, Marketing = 300, Maintenance = 2000, Insurance = 100, Licensing = 0, Debt = 0,},
                new AccountingRecord(){Code = 101, Date = "11/20/2024", Rent = 2000, Ingredients = 5000, Labor = 0, Supplies = 5000, Utilities = 500, Marketing = 300, Maintenance = 2000, Insurance = 100, Licensing = 0, Debt = 0,},
            ];

            AccountingGrid.ItemsSource = AccoutingCollection;
        }
    }
}
