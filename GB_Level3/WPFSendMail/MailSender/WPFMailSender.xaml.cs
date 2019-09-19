using System;
using System.Windows;
using System.Net.Mail;
using System.Net;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для WPFMailSender.xaml
    /// </summary>
    public partial class WPFMailSender : Window
    {
        public WPFMailSender()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsAllFieldsFilled())
            {
                var host = SMTPServerEditor.Text;
                int port;
                if (!int.TryParse(ServerPortEditor.Text, out port))
                    MessageBox.Show("Введите цифровое значение в поле Порт", "", MessageBoxButton.OK, MessageBoxImage.Information);

                var user_name = UserNameEditor.Text;
                var password = PasswordEditor.SecurePassword;

                var msg = MessageEditor.Text;

                using (var client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(user_name, password);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(UserNameEditor.Text+"@yandex.ru");
                        message.To.Add(new MailAddress("micola8903@mail.ru"));
                        message.Subject = SubjectEditor.Text;
                        message.Body = msg;
                        //message.Attachments.Add(new Attachment());

                        try
                        {
                            client.Send(message);
                            MessageBox.Show("Почта успешно отправлена",
                                "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message,
                                "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private bool IsAllFieldsFilled()
        {
            return true;
        }
    }
}
