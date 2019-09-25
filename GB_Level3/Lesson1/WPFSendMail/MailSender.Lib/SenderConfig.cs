using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib
{
    static class SenderConfig
    {
        public readonly static string host;
        public readonly static int port;
        static SenderConfig()
        {
            host = ConfigurationManager.AppSettings["smtpName"];
            if (!int.TryParse(ConfigurationManager.AppSettings["port"], out port))
            {
                throw new InvalidCastException("Не верная настрока поля порт - не число");
            }
        }
    }
}
