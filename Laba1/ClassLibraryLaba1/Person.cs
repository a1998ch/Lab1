using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO:
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
        private bool _capitalLetter = false;

        //TODO: RSDN
        public string Name
        {
            set
            {
                //TODO: duplication
                _name = value;
                _name = ValidationNameAndSurname(_name);
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
                NameAndSurnameOnlyRusOrEng();
                _surname = ValidationNameAndSurname(_surname);
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
                AgeEntryRule();
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

        public Person(GenderType gender)
        {
            Gender = gender;
        }

        public string ValidationNameAndSurname(string nameOrSurname)
        {
            char[] doubleNameOrSurname = { ' ', '-', ',' };
            string[] nameOrSurnameChar = nameOrSurname.Split(doubleNameOrSurname, StringSplitOptions.RemoveEmptyEntries);
            if (nameOrSurnameChar.Length == 1)
            {
                if (Convert.ToString(nameOrSurnameChar[0])[0].ToString() !=
                    Convert.ToString(nameOrSurnameChar[0])[0].ToString().ToUpper())
                {
                    string capitalName = Convert.ToString(nameOrSurnameChar[0]).Substring(1);
                    nameOrSurname = Convert.ToString(nameOrSurnameChar[0])[0].ToString().ToUpper() + capitalName;
                    SpellingNameAndSurname(nameOrSurname);
                    _capitalLetter = true;
                }
            }
            else if (nameOrSurnameChar.Length == 2)
            {
                if (Convert.ToString(nameOrSurnameChar[0])[0].ToString() !=
                    Convert.ToString(nameOrSurnameChar[0])[0].ToString().ToUpper() ||
                    Convert.ToString(nameOrSurnameChar[1])[0].ToString() !=
                    Convert.ToString(nameOrSurnameChar[1])[0].ToString().ToUpper())
                {
                    string capitalName1 = Convert.ToString(nameOrSurnameChar[0]).Substring(1);
                    string capitalName2 = Convert.ToString(nameOrSurnameChar[1]).Substring(1);
                    nameOrSurname = Convert.ToString(nameOrSurnameChar[0])[0].ToString().ToUpper() + capitalName1 +
                           "-" + Convert.ToString(nameOrSurnameChar[1])[0].ToString().ToUpper() + capitalName2;
                    SpellingNameAndSurname(nameOrSurname);
                    _capitalLetter = true;
                }
            }
            else
            {
                throw new Exception("Возможно неправильный ввод данных");
            }
            return nameOrSurname;
        }

        public string SpellingNameAndSurname(string nameOrSurname)
        {
            Regex errorAlphabet = new Regex("([a-z])([а-я])|([а-я])([a-z])|([a-z])-([а-я])|([а-я])-([a-z])");     
            if (errorAlphabet.IsMatch(nameOrSurname.ToLower()))
            {
                throw new Exception("Имя и Фамилия должны содержать только русские или только английские символы");
            }
            else
            {
                return nameOrSurname;
            }
        }

        public string NameAndSurnameOnlyRusOrEng()
        {
            Regex rusAlphabet = new Regex("^[а-я]");
            if (!rusAlphabet.IsMatch(Name.ToLower()) & rusAlphabet.IsMatch(Surname.ToLower()) ||
                rusAlphabet.IsMatch(Name.ToLower()) & !rusAlphabet.IsMatch(Surname.ToLower()))
            {
                throw new Exception("Фамилия и имя должны быть написаны на одном языке");
            }
            else
            {
                return Surname;
            }
        }

        public void NameAndSurnameCapitalLetterMessage()
        {
            if (_capitalLetter == true)
            {
                throw new Exception("Имя и Фамилию необходимо писать с большой буквы");
            }
        }

        public int AgeEntryRule()
        {
            if (Age > 120 || Age < 0)
            {
                throw new Exception("Необходимо вводить числа от \"0\" до \"120\"");
            }
            else
            {
                return Age;
            }
        }

        public string Info()
        {
            return $"Имя: {Name}, Фамилия: {Surname}, Возраст: {Age}, Пол: {Gender}";
        }
        
        public static Person GetRandomPerson()
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

            if (Gender == Convert.ToString(GenderType.Мужской))
            {
                return new Person(MenName, MenSurame, Age, GenderType.Мужской);
            }
            else
            {
                return new Person(WoomenName, WoomenSurame, Age, GenderType.Женский);
            }
        }
    }
}
