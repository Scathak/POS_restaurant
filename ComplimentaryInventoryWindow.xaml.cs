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
    /// Interaction logic for ComplimentaryInventoryWindow.xaml
    /// </summary>
    public partial class ComplimentaryInventoryWindow : Window
    {
        public ComplimentaryInventoryWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("3. Inventory of commercial equipment");
        }
    }
}
