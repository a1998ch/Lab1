using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba4WindowsForms
{
    /// <summary>
    /// Класс Rectangle
    /// </summary>
    public class Rectangle : FiguresAreaBase
    {
        /// <summary>
        /// Длинна одной из сторон прямоугольника
        /// </summary>
        private double _sideA;

        /// <summary>
        /// Длинна одной из сторон прямоугольника
        /// </summary>
        private double _sideB;

        /// <summary>
        /// Метод для работы с одной из сторон прямоугольника
        /// </summary>
        public double SideA
        {
            set => _sideA = CheckValue(value);
            get => _sideA;
        }

        /// <summary>
        /// Метод для работы с одной из сторон прямоугольника
        /// </summary>
        public double SideB
        {
            set => _sideB = CheckValue(value);
            get => _sideB;
        }

        /// <summary>
        /// Констукрутор класса "Прямоугольник"
        /// </summary>
        /// <param name="sideA">Длинна одной из сторон прямоугольника</param>
        /// <param name="sideB">Длинна одной из сторон прямоугольника</param>
        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        /// <summary>
        /// Площадь прямоугольника
        /// </summary>
        public override double FigureArea
        {
            get => Math.Round(SideA * SideB, 3);
        }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public override string Type => "Прямоугольник";
    }
}
