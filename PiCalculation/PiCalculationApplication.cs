using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculationTask
{
    /// <summary>
    /// Приложение отвечающее за расчет числа Пи
    /// </summary>
    public class PiCalculationApplication
    {
        /// <summary>
        /// Объект класса отвечающего за расчет числа Пи в многопоточности
        /// </summary>
        private MultiThreadingPiCalculation _multiThreadingPiCalculation;

        /// <summary>
        /// Объект класса отвечающего за расчет числа Пи
        /// </summary>
        private PiCalculation _piCalculation;

        /// <summary>
        /// Секундомер
        /// </summary>
        private Stopwatch _stopwatch;

        /// <summary>
        /// Максимальное количество точек
        /// </summary>
        private int MaxNumberOfPoints { get; set; }

        /// <summary>
        /// Конструктор по умочанию
        /// </summary>
        public PiCalculationApplication()
        {
            _multiThreadingPiCalculation = null;
            _piCalculation = null;
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Запустить приложение
        /// </summary>
        public void Launch()
        {
            PrintName();

            MaxNumberOfPoints = GetNumberOfPoints();

            _piCalculation = new PiCalculation(MaxNumberOfPoints);

            _multiThreadingPiCalculation = new MultiThreadingPiCalculation(_piCalculation);

            _piCalculation.CreatePointsRandomly();

            PrintMultiThreadedResults();
            PrintSingleThreadedResults();
        }

        /// <summary>
        /// Получить от пользователя число точек для расчета
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Напечатать имя приложения
        /// </summary>
        private void PrintName()
        {
            Console.SetCursorPosition(Console.WindowWidth/2, 0);
            Console.WriteLine("Расчет числа Пи");
        }

        /// <summary>
        /// Напечатать результаты расчетов полученных через многопоточность
        /// </summary>
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

        /// <summary>
        /// Напечатать результаты расчетов полученных через однопоточность
        /// </summary>
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