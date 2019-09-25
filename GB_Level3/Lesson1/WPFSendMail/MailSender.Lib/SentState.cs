using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib
{
    public class SentState
    {
        public string Message { get; }
        public bool IsOk { get; }
        private SentState(){}
        internal SentState(string message,bool isOk)
        {
            Message = message;
            IsOk = isOk;
        }
    }
}
