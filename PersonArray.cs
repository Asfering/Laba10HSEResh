using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    class PersonArray
    {
        public Person[] arr;
        public PersonArray(int size)
        {
            arr = new Person[size];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Имя: ");
                string firstName = Console.ReadLine();
                Console.Write("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.Write("Возраст: ");
                int age = InputNumber("", 0, 110);
                Console.WriteLine("Выберите должность (1-2): 1 - Работник,  2 - Администратор");
                int choose = InputNumber("", 1, 2);
                if (choose == 1)
                {
                    Console.WriteLine("Инженер? 1 - Да, 2 - Нет");
                    int choiceWL = InputNumber("", 1, 2);
                    Console.WriteLine("Наименование цеха:");
                    string worr = Console.ReadLine();
                    if (choiceWL == 2)
                    {
                        Worker w = new Worker(firstName, lastName, age, worr);
                        arr[i] = w;
                    }

                    if (choiceWL == 1)
                    {
                        Console.WriteLine("Наименование места работы:");
                        string eng = Console.ReadLine();
                        Engineer e = new Engineer(firstName, lastName, age, worr, eng);
                        arr[i] = e;
                    }
                }
                if (choose == 2)
                {
                    Console.WriteLine("Наименование места администрирования:");
                    string adm = Console.ReadLine();
                    Administer a = new Administer(firstName, lastName, age, adm);
                    arr[i] = a;
                }
                Console.WriteLine();
            }
        }





        //____________________________________________________________________________________________________

        #region service

        public static int InputNumber(string text, int left, int right)   //Текст + границы
        {
            int number = 0;
            var ok = false;
            Console.Write(text);
            do
            {
                try
                {
                    number = Int32.Parse(Console.ReadLine());   //Ввод номера
                    if (number <= right && number >= left)   //проверка номера
                        ok = true;
                    else
                    {
                        Console.WriteLine("Ошибка! Введено число за пределами границ!");   //ошибка на границы
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Неверно введено число!");   //ошибка на формат
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод!");   //иная ошибка
                }
            } while (!ok);

            return number;
        }
        #endregion

    }
}
