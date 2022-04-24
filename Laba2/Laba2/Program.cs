using System;
using System.Text;
using ModelLaba2;
using static System.Console;

namespace ViewLaba2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;

            var adult = new Adult("Сергей", "Пащенко", 49,
                GenderType.Мужской, 123456789, "Энергетик",
                StateOfMarriageType.Married, "Антонина Пащенко");

            var adult2 = new Adult("Антонина", "Пащенко", 33,
                GenderType.Женский, 865756756, "Безработный",
                StateOfMarriageType.Married, "Сергей Пащенко");

            var adult3 = new Adult("Алина", "Буравченко", 57,
                GenderType.Мужской, 876543425, "Слесарь",
                StateOfMarriageType.CivilMarriage, "Фанит Загитов");

            var adult4 = new Adult("Олег", "Николашкин", 23,
                GenderType.Мужской, 876786425, "Актёр",
                StateOfMarriageType.CivilMarriage, "Алина Буравченко");

            var child = new Child("Дмитрий", "Питомец", 12,
                GenderType.Мужской, adult2, adult, "Школа №5");

            var child2 = new Child("Андрей", "Афанасьев", 4,
                GenderType.Мужской, adult2, adult, "Детский сад №3");

            var child3 = new Child("Юрий", "Шашков", 15,
                GenderType.Мужской, adult3, adult4, "Школа №15");

            PersonList personList = new PersonList();
            personList.Add(adult);
            personList.Add(adult2);
            personList.Add(adult3);
            personList.Add(adult4);
            personList.Add(child);
            personList.Add(child2);
            personList.Add(child3);

            WriteLine("Чтобы вывести содержимое " +
                "списка на экран нажмите любую кнопку");
            ReadLine();
            WriteLine("Список персон:");
            WriteLine(personList.PrintPersonList());


            while (true)
            {
                WriteLine("Чтобы добавить случайного взрослого " +
                            "нажмите 1. \nЧтобы добавить случайного " +
                            "ребёнка нажмите 2.\n" +
                            "Чтобы выйти нажмите 3.");
                string command = ReadLine();
                switch(command)
                {
                    case "1":
                        personList.Add(Adult.GetRandomAdult());
                        WriteLine(personList.PrintPersonList());
                        break;
                    case "2":
                        personList.Add(Child.GetRandomChild());
                        WriteLine(personList.PrintPersonList());
                        break;
                }
                if (command == "3")
                {
                    break;
                }
            }


            WriteLine("\nЧтобы программно определить тип четвёртого " +
                        "человека в списке и вывести его на экран " +
                        "нажмите любую кнопку");
            ReadLine();
            var personTmp = personList.SearchByIndex(3);
            switch (personTmp.GetType().Name)
            {
                case "Adult":
                    WriteLine("{0}\n{1}", personTmp.Info(),
                        adult.TestTypeAdult());
                    break;
                case "Child":
                    WriteLine("{0}\n{1}", personTmp.Info(),
                        child.TestTypeChild());
                    break;
                default:
                    WriteLine("Неизвестный тип данных");
                    break;
            }
            ReadLine();
        }
    }
}
