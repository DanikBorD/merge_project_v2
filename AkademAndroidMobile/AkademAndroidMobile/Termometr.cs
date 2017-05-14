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
    class Termometr
    {
        Connect cnn;
        public int NumberOfTemometer;
        public int temperature;
        public int normalTemperature;
        public int maxDifference;
        public int difference;
        public UInt16 tmpFromPLC;

        public Termometr(int numberOfTermometer)
        {
            this.cnn = cnn;
            this.NumberOfTemometer = numberOfTermometer;
        }

        public async Task<UInt16> ReadDM()
        {
            //UInt16 dm_position;

            //if (NumberOfTemometer == 1)
            //{
            //    dm_position = 104;
            //}

            //else if (NumberOfTemometer == 2)
            //{
            //    dm_position = 106;
            //}


            //else if (NumberOfTemometer == 3)
            //{
            //    dm_position = 108;
            //}


            //else
            //{
            //    dm_position = 110;
            //}

            //try
            //{
            //    bool result = cnn.plc.ReadDM(dm_position, ref tmpFromPLC);
            //    if (!result)
            //    {
            //        throw new Exception(cnn.plc.LastError);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ReadDM() Error: " + ex.Message);                         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //}

            //return tmpFromPLC;
            return 1;
        }
    }
}