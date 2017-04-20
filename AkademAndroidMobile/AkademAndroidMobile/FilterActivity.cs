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
using Android.Support.Design.Widget;
using FR.Ganfra.Materialspinner;

namespace AkademAndroidMobile
{
    [Activity(Theme = "@style/MyCustomTheme", Label = "FilterActivity", Icon = "@drawable/icon")]
    public class FilterActivity : AppCompatActivity
    {

        MaterialSpinner _spinner1, _spinner2, _spinner3, _spinner4, _spinner5;
        List<string> listItems1 = new List<string>();
        List<string> listItems2 = new List<string>();
        List<string> listItems3 = new List<string>();
        List<string> listItems4 = new List<string>();
        List<string> listItems5 = new List<string>();
        ArrayAdapter<string> adapter1, adapter2, adapter3, adapter4, adapter5;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Filter_content);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Фильтр";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_action_arrow_back);
            ab.SetDisplayHomeAsUpEnabled(true);

            //Select инициализация и выбор спинеров
            //Инициализация обектов спиннера
            listItems1.Add("Неисправность - 1");
            listItems1.Add("Неисправность - 2");
            listItems2.Add("Заявка выполненна");
            listItems2.Add("Проверенна");
            listItems3.Add("Подрядчик - 1");
            listItems3.Add("Подрядчик - 2");
            listItems4.Add("Ответственный - 1");
            listItems4.Add("Ответственный - 2");
            listItems5.Add("Исполнитель - 1");
            listItems5.Add("Исполнитель - 2");

            //Парящая кнопка
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) =>
            {
                View anchor = o as View;

                Intent intent = new Intent(fab.Context, typeof(MainActivity));
                StartActivity(intent);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
            };

            //Первый спиннер
            _spinner1 = FindViewById<MaterialSpinner>(Resource.Id.defect_spinner);
            adapter1 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems1);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner1.Adapter = adapter1;
            _spinner1.ItemSelected += _spinner_ItemSelected;

            //Второй спиннер
            _spinner2 = FindViewById<MaterialSpinner>(Resource.Id.request_status);
            adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems2);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner2.Adapter = adapter2;
            _spinner2.ItemSelected += _spinner_ItemSelected;

            //Третий спиннер
            _spinner3 = FindViewById<MaterialSpinner>(Resource.Id.contractor_spinner);
            adapter3 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems3);
            adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner3.Adapter = adapter3;
            _spinner3.ItemSelected += _spinner_ItemSelected;

            //4 спиннер
            _spinner4 = FindViewById<MaterialSpinner>(Resource.Id.responsible);
            adapter4 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems4);
            adapter4.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner4.Adapter = adapter4;
            _spinner4.ItemSelected += _spinner_ItemSelected;

            //5 спиннер
            _spinner5 = FindViewById<MaterialSpinner>(Resource.Id.executor);
            adapter5 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems5);
            adapter5.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner5.Adapter = adapter5;
            _spinner5.ItemSelected += _spinner_ItemSelected;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Filter_menus, menu);
            return true;
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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //Обрабатывает клик по бургеру, и выводит навигацию
                    OnBackPressed();
                    return base.OnOptionsItemSelected(item);

                default:
                    Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}