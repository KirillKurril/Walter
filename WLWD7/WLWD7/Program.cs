using MyLib;
using ShellProgressBar;
using System;

namespace WLWD7
{
    internal class Program
    {
        private static int threadsNum = 5;
        private delegate void ThreadStart();

        static void Main(string[] args)
        {
            IntegralHandler integralHandler = new IntegralHandler();
            ThreadStart threadStart = new ThreadStart(integralHandler.CalculateIntegral);
            Thread[] threads = new Thread[threadsNum];

            IntegralHandler integralHandler = new IntegralHandler();
            for (int i = 0; i < threadsNum; ++i)
            {
                threads[i] = new Thread(threadStart);
            }

            int totalTicks = Convert.ToInt32((top - bottom) / step);
            var options = new ProgressBarOptions
            {
                ProgressBarOnBottom = true
            };
            using (var pbar = new ProgressBar(totalTicks, "Calculating integral...", options))
            {


            }
    }
}