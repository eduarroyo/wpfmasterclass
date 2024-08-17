using SQLite;

namespace EvernoteClone.Model;

public class Notebook
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed]
    public int UserId { get; set; }

    [MaxLength(500)]
    public string Name { get; set; }
}
