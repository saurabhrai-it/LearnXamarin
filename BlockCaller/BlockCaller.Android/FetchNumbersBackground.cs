using Android.App;
using Android.Content;
using Android.OS;
using BlockCaller.Model;
using System.Collections.Generic;
using System;

namespace BlockCaller.Droid
{
    //[Service(Exported = true, Name = "BlockCaller.Droid.FetchNumbersBackground")]
    //[IntentFilter(new string[] { "BlockCaller.Droid.BlockedNumberList" })]
    public class FetchNumbersBackground : IntentService
    {
        protected override void OnHandleIntent(Intent intent)
        {
            string blockType = intent.GetStringExtra("blockType");
            List<string> getNumList;
            getNumList = new List<string>();
            var dbNum = new BlockDatabase("PhoneNumber"); // Creates (if does not exist) a database named People
            List<Numbers> temp = dbNum.Query<Numbers>("select * from Numbers where blockType = '"+ blockType + "'");
            foreach (Numbers num in temp)
            {
                getNumList.Add(num.number);
            }
        }
    }
}