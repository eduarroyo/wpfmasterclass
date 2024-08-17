using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EvernoteClone.ViewModel;

public class NotesVM: INotifyPropertyChanged
{

    #region Properties
    public ObservableCollection<Notebook> Notebooks { get; set; }
    private Notebook selectedNotebook;
    public Notebook SelectedNotebook
    {
        get => selectedNotebook;
        set
        {
            selectedNotebook = value;
            OnPropertyChanged(nameof(SelectedNotebook));
            GetNotes();
        }
    }

    public ObservableCollection<Note> Notes { get; set; }
    private Note selectedNote;

    public Note SelectedNote
    {
        get => selectedNote;
        set
        {
            selectedNote = value;
            OnPropertyChanged(nameof(SelectedNote));
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

        GetNotebooks();
    }

    #region Methods
    public void CreateNotebook()
    {
        Notebook newNotebook = new()
        {
            Name = "New notebook",
        };
        DatabaseHelper.Insert(newNotebook);
        GetNotebooks();
    }

    public void CreateNote(int notebookId)
    {
        Note newNote = new()
        {
            NotebookId = notebookId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Title = $"Note for {DateTime.Now}"
        };

        DatabaseHelper.Insert(newNote);
        GetNotes();
    }

    private void GetNotebooks()
    {
        List<Notebook> notebooks = DatabaseHelper.Query<Notebook>();
        Notebooks.Clear();
        foreach (Notebook notebook in notebooks)
        {
            Notebooks.Add(notebook);
        }
    }

    private void GetNotes()
    {
        Notes.Clear();
        if(SelectedNotebook == null)
        {
            return;
        }

        List<Note> notes = DatabaseHelper.Query<Note>()
            .Where(n => n.NotebookId == SelectedNotebook.Id)
            .ToList();
        foreach (Note note in notes)
        {
            Notes.Add(note);
        }
    }
    #endregion

    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    { 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
