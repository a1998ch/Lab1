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
        public override string FullInfo
        {
           get => $"Имя: {Name}, " +
                        $"Фамилия: {Surname}, " +
                        $"Возраст: {Age}, " +
                        $"Пол: {Gender}, " + "\n" +
                        $"{{ Паспотные данные: { PassportDetails}" + "\n" +
                        $"  Самозанятость: {PlaceOfWork}" + "\n" +
                        $"  Семейное положение: {StateOfMarriage} " + "\n" +
                        $"  Имя и фамилия супруга/супруги: {NameAndSurnameWifeOrHusband}}}" + "\n";
        }

        /// <summary>
        /// Создаёт случайного взрослого
        /// </summary>
        /// <param name="adult">Генератор случайных взрослых</param>
        /// <param name="parents">Если данный параметр равен "f",
        /// то возвращает отца, если - "m", возвращает мать.
        /// В других случаях, возвращает случайного взрослого</param>
        /// <returns>Случайный взрослый</returns>
        public static Adult GetRandomAdult(Random adult, string parents = "")
        {
            GenderType[] genderArray =
                new GenderType[2] { GenderType.Мужской, GenderType.Женский };

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

            int age = adult.Next(18, 120);
            GenderType gender = genderArray[adult.Next(genderArray.Length)];
            int passportDetails = adult.Next(111111111, 999999999);
            string placeOfWork = placeOfWorkArray[adult.Next(
                                                   placeOfWorkArray.Length)];
            StateOfMarriageType stateOfMarriage =
               stateOfMarriageArray[adult.Next(stateOfMarriageArray.Length)];

            string nameAndSurnameWife =
                GetRandomWomen(adult) + " " + GetRandomWomen(adult, true);
            string nameAndSurnameHusband =
                GetRandomMen(adult) + " " + GetRandomMen(adult, true);

            if (stateOfMarriage != StateOfMarriageType.Married &&
                stateOfMarriage != StateOfMarriageType.CivilMarriage)
            {
                nameAndSurnameWife = nameAndSurnameHusband = "Отсутствует";
            }

            //TODO: duplication
            switch (parents)
            {
                case "m":
                    return new Adult(GetRandomWomen(adult), GetRandomWomen(adult, true), age,
                        GenderType.Женский, passportDetails, placeOfWork,
                        stateOfMarriage, nameAndSurnameHusband);
                case "f":
                    return new Adult(GetRandomMen(adult), GetRandomMen(adult, true), age,
                        GenderType.Мужской, passportDetails, placeOfWork,
                        stateOfMarriage, nameAndSurnameWife);
                default:
                    return gender == GenderType.Мужской
                        ? new Adult(GetRandomMen(adult), GetRandomMen(adult, true), age,
                            GenderType.Мужской, passportDetails, placeOfWork,
                            stateOfMarriage, nameAndSurnameWife)
                        : new Adult(GetRandomWomen(adult), GetRandomWomen(adult, true), age,
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
