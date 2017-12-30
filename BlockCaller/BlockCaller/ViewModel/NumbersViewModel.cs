

using BlockCaller.Model;
using System.Collections.Generic;

namespace BlockCaller.ViewModel
{
    public class NumbersViewModel 
    {
        public NumbersViewModel() { }

        public NumbersViewModel(Numbers num)
        {
            var dbNum = new BlockDatabase("PhoneNumber"); // Creates (if does not exist) a database named People
            dbNum.CreateTable<Numbers>();
            dbNum.SaveItem<Numbers>(num);
        }

        public static List<Numbers> GetDataFromTable(string str)
        {
            var dbNum = new BlockDatabase(str); // Creates (if does not exist) a database named People
            return dbNum.GetItems<Numbers>();
        }

        public static List<string> GetNumberFromTable(string str)
        {
            List<string> getNumList = new List<string>();
            var dbNum = new BlockDatabase(str); // Creates (if does not exist) a database named People
            List<Numbers> temp = dbNum.Query<Numbers>("select * from Numbers where blockType = 'blockThisNumber'");
            foreach(Numbers num in temp)
            {
                getNumList.Add(num.number);
            }
            return getNumList;
        }
    }
}
