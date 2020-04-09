using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Laba10
{
    abstract class Person : IComparable, ICloneable, Person.IExecutable
    {
        private string _firstName;
        private int _age;
        private string _lastName;


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }
        

        public virtual void Display()
        {
            Console.WriteLine(FirstName + " " + LastName + " " + Age + " ");
        }


        public static bool operator >(Person person1, Person person2)
        {
            return person1.Age> person2.Age;
        }

        public static bool operator <(Person person1, Person person2)
        {
            return person1.Age < person2.Age;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Age == person1.Age && person1.LastName.Equals(person2.LastName) &&
                   person1.FirstName.Equals(person2.FirstName);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return person1.Age != person1.Age && !person1.LastName.Equals(person2.LastName) &&
                   !person1.FirstName.Equals(person2.FirstName);
        }


        public int CompareTo(object obj)
        {
            Person person1 = (Person)this;
            Person person2 = (Person)obj;
            if (person1 < person2)
                return -1;
            if (person1 > person2)
                return 1;
            return 0;
        }

        public abstract object Clone();

        public abstract void Execute();

        public interface IExecutable
        {
            void Execute();
        }

    }
    //____________________________________________________________________________________________________



    //____________________________________________________________________________________________________
    class Worker : Person
    {
        private string _nameWorkShop = "";

        public string NameWorkShop
        {
            get { return _nameWorkShop; }
            set { _nameWorkShop = value; }
        }


        public Worker(string firstName, string lastName, int age, string nameWorkShop) : base(firstName, lastName, age)
        {
            _nameWorkShop = nameWorkShop;
        }

        public override void Display()
        {
           Console.WriteLine(FirstName + " " + LastName + " " + Age + " " + NameWorkShop);
        }

        public override object Clone()
        {
            return new Worker(FirstName, LastName, Age, NameWorkShop);
        }

        public override void Execute()
        {
            FirstName = "UnknownWorker";
            LastName = "UnknownWorker";
            Age = 0;
            NameWorkShop = "UnknownWorker";
        }
    }


    //____________________________________________________________________________________________________
    class Administer : Person
   {
       private string _whatManage = "";

       public string WhatManage
       {
           get { return _whatManage; }
           set { _whatManage = value; }
       }


       public Administer(string firstName, string lastName, int age, string WhatManage) : base(firstName, lastName, age)
       {
           _whatManage = WhatManage;
       }

       public override void Display()
       {
           Console.WriteLine(FirstName + " " + LastName + " " + Age + " " + WhatManage);
       }

       public override object Clone()
       {
           return new Administer(FirstName, LastName, Age, WhatManage);
       }

       public override void Execute()
       {
           FirstName = "UnknownAdminister";
           LastName = "UnknownAdminister";
           Age = 0;
           WhatManage = "UnknownAdminister";

        }
    }


    //____________________________________________________________________________________________________
    class Engineer : Worker
    {
        private string _nameFactory = "";
        

        public string NameFactory
        {
            get { return _nameFactory; }
            set { _nameFactory = value; }
        }


        public Engineer(string firstName, string lastName, int age, string nameWorkShop, string NameFactory) : base(firstName, lastName, age,nameWorkShop)
        {
            _nameFactory = NameFactory;
        }

        public override void Display()
        {
            Console.WriteLine(FirstName + " " + LastName + " " + Age + " " + NameFactory);
        }

        public override object Clone()
        {
            return new Engineer(FirstName, LastName, Age, NameWorkShop, NameFactory);
        }

        public override void Execute()
        {
            FirstName = "UnknownEngineer";
            LastName = "UnknownEngineer";
            Age = 0;
            NameWorkShop = "UnknownEngineer";
            NameFactory = "UnknownEngineer";

        }
    }





}
