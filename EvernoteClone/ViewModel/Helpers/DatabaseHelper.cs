using SQLite;
using System.IO;

namespace EvernoteClone.ViewModel.Helpers;

public class DatabaseHelper
{
    private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

    public static bool Insert<T>(T item) where T : class
    {
        using (SQLiteConnection conn = new SQLiteConnection(dbFile))
        {
            conn.CreateTable<T>();
            if (conn.Insert(item) > 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool Update<T>(T item) where T : class
    {
        using (SQLiteConnection conn = new SQLiteConnection(dbFile))
        {
            if (conn.Update(item) > 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool Delete<T>(T item) where T : class
    {
        using (SQLiteConnection conn = new SQLiteConnection(dbFile))
        {
            if (conn.Delete(item) > 0)
            {
                return true;
            }
        }
        return false;
    }

    public static List<T> Query<T>() where T : new()
    {
        using (SQLiteConnection conn = new SQLiteConnection(dbFile))
        {
            return conn.Table<T>().ToList();
        }
    }
}
