using System;

namespace ModelLaba1
{
    /// <summary>
    /// Класс списка персон
    /// Включает в себя информацию о персонах
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список персон
        /// </summary>
        private Person[] _personList = new Person[0];

        /// <summary>
        /// Добавление персоны в список
        /// </summary>
        /// <param name="person">Экземпляр класса Person</param>
        public Person[] Add(Person person)
        {
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[_personList.Length - 1] = person;
            return _personList;
        }

        /// <summary>
        /// Информация обо всех элементах списка
        /// </summary>
        public string PrintPersonList()
        {
            string personList = "";
            for (int i = 0; i < _personList.Length; i++)
            {
                personList += _personList[i].Info() + "\n";
            }
            return personList;
        }

        /// <summary>
        /// Удаление персоны из списка по его данным
        /// </summary>
        /// <param name="person">Экземпляр класса Person</param>
        public void DelitePersonByData(Person person)
        {
            int remove = -1;
            for (int i = 0; i < _personList.Length; ++i)
            {
                if (_personList[i].Info() == person.Info())
                {
                    remove = i;
                    break;
                }
            }
            DelitePerson(remove);
        }

        /// <summary>
        /// Удаление персоны из списка по его индексу
        /// </summary>
        /// <param name="personIndex">Индекс персоны</param>
        public void DelitePersonByIndex(int personIndex)
        {
            int indexRemove = -1;
            for (int i = 0; i < _personList.Length; ++i)
            {
                if (i == personIndex)
                {
                    indexRemove = i;
                    break;
                }
            }
            DelitePerson(indexRemove);
        }

        /// <summary>
        /// Удаление персоны из списка
        /// </summary>
        /// <param name="personRemove">Индекс или данные персоны</param>
        private void DelitePerson(int personRemove)
        {
            if (personRemove >= 0)
            {
                for (int i = 0, j = 0; i < _personList.Length - 1; ++i, ++j)
                {
                    if (j == personRemove)
                    {
                        ++j;
                    }
                    _personList[i] = _personList[j];
                }
                Array.Resize(ref _personList, _personList.Length - 1);
            }
            else
            {
                throw new Exception("Удаляемый элемент отсутствует в текущем списке персон");
            }
        }

        /// <summary>
        /// Поиск персоны из списка по его индексу
        /// </summary>
        /// <param name="personIndex">Индекс персоны</param>
        /// <returns>Информация о персоне</returns>
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

        /// <summary>
        /// Поиск индекса персоны из списка по данным персоны
        /// </summary>
        /// <param name="person">Экземпляр класса Person</param>
        /// <returns>Индекс персоны</returns>
        public int SearchIndexByPerson(Person person)
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

        /// <summary>
        /// Удаление содержимого списка
        /// </summary>
        public void CleanList()
        {
            Array.Resize(ref _personList, 0);
        }
        
        /// <summary>
        /// Количество персон в списке
        /// </summary>
        public int Length => _personList.Length;
    }
}
