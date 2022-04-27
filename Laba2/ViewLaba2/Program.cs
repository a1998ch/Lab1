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
            //TODO:
            PersonList personList = new PersonList();
            var rnd = new Random();

            string[] person = new string[7];
            for (int i = 0; i < person.Length; i++)
            {
                if (i % 2 == 0)
                {
                    personList.Add(Child.GetRandomChild(rnd));
                }
                else
                {
                    personList.Add(Adult.GetRandomAdult(rnd));
                }
            }

            WriteLine("Чтобы вывести содержимое " +
                "списка на экран нажмите любую кнопку");
            ReadLine();
            WriteLine("Список персон:");
            WriteLine(personList.PrintPersonList());

            while (true)
            {
                WriteLine("Чтобы добавить случайного взрослого " +
                            "нажмите \"1\". \nЧтобы добавить случайного " +
                            "ребёнка нажмите \"2\".\n" +
                            "Чтобы выйти нажмите \"3\".");
                string command = ReadLine();
                switch (command)
                {
                    case "1":
                        personList.Add(Adult.GetRandomAdult(rnd));
                        WriteLine(personList.PrintPersonList());
                        break;
                    case "2":
                        personList.Add(Child.GetRandomChild(rnd));
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

            switch (personTmp)
            {
                case Adult adult:
                    WriteLine("{0}\n{1}", personTmp.FullInfo,
                        adult.TestTypeAdult());
                    break;
                case Child child:
                    WriteLine("{0}\n{1}", personTmp.FullInfo,
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
