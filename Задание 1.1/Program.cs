using System;

namespace Задание_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, c; // Вводим и задаём тип переменных
            Console.Write("Введите x: ");
            x = double.Parse(Console.ReadLine()); // Для ввода переменных с консоли
            Console.Write("Введите y: ");
            y = double.Parse(Console.ReadLine());
            c = Math.Atan(y / x) * 180 / Math.PI; // Определение угла
            Console.WriteLine("Угол: {0}", c); // Вывод результата
        }
    }
}