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

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "AkademAndroidMobile", Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {

        EditText ip;
        EditText port;
        Button connectBtn;
        bool isSuccessConnect = true;
        string ipText = "";
        string portText = "";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);

            ip = FindViewById<EditText>(Resource.Id.ip);
            port = FindViewById<EditText>(Resource.Id.port);
            connectBtn = FindViewById<Button>(Resource.Id.connectBtn);
            connectBtn.Click += connectBtn_Click;


        }


        private void connectBtn_Click(object sender, EventArgs e)
        {
            ipText = ip.Text == null ? "" : ip.Text;
            portText = port.Text == null ? "" : port.Text;

            if (!(IsConnect(ipText, portText)))
            {
                Toast.MakeText(this, "Соединение не установлено, попробуйте еще раз", ToastLength.Long). Show();

            }
            Toast.MakeText(this, "Соединение установлено!", ToastLength.Long).Show();

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            OverridePendingTransition(Android.Resource.Animation.SlideOutRight, Android.Resource.Animation.SlideInLeft);
        }

        public bool IsConnect(string ip, string port)
        {
            #region tcp
            //public mcOMRON.OmronPLC plc;
            //this.plc = new mcOMRON.OmronPLC(mcOMRON.TransportType.Tcp);     
            #endregion

            bool IsOK = false;
            //if (ip == "" || port == "") 
			//{
				//Toast.MakeText(this, "Соединение не установлено, попробуйте еще раз", ToastLength.Long).Show();
				//return IsOK;
			//}


            #region tcp
            //try
            //{
            //    mcomron.tcpfinscommand tcpcommand = ((mcomron.tcpfinscommand)plc.finscommand);
            //    tcpcommand.settcpparams(ipaddress.parse(ip), convert.toint32(port));

            //    if (!plc.connect())
            //    {
            //        throw new exception(plc.lasterror);
            //    }
            //}
            //catch (exception ex)
            //{
            //    return isok;
            //}

            //try
            //{
            //    if (!plc.finsconnectiondataread(0))
            //    {
            //        throw new exception(plc.lasterror);
            //    }

            //}
            //catch (exception ex)
            //{
            //    return isok;
            //}
            //IsOK = true;

            //return IsOK;
            #endregion
            return true;
        }
    }
}