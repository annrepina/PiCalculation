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
        /// <summary>
        /// Координата точки Х
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Координата точки Y
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DoublePoint()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата Y</param>
        public DoublePoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}