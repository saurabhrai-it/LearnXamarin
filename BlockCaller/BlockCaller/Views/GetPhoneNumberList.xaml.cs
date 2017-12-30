using BlockCaller.Model;
using BlockCaller.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            if (await this.DisplayAlert(
                     "Confirmation",
                     "Do you want to block " + selectedItem.NameInCallLog+ " : " + selectedItem.phoneNumberofCallLog + "?",
                     "Yes",
                     "No"))
            {
                Numbers numb = new Numbers();
                numb.number = selectedItem.phoneNumberofCallLog;
                numb.name = selectedItem.NameInCallLog;
                numb.blockType = "blockThisNumber";
                new NumbersViewModel(numb);
                await DisplayAlert("Aha!" + selectedItem.NameInCallLog + " : " + selectedItem.phoneNumberofCallLog + " blocked!", "OK", null);
            }
            await Navigation.PopModalAsync();
        }
    }
}