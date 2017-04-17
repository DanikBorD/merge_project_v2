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
using AkademAndroidMobile.Resources.fragments;
using System.Globalization;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "CreationActivity", Icon = "@drawable/icon")]
    public class CreationActivity : AppCompatActivity
    {
        private DrawerLayout _mDrawerLayout;
        Button _dateSelectButton, _timeSelectButton;

        private int hour;
        private int minute;

        const int TIME_DIALOG_ID = 0;

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

            //Выбор даты
            _dateSelectButton = FindViewById<Button>(Resource.Id.InputDate);
            _dateSelectButton.Click += DateSelect_OnClick;

            //Выбор времени
            _timeSelectButton = FindViewById<Button>(Resource.Id.InputTime);
            _timeSelectButton.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);

            // Get the current time
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;

            // Display the current date
            UpdateDisplay();
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

        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateSelectButton.Text = time.ToString("d", CultureInfo.CreateSpecificCulture("ru-RU"));
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void UpdateDisplay()
        {
            string time = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            _timeSelectButton.Text = time;
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            UpdateDisplay();
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == TIME_DIALOG_ID)
                return new TimePickerDialog(this, TimePickerCallback, hour, minute, true);

            return null;
        }
    }
}