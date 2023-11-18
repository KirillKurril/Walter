using MyLibrary;

namespace WLWD7
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  IntegralCalculator integralCalculator1 = new();
            IntegralCalculator integralCalculator2 = new();

            ProgressBar progressBar1 = new ProgressBar();
            ProgressBar progressBar2 = new ProgressBar();

            integralCalculator1.ProgressChanged += progressBar1.Up;
            integralCalculator2.ProgressChanged += progressBar2.Up;

            Thread thread1 = new (integralCalculator1.CalculateIntegral);
            Thread thread2 = new(integralCalculator2.CalculateIntegral);

            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Lowest;

            thread1.Name = "1";
            thread2.Name = "2";

            integralCalculator1.CalculationCompleted += progressBar1.Finish;
            integralCalculator2.CalculationCompleted += progressBar2.Finish;

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();*/

            Console.WriteLine("\n\nWhen a function is executed in several threads, only one thread is executed\n");

            IntegralCalculator integralCalculator3 = new (1, 5);
            Thread[] threads = new Thread[5];

            ProgressBar progressBar = new ProgressBar();
            integralCalculator3.CalculationCompleted += progressBar.Finish;

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(integralCalculator3.CalculateIntegral);
                threads[i].Name = $"{i}";
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            Console.WriteLine("\n\nWhen a function is executed in several threads, given amount is executed\n");

            IntegralCalculator integralCalculator4 = new(3, 5);
            integralCalculator4.CalculationCompleted += progressBar.Finish;
            Thread[] threads2 = new Thread[5];

            for (int i = 0; i < threads2.Length; i++)
            {
                threads2[i] = new Thread(integralCalculator4.CalculateIntegral);
                threads2[i].Name = $"Поток №{i + 1}";
                threads2[i].Start();
            }

            for (int i = 0; i < threads2.Length; i++)
                threads2[i].Join();

        }
    }
}