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
    class Flap
    {
        //Connect cnn;
        public int NumberOfFlap;
		public float Angle;
        public UInt16 writeOpenFlap = Convert.ToUInt16(1);
        public UInt16 writeCloseFlap = Convert.ToUInt16(2);
        public UInt16 readFlap;
        public UInt16 statusFlap;

        public Flap(int numberOfFlap)
        {
            //this.cnn = cnn;
            this.NumberOfFlap = numberOfFlap;
        }

		public async Task<bool> WriteOpen(float angle)
        {
            //bool result = false;
            //UInt16 dm_position = 5;

            //if (NumberOfFlap == 2)
            //{
            //    writeOpenFlap = Convert.ToUInt16(4);
            //}

			
            //try
            //{
            //    result = cnn.plc.WriteCIO(Convert.ToUInt16(dm_position), writeOpenFlap, angle);
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

            return true;
        }

        public async Task<bool> WriteClose(float angle)
        {
            //bool result = false;
            //UInt16 dm_position = 5;
            //if (NumberOfFlap == 2)
            //{
            //    writeOpenFlap = Convert.ToUInt16(8);
            //}

            //try
            //{
            //    result = cnn.plc.WriteCIO(Convert.ToUInt16(dm_position), writeCloseFlap);
            //    if (!result)
            //    {
            //        throw new Exception(cnn.plc.LastError);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("WriteDM() error: " + ex.Message);                  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //}

            //result = true;
            //return result;

            return true;
        }

        public async Task<UInt16> ReadDM()
        {
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


            //    if (in_2_0)
            //    {
            //        string status = "Полностью открыто";
            //    }

            //    if (in_2_1)
            //    {
            //        string status = "Полностью закрыто";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ReadDM() Error: " + ex.Message + ex.Source);              !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //}

            //return result;

            return 1;
        }
    }

    
}