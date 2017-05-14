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
using System.Threading;

namespace scada_dispetcher_station
{
    class Manager
    {
        Termometr trmInside = new Termometr(1);
        Termometr trmTop = new Termometr(2);
        Termometr trmFan = new Termometr(3);
        Termometr trmStreet = new Termometr(4);
        Flap flapIndide = new Flap(1);
        Flap flapStreet = new Flap(2);
        Conditional cond = new Conditional();
        Heater heat = new Heater();

        public Manager() { }

        public void Actionss()
        {
            trmInside.ReadDM();
            trmTop.ReadDM();
            trmFan.ReadDM();
            trmStreet.ReadDM();
            flapIndide.ReadDM();
            flapStreet.ReadDM();
            cond.ReadDM();
            heat.ReadDM();
        }
    }
    
}
