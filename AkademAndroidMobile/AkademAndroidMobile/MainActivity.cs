using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using AlertDialog = Android.App.AlertDialog;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "AkademAndroidMobile", Icon = "@drawable/icon")]
    public class MainActivity : ActionBarActivity
    {
        private ListView _mLeftDrawer;
        private DrawerLayout _mDrawerLayout;
        private MyActionBarDrawerToggle _mDrawerToggle;
        private SupportToolbar _mToolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            _mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_mToolbar);
            SupportActionBar.Title = "Заявки";
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            if (bundle != null)
            {
                if (bundle.GetString("DrawerState") == "Opened")
                {
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                }
                else
                {
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
                }
            }
            else
            {
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
            }

            //Выпадающее меню слева
            _mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            _mDrawerToggle = new MyActionBarDrawerToggle(
                this,
                _mDrawerLayout,
                Resource.String.openDrawer,
                Resource.String.closeDrawer
            );
            _mDrawerLayout.SetDrawerListener(_mDrawerToggle);
            _mDrawerToggle.SyncState();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            _mDrawerToggle.OnOptionsItemSelected(item);
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (_mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }
            else
            {
                outState.PutString("DrawerState", "Closed");
            }
            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _mDrawerToggle.SyncState();
        }
    }
}

