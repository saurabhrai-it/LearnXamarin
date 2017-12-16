using BlockCaller.Droid;
using System.Collections.Generic;

namespace BlockCaller.Model
{
    public class PhoneNumber
    {
        public string phoneNumberofCallLog { get; set; }
        public string NameInCallLog { get; set; }


        List<PhoneNumber> tempList = new List<PhoneNumber>();

        public List<PhoneNumber> FetchLog()
        {
            Dictionary<string, string> listOfLog = GetCallLog.getCallDetails();
            foreach (KeyValuePair<string, string> s in listOfLog)
            {
                PhoneNumber phoneObject = new PhoneNumber();
                phoneObject.phoneNumberofCallLog = s.Key;
                phoneObject.NameInCallLog = s.Value;
                tempList.Add(phoneObject);
            }
            return tempList;
        }
    }

}
