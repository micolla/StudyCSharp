using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson5
{
    static class CheckLogin
    {
        /// <summary>
        /// Создать программу, которая будет проверять корректность ввода логина. 
        /// Корректным логином будет строка от 2 до 10 символов, 
        /// содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой
        /// Проверка без регулярных
        /// </summary>
        /// <param name="login">Логин на проверку</param>
        /// <returns></returns>
        public static bool IsValidLogin(string login)
        {
            bool result = true;
            if ((login.Length >= 2) && (login.Length <= 10) && (Char.IsDigit(login[0]) == false))
            {
                for (int i = 0; i < login.Length; i++)
                {
                    if (!char.IsLetterOrDigit(login, i))
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
                result = false;
            return result;
        }
        /// <summary>
        /// Создать программу, которая будет проверять корректность ввода логина. 
        /// Корректным логином будет строка от 2 до 10 символов, 
        /// содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой
        /// Проверка c регулярками
        /// </summary>
        /// <param name="login">Логин на проверку</param>
        /// <returns></returns>
        public static bool IsValidLoginRegex(string login)
        {
            bool result = true;
            Regex reg = new Regex(@"^\D(\d|\D){1,9}$");
            result = reg.IsMatch(login,0);
            return result;
        }
    }

}
