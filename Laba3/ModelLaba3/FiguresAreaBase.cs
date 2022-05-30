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

        //TODO: naming + комментарии
        /// <summary>
        /// Проверка знака (плюс или минус) отрезка фигуры
        /// </summary>
        /// <param name="lineSegment">Отрезок фигуры</param>
        /// <returns>Отрезок фигуры</returns>
        protected double CheckValue(double lineSegment)
        {
            return lineSegment <= 0
                ? throw new ArgumentException("Неправильный ввод данных")
                : lineSegment;
        }
    }
}
