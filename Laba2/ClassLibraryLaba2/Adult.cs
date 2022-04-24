using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba2
{
    /// <summary>
    /// Класс Adult 
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Возраст взрослого
        /// </summary>
        private int _age;

        /// <summary>
        /// Паспортные данные
        /// </summary>
        private int _passportDetails;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _placeOfWork;

        /// <summary>
        /// Состояние брака 
        /// </summary>
        private StateOfMarriageType _stateOfMarriage;

        /// <summary>
        /// Имя и фамилия супруга/супруги
        /// </summary>
        private string _nameAndSurnameWifeOrHusband;

        /// <summary>
        /// Минимальный возраст взрослого
        /// </summary>
        public const int MinAgeAdult = 18;

        /// <summary>
        /// Метод для работы с паспортными данными
        /// </summary>
        public int PassportDetails
        {
            set => _passportDetails = value;
            get => _passportDetails;
        }

        /// <summary>
        /// Метод для работы с местом работы
        /// </summary>
        public string PlaceOfWork
        {
            set => _placeOfWork = value;
            get => _placeOfWork;
        }

        /// <summary>
        /// Метод для работы с семейным положением
        /// </summary>
        public StateOfMarriageType StateOfMarriage
        {
            set => _stateOfMarriage = value;
            get => _stateOfMarriage;
        }

        /// <summary>
        /// Метод для работы с именем и фамилией супруга/супруги
        /// </summary>
        public string NameAndSurnameWifeOrHusband
        {
            set => _nameAndSurnameWifeOrHusband =
                        ValidationNameAndSurname(value);
            get => _nameAndSurnameWifeOrHusband;
        }

        /// <summary>
        /// Метод для работы с возрастом взрослого
        /// </summary>
        public override int Age
        {
            set => _age = AgeEntryRule(value);
            get => _age;
        }

        /// <summary>
        /// Констукрутор класса взросого
        /// </summary>
        /// <param name="name">Имя персоны</param>
        /// <param name="surname">Фамилия персоны</param>
        /// <param name="age">Возраст персоны</param>
        /// <param name="gender">Пол персоны</param>
        /// <param name="passportDetails">Паспортные данные персоны</param>
        /// <param name="placeOfWork">Профессия персоны</param>
        /// <param name="stateOfMarriage">Семейное положение персоны</param>
        /// <param name="nameAndSurnameWifeOrHusband">
        /// имя и фамилия супруга/супруги персоны</param>
        public Adult(string name, string surname, int age, GenderType gender,
            int passportDetails, string placeOfWork,
            StateOfMarriageType stateOfMarriage, string nameAndSurnameWifeOrHusband)
            : base(name, surname, age, gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            PassportDetails = passportDetails;
            PlaceOfWork = placeOfWork;
            StateOfMarriage = stateOfMarriage;
            NameAndSurnameWifeOrHusband = nameAndSurnameWifeOrHusband;
        }

        /// <summary>
        /// Корректный ввод возраста взрослого
        /// </summary>
        /// <param name="age">Возраст персоны</param>
        /// <returns>Корректный возраст</returns>
        protected override int AgeEntryRule(int age)
        {
            if (age > MaxAge || age < MinAgeAdult)
            {
                throw new Exception($"Необходимо вводить числа" +
                    $" от \"{MinAgeAdult}\" до \"{MaxAge}\"");
            }
            else
            {
                return age;
            }
        }

        /// <summary>
        /// Информация о взрослом
        /// </summary>
        public override string Info(bool conditionAdultOrChild = false)
        {
            if (!conditionAdultOrChild)
            {
                return  $"Имя: {Name}, " +
                        $"Фамилия: {Surname}, " +
                        $"Возраст: {Age}, " +
                        $"Пол: {Gender}, " + "\n" +
                        $"{{ Паспотные данные: { PassportDetails}" + "\n" +
                        $"  Самозанятость: {PlaceOfWork}" + "\n" +
                        $"  Семейное положение: {StateOfMarriage} " + "\n" +
                        $"  Имя и фамилия супруга/супруги: {NameAndSurnameWifeOrHusband}}}" + "\n";
            }
            else
            {
                return Name + " " + Surname;
            }
        }

        /// <summary>
        /// Создаёт случайного взрослого
        /// </summary>
        /// <param name="mother">Мать</param>
        /// <param name="father">Отец</param>
        /// <returns>Случайный взрослый</returns>
        public static Adult GetRandomAdult(
            string mother = "m", string father = "f")
        {
            Random adult = new Random(DateTime.Now.Second);

            string[] menNameArray = new string[10] { "Павел", "Антон",
                                                    "Алексей", "Максим",
                                                    "Александр", "Ярослав",
                                                        "Илья", "Пётр",
                                                        "Олег", "Сергей" };
            string[] womenNameArray = new string[10] { "Ольга", "Светлана",
                                                        "Марина", "Олеся",
                                                        "Анна", "Галина",
                                                        "Алиса", "Вероника",
                                                        "Вера", "Лариса" };
            string[] menSurnameArray = new string[10] { "Иванов", "Петров",
                                                        "Сидоров", "Какауров",
                                                        "Ермолаев", "Еремеев",
                                                        "Раздобреев",
                                                        "Пляскин",
                                                        "Загибалов",
                                                        "Сергеев" };
            string[] womenSurnameArray = new string[10] { "Бардакова",
                                                          "Филатова",
                                                          "Попова",
                                                          "Золотухина",
                                                          "Сорокина",
                                                          "Вычугжанина",
                                                          "Стремилова",
                                                          "Лопаницына",
                                                          "Жеребцова",
                                                          "Лосякова" };
            string[] genderArray = new string[2] { "Мужской", "Женский" };

            string[] placeOfWorkArray = new string[10] { "Энергетик",
                                                         "Програмист",
                                                        "Водитель",
                                                        "Строитель",
                                                        "Сантехник",
                                                        "Учитель",
                                                        "ИП", "Бухгалтер",
                                                        "Безработный",
                                                                "Музыкант"};

            StateOfMarriageType[] stateOfMarriageArray = new 
                StateOfMarriageType[4] { StateOfMarriageType.Married,
                                         StateOfMarriageType.NotMarried,
                                         StateOfMarriageType.Divorced,
                                         StateOfMarriageType.CivilMarriage};

            string menName = menNameArray[adult.Next(menNameArray.Length)];
            string menSurname = menSurnameArray[adult.Next(
                                                    menSurnameArray.Length)];
            string womenName = womenNameArray[adult.Next(
                                                     womenNameArray.Length)];
            string womenSurname = womenSurnameArray[adult.Next(
                                                  womenSurnameArray.Length)];
            int age = adult.Next(18, 120);
            string gender = genderArray[adult.Next(genderArray.Length)];
            int passportDetails = adult.Next(111111111, 999999999);
            string placeOfWork = placeOfWorkArray[adult.Next(
                                                   placeOfWorkArray.Length)];
            StateOfMarriageType stateOfMarriage = 
               stateOfMarriageArray[adult.Next(stateOfMarriageArray.Length)];
            
            string nameAndSurnameWife = womenName + " " + womenSurname;
            string nameAndSurnameHusband = menName + " " + menSurname;

            if (stateOfMarriage != StateOfMarriageType.Married &&
                stateOfMarriage != StateOfMarriageType.CivilMarriage)
            {
                nameAndSurnameWife = nameAndSurnameHusband = "Отсутствует";
            }

            if (mother == "m")
            {
                return new Adult(womenName, womenSurname, age, 
                    GenderType.Женский, passportDetails, placeOfWork, 
                    stateOfMarriage, nameAndSurnameHusband);
            }
            else if (father == "f")
            {
                return new Adult(menName, menSurname, age,
                    GenderType.Мужской, passportDetails, placeOfWork,
                    stateOfMarriage, nameAndSurnameWife);
            }
            else
            {
                return gender == Convert.ToString(GenderType.Мужской)
                    ? new Adult(menName, menSurname, age,
                        GenderType.Мужской, passportDetails, placeOfWork,
                        stateOfMarriage, nameAndSurnameWife)
                    : new Adult(womenName, womenSurname, age, 
                        GenderType.Женский, passportDetails, placeOfWork,
                        stateOfMarriage, nameAndSurnameHusband);
            }
        }

        /// <summary>
        /// Метод для идентификации взрослого
        /// </summary>
        /// <returns>Строку</returns>
        public string TestTypeAdult()
        {
            return "↑ Это взрослый";
        }
    }
}
