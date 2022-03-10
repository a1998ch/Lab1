using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace ModelLaba1
{
    public class Person
    {
        private Gender gender;
        private string Name;
        private string Surname;
        private int Age;

        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;

        public string name
        {
            set
            {
                Name = value;
                Regex rusAlphabet = new Regex("[а-я]");
                Regex engAlphabet = new Regex("[a-z]");
                while (true)
                {
                    if (rusAlphabet.IsMatch(Name) & engAlphabet.IsMatch(Name))
                    {
                        WriteLine("\nИмя должно содержать только русские или только английские символы");
                    }
                    else
                    {
                        break;
                    }
                    Write("\nВведите имя: ");
                    name = ReadLine();
                }

                if (rusAlphabet.IsMatch(Name))
                {
                    flag1 = true;
                }
                else
                {
                    flag2 = true;
                }

                if (Name[0].ToString() != Name[0].ToString().ToUpper())
                {
                    WriteLine("Имена необходимо писать с большой буквы");
                }
                string capitalName = Name.ToString().Substring(1);
                Name = Name[0].ToString().ToUpper() + capitalName;
            }
            get
            {
                return Name;
            }
        }

        public string surname
        {
            set
            {
                Surname = value;
                Regex rusAlphabet = new Regex("[а-я]");
                Regex engAlphabet = new Regex("[a-z]");

                if (rusAlphabet.IsMatch(Surname))
                {
                    flag3 = true;
                }
                else
                {
                    flag4 = true;
                }

                while (true)
                {
                    if (rusAlphabet.IsMatch(Surname) & engAlphabet.IsMatch(Surname))
                    {
                        WriteLine("\nФамилия должна содержать только русские или только английские символы");
                    }
                    else if (flag1 != flag3 && flag2 != flag4)
                    {
                        WriteLine("\nИмя и фамилия должны быть заполнены на одном языке");
                    }
                    else
                    {
                        flag1 = false;
                        flag2 = false;
                        flag3 = false;
                        flag4 = false;
                        break;
                    }
                    Write("\nВведите фамилию: ");
                    surname = ReadLine();
                }

                if (Surname[0].ToString() != Surname[0].ToString().ToUpper())
                {
                    WriteLine("Фамилии необходимо писать с большой буквы");
                }
                string capitalSurname = Surname.ToString().Substring(1);
                Surname = Surname[0].ToString().ToUpper() + capitalSurname;
            }
            get
            {
                return Surname;
            }
        }

        public int age
        {
            set
            {
                Age = value;
            }
            get
            {
                return Age;
            }
        }

        public Gender genderPublic
        {
            set
            {
                gender = value;
            }
            get
            {
                return gender;
            }
        }

        public void Print(string[] array)
        {
            WriteLine(String.Join("\n", array));
        }

        public void Read()
        {
            int n;
            string g;
            PersonList personList = new PersonList();
            Write("\nВведите имя: ");
            name = ReadLine();
            Write("\nВведите фамилию: ");
            surname = ReadLine();
            while (true)
            {
                Write("\nВведите возраст: ");
                if (!int.TryParse(g = ReadLine(), out n) || Convert.ToInt32(g) > 120 || Convert.ToInt32(g) < 0)
                {
                    WriteLine("\nНеобходимо вводить числа от \"0\" до \"120\"");
                }
                else
                {
                    age = Convert.ToInt32(g);
                    break;
                }
            }
            genderPublic = personList.genderMetod();
        }
        
        public static string GetRandomPerson()
        {
            Random person = new Random(DateTime.Now.Millisecond);

            string[] menName = new string[10] { "Павел", "Антон", "Алексей", "Максим", "Александр", 
                                                "Ярослав", "Илья", "Пётр", "Олег", "Сергей" };
            string[] woomenName = new string[10] { "Ольга", "Светлана", "Марина", "Олеся", "Анна", 
                                                   "Галина", "Алиса", "Вероника", "Вера", "Лариса" };
            string[] menSurname = new string[10] { "Иванов", "Петров", "Сидоров", "Какауров", "Ермолаев", 
                                                   "Еремеев", "Раздобреев", "Пляскин", "Загибалов", "Сергеев" };
            string[] woomenSurname = new string[10] { "Бардакова", "Филатова", "Попова", "Золотухина", "Сорокина", 
                                                     "Вычугжанина", "Стремилова", "Лопаницына", "Жеребцова", "Лосякова" };
            string[] gender = new string[2] { "Мужской", "Женский" };
 
            string MenName = menName[person.Next(menName.Length)];
            string MenSurame = menSurname[person.Next(menSurname.Length)];
            string WoomenName = woomenName[person.Next(woomenName.Length)];
            string WoomenSurame = woomenSurname[person.Next(woomenSurname.Length)];
            int Age = person.Next(0, 120);
            string Gender = gender[person.Next(gender.Length)];

            string menPeople = MenName + ", " + MenSurame + ", " + Age + ", " + Gender;
            string woomenPeople = WoomenName + ", " + WoomenSurame + ", " + Age + ", " + Gender;
            if (Gender == "Мужской")
            {
                return menPeople;
            }
            else
            {
                return woomenPeople;
            }
        }
    }
}
