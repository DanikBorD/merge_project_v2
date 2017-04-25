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
    [Activity(Theme = "@style/MyCustomTheme", Label = "ForgetPassActivity", Icon = "@drawable/icon", NoHistory = true)]
    public class ForgetPassActivity : Activity
    {
        Button _ResetButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ForgetPass);

            _ResetButton = FindViewById<Button>(Resource.Id.resetPassword);
            _ResetButton.Click += _ResetButton_Click;
        }

        private void _ResetButton_Click(object sender, EventArgs e)
        {
            var callDialog = new AlertDialog.Builder(this);
            callDialog.SetMessage("Письмо с паролем высланно вам на почту");
            callDialog.SetNeutralButton("Хорошо", delegate {});
            
            callDialog.Show();
        }
    }
}