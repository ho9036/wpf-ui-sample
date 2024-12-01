using WPF.Sample.Models.Base;

namespace WPF.Sample.ViewModels
{
    public class MainWindowViewModel : PropertyChangeBase
    {
        private string _windowTitle = string.Empty;

        private double _windowWidth = 0;

        private double _windowHeight = 0;

        private string _windowBakcground = "#00000000";

        public string WindowTitle
        {
            get => _windowTitle;
            set => SetProperty(ref _windowTitle, value);
        }

        public double WindowWidth
        {
            get => _windowWidth;
            set => SetProperty(ref _windowWidth, value);
        }

        public double WindowHeight
        {
            get => _windowHeight;
            set => SetProperty(ref _windowHeight, value);
        }

        public string WindowBackground
        {
            get => _windowBakcground;
            set => SetProperty(ref _windowBakcground, value);
        }
    }
}
