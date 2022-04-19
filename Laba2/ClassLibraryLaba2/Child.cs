using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba2
{
    public class Child : PersonBase
    {
        /// <summary>
        /// Мать ребёнка
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Отец ребёнка
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Название детского сада/школы
        /// </summary>
        private string _nameOfKindergartenOrSchool;

        /// <summary>
        /// Метод для работы с матерью
        /// </summary>
        public Adult Mother
        {
            set => _mother = value;
            get => _mother;
        }

        /// <summary>
        /// Метод для работы с отцом
        /// </summary>
        public Adult Father
        {
            set => _father = value;
            get => _father;
        }

        /// <summary>
        /// Метод для работы с отцом
        /// </summary>
        public string NameOfKindergartenOrSchool
        {
            set => _nameOfKindergartenOrSchool = value;
            get => _nameOfKindergartenOrSchool;
        }

        public Child(string name, string surname, int age, GenderType gender)
            : base(name, surname, age, gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
    }
}
