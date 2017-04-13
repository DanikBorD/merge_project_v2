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
    [Activity(Theme = "@style/MyCustomTheme", Label = "CreationActivity", Icon = "@drawable/icon")]
    public class CreationActivity : AppCompatActivity
    {
        private DrawerLayout _mDrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Creation);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Новая заявка";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
            ab.SetDisplayHomeAsUpEnabled(true);

            //Выпадающее меню слева
            _mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            NavigationView mLeftDrawer = FindViewById<NavigationView>(Resource.Id.left_drawer);
            if (mLeftDrawer != null)
            {
                SetUpDrawerContent(mLeftDrawer);
            }

        }

        //Скрывает навигацию по клику, на любой item навигации (вроде)
        private void SetUpDrawerContent(NavigationView mLeftDrawer)
        {
            mLeftDrawer.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                _mDrawerLayout.CloseDrawers();
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //Обрабатывает клик по бургеру, и выводит навигацию
                    _mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}