using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using BlockCaller.db;
using BlockCaller.Model;

namespace BlockCaller
{
    public class BlockDatabase
    {
        static object locker = new object();
        ISQLiteService SQLite
        {
            get
            {
                return DependencyService.Get<ISQLiteService>();
            }
        }
        readonly SQLiteConnection connection;
        readonly string DatabaseName;

        public BlockDatabase(string databaseName)
        {
            DatabaseName = databaseName;
            connection = SQLite.GetConnection(DatabaseName);
        }

        public void CreateTable<T>()
        {
            lock (locker)
            {
                connection.CreateTable<T>();
            }
        }

        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }

        public int SaveItem<T>(T item)
        {
            lock (locker)
            {
                var id = ((Numbers)(object)item).Id;
                if (id != 0)
                {
                    connection.Update(item);
                    return id;
                }
                else
                {
                    return connection.Insert(item);
                }
            }
        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (locker)
            {
                connection.Execute(query, args);
            }
        }

        public List<T> Query<T>(string query) where T : new()
        {
            lock (locker)
            {
                return connection.Query<T>(query);
            }
        }

        public List<T> GetItems<T>() where T : new()
        {
            lock (locker)
            {
                return (from i in connection.Table<T>() select i).ToList();
            }
        }

        public int DeleteItem<T>(int id)
        {
            lock (locker)
            {
                return connection.Delete<T>(id);
            }
        }

        public int DeleteAll<T>()
        {
            lock (locker)
            {
                return connection.DeleteAll<T>();
            }
        }
    }
}