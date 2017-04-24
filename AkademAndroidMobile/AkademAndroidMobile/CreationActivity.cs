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

        MaterialSpinner _spinner1, _spinner2;
        List<string> listItems1 = new List<string>();
        List<string> listItems2 = new List<string>();
        ArrayAdapter<string> adapter1, adapter2;


        //Листинг обьектов для автокомплита
        static string[] COUNTRIES = new string[] {
          "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra",
          "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Argentina",
          "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan"
        };

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



            //Select инициализация и выбор спинеров
            //Инициализация обектов спиннера
            listItems1.Add("Неисправность - 1");
            listItems1.Add("Неисправность - 2");
            listItems2.Add("Подрядчик - 1");
            listItems2.Add("Подрядчик - 2");

            //Первый спиннер
            _spinner1 = FindViewById<MaterialSpinner>(Resource.Id.defect_spinner);
            adapter1 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems1);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner1.Adapter = adapter1;
            _spinner1.ItemSelected += _spinner_ItemSelected;

            //Второй спиннер
            _spinner2 = FindViewById<MaterialSpinner>(Resource.Id.contractor_spinner);
            adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems2);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner2.Adapter = adapter2;
            _spinner2.ItemSelected += _spinner_ItemSelected;


            //Парящая кнопка
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) =>
            {
                View anchor = o as View;

                Snackbar.Make(anchor, "Ваша заявка созданна", Snackbar.LengthLong)
                        .SetAction("К списку звявок", v =>
                        {
                            Intent intent = new Intent(fab.Context, typeof(MainActivity));
                            StartActivity(intent);
                            Finish();
                            OverridePendingTransition(Android.Resource.Animation.SlideOutRight, Android.Resource.Animation.SlideInLeft);
                        })
                        .Show();
            };

            //Автокомплит
            AutoCompleteTextView textView = FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete_txtInputHouse);
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.autocomplete, COUNTRIES);

            textView.Adapter = adapter;

        }

        //Функия спиннера
        private void _spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                int selected_position = e.Position;
                if (selected_position % 2 == 0)
                    Console.WriteLine("Ошибка выбора");
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
                    case Resource.Id.nav_list_req:
                        intent = new Intent(this, typeof(MainActivity));
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