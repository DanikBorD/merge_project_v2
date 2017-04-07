using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;

namespace AkademAndroidMobile
{
    class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        private ActionBarActivity _mHostActivity;
        private int _mOpenResource;
        private int _mClosedResource;
        public MyActionBarDrawerToggle(ActionBarActivity host, DrawerLayout drawerLayout, int openedResource, int closedResource)
            : base(host, drawerLayout, openedResource, closedResource)
        {
            _mHostActivity = host;
            _mOpenResource = openedResource;
            _mClosedResource = closedResource;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            _mHostActivity.SupportActionBar.SetTitle(_mOpenResource);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            _mHostActivity.SupportActionBar.SetTitle(_mClosedResource);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}