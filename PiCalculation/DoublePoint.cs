using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculationTask
{
    /// <summary>
    /// Класс, в котором Point представлена значениями double
    /// </summary>
    public class DoublePoint
    {
        public double X { get; set; }

        public double Y { get; set; }

        public DoublePoint()
        {
            X = 0;
            Y = 0;
        }

        public DoublePoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
