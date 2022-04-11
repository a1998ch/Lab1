using System;
using System.Text;
using ModelLaba1;
using static System.Console;

namespace ViewLaba1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;

            PersonList personList1 = new PersonList();
            personList1.Add(new Person("Сергей", "Пащенко", 23, GenderType.Мужской));
            personList1.Add(new Person("Дмитрий", "Питомец", 55, GenderType.Мужской));
            personList1.Add(new Person("Дарья", "Ивасенко", 60, GenderType.Женский));

            PersonList personList2 = new PersonList();
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
            personList1.DelitePersonByIndex(1);
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
                WriteLine("\nВведите команду: \n" +
                          "\"Добавить человека\" = 1, \n" +
                          "\"Удалить человека\" = 2, \n" +
                          "\"Удалить человека по индексу\" = 3, \n" +
                          "\"Поиск человека по индексу\" = 4, \n" +
                          "\"Поиск индекса по человеку\" = 5, \n" +
                          "\"Очистить список\" = 6, \n" +
                          "\"Количество элементов в списке\" = 7, \n" +
                          "\"Выбрать другой список\" = 8, \n" +
                          "\"Выход\" чтобы выйти\n");
                
                string command = ReadLine();
                const string addPerson = "1";
                const string delitePerson = "2";
                const string delitePersonByIndex = "3";
                const string searchPersonByIndex = "4";
                const string searchIndexByPerson = "5";
                const string cleanPersonList = "6";
                const string lengthPersonList = "7";
                const string choicePersonList = "8";
                
                switch (command)
                {
                    case addPerson:
                        {
                            WriteLine("\nДля добавления случайного человека нажмите \"1\" или \"2\" " +
                                                                    "чтобы добавить человека вручную: ");

                            string choice = ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    personList.Add(Person.GetRandomPerson());
                                    WriteLine("\n{0}", personList.PrintPersonList());
                                    break;
                                case "2":
                                    personList.Add(Read());
                                    WriteLine("\n{0}", personList.PrintPersonList());
                                    break;
                                default:
                                    WriteLine("Нужно выбрать \"1\" или \"2\"");
                                    break;
                            }
                            break;
                        }
                    case delitePerson:
                        {
                            try
                            {
                                personList.DelitePersonByData(Read());
                            }
                            catch (Exception ex)
                            {
                                ExceptionMessage(ex);
                            }
                            WriteLine("\n{0}", personList.PrintPersonList());
                            break;
                        }
                    case delitePersonByIndex:
                        {
                            try
                            {
                                WriteLine("\nВведите индекс:");
                                personList.DelitePersonByIndex(int.Parse(ReadLine()));
                            }
                            catch (Exception ex)
                            {
                                ExceptionMessage(ex);
                            }
                            WriteLine("\n{0}", personList.PrintPersonList());
                            break;
                        }
                    case searchPersonByIndex:
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
                            break;
                        }
                    case searchIndexByPerson:
                        {
                            try
                            {
                                WriteLine("\nИндекс введённого человека: {0}",
                                                    personList.SearchIndexByPerson(Read()));
                            }
                            catch (Exception ex)
                            {
                                ExceptionMessage(ex);
                            }
                            break;
                        }
                    case cleanPersonList:
                        {
                            personList.CleanList();
                            WriteLine("\nСписок отчищен");
                            break;
                        }
                    case lengthPersonList:
                        {
                            WriteLine("\nДлина списка: {0}", personList.Length);
                            break;
                        }
                    case choicePersonList:
                        {
                            personList = ListChoice(personList1, personList2);
                            break;
                        }
                }
                
                if (command.ToLower() == "выход")
                {
                    WriteLine("\nПрограмма завершена");
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

        /// <summary>
        /// Выбор пола персоны
        /// </summary>
        /// <returns>Пол персоны</returns>
        private static GenderType ReadGenderFromConsole()
        {
            while (true)
            {
                WriteLine($"\nВведите пол: {GenderType.Мужской} = \"М\"" +
                                    $" или {GenderType.Женский} = \"Ж\" ");
                string gender = ReadLine();
                try
                {
                    switch (gender.ToLower())
                    {
                        case "м":
                            return GenderType.Мужской;
                        case "ж":
                            return GenderType.Женский;
                        default:
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
            
            while (true)
            {
                Write("\nВведите имя: ");
                string testName = ReadLine();
                try
                {
                    partPerson.Name = testName;
                    WarningMessage(testName);
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
            }

            while (true)
            {
                Write("\nВведите фамилию: ");
                string testSurname = ReadLine();
                try
                {
                    partPerson.Surname = testSurname;
                    WarningMessage(testSurname);
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
            }
            
            while (true)
            {
                Write("\nВведите возраст: ");
                try
                {
                    partPerson.Age = int.Parse(ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionMessage(ex);
                }
            }
            
            partPerson.Gender = ReadGenderFromConsole();
            return partPerson;
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

        /// <summary>
        /// Выводит в консоль предупреждение при неправильном регистре имени или фамилии
        /// </summary>
        /// <param name="nameOrSurname">Имя или фамилия для проверки</param>
        private static void WarningMessage(string nameOrSurname)
        {
            if (nameOrSurname[0].ToString() != nameOrSurname[0].ToString().ToUpper())
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nПредупреждение: \"Имя и Фамилию необходимо писать с большой буквы\"");
                ResetColor();
            }
        }
    }
}
