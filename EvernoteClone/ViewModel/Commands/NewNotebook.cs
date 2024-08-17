using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands;

public class NewNotebookCommand : ICommand
{
    #region Properties
    public NotesVM VM { get; private set; }
    #endregion

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

    public NewNotebookCommand(NotesVM vm)
    {
        VM = vm;
    }
}
