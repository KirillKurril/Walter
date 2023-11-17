using MyLibrary;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            IntegralCalculator integralCalculator1 = new();
            IntegralCalculator integralCalculator2 = new();

            Thread thread1 = new (integralCalculator1.CalculateIntegral);
            thread1.Priority = ThreadPriority.Highest;
            thread1.Name = "Integral Calculator №1";

            integralCalculator1.CalculationCompleted += (sender, result) =>
            {
                Console.WriteLine($"Поток {thread1.Name} завершен с результатом: {Math.Round(result,6)}");
            };

            string Base = "> ";

            integralCalculator1.ProgressChanged += (sender, progress) =>
            {
                if ((progress - (Base.Length - 1) * 10) % 10 >= 0)
                {
                    Base = Base.Insert(0, "=");
                } 
                    Console.WriteLine($"Поток {thread1.Name}:["+ Base + Math.Round(progress,3) + "]%");
            };

            Thread thread2 = new (integralCalculator2.CalculateIntegral);
            thread1.Priority = ThreadPriority.Lowest;
            thread1.Name = "Integral Calculator №2";

            integralCalculator2.CalculationCompleted += (sender, result) =>
            {
                Console.WriteLine($"Поток {thread2.Name} завершен с результатом: {Math.Round(result, 6)}");
            };


            integralCalculator2.ProgressChanged += (sender, progress) =>
            {
                if ((progress - (Base.Length - 1) * 10) % 10 >= 0)
                {
                    Base = Base.Insert(0, "=");
                }
                Console.WriteLine($"Поток {thread2.Name}:[" + Base + Math.Round(progress, 3) + "]%");
            };

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("\n****************************************************************");
            Thread.Sleep(3000);

            IntegralCalculator integralCalculator3 = new (1, 5);

            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(integralCalculator3.CalculateIntegral);
                threads[i].Name = $"Поток №{i + 1}";
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("\n****************************************************************");
            Thread.Sleep(3000);

            IntegralCalculator integralCalculator4 = new(3, 5);

            Thread[] threads2 = new Thread[5];

            for (int i = 0; i < threads2.Length; i++)
            {
                threads2[i] = new Thread(integralCalculator4.CalculateIntegral);
                threads2[i].Name = $"Поток №{i + 1}";
                threads2[i].Start();
            }

            for (int i = 0; i < threads2.Length; i++)
            {
                threads2[i].Join();
            }

        }
    }
}