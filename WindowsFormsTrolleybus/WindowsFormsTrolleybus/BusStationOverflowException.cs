using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTrolleybus
{
    class BusStationOverflowException : Exception
    {
        public BusStationOverflowException() : base("На парковке нет свободных мест")
        { }
    }
}
