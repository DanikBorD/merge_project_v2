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
using FR.Ganfra.Materialspinner;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "RequestCardActivity", Icon = "@drawable/icon")]
    public class RequestCardActivity : AppCompatActivity
    {
        MaterialSpinner _spinner;
        List<string> listItems = new List<string>();
        ArrayAdapter<string> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RequestCard_content);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Домофон (первичная заявка)";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_add_white_24dp);
            ab.SetDisplayHomeAsUpEnabled(true);

            //Cпиннер

            listItems.Add("Мастер-Дом, Парамонов О.С.");
            _spinner = FindViewById<MaterialSpinner>(Resource.Id.contractor_spinner);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner.Adapter = adapter;
            _spinner.ItemSelected += _spinner_ItemSelected;

        }

        //Функия спиннера
        private void _spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                int selected = int.Parse(_spinner.GetItemAtPosition(e.Position).ToString());
                if (selected % 2 == 0)
                    _spinner.Error = "This is Error";
            }
        }
        
    }
}