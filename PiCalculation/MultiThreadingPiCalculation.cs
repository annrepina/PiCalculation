using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculationTask
{
    /// <summary>
    /// Класс, который отвечает за расчет числа Пи многопоточно
    /// </summary>
    public class MultiThreadingPiCalculation
    {
        /// <summary>
        /// Количество потоков
        /// </summary>
        private static int NumberOfThreads;

        /// <summary>
        /// Свойство - объект класса, который отвечает за расчет числа Пи
        /// </summary>
        public PiCalculation PiCalculation { get; set; }    

        /// <summary>
        /// Массив потоков
        /// </summary>
        private Thread[] _threads;

        /// <summary>
        /// Максимальное количество точек для расчета
        /// </summary>
        public int MaxNumberOfPoints { get; set; }

        /// <summary>
        /// Стартовые и конечные индексы для тредов, когда они будут проходить по массиву точек
        /// </summary>
        private int[] _startEndIndexes;

        /// <summary>
        /// Кол-ва точек в круге, которые посчитали каждый поток
        /// </summary>
        private int[] _numbersOfPointsInCircle;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="piCalculation">Объект класса, который отвечает за расчет числа Пи</param>
        public MultiThreadingPiCalculation(PiCalculation piCalculation)
        {
            if (piCalculation != null)
            {
                PiCalculation = piCalculation;

                MaxNumberOfPoints = PiCalculation.MaxNumberOfPoints;
                NumberOfThreads = 6;

                _threads = new Thread[NumberOfThreads];
                _startEndIndexes = new int[NumberOfThreads + 1];
                _numbersOfPointsInCircle = new int[NumberOfThreads];
            }
        }

        /// <summary>
        /// Заполнить  стартовые и конечные индексы
        /// </summary>
        public void FillStartEndIndexes()
        {
            // кол-во точек, отведенное каждому потоку
            int numberOfPointsForOneThread = MaxNumberOfPoints / NumberOfThreads;

            // слагаемое
            int adding = numberOfPointsForOneThread;

            int max = NumberOfThreads + 1;

            // начинаем с 1 т.к. первый элемент уже равен единице
            for (int i = 1; i < max; i++)
            {
                _startEndIndexes[i] = adding;

                adding += numberOfPointsForOneThread;
            }
        }

        /// <summary>
        /// Расчитать при использовании многопоточности точки, которые попадают в окружность 
        /// </summary>
        /// <returns></returns>
        public int CalculatePointsInCircleMultiThreaded()
        {
            for (int i = 0; i < NumberOfThreads; i++)
            {
                int indexForAvoidingClosure = i;
                Thread thread = new Thread(() => { PiCalculation.CalculatePointsInCircle(ref _numbersOfPointsInCircle[indexForAvoidingClosure], _startEndIndexes[indexForAvoidingClosure], _startEndIndexes[indexForAvoidingClosure + 1]); });

                _threads[i] = thread;
                _threads[i].Start();
            }

            for (int i = 0; i < NumberOfThreads; i++)
            {
                _threads[i].Join();
            }

            int total = _numbersOfPointsInCircle.Sum();

            return total;
        }

        /// <summary>
        /// Запустить рассчет точек в круге
        /// </summary>
        /// <returns></returns>
        public int LaunchPointsInCircleCalculation()
        {
            FillStartEndIndexes();

            int numberOfPointsInCircle = CalculatePointsInCircleMultiThreaded();

            return numberOfPointsInCircle;
        }
    }
}