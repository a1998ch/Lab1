using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba4WindowsForms
{
    /// <summary>
    /// Класс Circle
    /// </summary>
    public class Circle : FiguresAreaBase
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        private double _radius;

        /// <summary>
        /// Метод для работы с радиусом круга
        /// </summary>
        public double Radius
        {
            set => _radius = CheckValue(value);
            get => _radius;
        }

        /// <summary>
        /// Констукрутор по умолчанию класса "Круг"
        /// </summary>
        public Circle()
        {
        }

        /// <summary>
        /// Констукрутор класса "Круг"
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        public override double FigureArea
        {
            get => Math.Round(Math.Pow(Radius, 2) * Math.PI, 3);
        }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public override string Type => "Круг";
    }
}
