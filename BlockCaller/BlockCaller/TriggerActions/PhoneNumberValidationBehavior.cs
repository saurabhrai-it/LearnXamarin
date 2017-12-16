using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlockCaller.TriggerActions
{
    public static class PhoneNumberValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
        BindableProperty.CreateAttached(
            "AttachBehavior",typeof(bool),
            typeof(PhoneNumberValidationBehavior),false,
            propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }
        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            long result;
            bool isValid = long.TryParse(args.NewTextValue, out result);
            if(isValid)
            {
                var lengthOfText = ((Entry)sender).Text.Length;
                if(lengthOfText > 10)
                {
                    //((Entry)sender).BackgroundColor = Color.Red;
                    ((Entry)sender).Text = ((Entry)sender).Text.Remove(((Entry)sender).Text.Length - 1);
                }
            }
        }
    }
}
