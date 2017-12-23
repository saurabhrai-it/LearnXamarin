using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlockCaller.ViewModel;
using System;
using BlockCaller.Model;

namespace BlockCaller.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetPhoneNumberList : ContentPage
    {

        PhoneNumberCallLogs callLogs;

        public GetPhoneNumberList()
        {
            InitializeComponent();
            callLogs = new PhoneNumberCallLogs();
            BindingContext = callLogs;
        }

        async void CallLog_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var selectedItem = e.SelectedItem as PhoneNumber;
            await DisplayAlert("Block "+ selectedItem.NameInCallLog+" !","Phone Number :  "+selectedItem.phoneNumberofCallLog+" ?", "OK","Cancel");
            NumberToBlock.numberToBlock.Add(selectedItem.phoneNumberofCallLog);
        }

        //async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var selectedLog = e.SelectedItem as PhoneNumber;
        //    if (e.SelectedItem == null)
        //        return;

        //    await DisplayAlert("Aha!",String.Format("You selected {0} {1}",selectedLog.NameInCallLog,selectedLog.phoneNumberofCallLog), "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}