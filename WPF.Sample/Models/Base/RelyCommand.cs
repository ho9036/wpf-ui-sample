using System.Windows.Input;

namespace WPF.Sample.Models.Base
{
    public class RelyCommand<T, U>(Action<T?>? action = null, Func<U?, bool>? condition = null) : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return condition?.Invoke(parameter is not U ? default : (U)parameter) == true;
        }

        public void Execute(object? parameter)
        {
            action?.Invoke(parameter is not T ? default : (T)parameter);
        }
    }
}
