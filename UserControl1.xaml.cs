using System.Windows.Controls;
using System.Windows.Threading;

namespace POS_restaurant
{
    /// <summary>
    /// Top status bar
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            InitDateTime();
        }
        private void InitDateTime()
        {
            // Initial set
            DateTimeTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            // Start the timer to update date and time every second
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        // Method to update date and time
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTimeTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        
        // Method to set the window name
        public void SetWindowName(string windowName)
        {
            WindowNameTextBlock.Text = windowName;
        }
    }
}
