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
using System.Threading.Tasks;

namespace scada_dispetcher_station
{
    class Conditional
    {
        //ToggleButton btn = FindViewById<ToggleButton>(Resource.Layout.ConditionalToggleButton);
        //TextView txtView = FindViewById<TextView>(Resource.Layout.ConditionalTemperatureTextView);
        Connect cnn;
        public UInt16 readConditional;
        public UInt16 statusConditional;

        public Conditional()
        {
            this.cnn = cnn;
        }

        public async Task<bool> TurnOnOff(UInt16 onoff)
        {
            #region tcp
            //bool result = false;
            //UInt16 dm_position = 6;

            //try
            //{
            //    result = cnn.plc.WriteCIO(Convert.ToUInt16(dm_position), onoff);
            //    if (!result)
            //    {
            //        throw new Exception(cnn.plc.LastError);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("WriteDM() error: " + ex.Message);           
            //}

            //result = true;
            //return result;
            #endregion

            //if (onoff == 1)
            //{
            //    btn.Activated = true;
            //    //txtView.Text = ReadDM().ToString();
            //    txtView.Text = "0";
            //}
            //else
            //{
            //    btn.Activated = false;
            //    txtView.Text = "-";
            //}
            return true;
            
        }


        public async Task<bool> SetValue(UInt16 value)
        {
            #region tcp
            //bool result = false;
            //UInt16 dm_position = 6;
            //byte valuebites = Convert.ToByte(value);
            //try
            //{
            //    result = cnn.plc.WriteCIO(Convert.ToUInt16(dm_position), valuebites);
            //    if (!result)
            //    {
            //        throw new Exception(cnn.plc.LastError);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("WriteDM() error: " + ex.Message);           
            //}

            //result = true;
            //return result;
            #endregion


            //txtView.Text = value.ToString();
            return true;
        }

       

        public async Task<UInt16> ReadDM()
        {
            #region tcp
            //UInt16 result = 0;
            //UInt16 dm_position = 116;

            //readConditional = 0;
            //bool in_2_0 = false;
            //bool in_2_1 = false;
            //bool in_2_2 = false;
            //bool in_2_3 = false;

            //try
            //{
            //    result = cnn.plc.ReadDM(dm_position, ref statusConditional);
            //    if (!cnn.plc.ReadDM(dm_position, ref statusConditional))
            //    {
            //        throw new Exception(this.cnc.plc.LastError);
            //    }

            //    if ((Convert.ToUInt16(statusConditional) & Convert.ToUInt16(1)) == Convert.ToUInt16(1)) in_2_0 = true;
            //    if ((Convert.ToUInt16(statusConditional) & Convert.ToUInt16(2)) == Convert.ToUInt16(2)) in_2_1 = true;
            //    if ((Convert.ToUInt16(statusConditional) & Convert.ToUInt16(4)) == Convert.ToUInt16(4)) in_2_2 = true;
            //    if ((Convert.ToUInt16(statusConditional) & Convert.ToUInt16(8)) == Convert.ToUInt16(8)) in_2_3 = true;

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ReadDM() Error: " + ex.Message + ex.Source);              !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //}
            //txtView.Text = result.ToString();
            //return result;
#endregion

            //txtView.Text = "0";
            return 1;
        }
    }
}