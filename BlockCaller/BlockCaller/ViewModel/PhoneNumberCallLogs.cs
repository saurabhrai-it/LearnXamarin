using BlockCaller.Model;
using System.Collections.Generic;

namespace BlockCaller.ViewModel
{
    public class PhoneNumberCallLogs
    {
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public PhoneNumberCallLogs()
        {
            PhoneNumbers = new PhoneNumber().FetchLog();
        }
    }
}
