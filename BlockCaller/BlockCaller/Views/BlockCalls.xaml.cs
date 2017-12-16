using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlockCaller.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlockCalls : ContentPage
	{
		public BlockCalls ()
		{
			InitializeComponent ();
		}

        private void BlockAllExceptFew(object sender, EventArgs e)
        {

        }

        async void BlockSome(object sender, EventArgs e)
        {
            //var optionMenu = new OptionMenu();
            //optionMenu.loadMenu();
            String action = await DisplayActionSheet(null, "Cancel", null, "From Contact", "From Call Log", "Enter Manually");
            if (action.Equals("From Contact"))
            {

            }
            if (action.Equals("From Call Log"))
            {
                await Navigation.PushModalAsync(new GetPhoneNumberList());
            }
            if (action.Equals("Enter Manually"))
            {
                var enterNumberPage = new EnterNumberPage();
                await Navigation.PushModalAsync(enterNumberPage);
            }
        }

        private void BlockAllByStartDigit(object sender, EventArgs e)
        {

        }

        private void BlockAll(object sender, ToggledEventArgs e)
        {

        }
    }
}