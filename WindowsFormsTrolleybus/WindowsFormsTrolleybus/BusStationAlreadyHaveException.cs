using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTrolleybus
{
    class BusStationAlreadyHaveException : Exception
    {
        public BusStationAlreadyHaveException() : base("На автовокзале уже есть такая машина")
        { }
    }
}
