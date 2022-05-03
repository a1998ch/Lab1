using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLaba3
{
    public class FiguresBase
    {
        private double _radius;

        private double _side;

        public double Radius
        {
            set => _radius = value;
            get => _radius;
        }

        public double Side
        {
            set => _side = value;
            get => _side;
        }

        public FiguresBase(double radius, double side)
        {
            Radius = radius;
            Side = side;
        }



        //public abstract double FigureArea()
    }
}
