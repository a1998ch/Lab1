using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLaba3;
using static System.Console;

namespace ViewLaba3
{
    /// <summary>
    /// Класс Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа приложения
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        private static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;

            var figuresAreaList = new List<FiguresAreaBase>()
            {
                new Circle(5.6),
                new Rectangle(4, 5.7),
                new Triangle(3, 2, 4),
            };
            
            foreach (var figures in figuresAreaList)
            {
                WriteLine($"Area of a {figures.GetType().Name}: " +
                                    $"{{0}}", figures.FigureArea);
            }
            ReadLine();
        }
    }
}
