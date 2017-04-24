using System;
using System.Collections.Generic;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "AkademAndroidMobile", Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _mDrawerLayout;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Заявки";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
            ab.SetDisplayHomeAsUpEnabled(true);

            //Выпадающее меню слева
            _mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            NavigationView mLeftDrawer = FindViewById<NavigationView>(Resource.Id.left_drawer);
            if (mLeftDrawer != null)
            {
                SetUpDrawerContent(mLeftDrawer);
            }

            //Клик по карточке
            FrameLayout _mCardView = FindViewById<FrameLayout>(Resource.Id.test_card_id);
            _mCardView.Click += _mCardView_Click;
            _mCardView.LongClick += _mCardView_LongClick;

            //Парящая кнопка
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) =>
            {
                View anchor = o as View;

                Intent intent = new Intent(fab.Context, typeof(CreationActivity));
                StartActivity(intent);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
            };

        }

        

        //Клик по карточке функция
        private void _mCardView_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RequestCardActivity));
            StartActivity(intent);
            OverridePendingTransition(Android.Resource.Animation.SlideOutRight, Android.Resource.Animation.SlideInLeft);
        }

        //Длинный по карточке функция
        private void _mCardView_LongClick(object sender, View.LongClickEventArgs e)
        {
            Toast.MakeText(this, "Длинный клик", ToastLength.Short).Show();
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

                    case Resource.Id.nav_contacts:
                        intent = new Intent(this, typeof(ContactsActivity));
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

        //Создание меню в тулбаре
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Top_menus, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //Обрабатывает клик по бургеру, и выводит навигацию
                    _mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                case Resource.Id.menu_filter:
                    Intent intent = new Intent(this, typeof(FilterActivity));
                    StartActivity(intent);
                    return true;

                default:
                    Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
                    return base.OnOptionsItemSelected(item);
            }
        }

    }
}

