using Android.App;
using Android.Provider;
using System.Collections.Generic;

namespace BlockCaller.Droid
{
    [Android.Runtime.Register("android/content/ContentResolver", DoNotGenerateAcw = true)]
    public static class GetCallLog
    {
        public static Dictionary<string,string> getCallDetails()
        {
            string stringBuffer = string.Empty;
            Dictionary<string, string> logList = new Dictionary<string, string>();
            string removeDub = string.Empty;

            Android.Database.ICursor queryData = Application.Context.ContentResolver.Query(CallLog.Calls.ContentUri, null, null, null, CallLog.Calls.Date + " DESC");
            while (queryData.MoveToNext())
            {
                string phoneNumber = queryData.GetString(queryData.GetColumnIndex(CallLog.Calls.Number));
                string contactName = queryData.GetString(queryData.GetColumnIndex(CallLog.Calls.CachedName));
                if(!string.IsNullOrEmpty(phoneNumber))
                {
                    if (string.IsNullOrEmpty(contactName))
                            contactName = "Unknown";
                    else if (phoneNumber.IndexOf("0") == 0)
                       phoneNumber = "+91" + phoneNumber.Substring(1, 10);
                    else if (phoneNumber.Length == 10)
                        phoneNumber = "+91" + phoneNumber;
                    if (!logList.ContainsKey(phoneNumber))
                        logList.Add(phoneNumber, contactName);
                }
            } 
            queryData.Close();
            return logList;
        }
    }
}