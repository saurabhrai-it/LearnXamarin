using SQLite;

namespace BlockCaller.db
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}