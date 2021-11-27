using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTrolleybus
{
    class BusStationNotFoundException : Exception
    {
        public BusStationNotFoundException(int i) : base("Не найден автомобиль по месту "+ i)
        { }
    }
}
