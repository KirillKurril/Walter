using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShellProgressBar;

namespace MyLib
{
    public class LoadBar
    {
        double Top;
        double Bottom;
        double Step;
        int TotalTicks;
        ProgressBar? PBar;

        public LoadBar(string message = "Processing...", double bottom = 0, double top = 1, double step = 0.0000001)
        {
            Bottom = bottom;
            Top = top;
            Step = step;
            TotalTicks = Convert.ToInt32((top - bottom) / step);
            var options = new ProgressBarOptions { ProgressBarOnBottom = true };
            PBar = new ProgressBar(TotalTicks, message, options);
        }
          
        public void Up()
        {
            PBar.Tick();
        }




    }
}

         