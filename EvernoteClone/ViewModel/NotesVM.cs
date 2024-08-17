using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System.Collections.ObjectModel;

namespace EvernoteClone.ViewModel;

public class NotesVM
{

    #region Properties
    ObservableCollection<Notebook> Notebooks { get; set; }
    private Notebook selectedNotebook;
    public Notebook SelectedNotebook
    {
        get => selectedNotebook;
        set
        {
            selectedNotebook = value;
            // TODO: get notes
        }
    }

    ObservableCollection<Note> Notes { get; set; }
    private Note selectedNote;
    public Note SelectedNote
    {
        get => selectedNote;
        set
        {
            selectedNote = value;
            
        }
    }

    private NewNotebookCommand NewNotebookCommand;
    private NewNoteCommand NewNoteCommand;

    #endregion

    public NotesVM()
    {
        Notebooks = new ObservableCollection<Notebook>();
        Notes = new ObservableCollection<Note>();
        NewNotebookCommand = new NewNotebookCommand(this);
        NewNoteCommand = new NewNoteCommand(this);
    }
}
