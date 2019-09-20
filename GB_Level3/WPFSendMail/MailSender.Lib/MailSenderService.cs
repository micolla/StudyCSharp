using System;
using System.Security;
using System.Net;
using System.Net.Mail;

namespace MailSender.Lib
{   
    public class MailSenderService
    {
        string host;
        int port;
        string user_name;
        SecureString password;
        string message;
        string subject;
        public MailSenderService(string userName,SecureString password, string message,string subject)
        {
            this.host = SenderConfig.host;
            this.port= SenderConfig.port;
            this.user_name = userName;
            this.password = password;
            this.message = message;
            this.subject = subject;
        }
        public SentState SendMail()
        {
            try
            {
                using (var client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(user_name, password);

                    using (var message = new MailMessage() { Body = this.message, Subject = this.subject })
                    {
                        message.From = new MailAddress(this.user_name + "@yandex.ru");
                        message.To.Add(new MailAddress("micola8903@mail.ru"));

                        client.Send(message);
                        return new SentState("Почта успешно отправлена", true);
                    }
                }
            }
            catch (Exception e)
            {
                return new SentState(e.Message, false);
            }
        }
    }
}
