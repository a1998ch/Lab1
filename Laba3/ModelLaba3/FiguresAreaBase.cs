using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba3
{
    /// <summary>
    /// Класс FiguresAreaBase
    /// </summary>
    public abstract class FiguresAreaBase
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public abstract double FigureArea { get; }

        /// <summary>
        /// Корректный ввод данных фигуры
        /// </summary>
        /// <param name="data">Параметр фигуры</param>
        /// <returns>Корректные параметры фигуры</returns>
        protected double DataCorrectness(double data)
        {
            if (data <= 0)
            {
                throw new ArgumentException("Неправильный ввод данных");
            }
            else
            {
                return data;
            }
        }
    }
}
