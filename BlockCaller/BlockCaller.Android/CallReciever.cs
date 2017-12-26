using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;
using BlockCaller.Views;
using BlockCaller.Model;
using BlockCaller.ViewModel;

namespace BlockCaller.Droid
{
    [BroadcastReceiver(Exported = true, Label = "Call Receiver")]
    [IntentFilter(new[] { "android.intent.action.PHONE_STATE" },Priority =(int)IntentFilterPriority.HighPriority)]
    public class CallReciever : BroadcastReceiver
    {
        List<string> tempList = GetNumberFromTable("PhoneNumber");

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Extras != null)
            {
                string state = intent.GetStringExtra(TelephonyManager.ExtraState);
                if (state == TelephonyManager.ExtraStateRinging)
                {
                    string telephone = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    if (!string.IsNullOrEmpty(telephone))
                    {
                        if(tempList.Contains(telephone))
                        {
                            endCall(context);
                        }
                        //Toast.MakeText(context, "Incoming call from " + telephone + ".", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(context, "Incoming call from unknown number.", ToastLength.Short).Show();
                    }
                    Intent buttonDown = new Intent(Intent.ActionMediaButton);
                    buttonDown.PutExtra(Intent.ExtraKeyEvent, new KeyEvent(KeyEventActions.Up, Keycode.Headsethook));
                    context.SendOrderedBroadcast(buttonDown, "android.permission.CALL_PRIVILEGED");
                }
                else if (state == TelephonyManager.ExtraStateOffhook)
                {
                    //Toast.MakeText(context, "Incoming call answered.", ToastLength.Short).Show();
                }
                else if (state == TelephonyManager.ExtraStateIdle)
                {
                    //Toast.MakeText(context, "Incoming call ended.", ToastLength.Short).Show();
                }
            }
        }

        public void endCall(Context context)
        {
            var manager = (TelephonyManager)context.GetSystemService(Context.TelephonyService);

            IntPtr TelephonyManager_getITelephony = JNIEnv.GetMethodID(manager.Class.Handle,
                    "getITelephony",
                    "()Lcom/android/internal/telephony/ITelephony;");

            IntPtr telephony = JNIEnv.CallObjectMethod(manager.Handle, TelephonyManager_getITelephony);
            IntPtr ITelephony_class = JNIEnv.GetObjectClass(telephony);
            //IntPtr ITelephony_silentRinger = JNIEnv.GetMethodID(ITelephony_class, "silenceRinger", "()Z");
            //JNIEnv.CallBooleanMethod(telephony, ITelephony_silentRinger);
            IntPtr ITelephony_endCall = JNIEnv.GetMethodID(ITelephony_class, "endCall", "()Z");
            JNIEnv.CallBooleanMethod(telephony, ITelephony_endCall);
            JNIEnv.DeleteLocalRef(telephony);
            JNIEnv.DeleteLocalRef(ITelephony_class);
        }

        public static List<string> GetNumberFromTable(string str)
        {
            List<string> getNumList = new List<string>();
            var dbNum = new BlockDatabase(str); // Creates (if does not exist) a database named People
            List<Numbers> temp = dbNum.Query<Numbers>("select * from Numbers where blockType = 'blockThisNumber'");
            foreach (Numbers num in temp)
            {
                getNumList.Add(num.number);
            }
            return getNumList;
        }
    }
}