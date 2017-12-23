using BlockCaller.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BlockCaller.db
{
    public class PhoneNumberDB
    {
        private SQLiteConnection _sqlconnection;

        public PhoneNumberDB()
        { 
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<NumberToBlock>();
        }
        
        public IEnumerable<NumberToBlock> GetPhoneNumbers()
        {
            return (from t in _sqlconnection.Table<NumberToBlock>() select t).ToList();
        }
        
        public NumberToBlock GetPhoneNumber(int id)
        {
            return _sqlconnection.Table<NumberToBlock>().FirstOrDefault(t => t.Id == id);
        }
        
        public void DeletePhoneNumbert(int id)
        {
            _sqlconnection.Delete<NumberToBlock>(id);
        }
        
        public void AddPhoneNumberToBlock(NumberToBlock phoneNumber)
        {
            _sqlconnection.Insert(phoneNumber);
        }
    }
}
