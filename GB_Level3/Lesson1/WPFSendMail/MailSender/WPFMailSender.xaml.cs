﻿using System;
using System.Windows;
using MailSender.Lib;

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
                MailSenderService mailSenderService
                    = new MailSenderService(UserNameEditor.Text, PasswordEditor.SecurePassword, MessageEditor.Text, SubjectEditor.Text);

                SentState sentState = mailSenderService.SendMail();
                ShowState(sentState);
            }
        }

        private static void ShowState(SentState sentState)
        {
            WPFInformationMessage w = new WPFInformationMessage(sentState.IsOk ? "Успех!" : "Ошибка!", sentState.Message);
            w.ShowDialog();
        }

        /// <summary>
        /// Заглушка для проверки полей на заполнение
        /// </summary>
        /// <returns></returns>
        private bool IsAllFieldsFilled()
        {
            return true;
        }
    }
}
