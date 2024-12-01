using System.Windows.Controls;
using WPF.Sample.ViewModels;

namespace WPF.Sample.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage(LoginPageViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
