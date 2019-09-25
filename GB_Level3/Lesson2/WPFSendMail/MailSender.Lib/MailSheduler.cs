using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MailSender.Lib
{
    public class MailSheduler
    {
        List<Task> Tasks;
        DispatcherTimer timer;

        public event Action<SentState> MailIsSend;

        public MailSheduler(List<Task> tasks)
        {
            Tasks = tasks;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public MailSheduler()
        {
            Tasks = new List<Task>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        /// <summary>
        /// Работа по расписанию, обработка задач
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            var list = from t in Tasks
                       where t.IsActual
                       where t.IsTime()
                       select t;
            SentState resultState;
            foreach (var item in list)
            {
                resultState = item.DoTask();
                MailIsSend?.Invoke(resultState);
            }
        }
        /// <summary>
        /// Добавить задачу в рассмотрение
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

    }
}
