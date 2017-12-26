using Android.Widget;
using BlockCaller.Model;
using BlockCaller.ViewModel;
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
	public partial class BlockedList : ContentPage
	{
		public BlockedList ()
		{
			InitializeComponent ();
		}

        private async Task getMyDataAsync(object sender, EventArgs e)
        {
            var allData = NumbersViewModel.GetDataFromTable("PhoneNumber");
            foreach (Numbers num in allData)
            {
                await this.DisplayAlert("Hurray!!!", num.number + " is " + num.name, "OK");
            }
        }
    }
}