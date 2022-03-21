using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO:
using static System.Console;

namespace ModelLaba1
{
    public class PersonList
    {
        private Person[] _personList = new Person[0];

        public Person[] MyAdd(Person person)
        {
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[_personList.Length - 1] = person;
            return _personList;
        }

        /*public GenderType GenderMetod()
        {
            Person person = new Person();
            string gender;
            while (true)
            {
                WriteLine($"\nВведите пол: {GenderType.Мужской} = \"М\" или {GenderType.Женский} = \"Ж\" ");
                gender = ReadLine();
                try
                {
                    if (gender.ToLower() == "М".ToLower())
                    {
                        return person.Gender = GenderType.Мужской;
                    }
                    else if (gender.ToLower() == "Ж".ToLower())
                    {
                        return person.Gender = GenderType.Женский;
                    }
                    else
                    {
                        throw new Exception("Неправильный пол");
                    }
                }
                catch (Exception ex)
                {
                    WriteLine($"\nОшибка: {ex.Message}");
                }
            }
        }*/


        public string[] SpisokChoice(string[] people1, string[] people2)
        {
            string spisok;
            while (true)
            {
                WriteLine($"\nВыберете список персон: 1 или 2");
                spisok = ReadLine();
                try
                {
                    if (spisok == "1")
                    {
                        return people1;
                    }
                    else if (spisok == "2")
                    {
                        return people2;
                    }
                    else
                    {
                        throw new Exception("Нет такого списка");
                    }
                }
                catch (Exception ex)
                {
                    WriteLine($"\nОшибка: {ex.Message}");
                }
            }
        }


        public string[] Del(string[] personArray, string person)
        {
            int remove = 0, count = 0;
            for (int i = 0; i < personArray.Length; ++i)
            {
                if (personArray[i] == person)
                {
                    remove = i;
                    count++;
                    break;
                }
            }

            if (count > 0)
            {
                string[] people = new string[personArray.Length - 1];

                for (int i = 0, j = 0; i < people.Length; ++i, ++j)
                {
                    if (j == remove)
                    {
                        ++j;
                    }
                    people[i] = personArray[j];
                }
                return people;
            }
            else
            {
                string[] people = personArray;
                return people;
            }
        }


        public string[] DelIndex(string[] personArray, int personIndex)
        {
            int indexRemove = 0, count = 0;
            for (int i = 0; i < personArray.Length; ++i)
            {
                if (i == personIndex)
                {
                    indexRemove = i;
                    count++;
                    break;
                }
            }

            if (count > 0)
            {
                string[] people = new string[personArray.Length - 1];

                for (int i = 0, j = 0; i < people.Length; ++i, ++j)
                {
                    if (j == indexRemove)
                    {
                        ++j;
                    }
                    people[i] = personArray[j];
                }
                return people;
            }
            else
            {
                string[] people = personArray;
                return people;
            }
        }


        public Person SearchByIndex(int personIndex)
        {
            if (personIndex < 0 || personIndex > _personList.Length - 1)
            {
                //TODO: реализовать обработку выхода за границы массива
            }

            return _personList[personIndex];
        }


        public string SearchIndexPeople(string[] personArray, string person)
        {
            string index = "";
            for (int i = 0; i < personArray.Length; ++i)
            {
                if (personArray[i] == person)
                {
                    index = Convert.ToString(i);
                    break;
                }
                else
                {
                    index = "Нет такого человека";
                }
            }
            return index;
        }


        public string[] Clean(string[] personArray)
        {
            string [] emptyArray = new string[0];
            return personArray = emptyArray;
        }


        public int MyLength(string[] personArray)
        {
            return personArray.Length;
        }
    }
}
