using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static string requestToUser(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        static float getIMT(float height, float weight) {
            return weight / (height*height/10000);
        }
        static void Main(string[] args)
        {
            bool success=false;
            string firstName, lastName,agePostfix;
            int age;
            float weight,height=0;

            Console.WriteLine("Вас приветсвует программа Анкета");
            firstName = requestToUser( "Введите Ваше имя");
            lastName = requestToUser("Введите Ваше фаммилию");
            success=int.TryParse(requestToUser("Введите Ваш полный возраст"),out age );
            while(!success) {
                Console.WriteLine("Вы не верно ввели возраст, нужно ввести целое число");
                success = int.TryParse(requestToUser("Введите Ваш полный возраст"), out age);
            }
            success=float.TryParse(requestToUser("Введите Ваш вес в килограммах"), out weight);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели вес, нужно ввести целое число или дробное с запятой");
                success = float.TryParse(requestToUser("Введите Ваш вес в килограммах"), out weight);
            }
            success = float.TryParse(requestToUser("Введите Ваш рост в сантиметрах"), out height);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели рост, нужно ввести целое число или дробное с запятой");
                success = float.TryParse(requestToUser("Введите Ваш рост в сантиметрах"), out height);
            }
            if (age % 10 == 1){
                agePostfix = "год";
            }
            else if (age % 10>1 && age % 10 < 5) {
                agePostfix = "года";
            }
            else{ agePostfix = "лет"; }
            Console.WriteLine();
            Console.WriteLine("Вас зовут {0} \n" +
                        "Вам {1} {3} \n" +
                        "Вы весите {2:F2} кг\n" +
                        "При росте {4:f2}", firstName + " " + lastName, age, weight
                            , agePostfix,height);
            Console.WriteLine("Ваш ИМТ равен {0:F2}", getIMT(height, weight));
            Console.ReadLine();
        }
    }
}
