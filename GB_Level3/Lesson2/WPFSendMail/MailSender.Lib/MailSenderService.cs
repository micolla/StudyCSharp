using System;
using System.Security;
using System.Net;
using System.Net.Mail;
using MailSender.Lib.Data.Linq2SQL;
using System.Linq;

namespace MailSender.Lib
{   
    public class MailSenderService
    {
        string host;
        int port;
        string user_name;
        string password;
        string message;
        string subject;
        string user_email;
        IQueryable<Recipient> recipients;
        public MailSenderService(Sender sender, string message,string subject, IQueryable<Recipient> recipients) 
            :this(sender,message,subject)
        {
            this.recipients = recipients;
        }
        public MailSenderService(Sender sender, string message, string subject) : this(sender)
        {
            this.message = message;
            this.subject = subject;
        }

        public MailSenderService(Sender sender)
        {
            this.host = sender.smtp_address;
            this.port = sender.smtp_port;
            this.user_email = sender.email;
            this.user_name = sender.login;
            this.password = sender.password;
            this.message = "не указан текст";
            this.subject = "не указана тема";
        }
        /// <summary>
        /// Отправка почты внешнему списку адресатов
        /// </summary>
        /// <param name="recipients">список адресатов</param>
        /// <returns></returns>
        public SentState SendMails(IQueryable<Recipient> recipients)
        {
            SentState tmpState = new SentState("Не указаны получатели", false);
            if (recipients.Count() > 0)
            {
                foreach (var item in recipients)
                {
                    tmpState = SendMail(item.email, item.name);
                    if (!tmpState.IsOk)
                        throw new InvalidOperationException(tmpState.Message);
                }
            }
            return tmpState;
        }
        /// <summary>
        /// Отправка писем внутреннему списку адресатов
        /// </summary>
        /// <returns></returns>
        public SentState SendMails()
        {
            return SendMails(this.recipients);
        }

        public SentState SendMail(string recipientEmail,string recipientName)
        {
            try
            {
                using (var client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(user_name, password);
                    //client.Credentials = new NetworkCredential(user_name, PasswordDecoder.getPassword(password));
                    using (var message = new MailMessage() { Body = this.message, Subject = this.subject })
                    {
                        message.From = new MailAddress(this.user_email);
                        message.To.Add(new MailAddress(recipientEmail,recipientName));

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
