using System.Diagnostics;
using System.Threading;

namespace MyLibrary
{
    public class IntegralCalculator
    {
        private int a = 0;
        private int b = 1;
        private double step = 0.00002;


        private static Semaphore sem;
        private int runningThreads = 1;
        public IntegralCalculator() 
        { }

        public IntegralCalculator(int initialCount, int maximumCount)
        {
            sem = new(initialCount, maximumCount);
            runningThreads = maximumCount;
        }

        public event EventHandler<double> CalculationCompleted;
        public event EventHandler<double> ProgressChanged;

        public void CalculateIntegral()
        {
            if (runningThreads > 1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: Ожидание запуска");

                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name}: Запустился");
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double x = a;
            double result = 0;
            double progress = 0;

            while (x < b)
            {
                for (int i = 0; i < 100000; i++)
                {
                    int buff = 2*2;
                }
                double f = Math.Sin(x);
                result += f * step;
                x += step;

                progress = (x - a) / (b - a) * 100;

                OnProgressChanged(progress);

            }

            stopwatch.Stop();
            double executionTime = stopwatch.Elapsed.TotalSeconds;
            if (runningThreads > 1)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.Name} Время выполнения: " + executionTime + " мс");
                OnCalculationCompleted(result, executionTime);
                sem.Release();
            }
            else 
            {
                Console.WriteLine($"Время выполнения: " + executionTime + " мс");
                OnCalculationCompleted(result, executionTime);
            }
        }
        protected virtual void OnCalculationCompleted(double result, double executionTime)
        {
            CalculationCompleted?.Invoke(this, result);
        }

        protected virtual void OnProgressChanged(double progress)
        {
            ProgressChanged?.Invoke(this, progress);
        }
    }
}