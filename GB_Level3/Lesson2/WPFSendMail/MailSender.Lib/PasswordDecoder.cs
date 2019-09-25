using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib
{
    /// <summary>
    ///На вход подаем зашифрованный пароль, на выходе получаем пароль для email
    /// </summary>
    public static class PasswordDecoder
    {
        public static string getPassword(string p_sPassw)
        {
            string password = String.Empty;
            foreach (char a in p_sPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }

            return password;
        }
        /// <summary>
        /// На вход подаем пароль, на выходе получаем зашифрованный пароль
        /// </summary>
        /// <param name="p_sPassword"></param>
        /// <returns></returns>
        public static string getCodPassword(string p_sPassword)
        {
            string sCode = "";
            foreach (char a in p_sPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }
    }
}
