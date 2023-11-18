using ShellProgressBar;

namespace MyLib
{
    public class IntegralHandler
    {
        public delegate void IteratoinDelegate();

        public event IteratoinDelegate IterationDone;
        public event EventHandler<double> CalcDone;

        static Semaphore sem;
        int runningThreads = 1;
        public void OnIterationChange() => IterationDone?.Invoke();

        double Top;
        double Bottom;
        double Step;
        public string Name;
        /*double var1 = 1e7;
        double var2 = 0;*/

        public IntegralHandler(string name = "noname", double bottom = 0, double top = 1, double step = 0.0000001)
        {
            Top = top;
            Bottom = bottom;
            Step = step;
            Name = name;
        }

        public void CalculateIntegral()
        {
            double answer = 0;
            while (Top > Bottom)
            {
                answer += Math.Sin(Bottom);
                Bottom += Step;
                /*for (int i = 0; i < 100000; i++)
                 var2 = var1 + step;*/
                OnIterationChange();
            }
            answer *= Step;
            CalcDone?.Invoke(this, answer);
        }
    }
}