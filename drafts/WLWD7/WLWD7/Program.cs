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
            IntegralHandler integralHandler1 = new IntegralHandler("int 1");
            IntegralHandler integralHandler2 = new IntegralHandler("int 2");

            LoadBar loadBar1 = new LoadBar("Thread 1");
            LoadBar loadBar2 = new LoadBar("Thread 2");

            integralHandler1.IterationDone += loadBar1.Up;
            integralHandler2.IterationDone += loadBar2.Up;

            integralHandler1.CalcDone += (object sender, double answer)
                => { Console.WriteLine($"Quadrature of {integralHandler1.Name} is {answer}"); };
            integralHandler2.CalcDone += (object sender, double answer)
                => { Console.WriteLine($"Quadrature of {integralHandler2.Name} is {answer}"); };

            Thread thread1 = new Thread(integralHandler1.CalculateIntegral);
            Thread thread2 = new Thread(integralHandler2.CalculateIntegral);

            thread1.Priority = ThreadPriority.Lowest;
            thread2.Priority = ThreadPriority.Highest;

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();



        }
    }
}