using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba3
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
            set => _radius = DataCorrectness(value);
            get => _radius;
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
            get => Math.Pow(Radius, 2) * Math.PI;
        }
    }
}
