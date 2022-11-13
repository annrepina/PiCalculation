using System.Diagnostics;
using System.Drawing;

namespace PiCalculation
{
    public struct MyPoint
    {
        public double X;

        public double Y;
    }

    public class Program
    {
        //static int minRadius = 1;

        //static int maxRadius = System.Int32.MaxValue;
        static int maxRadius = 100000;

        static int maxNumberOfPoints = 600000000;

        static Random random = new Random(1);

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            var listOfPoints = CalculatePoints();

            stopwatch.Start();






            //int[] arrOfLength = new int[6];

            //// частное
            //int quotient = maxNumberOfPoints / 5;
            //int adding = quotient;

            //for (int i = 1; i < 6; i++)
            //{
            //    arrOfLength[i] = adding;

            //    adding += quotient;
            //}


            //int[] arr = new int[5];

            //Thread[] threads = new Thread[20];

            //for (int i = 0; i <5; i++)
            //{
            //    int j = i;
            //    Thread myThread = new Thread(() => { CalculatePointsInCircle(listOfPoints, ref arr[j], arrOfLength[j], arrOfLength[j + 1]); });
            //    myThread.Name = $"Поток {i}";   // устанавливаем имя для каждого потока

            //    threads[i] = myThread;

            //    myThread.Start();
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    threads[i].Join();
            //}

            //int total = arr.Sum();




            //double pii = (double)total / maxNumberOfPoints * 4;




            var points = CalculatePointsInCircle1(listOfPoints);

            double pii = (double)points / maxNumberOfPoints * 4;






            Console.WriteLine($"Пииии {pii}");


            stopwatch.Stop();



            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        //public static void Calculate(object? minRad)
        //{
        //    if (minRad is Int32 min)
        //    {
        //        List<double> results = new List<double>();

        //        double pi = 0d;

        //        for (int j = min; j < maxRadius; j++)
        //        {
        //            int numberOfPoints = 0;

        //            for (int i = 0; i < maxNumberOfPoints; i++)
        //            {
        //                double x = random.NextDouble() * j;
        //                double y = random.NextDouble() * j;

        //                if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(j, 2))
        //                {
        //                    ++numberOfPoints;
        //                }
        //            }

        //            pi = numberOfPoints / maxNumberOfPoints * 4;

        //            results.Add(pi);
        //        }

        //        Console.WriteLine(results.Average());
        //    }
        //}

        //public static void Calculate(object? minRad)
        //{
        //    if (minRad is Result result)
        //    {
        //        double pi = 0d;

        //        //for (int j = result._minRadius; j < maxRadius; j++)
        //        //{
        //            int numberOfPoints = 0;

        //            for (int i = 0; i < maxNumberOfPoints; i++)
        //            {
        //                double x = random.NextDouble() * j;
        //                double y = random.NextDouble() * j;

        //                if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(maxRadius, 2))
        //                {
        //                    ++numberOfPoints;
        //                }
        //            }

        //            pi = numberOfPoints / maxNumberOfPoints * 4;

        //            result.Add(pi);
        //        //}
        //    }
        //}

        public static MyPoint[] CalculatePoints()
        {
            MyPoint[] points = new MyPoint[maxNumberOfPoints];

            for (int i = 0; i < maxNumberOfPoints; i++)
            {
                double x = random.NextDouble() * maxRadius;
                double y = random.NextDouble() * maxRadius;

                //Point p = new Point(x, y);

                points[i] = new MyPoint { X = x, Y = y };

                //points.Add(x);
                //points.Add(y);
            }

            //pi = numberOfPoints / maxNumberOfPoints * 4;

            //result.Add(pi);

            return points;
        }

        //public static void CalculatePointsInCircle(object? obj)
        //{
        //    if (obj is Result result)
        //    {
        //        for (int i = result.startValue; i < result.endValue; ++i)
        //        {
        //            if (Math.Pow(result.list[i], 2) + Math.Pow(result.list[++i], 2) <= Math.Pow(maxRadius, 2))
        //            {
        //                ++result.numberOfPoints;
        //            }
        //        }
        //    }
        //}

        public static void CalculatePointsInCircle(MyPoint[] list, ref int res, int min, int max)
        {
            res = 0;
            for (int i = min; i < max; ++i)
            {
                if (Math.Pow(list[i].X, 2) + Math.Pow(list[i].Y, 2) <= Math.Pow(maxRadius, 2))
                {
                    ++res;
                }
            }
        }

        public static int CalculatePointsInCircle1(MyPoint[] list)
        {
            int res = 0;

            //int max = 2 * maxNumberOfPoints;

            for (int i = 0; i < maxNumberOfPoints; ++i)
            {
                if (Math.Pow(list[i].X, 2) + Math.Pow(list[i].Y, 2) <= Math.Pow(maxRadius, 2))
                {
                    ++res;
                }
            }

            return res;
        }

        //public static double Calculate()
        //{
        //    double pi = 0d;

        //    List<double> results = new List<double>();

        //    for (int j = minRadius; j < maxRadius; j++)
        //    {
        //        int numberOfPoints = 0;

        //        for (int i = 0; i < maxNumberOfPoints; i++)
        //        {
        //            double x = random.NextDouble() * j;
        //            double y = random.NextDouble() * j;

        //            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(j, 2))
        //            {
        //                ++numberOfPoints;
        //            }
        //        }

        //        pi = (double)numberOfPoints / maxNumberOfPoints * 4;

        //        results.Add(pi);
        //    }

        //    return results.Average();
        //}

        //public static double Calculate()
        //{
        //    double pi = 0d;

        //    List<double> results = new List<double>();

        //    for (int j = minRadius; j < maxRadius; j++)
        //    {
        //        int numberOfPoints = 0;

        //        for (int i = 0; i < maxNumberOfPoints; i++)
        //        {
        //            double x = random.NextDouble() * j;
        //            double y = random.NextDouble() * j;

        //            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(j, 2))
        //            {
        //                ++numberOfPoints;
        //            }
        //        }

        //        pi = (double)numberOfPoints / maxNumberOfPoints * 4;

        //        results.Add(pi);
        //    }

        //    return results.Average();
        //}

        //public class Result
        //{
        //    //public List<double> Pis;

        //    //public void Add(double value)
        //    //{
        //    //    Pis.Add(value);
        //    //}

        //    //public int _minRadius;

        //    //public Result(int minRadius)
        //    //{
        //    //    Pis = new List<double>();

        //    //    _minRadius = minRadius;
        //    //}

        //    public int startValue;

        //    public int endValue;

        //    public int numberOfPoints;

        //    public List<double> list;

        //    public Result(int startValue, int endValue, List<double> list)
        //    {
        //        this.startValue = startValue;
        //        this.endValue = endValue;
        //        this.numberOfPoints = 0;
        //        this.list = list;
        //    }
        //}
    }
}