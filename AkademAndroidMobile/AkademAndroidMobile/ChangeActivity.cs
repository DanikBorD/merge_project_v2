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
using System.Threading.Tasks;

namespace AkademAndroidMobile
{
    [Activity(Label = "ChangeActivity1")]
    public class ChangeActivity : Activity
    {
        int MaxDiff;

        CheckBox IsAuto;
        TextView RoomTempDiff;
        TextView RoomTemp;
        TextView ConditionalTemp;
        TextView HeaterTemp;
        ImageButton RoomTempDiffUp;
        ImageButton RoomTempDiffDown;
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

        Conditional cond = new Conditional();
        Heater heat = new Heater();
        Manager manager = new Manager();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ChangeTemp);

            IsAuto = FindViewById<CheckBox>(Resource.Id.IsAutomaticCheckBox);
            RoomTempDiff = FindViewById<TextView>(Resource.Id.RoomTemperatureDiffTextView);
            RoomTemp = FindViewById<TextView>(Resource.Id.RoomTemperatureTextView);
            ConditionalTemp = FindViewById<TextView>(Resource.Id.ConditionalTemperatureTextView);
            HeaterTemp = FindViewById<TextView>(Resource.Id.HeaterTemperatureTextView);
            RoomTempDiffUp = FindViewById<ImageButton>(Resource.Id.UpRoomTemperatureDiffButton);
            RoomTempDiffDown = FindViewById<ImageButton>(Resource.Id.DownRoomTemperatureDiffButton);
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

            MaxDiff = Convert.ToUInt16(RoomTempDiff.Text);
            bool IsAutoCheck = IsAutoReadDM();
            int roomTemp = RoomTempReadDM();


            RoomTemp.Text = roomTemp.ToString();
            ConditionalTemp.Text = cond.ReadDM().ToString();
            HeaterTemp.Text = heat.ReadDM().ToString();

            if (IsAutoCheck)
            {
                IsAuto.Checked = true;
            }
            else
            {
                IsAuto.Checked = false;
            }

            RoomTempDiffUp.Click += RoomTempDiffUp_Click;
            RoomTempDiffDown.Click += RoomTempDiffDown_Click;

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

        private void RoomTempDiffDown_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(RoomTempDiff.Text) - 1;
            RoomTempDiff.Text = val.ToString();
        }

        private void RoomTempDiffUp_Click(object sender, EventArgs e)
        {
            int val = Convert.ToUInt16(RoomTempDiff.Text) + 1;
            RoomTempDiff.Text = val.ToString();
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

        public bool IsAutoReadDM()
        {
            #region plc
            //bool isAutoCheck;
            //UInt16 result = 0;
            //UInt16 dm_position = 100;

            //if(NumberOfFlap == 2)
            //{
            //    dm_position = 102;
            //}
            //readFlap = 0;
            //bool in_2_0 = false;
            //bool in_2_1 = false;
            //bool in_2_2 = false;
            //bool in_2_3 = false;

            //try
            //{
            //    result = cnn.plc.ReadDM(dm_position, ref statusFlap);
            //    if (!cnn.plc.ReadDM(dm_position, ref statusFlap))
            //    {
            //        throw new Exception(this.cnc.plc.LastError);
            //    }

            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(1)) == Convert.ToUInt16(1)) in_2_0 = true;
            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(2)) == Convert.ToUInt16(2)) in_2_1 = true;
            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(4)) == Convert.ToUInt16(4)) in_2_2 = true;
            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(8)) == Convert.ToUInt16(8)) in_2_3 = true;


            //    if (result == 1)
            //    {
            //        isAutoCheck = true;
            //    }

            //    if (result == 0)
            //    {
            //        isAutoCheck = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ReadDM() Error: " + ex.Message + ex.Source);              !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //}

            //return result;
            #endregion
            return true;
        }

        public int RoomTempReadDM()
        {
            #region plc
            //bool isAutoCheck;
            //UInt16 result = 0;
            //UInt16 dm_position = 100;

            //if(NumberOfFlap == 2)
            //{
            //    dm_position = 102;
            //}
            //readFlap = 0;
            //bool in_2_0 = false;
            //bool in_2_1 = false;
            //bool in_2_2 = false;
            //bool in_2_3 = false;

            //try
            //{
            //    result = cnn.plc.ReadDM(dm_position, ref statusFlap);
            //    if (!cnn.plc.ReadDM(dm_position, ref statusFlap))
            //    {
            //        throw new Exception(this.cnc.plc.LastError);
            //    }

            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(1)) == Convert.ToUInt16(1)) in_2_0 = true;
            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(2)) == Convert.ToUInt16(2)) in_2_1 = true;
            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(4)) == Convert.ToUInt16(4)) in_2_2 = true;
            //    if ((Convert.ToUInt16(statusFlap) & Convert.ToUInt16(8)) == Convert.ToUInt16(8)) in_2_3 = true;


            //    if (result == 1)
            //    {
            //        isAutoCheck = true;
            //    }

            //    if (result == 0)
            //    {
            //        isAutoCheck = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ReadDM() Error: " + ex.Message + ex.Source);              !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //}

            //return result;
            #endregion
            return 5;
        }
    }
}