using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "RequestCardActivity", Icon = "@drawable/icon")]
    public class RequestCardActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RequestCard_content);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Домофон (первичная заявка)";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_add_white_24dp);
            ab.SetDisplayHomeAsUpEnabled(true);

        }
    }
}