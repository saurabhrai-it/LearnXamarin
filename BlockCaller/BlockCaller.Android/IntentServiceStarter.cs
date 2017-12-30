
using Android.App;
using Android.Content;

namespace BlockCaller.Droid
{
    public class IntentServiceStarter
    {
        public static void StartIntentService(Context context, string str)
        {
            Intent getNumberIntent = new Intent(context, typeof(FetchNumbersBackground));
            getNumberIntent.PutExtra("blockType", str);
            Application.Context.StartService(getNumberIntent);
        }
    }
}