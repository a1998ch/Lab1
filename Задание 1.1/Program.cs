using System;

namespace Задание_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, c, sum, diff; // Вводим и задаём тип переменных
            Console.Write("Введите x: ");
            x = double.Parse(Console.ReadLine()); // Для ввода переменных с консоли
            Console.Write("Введите y: ");
            y = double.Parse(Console.ReadLine());
            c = Math.Atan(y / x) * 180 / Math.PI; // Определение угла
            sum = x + y;
            diff = x - y;
            Console.WriteLine("Угол: {0}", c); // Вывод результата
            Console.WriteLine("Сумма: {0}", sum, diff);
            Console.WriteLine("Разность: {0}", diff);
            Console.WriteLine("Умножение: {0}", umn(sum, diff));
        }

        public static double umn(double a, double b)
        {
            double c = a * b;
            return c;
        }
    }
}