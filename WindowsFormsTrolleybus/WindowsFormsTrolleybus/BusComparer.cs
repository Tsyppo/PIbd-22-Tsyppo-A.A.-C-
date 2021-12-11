using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTrolleybus
{
    public class BusComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is Trolleybus && y is Trolleybus)
            {
                return ComparerTrollybus((Trolleybus)x, (Trolleybus)y);
            }
            if (x is Trolleybus && y is Bus)
            {
                return -1;
            }
            if (x is Bus && y is Trolleybus)
            {
                return 1;
            }
            if (x is Bus && y is Bus)
            {
                return ComparerBus((Bus)x, (Bus)y);
            }
            return 0;
        }

        private int ComparerBus(Bus x, Bus y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }

        private int ComparerTrollybus(Trolleybus x, Trolleybus y)
        {
            var res = ComparerBus(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.Headlights != y.Headlights)
            {
                return x.Headlights.CompareTo(y.Headlights);
            }
            if (x.SideLine != y.SideLine)
            {
                return x.SideLine.CompareTo(y.SideLine);
            }
            if (x.Barbell != y.Barbell)
            {
                return x.Barbell.CompareTo(y.Barbell);
            }
            return 0;
        }
    }
}
