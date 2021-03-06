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
        ImageView _CallPhoneContractor;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RequestCard_content);

            SupportToolbar mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "������� (��������� ������)";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_action_arrow_back);
            ab.SetDisplayHomeAsUpEnabled(true);

            //C������
            listItems.Add("������-���, ��������� �.�.");
            _spinner = FindViewById<MaterialSpinner>(Resource.Id.contractor_spinner);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, listItems);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner.Adapter = adapter;
            _spinner.ItemSelected += _spinner_ItemSelected;

            //�������� ����������
            _CallPhoneContractor = FindViewById<ImageView>(Resource.Id.callPhoneContractor);
            _CallPhoneContractor.Click += _CallPhoneContractor_Click;

        }

        //�������� ���������� �������
        private void _CallPhoneContractor_Click(object sender, EventArgs e)
        {
            // Create intent to dial phone
            var callIntent = new Intent(Intent.ActionCall);
            callIntent.SetData(Android.Net.Uri.Parse("tel:123456789"));
            StartActivity(callIntent);
        }

        //������ ��������
        private void _spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                int selected_position = e.Position;
                if (selected_position % 2 == 0)
                    Console.WriteLine("������ ������");
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(item.ItemId == Android.Resource.Id.Home)
            {
                OnBackPressed();
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}