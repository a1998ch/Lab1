using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLaba1;
using static System.Console;

namespace ViewLaba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;

            PersonList personList = new PersonList();

            Person person1 = new Person();
            Person person2 = new Person();
            Person person3 = new Person();
            Person person4 = new Person();
            Person person5 = new Person();
            Person person6 = new Person();

            person1.name = "Сергей";
            person1.surname = "Пащенко";
            person1.age = 23;
            person1.genderPublic = Gender.Мужской;
            person2.name = "Дмитрий";
            person2.surname = "Питомец";
            person2.age = 55;
            person2.genderPublic = Gender.Мужской;
            person3.name = "Дарья";
            person3.surname = "Ивасенко";
            person3.age = 60;
            person3.genderPublic = Gender.Женский;
            person4.name = "Екатерина";
            person4.surname = "Бозырева";
            person4.age = 28;
            person4.genderPublic = Gender.Женский;
            person5.name = "Галина";
            person5.surname = "Павловская";
            person5.age = 77;
            person5.genderPublic = Gender.Женский;
            person6.name = "Вадим";
            person6.surname = "Азеев";
            person6.age = 18;
            person6.genderPublic = Gender.Мужской;

            string[] people1 = new string[3];
            string[] people2 = new string[3];
            people1[0] = person1.name + ", " + person1.surname + ", " + person1.age + ", " + person1.genderPublic;
            people1[1] = person2.name + ", " + person2.surname + ", " + person2.age + ", " + person2.genderPublic;
            people1[2] = person3.name + ", " + person3.surname + ", " + person3.age + ", " + person3.genderPublic;
            people2[0] = person4.name + ", " + person4.surname + ", " + person4.age + ", " + person4.genderPublic;
            people2[1] = person5.name + ", " + person5.surname + ", " + person5.age + ", " + person5.genderPublic;
            people2[2] = person6.name + ", " + person6.surname + ", " + person6.age + ", " + person6.genderPublic;


            WriteLine("Чтобы вывести содержимое каждого списка на экран нажмите любую кнопку");
            ReadLine();
            WriteLine("Первый список персон:");
            person.Print(people1);
            WriteLine("\nВторой список персон:");
            person.Print(people2);
            
            


            WriteLine("\nЧтобы добавить человека в первый список нажмите любую кнопку");
            ReadLine();
            string newPeople = "Олег" + ", " + "Николашкин" + ", " + 23 + ", " + Gender.Мужской;
            people1 = personList.MyAdd(people1, newPeople);
            WriteLine("Первый список персон:");
            person.Print(people1);


            WriteLine("\nЧтобы скопировать второго человека из первого списка в конец второго списка нажмите любую кнопку");
            ReadLine();
            string secondPeople = personList.SearchPeopleIndex(people1, 1);
            people2 = personList.MyAdd(people2, secondPeople);
            WriteLine("Первый список персон:");
            for (int i = 0; i < people1.Length; i++)
            {
                if (i == 1)
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine(people1[i]);
                ResetColor();
            }
            WriteLine("\nВторой список персон:");
            for (int i = 0; i < people2.Length; i++)
            {
                if (i == people2.Length - 1)
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine(people2[i]);
                ResetColor();
            }


            WriteLine("\nЧтобы удалить второго человека из первого списка нажмите любую кнопку");
            ReadLine();
            people1 = personList.DelIndex(people1, 1);
            WriteLine("Первый список персон:");
            person.Print(people1);
            WriteLine("\nВторой список персон:");
            for (int i = 0; i < people2.Length; i++)
            {
                if (i == people2.Length - 1)
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine(people2[i]);
                ResetColor();
            }


            WriteLine("\nЧтобы отчистить второй список нажмите любую кнопку");
            ReadLine();
            people2 = personList.Clean(people2);
            WriteLine("Список отчищен");


            string[] people = personList.spisok(people1, people2);

            while (true)
            {
                WriteLine("\nВведите команду: \n\"Добавить человека\" = 1, \n\"Удалить человека\" = 2, " +
                         "\n\"Удалить человека по индексу\" = 3, \n\"Поиск человека по индексу\" = 4, " +
                         "\n\"Поиск индекса по человук\" = 5, \n\"Очистить список\" = 6," +
                         "\n\"Количество элементов в списке\" = 7, \n\"Выбрать другой список\" = 8, " +
                         "\n\"Выход\" чтобы выйти\n");
                string command = "";
                string command1 = "1";
                string command2 = "2";
                string command3 = "3";
                string command4 = "4";
                string command5 = "5";
                string command6 = "6";
                string command7 = "7";
                string command8 = "8";
                string exit = "Выход".ToLower();
                command = ReadLine();
                if (command == command1)
                {
                    WriteLine("\nДля добавления случайного человека нажмите \"1\" или \"2\" чтобы добавить человека вручную: ");
                    string choice = ReadLine();
                    if (choice == "1")
                    {
                        string peopleComplex = Person.GetRandomPerson();
                        people = personList.MyAdd(people, peopleComplex);
                        WriteLine();
                        person.Print(people);
                    }
                    else if (choice == "2")
                    {
                        person.Read();
                        string peopleComplex = person.name + ", " + person.surname + ", " + person.age + ", " + person.genderPublic;
                        people = personList.MyAdd(people, peopleComplex);
                        WriteLine();
                        person.Print(people);
                    }
                    else
                    {
                        WriteLine("Нужно выбрать \"1\" или \"2\"");
                    }
                }

                else if (command == command2)
                {
                    person.Read();
                    string peopleComplex = person.name + ", " + person.surname + ", " + person.age + ", " + person.genderPublic;
                    if (people.Contains(peopleComplex))
                    {
                        people = personList.Del(people, peopleComplex);
                        WriteLine();
                        person.Print(people);
                    }
                    else
                    {
                        WriteLine("\nВ списке нет такого человека");
                    }
                }

                else if (command == command3)
                {
                    int n;
                    string index;
                    Write("\nВведите индекс: ");
                    if (!int.TryParse(index = ReadLine(), out n))
                    {
                        WriteLine("\nНеобходимо вводить числа");
                    }
                    else if (Convert.ToInt32(index) < personList.MyLength(people) && Convert.ToInt32(index) > 0)
                    {
                        people = personList.DelIndex(people, Convert.ToInt32(index));
                        WriteLine();
                        person.Print(people);
                    }
                    else
                    {
                        WriteLine("\nВ списке нет человека с таким индексом");
                    }
                }

                else if (command == command4)
                {
                    int n;
                    string index;
                    Write("\nВведите индекс: ");
                    if (!int.TryParse(index = ReadLine(), out n))
                    {
                        WriteLine("\nНеобходимо вводить числа");
                    }
                    else if (Convert.ToInt32(index) < personList.MyLength(people) && Convert.ToInt32(index) > 0)
                    {
                        WriteLine("\n{0}", personList.SearchPeopleIndex(people, Convert.ToInt32(index)));
                    }
                    else
                    {
                        WriteLine("\nВ списке нет человека с таким индексом");
                    }
                }

                else if (command == command5)
                {
                    person.Read();
                    string peopleComplex = person.name + ", " + person.surname + ", " + person.age + ", " + person.genderPublic;
                    if (people.Contains(peopleComplex))
                    {
                        WriteLine("\n{0}", personList.SearchIndex(people, peopleComplex));
                    }
                    else
                    {
                        WriteLine("\nВ списке нет такого человека");
                    }
                }

                else if (command == command6)
                {
                    if (personList.MyLength(people) > 0)
                    {
                        people = personList.Clean(people);
                        WriteLine("\nСписок отчищен");
                    }
                    else
                    {
                        WriteLine("\nСписок был пуст");
                    }
                }

                else if (command == command7)
                {
                    WriteLine("\nДлина списка: {0}", personList.MyLength(people));
                }

                else if (command == command8)
                {
                    people = personList.spisok(people1, people2);
                }

                else if (command.ToLower() == exit)
                {
                    WriteLine("\nПока");
                    break;
                }
            }
            ReadLine();
        }
    }
}
