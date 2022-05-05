using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLaba3;
using static System.Console;

namespace ViewLaba3
{
    public class Program
    {
        private static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;

            var figuresAreaList = new List<FiguresAreaBase>()
            {
                new Circle(5.6),
                new Rectangle(4, 5.7),
                new Triangle(1, 2, 3),
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
