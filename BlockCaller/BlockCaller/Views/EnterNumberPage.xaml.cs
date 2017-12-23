using BlockCaller.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlockCaller.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnterNumberPage : ContentPage
	{
		public EnterNumberPage ()
		{
			InitializeComponent ();
		}
        async void fetchNumber(object sender, EventArgs e)
        {
            string phNum = phCode.Text + phoneNumber.Text;

            //if(phNum.Length<11)
            if (await this.DisplayAlert(
                    "Confirmation",
                    "Do you want to block " + phNum + "?",
                    "Yes",
                    "No"))
            {
                NumberToBlock.numberToBlock.Add(phNum);
                await this.DisplayAlert("Hurray!!!",phNum+" is blocked successfully!!!","OK");
                await Navigation.PopModalAsync();
            }
        }

        async void cancelDialog(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        //private void validatePhoneNumber(object sender, TextChangedEventArgs e)
        //{
        //    if(e.NewTextValue.Length>10)
        //    {
        //        Submit.Focus();
        //    }
        //}
    }
}