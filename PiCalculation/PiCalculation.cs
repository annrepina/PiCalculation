using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculationTask
{
    /// <summary>
    /// Класс, который отвечает за рассчет числа Пи
    /// </summary>
    public class PiCalculation
    {
        /// <summary>
        /// Максимальный радиус круга
        /// </summary>
        private static int MaxCircleRadius;

        /// <summary>
        /// Часть круга для расчета числа Пи
        /// </summary>
        private const int PartOfCircleForCalculation = 4;

        /// <summary>
        /// Массив точек
        /// </summary>
        private DoublePoint[] _points;

        /// <summary>
        /// Максимальное количество точек для расчета
        /// </summary>
        public int MaxNumberOfPoints { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="maxNumberOfPoints">Максимальное количество точек</param>
        public PiCalculation(int maxNumberOfPoints)
        {
            MaxCircleRadius = 100000;
            MaxNumberOfPoints = maxNumberOfPoints;
            _points = new DoublePoint[MaxNumberOfPoints];
        }

        /// <summary>
        /// Создать точки рандомно
        /// </summary>
        public void CreatePointsRandomly()
        {
            Random random = new Random();

            for (int i = 0; i < MaxNumberOfPoints; i++)
            {
                double x = random.NextDouble() * MaxCircleRadius;
                double y = random.NextDouble() * MaxCircleRadius;

                _points[i] = new DoublePoint { X = x, Y = y };
            }
        }

        /// <summary>
        /// Расчитать принадлежит ли точка кругу
        /// </summary>
        /// <param name="numberOfPointsInCircle">Кол-во точек, принадлежащих кругу</param>
        /// <param name="min">Стартовый индекс</param>
        /// <param name="max">Максимальный индекс</param>
        public void CalculatePointsInCircle(ref int numberOfPointsInCircle, int min, int max)
        {
            numberOfPointsInCircle = 0;

            for (int i = min; i < max; ++i)
            {
                if (Math.Pow(_points[i].X, 2) + Math.Pow(_points[i].Y, 2) <= Math.Pow(MaxCircleRadius, 2))
                {
                    ++numberOfPointsInCircle;
                }
            }
        }

        /// <summary>
        /// Расчитать число Пи
        /// </summary>
        /// <param name="numberOfPointsInCircle">Количествто точек в кругу</param>
        /// <returns></returns>
        public double CalculatePiNumber(int numberOfPointsInCircle)
        {
            double pi = (double)numberOfPointsInCircle / MaxNumberOfPoints * PartOfCircleForCalculation;

            return pi;
        }     
    }
}