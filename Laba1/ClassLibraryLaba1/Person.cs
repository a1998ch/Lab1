using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ModelLaba1
{
    /// <summary>
    /// Класс Person 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст 
        /// </summary>
        private int _age;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int MaxAge = 120;

        /// <summary>
        /// Пол
        /// </summary>
        private GenderType _gender;
        
        /// <summary>
        /// Метод для работы с именем 
        /// </summary>
        public string Name
        {
            set
            {
                _name = ValidationNameAndSurname(value);
            }
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Метод для работы с фамилией 
        /// </summary>
        public string Surname
        {
            set
            {
                _surname = ValidationNameAndSurname(value);
            }
            get
            {
                return _surname;
            }
        }

        /// <summary>
        /// Метод для работы с возрастом 
        /// </summary>
        public int Age
        {
            set
            {
                _age = AgeEntryRule(value);
            }
            get
            {
                return _age;
            }
        }

        /// <summary>
        /// Метод для работы с полом 
        /// </summary>
        public GenderType Gender
        {
            set => _gender = value;
            get => _gender;
        }

        /// <summary>
        /// Констукрутор класса
        /// </summary>
        /// <param name="name">Имя персоны</param>
        /// <param name="surname">Фамилия персоны</param>
        /// <param name="age">Возраст персоны</param>
        /// <param name="gender">Пол персоны</param>
        public Person(string name, string surname, int age, GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Person(GenderType gender)
        {
            Gender = gender;
        }

        /// <summary>
        /// Проверка правильности ввода имени и фамилии персоны
        /// </summary>
        /// <param name="nameOrSurname">Имя или фамилия для проверки</param>
        /// <returns>Корректное имя или фамилию</returns>
        private string ValidationNameAndSurname(string nameOrSurname)
        {
            string nameOrSurnameCorrect = CorrectCaseNameAndSurname(nameOrSurname);
            SpellingNameAndSurname(nameOrSurnameCorrect);

            if (Name != null)
            {
                NameAndSurnameOnlyRusOrEng(nameOrSurnameCorrect);
            }

            return nameOrSurnameCorrect;
        }

        /// <summary>
        /// Преобразование имени или фамилии персоны в правильные регистры
        /// </summary>
        /// <param name="nameOrSurname">Имя или фамилия персоны</param>
        /// <returns>Корректное имя или фамилию с точки зрения правильности регистра</returns>
        private string CorrectCaseNameAndSurname(string nameOrSurname)
        {
            char[] doubleNameOrSurname = { ' ', '-', ',' };
            string[] nameOrSurnameChar = nameOrSurname.Split(doubleNameOrSurname,
                StringSplitOptions.RemoveEmptyEntries);
            if (nameOrSurnameChar.Length == 1)
            {
                string capitalName = Convert.ToString(nameOrSurnameChar[0]).Substring(1).ToLower();
                nameOrSurname = Convert.ToString(nameOrSurnameChar[0])[0].ToString().ToUpper() + capitalName;
                return nameOrSurname;
            }
            else if (nameOrSurnameChar.Length == 2)
            {
                string capitalName1 = Convert.ToString(nameOrSurnameChar[0]).Substring(1).ToLower();
                string capitalName2 = Convert.ToString(nameOrSurnameChar[1]).Substring(1).ToLower();
                nameOrSurname = Convert.ToString(nameOrSurnameChar[0])[0].ToString().ToUpper() + capitalName1 +
                       "-" + Convert.ToString(nameOrSurnameChar[1])[0].ToString().ToUpper() + capitalName2;
                return nameOrSurname;
            }
            else
            {
                throw new Exception("Неправильный ввод данных");
            }
        }

        /// <summary>
        /// Проверка имени или фамилии персоны на соответствие одному языку
        /// </summary>
        /// <param name="nameOrSurname">Имя или фамилия для проверки</param>
        private void SpellingNameAndSurname(string nameOrSurname)
        {
            Regex errorAlphabet = new Regex(
                "([a-z])([а-я])|([а-я])([a-z])|([a-z])-([а-я])|([а-я])-([a-z])");     
            if (errorAlphabet.IsMatch(nameOrSurname.ToLower()))
            {
                throw new Exception("Имя и Фамилия должны содержать " +
                    "только русские или только английские символы");
            }
        }

        /// <summary>
        /// Проверка фамилии персоны на соответствие языку, введеного имени
        /// </summary>
        /// <param name="surname">Фамилия для проверки</param>
        private void NameAndSurnameOnlyRusOrEng(string surname)
        {
            Regex rusAlphabet = new Regex("^[а-я]");
            
            //TODO:
            if (!rusAlphabet.IsMatch(Name.ToLower()) && rusAlphabet.IsMatch(surname.ToLower()) ||
                rusAlphabet.IsMatch(Name.ToLower()) && !rusAlphabet.IsMatch(surname.ToLower()))
            {
                throw new Exception("Фамилия и имя должны быть написаны на одном языке");
            }
        }

        /// <summary>
        /// Проверка правильности ввода возраста персоны
        /// </summary>
        /// <param name="age">Возраст для проверки</param>
        /// <returns>Корректный возраст</returns>
        private int AgeEntryRule(int age)
        {
            //TODO: const
            if (age > MaxAge || age < 0)
            {
                throw new Exception($"Необходимо вводить числа от \"0\" до \"{MaxAge}\"");
            }
            else
            {
                return age;
            }
        }

        /// <summary>
        /// Вывод информации о персоне
        /// </summary>
        public string Info()
        {
            return $"Имя: {Name}, Фамилия: {Surname}, Возраст: {Age}, Пол: {Gender}";
        }

        /// <summary>
        /// Генерирует случайную персону
        /// </summary>
        /// <returns>Случайная персона</returns>
        public static Person GetRandomPerson()
        {
            Random person = new Random(DateTime.Now.Millisecond);

            string[] menNameArray = new string[10] { "Павел", "Антон", "Алексей", "Максим", "Александр", 
                                                     "Ярослав", "Илья", "Пётр", "Олег", "Сергей" };
            string[] woomenNameArray = new string[10] { "Ольга", "Светлана", "Марина", "Олеся", "Анна", 
                                                        "Галина", "Алиса", "Вероника", "Вера", "Лариса" };
            string[] menSurnameArray = new string[10] { "Иванов", "Петров", "Сидоров", "Какауров", 
                                                        "Ермолаев", "Еремеев", "Раздобреев", "Пляскин", 
                                                                            "Загибалов", "Сергеев" };
            string[] woomenSurnameArray = new string[10] { "Бардакова", "Филатова", "Попова", "Золотухина", 
                                                           "Сорокина", "Вычугжанина", "Стремилова", 
                                                             "Лопаницына", "Жеребцова", "Лосякова" };
            string[] genderArray = new string[2] { "Мужской", "Женский" };
 
            //TODO: RSDN
            string menName = menNameArray[person.Next(menNameArray.Length)];
            string menSurame = menSurnameArray[person.Next(menSurnameArray.Length)];
            string woomenName = woomenNameArray[person.Next(woomenNameArray.Length)];
            string woomenSurame = woomenSurnameArray[person.Next(woomenSurnameArray.Length)];
            int age = person.Next(0, 120);
            string gender = genderArray[person.Next(genderArray.Length)];

            return gender == Convert.ToString(GenderType.Мужской) 
                ? new Person(menName, menSurame, age, GenderType.Мужской) 
                : new Person(woomenName, woomenSurame, age, GenderType.Женский);
        }
    }
}
