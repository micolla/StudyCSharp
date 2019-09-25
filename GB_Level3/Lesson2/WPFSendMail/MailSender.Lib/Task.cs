using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib
{
    public class Task
    {
        DateTime SheduledDate;
        MailSenderService MailSenderService;
        /// <summary>
        /// Признак, что задача еще актуальна
        /// </summary>
        public bool IsActual { get; private set; }
        public Task(DateTime sheduledDate, MailSenderService mailSenderService)
        {
            SheduledDate = sheduledDate;
            MailSenderService = mailSenderService;
            IsActual = true;
        }
        /// <summary>
        /// Проверка, что пришло время отправлять
        /// </summary>
        /// <returns></returns>
        public bool IsTime()
        {
            DateTime now = DateTime.Now;
            bool result = false;
            if (IsActual)
            {
                if (SheduledDate.ToShortTimeString() == now.ToShortTimeString())
                    result = true;
                else if (now > SheduledDate)
                {
                    IsActual = false;
                }
            }
            return result;
        }
        /// <summary>
        /// Выполнить задачу
        /// </summary>
        /// <returns></returns>
        public SentState DoTask()
        {
            SentState resultState = MailSenderService.SendMails();
            IsActual = false;
            return resultState;
        }
    }
}
