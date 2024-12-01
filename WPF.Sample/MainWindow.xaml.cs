using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF.Sample.Pages;
using WPF.Sample.ViewModels;

namespace WPF.Sample
{
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider, MainWindowViewModel viewModel)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();

            DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
            RootFrame.Navigate(loginPage);
        }
    }
}