using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba2
{
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

        //public Adult(string name, string surname, int age, GenderType gender)
        //    : base(name, surname, age, gender)
        //{
        //    Name = name;
        //    Surname = surname;
        //    Age = age;
        //    Gender = gender;
        //}

        public Adult(int passportDetails, string placeOfWork,
            StateOfMarriageType stateOfMarriage,
            string name, string surname)
            : base(name, surname)
        {
            PassportDetails = passportDetails;
            PlaceOfWork = placeOfWork;
            StateOfMarriage = stateOfMarriage;
            Name = name;
            Surname = surname;
        }
    }
}
