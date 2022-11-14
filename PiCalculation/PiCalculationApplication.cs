using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculationTask
{
    public class PiCalculationApplication
    {
        private MultiThreadingPiCalculation _multiThreadingPiCalculation;

        private PiCalculation _piCalculation;

        private Stopwatch _stopwatch;

        private int MaxNumberOfPoints { get; set; }

        public PiCalculationApplication()
        {
            _multiThreadingPiCalculation = null;
            _piCalculation = null;
            _stopwatch = new Stopwatch();
        }

        public void Launch()
        {
            PrintApplicationName();

            MaxNumberOfPoints = GetNumberOfPoints();

            _piCalculation = new PiCalculation(MaxNumberOfPoints);

            _multiThreadingPiCalculation = new MultiThreadingPiCalculation(_piCalculation);

            _piCalculation.GetPointsRandomly();

            PrintMultiThreadedResults();
            PrintSingleThreadedResults();
        }

        public int GetNumberOfPoints()
        {
            Console.Write("Введите общее количество точек для рассчета числа Пи: ");

            bool isInt32 = Int32.TryParse(Console.ReadLine(), out int result);

            while(!isInt32)
            {
                Console.Write("Вы ввели недопустимое значение, попробуйте снова: ");

                isInt32 = Int32.TryParse(Console.ReadLine(), out result);
            }

            return result;
        }

        private void PrintApplicationName()
        {
            Console.SetCursorPosition(Console.WindowWidth/2, 0);
            Console.WriteLine("Расчет числа Пи");
        }

        private void PrintMultiThreadedResults()
        {
            Console.WriteLine("Многопоточное вычисление числа Пи");

            _stopwatch.Start();

            int numberOfPointsByMultiThreading = _multiThreadingPiCalculation.LaunchPointsInCircleCalculation();

            _stopwatch.Stop();

            double piMultiThreading = _piCalculation.CalculatePiNumber(numberOfPointsByMultiThreading);

            Console.WriteLine($"Согласно расчетам число Пи равно: {piMultiThreading}");
            Console.WriteLine($"Время потраченное на вычисления равно {_stopwatch.ElapsedMilliseconds} милисекунд");

            _stopwatch.Reset();
        }

        private void PrintSingleThreadedResults()
        {
            Console.WriteLine("Однопоточное вычисление числа Пи");

            _stopwatch.Start();

            int numberOfPointsInCircle = 0;

            _piCalculation.CalculatePointsInCircle(ref numberOfPointsInCircle, 0, _piCalculation.MaxNumberOfPoints);

            _stopwatch.Stop();

            double piSingleThreading = _piCalculation.CalculatePiNumber(numberOfPointsInCircle);

            Console.WriteLine($"Согласно расчетам число Пи равно: {piSingleThreading}");
            Console.WriteLine($"Время потраченное на вычисления равно {_stopwatch.ElapsedMilliseconds} милисекунд");

            _stopwatch.Reset();
        }

    }
}
