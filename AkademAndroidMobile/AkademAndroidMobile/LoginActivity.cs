﻿using System;
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
        Button _mButton, _ForgetPassButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);

            _mButton = FindViewById<Button>(Resource.Id.signInBtn);
            _mButton.Click += _mButton_Click;

            _ForgetPassButton = FindViewById<Button>(Resource.Id.reestablishPassBtn);
            _ForgetPassButton.Click += _ForgetPassButton_Click;

        }

        private void _ForgetPassButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ForgetPassActivity));
            StartActivity(intent);
        }

        private void _mButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            OverridePendingTransition(Android.Resource.Animation.SlideOutRight, Android.Resource.Animation.SlideInLeft);
        }
    }
}