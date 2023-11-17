using System;

namespace YourNamespace
{
    public class ProgressBarEventArgs : EventArgs
    {
        public int Progress { get; }

        public ProgressBarEventArgs(int progress)
        {
            Progress = progress;
        }
    }

    public class ProgressBar
    {
        public event EventHandler<ProgressBarEventArgs> ProgressUpdated;

        public void Tick(int progress)
        {
            OnProgressUpdated(progress);
        }

        protected virtual void OnProgressUpdated(int progress)
        {
            ProgressUpdated?.Invoke(this, new ProgressBarEventArgs(progress));
        }
    }

    public class OtherClass
    {
        public event EventHandler<ProgressBarEventArgs> ProgressUpdated;

        public void DoWork()
        {
            ProgressBar progressBar = new ProgressBar();

            // Подписываемся на событие ProgressUpdated объекта progressBar
            progressBar.ProgressUpdated += ProgressBar_ProgressUpdated;

            // Выполняем работу и обновляем прогресс в progressBar
            for (int i = 0; i <= 100; i++)
            {
                // Вызываем метод Tick для обновления прогресса в progressBar
                progressBar.Tick(i);
            }

            // Отписываемся от события после завершения работы
            progressBar.ProgressUpdated -= ProgressBar_ProgressUpdated;
        }

        private void ProgressBar_ProgressUpdated(object sender, ProgressBarEventArgs e)
        {
            // Обработчик события ProgressUpdated
            // Здесь можно обновить ProgressBar на основе прогресса e.Progress
            Console.WriteLine($"Progress: {e.Progress}%");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            OtherClass otherClass = new OtherClass();
            otherClass.DoWork();
        }
    }
}