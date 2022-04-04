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
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;

            PersonList personList1 = new PersonList();
            PersonList personList2 = new PersonList();

            personList1.Add(new Person("Сергей", "Пащенко", 23, GenderType.Мужской));
            personList1.Add(new Person("Дмитрий", "Питомец", 55, GenderType.Мужской));
            personList1.Add(new Person("Дарья", "Ивасенко", 60, GenderType.Женский));

            personList2.Add(new Person("Екатерина", "Бозырева", 28, GenderType.Женский));
            personList2.Add(new Person("Галина", "Павловская", 77, GenderType.Женский));
            personList2.Add(new Person("Вадим", "Азеев", 18, GenderType.Мужской));

            WriteLine("Чтобы вывести содержимое каждого списка на экран нажмите любую кнопку");
            ReadLine();
            WriteLine("Первый список персон:");
            WriteLine(personList1.PrintPersonList());
            WriteLine("Второй список персон:");
            WriteLine(personList2.PrintPersonList());


            WriteLine("\nЧтобы добавить человека в первый список нажмите любую кнопку");
            ReadLine();
            personList1.Add(new Person("Олег", "Николашкин", 23, GenderType.Мужской));
            WriteLine("Первый список персон:");
            WriteLine(personList1.PrintPersonList());


            WriteLine("\nЧтобы скопировать второго человека из первого списка в конец второго " +
                                                                   "списка нажмите любую кнопку");
            ReadLine();
            var personTmp = personList1.SearchByIndex(1);
            personList2.Add(personTmp);
            WriteLine("Первый список персон:");
            WriteLine(personList1.PrintPersonList());
            WriteLine("Второй список персон:");
            WriteLine(personList2.PrintPersonList());


            WriteLine("\nЧтобы удалить второго человека из первого списка нажмите любую кнопку");
            ReadLine();
            personList1.DeliteByIndex(1);
            WriteLine("Первый список персон:");
            WriteLine(personList1.PrintPersonList());
            WriteLine("Второй список персон:");
            WriteLine(personList2.PrintPersonList());


            WriteLine("\nЧтобы отчистить второй список нажмите любую кнопку");
            ReadLine();
            personList2.CleanList();
            WriteLine("Список отчищен");

            PersonList personList = ListChoice(personList1, personList2);

            while (true)
            {
                WriteLine("\nВведите команду: \n\"Добавить человека\" = 1, \n\"Удалить человека\" = 2, " +
                         "\n\"Удалить человека по индексу\" = 3, \n\"Поиск человека по индексу\" = 4, " +
                         "\n\"Поиск индекса по человеку\" = 5, \n\"Очистить список\" = 6," +
                         "\n\"Количество элементов в списке\" = 7, \n\"Выбрать другой список\" = 8, " +
                         "\n\"Выход\" чтобы выйти\n");
                //TODO:
                string command = ReadLine();
                if (command == "1")
                {
                    WriteLine("\nДля добавления случайного человека нажмите \"1\" или \"2\" " +
                                                            "чтобы добавить человека вручную: ");
                    string choice = ReadLine();
                    if (choice == "1")
                    {
                        personList.Add(Person.GetRandomPerson());
                        WriteLine("\n{0}", personList.PrintPersonList());
                    }
                    else if (choice == "2")
                    {
                        personList.Add(Read());
                        WriteLine("\n{0}", personList.PrintPersonList());
                    }
                    else
                    {
                        WriteLine("Нужно выбрать \"1\" или \"2\"");
                    }
                }

                else if (command == "2")
                {
                    try
                    {
                        personList.DelitePerson(Read());
                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage(ex);
                    }
                    WriteLine("\n{0}", personList.PrintPersonList());
                }

                else if (command == "3")
                {
                    try
                    {
                        WriteLine("\nВведите индекс:");
                        personList.DeliteByIndex(int.Parse(ReadLine()));
                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage(ex);
                    }
                    WriteLine("\n{0}", personList.PrintPersonList());
                }

                else if (command == "4")
                {
                    try
                    {
                        WriteLine("\nВведите индекс:");
                        WriteLine("\n{0}", personList.SearchByIndex(int.Parse(ReadLine())).Info());
                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage(ex);
                    }
                }

                else if (command == "5")
                {
                    try
                    {
                        //TODO: RSDN
                        WriteLine("\nИндекс введённого человека: {0}", 
                                            personList.SearchIndexByPeople(Read()));
                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage(ex);
                    }
                }

                else if (command == "6")
                {
                    personList.CleanList();
                    WriteLine("\nСписок отчищен");
                }

                else if (command == "7")
                {
                    WriteLine("\nДлина списка: {0}", personList.LengthList());
                }

                else if (command == "8")
                {
                    personList = ListChoice(personList1, personList2);
                }

                else if (command.ToLower() == "выход")
                {
                    WriteLine("\nПока");
                    break;
                }
            }
            ReadLine();
        }

        /// <summary>
        /// Выбор списка персон
        /// </summary>
        /// <param name="people1">Экземпляр класса PersonList</param>
        /// <param name="people2">Экземпляр класса PersonList</param>
        private static PersonList ListChoice(PersonList people1, PersonList people2)
        {
            while (true)
            {
                WriteLine($"\nВыберете список персон: 1 или 2");
                string list = ReadLine();
                switch (list)
                {
                    case "1":
                        return people1;
                    case "2":
                        return people2;
                    default:
                        WriteLine("Нет такого списка");
                        break;
                }
            }
        }

        //TODO: static
        /// <summary>
        /// Выбор пола персоны
        /// </summary>
        /// <returns>Пол персоны</returns>
        private static GenderType ReadGenderFromConsole()
        {
            string gender;
            while (true)
            {
                WriteLine($"\nВведите пол: {GenderType.Мужской} = \"М\"" +
                                    $" или {GenderType.Женский} = \"Ж\" ");
                gender = ReadLine();
                try
                {
                    //TODO:
                    if (gender.ToLower() == "м")
                    {
                        return GenderType.Мужской;
                    }
                    else if (gender.ToLower() == "ж")
                    {
                        return GenderType.Женский;
                    }
                    else
                    {
                        throw new Exception("Неправильный пол");
                    }
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
            }
        }

        /// <summary>
        /// Ввод информации о персоне в консоль
        /// </summary>
        /// <returns>Полная информация о персоне</returns>
        private static Person Read()
        {
            var partPerson = new Person(GenderType.Мужской);
            Write("\nВведите имя: ");
            string testName;
            while (true)
            {
                testName = ReadLine();
                try
                {
                    partPerson.Name = testName;
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
                Write("\nВведите имя повторно: ");
            }

            if (testName[0].ToString() != testName[0].ToString().ToUpper())
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nПредупреждение: \"Имя необходимо писать с большой буквы\"");
                ResetColor();
            }

            Write("\nВведите фамилию: ");
            string testSurname;
            while (true)
            {
                testSurname = ReadLine();
                try
                {
                    partPerson.Surname = testSurname;
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
                Write("\nВведите фамилию повторно: ");
            }

            if (testSurname[0].ToString() != testSurname[0].ToString().ToUpper())
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nПредупреждение: \"Фамилию необходимо писать с большой буквы\"");
                ResetColor();
            }

            Write("\nВведите возраст: ");
            while (true)
            {
                try
                {
                    partPerson.Age = int.Parse(ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
                Write("\nВведите возраст повторно: ");
            }
            GenderType Gender = ReadGenderFromConsole();
            return new Person(partPerson.Name, partPerson.Surname, partPerson.Age, Gender);
        }

        /// <summary>
        /// Выводит в консоль текст при срабатывании исключения
        /// </summary>
        /// <param name="ex">представляет из себя сообщение об ошибке</param>
        private static void ExceptionMessage(Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            Write($"\nОшибка: { ex.Message}\n");
            ResetColor();
        }
    }
}
