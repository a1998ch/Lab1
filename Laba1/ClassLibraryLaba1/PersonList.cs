using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ModelLaba1
{
    public class PersonList
    {
        public Gender genderMetod()
        {
            Person person = new Person();
            string genderr;
            while (true)
            {
                WriteLine($"\nВведите пол: {Gender.Мужской} = \"М\" или {Gender.Женский} = \"Ж\" ");
                genderr = ReadLine();
                try
                {
                    if (genderr.ToLower() == "М".ToLower())
                    {
                        return person.genderPublic = Gender.Мужской;
                    }
                    else if (genderr.ToLower() == "Ж".ToLower())
                    {
                        return person.genderPublic = Gender.Женский;
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
        }


        public string[] spisok(string[] people1, string[] people2)
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


        public string[] MyAdd(string[] spisokPeople, string people)
        {
            Array.Resize(ref spisokPeople, spisokPeople.Length + 1);
            spisokPeople[spisokPeople.Length - 1] = people;
            return spisokPeople;
        }


        public string[] Del(string[] array, string personDel)
        {
            int remove = 0, count = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == personDel)
                {
                    remove = i;
                    count++;
                    break;
                }
            }

            if (count > 0)
            {
                string[] people = new string[array.Length - 1];

                for (int i = 0, j = 0; i < people.Length; ++i, ++j)
                {
                    if (j == remove)
                    {
                        ++j;
                    }
                    people[i] = array[j];
                }
                return people;
            }
            else
            {
                string[] people = array;
                return people;
            }
        }


        public string[] DelIndex(string[] array, int personDel)
        {
            int remove = 0, count = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (i == personDel)
                {
                    remove = i;
                    count++;
                    break;
                }
            }

            if (count > 0)
            {
                string[] people = new string[array.Length - 1];

                for (int i = 0, j = 0; i < people.Length; ++i, ++j)
                {
                    if (j == remove)
                    {
                        ++j;
                    }
                    people[i] = array[j];
                }
                return people;
            }
            else
            {
                string[] people = array;
                return people;
            }
        }


        public string SearchPeopleIndex(string[] array, int personIndex)
        {
            string person = "";
            int search = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (i == personIndex)
                {
                    search = i;
                    person = array[i];
                    break;
                }
            }
            return person;
        }


        public string SearchIndex(string[] array, string person)
        {
            string search = "";
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == person)
                {
                    search = Convert.ToString(i);
                    break;
                }
                else
                {
                    search = "Нет такого человека";
                }
            }
            return search;
        }


        public string[] Clean(string[] array)
        {
            string [] peopleClean = new string[0];
            return array = peopleClean;
        }


        public int MyLength(string[] array)
        {
            return array.Length;
        }
    }
}
