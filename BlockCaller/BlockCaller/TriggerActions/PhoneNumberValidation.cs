using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlockCaller.TriggerActions
{
    class PhoneNumberValidation : TriggerAction<Entry>
    {
        private string phNumValue = string.Empty;

        protected override void Invoke(Entry entry)
        {
            long n;
            var isNumeric = long.TryParse(entry.Text, out n);

            if (!string.IsNullOrWhiteSpace(entry.Text) && !isNumeric) /* (entry.Text.Length != 11 || !isNumeric)*/
            {
                entry.Text = phNumValue;
                return;
            }

            phNumValue = entry.Text;
        }
    }
}
