using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculationTask
{
    /// <summary>
    /// Класс, который отвечает за расчет числа Пи
    /// </summary>
    public class MultiThreadingPiCalculation
    {
        public PiCalculation PiCalculation { get; set; }    

        private static int NumberOfThreads;

        private Thread[] _threads;

        public int MaxNumberOfPoints { get; set; }

        /// <summary>
        /// Стартовые и конечные индексы для тредов, когда они будут проходить по массиву точек
        /// </summary>
        private int[] _startEndIndexes;

        /// <summary>
        /// Кол-ва точек в круге, которые посчитали каждый поток
        /// </summary>
        private int[] _numbersOfPointsInCircle;

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

        public int LaunchPointsInCircleCalculation()
        {
            FillStartEndIndexes();

            int numberOfPointsInCircle = CalculatePointsInCircleMultiThreaded();

            return numberOfPointsInCircle;
        }
    }
}