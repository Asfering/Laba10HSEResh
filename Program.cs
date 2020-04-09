using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba10
{

    class Program
    {
        public static int size = 0;

        static void Main(string[] args)
        {
            //Задание 1.

            int encount = 0;
            Console.WriteLine("Лабораторная работа №10. Решетняк Роман. 3 Вариант");
            Console.WriteLine();
            Console.WriteLine("Введите размер массива (максимум 15)");
            Console.WriteLine();
            size = InputNumber("", 0, 15);
            Console.WriteLine();
            PersonArray PArr = new PersonArray(size);
            Console.WriteLine();

            //     Console.WriteLine(PersonArray.);
            Console.WriteLine();
            Console.WriteLine("Просмотр данных:");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Имя: " + PArr.arr[i].FirstName);
                Console.WriteLine("Фамилия: " + PArr.arr[i].LastName);
                Console.WriteLine("Возраст: " + PArr.arr[i].Age);
                if(PArr.arr[i] is Engineer)
                {
                    Engineer engl = PArr.arr[i] as Engineer;
                    Console.WriteLine("Наименование места работы: " + engl.NameFactory);
                }
                if (PArr.arr[i] is Administer)
                {
                    Administer adm = PArr.arr[i] as Administer;
                    Console.WriteLine("Наименование места администрирования: " + adm.WhatManage);
                }
                if (PArr.arr[i] is Worker)
                {
                    Worker Wk = PArr.arr[i] as Worker;
                    Console.WriteLine("Наименование цеха: " + Wk.NameWorkShop);
                }
                Console.WriteLine();
            }


            //Задание 2.
            //______________________________________________________________________________________________________________________________



            Console.WriteLine();
            Console.WriteLine("Запросы: \n1) Количество инженеров на работе;\n2) Имена рабочих;\n3) Количество инженеров в заданном подразделении;\n4) Продолжить.");
            Console.WriteLine();

            //Задача 9. Количество инженеров на работе.

            Console.WriteLine("Количество инженеров на работе");
            foreach (Person pEng in PArr.arr)
            {
                if (pEng is Engineer) encount = 1 + encount;
            }
            Console.WriteLine("Инженеров: " + encount);
            Console.WriteLine();

            //Задача 7. Имена рабочих.

            int da = 0;
            foreach (Person pWk in PArr.arr)
            {
                if (pWk is Worker)
                {
                    da = 1 + da;
                    
                    if(pWk is Engineer)
                        Console.WriteLine("Рабочий инженер: " + pWk.FirstName + " " + pWk.LastName);
                    else
                        Console.WriteLine("Рабочий: " + pWk.FirstName + " " + pWk.LastName);
                }
            }
            if (da == 0) Console.WriteLine("Рабочих нет");
            Console.WriteLine();

            //Задача 19. Количество инженеров в заданном подразделении.

            Console.WriteLine("Количество инженеров в заданном месте работы");
            Console.WriteLine("Введите место работы: ");
            string unit = Console.ReadLine();
            int unitCount = 0;
            Console.WriteLine();
            Engineer engIn = new Engineer("", "", 0, "", "");
            foreach (Person pEng in PArr.arr)
            {
                if (pEng is Engineer)
                {
                    engIn = pEng as Engineer;
                    if (engIn.NameFactory == unit) unitCount = 1 + unitCount;
                }
            }
            Console.WriteLine("Всего инженеров на данном месте работы: " + unitCount);
            Console.WriteLine();


            //Задача 3.
            //______________________________________________________________________________________________________________________________
            Console.WriteLine("Сортировка");
            Array.Sort(PArr.arr);
            for (int i = 0; i < PArr.arr.Length; i++)
            {
                Console.WriteLine("Имя: " + PArr.arr[i].FirstName);
                Console.WriteLine("Фамилия: " + PArr.arr[i].LastName);
                Console.WriteLine("Возраст: " + PArr.arr[i].Age);
                if (PArr.arr[i] is Administer)
                {
                    Administer adm = PArr.arr[i] as Administer;
                    Console.WriteLine("Наименование места администрирования: " + adm.WhatManage);
                }
                if (PArr.arr[i] is Worker)
                {
                    Worker Wk = PArr.arr[i] as Worker;
                    Console.WriteLine("Наименование цеха: " + Wk.NameWorkShop);
                    if (PArr.arr[i] is Engineer)
                    {
                        Engineer engl = PArr.arr[i] as Engineer;
                        Console.WriteLine("Наименование места работы: " + engl.NameFactory);
                    }
                }
                Console.WriteLine();
            }
            //Поиск в массиве
            Console.WriteLine("В каком разделе искать: 1 - Работник, 2 - Администратор");
            int findCount = InputNumber("", 1, 2);
            if (findCount == 1)
            {
                Console.WriteLine("Инженер? 1 - Да, 2 - Нет.");
                int choiceEngl = InputNumber("", 1, 2);
                
                    Console.WriteLine();
                    Console.Write("Введите имя:");
                    string findFirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string findLastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int findAge = InputNumber("", 0, 100);
                    Console.Write("Введите название цеха: ");
                    string findNameWorkShop = Console.ReadLine();
                    if (choiceEngl == 2)
                    {
                    try
                    {
                        Person p = new Worker(findFirstName, findLastName, findAge, findNameWorkShop);
                        Person finded = Array.Find(PArr.arr, Person => p == Person);
                        Console.Write($"Найдено: ");
                        p.Display();

                        Console.WriteLine("Клонирование...");
                        for (int i = 10; i > 0; i--)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine(i);
                        }

                        Person ClonP = (Worker) p.Clone();
                        Console.WriteLine("Клонирование завершено!");

                        Console.WriteLine(ClonP.FirstName + " " + ClonP.LastName + " " + ClonP.Age);

                        //interface IExecutable
                        ClonP.Execute();
                        Console.WriteLine("Клонирование...");
                        for (int i = 10; i > 0; i--)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine(i);
                        }

                        Console.WriteLine(ClonP.FirstName + " " + ClonP.LastName + " " + ClonP.Age);
                    }
                    catch
                    {
                        Console.WriteLine("Пользователя нет!");
                    }
                }

                    if (choiceEngl == 1)
                    {
                        Console.Write("Введите наименование места работы: ");
                        string findNameFactory = Console.ReadLine();
                        try
                        {
                            Person p = new Engineer(findFirstName, findLastName, findAge, findNameWorkShop, findNameFactory);
                            Person finded = Array.Find(PArr.arr, Person => p == Person);
                            Console.Write($"Найдено: ");
                            p.Display();
                            Console.WriteLine("Клонирование...");
                            for (int i = 10; i > 0; i--)
                            {
                                Thread.Sleep(500);
                                Console.WriteLine(i);
                            }

                            Person ClonP = (Engineer)p.Clone();
                            Console.WriteLine("Клонирование завершено!");

                            Console.WriteLine(ClonP.FirstName + " " + ClonP.LastName + " " + ClonP.Age);

                            //interface IExecutable
                            ClonP.Execute();
                            Console.WriteLine("Клонирование...");
                            for (int i = 10; i > 0; i--)
                            {
                                Thread.Sleep(500);
                                Console.WriteLine(i);
                            }

                            Console.WriteLine(ClonP.FirstName + " " + ClonP.LastName + " " + ClonP.Age);
                        }
                        catch
                        {
                            Console.WriteLine("Пользователя нет!");
                        }
                }
            }

            if (findCount == 2)
            {
                Console.WriteLine();
                Console.Write("Введите имя: ");
                string findFirstName = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                string findLastName = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int findAge = InputNumber("", 0, 100);
                Console.Write("Введите наименоение места администрирования: ");
                string findWhatManage = Console.ReadLine();
                try
                {
                    Person p = new Administer(findFirstName, findLastName, findAge, findWhatManage);
                    Person finded = Array.Find(PArr.arr, Person => p == Person); 
                    Console.Write($"Найдено: ");
                    p.Display();
                    Console.WriteLine("Клонирование...");
                    for (int i = 10; i > 0; i--)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine(i);
                    }

                    Person ClonP = (Administer) p.Clone();
                    Console.WriteLine("Клонирование завершено!");

                    Console.WriteLine(ClonP.FirstName + " " + ClonP.LastName + " " + ClonP.Age);

                    //interface IExecutable
                    ClonP.Execute();
                    Console.WriteLine("Клонирование...");
                    for (int i = 10; i > 0; i--)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine(i);
                    }

                    Console.WriteLine(ClonP.FirstName + " " + ClonP.LastName + " " + ClonP.Age);
                }
                catch
                {
                    Console.WriteLine("Пользователя нет!");
                }

                Console.ReadLine();
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
