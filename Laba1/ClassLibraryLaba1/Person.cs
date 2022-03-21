using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO:
using static System.Console;
using System.Text.RegularExpressions;

namespace ModelLaba1
{
    //TODO: RSDN
    public class Person
    {
        private GenderType _gender;
        private string _name;
        private string _surname;
        private int _age;

        //TODO: RSDN
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;

        public string Name
        {
            set
            {
                //TODO: duplication
                _name = value;
                Regex rusAlphabet = new Regex("[а-я]");
                Regex engAlphabet = new Regex("[a-z]");
                while (true)
                {
                    if (rusAlphabet.IsMatch(_name) & engAlphabet.IsMatch(_name))
                    {
                        WriteLine("\nИмя должно содержать только русские или только английские символы");
                    }
                    else
                    {
                        break;
                    }
                    Write("\nВведите имя: ");
                    Name = ReadLine();
                }

                if (rusAlphabet.IsMatch(_name))
                {
                    flag1 = true;
                }
                else
                {
                    flag2 = true;
                }

                if (_name[0].ToString() != _name[0].ToString().ToUpper())
                {
                    WriteLine("Имена необходимо писать с большой буквы");
                }
                string capitalName = _name.ToString().Substring(1);
                _name = _name[0].ToString().ToUpper() + capitalName;
            }
            get
            {
                return _name;
            }
        }

        public string Surname
        {
            set
            {
                _surname = value;
                Regex rusAlphabet = new Regex("[а-я]");
                Regex engAlphabet = new Regex("[a-z]");

                if (rusAlphabet.IsMatch(_surname))
                {
                    flag3 = true;
                }
                else
                {
                    flag4 = true;
                }

                while (true)
                {
                    if (rusAlphabet.IsMatch(_surname) & engAlphabet.IsMatch(_surname))
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
                    Surname = ReadLine();
                }

                if (_surname[0].ToString() != _surname[0].ToString().ToUpper())
                {
                    WriteLine("Фамилии необходимо писать с большой буквы");
                }
                string capitalSurname = _surname.ToString().Substring(1);
                _surname = _surname[0].ToString().ToUpper() + capitalSurname;
            }
            get
            {
                return _surname;
            }
        }

        public int Age
        {
            set
            {
                _age = value;
            }
            get
            {
                return _age;
            }
        }

        public GenderType Gender
        {
            set
            {
                _gender = value;
            }
            get
            {
                return _gender;
            }
        }

        public Person(string name, string surname, int age, GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        public string Info()
        {
            return $"Name: {Name}, Surname: {Surname}, Age: {Age}, Gender: {Gender}";
        }

        public void Print(string[] array)
        {
            WriteLine(String.Join("\n", array));
        }

        /*public void Read()
        {
            int n;
            string g;
            PersonList personList = new PersonList();
            Write("\nВведите имя: ");
            Name = ReadLine();
            Write("\nВведите фамилию: ");
            Surname = ReadLine();
            while (true)
            {
                Write("\nВведите возраст: ");
                if (!int.TryParse(g = ReadLine(), out n) || Convert.ToInt32(g) > 120 || Convert.ToInt32(g) < 0)
                {
                    WriteLine("\nНеобходимо вводить числа от \"0\" до \"120\"");
                }
                else
                {
                    Age = Convert.ToInt32(g);
                    break;
                }
            }
            Gender = personList.GenderMetod();
        }*/
        
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
