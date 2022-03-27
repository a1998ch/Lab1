using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO:

namespace ModelLaba1
{
    public class PersonList
    {
        private Person[] _personList = new Person[0];

        public Person[] Add(Person person)
        {
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[_personList.Length - 1] = person;
            return _personList;
        }

        public string PrintPersonList()
        {
            string personList = "";
            for (int i = 0; i < _personList.Length; i++)
            {
                personList += _personList[i].Info() + "\n";
            }
            return personList;
        }


        public void DelitePerson(Person person)
        {
            int remove = 0, count = 0;
            for (int i = 0; i < _personList.Length; ++i)
            {
                if (_personList[i].Info() == person.Info())
                {
                    remove = i;
                    count++;
                    break;
                }
            }

            if (count > 0)
            {
                for (int i = 0, j = 0; i < _personList.Length - 1; ++i, ++j)
                {
                    if (j == remove)
                    {
                        ++j;
                    }
                    _personList[i] = _personList[j];
                }
                Array.Resize(ref _personList, _personList.Length - 1);
            }
            else
            {
                throw new Exception("Нет такого человека");
            }
        }


        public void DeliteByIndex(int personIndex)
        {
            int indexRemove = 0, count = 0;
            for (int i = 0; i < _personList.Length; ++i)
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
                for (int i = 0, j = 0; i < _personList.Length - 1; ++i, ++j)
                {
                    if (j == indexRemove)
                    {
                        ++j;
                    }
                    _personList[i] = _personList[j];
                }
                Array.Resize(ref _personList, _personList.Length - 1);
            }
            else
            {
                throw new Exception("Нет такого индекса");
            }
        }


        public Person SearchByIndex(int personIndex)
        {
            if (personIndex < 0 || personIndex > _personList.Length - 1)
            {
                throw new Exception("Нет такого индекса");
            }
            else
            {
                return _personList[personIndex];
            }
        }


        public int SearchIndexByPeople(Person person)
        {
            int index = 0;
            for (int i = 0; i < _personList.Length; ++i)
            {
                if (_personList[i].Info() == person.Info())
                {
                    index = i;
                    break;
                }
                else if (i == _personList.Length - 1)
                {
                    throw new Exception("Нет такого человека");
                }
            }
            return index;
        }


        public void CleanList()
        {
            Array.Resize(ref _personList, 0);
        }


        public int LengthList()
        {
            return _personList.Length;
        }
    }
}
