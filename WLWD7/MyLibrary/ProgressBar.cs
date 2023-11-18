using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ProgressBar
    {
        string Bar;
        double fullness;

        public ProgressBar()
        {
            Bar = "[>          ]";
            fullness = 0;
        }
        public void Up(object? sender, double progress)
        {
            double proc = Math.Floor(progress);
            if (proc > fullness)
            {
                Bar = Bar.Remove(11, 1);
                Bar = Bar.Insert(1, "=");
                fullness += 10;
            }
            Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {Bar} Progress: {Math.Round(progress, 2)}%");
        }

        public void Finish(double result, double executionTime)
        {
            Console.WriteLine($"\nThread {Thread.CurrentThread.Name} is finished with the result: {Math.Round(result, 6)}");
            Console.WriteLine($"Execution time: {executionTime} ms\n");
        }
    }
}
