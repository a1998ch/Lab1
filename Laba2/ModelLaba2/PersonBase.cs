using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ModelLaba2
{
    /// <summary>
    /// Класс PersonBase
    /// </summary>
    public abstract class PersonBase
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
        protected string Name
        {
            set => _name = ValidationNameAndSurname(value);
            get => _name;
        }

        /// <summary>
        /// Метод для работы с фамилией 
        /// </summary>
        protected string Surname
        {
            set => _surname = ValidationNameAndSurname(value);
            get => _surname;
        }

        /// <summary>
        /// Метод для работы с возрастом 
        /// </summary>
        protected int Age 
        {
            set => _age = AgeEntryRule(value);
            get => _age;
        }

        /// <summary>
        /// Метод для работы с полом 
        /// </summary>
        protected GenderType Gender
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
        protected PersonBase(string name, string surname,
            int age, GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Корректный ввод возраста персоны
        /// </summary>
        /// <param name="age">Возраст персоны</param>
        /// <returns>Корректный возраст</returns>
        protected abstract int AgeEntryRule(int age);

        /// <summary>
        /// Проверка правильности ввода имени и фамилии персоны
        /// </summary>
        /// <param name="nameOrSurname">Имя или фамилия для проверки</param>
        /// <returns>Корректное имя или фамилию</returns>
        protected string ValidationNameAndSurname(string nameOrSurname)
        {
            string nameOrSurnameCorrect = CorrectCaseNameAndSurname(
                nameOrSurname);
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
        /// <returns>Корректное имя или фамилию 
        /// с точки зрения правильности регистра</returns>
        private string CorrectCaseNameAndSurname(string nameOrSurname)
        {
            char[] doubleNameOrSurname = { ' ', '-', ',' };
            string[] nameOrSurnameChar = nameOrSurname.Split(
                doubleNameOrSurname, StringSplitOptions.RemoveEmptyEntries);
            switch (nameOrSurnameChar.Length)
            {
                case 1:
                {
                    string capitalName = Convert.ToString(
                        nameOrSurnameChar[0]).Substring(1).ToLower();
                    nameOrSurname = Convert.ToString(
                        nameOrSurnameChar[0])[0].ToString().ToUpper()
                                    + capitalName;
                    return nameOrSurname;
                }
                case 2:
                {
                    string capitalName1 = Convert.ToString(
                        nameOrSurnameChar[0]).Substring(1).ToLower();
                    string capitalName2 = Convert.ToString(
                        nameOrSurnameChar[1]).Substring(1).ToLower();
                    nameOrSurname = Convert.ToString(
                            nameOrSurnameChar[0])[0].ToString().ToUpper() + 
                        capitalName1 + " " + Convert.ToString(
                            nameOrSurnameChar[1])[0].ToString().ToUpper() + 
                        capitalName2;
                    return nameOrSurname;
                }
                default:
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
                "([a-z])([а-я])|([а-я])([a-z])|" +
                "([a-z]) ([а-я])|([а-я]) ([a-z])|([0-9])");
            if (errorAlphabet.IsMatch(nameOrSurname.ToLower()))
            {
                throw new Exception("Имя и Фамилия должны содержать \n" +
                    "только русские или только английские символы \n" +
                    "и не должны содержать цифры");
            }
        }

        /// <summary>
        /// Проверка фамилии персоны на соответствие языку, введеного имени
        /// </summary>
        /// <param name="surname">Фамилия для проверки</param>
        private void NameAndSurnameOnlyRusOrEng(string surname)
        {
            Regex rusAlphabet = new Regex("^[а-я]");
            
            if (!rusAlphabet.IsMatch(Name.ToLower()) 
                && rusAlphabet.IsMatch(surname.ToLower()) ||
                rusAlphabet.IsMatch(Name.ToLower()) 
                && !rusAlphabet.IsMatch(surname.ToLower()))
            {
                throw new Exception("Фамилия и имя " +
                    "должны быть написаны на одном языке");
            }
        }
        
        /// <summary>
        /// Полная инфомация о персоне
        /// </summary>
        public abstract string FullInfo { get; }
        
        /// <summary>
        /// Имя и фамилия персоны
        /// </summary>
        public string ShortInfo => $"{Name} {Surname}";

        /// <summary>
        /// Создаёт имя случайного взрослого
        /// </summary>
        /// <param name="rnd">Генератор случайных женщин</param>
        /// <param name="gender">Пол человека</param>
        /// <returns>Имя взрослого</returns>
        protected static string GetRandomName(Random rnd, GenderType gender)
        {
            string[] menNameArray = new string[10]
            {
                "Павел", "Антон",
                "Алексей", "Максим",
                "Александр", "Ярослав",
                "Илья", "Пётр",
                "Олег", "Сергей"
            };

            string[] womenNameArray = new string[10]
            {
                "Ольга", "Светлана",
                "Марина", "Олеся",
                "Анна", "Галина",
                "Алиса", "Вероника",
                "Вера", "Лариса" 
            };

            string womenName = womenNameArray[rnd.Next(
                                                     womenNameArray.Length)];
            string menName = menNameArray[rnd.Next(
                                                    menNameArray.Length)];

            return gender == GenderType.Мужской
                ? menName
                : womenName;
        }

        /// <summary>
        /// Создаёт случайного взрослого
        /// </summary>
        /// <param name="rnd">Генератор случайных мужчин</param>
        /// <param name="gender">Пол человека</param>
        /// <returns>Фамилия взрослого</returns>
        protected static string GetRandomSurname(Random rnd, GenderType gender)
        {
            string[] menSurnameArray = new string[10]
            { 
                "Иванов", "Петров",
                "Сидоров", "Какауров",
                "Ермолаев", "Еремеев",
                "Раздобреев",
                "Пляскин",
                "Загибалов",
                "Сергеев" 
            };

            string[] womenSurnameArray = new string[10]
            { 
                "Бардакова",
                "Филатова",
                "Попова",
                "Золотухина",
                "Сорокина",
                "Вычугжанина",
                "Стремилова",
                "Лопаницына",
                "Жеребцова",
                "Лосякова" 
            };

            string menSurname = menSurnameArray[rnd.Next(
                                                menSurnameArray.Length)];
            string womenSurname = womenSurnameArray[rnd.Next(
                          womenSurnameArray.Length)];

            return gender == GenderType.Мужской
                ? menSurname
                : womenSurname;
        }
    }
}
