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
using Android.Graphics;

namespace AkademAndroidMobile
{
    [Activity(Label = "ChangeActivity1")]
    public class ChangeActivity : Activity
    {
        CheckBox IsAuto;
        TextView RoomTemp;
        TextView ConditionalTemp;
        TextView HeaterTemp;
        ImageButton RoomTempUp;
        ImageButton RoomTempDown;
        ImageButton ConditionalTempUp;
        ImageButton ConditionalTempDown;
        ImageButton HeaterTempUp;
        ImageButton HeaterTempDown;
        ImageButton Accept;
        LinearLayout roomLine;
        LinearLayout condLine1;
        LinearLayout condLine2;
        LinearLayout heatLine1;
        LinearLayout heatLine2;
        ToggleButton condToggleBtn;
        ToggleButton heatToggleBtn;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ChangeTemp);

            IsAuto = FindViewById<CheckBox>(Resource.Id.IsAutomaticCheckBox);
            RoomTemp = FindViewById<TextView>(Resource.Id.RoomTemperatureTextView);
            ConditionalTemp = FindViewById<TextView>(Resource.Id.ConditionalTemperatureTextView);
            HeaterTemp = FindViewById<TextView>(Resource.Id.HeaterTemperatureTextView);
            RoomTempUp = FindViewById<ImageButton>(Resource.Id.UpRoomTemperatureButton);
            RoomTempDown = FindViewById<ImageButton>(Resource.Id.DownRoomTemperatureButton);
            ConditionalTempUp = FindViewById<ImageButton>(Resource.Id.UpConditionalTemperatureButton);
            ConditionalTempDown = FindViewById<ImageButton>(Resource.Id.DownConditionalTemperatureButton);
            HeaterTempUp = FindViewById<ImageButton>(Resource.Id.UpHeaterTemperatureButton);
            HeaterTempDown = FindViewById<ImageButton>(Resource.Id.DownHeaterTemperatureButton);
            Accept = FindViewById<ImageButton>(Resource.Id.AcceptBtn);
            roomLine = FindViewById<LinearLayout>(Resource.Id.roomLine);
            condLine1 = FindViewById<LinearLayout>(Resource.Id.condLine1);
            condLine2 = FindViewById<LinearLayout>(Resource.Id.condLine2);
            heatLine1 = FindViewById<LinearLayout>(Resource.Id.heatLine1);
            heatLine2 = FindViewById<LinearLayout>(Resource.Id.heatLine2);
            condToggleBtn = FindViewById<ToggleButton>(Resource.Id.ConditionalToggleButton);
            heatToggleBtn = FindViewById<ToggleButton>(Resource.Id.HeaterToggleButton);

            RoomTempUp.Click += RoomTempUp_Click;
            RoomTempDown.Click += RoomTempDown_Click;

            ConditionalTempUp.Click += ConditionalTempUp_Click;
            ConditionalTempDown.Click += ConditionalTempDown_Click;

            HeaterTempUp.Click += HeaterTempUp_Click;
            HeaterTempDown.Click += HeaterTempDown_Click;

            Accept.Click += Accept_Click;

            IsAuto.CheckedChange += IsAuto_CheckedChanged;

            if(IsAuto.Checked)
            {
                condLine1.SetBackgroundColor(Color.Gray);
                condLine2.SetBackgroundColor(Color.Gray);

                heatLine1.SetBackgroundColor(Color.Gray);
                heatLine2.SetBackgroundColor(Color.Gray);
            }
            else
            {
                condLine1.SetBackgroundColor(Color.Green);
                condLine2.SetBackgroundColor(Color.Green);

                heatLine1.SetBackgroundColor(Color.Green);
                heatLine2.SetBackgroundColor(Color.Green);
            }
        }


        private void IsAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(!IsAuto.Checked)
            { 
                condLine1.SetBackgroundColor(Color.Green);
                condLine2.SetBackgroundColor(Color.Green);

                heatLine1.SetBackgroundColor(Color.Green);
                heatLine2.SetBackgroundColor(Color.Green);
            }
            else
            {
                condLine1.SetBackgroundColor(Color.Gray);
                condLine2.SetBackgroundColor(Color.Gray);

                heatLine1.SetBackgroundColor(Color.Gray);
                heatLine2.SetBackgroundColor(Color.Gray);
            }
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            OverridePendingTransition(Android.Resource.Animation.SlideOutRight, Android.Resource.Animation.SlideInLeft);
        }


        private void RoomTempDown_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(RoomTemp.Text) - 1;
            RoomTemp.Text = val.ToString();
        }

        private void RoomTempUp_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(RoomTemp.Text) + 1;
            RoomTemp.Text = val.ToString();
        }


        private void ConditionalTempDown_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(ConditionalTemp.Text) - 1;
            ConditionalTemp.Text = val.ToString();
        }

        private void ConditionalTempUp_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(ConditionalTemp.Text) + 1;
            ConditionalTemp.Text = val.ToString();
        }


        private void HeaterTempDown_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(HeaterTemp.Text) - 1;
            HeaterTemp.Text = val.ToString();
        }

        private void HeaterTempUp_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(HeaterTemp.Text) + 1;
            HeaterTemp.Text = val.ToString();
        }
    }
}