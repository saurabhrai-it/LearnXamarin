using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BlockCaller.db
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection(string databaseName);
        long GetSize(string databaseName);
    }
}
