using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
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

    public NewNotebookCommand NewNotebookCommand { get; private set; }
    public NewNoteCommand NewNoteCommand { get; private set; }

    #endregion

    public NotesVM()
    {
        Notebooks = new ObservableCollection<Notebook>();
        Notes = new ObservableCollection<Note>();
        NewNotebookCommand = new NewNotebookCommand(this);
        NewNoteCommand = new NewNoteCommand(this);
    }

    public void CreateNotebook()
    {
        Notebook newNotebook = new()
        {
            Name = "New notebook",
        };
        DatabaseHelper.Insert(newNotebook);
    }

    public void CreateNote(int notebookId)
    {
        Note newNote = new()
        {
            NotebookId = notebookId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Title = "New note"
        };

        DatabaseHelper.Insert(newNote);
    }
}
