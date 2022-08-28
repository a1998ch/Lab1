using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModelLaba4WindowsForms
{
    /// <summary>
    /// Класс FiguresAreaBase
    /// </summary>
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    public abstract class FiguresAreaBase
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public abstract double FigureArea { get; }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public abstract string Type { get; }

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
