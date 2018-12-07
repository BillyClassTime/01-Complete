using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
//21_EventossYDatosTimer
namespace _01_Complete
{
    class EventosYDatosTimer : IDisposable
    {
        private Timer timer = new Timer();
        EventosYDatosTimer(int interval)
        {
            timer.Interval = interval;
        }

        private int suma;

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}