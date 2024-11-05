using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace POS_restaurant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {

        }
        /*
                     // Set up dependency injection
            var services = new ServiceCollection();

            // Register the database context with a connection to the SQLite database
            services.AddDbContext<LabourContext>(options =>
                options.UseSqlite("Data Source=POS_Restaurant_202410251713.db"));

            // Register the DatabaseService
            services.AddSingleton<DatabaseService>();

            // Register the main window
            services.AddTransient<labourManagementWindow>();

            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

            // Start the main window and show it
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        protected override void OnExit(ExitEventArgs e)
        {
            ServiceProvider.Dispose();
            base.OnExit(e);
        }*/
    }
}
