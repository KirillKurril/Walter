using System.Data;
using System.Diagnostics;
using System.Threading;

namespace MyLibrary
{
    public class IntegralCalculator
    {
        public delegate void ResultDelegate(double result, double time);

        public event ResultDelegate CalculationCompleted;
        public event EventHandler<double> ProgressChanged;

        private int bottom = 0;
        private int top = 1;
        private double step = 0.00002;


        private static Semaphore sem;
        private int runningThreads = 1;
        private int allowedThreads = 1;
        public IntegralCalculator() 
        { }

        public IntegralCalculator(int allowedThreads, int maximumCount)
        {
            sem = new(allowedThreads, maximumCount);
            runningThreads = maximumCount;
        }

       

        public void CalculateIntegral()
        {
            if (runningThreads > allowedThreads)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} is pending launch");
                sem.WaitOne();
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} started");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            double progress = bottom;
            double result = 0;

            while (progress < top)
            {
                result += Math.Sin(progress) * step;
                progress += step;

                double percent = (progress - bottom) / (top - bottom) * 100;

                OnProgressChanged(percent);

            }

            stopwatch.Stop();
            double executionTime = stopwatch.Elapsed.TotalSeconds;

            if (runningThreads > allowedThreads)
            {
                OnCalculationCompleted(result, executionTime);
                sem.Release();
            }
            else 
                OnCalculationCompleted(result, executionTime);
        }
        protected virtual void OnCalculationCompleted(double result, double executionTime)
            => CalculationCompleted?.Invoke(result, executionTime);

        protected virtual void OnProgressChanged(double percent)
            => ProgressChanged?.Invoke(this, percent);
    }
}