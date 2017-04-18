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
using FR.Ganfra.Materialspinner;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "CreationActivity", Icon = "@drawable/icon")]
    public class CreationActivity : AppCompatActivity
    {
        private DrawerLayout _mDrawerLayout;
        Button _dateSelectButton, _timeSelectButton;

        MaterialSpinner _spinner;
        List<int> listItems = new List<int>();
        ArrayAdapter<int> adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Creation);

            //Инициализация кастомного тулбара
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
            _timeSelectButton.Click += TimeSelect_OnClick;
            _timeSelectButton.Text = DateTime.Now.ToString("HH:mm"); //Начальное время (текущее)

            InitItems();
            _spinner = FindViewById<MaterialSpinner>(Resource.Id.defect_spinner);
            adapter = new ArrayAdapter<int>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner.Adapter = adapter;
            _spinner.ItemSelected += _spinner_ItemSelected;

        }

        private void _spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                int selected = int.Parse(_spinner.GetItemAtPosition(e.Position).ToString());
                if (selected % 2 == 0)
                    _spinner.Error = "This is Error";
            }
        }

        private void InitItems()
        {
            for (int i = 1; i <= 100; i++)
                listItems.Add(i);
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

        //При клике на выбор даты
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateSelectButton.Text = time.ToString("d", CultureInfo.CreateSpecificCulture("ru-RU"));
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        //При клике на выбор времени
        private void TimeSelect_OnClick(object sender, EventArgs eventArgs)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(delegate (DateTime time)
            {
                _timeSelectButton.Text = time.ToString("HH:mm");
            });
            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }
    }
}