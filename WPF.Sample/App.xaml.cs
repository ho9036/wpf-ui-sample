using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows;
using System.Windows.Threading;
using WPF.Sample.Datacontexts;
using WPF.Sample.Extensions;
using WPF.Sample.ViewModels;

namespace WPF.Sample
{
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            InitializeComponent();

            _host = Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(configuration =>
                {
                    configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<MainContext>(options => options.UseSqlite("Data Source=app.db"));
                    services.AddMemoryCache();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainWindowViewModel>();
                  
                })
                .UseSerilog((context, configuration) =>
                {
#if DEBUG
                    configuration
                        .MinimumLevel.Debug()
                        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);
#else
                    configuration
                        .MinimumLevel.Information()
                        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Infinite);
#endif
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            _host.WriteFatalLog(e.Exception, "Unhandled exception occurred");
        }
    }
}
