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

namespace AkademAndroidMobile
{
    [Activity(Label = "ChangeActivity1")]
    public class ChangeActivity : Activity
    {
        CheckBox IsAuto;
        TextView RoomTemp;
        TextView ConditionalTemp;
        TextView HeaterTemp;
        Button RoomTempUp;
        Button RoomTempDown;
        Button ConditionalTempUp;
        Button ConditionalTempDown;
        Button HeaterTempUp;
        Button HeaterTempDown;
        Button Accept;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ChangeTemp);

            IsAuto = FindViewById<CheckBox>(Resource.Id.IsAutomaticCheckBox);
            RoomTemp = FindViewById<TextView>(Resource.Id.RoomTemperatureTextView);
            ConditionalTemp = FindViewById<TextView>(Resource.Id.ConditionalTemperatureTextView);
            HeaterTemp = FindViewById<TextView>(Resource.Id.HeaterTemperatureTextView);
            RoomTempUp = FindViewById<Button>(Resource.Id.UpRoomTemperatureButton);
            RoomTempDown = FindViewById<Button>(Resource.Id.DownRoomTemperatureButton);
            ConditionalTempUp = FindViewById<Button>(Resource.Id.UpConditionalTemperatureButton);
            ConditionalTempDown = FindViewById<Button>(Resource.Id.DownConditionalTemperatureButton);
            HeaterTempUp = FindViewById<Button>(Resource.Id.UpHeaterTemperatureButton);
            HeaterTempDown = FindViewById<Button>(Resource.Id.DownHeaterTemperatureButton);
            Accept = FindViewById<Button>(Resource.Id.AcceptBtn);

            RoomTempUp.Click += RoomTempUp_Click;
            RoomTempDown.Click += RoomTempDown_Click;

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
    }
}