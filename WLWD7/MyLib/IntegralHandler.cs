using ShellProgressBar;

namespace MyLib
{
    public class IntegralHandler
    {
        public delegate void IteratoinDelegate();
        public delegate double CalcDelegate();

        public event IteratoinDelegate IterationDone;
        public event CalcDelegate CalcDone();
        public void OnIterationChange() => IterationDone?.Invoke();
        
        public void CalculateIntegral()
        {
            double answer = 0;
            double top = 1;
            double bottom = 0;
            double step = 0.00000001;
            double var1 = 1e7;
            double var2 = 0;


           
                while (top > bottom)
                {
                    answer += Math.Sin(bottom);
                    bottom += step;
                    /*for (int i = 0; i < 100000; i++)
                        var2 = var1 + step;*/
                    OnIterationChange();
                }
            
            CalcDone?.Invoke();
        }
    }
}