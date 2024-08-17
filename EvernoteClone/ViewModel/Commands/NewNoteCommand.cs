using EvernoteClone.Model;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands;

public class NewNoteCommand: ICommand
{
    #region Properties
    public NotesVM VM { get; private set; }
    #endregion

    #region ICommand implementation
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        Notebook? selectedNotebook = parameter as Notebook;
        return selectedNotebook != null;
    }

    public void Execute(object? parameter)
    {
        Notebook selectedNotebook = parameter as Notebook;
        VM.CreateNote(selectedNotebook.Id);
    }
    #endregion

    public NewNoteCommand(NotesVM vm)
    {
        VM = vm;
    }
}
