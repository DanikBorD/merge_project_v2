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
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "AkademAndroidMobile", Icon = "@drawable/icon")]
    public class ContactsActivity : AppCompatActivity
    {
        private DrawerLayout _mDrawerLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Contacts);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Контакты";
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

        //Навигация по клику
        private void SetUpDrawerContent(NavigationView mLeftDrawer)
        {
            mLeftDrawer.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                #region Переход на другую активити.

                var menuItem = e.MenuItem;
                //menuItem.SetChecked(true);

                Intent intent = new Intent();

                switch (menuItem.ItemId)
                {
                    case Resource.Id.nav_create_req:
                        intent = new Intent(this, typeof(CreationActivity));
                        StartActivity(intent);
                        Finish();
                        break;

                    case Resource.Id.nav_list_req:
                        intent = new Intent(this, typeof(MainActivity));
                        StartActivity(intent);
                        Finish();
                        break;

                    case Resource.Id.nav_exit:
                        intent = new Intent(this, typeof(LoginActivity));
                        StartActivity(intent);
                        Finish();
                        break;
                }

                #endregion
                _mDrawerLayout.CloseDrawers();
            };
        }

        //Функция при выборе пункта меню
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