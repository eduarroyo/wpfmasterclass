using SQLite;

namespace EvernoteClone.Model;

public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed]
    public int NotebookId { get; set; }
    
    [MaxLength(500)]
    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string FileLocation { get; set; }
}
