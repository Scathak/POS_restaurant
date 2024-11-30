using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        private VideoCaptureDevice _webcam;
        private FilterInfoCollection _webcamDevices;
        public SetupWindow()
        {
            InitializeComponent();
            MainHeader.SetWindowName("9. Setups page");

            // Set default index for the dropdowns
            ColorSchemeComboBox.SelectedIndex = 0; // Default: Light
            LanguageComboBox.SelectedIndex = 0; // Default: Turkish
            CurrencyComboBox.SelectedIndex = 0; // Default: Turk Lira
            DateTimeFormatComboBox.SelectedIndex = 0; // Default: First DateTime Format

            SoundToggleButton.Content = "Off";
        }
        // Event when the toggle button is checked (Auto Date & Time ON)
        private void AutoDateTimeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            DateTimeFormatComboBox.IsEnabled = false; // Disable DateTime format selection
        }

        // Event when the toggle button is unchecked (Auto Date & Time OFF)
        private void AutoDateTimeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            DateTimeFormatComboBox.IsEnabled = true; // Enable DateTime format selection
        }
        // Event handler for when the toggle button is checked (Sound On)
        private void SoundToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            SoundToggleButton.Content = "On"; // Change label to "On"
        }

        // Event handler for when the toggle button is unchecked (Sound Off)
        private void SoundToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SoundToggleButton.Content = "Off"; // Change label to "Off"
        }

        // Load available webcam devices
        private void LoadWebcamDevices()
        {
            _webcamDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (_webcamDevices.Count == 0)
            {
                MessageBox.Show("No webcam devices found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Start the webcam feed
        private void StartWebcam_Click(object sender, RoutedEventArgs e)
        {
            if (_webcamDevices?.Count > 0)
            {
                _webcam = new VideoCaptureDevice(_webcamDevices[0].MonikerString); // Use the first webcam device
                _webcam.NewFrame += Webcam_NewFrame;
                _webcam.Start();
            }
        }

        // Handle each new frame from the webcam
        private void Webcam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // Convert AForge's frame to BitmapImage
                /*
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    var bitmapImage = BitmapToImageSource(bitmap);
                    Dispatcher.Invoke(() =>
                    {
                        WebcamFeed.Source = bitmapImage; // Display the webcam feed
                    });

                    // Attempt to decode the QR/BAR code
                    var result = DecodeQRCode(bitmap);
                    if (!string.IsNullOrEmpty(result))
                    {
                        Dispatcher.Invoke(() =>
                        {
                            // Paste the result into NumericTextBox in UserControl4
                            //NumericButtons.NumericTextBox.Text = result;
                        });
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing webcam frame: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Convert Bitmap to BitmapImage
        /*
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }*/

        // Decode QR or BAR code using ZXing
        /*
        private string DecodeQRCode(Bitmap bitmap)
        {
            
            var reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            return result?.Text; // Return the decoded text or null if no code found
            
            return "";
        }*/

        // Stop the webcam feed when the window is closed
        protected override void OnClosed(EventArgs e)
        {
            _webcam?.SignalToStop();
            _webcam?.WaitForStop();
            base.OnClosed(e);
        }
    }
}
