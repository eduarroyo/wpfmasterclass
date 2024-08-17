using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands;

public class LoginCommand : ICommand
{
    private LoginVM VM { get; set; }

    public LoginCommand(LoginVM vm)
    {
        VM = vm;
    }

    #region ICommand implementation
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        // TODO
    }
    #endregion
}
