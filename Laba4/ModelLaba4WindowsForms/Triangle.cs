using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba4WindowsForms
{
    /// <summary>
    /// Класс Triangle
    /// </summary>
    public class Triangle : FiguresAreaBase
    {
        /// <summary>
        /// Длинна одной из сторон треугольника
        /// </summary>
        private double _sideA;

        /// <summary>
        /// Длинна одной из сторон треугольника
        /// </summary>
        private double _sideB;

        /// <summary>
        /// Длинна одной из сторон треугольника
        /// </summary>
        private double _sideC;

        /// <summary>
        /// Метод для работы с одной из сторон треугольника
        /// </summary>
        public double SideA
        {
            set => _sideA = CheckValue(value);
            get => _sideA;
        }

        /// <summary>
        /// Метод для работы с одной из сторон треугольника
        /// </summary>
        public double SideB
        {
            set => _sideB = CheckValue(value);
            get => _sideB;
        }

        /// <summary>
        /// Метод для работы с одной из сторон треугольника
        /// </summary>
        public double SideC
        {
            set => _sideC = CheckValue(value);
            get => _sideC;
        }

        /// <summary>
        /// Констукрутор класса "Треугольник"
        /// </summary>
        /// <param name="sideA">Длинна одной из сторон треугольника</param>
        /// <param name="sideB">Длинна одной из сторон треугольника</param>
        /// <param name="sideC">Длинна одной из сторон треугольника</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA + sideB <= sideC
                || sideB + sideC <= sideA
                || sideC + sideA <= sideB)
            {
                throw new ArgumentException("Из введённых длин отрезков" +
                                        "невозможно построить треугольник");
            }
            else
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public override double FigureArea =>
            Math.Round(Math.Sqrt((SideA + SideB + SideC) *
                       ((SideA + SideB + SideC) - SideA) *
                       ((SideA + SideB + SideC) - SideB) *
                       ((SideA + SideB + SideC) - SideC)), 3);

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public override string Type => "Треугольник";
    }
}
